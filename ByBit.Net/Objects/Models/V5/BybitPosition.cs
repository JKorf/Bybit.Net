using Bybit.Net.Enums;
using Bybit.Net.Enums.V5;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Position info
    /// </summary>
    public class BybitPosition
    {
        /// <summary>
        /// Position mode
        /// </summary>
        [JsonProperty("positionIdx")]
        [JsonConverter(typeof(EnumConverter))]
        public PositionIdx PositionIdx { get; set; }
        /// <summary>
        /// Risk id
        /// </summary>
        public int RiskId { get; set; }
        /// <summary>
        /// Risk limit value
        /// </summary>
        public decimal RiskLimitValue { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Position side
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public PositionSide? Side { get; set; }
        /// <summary>
        /// Position size
        /// </summary>
        [JsonProperty("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Average entry price
        /// </summary>
        [JsonProperty("avgPrice")]
        public decimal? AveragePrice { get; set; }

        [JsonProperty("entryPrice")]
        private decimal? EntryPrice
        {
            get => AveragePrice;
            set => AveragePrice = value;
        }

        /// <summary>
        /// Position value
        /// </summary>
        [JsonProperty("positionValue")]
        public decimal? PositionValue { get; set; }
        /// <summary>
        /// Trade mode
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public TradeMode TradeMode { get; set; }
        /// <summary>
        /// Position status
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public PositionStatus? PositionStatus { get; set; }
        /// <summary>
        /// Leverage
        /// </summary>
        public decimal? Leverage { get; set; }
        /// <summary>
        /// Mark price
        /// </summary>
        public decimal? MarkPrice { get; set; }
        /// <summary>
        /// Liquidation price
        /// </summary>
        [JsonProperty("liqPrice")]
        public decimal? LiquidationPrice { get; set; }
        /// <summary>
        /// Bankruptcy price
        /// </summary>
        public decimal? BustPrice { get; set; }
        /// <summary>
        /// Initial margin
        /// </summary>
        [JsonProperty("positionIM")]
        public decimal? InitialMargin { get; set; }
        /// <summary>
        /// Maintenance margin
        /// </summary>
        [JsonProperty("positionMM")]
        public decimal? MaintenanceMargin { get; set; }
        /// <summary>
        /// Take profit / stop loss price
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        [JsonProperty("tpslMode")]
        public StopLossTakeProfitMode? TakeProfitStopLossMode { get; set; }
        /// <summary>
        /// Take profit price
        /// </summary>
        public decimal? TakeProfit { get; set; }
        /// <summary>
        /// Stop loss price
        /// </summary>
        public decimal? StopLoss { get; set; }
        /// <summary>
        /// Trailing stop
        /// </summary>
        public decimal? TrailingStop { get; set; }
        /// <summary>
        /// Unrealized profit and lsos
        /// </summary>
        [JsonProperty("unrealisedPnl")]
        public decimal? UnrealizedPnl { get; set; }
        /// <summary>
        /// Realized profit and loss
        /// </summary>
        [JsonProperty("cumRealisedPnl")]
        public decimal? RealizedPnl { get; set; }
        /// <summary>
        /// Auto deleverage rank indicator
        /// </summary>
        [JsonProperty("adlRankIndicator")]
        public int AutoDeleverageRankIndicator { get; set; }
        /// <summary>
        /// Created timestamp
        /// </summary>
        [JsonProperty("createdTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// Updated timestamp
        /// </summary>
        [JsonProperty("updatedTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// Whether to add margin automatically
        /// </summary>
        [JsonProperty("autoAddMargin")]
        public bool AutoAddMargin { get; set; }
        /// <summary>
        /// Position margin
        /// </summary>
        [JsonProperty("positionBalance")]
        public decimal? PositionBalance { get; set; }
        /// <summary>
        /// Is reduce only position
        /// </summary>
        [JsonProperty("isReduceOnly")]
        public bool? IsReduceOnly { get; set; }
        /// <summary>
        /// When IsReduceOnly = true: the timestamp when the MMR will be forcibly adjusted by the system. When IsReduceOnly = false: the timestamp when the MMR had been adjusted by system
        /// </summary>
        [JsonProperty("mmrSysUpdatedTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? MaintenanceMarginUpdateTime { get; set; }
        /// <summary>
        /// When IsReduceOnly = true: the timestamp when the leverage will be forcibly adjusted by the system. When IsReduceOnly = false: the timestamp when the leverage had been adjusted by system
        /// </summary>
        [JsonProperty("leverageSysUpdatedTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? LeverageUpdateTime { get; set; }
        /// <summary>
        /// Cross sequence, used to associate each fill and each position update
        /// </summary>
        [JsonProperty("seq")]
        public long Sequence { get; set; }
    }
}
