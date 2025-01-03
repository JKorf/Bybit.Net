﻿using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Trade info
    /// </summary>
    public record BybitTrade
    {
        /// <summary>
        /// Trade timestamp
        /// </summary>
        [JsonPropertyName("T")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("s")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Side
        /// </summary>
        [JsonPropertyName("S")]
        [JsonConverter(typeof(EnumConverter))]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonPropertyName("v")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        [JsonPropertyName("p")]
        public decimal Price { get; set; }
        /// <summary>
        /// Direction
        /// </summary>
        [JsonPropertyName("L")]
        [JsonConverter(typeof(EnumConverter))]
        public TickDirection? Direction { get; set; }
        /// <summary>
        /// Trade id
        /// </summary>
        [JsonPropertyName("i")]
        public string TradeId { get; set; } = string.Empty;
        /// <summary>
        /// Is block trade
        /// </summary>
        [JsonPropertyName("BT")]
        public bool? IsBlockTrade { get; set; }
    }
}
