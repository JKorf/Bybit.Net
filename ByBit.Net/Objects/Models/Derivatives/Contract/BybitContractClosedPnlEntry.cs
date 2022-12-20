using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Derivatives.Contract
{
    /// <summary>
    /// Profit and loss entry
    /// </summary>
    public class BybitContractClosedPnlEntry
    {
        /// <summary>
        /// Order ID of the closing order
        /// </summary>
        public string OrderId { get; set; } = string.Empty;

        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// Order side
        /// </summary>
        [JsonConverter(typeof(OrderSideConverter))]
        public OrderSide Side { get; set; }

        /// <summary>
        /// Order qty
        /// </summary>
        [JsonProperty("qty")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Order price
        /// </summary>
        public decimal OrderPrice { get; set; }

        /// <summary>
        /// Order type
        /// </summary>
        [JsonConverter(typeof(OrderTypeConverter))]
        public OrderType OrderType { get; set; }

        /// <summary>
        /// Closed size
        /// </summary>
        public decimal ClosedSize { get; set; }

        /// <summary>
        /// Closed position value
        /// </summary>
        [JsonProperty("cumEntryValue")]
        public decimal ClosedPositionValue { get; set; }

        /// <summary>
        /// Average entry price
        /// </summary>
        [JsonProperty("avgEntryPrice")]
        public decimal AverageEntryPrice { get; set; }

        /// <summary>
        /// Cumulative trading value of position closing orders
        /// </summary>
        [JsonProperty("cumExitValue")]
        public decimal CumulativeTradingValue { get; set; }

        /// <summary>
        /// Average exit price
        /// </summary>
        [JsonProperty("avgExitPrice")]
        public decimal AverageExitPrice { get; set; }

        /// <summary>
        /// Closed Profit and Loss
        /// </summary>
        public decimal ClosedPnl { get; set; }

        /// <summary>
        /// The number of fills in a single order
        /// </summary>
        public int FillCount { get; set; }

        /// <summary>
        /// In Isolated Margin mode, the value is set by the user. In Cross Margin mode, the value is the max leverage at current risk level
        /// </summary>
        public decimal Leverage { get; set; }

        /// <summary>
        /// Trade type
        /// </summary>
        [JsonProperty("execType"), JsonConverter(typeof(TradeTypeConverter))]
        public TradeType TradeType { get; set; }

        /// <summary>
        /// Creation time (when the order_status was Created)
        /// </summary>
        [JsonProperty("createdAt"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreatedDate { get; set; }
    }
}