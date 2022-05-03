// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Bot.Connector.Client.Models;

namespace Microsoft.Bot.Connector.Client
{
    internal partial class BotSignInRestClient
    {
        private Uri endpoint;
        private ClientDiagnostics _clientDiagnostics;
        private HttpPipeline _pipeline;

        /// <summary> Initializes a new instance of BotSignInRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        public BotSignInRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            endpoint ??= new Uri("https://botframework.com");

            this.endpoint = endpoint;
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        internal HttpMessage CreateGetSignInUrlRequest(string state, string codeChallenge, string emulatorUrl, string finalRedirect)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/api/botsignin/GetSignInUrl", false);
            uri.AppendQuery("state", state, true);
            if (codeChallenge != null)
            {
                uri.AppendQuery("code_challenge", codeChallenge, true);
            }
            if (emulatorUrl != null)
            {
                uri.AppendQuery("emulatorUrl", emulatorUrl, true);
            }
            if (finalRedirect != null)
            {
                uri.AppendQuery("finalRedirect", finalRedirect, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "text/plain");
            return message;
        }

        /// <param name="state"> The String to use. </param>
        /// <param name="codeChallenge"> The String to use. </param>
        /// <param name="emulatorUrl"> The String to use. </param>
        /// <param name="finalRedirect"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="state"/> is null. </exception>
        public async Task<Response<string>> GetSignInUrlAsync(string state, string codeChallenge = null, string emulatorUrl = null, string finalRedirect = null, CancellationToken cancellationToken = default)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }

            using var message = CreateGetSignInUrlRequest(state, codeChallenge, emulatorUrl, finalRedirect);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        StreamReader streamReader = new StreamReader(message.Response.ContentStream);
                        string value = await streamReader.ReadToEndAsync().ConfigureAwait(false);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <param name="state"> The String to use. </param>
        /// <param name="codeChallenge"> The String to use. </param>
        /// <param name="emulatorUrl"> The String to use. </param>
        /// <param name="finalRedirect"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="state"/> is null. </exception>
        public Response<string> GetSignInUrl(string state, string codeChallenge = null, string emulatorUrl = null, string finalRedirect = null, CancellationToken cancellationToken = default)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }

            using var message = CreateGetSignInUrlRequest(state, codeChallenge, emulatorUrl, finalRedirect);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        StreamReader streamReader = new StreamReader(message.Response.ContentStream);
                        string value = streamReader.ReadToEnd();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetSignInResourceRequest(string state, string codeChallenge, string emulatorUrl, string finalRedirect)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/api/botsignin/GetSignInResource", false);
            uri.AppendQuery("state", state, true);
            if (codeChallenge != null)
            {
                uri.AppendQuery("code_challenge", codeChallenge, true);
            }
            if (emulatorUrl != null)
            {
                uri.AppendQuery("emulatorUrl", emulatorUrl, true);
            }
            if (finalRedirect != null)
            {
                uri.AppendQuery("finalRedirect", finalRedirect, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json, text/json");
            return message;
        }

        /// <param name="state"> The String to use. </param>
        /// <param name="codeChallenge"> The String to use. </param>
        /// <param name="emulatorUrl"> The String to use. </param>
        /// <param name="finalRedirect"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="state"/> is null. </exception>
        public async Task<Response<SignInResource>> GetSignInResourceAsync(string state, string codeChallenge = null, string emulatorUrl = null, string finalRedirect = null, CancellationToken cancellationToken = default)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }

            using var message = CreateGetSignInResourceRequest(state, codeChallenge, emulatorUrl, finalRedirect);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SignInResource value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = SignInResource.DeserializeSignInResource(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <param name="state"> The String to use. </param>
        /// <param name="codeChallenge"> The String to use. </param>
        /// <param name="emulatorUrl"> The String to use. </param>
        /// <param name="finalRedirect"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="state"/> is null. </exception>
        public Response<SignInResource> GetSignInResource(string state, string codeChallenge = null, string emulatorUrl = null, string finalRedirect = null, CancellationToken cancellationToken = default)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }

            using var message = CreateGetSignInResourceRequest(state, codeChallenge, emulatorUrl, finalRedirect);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SignInResource value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = SignInResource.DeserializeSignInResource(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}
