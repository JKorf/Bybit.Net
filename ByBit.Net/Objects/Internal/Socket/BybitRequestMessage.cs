using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Objects.Internal.Socket
{
    internal class BybitRequestMessage
    {
        [JsonProperty("op")]
        public string Operation { get; set; }
        [JsonProperty("args")]
        public object[] Parameters { get; set; }
    }
}
