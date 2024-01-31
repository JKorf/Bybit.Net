using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Volatility info
    /// </summary>
    public class BybitHistoricalVolatility
    {
        /// <summary>
        /// Period
        /// </summary>
        public int Period { get; set; }
        /// <summary>
        /// Value
        /// </summary>
        public decimal Value { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("time")]
        public DateTime Timestamp { get; set; }
    }
}
