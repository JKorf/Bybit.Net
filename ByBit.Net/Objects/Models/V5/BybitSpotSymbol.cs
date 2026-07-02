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
        /// ["<c>symbolId</c>"] Symbol id
        /// </summary>
        [JsonPropertyName("symbolId")]
        public long SymbolId { get; set; }
        /// <summary>
        /// ["<c>symbol</c>"] Symbol name
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>baseCoin</c>"] Base asset
        /// </summary>
        [JsonPropertyName("baseCoin")]
        public string BaseAsset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>quoteCoin</c>"] Quote asset
        /// </summary>
        [JsonPropertyName("quoteCoin")]
        public string QuoteAsset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>status</c>"] Symbol status
        /// </summary>
        [JsonPropertyName("status")]
        public SymbolStatus Status { get; set; }
        /// <summary>
        /// ["<c>marginTrading</c>"] Margin trade status
        /// </summary>
        [JsonPropertyName("marginTrading")]
        public MarginTrading MarginTrading { get; set; }
        /// <summary>
        /// ["<c>symbolType</c>"] Symbol type
        /// </summary>
        [JsonPropertyName("symbolType")]
        public SymbolType? SymbolType { get; set; }
        /// <summary>
        /// Xstock multiplier
        /// </summary>
        [JsonPropertyName("xstockMultiplier")]
        public decimal? XstockMultiplier { get; set; }
        /// <summary>
        /// ["<c>lotSizeFilter</c>"] Lot size order filter
        /// </summary>
        [JsonPropertyName("lotSizeFilter")]
        public BybitSpotLotSizeFilter? LotSizeFilter { get; set; }
        /// <summary>
        /// ["<c>priceFilter</c>"] Price order filter
        /// </summary>
        [JsonPropertyName("priceFilter")]
        public BybitSpotPriceFilter? PriceFilter { get; set; }
        /// <summary>
        /// ["<c>riskParameters</c>"] Price percentage filter
        /// </summary>
        [JsonPropertyName("riskParameters")]
        public BybitPriceLimit? PricePercentageFilter { get; set; }
        /// <summary>
        /// ["<c>stTag</c>"] Whether the symbol has the special treatment label
        /// </summary>
        [JsonPropertyName("stTag")]
        public bool SpecialTreatmentLabel { get; set; }
        /// <summary>
        /// ["<c>innovation</c>"] Whether the symbol has the innovation label
        /// </summary>
        [JsonPropertyName("innovation")]
        public bool Innovation { get; set; }
    }

    /// <summary>
    /// Price limits
    /// </summary>
    [SerializationModel]
    public record BybitPriceLimit
    {
        /// <summary>
        /// ["<c>priceLimitRatioX</c>"] Ratio X
        /// </summary>
        [JsonPropertyName("priceLimitRatioX")]
        public decimal PriceLimitRatioX { get; set; }
        /// <summary>
        /// ["<c>priceLimitRatioY</c>"] Ratio Y
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
        /// ["<c>basePrecision</c>"] Base precision
        /// </summary>
        [JsonPropertyName("basePrecision")]
        public decimal BasePrecision { get; set; }
        /// <summary>
        /// ["<c>quotePrecision</c>"] Quote precision
        /// </summary>
        [JsonPropertyName("quotePrecision")]
        public decimal QuotePrecision { get; set; }
        /// <summary>
        /// ["<c>minOrderQty</c>"] Min order quantity
        /// </summary>
        [JsonPropertyName("minOrderQty")]
        public decimal MinOrderQuantity { get; set; }
        /// <summary>
        /// ["<c>maxOrderQty</c>"] Max order quantity
        /// </summary>
        [JsonPropertyName("maxOrderQty")]
        public decimal MaxOrderQuantity { get; set; }
        /// <summary>
        /// ["<c>minOrderAmt</c>"] Min order amount
        /// </summary>
        [JsonPropertyName("minOrderAmt")]
        public decimal MinOrderValue { get; set; }
        /// <summary>
        /// ["<c>maxOrderAmt</c>"] Max order amount
        /// </summary>
        [JsonPropertyName("maxOrderAmt")]
        public decimal MaxOrderValue { get; set; }
        /// <summary>
        /// ["<c>maxMarketOrderQty</c>"] Maximum Market order quantity
        /// </summary>
        [JsonPropertyName("maxMarketOrderQty")]
        public decimal MaxMarketOrderQuantity { get; set; }
        /// <summary>
        /// ["<c>maxLimitOrderQty</c>"] Maximum Limit order quantity
        /// </summary>
        [JsonPropertyName("maxLimitOrderQty")]
        public decimal MaxLimitOrderQuantity { get; set; }
        /// <summary>
        /// ["<c>postOnlyMaxLimitOrderSize</c>"] Maximum order quantity for post-only limit orders
        /// </summary>
        [JsonPropertyName("postOnlyMaxLimitOrderSize")]
        public decimal PostOnlyMaxLimitOrderQuantity { get; set; }
    }

    /// <summary>
    /// Price filter info
    /// </summary>
    [SerializationModel]
    public record BybitSpotPriceFilter
    {
        /// <summary>
        /// ["<c>tickSize</c>"] Tick size
        /// </summary>
        [JsonPropertyName("tickSize")]
        public decimal TickSize { get; set; }
    }
}
