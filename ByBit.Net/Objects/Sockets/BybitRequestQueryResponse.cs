using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Objects.Sockets
{
    internal class BybitRequestQueryResponse<T>
    {
        [JsonProperty("reqId")]
        public string RequestId { get; set; }
        [JsonProperty("retCode")]
        public int ReturnCode { get; set; }
        [JsonProperty("retMsg")]
        public string ReturnMessage { get; set; }
        [JsonProperty("data")]
        public T? Data { get; set; }
        [JsonProperty("header")]
        public Dictionary<string, string> Headers { get; set; }
        [JsonProperty("connId")]
        public string ConnectionId { get; set; }
    }
}
