using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Order book info
    /// </summary>
    public record BybitOrderbook
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("s")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Bids
        /// </summary>
        [JsonProperty("b")]
        public IEnumerable<BybitOrderbookEntry> Bids { get; set; } = Array.Empty<BybitOrderbookEntry>();
        /// <summary>
        /// Asks
        /// </summary>
        [JsonProperty("a")]
        public IEnumerable<BybitOrderbookEntry> Asks { get; set; } = Array.Empty<BybitOrderbookEntry>();
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("ts")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Update id
        /// </summary>
        [JsonProperty("u")]
        public long UpdateId { get; set; }
        /// <summary>
        /// Cross sequence
        /// </summary>
        [JsonProperty("seq")]
        public long? Sequence { get; set; }
    }

    /// <summary>
    /// Order book entry
    /// </summary>
    [JsonConverter(typeof(ArrayConverter))]
    public record BybitOrderbookEntry : ISymbolOrderBookEntry
    {
        /// <summary>
        /// Price of the entry
        /// </summary>
        [ArrayProperty(0)]
        public decimal Price { get; set; }
        /// <summary>
        /// Quantity of the entry
        /// </summary>
        [ArrayProperty(1)]
        public decimal Quantity { get; set; }
    }
}
