using Bybit.Net.Enums;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Margin result
    /// </summary>
    public class BybitMarginResult
    {
        /// <summary>
        /// Position info
        /// </summary>
        [JsonProperty("PositionListResult")]
        public BybitMarginPositionInfo Position { get; set; } = null!;
        /// <summary>
        /// Wallet balance
        /// </summary>
        [JsonProperty("wallet_balance")]
        public decimal WalletBalance { get; set; }
        /// <summary>
        /// Available balance = wallet balance - used margin
        /// </summary>
        [JsonProperty("available_balance")]
        public decimal AvailableBalance { get; set; }
    }

    /// <summary>
    /// Position info
    /// </summary>
    public class BybitMarginPositionInfo
    {
        /// <summary>
        /// User id
        /// </summary>
        [JsonProperty("user_id")]
        public long UserId { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Side
        /// </summary>
        public PositionSide Side { get; set; }
        /// <summary>
        /// Position quantity
        /// </summary>
        [JsonProperty("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Current position value
        /// </summary>
        [JsonProperty("position_value")]
        public decimal PositionValue { get; set; }
        /// <summary>
        /// Average opening price
        /// </summary>
        [JsonProperty("entry_price")]
        public decimal EntryPrice { get; set; }
        /// <summary>
        /// Liquidation price
        /// </summary>
        [JsonProperty("liq_price")]
        public decimal LiquidationPrice { get; set; }
        /// <summary>
        /// Bust price
        /// </summary>
        [JsonProperty("bust_price")]
        public decimal BankruptcyPrice { get; set; }
        /// <summary>
        /// In Isolated Margin mode, the value is set by user. In Cross Margin mode, the value is the max leverage at current risk level
        /// </summary>
        public int Leverage { get; set; }
        /// <summary>
        /// Position margin
        /// </summary>
        [JsonProperty("position_margin")]
        public decimal PositionMargin { get; set; }
        /// <summary>
        /// Pre-occupancy closing fee
        /// </summary>
        [JsonProperty("occ_closing_fee")]
        public decimal ClosingFee { get; set; }
        /// <summary>
        /// Today's realized Profit and Loss
        /// </summary>
        [JsonProperty("realised_pnl")]
        public decimal RealizedPnl { get; set; }
        /// <summary>
        /// Cumulative realized Profit and Loss
        /// </summary>
        [JsonProperty("cum_realised_pnl")]
        public decimal TotalRealizedPnl { get; set; }
        /// <summary>
        /// Quantity which can be closed
        /// </summary>
        [JsonProperty("free_qty")]
        public decimal FreeQuantity { get; set; }
    }
}
