using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Objects.Models.Socket.Spot
{
    internal class BybitSpotPing
    {
        [JsonProperty("ping")]
        public long Ping { get; set; }
    }
}
