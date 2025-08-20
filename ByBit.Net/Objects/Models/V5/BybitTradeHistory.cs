using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Trade history info
    /// </summary>
    [SerializationModel]
    public record BybitTradeHistory
    {
        /// <summary>
        /// Trade id
        /// </summary>
        [JsonPropertyName("execId")]
        public string TradeId { get; set; } = string.Empty;
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Price of the trade
        /// </summary>
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        /// <summary>
        /// Quantity of the trade
        /// </summary>
        [JsonPropertyName("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Side
        /// </summary>
        [JsonPropertyName("side")]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Trade timestamp
        /// </summary>
        [JsonPropertyName("time")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Is block trade
        /// </summary>
        [JsonPropertyName("isBlockTrade")]
        public bool IsBlockTrade { get; set; }
        /// <summary>
        /// Is Retail Price Improvement trade
        /// </summary>
        [JsonPropertyName("isRPITrade")]
        public bool? IsRpiTrade { get; set; }
        /// <summary>
        /// [Option only] Mark price
        /// </summary>
        [JsonPropertyName("mP")]
        public decimal? MarkPrice { get; set; }
        /// <summary>
        /// [Option only] Index price
        /// </summary>
        [JsonPropertyName("iP")]
        public decimal? IndexPrice { get; set; }
        /// <summary>
        /// [Option only] Mark iv
        /// </summary>
        [JsonPropertyName("mIv")]
        public decimal? MarkIv { get; set; }
        /// <summary>
        /// [Option only] Index iv
        /// </summary>
        [JsonPropertyName("iv")]
        public decimal? IndexIv { get; set; }
        /// <summary>
        /// Cross sequence
        /// </summary>
        [JsonPropertyName("seq")]
        public long? Sequence { get; set; }
    }
}
