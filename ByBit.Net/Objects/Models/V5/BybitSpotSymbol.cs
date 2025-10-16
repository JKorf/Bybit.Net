using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Spot symbol
    /// </summary>
    [SerializationModel]
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
        [JsonPropertyName("status")]
        public SymbolStatus Status { get; set; }
        /// <summary>
        /// Margin trade status
        /// </summary>
        [JsonPropertyName("marginTrading")]
        public MarginTrading MarginTrading { get; set; }
        /// <summary>
        /// Symbol type
        /// </summary>
        [JsonPropertyName("symbolType")]
        public SymbolType? SymbolType { get; set; }
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
    [SerializationModel]
    public record BybitPriceLimit
    {
        /// <summary>
        /// Ratio X
        /// </summary>
        [JsonPropertyName("priceLimitRatioX")]
        public decimal PriceLimitRatioX { get; set; }
        /// <summary>
        /// Ratio Y
        /// </summary>
        [JsonPropertyName("priceLimitRatioY")]
        public decimal PriceLimitRatioY { get; set; }
    }

    /// <summary>
    /// Lot size filter info
    /// </summary>
    [SerializationModel]
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
        /// <summary>
        ///	Maximum Market order quantity
        /// </summary>
        [JsonPropertyName("maxMarketOrderQty")]
        public decimal MaxMarketOrderQuantity { get; set; }
        /// <summary>
        /// Maximum Limit order quantity
        /// </summary>
        [JsonPropertyName("maxLimitOrderQty")]
        public decimal MaxLimitOrderQuantity { get; set; }
    }

    /// <summary>
    /// Price filter info
    /// </summary>
    [SerializationModel]
    public record BybitSpotPriceFilter
    {
        /// <summary>
        /// Tick size
        /// </summary>
        [JsonPropertyName("tickSize")]
        public decimal TickSize { get; set; }
    }
}
