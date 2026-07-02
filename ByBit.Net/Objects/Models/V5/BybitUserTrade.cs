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
        /// ["<c>symbol</c>"] Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>orderId</c>"] Order id trade belongs to
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>orderLinkId</c>"] Client order id trade belongs to
        /// </summary>
        [JsonPropertyName("orderLinkId")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// ["<c>side</c>"] Side
        /// </summary>
        [JsonPropertyName("side")]
        public OrderSide Side { get; set; }
        /// <summary>
        /// ["<c>orderPrice</c>"] Order price
        /// </summary>
        [JsonPropertyName("orderPrice")]
        public decimal? OrderPrice { get; set; }
        /// <summary>
        /// ["<c>orderQty</c>"] Order quantity
        /// </summary>
        [JsonPropertyName("orderQty")]
        public decimal? OrderQuantity { get; set; }
        /// <summary>
        /// ["<c>leavesQty</c>"] Remaining order quantity
        /// </summary>
        [JsonPropertyName("leavesQty")]
        public decimal? QuantityRemaining { get; set; }
        /// <summary>
        /// ["<c>orderType</c>"] Order type
        /// </summary>
        [JsonPropertyName("orderType")]
        public OrderType? OrderType { get; set; }
        /// <summary>
        /// ["<c>stopOrderType</c>"] Stop order type
        /// </summary>
        [JsonPropertyName("stopOrderType")]
        public StopOrderType? StopOrderType { get; set; }
        /// <summary>
        /// ["<c>execFee</c>"] Fee paid
        /// </summary>
        [JsonPropertyName("execFee")]
        public decimal? Fee { get; set; }
        /// <summary>
        /// ["<c>execFeeV2</c>"] Spot leg transaction fee, only works for execType=FutureSpread
        /// </summary>
        [JsonPropertyName("execFeeV2")]
        public decimal? FeeV2 { get; set; }
        /// <summary>
        /// ["<c>execId</c>"] Trade id
        /// </summary>
        [JsonPropertyName("execId")]
        public string TradeId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>execPrice</c>"] Trade price
        /// </summary>
        [JsonPropertyName("execPrice")]
        public decimal Price { get; set; }
        /// <summary>
        /// ["<c>execQty</c>"] Trade quantity
        /// </summary>
        [JsonPropertyName("execQty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// ["<c>execValue</c>"] Trade value
        /// </summary>
        [JsonPropertyName("execValue")]
        public decimal? Value { get; set; }
        /// <summary>
        /// ["<c>execTime</c>"] Timestamp
        /// </summary>
        [JsonPropertyName("execTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// ["<c>execType</c>"] Trade type
        /// </summary>
        [JsonPropertyName("execType")]
        public TradeType? TradeType { get; set; }
        /// <summary>
        /// ["<c>isMaker</c>"] Is maker
        /// </summary>
        [JsonPropertyName("isMaker")]
        public bool IsMaker { get; set; }
        /// <summary>
        /// ["<c>isLeverage</c>"] Whether to borrow. Unified spot only
        /// </summary>
        [JsonPropertyName("isLeverage")]
        public bool? IsLeverage { get; set; }
        /// <summary>
        /// ["<c>feeCurrency</c>"] Spot trading fee asset
        /// </summary>
        [JsonPropertyName("feeCurrency")]
        public string? FeeAsset { get; set; }
        /// <summary>
        /// ["<c>feeRate</c>"] Fee rate
        /// </summary>
        [JsonPropertyName("feeRate")]
        public decimal? FeeRate { get; set; }
        /// <summary>
        /// ["<c>tradeIv</c>"] [Options] Implied volatility
        /// </summary>
        [JsonPropertyName("tradeIv")]
        public decimal? TradeIv { get; set; }
        /// <summary>
        /// ["<c>markIv</c>"] [Options] Implied volatility of mark price
        /// </summary>
        [JsonPropertyName("markIv")]
        public decimal? MarkIv { get; set; }
        /// <summary>
        /// ["<c>markPrice</c>"] Mark price
        /// </summary>
        [JsonPropertyName("markPrice")]
        public decimal? MarkPrice { get; set; }
        /// <summary>
        /// ["<c>indexPrice</c>"] [Options] Index price
        /// </summary>
        [JsonPropertyName("indexPrice")]
        public decimal? IndexPrice { get; set; }
        /// <summary>
        /// ["<c>underlyingPrice</c>"] [Options] Underlying price
        /// </summary>
        [JsonPropertyName("underlyingPrice")]
        public decimal? UnderlyingPrice { get; set; }
        /// <summary>
        /// ["<c>blockTradeId</c>"] Block trade id
        /// </summary>
        [JsonPropertyName("blockTradeId")]
        public string BlockTradeId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>closedSize</c>"] Closed position size
        /// </summary>
        [JsonPropertyName("closedSize")]
        public decimal? ClosedQuantity { get; set; }
        /// <summary>
        /// ["<c>seq</c>"] Cross sequence, used to associate each fill and each position update
        /// </summary>
        [JsonPropertyName("seq")]
        public long? Sequence { get; set; }
        /// <summary>
        /// ["<c>marketUnit</c>"] Market unit
        /// </summary>
        [JsonPropertyName("marketUnit")]
        public MarketUnit MarketUnit { get; set; }
    }
}
