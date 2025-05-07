using Bybit.Net.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Spread ticker update
    /// </summary>
    public record BybitSpreadTickerUpdate
    {
        /// <summary>
        /// Symbol name
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Best bid price
        /// </summary>
        [JsonPropertyName("bidPrice")]
        public decimal? BestBidPrice { get; set; }
        /// <summary>
        /// Best bid price
        /// </summary>
        [JsonPropertyName("bidSize")]
        public decimal? BestBidQuantity { get; set; }
        /// <summary>
        /// Best bid price
        /// </summary>
        [JsonPropertyName("askPrice")]
        public decimal? BestAskPrice { get; set; }
        /// <summary>
        /// Best bid price
        /// </summary>
        [JsonPropertyName("askSize")]
        public decimal? BestAskQuantity { get; set; }
        /// <summary>
        /// Last trade price
        /// </summary>
        [JsonPropertyName("lastPrice")]
        public decimal? LastPrice { get; set; }
        /// <summary>
        /// 24h High price
        /// </summary>
        [JsonPropertyName("highPrice24h")]
        public decimal? HighPrice { get; set; }
        /// <summary>
        /// 24h Low price
        /// </summary>
        [JsonPropertyName("lowPrice24h")]
        public decimal? LowPrice { get; set; }
        /// <summary>
        /// 24h Open price
        /// </summary>
        [JsonPropertyName("prevPrice24h")]
        public decimal? OpenPrice { get; set; }
        /// <summary>
        /// 24h Volume
        /// </summary>
        [JsonPropertyName("volume24h")]
        public decimal Volume { get; set; }
    }
}
