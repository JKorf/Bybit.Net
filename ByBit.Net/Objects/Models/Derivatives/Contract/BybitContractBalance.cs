using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.Derivatives.Contract
{
    /// <summary>
    /// Balance info
    /// </summary>
    public class BybitContractBalance
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
        /// Unrealized pnl
        /// </summary>
        public decimal UnrealisedPnl { get; set; }
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
        /// Position closing fee
        /// </summary>
        [JsonProperty("occClosingFee")]
        public decimal PositionClosingFee { get; set; }
        /// <summary>
        /// Funding fee
        /// </summary>
        [JsonProperty("occFundingFee")]
        public decimal FundingFee { get; set; }
        /// <summary>
        /// Unrealized profit and loss
        /// </summary>
        public decimal UnrealizedPnl { get; set; }
        /// <summary>
        /// Total realized profit and loss
        /// </summary>
        [JsonProperty("cumRealisedPnl")]
        public decimal TotalRealizedPnl { get; set; }
        /// <summary>
        /// Given cash
        /// </summary>
        public decimal GivenCash { get; set; }
        /// <summary>
        /// Service cash
        /// </summary>
        public decimal ServiceCash { get; set; }
    }
}
