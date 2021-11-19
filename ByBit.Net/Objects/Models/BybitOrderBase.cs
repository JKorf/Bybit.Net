using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Order data
    /// </summary>
    public class BybitOrderBase
    {
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
        /// Order side
        /// </summary>
        [JsonConverter(typeof(OrderSideConverter))]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Order type
        /// </summary>
        [JsonProperty("order_type"), JsonConverter(typeof(OrderTypeConverter))]
        public OrderType Type { get; set; }
        /// <summary>
        /// Order price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Order quantity
        /// </summary>
        [JsonProperty("qty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Time in force
        /// </summary>
        [JsonProperty("time_in_force"), JsonConverter(typeof(TimeInForceConverter))]
        public TimeInForce TimeInForce { get; set; }
        /// <summary>
        /// Order status
        /// </summary>
        [JsonProperty("order_status"), JsonConverter(typeof(OrderStatusConverter))]
        public OrderStatus? Status { get; set; }
        /// <summary>
        /// The estimated value corresponding to the number of remaining orders
        /// </summary>
        [JsonProperty("leaves_value")]
        public decimal? LeavesValue { get; set; }
        /// <summary>
        /// Number of unfilled contracts from the order's size
        /// </summary>
        [JsonProperty("leaves_qty")]
        public decimal LeavesQuantity { get; set; }
        /// <summary>
        /// Creation time
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// Trigger scenario for cancel operation
        /// </summary>
        [JsonProperty("cancel_type")]
        public string? CancelType { get; set; }
    }
}
