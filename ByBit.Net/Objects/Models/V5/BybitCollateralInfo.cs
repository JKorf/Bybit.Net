using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Collateral info
    /// </summary>
    [SerializationModel]
    public record BybitCollateralInfo
    {
        /// <summary>
        /// Asset
        /// </summary>
        [JsonPropertyName("currency")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Hourly borrow rate
        /// </summary>
        [JsonPropertyName("hourlyBorrowRate")]
        public decimal HourlyBorrowRate { get; set; }
        /// <summary>
        /// Max borrow amount
        /// </summary>
        [JsonPropertyName("maxBorrowingAmount")]
        public decimal MaxBorrowAmount { get; set; }
        /// <summary>
        /// Free borrow amount
        /// </summary>
        [JsonPropertyName("freeBorrowAmount")]
        public decimal? FreeBorrowAmount { get; set; }
        /// <summary>
        /// The maximum limit for interest-free borrowing
        /// </summary>
        [JsonPropertyName("freeBorrowingLimit")]
        public decimal? FreeBorrowingLimit { get; set; }
        /// <summary>
        /// Borrow amount
        /// </summary>
        [JsonPropertyName("borrowAmount")]
        public decimal BorrowAmount { get; set; }
        /// <summary>
        /// The sum of borrowing amount for other accounts under the same main account
        /// </summary>
        [JsonPropertyName("otherBorrowAmount")]
        public decimal OtherBorrowAmount { get; set; }
        /// <summary>
        /// Available to borrow
        /// </summary>
        [JsonPropertyName("availableToBorrow")]
        public decimal AvailableToBorrow { get; set; }
        /// <summary>
        /// Is borrowable
        /// </summary>
        [JsonPropertyName("borrowable")]
        public bool Borrowable { get; set; }
        /// <summary>
        /// Whether it can be used as a margin collateral currency
        /// </summary>
        [JsonPropertyName("marginCollateral")]
        public bool MarginCollateral { get; set; }
        /// <summary>
        /// Whether the collateral is turned on by user 
        /// </summary>
        [JsonPropertyName("collateralSwitch")]
        public bool CollateralSwitch { get; set; }
        /// <summary>
        /// Collateral ratio
        /// </summary>
        [JsonPropertyName("collateralRatio")]
        public decimal CollateralRatio { get; set; }
        /// <summary>
        /// Borrow usage rate
        /// </summary>
        [JsonPropertyName("borrowUsageRate")]
        public decimal? BorrowUsageRate { get; set; }
    }
}
