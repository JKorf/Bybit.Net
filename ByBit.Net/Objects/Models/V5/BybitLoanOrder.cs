using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Loan order info
    /// </summary>
    [SerializationModel]
    public record BybitLoanOrder
    {
        /// <summary>
        /// Borrow time
        /// </summary>
        [JsonPropertyName("borrowTime")]
        public DateTime BorrowTime { get; set; }
        /// <summary>
        /// Collateral asset
        /// </summary>
        [JsonPropertyName("collateralCurrency")]
        public string CollateralAsset { get; set; } = string.Empty;
        /// <summary>
        /// Expiration time
        /// </summary>
        [JsonPropertyName("expirationTime")]
        public DateTime? ExpirationTime { get; set; }
        /// <summary>
        /// Hourly interest rate
        /// </summary>
        [JsonPropertyName("hourlyInterestRate")]
        public decimal HourlyInterestRate { get; set; }
        /// <summary>
        /// Initial collateral quantity
        /// </summary>
        [JsonPropertyName("initialCollateralAmount")]
        public decimal InitialCollateralQuantity { get; set; }
        /// <summary>
        /// Initial loan quantity
        /// </summary>
        [JsonPropertyName("initialLoanAmount")]
        public decimal InitialLoanQuantity { get; set; }
        /// <summary>
        /// Loan asset
        /// </summary>
        [JsonPropertyName("loanCurrency")]
        public string LoanAsset { get; set; } = string.Empty;
        /// <summary>
        /// Loan term
        /// </summary>
        [JsonPropertyName("loanTerm")]
        public LoanTerm? LoanTerm { get; set; }
        /// <summary>
        /// Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Repaid interest
        /// </summary>
        [JsonPropertyName("repaidInterest")]
        public decimal RepaidInterest { get; set; }
        /// <summary>
        /// Repaid penalty interest
        /// </summary>
        [JsonPropertyName("repaidPenaltyInterest")]
        public decimal RepaidPenaltyInterest { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        [JsonPropertyName("status")]
        public LoanStatus Status { get; set; }
    }


}
