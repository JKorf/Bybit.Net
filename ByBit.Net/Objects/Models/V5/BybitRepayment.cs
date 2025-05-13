using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Repayment info
    /// </summary>
    [SerializationModel]
    public record BybitRepayment
    {
        /// <summary>
        /// Collateral asset
        /// </summary>
        [JsonPropertyName("collateralCurrency")]
        public string CollateralAsset { get; set; } = string.Empty;
        /// <summary>
        /// Collateral return
        /// </summary>
        [JsonPropertyName("collateralReturn")]
        public decimal CollateralReturn { get; set; }
        /// <summary>
        /// Loan asset
        /// </summary>
        [JsonPropertyName("loanCurrency")]
        public string LoanAsset { get; set; } = string.Empty;
        /// <summary>
        /// Loan term
        /// </summary>
        [JsonPropertyName("loanTerm")]
        public string? LoanTerm { get; set; }
        /// <summary>
        /// Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Repay quantity
        /// </summary>
        [JsonPropertyName("repayAmount")]
        public decimal RepayQuantity { get; set; }
        /// <summary>
        /// Repay id
        /// </summary>
        [JsonPropertyName("repayId")]
        public string RepayId { get; set; } = string.Empty;
        /// <summary>
        /// Repay status
        /// </summary>
        [JsonPropertyName("repayStatus")]
        public RepayStatus? RepayStatus { get; set; }
        /// <summary>
        /// Repay time
        /// </summary>
        [JsonPropertyName("repayTime")]
        public DateTime? RepayTime { get; set; }
        /// <summary>
        /// Repay type
        /// </summary>
        [JsonPropertyName("repayType")]
        public RepayType? RepayType { get; set; }
    }


}
