using Bybit.Net.Objects.Models.Spot;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.Socket.Spot
{
    /// <summary>
    /// Order book update
    /// </summary>
    public class BybitSpotOrderBookUpdate
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("s")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("t")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Asks
        /// </summary>
        [JsonProperty("a")]
        public IEnumerable<BybitSpotOrderBookEntry> Asks { get; set; } = Array.Empty<BybitSpotOrderBookEntry>();
        /// <summary>
        /// Bids
        /// </summary>
        [JsonProperty("b")]
        public IEnumerable<BybitSpotOrderBookEntry> Bids { get; set; } = Array.Empty<BybitSpotOrderBookEntry>();
    }
}
