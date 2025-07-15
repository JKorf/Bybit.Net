using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// User trade info
    /// </summary>
    [SerializationModel]
    public record BybitUserTrade
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Order id trade belongs to
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Client order id trade belongs to
        /// </summary>
        [JsonPropertyName("orderLinkId")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Side
        /// </summary>
        [JsonPropertyName("side")]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Order price
        /// </summary>
        [JsonPropertyName("orderPrice")]
        public decimal? OrderPrice { get; set; }
        /// <summary>
        /// Order quantity
        /// </summary>
        [JsonPropertyName("orderQty")]
        public decimal? OrderQuantity { get; set; }
        /// <summary>
        /// Remaining order quantity
        /// </summary>
        [JsonPropertyName("leavesQty")]
        public decimal? QuantityRemaining { get; set; }
        /// <summary>
        /// Order type
        /// </summary>
        [JsonPropertyName("orderType")]
        public OrderType? OrderType { get; set; }
        /// <summary>
        /// Stop order type
        /// </summary>
        [JsonPropertyName("stopOrderType")]
        public StopOrderType? StopOrderType { get; set; }
        /// <summary>
        /// Fee paid
        /// </summary>
        [JsonPropertyName("execFee")]
        public decimal? Fee { get; set; }
        /// <summary>
        /// Spot leg transaction fee, only works for execType=FutureSpread
        /// </summary>
        [JsonPropertyName("execFeeV2")]
        public decimal? FeeV2 { get; set; }
        /// <summary>
        /// Trade id
        /// </summary>
        [JsonPropertyName("execId")]
        public string TradeId { get; set; } = string.Empty;
        /// <summary>
        /// Trade price
        /// </summary>
        [JsonPropertyName("execPrice")]
        public decimal Price { get; set; }
        /// <summary>
        /// Trade quantity
        /// </summary>
        [JsonPropertyName("execQty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Trade value
        /// </summary>
        [JsonPropertyName("execValue")]
        public decimal? Value { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonPropertyName("execTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Trade type
        /// </summary>
        [JsonPropertyName("execType")]
        public TradeType? TradeType { get; set; }
        /// <summary>
        /// Is maker
        /// </summary>
        [JsonPropertyName("isMaker")]
        public bool IsMaker { get; set; }
        /// <summary>
        /// Whether to borrow. Unified spot only
        /// </summary>
        [JsonPropertyName("isLeverage")]
        public bool? IsLeverage { get; set; }
        /// <summary>
        /// Spot trading fee asset
        /// </summary>
        [JsonPropertyName("feeCurrency")]
        public string? FeeAsset { get; set; }
        /// <summary>
        /// Fee rate
        /// </summary>
        [JsonPropertyName("feeRate")]
        public decimal? FeeRate { get; set; }
        /// <summary>
        /// [Options] Implied volatility
        /// </summary>
        [JsonPropertyName("tradeIv")]
        public decimal? TradeIv { get; set; }
        /// <summary>
        /// [Options] Implied volatility of mark price
        /// </summary>
        [JsonPropertyName("markIv")]
        public decimal? MarkIv { get; set; }
        /// <summary>
        /// Mark price
        /// </summary>
        [JsonPropertyName("markPrice")]
        public decimal? MarkPrice { get; set; }
        /// <summary>
        /// [Options] Index price
        /// </summary>
        [JsonPropertyName("indexPrice")]
        public decimal? IndexPrice { get; set; }
        /// <summary>
        /// [Options] Underlying price
        /// </summary>
        [JsonPropertyName("underlyingPrice")]
        public decimal? UnderlyingPrice { get; set; }
        /// <summary>
        /// Block trade id
        /// </summary>
        [JsonPropertyName("blockTradeId")]
        public string BlockTradeId { get; set; } = string.Empty;
        /// <summary>
        /// Closed position size
        /// </summary>
        [JsonPropertyName("closedSize")]
        public decimal? ClosedQuantity { get; set; }
        /// <summary>
        /// Cross sequence, used to associate each fill and each position update
        /// </summary>
        [JsonPropertyName("seq")]
        public long? Sequence { get; set; }
    }
}
