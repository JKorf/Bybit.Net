using Bybit.Net.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Spot symbol
    /// </summary>
    public record BybitSpotSymbol
    {
        /// <summary>
        /// Symbol name
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Base asset
        /// </summary>
        [JsonPropertyName("baseCoin")]
        public string BaseAsset { get; set; } = string.Empty;
        /// <summary>
        /// Quote asset
        /// </summary>
        [JsonPropertyName("quoteCoin")]
        public string QuoteAsset { get; set; } = string.Empty;
        /// <summary>
        /// Symbol status
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        [JsonPropertyName("status")]
        public SymbolStatus Status { get; set; }
        /// <summary>
        /// Marging trade status
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        [JsonPropertyName("marginTrading")]
        public MarginTrading MarginTrading { get; set; }
        /// <summary>
        /// Is innovation
        /// </summary>
        [JsonConverter(typeof(BoolConverter))]
        [JsonPropertyName("innovation")]
        public bool Innovation { get; set; }
        /// <summary>
        /// Lot size order filter
        /// </summary>
        [JsonPropertyName("lotSizeFilter")]
        public BybitSpotLotSizeFilter? LotSizeFilter { get; set; }
        /// <summary>
        /// Price order filter
        /// </summary>
        [JsonPropertyName("priceFilter")]
        public BybitSpotPriceFilter? PriceFilter { get; set; }
        /// <summary>
        /// Price percentage filter
        /// </summary>
        [JsonPropertyName("riskParameters")]
        public BybitPriceLimit? PricePercentageFilter { get; set; }
        /// <summary>
        /// Whether the symbol has the special treatment label
        /// </summary>
        [JsonPropertyName("stTag")]
        public bool SpecialTreatmentLabel { get; set; }
    }

    /// <summary>
    /// Price limits
    /// </summary>
    public record BybitPriceLimit
    {
        /// <summary>
        /// Price limit on Limit order. For example, "0.05" means 5%, so the order price of your buy order cannot exceed 105% of the Last Traded Price, while the order price of your sell order cannot be lower than 95% of the Last Traded Price
        /// </summary>
        [JsonPropertyName("limitParameter")]
        public decimal LimitPricePercentageLimit { get; set; }
        /// <summary>
        /// Price limit on Market order. For example, assuming the market order limit for MNT/USDT is 5%. When the last traded price is at 2 USDT, a trader places a market order for 100,000 USDT. Any portion that could have been filled at above 2.1 USDT will be canceled. Assuming only 80,000 USDT order value can be filled at a price of 2.1 USDT or below, the remaining 20,000 USDT order value will be canceled since the deviation exceeds the 5% threshold.
        /// </summary>
        [JsonPropertyName("marketParameter")]
        public decimal MarketPricePercentageLimit { get; set; }
    }

    /// <summary>
    /// Lot size filter info
    /// </summary>
    public record BybitSpotLotSizeFilter
    {
        /// <summary>
        /// Base precision
        /// </summary>
        [JsonPropertyName("basePrecision")]
        public decimal BasePrecision { get; set; }
        /// <summary>
        /// Quote precision
        /// </summary>
        [JsonPropertyName("quotePrecision")]
        public decimal QuotePrecision { get; set; }
        /// <summary>
        /// Min order quantity
        /// </summary>
        [JsonPropertyName("minOrderQty")]
        public decimal MinOrderQuantity { get; set; }
        /// <summary>
        /// Max order quantity
        /// </summary>
        [JsonPropertyName("maxOrderQty")]
        public decimal MaxOrderQuantity { get; set; }
        /// <summary>
        /// Min order amount
        /// </summary>
        [JsonPropertyName("minOrderAmt")]
        public decimal MinOrderValue { get; set; }
        /// <summary>
        /// Max order amount
        /// </summary>
        [JsonPropertyName("maxOrderAmt")]
        public decimal MaxOrderValue { get; set; }
    }

    /// <summary>
    /// Price filter info
    /// </summary>
    public record BybitSpotPriceFilter
    {
        /// <summary>
        /// Tick size
        /// </summary>
        [JsonPropertyName("tickSize")]
        public decimal TickSize { get; set; }
    }
}
