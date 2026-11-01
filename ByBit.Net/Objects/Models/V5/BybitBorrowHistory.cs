using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Borrow history info
    /// </summary>
    [SerializationModel]
    public record BybitBorrowHistory
    {
        /// <summary>
        /// ["<c>currency</c>"] Asset
        /// </summary>
        [JsonPropertyName("currency")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>createdTime</c>"] Created time
        /// </summary>
        [JsonPropertyName("createdTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// ["<c>borrowCost</c>"] Interest
        /// </summary>
        [JsonPropertyName("borrowCost")]
        public decimal BorrowCost { get; set; }
        /// <summary>
        /// ["<c>hourlyBorrowRate</c>"] Hourly borrow rate
        /// </summary>
        [JsonPropertyName("hourlyBorrowRate")]
        public decimal HourlyBorrowRate { get; set; }
        /// <summary>
        /// ["<c>interestBearingBorrowSize</c>"] Interest Bearing Borrow Size
        /// </summary>
        [JsonPropertyName("interestBearingBorrowSize")]
        public decimal InterestBearingBorrowSize { get; set; }
        [JsonInclude, JsonPropertyName("InterestBearingBorrowSize")]
        internal decimal InterestBearingBorrowSizeInt
        {
            get => InterestBearingBorrowSize;
            set => InterestBearingBorrowSize = value;
        }

        /// <summary>
        /// ["<c>costExemption</c>"] Cost exemption
        /// </summary>
        [JsonPropertyName("costExemption")]
        public decimal CostExemption { get; set; }
        /// <summary>
        /// ["<c>borrowAmount</c>"] Total borrow quantity
        /// </summary>
        [JsonPropertyName("borrowAmount")]
        public decimal BorrowQuantity { get; set; }
        /// <summary>
        /// ["<c>unrealisedLoss</c>"] Unrealized loss
        /// </summary>
        [JsonPropertyName("unrealisedLoss")]
        public decimal? UnrealisedLoss { get; set; }
        /// <summary>
        /// ["<c>freeBorrowedAmount</c>"] The borrowed quantity for interest free
        /// </summary>
        [JsonPropertyName("freeBorrowedAmount")]
        public decimal? FreeBorrowedQuantity { get; set; }
    }
}
