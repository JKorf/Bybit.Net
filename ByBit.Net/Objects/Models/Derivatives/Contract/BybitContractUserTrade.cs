using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Derivatives.Contract
{
    /// <summary>
    /// User trade info
    /// </summary>
    public class BybitContractUserTrade
    {
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Transaction fee
        /// </summary>
        [JsonProperty("execFee")]
        public decimal Fee { get; set; }
        /// <summary>
        /// Trade id
        /// </summary>
        [JsonProperty("execId")]
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// Price
        /// </summary>
        [JsonProperty("execPrice")]
        public decimal Price { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonProperty("execQty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Trade type
        /// </summary>
        [JsonProperty("execType"), JsonConverter(typeof(TradeTypeConverter))]
        public TradeType Type { get; set; }
        /// <summary>
        /// Value of trade
        /// </summary>
        [JsonProperty("execValue")]
        public decimal Value { get; set; }
        /// <summary>
        /// Maker or taker fee rate
        /// </summary>
        [JsonProperty("feeRate")]
        public decimal FeeRate { get; set; }
        /// <summary>
        /// Liquiditry, only valid while Type is Trade, AdlTrade, BustTrade
        /// </summary>
        [JsonProperty("lastLiquidityInd"), JsonConverter(typeof(TradeLiquidityConverter))]
        public TradeLiquidity Liquidity { get; set; }
        /// <summary>
        /// Remaining quantity
        /// </summary>
        [JsonProperty("leavesQty")]
        public decimal QuantityRemaining { get; set; }
        /// <summary>
        /// Order id
        /// </summary>
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonProperty("orderLinkId")]
        public string ClientOrderId { get; set; } = string.Empty;
        /// <summary>
        /// Price of the order
        /// </summary>
        public decimal OrderPrice { get; set; }
        /// <summary>
        /// Quantity of the order
        /// </summary>
        [JsonProperty("orderQty")]
        public decimal OrderQuantity { get; set; }
        /// <summary>
        /// Type of the order
        /// </summary>
        [JsonConverter(typeof(OrderTypeConverter))]
        public OrderType? OrderType { get; set; }
        /// <summary>
        /// Conditional order type
        /// </summary>
        [JsonConverter(typeof(StopOrderTypeConverter))]
        public StopOrderType StopOrderType { get; set; }
        /// <summary>
        /// Side of the order
        /// </summary>
        [JsonProperty("side"), JsonConverter(typeof(OrderSideConverter))]
        public OrderSide OrderSide { get; set; }
        /// <summary>
        /// Trade time
        /// </summary>
        [JsonProperty("execTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime ExecuteTime { get; set; }
        /// <summary>
        /// The corresponding closing size of the closing order
        /// </summary>
        [JsonProperty("closedSize")]
        public decimal ClosedQuantity { get; set; }
    }
}
