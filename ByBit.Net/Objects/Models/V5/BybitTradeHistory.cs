using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Trade history info
    /// </summary>
    public record BybitTradeHistory
    {
        /// <summary>
        /// Trade id
        /// </summary>
        [JsonProperty("execId")]
        public string TradeId { get; set; } = string.Empty;
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Price of the trade
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Quantity of the trade
        /// </summary>
        [JsonProperty("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Side
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Trade timestamp
        /// </summary>
        [JsonProperty("time")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsBlockTrade { get; set; }
        /// <summary>
        /// [Option only] Mark price
        /// </summary>
        [JsonProperty("mP")]
        public decimal? MarkPrice { get; set; }
        /// <summary>
        /// [Option only] Index price
        /// </summary>
        [JsonProperty("iP")]
        public decimal? IndexPrice { get; set; }
        /// <summary>
        /// [Option only] Mark iv
        /// </summary>
        [JsonProperty("mIv")]
        public decimal? MarkIv { get; set; }
        /// <summary>
        /// [Option only] Index iv
        /// </summary>
        [JsonProperty("iv")]
        public decimal? IndexIv { get; set; }
    }
}
