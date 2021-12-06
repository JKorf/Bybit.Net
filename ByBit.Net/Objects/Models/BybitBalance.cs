using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Balance info
    /// </summary>
    public class BybitBalance
    {
        /// <summary>
        /// Equity, wallet balance + unrealized pnl
        /// </summary>
        public decimal Equity { get; set; }
        /// <summary>
        /// Available balance
        /// </summary>
        [JsonProperty("available_balance")]
        public decimal AvailableBalance { get; set; }
        /// <summary>
        /// Used margin, wallet balance - available balance
        /// </summary>
        [JsonProperty("used_margin")]
        public decimal UsedMargin { get; set; }
        /// <summary>
        /// Used margin by order
        /// </summary>
        [JsonProperty("order_margin")]
        public decimal OrderMargin { get; set; }
        /// <summary>
        /// Position margin
        /// </summary>
        [JsonProperty("position_margin")]
        public decimal PositionMargin { get; set; }
        /// <summary>
        /// Position closing fee
        /// </summary>
        [JsonProperty("occ_closing_fee")]
        public decimal PositionClosingFee { get; set; }
        /// <summary>
        /// Funding fee
        /// </summary>
        [JsonProperty("occ_funding_fee")]
        public decimal FundingFee { get; set; }
        /// <summary>
        /// Wallet balance
        /// </summary>
        [JsonProperty("wallet_balance")]
        public decimal WalletBalance { get; set; }
        /// <summary>
        /// Daily realized profit and loss
        /// </summary>
        [JsonProperty("realised_pnl")]
        public decimal RealizedPnl { get; set; }
        /// <summary>
        /// Unrealized profit and loss
        /// </summary>
        [JsonProperty("unrealised_pnl")]
        public decimal UnrealizedPnl { get; set; }
        /// <summary>
        /// Total realized profit and loss
        /// </summary>
        [JsonProperty("cum_realised_pnl")]
        public decimal TotalRealizedPnl { get; set; }
        /// <summary>
        /// Given cash
        /// </summary>
        [JsonProperty("given_cash")]
        public decimal GivenCash { get; set; }
        /// <summary>
        /// Service cash
        /// </summary>
        [JsonProperty("service_cash")]
        public decimal ServiceCash { get; set; }
    }
}
