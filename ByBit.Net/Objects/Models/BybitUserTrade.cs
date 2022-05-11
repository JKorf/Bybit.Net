using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// User trade info
    /// </summary>
    public class BybitUserTrade
    {
        /// <summary>
        /// The corresponding closing size of the closing order
        /// </summary>
        [JsonProperty("closed_size")]
        public decimal ClosedQuantity { get; set; }
        /// <summary>
        /// Cross sequence
        /// </summary>
        [JsonProperty("cross_seq")]
        public long CrossSequence { get; set; }
        /// <summary>
        /// Transaction fee
        /// </summary>
        [JsonProperty("exec_fee")]
        public decimal Fee { get; set; }
        /// <summary>
        /// Trade id
        /// </summary>
        [JsonProperty("exec_id")]
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// Price
        /// </summary>
        [JsonProperty("exec_price")]
        public decimal Price { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonProperty("exec_qty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Trade type
        /// </summary>
        [JsonProperty("exec_type"), JsonConverter(typeof(TradeTypeConverter))]
        public TradeType Type { get; set; }
        /// <summary>
        /// Value of trade
        /// </summary>
        [JsonProperty("exec_value")]
        public decimal Value { get; set; }
        /// <summary>
        /// Maker or taker fee rate
        /// </summary>
        [JsonProperty("fee_rate")]
        public decimal FeeRate { get; set; }
        /// <summary>
        /// Liquiditry, only valid while Type is Trade, AdlTrade, BustTrade
        /// </summary>
        [JsonProperty("last_liquidity_ind"), JsonConverter(typeof(TradeLiquidityConverter))]
        public TradeLiquidity Liquidity { get; set; }
        /// <summary>
        /// Remaining quantity
        /// </summary>
        [JsonProperty("leaves_qty")]
        public decimal QuantityRemaining { get; set; }
        /// <summary>
        /// The sequence of the transaction in this cross sequence data package
        /// </summary>
        [JsonProperty("nth_fill")]
        public decimal FillNumber { get; set; }
        /// <summary>
        /// Order id
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonProperty("order_link_id")]
        public string ClientOrderId { get; set; } = string.Empty;
        /// <summary>
        /// Price of the order
        /// </summary>
        [JsonProperty("order_price")]
        public decimal OrderPrice { get; set; }
        /// <summary>
        /// Quantity of the order
        /// </summary>
        [JsonProperty("order_qty")]
        public decimal OrderQuantity { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Type of the order
        /// </summary>
        [JsonProperty("order_type"), JsonConverter(typeof(OrderTypeConverter))]
        public OrderType? OrderType { get; set; }
        /// <summary>
        /// Side of the order
        /// </summary>
        [JsonProperty("side"), JsonConverter(typeof(OrderSideConverter))]
        public OrderSide OrderSide { get; set; }
        /// <summary>
        /// User id
        /// </summary>
        [JsonProperty("user_id")]
        public long UserId { get; set; }
        /// <summary>
        /// Trade time
        /// </summary>
        [JsonProperty("trade_time_ms"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
