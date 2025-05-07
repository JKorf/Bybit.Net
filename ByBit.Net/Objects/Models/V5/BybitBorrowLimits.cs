using CryptoExchange.Net.Converters.SystemTextJson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Borrow limit
    /// </summary>
    [SerializationModel]
    public record BybitBorrowLimits
    {
        /// <summary>
        /// Collateral asset
        /// </summary>
        [JsonPropertyName("collateralCurrency")]
        public string CollateralAsset { get; set; } = string.Empty;
        /// <summary>
        /// Loan asset
        /// </summary>
        [JsonPropertyName("loanCurrency")]
        public string LoanAsset { get; set; } = string.Empty;
        /// <summary>
        /// Max collateral quantity
        /// </summary>
        [JsonPropertyName("maxCollateralAmount")]
        public decimal MaxCollateralQuantity { get; set; }
        /// <summary>
        /// Max loan quantity
        /// </summary>
        [JsonPropertyName("maxLoanAmount")]
        public decimal MaxLoanQuantity { get; set; }
        /// <summary>
        /// Min collateral quantity
        /// </summary>
        [JsonPropertyName("minCollateralAmount")]
        public decimal MinCollateralQuantity { get; set; }
        /// <summary>
        /// Min loan quantity
        /// </summary>
        [JsonPropertyName("minLoanAmount")]
        public decimal MinLoanQuantity { get; set; }
    }


}
