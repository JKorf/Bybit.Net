﻿using Bybit.Net.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// User order update
    /// </summary>
    public record BybitOrderUpdate : BybitOrder
    {
        /// <summary>
        /// Closed profit and loss for a close position order.
        /// </summary>
        [JsonPropertyName("closedPnl")]
        public decimal? ClosedPnl { get; set; }

        /// <summary>
        /// Category
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        [JsonPropertyName("category")]
        public Category Category { get; set; }
    }
}
