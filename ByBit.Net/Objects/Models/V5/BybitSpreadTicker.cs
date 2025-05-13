using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Spread ticker info
    /// </summary>
    public record BybitSpreadTicker
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Bid price
        /// </summary>
        [JsonPropertyName("bidPrice")]
        public decimal? BidPrice { get; set; }
        /// <summary>
        /// Bid quantity
        /// </summary>
        [JsonPropertyName("bidSize")]
        public decimal? BidQuantity { get; set; }
        /// <summary>
        /// Ask price
        /// </summary>
        [JsonPropertyName("askPrice")]
        public decimal? AskPrice { get; set; }
        /// <summary>
        /// Ask quantity
        /// </summary>
        [JsonPropertyName("askSize")]
        public decimal? AskQuantity { get; set; }
        /// <summary>
        /// Last price
        /// </summary>
        [JsonPropertyName("lastPrice")]
        public decimal LastPrice { get; set; }
        /// <summary>
        /// High price24h
        /// </summary>
        [JsonPropertyName("highPrice24h")]
        public decimal HighPrice24h { get; set; }
        /// <summary>
        /// Low price24h
        /// </summary>
        [JsonPropertyName("lowPrice24h")]
        public decimal LowPrice24h { get; set; }
        /// <summary>
        /// Prev price24h
        /// </summary>
        [JsonPropertyName("prevPrice24h")]
        public decimal PrevPrice24h { get; set; }
        /// <summary>
        /// Volume24h
        /// </summary>
        [JsonPropertyName("volume24h")]
        public decimal Volume24h { get; set; }
    }


}
