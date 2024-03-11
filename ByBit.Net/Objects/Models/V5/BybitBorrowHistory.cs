﻿using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Borrow history info
    /// </summary>
    public class BybitBorrowHistory
    {
        /// <summary>
        /// Asset
        /// </summary>
        [JsonProperty("currency")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Created time
        /// </summary>
        [JsonProperty("createdTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Interest
        /// </summary>
        public decimal BorrowCost { get; set; }
        /// <summary>
        /// Houly borrow rate
        /// </summary>
        public decimal HourlyBorrowRate { get; set; }
        /// <summary>
        /// Interest Bearing Borrow Size
        /// </summary>
        public decimal InterestBearingBorrowSize { get; set; }
        /// <summary>
        /// Cost exemption
        /// </summary>
        public decimal CostExcemption { get; set; }
        /// <summary>
        /// Total borrow quantity
        /// </summary>
        [JsonProperty("borrowAmount")]
        public decimal BorrowQuantity { get; set; }
        /// <summary>
        /// Unrealized loss
        /// </summary>
        [JsonProperty("unrealisedLoss")]
        public decimal UnrealisedLoss { get; set; }
        /// <summary>
        /// The borrowed quantity for interest free
        /// </summary>
        [JsonProperty("freeBorrowedAmount")]
        public decimal FreeBorrowedQuantity { get; set; }
    }
}
