using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// User trade info
    /// </summary>
    public class BybitUserTrade
    {
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Order id trade belongs to
        /// </summary>
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Client order id trade belongs to
        /// </summary>
        [JsonProperty("orderLinkId")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Side
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Order price
        /// </summary>
        public decimal? OrderPrice { get; set; }
        /// <summary>
        /// Order quantity
        /// </summary>
        [JsonProperty("orderQty")]
        public decimal? OrderQuantity { get; set; }
        /// <summary>
        /// Remaining order quantity
        /// </summary>
        [JsonProperty("leavesQty")]
        public decimal? QuantityRemaining { get; set; }
        /// <summary>
        /// Order type
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public OrderType? OrderType { get; set; }
        /// <summary>
        /// Stop order type
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public StopOrderType? StopOrderType { get; set; }
        /// <summary>
        /// Fee paid
        /// </summary>
        [JsonProperty("execFee")]
        public decimal? Fee { get; set; }
        /// <summary>
        /// Trade id
        /// </summary>
        [JsonProperty("execId")]
        public string TradeId { get; set; } = string.Empty;
        /// <summary>
        /// Trade price
        /// </summary>
        [JsonProperty("execPrice")]
        public decimal Price { get; set; }
        /// <summary>
        /// Trade quantity
        /// </summary>
        [JsonProperty("execQty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Trade value
        /// </summary>
        [JsonProperty("execValue")]
        public decimal? Value { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("execTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Trade type
        /// </summary>
        [JsonProperty("execType")]
        [JsonConverter(typeof(EnumConverter))]
        public TradeType? TradeType { get; set; }
        /// <summary>
        /// Is maker
        /// </summary>
        public bool IsMaker { get; set; }
        /// <summary>
        /// Spot trading fee asset
        /// </summary>
        [JsonProperty("feeCurrency")]
        public string? FeeAsset { get; set; }
        /// <summary>
        /// Fee rate
        /// </summary>
        public decimal? FeeRate { get; set; }
        /// <summary>
        /// [Options] Implied volatility
        /// </summary>
        public decimal? TradeIv { get; set; }
        /// <summary>
        /// [Options] Implied volatility of mark price
        /// </summary>
        public decimal? MarkIv { get; set; }
        /// <summary>
        /// Mark price
        /// </summary>
        public decimal? MarkPrice { get; set; }
        /// <summary>
        /// [Options] Index price
        /// </summary>
        public decimal? IndexPrice { get; set; }
        /// <summary>
        /// [Options] Underlying price
        /// </summary>
        public decimal? UnderlyingPrice { get; set; }
        /// <summary>
        /// Block trade id
        /// </summary>
        public string BlockTradeId { get; set; } = string.Empty;
        /// <summary>
        /// Closed position size
        /// </summary>
        [JsonProperty("closedSize")]
        public decimal? ClosedQuantity { get; set; }
        /// <summary>
        /// Cross sequence, used to associate each fill and each position update
        /// </summary>
        [JsonProperty("seq")]
        public long? Sequence { get; set; }
    }
}
