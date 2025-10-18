using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Interfaces;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using Bybit.Net.Converters;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Order book info
    /// </summary>
    [SerializationModel]
    public record BybitRpiOrderbook
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
        public BybitRpiOrderbookEntry[] Bids { get; set; } = Array.Empty<BybitRpiOrderbookEntry>();
        /// <summary>
        /// Asks
        /// </summary>
        [JsonPropertyName("a")]
        public BybitRpiOrderbookEntry[] Asks { get; set; } = Array.Empty<BybitRpiOrderbookEntry>();
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
    [JsonConverter(typeof(ArrayConverter<BybitRpiOrderbookEntry>))]
    [SerializationModel]
    public record BybitRpiOrderbookEntry
    {
        /// <summary>
        /// Price of the entry
        /// </summary>
        [ArrayProperty(0), JsonConverter(typeof(DecimalConverter))]
        public decimal Price { get; set; }
        /// <summary>
        /// None RPI quantity
        /// </summary>
        [ArrayProperty(1)]
        public decimal NoneRpiQuantity { get; set; }
        /// <summary>
        /// RPI quantity
        /// </summary>
        [ArrayProperty(1)]
        public decimal RpiQuantity { get; set; }
    }
}
