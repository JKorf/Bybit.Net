using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Quantity available to repay a UTA loan without asset conversion
    /// </summary>
    [SerializationModel]
    public record BybitRepaymentAvailableQuantity
    {
        /// <summary>
        /// ["<c>currency</c>"] Asset
        /// </summary>
        [JsonPropertyName("currency")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>lossLessRepaymentAmount</c>"] Repayment quantity = min(spot available balance, borrow quantity)
        /// </summary>
        [JsonPropertyName("lossLessRepaymentAmount")]
        public decimal LossLessRepaymentQuantity { get; set; }
    }
}