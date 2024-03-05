using Newtonsoft.Json;

namespace Bybit.Net.Objects.Sockets
{
    internal class BybitPong
    {
        [JsonProperty("pong")]
        public string Operation { get; set; } = string.Empty;
    }
}
