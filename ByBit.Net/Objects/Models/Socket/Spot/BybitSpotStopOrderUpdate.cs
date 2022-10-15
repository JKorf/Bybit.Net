using System;
using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.Socket.Spot
{
    /// <summary>
    /// Spot order update
    /// </summary>
    public class BybitSpotStopOrderUpdate : BybitSocketEvent
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("s")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonProperty("c")]
        public string ClientOrderId { get; set; } = string.Empty;
        /// <summary>
        /// Order side
        /// </summary>
        [JsonProperty("S"), JsonConverter(typeof(OrderSideConverter))]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Order type
        /// </summary>
        [JsonProperty("o"), JsonConverter(typeof(OrderTypeSpotConverter))]
        public OrderType Type { get; set; }
        /// <summary>
        /// Time in force
        /// </summary>
        [JsonProperty("f"), JsonConverter(typeof(TimeInForceSpotConverter))]
        public TimeInForce TimeInForce { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonProperty("q")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        [JsonProperty("p")]
        public decimal Price { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        [JsonProperty("X"), JsonConverter(typeof(EnumConverter))]
        public OrderStatus Status { get; set; }
        /// <summary>
        /// Order id
        /// </summary>
        [JsonProperty("i")]
        public string OrderId { get; set; } = string.Empty;

        /// <summary>
        /// Creation time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("T")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Triggered time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("t")]
        public DateTime TriggeredTime { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("C")]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// The market price when place the order
        /// </summary>
        [JsonProperty("qp")]
        public string MarketPrice { get; set; } = string.Empty;
        /// <summary>
        /// The new order id after the tp/sl order is triggered.
        /// </summary>
        [JsonProperty("eo")]
        public string NewOrderId { get; set; } = string.Empty;
    }
}
