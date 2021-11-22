using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Objects.Internal.Socket
{
    internal class BybitResponseMessage
    {
        public bool Success { get; set; }
        [JsonProperty("ret_msg")]
        public bool ReturnMessage { get; set; }
        [JsonProperty("conn_id")]
        public string ConnectionId { get; set; }
        public BybitRequestMessage Request { get; set; }
    }
}
