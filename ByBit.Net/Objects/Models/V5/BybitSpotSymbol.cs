using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Spot symbol
    /// </summary>
    public class BybitSpotSymbol
    {
        /// <summary>
        /// Symbol name
        /// </summary>
        [JsonProperty("symbol")]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Base asset
        /// </summary>
        [JsonProperty("baseCoin")]
        public string BaseAsset { get; set; } = string.Empty;
        /// <summary>
        /// Quote asset
        /// </summary>
        [JsonProperty("quoteCoin")]
        public string QuoteAsset { get; set; } = string.Empty;
        /// <summary>
        /// Symbol status
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public SymbolStatus Status { get; set; }
        /// <summary>
        /// Is innovation
        /// </summary>
        [JsonConverter(typeof(BoolConverter))]
        public bool Innovation { get; set; }
        /// <summary>
        /// Lot size order filter
        /// </summary>
        public BybitSpotLotSizeFilter? LotSizeFilter { get; set; }
        /// <summary>
        /// Price order filter
        /// </summary>
        public BybitSpotPriceFilter? PriceFilter { get; set; }
    }

    /// <summary>
    /// Lot size filter info
    /// </summary>
    public class BybitSpotLotSizeFilter
    {
        /// <summary>
        /// Base precision
        /// </summary>
        public decimal BasePrecision { get; set; }
        /// <summary>
        /// Quote precision
        /// </summary>
        public decimal QuotePrecision { get; set; }
        /// <summary>
        /// Min order quantity
        /// </summary>
        [JsonProperty("minOrderQty")]
        public decimal MinOrderQuantity { get; set; }
        /// <summary>
        /// Max order quantity
        /// </summary>
        [JsonProperty("maxOrderQty")]
        public decimal MaxOrderQuantity { get; set; }
        /// <summary>
        /// Min order amount
        /// </summary>
        [JsonProperty("minOrderAmt")]
        public decimal MinOrderValue { get; set; }
        /// <summary>
        /// Max order amount
        /// </summary>
        [JsonProperty("maxOrderAmt")]
        public decimal MaxOrderValue { get; set; }
    }

    /// <summary>
    /// Price filter info
    /// </summary>
    public class BybitSpotPriceFilter
    {
        /// <summary>
        /// Tick size
        /// </summary>
        public decimal TickSize { get; set; }
    }
}
