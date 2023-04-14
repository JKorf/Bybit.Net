using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Server time info
    /// </summary>
    public class BybitTime
    {
        /// <summary>
        /// Seconds timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime TimeSecond { get; set; }
        /// <summary>
        /// Nano seconds timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime TimeNano { get; set; }
    }
}
