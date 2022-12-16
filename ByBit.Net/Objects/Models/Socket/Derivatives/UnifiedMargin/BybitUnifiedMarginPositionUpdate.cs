using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.Socket.Derivatives.UnifiedMargin
{
    /// <summary>
    /// Position update
    /// </summary>
    public class BybitUnifiedMarginPositionUpdate : BybitDerivativesPositionUpdate
    {
        /// <summary>
        /// Settlement price, for USDC only
        /// </summary>
        [JsonProperty("sessionAvgPrice")]
        public decimal SettlementPrice { get; set; }

        /// <summary>
        /// Position margin
        /// </summary>
        public decimal PositionMargin { get; set; }

        /// <summary>
        /// Mark price
        /// </summary>
        public decimal MarkPrice { get; set; }

        /// <summary>
        /// Session UPL, for USDC only
        /// </summary>
        public decimal SessionUPL { get; set; }

        /// <summary>
        /// Session RPL, for USDC only
        /// </summary>
        public decimal SessionRPL { get; set; }

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
        /// Accumulated realized pnl (all-time total)
        /// </summary>
        [JsonProperty("cumRealisedPnl")]
        public decimal TotalRealizedPnl { get; set; }

        /// <summary>
        /// Is isolated
        /// </summary>
        public bool IsIsolated { get; set; }
    }
}
