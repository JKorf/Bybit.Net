using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using Bybit.Net.Converters;
using Bybit.Net.Enums;

namespace Bybit.Net.Objects.Models.Spot.v3
{
    /// <summary>
    /// Spot order info
    /// </summary>
    public class BybitSpotOrderV3
    {
        /// <summary>
        /// Account id
        /// </summary>
        [JsonProperty("accountId")]
        public string AccountId { get; set; } = string.Empty;

        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// Client order id
        /// </summary>
        [JsonProperty("orderLinkId")]
        public string? ClientOrderId { get; set; }

        /// <summary>
        /// Order id
        /// </summary>
        [JsonProperty("orderId")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Order price
        /// </summary>
        [JsonProperty("orderPrice")]
        public decimal Price { get; set; }

        /// <summary>
        /// Order quantity
        /// </summary>
        [JsonProperty("orderQty")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Quantity filled
        /// </summary>
        [JsonProperty("execQty")]
        public decimal QuantityFilled { get; set; }

        /// <summary>
        /// Value of the order
        /// </summary>
        [JsonProperty("cummulativeQuoteQty")]
        public decimal QuoteQuantity { get; set; }

        /// <summary>
        /// Average fill price
        /// </summary>
        [JsonProperty("avgPrice")]
        public decimal AveragePrice { get; set; }

        /// <summary>
        /// Order status
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(OrderStatusSpotConverter))]
        public OrderStatus Status { get; set; }

        /// <summary>
        /// Time in force
        /// </summary>
        [JsonProperty("timeInForce")]
        [JsonConverter(typeof(TimeInForceSpotConverter))]
        public TimeInForce TimeInForce { get; set; }

        /// <summary>
        /// Order type
        /// </summary>
        [JsonProperty("orderType")]
        [JsonConverter(typeof(OrderTypeSpotConverter))]
        public OrderType Type { get; set; }

        /// <summary>
        /// Order side
        /// </summary>
        [JsonProperty("side")]
        [JsonConverter(typeof(OrderSideConverter))]
        public OrderSide Side { get; set; }

        /// <summary>
        /// Stop price
        /// </summary>
        [JsonProperty("stopPrice")]
        public decimal StopPrice { get; set; }

        /// <summary>
        /// Iceberg quantity
        /// </summary>
        [JsonProperty("icebergQty")]
        public decimal IcebergQuantity { get; set; }

        /// <summary>
        /// Create time
        /// </summary>
        [JsonProperty("createTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Update time
        /// </summary>
        [JsonProperty("updateTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// Is working
        /// </summary>
        [JsonProperty("isWorking"), JsonConverter(typeof(BoolConverter))]
        public bool IsWorking { get; set; }

        /// <summary>
        /// Quantity reserved for order
        /// </summary>
        [JsonProperty("locked")]
        public decimal Locked { get; set; }

        /// <summary>
        /// Block trade id
        /// </summary>
        [JsonProperty("blockTradeId")]
        public string BlockTradeId { get; set; } = string.Empty;

        /// <summary>
        /// Cancel type
        /// </summary>
        [JsonProperty("cancelType"), JsonConverter(typeof(EnumConverter))]
        public CancelType? CancelType { get; set; }

        /// <summary>
        /// Self match prevention type
        /// </summary>
        [JsonProperty("smpType"), JsonConverter(typeof(EnumConverter))]
        public SelfMatchPreventionType? SelfMatchPreventionType { get; set; }
        /// <summary>
        /// Self match prevention group, 0 by default
        /// </summary>
        [JsonProperty("smpGroup")]
        public int? SelfMatchPreventionGroup { get; set; }
        /// <summary>
        /// The counterparty's orderID which triggers this SMP execution
        /// </summary>
        [JsonProperty("smpOrderId")]
        public string? SelfMatchPreventionOrderId { get; set; }
        /// <summary>
        /// Trigger price
        /// </summary>
        [JsonProperty("triggerPrice")]
        public decimal? TriggerPrice { get; set; }
    }
}
