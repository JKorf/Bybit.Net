using CryptoExchange.Net.Converters;
using CryptoExchange.Net.ExchangeInterfaces;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Spot
{
    /// <summary>
    /// Ticker info
    /// </summary>
    public class BybitSpotTicker: ICommonTicker
    {
        /// <summary>
        /// Timestamp of the data
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("time")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Current best bid price
        /// </summary>
        public decimal BestBidPrice { get; set; }
        /// <summary>
        /// Current best ask price
        /// </summary>
        public decimal BestAskPrice { get; set; }
        /// <summary>
        /// Volume
        /// </summary>
        public decimal Volume { get; set; }
        /// <summary>
        /// Quote volume
        /// </summary>
        public decimal QuoteVolume { get; set; }
        /// <summary>
        /// Last trade price
        /// </summary>
        [JsonProperty("lastPrice")]
        public decimal LastTradePrice { get; set; }
        /// <summary>
        /// 24 hour high price
        /// </summary>
        public decimal HighPrice { get; set; }
        /// <summary>
        /// 24 hour low price
        /// </summary>
        public decimal LowPrice { get; set; }
        /// <summary>
        /// Price 24 hours ago
        /// </summary>
        public decimal OpenPrice { get; set; }

        string ICommonTicker.CommonSymbol => Symbol;

        decimal ICommonTicker.CommonHighPrice => HighPrice;

        decimal ICommonTicker.CommonLowPrice => LowPrice;

        decimal ICommonTicker.CommonVolume => Volume;
    }
}
