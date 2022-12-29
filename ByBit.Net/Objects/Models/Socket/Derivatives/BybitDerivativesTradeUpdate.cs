using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Socket.Derivatives
{
    /// <summary>
    /// Trade update
    /// </summary>
    public class BybitDerivativesTradeUpdate
    {
        /// <summary>
        /// Update timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("ts")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// The time that the order is filled
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("T")]
        public DateTime TradeTime { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("s")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Side
        /// </summary>
        [JsonConverter(typeof(OrderSideConverter))]
        [JsonProperty("S")]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonProperty("v")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        [JsonProperty("p")]
        public decimal Price { get; set; }
        /// <summary>
        /// Tick direction
        /// </summary>
        [JsonConverter(typeof(TickDirectionConverter))]
        [JsonProperty("L")]
        public TickDirection TickDirection { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty("i")]
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// Tick direction
        /// </summary>
        [JsonConverter(typeof(BoolConverter))]
        [JsonProperty("BT")]
        public bool IsBlockTrade { get; set; }
    }
}
