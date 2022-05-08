using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Position info
    /// </summary>
    public class BybitPositionBase
    {
        /// <summary>
        /// User id
        /// </summary>
        [JsonProperty("user_id")]
        public long UserId { get; set; }
        /// <summary>
        /// Risk id
        /// </summary>
        [JsonProperty("risk_id")]
        public long RiskId { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Side
        /// </summary>
        [JsonConverter(typeof(PositionSideConverter))]
        public PositionSide Side { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonProperty("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Value
        /// </summary>
        [JsonProperty("position_value")]
        public decimal PositionValue { get; set; }
        /// <summary>
        /// Average entry price
        /// </summary>
        [JsonProperty("entry_price")]
        public decimal EntryPrice { get; set; }
        /// <summary>
        /// In Isolated Margin mode, the value is set by user. In Cross Margin mode, the value is the max leverage at current risk level
        /// </summary>
        public decimal Leverage { get; set; }
        /// <summary>
        /// Position margin
        /// </summary>
        [JsonProperty("position_margin")]
        public decimal PositionMargin { get; set; }
        /// <summary>
        /// Liquidation price
        /// </summary>
        [JsonProperty("liq_price")]
        public decimal LiquidationPrice { get; set; }
        /// <summary>
        /// Bankruptcy price
        /// </summary>
        [JsonProperty("bust_price")]
        public decimal BankruptcyPrice { get; set; }
        
        /// <summary>
        /// Pre-occupied funding fee: calculated from position qty and current funding fee
        /// </summary>
        [JsonProperty("occ_funding_fee")]
        public decimal FundingFee { get; set; }
        /// <summary>
        /// Take profit price
        /// </summary>
        [JsonProperty("take_profit")]
        public decimal TakeProfit { get; set; }
        /// <summary>
        /// Stop loss price
        /// </summary>
        [JsonProperty("stop_loss")]
        public decimal StopLoss { get; set; }
        /// <summary>
        /// Trailing stop
        /// </summary>
        [JsonProperty("trailing_stop")]
        public decimal TrailingStop { get; set; }
        /// <summary>
        /// Whether to add margin automatically
        /// </summary>
        [JsonProperty("auto_add_margin")]
        [JsonConverter(typeof(BoolConverter))]
        public bool AutoAddMargin { get; set; }    
        /// <summary>
        /// Today's realized pnl
        /// </summary>
        [JsonProperty("realised_pnl")]
        public decimal RealizedPnl { get; set; }
        /// <summary>
        /// Accumulated realized pnl (all-time total)
        /// </summary>
        [JsonProperty("cum_realised_pnl")]
        public decimal TotalRealizedPnl { get; set; }
        /// <summary>
        /// Position mode
        /// </summary>
        [JsonProperty("position_idx"), JsonConverter(typeof(PositionModeConverter))]
        public PositionMode PositionMode { get; set; }
    }
}
