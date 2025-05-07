using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Account info
    /// </summary>
    [SerializationModel]
    public record BybitAccountInfo
    {
        /// <summary>
        /// Unified margin status
        /// </summary>

        [JsonPropertyName("unifiedMarginStatus")]
        public UnifiedMarginStatus UnifiedMarginStatus { get; set; }
        /// <summary>
        /// Margin info
        /// </summary>

        [JsonPropertyName("marginMode")]
        public MarginMode MarginMode { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonPropertyName("updatedTime")]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// Disconnect-CancelAll-Prevention status
        /// </summary>
        [JsonPropertyName("dcpStatus")]
        public string DcpStatus { get; set; } = string.Empty;
        /// <summary>
        /// Smp group id
        /// </summary>
        [JsonPropertyName("smpGroup")]
        public int SmpGroup { get; set; }
        /// <summary>
        /// Dcp trigger time
        /// </summary>
        [JsonPropertyName("timeWindow")]
        public int DcpTimeWindow { get; set; }
        /// <summary>
        /// Whether the account is a master trader (copytrading)
        /// </summary>
        [JsonPropertyName("isMasterTrader")]
        public bool IsMasterTrader { get; set; }
        /// <summary>
        /// Whether the unified account enables Spot hedging
        /// </summary>
        [JsonPropertyName("spotHedgingStatus")]
        [JsonConverter(typeof(BoolConverter))]
        public bool SpotHedgingStatus { get; set; }
    }
}
