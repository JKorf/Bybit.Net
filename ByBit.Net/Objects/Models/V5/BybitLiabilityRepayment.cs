using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Liability repayment info
    /// </summary>
    [SerializationModel]
    public record BybitLiabilityRepayment
    {
        /// <summary>
        /// Asset name
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Repayment quantity
        /// </summary>
        [JsonPropertyName("repaymentQty")]
        public decimal RepaymentQuantity { get; set; }
    }
}
