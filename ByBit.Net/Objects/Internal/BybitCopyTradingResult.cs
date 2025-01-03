using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Internal
{
    internal class BybitCopyTradingResult<T>
    {
        [JsonPropertyName("retCode")]
        public int ReturnCode { get; set; }
        [JsonPropertyName("retMsg")]
        public string ReturnMessage { get; set; } = string.Empty;       

#pragma warning disable 8618
        public T Result { get; set; }
#pragma warning restore
    }
}
