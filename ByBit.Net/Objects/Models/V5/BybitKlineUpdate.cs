using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Kline update
    /// </summary>
    public class BybitKlineUpdate
    {
        /// <summary>
        /// Kline start time
        /// </summary>
        [JsonProperty("start")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime StartTime { get; set; }
        /// <summary>
        /// Kline end time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("end")]
        public DateTime EndTime { get; set; }
        /// <summary>
        /// Interval
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public KlineInterval Interval { get; set; }
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
        /// High price
        /// </summary>
        [JsonProperty("high")]
        public decimal HighPrice { get; set; }
        /// <summary>
        /// Low price
        /// </summary>
        [JsonProperty("low")]
        public decimal LowPrice { get; set; }
        /// <summary>
        /// Volume
        /// </summary>
        public decimal Volume { get; set; }
        /// <summary>
        /// Turnover
        /// </summary>
        public decimal Turnover { get; set; }
        /// <summary>
        /// Is kline finished or still updating
        /// </summary>
        public bool Confirm { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
