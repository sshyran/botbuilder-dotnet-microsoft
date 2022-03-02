﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Microsoft.Bot.Connector.Schema.Teams
{
    /// <summary>
    /// Tab SuggestedActions (Only when type is 'auth' or 'silentAuth').
    /// </summary>
    public partial class TabSuggestedActions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TabSuggestedActions"/> class.
        /// </summary>
        public TabSuggestedActions()
        {
            CustomInit();
        }

        /// <summary>
        /// Gets or sets actions for a card tab response.
        /// </summary>
        /// <value>
        /// Actions for this <see cref="TabSuggestedActions"/>.
        /// </value>
        [JsonPropertyName("actions")]
#pragma warning disable CA2227 // Collection properties should be read only
        public IList<CardAction> Actions { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults.
        /// </summary>
        partial void CustomInit();
    }
}