using Newtonsoft.Json;

namespace Bybit.Net.Objects.Internal.Socket
{
    internal class BybitResponseMessage
    {
        public bool Success { get; set; }
        [JsonProperty("ret_msg")]
        public bool ReturnMessage { get; set; }
        [JsonProperty("conn_id")]
        public string ConnectionId { get; set; } = string.Empty;
        public BybitRequestMessage Request { get; set; } = default!;
    }
}
