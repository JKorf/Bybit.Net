using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Derivatives.UnifiedMargin
{
    /// <summary>
    /// Profit and loss entry
    /// </summary>
    public class BybitUnifiedMarginPnlEntry
    {
        /// <summary>
        /// Trading id
        /// </summary>
        [JsonProperty("execId")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// Order id
        /// </summary>
        public string OrderId { get; set; } = string.Empty;

        /// <summary>
        /// Block trade id
        /// </summary>
        public string BlockTradeId { get; set; } = string.Empty;

        /// <summary>
        /// Order link id
        /// </summary>
        [JsonProperty("orderLinkId")]
        public string ClientOrderId { get; set; } = string.Empty;

        /// <summary>
        /// Order side
        /// </summary>
        [JsonConverter(typeof(OrderSideConverter))]
        public OrderSide Side { get; set; }

        /// <summary>
        /// Order quantity
        /// </summary>
        [JsonProperty("orderQty")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Remaining order quantity
        /// </summary>
        [JsonProperty("leavesQty")]
        public decimal RemainingQuantity { get; set; }

        /// <summary>
        /// Order price
        /// </summary>
        public decimal OrderPrice { get; set; }

        /// <summary>
        /// Fee rate
        /// </summary>
        public decimal FeeRate { get; set; }

        /// <summary>
        /// Order type
        /// </summary>
        [JsonConverter(typeof(OrderTypeConverter))]
        public OrderType OrderType { get; set; }

        /// <summary>
        /// Trade type
        /// </summary>
        [JsonProperty("execType")]
        [JsonConverter(typeof(TradeTypeConverter))]
        public TradeType Type { get; set; }

        /// <summary>
        /// Conditional order type
        /// </summary>
        [JsonProperty("stopOrderType")]
        public StopOrderType ConditionalOrderType { get; set; }

        /// <summary>
        /// Liquidity type enum, only valid when the exec_type field type is Trade, AdlTrade, or BustTrade.
        /// </summary>
        [JsonProperty("lastLiquidityInd")]
        public LiquidityType LiquidityType { get; set; }

        /// <summary>
        /// Executed quantity
        /// </summary>
        [JsonProperty("execQty")]
        public decimal ExecutedQuantity { get; set; }

        /// <summary>
        /// Executed price
        /// </summary>
        [JsonProperty("execPrice")]
        public decimal ExecutedPrice { get; set; }

        /// <summary>
        /// Executed value
        /// </summary>
        [JsonProperty("execValue")]
        public decimal ExecutedValue { get; set; }

        /// <summary>
        /// Executed fee
        /// </summary>
        [JsonProperty("execFee")]
        public decimal ExecutedFee { get; set; }

        /// <summary>
        /// Time of trade
        /// </summary>
        [JsonProperty("execTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime TradeTime { get; set; }

        /// <summary>
        /// Closed position value
        /// </summary>
        [JsonProperty("cum_entry_value")]
        public decimal TotalEntryValue { get; set; }
        /// <summary>
        /// Average entry price
        /// </summary>
        [JsonProperty("avg_entry_price")]
        public decimal AverageEntryPrice { get; set; }
        /// <summary>
        /// Cumulative trading value of position closing orders
        /// </summary>
        [JsonProperty("cum_exit_value")]
        public decimal TotalExitValue { get; set; }
        /// <summary>
        /// Average exit price
        /// </summary>
        [JsonProperty("avg_exit_price")]
        public decimal AverageExitPrice { get; set; }
        /// <summary>
        /// Closed Profit and Loss
        /// </summary>
        [JsonProperty("closed_pnl")]
        public decimal ClosedPnl { get; set; }
        /// <summary>
        /// The number of fills in a single order
        /// </summary>
        [JsonProperty("fill_count")]
        public int Fills { get; set; }
        /// <summary>
        /// In Isolated Margin mode, the value is set by user. In Cross Margin mode, the value is the max leverage at current risk level
        /// </summary>
        public decimal Leverage { get; set; }

    }
}
