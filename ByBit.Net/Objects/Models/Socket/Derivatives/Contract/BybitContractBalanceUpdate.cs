using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.Socket.Derivatives.Contract
{
    /// <summary>
    /// Balance update info
    /// </summary>
    public class BybitContractBalanceUpdate
    {
        /// <summary>
        /// Asset name
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Equity, wallet balance + unrealized pnl
        /// </summary>
        public decimal Equity { get; set; }
        /// <summary>
        /// Wallet balance
        /// </summary>
        public decimal WalletBalance { get; set; }
        /// <summary>
        /// Position margin
        /// </summary>
        public decimal PositionMargin { get; set; }
        /// <summary>
        /// Available balance
        /// </summary>
        public decimal AvailableBalance { get; set; }
        /// <summary>
        /// Used margin by order
        /// </summary>
        public decimal OrderMargin { get; set; }
        /// <summary>
        /// Unrealized profit and loss
        /// </summary>
        public decimal UnrealisedPnl { get; set; }
        /// <summary>
        /// Total realized profit and loss
        /// </summary>
        [JsonProperty("cumRealisedPnl")]
        public decimal TotalRealizedPnl { get; set; }
    }
}
