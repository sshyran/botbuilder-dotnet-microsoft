﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Bot.Builder.Adapters.Facebook.TestBot;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Schema;
using Microsoft.BotBuilderSamples.DialogRootBot.Middleware;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Microsoft.Bot.Builder.Adapters.Facebook.PrimaryTestBot
{
    /// <summary>
    /// A <see cref="FacebookAdapter"/> specialized to append tags to messages.
    /// </summary>
    public class FacebookAdapterWithTag : FacebookAdapter
    {
        public FacebookAdapterWithTag(IConfiguration configuration, FacebookAdapterOptions options = null, ILogger<BotFrameworkHttpAdapter> logger = null)
            : base(configuration, options, logger)
        {
            Program.WriteToLog("Debug 2 FacebookAdapterWithTag");
            logger.LogInformation("Debug 2");
            Use(new LoggerMiddleware(logger));
        }

        public FacebookAdapterWithTag(FacebookClientWrapper facebookClient, FacebookAdapterOptions options, ILogger<BotFrameworkHttpAdapter> logger = null)
            : base(facebookClient, options, logger)
        {
            Program.WriteToLog("Debug 3 FacebookAdapterWithTag");
            logger.LogInformation("Debug 3");
            Use(new LoggerMiddleware(logger));
        }

        protected override FacebookMessage CreateFacebookMessageFromActivity(Activity activity)
        {
            // This override takes the facebook message created by the base adapter
            // and sets the tag to "ACCOUNT_UPDATE" as defined in
            // https://developers.facebook.com/docs/messenger-platform/send-messages/message-tags#sending
            // This bypasses the 24 hrs check for responses to a bot that don't go through the messenger client.
            var message = base.CreateFacebookMessageFromActivity(activity);
            message.MessagingType = "MESSAGE_TAG";
            message.Tag = "ACCOUNT_UPDATE";

            return message;
        }
    }
}
