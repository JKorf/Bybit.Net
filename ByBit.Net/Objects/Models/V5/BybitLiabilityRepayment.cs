using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Liability repayment info
    /// </summary>
    public record BybitLiabilityRepayment
    {
        /// <summary>
        /// Asset name
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Repayment quantity
        /// </summary>
        [JsonProperty("repaymentQty")]
        public decimal RepaymentQuantity { get; set; }
    }
}
