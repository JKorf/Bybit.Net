using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Sockets
{
    internal class BybitRequestMessage
    {
        [JsonProperty("req_id")]
        public string RequestId { get; set; } = string.Empty;
        [JsonProperty("op")]
        public string Operation { get; set; } = string.Empty;
        [JsonProperty("args", NullValueHandling = NullValueHandling.Ignore)]
        public List<object>? Args { get; set; }
    }
}
