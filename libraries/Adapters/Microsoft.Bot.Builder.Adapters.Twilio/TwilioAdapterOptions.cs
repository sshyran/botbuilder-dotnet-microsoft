﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Bot.Builder.Adapters.Twilio
{
    /// <summary>
    /// Options for the <see cref="TwilioAdapter"/>.
    /// </summary>
    public class TwilioAdapterOptions
    {
        /// <summary>
        /// Gets or sets a value indicating whether incoming requests should be validated as coming from Twilio.
        /// </summary>
        /// <value>
        /// A value indicating whether incoming requests should be validated as coming from Twilio.
        /// </value>
        public bool ValidateIncomingRequests { get; set; } = true;

        /// <summary>
        /// Gets or sets a value for an Id used to represent your bot application and
        /// it should be consistent across all adapters. If you are using Azure Bot Service
        /// channels then you should use your MicrosoftAppId.
        /// </summary>
        /// <value>
        /// A value for an Id used to represent your bot application and
        /// it should be consistent across all adapters. If you are using Azure Bot Service
        /// channels then you should use your MicrosoftAppId.
        /// </value>
        public string AppId { get; set; } = null;
    }
}
