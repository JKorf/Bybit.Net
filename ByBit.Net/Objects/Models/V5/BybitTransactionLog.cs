﻿using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Transaction info
    /// </summary>
    public record BybitTransactionLog
    {
        /// <summary>
        /// Unique id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Product
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        [JsonPropertyName("category")]
        public Category Category { get; set; }
        /// <summary>
        /// Side
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        [JsonPropertyName("side")]
        public PositionSide Side { get; set; }
        /// <summary>
        /// Transaction time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonPropertyName("transactionTime")]
        public DateTime TransactionTime { get; set; }
        /// <summary>
        /// Type
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        [JsonPropertyName("type")]
        public TransactionLogType Type { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonPropertyName("qty")]
        public decimal? Quantity { get; set; }
        /// <summary>
        /// Size
        /// </summary>
        [JsonPropertyName("size")]
        public decimal? Size { get; set; }
        /// <summary>
        /// Asset
        /// </summary>
        [JsonPropertyName("currency")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Trade price
        /// </summary>
        [JsonPropertyName("tradePrice")]
        public decimal? TradePrice { get; set; }
        /// <summary>
        /// Funding fee
        /// </summary>
        [JsonPropertyName("funding")]
        public decimal? Funding { get; set; }
        /// <summary>
        /// Trading fee
        /// </summary>
        [JsonPropertyName("fee")]
        public decimal? Fee { get; set; }
        /// <summary>
        /// Cash flow
        /// </summary>
        [JsonPropertyName("cashFlow")]
        public decimal? Cashflow { get; set; }
        /// <summary>
        /// Change
        /// </summary>
        [JsonPropertyName("change")]
        public decimal? Change { get; set; }
        /// <summary>
        /// Cash balance
        /// </summary>
        [JsonPropertyName("cashBalance")]
        public decimal? CashBalance { get; set; }
        /// <summary>
        /// Fee rate
        /// </summary>
        [JsonPropertyName("feeRate")]
        public decimal? FeeRate { get; set; }
        /// <summary>
        /// Bonus change
        /// </summary>
        [JsonPropertyName("bonusChange")]
        public decimal? BonusChange { get; set; }
        /// <summary>
        /// Trade id
        /// </summary>
        [JsonPropertyName("tradeId")]
        public string? TradeId { get; set; }
        /// <summary>
        /// Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string? OrderId { get; set; }
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonPropertyName("orderLinkId")]
        public string? ClientOrderId { get; set; }
    }
}
