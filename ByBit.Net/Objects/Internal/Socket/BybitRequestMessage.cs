using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Objects.Internal.Socket
{
    internal class BybitFuturesRequestMessage
    {
        [JsonProperty("op")]
        public string Operation { get; set; }
        [JsonProperty("args")]
        public object[] Parameters { get; set; }
    }

    internal class BybitSpotRequestMessage
    {
        [JsonProperty("topic")]
        public string Operation { get; set; }
        [JsonProperty("params")]
        public Dictionary<string, object> Parameters { get; set; }        
        [JsonProperty("event")]
        public string Event { get; set; }
    }
}
