using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Sockets
{
    internal class BybitRequestQueryResponse<T>
    {
        [JsonPropertyName("reqId")]
        public string RequestId { get; set; } = string.Empty;
        [JsonPropertyName("retCode")]
        public int ReturnCode { get; set; }
        [JsonPropertyName("retMsg")]
        public string ReturnMessage { get; set; } = string.Empty;
        [JsonPropertyName("data")]
        public T? Data { get; set; }
        [JsonPropertyName("header")]
        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
        [JsonPropertyName("connId")]
        public string ConnectionId { get; set; } = string.Empty;
    }

    internal class BybitRequestQueryResponse<T, U> : BybitRequestQueryResponse<T>
    {
        [JsonPropertyName("retExtInfo")]
        public U? ExtendedInfo { get; set; }
    }
}
