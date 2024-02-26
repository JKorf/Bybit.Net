using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Transaction info
    /// </summary>
    public class BybitTransactionLog
    {
        /// <summary>
        /// Unique id
        /// </summary>
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Product
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public Category Category { get; set; }
        /// <summary>
        /// Side
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public PositionSide Side { get; set; }
        /// <summary>
        /// Transaction time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime TransactionTime { get; set; }
        /// <summary>
        /// Type
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public TransactionLogType Type { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonProperty("qty")]
        public decimal? Quantity { get; set; }
        /// <summary>
        /// Size
        /// </summary>
        public decimal? Size { get; set; }
        /// <summary>
        /// Asset
        /// </summary>
        [JsonProperty("currency")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Trade price
        /// </summary>
        public decimal? TradePrice { get; set; }
        /// <summary>
        /// Funding fee
        /// </summary>
        public decimal? Funding { get; set; }
        /// <summary>
        /// Trading fee
        /// </summary>
        public decimal? Fee { get; set; }
        /// <summary>
        /// Cash flow
        /// </summary>
        public decimal? Cashflow { get; set; }
        /// <summary>
        /// Change
        /// </summary>
        public decimal? Change { get; set; }
        /// <summary>
        /// Cash balance
        /// </summary>
        public decimal? CashBalance { get; set; }
        /// <summary>
        /// Fee rate
        /// </summary>
        public decimal? FeeRate { get; set; }
        /// <summary>
        /// Bonus change
        /// </summary>
        public decimal? BonusChange { get; set; }
        /// <summary>
        /// Trade id
        /// </summary>
        public string? TradeId { get; set; }
        /// <summary>
        /// Order id
        /// </summary>
        public string? OrderId { get; set; }
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonProperty("orderLinkId")]
        public string? ClientOrderId { get; set; }
    }
}
