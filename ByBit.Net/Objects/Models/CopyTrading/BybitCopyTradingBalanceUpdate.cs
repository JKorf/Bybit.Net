using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.CopyTrading
{
    /// <summary>
    /// Balance update
    /// </summary>
    public class BybitCopyTradingBalanceUpdate
    {
        /// <summary>
        /// Asset
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Equity, wallet balance + unrealized pnl
        /// </summary>
        public decimal Equity { get; set; }
        /// <summary>
        /// Available balance
        /// </summary>
        [JsonProperty("availableBalance")]
        public decimal AvailableBalance { get; set; }
        /// <summary>
        /// Used margin, wallet balance - available balance
        /// </summary>
        [JsonProperty("usedMargin")]
        public decimal UsedMargin { get; set; }
        /// <summary>
        /// Used margin by order
        /// </summary>
        [JsonProperty("orderMargin")]
        public decimal OrderMargin { get; set; }
        /// <summary>
        /// Position margin
        /// </summary>
        [JsonProperty("positionMargin")]
        public decimal PositionMargin { get; set; }
        /// <summary>
        /// Wallet balance
        /// </summary>
        [JsonProperty("walletBalance")]
        public decimal WalletBalance { get; set; }
        /// <summary>
        /// Daily realized profit and loss
        /// </summary>
        [JsonProperty("realisedPnl")]
        public decimal RealizedPnl { get; set; }
        /// <summary>
        /// Unrealized profit and loss
        /// </summary>
        [JsonProperty("unrealisedPnl")]
        public decimal UnrealizedPnl { get; set; }
        /// <summary>
        /// Total realized profit and loss
        /// </summary>
        [JsonProperty("cumRealisedPnl")]
        public decimal TotalRealizedPnl { get; set; }
    }
}
