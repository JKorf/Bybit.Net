using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Sockets
{
    internal class BybitSpotSocketEvent<T>
    {
        [JsonPropertyName("topic")]
        public string Topic { get; set; } = string.Empty;
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonPropertyName("ts")]
        public DateTime Timestamp { get; set; }
        [JsonPropertyName("data")]
        public T Data { get; set; } = default!;
        [JsonPropertyName("cts")]
        public DateTime? CTimestamp { get; set; }
    }
}
