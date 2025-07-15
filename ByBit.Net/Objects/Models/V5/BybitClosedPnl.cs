using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Closed profit and loss info
    /// </summary>
    [SerializationModel]
    public record BybitClosedPnl
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Order side
        /// </summary>

        [JsonPropertyName("side")]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Order quantity
        /// </summary>
        [JsonPropertyName("qty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Order price
        /// </summary>
        [JsonPropertyName("orderPrice")]
        public decimal OrderPrice { get; set; }
        /// <summary>
        /// Order type
        /// </summary>

        [JsonPropertyName("orderType")]
        public OrderType OrderType { get; set; }
        /// <summary>
        /// Trade type
        /// </summary>
        [JsonPropertyName("execType")]

        public TradeType TradeType { get; set; }
        /// <summary>
        /// Closed size
        /// </summary>
        [JsonPropertyName("closedSize")]
        public decimal ClosedSize { get; set; }
        /// <summary>
        /// Cumulated entry position value
        /// </summary>
        [JsonPropertyName("cumEntryValue")]
        public decimal EntryValue { get; set; }
        /// <summary>
        /// Average entry price
        /// </summary>
        [JsonPropertyName("avgEntryPrice")]
        public decimal AverageEntryPrice { get; set; }
        /// <summary>
        /// Cumulated exit position value
        /// </summary>
        [JsonPropertyName("cumExitValue")]
        public decimal ExitValue { get; set; }
        /// <summary>
        /// Average exit price
        /// </summary>
        [JsonPropertyName("avgExitPrice")]
        public decimal AverageExitPrice { get; set; }
        /// <summary>
        /// Close PnL
        /// </summary>
        [JsonPropertyName("closedPnl")]
        public decimal ClosedPnl { get; set; }
        /// <summary>
        /// Number of fills
        /// </summary>
        [JsonPropertyName("fillCount")]
        public int FillCount { get; set; }
        /// <summary>
        /// Leverage
        /// </summary>
        [JsonPropertyName("leverage")]
        public decimal Leverage { get; set; }
        /// <summary>
        /// Created time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonPropertyName("createdTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Updated time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonPropertyName("updatedTime")]
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// Open fee
        /// </summary>
        [JsonPropertyName("openFee")]
        public decimal? OpenFee { get; set; }
        /// <summary>
        /// Close fee
        /// </summary>
        [JsonPropertyName("closeFee")]
        public decimal? CloseFee { get; set; }
    }
}
