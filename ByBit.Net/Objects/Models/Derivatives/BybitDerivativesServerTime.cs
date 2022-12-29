using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Derivatives
{
    /// <summary>
    /// Server time record
    /// </summary>
    public class BybitDerivativesServerTime
    {
        /// <summary>
        /// ServerTime
        /// </summary>
        [JsonProperty("timeSecond"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime ServerTime { get; set; }
    }
}
