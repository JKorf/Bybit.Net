using CryptoExchange.Net.Converters.SystemTextJson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Loan info
    /// </summary>
    [SerializationModel]
    public record BybitLoan
    {
        /// <summary>
        /// Collateral quantity
        /// </summary>
        [JsonPropertyName("collateralAmount")]
        public decimal CollateralQuantity { get; set; }
        /// <summary>
        /// Collateral asset
        /// </summary>
        [JsonPropertyName("collateralCurrency")]
        public string CollateralAsset { get; set; } = string.Empty;
        /// <summary>
        /// Current LTV
        /// </summary>
        [JsonPropertyName("currentLTV")]
        public decimal CurrentLtv { get; set; }
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
        /// Loan asset
        /// </summary>
        [JsonPropertyName("loanCurrency")]
        public string LoanAsset { get; set; } = string.Empty;
        /// <summary>
        /// Loan term
        /// </summary>
        [JsonPropertyName("loanTerm")]
        public decimal? LoanTerm { get; set; }
        /// <summary>
        /// Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Residual interest
        /// </summary>
        [JsonPropertyName("residualInterest")]
        public decimal ResidualInterest { get; set; }
        /// <summary>
        /// Residual penalty interest
        /// </summary>
        [JsonPropertyName("residualPenaltyInterest")]
        public decimal ResidualPenaltyInterest { get; set; }
        /// <summary>
        /// Total debt
        /// </summary>
        [JsonPropertyName("totalDebt")]
        public decimal TotalDebt { get; set; }
    }


}
