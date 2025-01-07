using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Sockets
{
    internal class BybitQueryResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }
        [JsonPropertyName("ret_msg")]
        public string Message { get; set; } = string.Empty;
        [JsonPropertyName("conn_id")]
        public string ConnectionId { get; set; } = string.Empty;
        [JsonPropertyName("req_id")]
        public string RequestId { get; set; } = string.Empty;
        [JsonPropertyName("op")]
        public string Operation { get; set; } = string.Empty;
    }
}
