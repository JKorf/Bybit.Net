using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Spot.v3
{
    /// <summary>
    /// Ticker info
    /// </summary>
    public class BybitSpotTickerV3
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
        [JsonProperty("s")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Current best bid price
        /// </summary>
        [JsonProperty("bp")]
        public decimal BestBidPrice { get; set; }
        /// <summary>
        /// Current best ask price
        /// </summary>
        [JsonProperty("ap")]
        public decimal BestAskPrice { get; set; }
        /// <summary>
        /// Volume
        /// </summary>
        [JsonProperty("v")]
        public decimal Volume { get; set; }
        /// <summary>
        /// Quote volume
        /// </summary>
        [JsonProperty("qv")]
        public decimal QuoteVolume { get; set; }
        /// <summary>
        /// 24 hour high price
        /// </summary>
        [JsonProperty("h")]
        public decimal HighPrice { get; set; }
        /// <summary>
        /// 24 hour low price
        /// </summary>
        [JsonProperty("l")]
        public decimal LowPrice { get; set; }
        /// <summary>
        /// Price 24 hours ago
        /// </summary>
        [JsonProperty("o")]
        public decimal OpenPrice { get; set; }
        /// <summary>
        /// Last traded price
        /// </summary>
        [JsonProperty("lp")]
        public decimal LastPrice { get; set; }
    }
}
