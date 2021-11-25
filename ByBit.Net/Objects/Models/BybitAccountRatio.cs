using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Long/short account ratio
    /// </summary>
    public class BybitAccountRatio
    {
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Buy ratio
        /// </summary>
        [JsonProperty("buy_ratio")]
        public decimal BuyRatio { get; set; }
        /// <summary>
        /// Sell ratio
        /// </summary>
        [JsonProperty("sell_ratio")]
        public decimal SellRatio { get; set; }
        /// <summary>
        /// Data timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
