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
        /// ["<c>category</c>"] Category
        /// </summary>
        [JsonPropertyName("category")]

        public Category Category { get; set; }
        /// <summary>
        /// ["<c>positionIdx</c>"] Position mode
        /// </summary>
        [JsonPropertyName("positionIdx")]

        public PositionIdx PositionIdx { get; set; }
        /// <summary>
        /// ["<c>riskId</c>"] Risk id
        /// </summary>
        [JsonPropertyName("riskId")]
        public int RiskId { get; set; }
        /// <summary>
        /// ["<c>riskLimitValue</c>"] Risk limit value
        /// </summary>
        [JsonPropertyName("riskLimitValue")]
        public decimal? RiskLimitValue { get; set; }
        /// <summary>
        /// ["<c>symbol</c>"] Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>side</c>"] Position side
        /// </summary>

        [JsonPropertyName("side")]
        public PositionSide? Side { get; set; }
        /// <summary>
        /// ["<c>size</c>"] Position size
        /// </summary>
        [JsonPropertyName("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// ["<c>avgPrice</c>"] Average entry price
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
        /// ["<c>positionValue</c>"] Position value
        /// </summary>
        [JsonPropertyName("positionValue")]
        public decimal? PositionValue { get; set; }
        /// <summary>
        /// ["<c>tradeMode</c>"] Trade mode. Only valid for Classic and UTA (inverse)
        /// </summary>

        [JsonPropertyName("tradeMode")]
        public TradeMode TradeMode { get; set; }
        /// <summary>
        /// ["<c>positionStatus</c>"] Position status
        /// </summary>

        [JsonPropertyName("positionStatus")]
        public PositionStatus? PositionStatus { get; set; }
        /// <summary>
        /// ["<c>leverage</c>"] Leverage
        /// </summary>
        [JsonPropertyName("leverage")]
        public decimal? Leverage { get; set; }
        /// <summary>
        /// ["<c>markPrice</c>"] Mark price
        /// </summary>
        [JsonPropertyName("markPrice")]
        public decimal? MarkPrice { get; set; }
        /// <summary>
        /// ["<c>liqPrice</c>"] Liquidation price
        /// </summary>
        [JsonPropertyName("liqPrice")]
        public decimal? LiquidationPrice { get; set; }
        /// <summary>
        /// ["<c>bustPrice</c>"] Bankruptcy price
        /// </summary>
        [JsonPropertyName("bustPrice")]
        public decimal? BustPrice { get; set; }
        /// <summary>
        /// ["<c>positionIM</c>"] Initial margin
        /// </summary>
        [JsonPropertyName("positionIM")]
        public decimal? InitialMargin { get; set; }
        /// <summary>
        /// ["<c>positionIMByMp</c>"] Initial margin by mark price
        /// </summary>
        [JsonPropertyName("positionIMByMp")]
        public decimal? InitialMarginByMarkPrice { get; set; }
        /// <summary>
        /// ["<c>positionMM</c>"] Maintenance margin
        /// </summary>
        [JsonPropertyName("positionMM")]
        public decimal? MaintenanceMargin { get; set; }
        /// <summary>
        /// ["<c>positionMMByMp</c>"] Maintenance margin by mark price
        /// </summary>
        [JsonPropertyName("positionMMByMp")]
        public decimal? MaintenanceMarginByMarkPrice { get; set; }
        /// <summary>
        /// ["<c>tpslMode</c>"] Take profit / stop loss price
        /// </summary>

        [JsonPropertyName("tpslMode")]
        public StopLossTakeProfitMode? TakeProfitStopLossMode { get; set; }
        /// <summary>
        /// ["<c>takeProfit</c>"] Take profit price
        /// </summary>
        [JsonPropertyName("takeProfit")]
        public decimal? TakeProfit { get; set; }
        /// <summary>
        /// ["<c>stopLoss</c>"] Stop loss price
        /// </summary>
        [JsonPropertyName("stopLoss")]
        public decimal? StopLoss { get; set; }
        /// <summary>
        /// ["<c>trailingStop</c>"] Trailing stop
        /// </summary>
        [JsonPropertyName("trailingStop")]
        public decimal? TrailingStop { get; set; }
        /// <summary>
        /// ["<c>unrealisedPnl</c>"] Unrealized profit and lsos
        /// </summary>
        [JsonPropertyName("unrealisedPnl")]
        public decimal? UnrealizedPnl { get; set; }
        /// <summary>
        /// ["<c>cumRealisedPnl</c>"] Realized profit and loss
        /// </summary>
        [JsonPropertyName("cumRealisedPnl")]
        public decimal? RealizedPnl { get; set; }
        /// <summary>
        /// ["<c>curRealisedPnl</c>"] The realised PnL for the current holding position
        /// </summary>
        [JsonPropertyName("curRealisedPnl")]
        public decimal? CurrentRealizedPnl { get; set; }
        /// <summary>
        /// ["<c>adlRankIndicator</c>"] Auto deleverage rank indicator
        /// </summary>
        [JsonPropertyName("adlRankIndicator")]
        public int AutoDeleverageRankIndicator { get; set; }
        /// <summary>
        /// ["<c>createdTime</c>"] Created timestamp
        /// </summary>
        [JsonPropertyName("createdTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// ["<c>updatedTime</c>"] Updated timestamp
        /// </summary>
        [JsonPropertyName("updatedTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// ["<c>autoAddMargin</c>"] Whether to add margin automatically
        /// </summary>
        [JsonPropertyName("autoAddMargin")]
        public bool AutoAddMargin { get; set; }
        /// <summary>
        /// ["<c>positionBalance</c>"] Position margin
        /// </summary>
        [JsonPropertyName("positionBalance")]
        public decimal? PositionBalance { get; set; }
        /// <summary>
        /// ["<c>isReduceOnly</c>"] Is reduce only position
        /// </summary>
        [JsonPropertyName("isReduceOnly")]
        public bool? IsReduceOnly { get; set; }
        /// <summary>
        /// ["<c>mmrSysUpdatedTime</c>"] When IsReduceOnly = true: the timestamp when the MMR will be forcibly adjusted by the system. When IsReduceOnly = false: the timestamp when the MMR had been adjusted by system
        /// </summary>
        [JsonPropertyName("mmrSysUpdatedTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? MaintenanceMarginUpdateTime { get; set; }
        /// <summary>
        /// ["<c>leverageSysUpdatedTime</c>"] When IsReduceOnly = true: the timestamp when the leverage will be forcibly adjusted by the system. When IsReduceOnly = false: the timestamp when the leverage had been adjusted by system
        /// </summary>
        [JsonPropertyName("leverageSysUpdatedTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? LeverageUpdateTime { get; set; }
        /// <summary>
        /// ["<c>seq</c>"] Cross sequence, used to associate each fill and each position update
        /// </summary>
        [JsonPropertyName("seq")]
        public long Sequence { get; set; }

        /// <summary>
        /// ["<c>sessionAvgPrice</c>"] USDC contract session average price, it is the same figure as avg entry price shown in the web UI
        /// </summary>
        [JsonPropertyName("sessionAvgPrice")]
        public decimal? SessionAveragePrice { get; set; }
        /// <summary>
        /// ["<c>delta</c>"] Delta, unique field for option
        /// </summary>
        [JsonPropertyName("delta")]
        public decimal? Delta { get; set; }
        /// <summary>
        /// ["<c>gamma</c>"] Gamma, unique field for option
        /// </summary>
        [JsonPropertyName("gamma")]
        public decimal? Gamma { get; set; }
        /// <summary>
        /// ["<c>vega</c>"] Vega, unique field for option
        /// </summary>
        [JsonPropertyName("vega")]
        public decimal? Vega { get; set; }
        /// <summary>
        /// ["<c>theta</c>"] Theta, unique field for option
        /// </summary>
        [JsonPropertyName("theta")]
        public decimal? Theta { get; set; }
        /// <summary>
        /// ["<c>breakEvenPrice</c>"] Break even price, only for linear/inverse
        /// </summary>
        [JsonPropertyName("breakEvenPrice")]
        public decimal? BreakEvenPrice { get; set; }
        /// <summary>
        /// ["<c>netDeltaRatio</c>"] Net delta ratio
        /// </summary>
        [JsonPropertyName("netDeltaRatio")]
        public decimal? NetDeltaRatio { get; set; }
    }
}
