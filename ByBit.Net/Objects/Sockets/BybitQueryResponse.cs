using Newtonsoft.Json;

namespace Bybit.Net.Objects.Sockets
{
    internal class BybitQueryResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("ret_msg")]
        public string Message { get; set; } = string.Empty;
        [JsonProperty("conn_id")]
        public string ConnectionId { get; set; } = string.Empty;
        [JsonProperty("req_id")]
        public string RequestId { get; set; } = string.Empty;
        [JsonProperty("op")]
        public string Operation { get; set; } = string.Empty;
    }
}
