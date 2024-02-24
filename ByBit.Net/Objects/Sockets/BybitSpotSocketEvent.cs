using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Sockets
{
    internal class BybitSpotSocketEvent<T>
    {
        [JsonProperty("topic")]
        public string Topic { get; set; } = string.Empty;
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("ts")]
        public DateTime Timestamp { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; } = default!;
    }
}
