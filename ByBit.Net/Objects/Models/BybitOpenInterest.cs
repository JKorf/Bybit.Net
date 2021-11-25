using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Open interest info
    /// </summary>
    public class BybitOpenInterest
    {
        /// <summary>
        /// Open interest value
        /// </summary>
        [JsonProperty("open_interest")]
        public decimal OpenInterest { get; set; }
        /// <summary>
        /// Date timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
    }
}
