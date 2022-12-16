using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Derivatives
{
    /// <summary>
    /// Open interest item
    /// </summary>
    public class BybitDerivativesOpenInterest
    {
        /// <summary>
        /// Open interest value
        /// </summary>
        public decimal OpenInterest { get; set; }
        /// <summary>
        /// Date timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
