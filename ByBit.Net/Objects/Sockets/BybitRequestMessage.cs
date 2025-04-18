using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Sockets
{
    internal class BybitRequestMessage
    {
        [JsonPropertyName("req_id")]
        public string RequestId { get; set; } = string.Empty;
        [JsonPropertyName("op")]
        public string Operation { get; set; } = string.Empty;
        [JsonPropertyName("args"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object[]? Args { get; set; }
    }

    internal class BybitRequestQueryMessage
    {
        [JsonPropertyName("reqId")]
        public string RequestId { get; set; } = string.Empty;
        [JsonPropertyName("op")]
        public string Operation { get; set; } = string.Empty;
        [JsonPropertyName("header"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, string>? Header { get; set; }
        [JsonPropertyName("args"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object[]? Args { get; set; }
    }
}
