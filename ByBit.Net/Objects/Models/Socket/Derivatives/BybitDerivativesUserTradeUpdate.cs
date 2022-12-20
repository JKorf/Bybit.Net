using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Socket.Derivatives
{
    /// <summary>
    /// Base class for user trade updates
    /// </summary>
    public class BybitDerivativesUserTradeUpdate
    {
        /// <summary>
        /// Order id
        /// </summary>
        [JsonProperty("orderId")]
        public string OrderId { get; set; } = string.Empty;

        /// <summary>
        /// Trading id
        /// </summary>
        [JsonProperty("execId")]
        public string TradingId { get; set; } = string.Empty;

        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// Order type
        /// </summary>
        [JsonConverter(typeof(OrderTypeConverter))]
        public OrderType OrderType { get; set; }

        /// <summary>
        /// Trading volume
        /// </summary>
        [JsonProperty("execQty")]
        public decimal? AccumulativeTradingVolume { get; set; }

        /// <summary>
        /// Trading value
        /// </summary>
        [JsonProperty("execValue")]
        public decimal? TradingValue { get; set; }

        /// <summary>
        /// Trading fee
        /// </summary>
        [JsonProperty("execFee")]
        public decimal? TradingFee { get; set; }

        /// <summary>
        /// Trading price
        /// </summary>
        [JsonProperty("execPrice")]
        public decimal? TradingPrice { get; set; }

        /// <summary>
        /// Fee rate
        /// </summary>
        public decimal? FeeRate { get; set; }

        /// <summary>
        /// Client order id
        /// </summary>
        [JsonProperty("orderLinkId")]
        public string? ClientOrderId { get; set; }

        /// <summary>
        /// Order price
        /// </summary>
        public decimal OrderPrice { get; set; }

        /// <summary>
        /// Order quantity
        /// </summary>
        [JsonProperty("orderQty")]
        public decimal OrderQuantity { get; set; }

        /// <summary>
        /// Order side
        /// </summary>
        [JsonConverter(typeof(OrderSideConverter))]
        public OrderSide Side { get; set; }

        /// <summary>
        /// Time of trade
        /// </summary>
        [JsonProperty("execTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime? TradingTime { get; set; }

        /// <summary>
        /// Conditional order type
        /// </summary>
        [JsonProperty("stopOrderType"), JsonConverter(typeof(StopOrderTypeConverter))]
        public StopOrderType? ConditionalOrderType { get; set; }

        /// <summary>
        /// Trade type
        /// </summary>
        [JsonProperty("execType"), JsonConverter(typeof(TradeTypeConverter))]
        public TradeType TradeType { get; set; }

        /// <summary>
        /// Liquidity type enum, only valid when the exec_type field type is Trade, AdlTrade, or BustTrade.
        /// </summary>
        [JsonProperty("lastLiquidityInd"), JsonConverter(typeof(EnumConverter))]
        public LiquidityType LiquidityType { get; set; }

        /// <summary>
        /// Remaining order quantity
        /// </summary>
        [JsonProperty("leavesQty")]
        public decimal RemainingOrderQuantity { get; set; }
    }
}
