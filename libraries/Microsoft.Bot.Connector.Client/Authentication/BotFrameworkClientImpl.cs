﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Connector.Client.Bot.Builder;
using Microsoft.Bot.Connector.Schema;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Microsoft.Bot.Connector.Client.Authentication
{
    internal class BotFrameworkClientImpl : BotFrameworkClient
    {
        private readonly ServiceClientCredentialsFactory _credentialsFactory;
        private readonly HttpClient _httpClient;
        private readonly string _loginEndpoint;
        private readonly ILogger _logger;
        private bool _disposed;

        public BotFrameworkClientImpl(
            ServiceClientCredentialsFactory credentialsFactory,
            IHttpClientFactory httpClientFactory,
            string loginEndpoint,
            ILogger logger)
        {
            _credentialsFactory = credentialsFactory;
            _httpClient = httpClientFactory?.CreateClient() ?? new HttpClient();
            _loginEndpoint = loginEndpoint;
            _logger = logger ?? NullLogger.Instance;
            ConnectorClient.AddDefaultRequestHeaders(_httpClient);
        }

        public async override Task<InvokeResponse<T>> PostActivityAsync<T>(string fromBotId, string toBotId, Uri toUrl, Uri serviceUrl, string conversationId, Activity activity, CancellationToken cancellationToken = default)
        {
            _ = fromBotId ?? throw new ArgumentNullException(nameof(fromBotId));
            _ = toBotId ?? throw new ArgumentNullException(nameof(toBotId));
            _ = toUrl ?? throw new ArgumentNullException(nameof(toUrl));
            _ = serviceUrl ?? throw new ArgumentNullException(nameof(serviceUrl));
            _ = conversationId ?? throw new ArgumentNullException(nameof(conversationId));
            _ = activity ?? throw new ArgumentNullException(nameof(activity));

            _logger.LogInformation($"post to skill '{toBotId}' at '{toUrl}'");

            var credentials = await _credentialsFactory.CreateCredentialsAsync(fromBotId, toBotId, _loginEndpoint, true, cancellationToken).ConfigureAwait(false);

            // Clone the activity so we can modify it before sending without impacting the original object.
            var activityClone = JsonSerializer.Deserialize<Activity>(JsonSerializer.Serialize(activity));

            // Apply the appropriate addressing to the newly created Activity.
            activityClone.RelatesTo = new ConversationReference
            {
                ServiceUrl = activityClone.ServiceUrl,
                ActivityId = activityClone.Id,
                ChannelId = activityClone.ChannelId,
                Locale = activityClone.Locale,
                Conversation = new ConversationAccount
                {
                    Id = activityClone.Conversation.Id,
                    Name = activityClone.Conversation.Name,
                    ConversationType = activityClone.Conversation.ConversationType,
                    AadObjectId = activityClone.Conversation.AadObjectId,
                    IsGroup = activityClone.Conversation.IsGroup,
                    Properties = activityClone.Conversation.Properties,
                    Role = activityClone.Conversation.Role,
                    TenantId = activityClone.Conversation.TenantId,
                }
            };
            activityClone.Conversation.Id = conversationId;
            activityClone.ServiceUrl = serviceUrl.ToString();
            activityClone.Recipient ??= new ChannelAccount();
            activityClone.Recipient.Role = RoleTypes.Skill;

            // Create the HTTP request from the cloned Activity and send it to the Skill.
            using (var jsonContent = new StringContent(JsonSerializer.Serialize(activityClone, SerializationConfig.DefaultSerializeOptions), Encoding.UTF8, "application/json"))
            {
                using (var httpRequestMessage = new HttpRequestMessage())
                {
                    httpRequestMessage.Method = HttpMethod.Post;
                    httpRequestMessage.RequestUri = toUrl;
                    httpRequestMessage.Content = jsonContent;

                    httpRequestMessage.Headers.Add(ConversationConstants.ConversationIdHttpHeaderName, conversationId);

                    // Add the auth header to the HTTP request.
                    await credentials.ProcessHttpRequestAsync(httpRequestMessage, cancellationToken).ConfigureAwait(false);

                    using (var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage, cancellationToken).ConfigureAwait(false))
                    {
                        var content = httpResponseMessage.Content != null ? await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false) : null;

                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            // On success assuming either JSON that can be deserialized to T or empty.
                            return new InvokeResponse<T>
                            {
                                Status = (int)httpResponseMessage.StatusCode,
                                Body = content?.Length > 0 ? content.Deserialize<T>() : default
                            };
                        }
                        else
                        {
                            // Otherwise we can assume we don't have a T to deserialize - so just log the content so it's not lost.
                            _logger.LogError($"Bot Framework call failed to '{toUrl}' returning '{(int)httpResponseMessage.StatusCode}' and '{content}'");

                            // We want to at least propogate the status code because that is what InvokeResponse expects.
                            return new InvokeResponse<T>
                            {
                                Status = (int)httpResponseMessage.StatusCode,
                                Body = typeof(T) == typeof(object) ? (T)(object)content : default,
                            };
                        }
                    }
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            _httpClient.Dispose();
            base.Dispose(disposing);
            _disposed = true;
        }
    }
}
