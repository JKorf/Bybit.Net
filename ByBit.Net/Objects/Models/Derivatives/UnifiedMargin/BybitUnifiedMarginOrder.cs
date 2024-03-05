using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.Derivatives.UnifiedMargin
{
    /// <summary>
    /// Order
    /// </summary>
    public class BybitUnifiedMarginOrder : BybitDerivativesOrder
    {
        /// <summary>
        /// Implied volatility
        /// </summary>
        [JsonProperty("iv")]
        public decimal? Volatility { get; set; }

        /// <summary>
        /// Initial margin of an order
        /// </summary>
        [JsonProperty("orderIM")]
        public decimal? InitialMargin { get; set; }

        /// <summary>
        /// Market price when the order is placed
        /// </summary>
        [JsonProperty("basePrice")]
        public decimal? MarketPrice { get; set; }
    }
}
