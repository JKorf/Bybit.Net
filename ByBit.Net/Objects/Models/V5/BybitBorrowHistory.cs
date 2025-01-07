using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Borrow history info
    /// </summary>
    public record BybitBorrowHistory
    {
        /// <summary>
        /// Asset
        /// </summary>
        [JsonPropertyName("currency")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Created time
        /// </summary>
        [JsonPropertyName("createdTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Interest
        /// </summary>
        [JsonPropertyName("borrowCost")]
        public decimal BorrowCost { get; set; }
        /// <summary>
        /// Houly borrow rate
        /// </summary>
        [JsonPropertyName("hourlyBorrowRate")]
        public decimal HourlyBorrowRate { get; set; }
        /// <summary>
        /// Interest Bearing Borrow Size
        /// </summary>
        [JsonPropertyName("interestBearingBorrowSize")]
        public decimal InterestBearingBorrowSize { get; set; }
        [JsonInclude, JsonPropertyName("InterestBearingBorrowSize")]
        private decimal InterestBearingBorrowSizeInt
        {
            set => InterestBearingBorrowSize = value;
        }

        /// <summary>
        /// Cost exemption
        /// </summary>
        [JsonPropertyName("costExemption")]
        public decimal CostExemption { get; set; }
        /// <summary>
        /// Total borrow quantity
        /// </summary>
        [JsonPropertyName("borrowAmount")]
        public decimal BorrowQuantity { get; set; }
        /// <summary>
        /// Unrealized loss
        /// </summary>
        [JsonPropertyName("unrealisedLoss")]
        public decimal UnrealisedLoss { get; set; }
        /// <summary>
        /// The borrowed quantity for interest free
        /// </summary>
        [JsonPropertyName("freeBorrowedAmount")]
        public decimal FreeBorrowedQuantity { get; set; }
    }
}
