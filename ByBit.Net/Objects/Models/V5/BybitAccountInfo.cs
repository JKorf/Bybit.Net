using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Account info
    /// </summary>
    public class BybitAccountInfo
    {
        /// <summary>
        /// Account status
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public UnifiedMarginStatus AccountStatus { get; set; }
        /// <summary>
        /// Margin info
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public MarginMode MarginMode { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("updatedTime")]
        public DateTime UpdateTime { get; set; }
    }
}
