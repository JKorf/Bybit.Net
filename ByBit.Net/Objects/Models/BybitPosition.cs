using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Position info
    /// </summary>
    public class BybitPosition
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// User id
        /// </summary>
        [JsonProperty("user_id")]
        public long UserId { get; set; }
        /// <summary>
        /// Position mode
        /// </summary>
        [JsonProperty("position_idx"), JsonConverter(typeof(PositionModeConverter))]
        public PositionMode Mode { get; set; }
        /// <summary>
        /// Risk id
        /// </summary>
        [JsonProperty("risk_id")]
        public long RiskId { get; set; }
        /// <summary>
        /// Whether the current data is valid. Only use data when IsValid is true
        /// </summary>
        public bool IsValid { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Side
        /// </summary>
        [JsonConverter(typeof(OrderSideConverter))]
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
        /// Isolated margin mode
        /// </summary>
        [JsonProperty("is_isolated")]
        public bool IsIsolated { get; set; }
        /// <summary>
        /// Whether to add margin automatically
        /// </summary>
        [JsonProperty("auto_add_margin")]
        public bool AutoAddMargin { get; set; }
        /// <summary>
        /// In Isolated Margin mode, the value is set by user. In Cross Margin mode, the value is the max leverage at current risk level
        /// </summary>
        public decimal Leverage { get; set; }
        /// <summary>
        /// Effective leverage
        /// </summary>
        [JsonProperty("effective_leverage")]
        public decimal EffectiveLeverage { get; set; }
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
        /// Position closing fee occupied (your opening fee + expected maximum closing fee)
        /// </summary>
        [JsonProperty("occ_closing_fee")]
        public decimal ClosingFee { get; set; }
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
        /// Position status
        /// </summary>
        [JsonProperty("position_status"), JsonConverter(typeof(PositionStatusConverter))]
        public PositionStatus PositionStatus { get; set; }
        /// <summary>
        /// Deleverage indicator level (1,2,3,4,5)
        /// </summary>
        [JsonProperty("deleverage_indicator")]
        public int DeleverageIndicator { get; set; }
        /// <summary>
        /// Pre-occupied order margin
        /// </summary>
        [JsonProperty("order_margin")]
        public decimal OrderMargin { get; set; }
        /// <summary>
        /// Wallet balance
        /// </summary>
        [JsonProperty("wallet_balance")]
        public decimal WalletBalance { get; set; }
        /// <summary>
        /// Today's realized pnl
        /// </summary>
        [JsonProperty("realised_pnl")]
        public decimal RealizedPnl { get; set; }
        /// <summary>
        /// Unrealised pnl
        /// </summary>
        [JsonProperty("unrealised_pnl")]
        public decimal UnrealizedPnl { get; set; }
        /// <summary>
        /// Accumulated realised pnl (all-time total)
        /// </summary>
        [JsonProperty("cum_realised_pnl")]
        public decimal TotalRealizedPnl { get; set; }
        /// <summary>
        /// Cross sequence
        /// </summary>
        [JsonProperty("cross_seq")]
        public long CrossSequence { get; set; }
        /// <summary>
        /// Position sequence
        /// </summary>
        [JsonProperty("position_seq")]
        public long PositionSequence { get; set; }
        /// <summary>
        /// The account creation time
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// Stop loss and take profit mode
        /// </summary>
        [JsonProperty("tp_sl_mode"), JsonConverter(typeof(StopLossTakeProfitModeConverter))]
        public StopLossTakeProfitMode StopMode { get; set; }
    }
}
