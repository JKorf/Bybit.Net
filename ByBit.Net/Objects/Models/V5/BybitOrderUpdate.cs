using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// User order update
    /// </summary>
    public record BybitOrderUpdate : BybitOrder
    {
        /// <summary>
        /// Closed profit and loss for a close position order.
        /// </summary>
        [JsonProperty("closedPnl")]
        public decimal? ClosedPnl { get; set; }

        /// <summary>
        /// Category
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public Category Category { get; set; }
    }
}
