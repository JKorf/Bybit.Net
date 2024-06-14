using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Derivatives
{
    /// <summary>
    /// Server time record
    /// </summary>
    public record BybitDerivativesServerTime
    {
        /// <summary>
        /// ServerTime
        /// </summary>
        [JsonProperty("timeSecond"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime ServerTime { get; set; }
    }
}
