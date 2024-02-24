using Bybit.Net.Objects.Models.Spot;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Internal
{
    internal class BybitBalanceWrapper
    {
        [JsonProperty("balances")]
        public IEnumerable<BybitSpotBalance> Balances { get; set; } = Array.Empty<BybitSpotBalance>();
    }

}
