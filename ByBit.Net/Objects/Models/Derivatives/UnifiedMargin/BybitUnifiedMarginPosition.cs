using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.Derivatives;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.UnifiedMargin
{
    /// <summary>
    /// Position info
    /// </summary>
    public class BybitUnifiedMarginPosition : BybitDerivativesPosition
    {
        /// <summary>
        /// Type of derivatives product: linear or option.
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Settlement price, for USDC only
        /// </summary>
        [JsonProperty("sessionAvgPrice")]
        public decimal SettlementPrice { get; set; }

        /// <summary>
        /// Mark price
        /// </summary>
        public decimal MarkPrice { get; set; }

        /// <summary>
        /// Position Initial margin
        /// </summary>
        [JsonProperty("positionIM")]
        public decimal InitialMargin { get; set; }

        /// <summary>
        /// Position Maintenance margin
        /// </summary>
        [JsonProperty("positionMM")]
        public decimal MaintenanceMargin { get; set; }

        /// <summary>
        /// Position status
        /// </summary>
        [JsonConverter(typeof(PositionStatusConverter))]
        public PositionStatus PositionStatus { get; set; }

        /// <summary>
        /// Accumulated realized pnl (all-time total)
        /// </summary>
        [JsonProperty("cumRealisedPnl")]
        public decimal TotalRealizedPnl { get; set; }
    }
}
