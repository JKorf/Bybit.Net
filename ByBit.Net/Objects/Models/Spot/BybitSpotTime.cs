using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Spot
{
    internal class BybitSpotTime
    {
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime ServerTime { get; set; }
    }
}
