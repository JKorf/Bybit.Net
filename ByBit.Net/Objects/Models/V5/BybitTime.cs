using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Server time info
    /// </summary>
    [SerializationModel]
    public record BybitTime
    {
        /// <summary>
        /// Seconds timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonPropertyName("timeSecond")]
        public DateTime TimeSecond { get; set; }
        /// <summary>
        /// Nano seconds timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonPropertyName("timeNano")]
        public DateTime TimeNano { get; set; }
    }
}
