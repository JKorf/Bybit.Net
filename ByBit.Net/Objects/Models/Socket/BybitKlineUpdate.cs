using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Socket
{
    /// <summary>
    /// Kline update
    /// </summary>
    public class BybitKlineUpdate
    {
        /// <summary>
        /// Open time of the kline
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("start")]
        public DateTime OpenTime { get; set; }
        /// <summary>
        /// Close time of the kline
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("end")]
        public DateTime CloseTime { get; set; }
        /// <summary>
        /// Open price
        /// </summary>
        [JsonProperty("open")]
        public decimal OpenPrice { get; set; }
        /// <summary>
        /// Close price
        /// </summary>
        [JsonProperty("close")]
        public decimal ClosePrice { get; set; }
        /// <summary>
        /// Low price
        /// </summary>
        [JsonProperty("low")]
        public decimal LowPrice { get; set; }
        /// <summary>
        /// High price
        /// </summary>
        [JsonProperty("high")]
        public decimal HighPrice { get; set; }
        /// <summary>
        /// Volume
        /// </summary>
        [JsonProperty("volume")]
        public decimal Volume { get; set; }
        /// <summary>
        /// Turnover
        /// </summary>
        [JsonProperty("turnover")]
        public decimal Turnover { get; set; }
        /// <summary>
        /// Is the final kline
        /// </summary>
        public bool Confirm { get; set; }
        /// <summary>
        /// Cross sequence
        /// </summary>
        [JsonProperty("cross_seq")]
        public long CrossSequence { get; set; }
        /// <summary>
        /// Data timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
