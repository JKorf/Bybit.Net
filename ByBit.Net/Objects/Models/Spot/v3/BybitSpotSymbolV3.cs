using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.Spot.v3
{
    /// <summary>
    /// Symbol info
    /// </summary>
    public class BybitSpotSymbolV3
    {
        /// <summary>
        /// Name of the symbol
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Alias
        /// </summary>
        public string Alias { get; set; } = string.Empty;
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
        /// Precision of the base asset
        /// </summary>
        public decimal BasePrecision { get; set; }
        /// <summary>
        /// Precision of the quote asset
        /// </summary>
        public decimal QuotePrecision { get; set; }
        /// <summary>
        /// Minimal order quantity
        /// </summary>
        [JsonProperty("minTradeQty")]
        public decimal MinOrderQuantity { get; set; }

        /// <summary>
        /// Minimal order value (quantity * price)
        /// </summary>
        [JsonProperty("minTradeAmt")]
        public decimal MinOrderValue { get; set; }

        /// <summary>
        /// Price precision
        /// </summary>
        [JsonProperty("minPricePrecision")]
        public decimal PricePrecision { get; set; }
        /// <summary>
        /// Max order quantity
        /// </summary>
        [JsonProperty("maxTradeQty")]
        public decimal MaxOrderQuantity { get; set; }

        /// <summary>
        /// Max order value (quantity * price)
        /// </summary>
        [JsonProperty("maxTradeAmt")]
        public decimal MaxOrderValue { get; set; }

        /// <summary>
        /// Category
        /// </summary>
        public int Category { get; set; }

        /// <summary>
        /// True indicates that the price of this currency is relatively volatile
        /// </summary>
        public string Innovation { get; set; } = string.Empty;

        /// <summary>
        /// True indicates that the symbol open for trading
        /// </summary>
        public string ShowStatus { get; set; } = string.Empty;
    }
}
