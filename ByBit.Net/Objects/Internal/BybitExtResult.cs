using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Internal
{
    internal class BybitExtResult<T, U>
    {
        [JsonPropertyName("retCode")]
        public int ReturnCode { get; set; }

        [JsonPropertyName("retMsg")]
        public string ReturnMessage { get; set; } = string.Empty;

        [JsonPropertyName("time"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }

#pragma warning disable 8618
        [JsonPropertyName("result")]
        public T Result { get; set; }

        [JsonPropertyName("retExtInfo")]
        public U ExtInfo { get; set; }
#pragma warning restore
    }
}
