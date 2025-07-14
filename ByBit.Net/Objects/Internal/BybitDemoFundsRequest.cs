using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
