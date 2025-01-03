﻿using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Set Margin Mode result
    /// </summary>
    public record BybitSetMarginModeResult
    {
        /// <summary>
        /// Failure reasons. If empty it was successful
        /// </summary>
        [JsonPropertyName("reasons")]
        public IEnumerable<BybitReason> Reasons { get; set; } = Array.Empty<BybitReason>();
    }

    /// <summary>
    /// Reason
    /// </summary>
    public record BybitReason
    {
        /// <summary>
        /// Reason code
        /// </summary>
        [JsonPropertyName("reasonCode")]
        public string ReasonCode { get; set; } = string.Empty;
        /// <summary>
        /// Reason message
        /// </summary>
        [JsonPropertyName("reasonMsg")]
        public string ReasonMessage { get; set; } = string.Empty;
    }
}
