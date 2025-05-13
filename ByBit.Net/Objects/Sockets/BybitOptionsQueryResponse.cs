using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Sockets
{
    internal class BybitOptionsQueryResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }
        [JsonPropertyName("ret_msg")]
        public string Message { get; set; } = string.Empty;
        [JsonPropertyName("conn_id")]
        public string ConnectionId { get; set; } = string.Empty;
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;
        [JsonPropertyName("req_id")]
        public string RequestId { get; set; } = string.Empty;

        [JsonPropertyName("data")]
        public BybitOptionsQueryData Data { get; set; } = null!;
    }

    internal class BybitOptionsQueryData
    {
        [JsonPropertyName("failTopics")]
        public string[] FailedTopics { get; set; } = [];
        [JsonPropertyName("successTopics")]
        public string[] SuccessTopics { get; set; } = [];
    }
}
