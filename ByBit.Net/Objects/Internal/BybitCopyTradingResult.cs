using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Internal
{
    internal class BybitCopyTradingResult<T>
    {
        [JsonProperty("retCode")]
        public int ReturnCode { get; set; }
        [JsonProperty("retMsg")]
        public string ReturnMessage { get; set; } = string.Empty;       

#pragma warning disable 8618
        public T Result { get; set; }
#pragma warning restore
    }
}
