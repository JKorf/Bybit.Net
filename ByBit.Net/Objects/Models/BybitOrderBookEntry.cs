using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Newtonsoft.Json;

namespace ByBit.Net.Objects.Models
{
    /// <summary>
    /// Order book entry
    /// </summary>
    public class BybitOrderBookEntry
    {
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Price of the entry
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Quantity of the entry
        /// </summary>
        [JsonProperty("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Side of the entry
        /// </summary>
        [JsonConverter(typeof(OrderSideConverter))]
        public OrderSide Side { get; set; }
    }
}
