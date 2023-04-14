using Newtonsoft.Json;

namespace Bybit.Net.Objects.Internal.Socket
{
    internal class BybitV5RequestMessage
    {
        [JsonProperty("op")]
        public string Operation { get; set; }
        [JsonProperty("args")]
        public object[] Parameters { get; set; }
        [JsonProperty("req_id")]
        public string RequestId { get; set; }

        public BybitV5RequestMessage(string operation, object[] parameters, string requestId)
        {
            Operation = operation;
            Parameters = parameters;
            RequestId = requestId;
        }
    }
}
