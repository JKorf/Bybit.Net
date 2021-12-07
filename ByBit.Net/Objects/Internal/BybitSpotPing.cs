using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.Socket.Spot
{
    internal class BybitSpotPing
    {
        [JsonProperty("ping")]
        public long Ping { get; set; }
    }
}
