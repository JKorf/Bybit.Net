using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Interfaces;
using System.Text.Json.Serialization;
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
        [JsonPropertyName("s")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Bids
        /// </summary>
        [JsonPropertyName("b")]
        public IEnumerable<BybitOrderbookEntry> Bids { get; set; } = Array.Empty<BybitOrderbookEntry>();
        /// <summary>
        /// Asks
        /// </summary>
        [JsonPropertyName("a")]
        public IEnumerable<BybitOrderbookEntry> Asks { get; set; } = Array.Empty<BybitOrderbookEntry>();
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonPropertyName("ts")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Update id
        /// </summary>
        [JsonPropertyName("u")]
        public long UpdateId { get; set; }
        /// <summary>
        /// Cross sequence
        /// </summary>
        [JsonPropertyName("seq")]
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
