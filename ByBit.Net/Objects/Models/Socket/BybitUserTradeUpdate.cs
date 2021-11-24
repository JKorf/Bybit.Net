using Bybit.Net.Enums;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Socket
{
    /// <summary>
    /// User trade info
    /// </summary>
    public class BybitUserTradeUpdate
    {
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Side
        /// </summary>
        public OrderSide Side { get; set; }
        /// <summary>
        /// The order id the trade was for
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// The trade id 
        /// </summary>
        [JsonProperty("exec_id")]
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// The client order id the trade was for
        /// </summary>
        [JsonProperty("order_link_id")]
        public string ClientOrderId { get; set; } = string.Empty;
        /// <summary>
        /// The trade price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Quantity of the order the trade was for
        /// </summary>
        [JsonProperty("order_qty")]
        public decimal OrderQuantity { get; set; }
        /// <summary>
        /// The traded quantity
        /// </summary>
        [JsonProperty("exec_qty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Trade type
        /// </summary>
        [JsonProperty("exec_type")]
        public TradeType Type { get; set; }
        /// <summary>
        /// Fee paid for the trade
        /// </summary>
        [JsonProperty("exec_fee")]
        public decimal Fee { get; set; }
        /// <summary>
        /// Remaining quantity in order
        /// </summary>
        [JsonProperty("leaves_qty")]
        public decimal QuantityRemaining { get; set; }
        /// <summary>
        /// Is maker
        /// </summary>
        [JsonProperty("is_maker")]
        public bool IsMaker { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("trade_time")]
        public DateTime TradeTime { get; set; }
    }
}
