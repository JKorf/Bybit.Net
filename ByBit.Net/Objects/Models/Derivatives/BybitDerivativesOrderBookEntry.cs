using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.Derivatives
{
    /// <summary>
    /// Order book for Unified Margin
    /// </summary>
    public class BybitDerivativesOrderBookEntry
    {
        /// <summary>
        /// Id for continuity of data
        /// </summary>
        [JsonProperty("u")]
        public long ID { get; set; }

        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("s")]
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// Delivery time
        /// </summary>
        [JsonProperty("ts"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// Buyer. Order by price asc
        /// </summary>
        [JsonProperty("b")]
        public IEnumerable<BybitUnifiedMarginOrderBookItem> Bids { get; set; } = Array.Empty<BybitUnifiedMarginOrderBookItem>();

        /// <summary>
        /// Seller. Order by price asc
        /// </summary>
        [JsonProperty("a")]
        public IEnumerable<BybitUnifiedMarginOrderBookItem> Asks { get; set; } = Array.Empty<BybitUnifiedMarginOrderBookItem>();
    }

    /// <summary>
    /// Order book entry
    /// </summary>
    [JsonConverter(typeof(ArrayConverter))]
    public class BybitUnifiedMarginOrderBookItem : ISymbolOrderBookEntry
    {
        /// <summary>
        /// Price
        /// </summary>
        [ArrayProperty(0)]
        public decimal Price { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [ArrayProperty(1)]
        public decimal Quantity { get; set; }
    }
}
