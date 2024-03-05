using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Set Margin Mode result
    /// </summary>
    public class BybitSetMarginModeResult
    {
        /// <summary>
        /// Failure reasons. If empty it was successful
        /// </summary>
        public IEnumerable<BybitReason> Reasons { get; set; } = Array.Empty<BybitReason>();
    }

    /// <summary>
    /// Reason
    /// </summary>
    public class BybitReason
    {
        /// <summary>
        /// Reason code
        /// </summary>
        public string ReasonCode { get; set; } = string.Empty;
        /// <summary>
        /// Reason message
        /// </summary>
        [JsonProperty("reasonMsg")]
        public string ReasonMessage { get; set; } = string.Empty;
    }
}
