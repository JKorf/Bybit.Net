using CryptoExchange.Net.Converters;
using CryptoExchange.Net.ExchangeInterfaces;
using CryptoExchange.Net.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.Spot
{
    /// <summary>
    /// Order book info
    /// </summary>
    public class BybitSpotOrderBook: ICommonOrderBook
    {
        /// <summary>
        /// Timestamp of the data
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("time")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Bids
        /// </summary>
        public IEnumerable<BybitSpotOrderBookEntry> Bids { get; set; } = Array.Empty<BybitSpotOrderBookEntry>();
        
        /// <summary>
        /// Asks
        /// </summary>
        public IEnumerable<BybitSpotOrderBookEntry> Asks { get; set; } = Array.Empty<BybitSpotOrderBookEntry>();

        IEnumerable<ISymbolOrderBookEntry> ICommonOrderBook.CommonBids => Bids;

        IEnumerable<ISymbolOrderBookEntry> ICommonOrderBook.CommonAsks => Asks;
    }
}
