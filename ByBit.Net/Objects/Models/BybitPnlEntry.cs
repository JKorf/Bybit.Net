using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Profit and loss entry
    /// </summary>
    public class BybitPnlEntry
    {
        /// <summary>
        /// Position id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// User id
        /// </summary>
        [JsonProperty("user_id")]
        public long UserId { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Order id
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Order side
        /// </summary>
        [JsonConverter(typeof(OrderSideConverter))]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Order quantity
        /// </summary>
        [JsonProperty("qty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Order price
        /// </summary>
        [JsonProperty("order_price")]
        public decimal OrderPrice { get; set; }
        /// <summary>
        /// Order type
        /// </summary>
        [JsonProperty("order_type")]
        [JsonConverter(typeof(OrderTypeConverter))]
        public OrderType OrderType { get; set; }
        /// <summary>
        /// Trade type
        /// </summary>
        [JsonProperty("exec_type")]
        [JsonConverter(typeof(TradeTypeConverter))]
        public TradeType Type { get; set; }
        /// <summary>
        /// The corresponding closing size of the closing order
        /// </summary>
        [JsonProperty("closed_size")]
        public decimal ClosedQuantity { get; set; }
        /// <summary>
        /// Closed position value
        /// </summary>
        [JsonProperty("cum_entry_value")]
        public decimal TotalEntryValue { get; set; }
        /// <summary>
        /// Average entry price
        /// </summary>
        [JsonProperty("avg_entry_price")]
        public decimal AverageEntryPrice { get; set; }
        /// <summary>
        /// Cumulative trading value of position closing orders
        /// </summary>
        [JsonProperty("cum_exit_value")]
        public decimal TotalExitValue { get; set; }
        /// <summary>
        /// Average exit price
        /// </summary>
        [JsonProperty("avg_exit_price")]
        public decimal AverageExitPrice { get; set; }
        /// <summary>
        /// Closed Profit and Loss
        /// </summary>
        [JsonProperty("closed_pnl")]
        public decimal ClosedPnl { get; set; }
        /// <summary>
        /// The number of fills in a single order
        /// </summary>
        [JsonProperty("fill_count")]
        public int Fills { get; set; }
        /// <summary>
        /// In Isolated Margin mode, the value is set by user. In Cross Margin mode, the value is the max leverage at current risk level
        /// </summary>
        public decimal Leverage { get; set; }
        /// <summary>
        /// Creation time
        /// </summary>
        [JsonProperty("created_at")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
    }
}
