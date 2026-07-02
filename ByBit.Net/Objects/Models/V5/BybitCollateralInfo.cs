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
        /// ["<c>currency</c>"] Asset
        /// </summary>
        [JsonPropertyName("currency")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>hourlyBorrowRate</c>"] Hourly borrow rate
        /// </summary>
        [JsonPropertyName("hourlyBorrowRate")]
        public decimal HourlyBorrowRate { get; set; }
        /// <summary>
        /// ["<c>maxBorrowingAmount</c>"] Max borrow amount
        /// </summary>
        [JsonPropertyName("maxBorrowingAmount")]
        public decimal MaxBorrowAmount { get; set; }
        /// <summary>
        /// ["<c>freeBorrowAmount</c>"] Free borrow amount
        /// </summary>
        [JsonPropertyName("freeBorrowAmount")]
        public decimal? FreeBorrowAmount { get; set; }
        [JsonInclude, JsonPropertyName("freeBorrowingAmount")]
        internal decimal? FreeBorrowAmountInt
        {
            set => FreeBorrowAmount = value;
        }
        /// <summary>
        /// ["<c>freeBorrowingLimit</c>"] The maximum limit for interest-free borrowing
        /// </summary>
        [JsonPropertyName("freeBorrowingLimit")]
        public decimal? FreeBorrowingLimit { get; set; }
        /// <summary>
        /// ["<c>borrowAmount</c>"] Borrow amount
        /// </summary>
        [JsonPropertyName("borrowAmount")]
        public decimal BorrowAmount { get; set; }
        /// <summary>
        /// ["<c>otherBorrowAmount</c>"] The sum of borrowing amount for other accounts under the same main account
        /// </summary>
        [JsonPropertyName("otherBorrowAmount")]
        public decimal OtherBorrowAmount { get; set; }
        /// <summary>
        /// ["<c>availableToBorrow</c>"] Available to borrow
        /// </summary>
        [JsonPropertyName("availableToBorrow")]
        public decimal AvailableToBorrow { get; set; }
        /// <summary>
        /// ["<c>borrowable</c>"] Is borrowable
        /// </summary>
        [JsonPropertyName("borrowable")]
        public bool Borrowable { get; set; }
        /// <summary>
        /// ["<c>marginCollateral</c>"] Whether it can be used as a margin collateral currency
        /// </summary>
        [JsonPropertyName("marginCollateral")]
        public bool MarginCollateral { get; set; }
        /// <summary>
        /// ["<c>collateralSwitch</c>"] Whether the collateral is turned on by user 
        /// </summary>
        [JsonPropertyName("collateralSwitch")]
        public bool CollateralSwitch { get; set; }
        /// <summary>
        /// ["<c>collateralRatio</c>"] Collateral ratio
        /// </summary>
        [JsonPropertyName("collateralRatio")]
        public decimal CollateralRatio { get; set; }
        /// <summary>
        /// ["<c>borrowUsageRate</c>"] Borrow usage rate
        /// </summary>
        [JsonPropertyName("borrowUsageRate")]
        public decimal? BorrowUsageRate { get; set; }
    }
}
