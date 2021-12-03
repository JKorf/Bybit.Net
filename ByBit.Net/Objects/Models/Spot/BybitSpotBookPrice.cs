using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Spot
{
    /// <summary>
    /// Book price info
    /// </summary>
    public class BybitSpotBookPrice
    {
        /// <summary>
        /// The symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Best bid price
        /// </summary>
        [JsonProperty("bidPrice")]
        public decimal BestBidPrice { get; set; }
        /// <summary>
        /// Quantity of the best bid price
        /// </summary>
        [JsonProperty("bidQty")]
        public decimal BestBidQuantity { get; set; }
        /// <summary>
        /// Best ask price
        /// </summary>
        [JsonProperty("askPrice")]
        public decimal BestAskPrice { get; set; }
        /// <summary>
        /// Quantity of the best ask price
        /// </summary>
        [JsonProperty("askQty")]
        public decimal BestAskQuantity { get; set; }
        /// <summary>
        /// Timestamp of the data
        /// </summary>
        [JsonProperty("time"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
