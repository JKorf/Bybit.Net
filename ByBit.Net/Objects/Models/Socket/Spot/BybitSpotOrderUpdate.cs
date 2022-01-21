using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Socket.Spot
{
    /// <summary>
    /// Spot order update
    /// </summary>
    public class BybitSpotOrderUpdate: BybitSocketEvent
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
        [JsonProperty("X"), JsonConverter(typeof(OrderStatusSpotConverter))]
        public OrderStatus Status { get; set; }
        /// <summary>
        /// Order id
        /// </summary>
        [JsonProperty("i")]
        public long OrderId { get; set; }
        /// <summary>
        /// Match order id
        /// </summary>
        [JsonProperty("M")]
        public long MatchOrderId { get; set; }
        /// <summary>
        /// Last filled quantity
        /// </summary>
        [JsonProperty("l")]
        public decimal LastFilledQuantity { get; set; }
        /// <summary>
        /// Total filled quantity
        /// </summary>
        [JsonProperty("z")]
        public decimal TotalQuantityFilled { get; set; }
        /// <summary>
        /// Price of last filled quantity
        /// </summary>
        [JsonProperty("L")]
        public decimal LastTradePrice { get; set; }
        /// <summary>
        /// Fee
        /// </summary>
        [JsonProperty("n")]
        public decimal Fee { get; set; }
        /// <summary>
        /// Fee asset
        /// </summary>
        [JsonProperty("N")]
        public string FeeAsset { get; set; } = string.Empty;
        /// <summary>
        /// Is normal
        /// </summary>
        [JsonProperty("u")]
        public bool IsNormal { get; set; }
        /// <summary>
        /// Is working
        /// </summary>
        [JsonProperty("w")]
        public bool IsWorking { get; set; }
        /// <summary>
        /// Is limit maker
        /// </summary>
        [JsonProperty("m")]
        public bool IsLimitMaker { get; set; }
        /// <summary>
        /// Creation time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("O")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Total value filled
        /// </summary>
        [JsonProperty("Z")]
        public decimal TotalValueFilled { get; set; }
        /// <summary>
        /// Match account id
        /// </summary>
        [JsonProperty("A")]
        public long MatchAccountId { get; set; }
        /// <summary>
        /// Is closed
        /// </summary>
        [JsonProperty("C")]
        public bool IsClosed { get; set; }
        /// <summary>
        /// Leverage
        /// </summary>
        [JsonProperty("v")]
        public decimal Leverage { get; set; }
    }
}
