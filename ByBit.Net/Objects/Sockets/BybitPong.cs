using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Sockets
{
    internal class BybitPong
    {
        [JsonPropertyName("pong")]
        public string Operation { get; set; } = string.Empty;
    }
}
