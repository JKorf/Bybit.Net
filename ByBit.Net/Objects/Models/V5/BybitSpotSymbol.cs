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
        /// Marging trade status
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public MarginTrading MarginTrading { get; set; }
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
        /// <summary>
        /// Price percentage filter
        /// </summary>
        [JsonProperty("riskParameters")]
        public BybitPriceLimit? PricePercentageFilter { get; set; }
    }

    /// <summary>
    /// Price limits
    /// </summary>
    public class BybitPriceLimit
    {
        /// <summary>
        /// Price limit on Limit order. For example, "0.05" means 5%, so the order price of your buy order cannot exceed 105% of the Last Traded Price, while the order price of your sell order cannot be lower than 95% of the Last Traded Price
        /// </summary>
        [JsonProperty("limitParameter")]
        public decimal LimitPricePercentageLimit { get; set; }
        /// <summary>
        /// Price limit on Market order. For example, assuming the market order limit for MNT/USDT is 5%. When the last traded price is at 2 USDT, a trader places a market order for 100,000 USDT. Any portion that could have been filled at above 2.1 USDT will be canceled. Assuming only 80,000 USDT order value can be filled at a price of 2.1 USDT or below, the remaining 20,000 USDT order value will be canceled since the deviation exceeds the 5% threshold.
        /// </summary>
        [JsonProperty("marketParameter")]
        public decimal MarketPricePercentageLimit { get; set; }
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
