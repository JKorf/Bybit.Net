using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Internal
{
    internal class BybitExtResult<T, U>
    {
        [JsonProperty("retCode")]
        public int ReturnCode { get; set; }

        [JsonProperty("retMsg")]
        public string ReturnMessage { get; set; } = string.Empty;

        [JsonProperty("time"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }

#pragma warning disable 8618
        [JsonProperty("result")]
        public T Result { get; set; }

        [JsonProperty("retExtInfo")]
        public U ExtInfo { get; set; }
#pragma warning restore
    }
}
