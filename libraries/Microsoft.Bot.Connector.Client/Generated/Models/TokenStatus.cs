// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Microsoft.Bot.Connector.Client.Models
{
    /// <summary> The status of a particular token. </summary>
    public partial class TokenStatus
    {
        /// <summary> Initializes a new instance of TokenStatus. </summary>
        internal TokenStatus()
        {
        }

        /// <summary> Initializes a new instance of TokenStatus. </summary>
        /// <param name="channelId"> The channelId of the token status pertains to. </param>
        /// <param name="connectionName"> The name of the connection the token status pertains to. </param>
        /// <param name="hasToken"> True if a token is stored for this ConnectionName. </param>
        /// <param name="serviceProviderDisplayName"> The display name of the service provider for which this Token belongs to. </param>
        internal TokenStatus(string channelId, string connectionName, bool? hasToken, string serviceProviderDisplayName)
        {
            ChannelId = channelId;
            ConnectionName = connectionName;
            HasToken = hasToken;
            ServiceProviderDisplayName = serviceProviderDisplayName;
        }

        /// <summary> The channelId of the token status pertains to. </summary>
        public string ChannelId { get; }
        /// <summary> The name of the connection the token status pertains to. </summary>
        public string ConnectionName { get; }
        /// <summary> True if a token is stored for this ConnectionName. </summary>
        public bool? HasToken { get; }
        /// <summary> The display name of the service provider for which this Token belongs to. </summary>
        public string ServiceProviderDisplayName { get; }
    }
}
