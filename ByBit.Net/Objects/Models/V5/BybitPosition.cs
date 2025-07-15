using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Position info
    /// </summary>
    [SerializationModel]
    public record BybitPosition
    {
        /// <summary>
        /// Category
        /// </summary>
        [JsonPropertyName("category")]

        public Category Category { get; set; }
        /// <summary>
        /// Position mode
        /// </summary>
        [JsonPropertyName("positionIdx")]

        public PositionIdx PositionIdx { get; set; }
        /// <summary>
        /// Risk id
        /// </summary>
        [JsonPropertyName("riskId")]
        public int RiskId { get; set; }
        /// <summary>
        /// Risk limit value
        /// </summary>
        [JsonPropertyName("riskLimitValue")]
        public decimal? RiskLimitValue { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Position side
        /// </summary>

        [JsonPropertyName("side")]
        public PositionSide? Side { get; set; }
        /// <summary>
        /// Position size
        /// </summary>
        [JsonPropertyName("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Average entry price
        /// </summary>
        [JsonPropertyName("avgPrice")]
        public decimal? AveragePrice { get; set; }

        [JsonInclude, JsonPropertyName("entryPrice")]
        internal decimal? EntryPrice
        {
            get => AveragePrice;
            set => AveragePrice = value;
        }

        /// <summary>
        /// Position value
        /// </summary>
        [JsonPropertyName("positionValue")]
        public decimal? PositionValue { get; set; }
        /// <summary>
        /// Trade mode. Only valid for Classic and UTA (inverse)
        /// </summary>

        [JsonPropertyName("tradeMode")]
        public TradeMode TradeMode { get; set; }
        /// <summary>
        /// Position status
        /// </summary>

        [JsonPropertyName("positionStatus")]
        public PositionStatus? PositionStatus { get; set; }
        /// <summary>
        /// Leverage
        /// </summary>
        [JsonPropertyName("leverage")]
        public decimal? Leverage { get; set; }
        /// <summary>
        /// Mark price
        /// </summary>
        [JsonPropertyName("markPrice")]
        public decimal? MarkPrice { get; set; }
        /// <summary>
        /// Liquidation price
        /// </summary>
        [JsonPropertyName("liqPrice")]
        public decimal? LiquidationPrice { get; set; }
        /// <summary>
        /// Bankruptcy price
        /// </summary>
        [JsonPropertyName("bustPrice")]
        public decimal? BustPrice { get; set; }
        /// <summary>
        /// Initial margin
        /// </summary>
        [JsonPropertyName("positionIM")]
        public decimal? InitialMargin { get; set; }
        /// <summary>
        /// Initial margin by mark price
        /// </summary>
        [JsonPropertyName("positionIMByMp")]
        public decimal? InitialMarginByMarkPrice { get; set; }
        /// <summary>
        /// Maintenance margin
        /// </summary>
        [JsonPropertyName("positionMM")]
        public decimal? MaintenanceMargin { get; set; }
        /// <summary>
        /// Maintenance margin by mark price
        /// </summary>
        [JsonPropertyName("positionMMByMp")]
        public decimal? MaintenanceMarginByMarkPrice { get; set; }
        /// <summary>
        /// Take profit / stop loss price
        /// </summary>

        [JsonPropertyName("tpslMode")]
        public StopLossTakeProfitMode? TakeProfitStopLossMode { get; set; }
        /// <summary>
        /// Take profit price
        /// </summary>
        [JsonPropertyName("takeProfit")]
        public decimal? TakeProfit { get; set; }
        /// <summary>
        /// Stop loss price
        /// </summary>
        [JsonPropertyName("stopLoss")]
        public decimal? StopLoss { get; set; }
        /// <summary>
        /// Trailing stop
        /// </summary>
        [JsonPropertyName("trailingStop")]
        public decimal? TrailingStop { get; set; }
        /// <summary>
        /// Unrealized profit and lsos
        /// </summary>
        [JsonPropertyName("unrealisedPnl")]
        public decimal? UnrealizedPnl { get; set; }
        /// <summary>
        /// Realized profit and loss
        /// </summary>
        [JsonPropertyName("cumRealisedPnl")]
        public decimal? RealizedPnl { get; set; }
        /// <summary>
        /// The realised PnL for the current holding position
        /// </summary>
        [JsonPropertyName("curRealisedPnl")]
        public decimal? CurrentRealizedPnl { get; set; }
        /// <summary>
        /// Auto deleverage rank indicator
        /// </summary>
        [JsonPropertyName("adlRankIndicator")]
        public int AutoDeleverageRankIndicator { get; set; }
        /// <summary>
        /// Created timestamp
        /// </summary>
        [JsonPropertyName("createdTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// Updated timestamp
        /// </summary>
        [JsonPropertyName("updatedTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// Whether to add margin automatically
        /// </summary>
        [JsonPropertyName("autoAddMargin")]
        public bool AutoAddMargin { get; set; }
        /// <summary>
        /// Position margin
        /// </summary>
        [JsonPropertyName("positionBalance")]
        public decimal? PositionBalance { get; set; }
        /// <summary>
        /// Is reduce only position
        /// </summary>
        [JsonPropertyName("isReduceOnly")]
        public bool? IsReduceOnly { get; set; }
        /// <summary>
        /// When IsReduceOnly = true: the timestamp when the MMR will be forcibly adjusted by the system. When IsReduceOnly = false: the timestamp when the MMR had been adjusted by system
        /// </summary>
        [JsonPropertyName("mmrSysUpdatedTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? MaintenanceMarginUpdateTime { get; set; }
        /// <summary>
        /// When IsReduceOnly = true: the timestamp when the leverage will be forcibly adjusted by the system. When IsReduceOnly = false: the timestamp when the leverage had been adjusted by system
        /// </summary>
        [JsonPropertyName("leverageSysUpdatedTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? LeverageUpdateTime { get; set; }
        /// <summary>
        /// Cross sequence, used to associate each fill and each position update
        /// </summary>
        [JsonPropertyName("seq")]
        public long Sequence { get; set; }

        /// <summary>
        /// USDC contract session average price, it is the same figure as avg entry price shown in the web UI
        /// </summary>
        [JsonPropertyName("sessionAvgPrice")]
        public decimal? SessionAveragePrice { get; set; }
        /// <summary>
        /// Delta, unique field for option
        /// </summary>
        [JsonPropertyName("delta")]
        public decimal? Delta { get; set; }
        /// <summary>
        /// Gamma, unique field for option
        /// </summary>
        [JsonPropertyName("gamma")]
        public decimal? Gamma { get; set; }
        /// <summary>
        /// Vega, unique field for option
        /// </summary>
        [JsonPropertyName("vega")]
        public decimal? Vega { get; set; }
        /// <summary>
        /// Theta, unique field for option
        /// </summary>
        [JsonPropertyName("theta")]
        public decimal? Theta { get; set; }
    }
}
