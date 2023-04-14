using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Trade info
    /// </summary>
    public class BybitTrade
    {
        /// <summary>
        /// Trade timestamp
        /// </summary>
        [JsonProperty("T")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("s")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Side
        /// </summary>
        [JsonProperty("S")]
        [JsonConverter(typeof(EnumConverter))]
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
        /// Direction
        /// </summary>
        [JsonProperty("L")]
        [JsonConverter(typeof(EnumConverter))]
        public TickDirection? Direction { get; set; }
        /// <summary>
        /// Trade id
        /// </summary>
        [JsonProperty("i")]
        public string TradeId { get; set; } = string.Empty;
        /// <summary>
        /// Is block trade
        /// </summary>
        [JsonProperty("BT")]
        public bool? IsBlockTrade { get; set; }
    }
}
