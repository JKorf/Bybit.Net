using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Sockets
{
    internal class BybitOptionsQueryResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("ret_msg")]
        public string Message { get; set; } = string.Empty;
        [JsonProperty("conn_id")]
        public string ConnectionId { get; set; } = string.Empty;
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;
        [JsonProperty("req_id")]
        public string RequestId { get; set; } = string.Empty;

        [JsonProperty("data")]
        public BybitOptionsQueryData Data { get; set; } = null!;
    }

    internal class BybitOptionsQueryData
    {
        [JsonProperty("failTopics")]
        public List<string> FailedTopics { get; set; } = new List<string>();
        [JsonProperty("successTopics")]
        public List<string> SuccessTopics { get; set; } = new List<string>();
    }
}
