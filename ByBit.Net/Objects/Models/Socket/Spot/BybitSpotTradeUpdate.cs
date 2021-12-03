using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Socket.Spot
{
    /// <summary>
    /// Trade update
    /// </summary>
    public class BybitSpotTradeUpdate
    {
        /// <summary>
        /// Transaction id
        /// </summary>
        [JsonProperty("v")]
        public long Id { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("t"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Trade price
        /// </summary>
        [JsonProperty("p")]
        public decimal Price { get; set; }
        /// <summary>
        /// Trade quantity
        /// </summary>
        [JsonProperty("q")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Is buy
        /// </summary>
        [JsonProperty("m")]
        public bool Buy { get; set; }
    }
}
