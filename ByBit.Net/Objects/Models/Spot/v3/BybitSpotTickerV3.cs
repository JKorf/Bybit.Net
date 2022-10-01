using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Bybit.Net.Converters;

namespace Bybit.Net.Objects.Models.Spot.v3
{
    /// <summary>
    /// Wrapper for tickers deserialization
    /// </summary>
    public class BybitSpotTickerWrapper
    {
        /// <summary>
        /// List of spot tickers
        /// </summary>
        [JsonProperty("list")]
        public IEnumerable<BybitSpotTickerV3> Tickers { get; set; } = Array.Empty<BybitSpotTickerV3>();
    }

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
        [JsonConverter(typeof(DecimalJsonConverter))]
        [JsonProperty("bp")]
        public decimal BestBidPrice { get; set; }
        /// <summary>
        /// Current best ask price
        /// </summary>
        [JsonConverter(typeof(DecimalJsonConverter))]
        [JsonProperty("ap")]
        public decimal BestAskPrice { get; set; }
        /// <summary>
        /// Volume
        /// </summary>
        [JsonConverter(typeof(DecimalJsonConverter))]
        [JsonProperty("v")]
        public decimal Volume { get; set; }
        /// <summary>
        /// Quote volume
        /// </summary>
        [JsonConverter(typeof(DecimalJsonConverter))]
        [JsonProperty("qv")]
        public decimal QuoteVolume { get; set; }
        /// <summary>
        /// 24 hour high price
        /// </summary>
        [JsonConverter(typeof(DecimalJsonConverter))]
        [JsonProperty("h")]
        public decimal HighPrice { get; set; }
        /// <summary>
        /// 24 hour low price
        /// </summary>
        [JsonConverter(typeof(DecimalJsonConverter))]
        [JsonProperty("l")]
        public decimal LowPrice { get; set; }
        /// <summary>
        /// Price 24 hours ago
        /// </summary>
        [JsonConverter(typeof(DecimalJsonConverter))]
        [JsonProperty("o")]
        public decimal OpenPrice { get; set; }
        /// <summary>
        /// Last traded price
        /// </summary>
        [JsonConverter(typeof(DecimalJsonConverter))]
        [JsonProperty("lp")]
        public decimal LastPrice { get; set; }
    }
}
