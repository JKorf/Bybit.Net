using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.Spot.v1
{
    /// <summary>
    /// Symbol info
    /// </summary>
    public class BybitSpotSymbolV1
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
        [JsonProperty("baseCurrency")]
        public string BaseAsset { get; set; } = string.Empty;

        /// <summary>
        /// Quote asset
        /// </summary>
        [JsonProperty("quoteCurrency")]
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
        [JsonProperty("minTradeQuantity")]
        public decimal MinOrderQuantity { get; set; }

        /// <summary>
        /// Minimal order value (quantity * price)
        /// </summary>
        [JsonProperty("minTradeAmount")]
        public decimal MinOrderValue { get; set; }

        /// <summary>
        /// Price precision
        /// </summary>
        [JsonProperty("minPricePrecision")]
        public decimal PricePrecision { get; set; }
        /// <summary>
        /// Max order quantity
        /// </summary>
        [JsonProperty("maxTradeQuantity")]
        public decimal MaxOrderQuantity { get; set; }

        /// <summary>
        /// Max order value (quantity * price)
        /// </summary>
        [JsonProperty("maxTradeAmount")]
        public decimal MaxOrderValue { get; set; }

        /// <summary>
        /// Category
        /// </summary>
        public int Category { get; set; }


        /// <summary>
        /// True indicates that the price of this currency is relatively volatile
        /// </summary>
        public bool Innovation { get; set; }

        /// <summary>
        /// True indicates that the symbol open for trading
        /// </summary>
        public bool ShowStatus { get; set; }
    }
}
