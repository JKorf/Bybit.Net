using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Internal
{
    internal class BybitDemoFundsRequest
    {
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;

        [JsonPropertyName("amountStr"), JsonConverter(typeof(DecimalStringWriterConverter))]
        public decimal Quantity { get; set; }
    }
}
