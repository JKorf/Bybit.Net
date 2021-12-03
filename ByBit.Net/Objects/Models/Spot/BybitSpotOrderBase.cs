using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Objects.Models.Spot
{
    /// <summary>
    /// Spot order info
    /// </summary>
    public class BybitSpotOrderBase
    {
        /// <summary>
        /// Order id
        /// </summary>
        [JsonProperty("orderId")]
        public long Id { get; set; }
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonProperty("orderLinkId")]
        public string ClientOrderId { get; set; } = string.Empty;
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonProperty("origQty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Type
        /// </summary>
        [JsonConverter(typeof(OrderTypeSpotConverter))]
        public OrderType Type { get; set; }
        /// <summary>
        /// Side
        /// </summary>
        [JsonConverter(typeof(OrderSideConverter))]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        [JsonConverter(typeof(OrderStatusSpotConverter))]
        public OrderStatus Status { get; set; }
        /// <summary>
        /// Time in force
        /// </summary>
        [JsonConverter(typeof(TimeInForceSpotConverter))]
        public TimeInForce TimeInForce { get; set; }
        /// <summary>
        /// Account id
        /// </summary>
        public long AccountId { get; set; }
        /// <summary>
        /// Symbol name
        /// </summary>
        public string SymbolName { get; set; } = string.Empty;
    }
}
