using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Order data
    /// </summary>
    public abstract class BybitOrderBase
    {
        /// <summary>
        /// Id
        /// </summary>
        public abstract string Id { get; set; }
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
        /// The estimated value corresponding to the number of remaining orders
        /// </summary>
        [JsonProperty("leaves_value")]
        public decimal? LeavesValue { get; set; }
        /// <summary>
        /// Number of unfilled contracts from the order's size
        /// </summary>
        [JsonProperty("leaves_qty")]
        public decimal? LeavesQuantity { get; set; }
        /// <summary>
        /// Creation time
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime? CreateTime { get; set; }
        [JsonProperty("created_time"), JsonConverter(typeof(DateTimeConverter))]
        internal DateTime? _createTime { get => CreateTime; set => CreateTime = value; }
        [JsonProperty("create_time"), JsonConverter(typeof(DateTimeConverter))]
        internal DateTime? _createTime2 { get => CreateTime; set => CreateTime = value; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdateTime { get; set; }
        [JsonProperty("updated_time"), JsonConverter(typeof(DateTimeConverter))]
        internal DateTime? _updateTime { get => UpdateTime; set => UpdateTime = value; }
        [JsonProperty("update_time"), JsonConverter(typeof(DateTimeConverter))]
        internal DateTime? _updateTime2 { get => UpdateTime; set => UpdateTime = value; }
        /// <summary>
        /// Trigger scenario for cancel operation
        /// </summary>
        [JsonProperty("cancel_type")]
        public string? CancelType { get; set; }
    }
}
