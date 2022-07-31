using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.CopyTrading
{
    /// <summary>
    /// Position info
    /// </summary>
    public class BybitCopyTradingPosition
    {
        /// <summary>
        /// The symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Side
        /// </summary>
        [JsonConverter(typeof(OrderSideConverter))]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Position quantity
        /// </summary>
        [JsonProperty("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Average entry price
        /// </summary>
        public decimal EntryPrice { get; set; }
        /// <summary>
        /// Position value
        /// </summary>
        public decimal PositionValue { get; set; }
        /// <summary>
        /// Liquidation price
        /// </summary>
        [JsonProperty("liqPrice")]
        public decimal LiquidationPrice { get; set; }
        /// <summary>
        /// Bankruptcy price
        /// </summary>
        public decimal BustPrice { get; set; }
        /// <summary>
        /// Mark price
        /// </summary>
        public decimal MarkPrice { get; set; }
        /// <summary>
        /// Leverage
        /// </summary>
        public decimal Leverage { get; set; }
        /// <summary>
        /// Is isolated margin mode
        /// </summary>
        public bool IsIsolated { get; set; }
        /// <summary>
        /// Position margin
        /// </summary>
        public decimal PositionMargin { get; set; }
        /// <summary>
        /// Position closing fee occupied (your opening fee + expected maximum closing fee)
        /// </summary>
        public decimal OccClosingFee { get; set; }
        /// <summary>
        /// Pre-occupied funding fee: calculated from position qty and current funding fee
        /// </summary>
        public decimal OccFundingFee { get; set; }
        /// <summary>
        /// Accumulated realised pnl (all-time total)
        /// </summary>
        public decimal CumRealisedPnl { get; set; }
        /// <summary>
        /// Quantity which can be closed
        /// </summary>
        [JsonProperty("freeQty")]
        public decimal FreeQuantity { get; set; }
        /// <summary>
        /// Unrealized profit and loss
        /// </summary>
        public decimal UnrealisedPnl { get; set; }
        /// <summary>
        /// Position mode
        /// </summary>
        [JsonProperty("positionIdx")]
        [JsonConverter(typeof(PositionModeConverter))]
        public PositionMode PositionMode { get; set; }
        /// <summary>
        /// Creation time
        /// </summary>
        [JsonProperty("createdTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Last update time
        /// </summary>
        [JsonProperty("updatedTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime UpdateTime { get; set; }
    }
}
