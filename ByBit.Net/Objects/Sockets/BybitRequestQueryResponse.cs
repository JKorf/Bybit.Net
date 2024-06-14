using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Objects.Sockets
{
    internal class BybitRequestQueryResponse<T>
    {
        [JsonProperty("reqId")]
        public string RequestId { get; set; } = string.Empty;
        [JsonProperty("retCode")]
        public int ReturnCode { get; set; }
        [JsonProperty("retMsg")]
        public string ReturnMessage { get; set; } = string.Empty;
        [JsonProperty("data")]
        public T? Data { get; set; }
        [JsonProperty("header")]
        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
        [JsonProperty("connId")]
        public string ConnectionId { get; set; } = string.Empty;
    }
}
