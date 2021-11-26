using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Socket
{
    /// <summary>
    /// Trade update
    /// </summary>
    public class BybitTradeUpdate
    {
        /// <summary>
        /// Update timestamp
        /// </summary>
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Trade time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("trade_time_ms")]
        public DateTime TradeTime { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Side
        /// </summary>
        [JsonConverter(typeof(OrderSideConverter))]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonProperty("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Tick direction
        /// </summary>
        [JsonConverter(typeof(TickDirectionConverter))]
        [JsonProperty("tick_direction")]
        public TickDirection TickDirection { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty("trade_id")]
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// Cross sequence
        /// </summary>
        [JsonProperty("cross_seq")]
        public long? CrossSequence { get; set; }
    }
}
