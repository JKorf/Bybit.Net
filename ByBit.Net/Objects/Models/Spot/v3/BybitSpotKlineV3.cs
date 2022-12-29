using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Spot.v3
{
    /// <summary>
    /// Kline data
    /// </summary>
    public class BybitSpotKlineV3
    {
        /// <summary>
        /// Candle open time
        /// </summary>
        [JsonProperty("t"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime OpenTime { get; set; }
        /// <summary>
        /// Name of the trading pair
        /// </summary>
        [JsonProperty("s")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Alias
        /// </summary>
        [JsonProperty("sn")]
        public string Alias { get; set; } = string.Empty;
        /// <summary>
        /// Open price
        /// </summary>
        [JsonProperty("o")]
        public decimal OpenPrice { get; set; }
        /// <summary>
        /// High price
        /// </summary>
        [JsonProperty("h")]
        public decimal HighPrice { get; set; }
        /// <summary>
        /// Low price
        /// </summary>
        [JsonProperty("l")]
        public decimal LowPrice { get; set; }
        /// <summary>
        /// Close price
        /// </summary>
        [JsonProperty("c")]
        public decimal ClosePrice { get; set; }
        /// <summary>
        /// Trading volume
        /// </summary>
        [JsonProperty("v")]
        public decimal Volume { get; set; }
    }
}
