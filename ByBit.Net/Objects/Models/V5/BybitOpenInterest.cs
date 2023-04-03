using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Open interest at a time
    /// </summary>
    public class BybitOpenInterest
    {
        /// <summary>
        /// Open interest
        /// </summary>
        public decimal OpenInterest { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
