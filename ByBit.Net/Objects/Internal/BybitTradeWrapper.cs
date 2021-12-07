using Bybit.Net.Objects.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Internal
{
    internal class BybitTradeWrapper
    {
        [JsonProperty("trade_list")]
        public IEnumerable<BybitUserTrade> Trades { get; set; } = Array.Empty<BybitUserTrade>();
    }

}
