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
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// Disconnect-CancelAll-Prevention status
        /// </summary>
        public string DcpStatus { get; set; } = string.Empty;
        /// <summary>
        /// Smp group id
        /// </summary>
        public int SmpGroup { get; set; }
        /// <summary>
        /// Dcp trigger time
        /// </summary>
        [JsonProperty("timeWindow")]
        public int DcpTimeWindow { get; set; }
    }
}
