using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Spot ticker update
    /// </summary>
    public class BybitSpotTickerUpdate
    {
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Last price
        /// </summary>
        public decimal LastPrice { get; set; }
        /// <summary>
        /// High price in last 24h
        /// </summary>
        public decimal HighPrice24h { get; set; }
        /// <summary>
        /// Low price in last 24h
        /// </summary>
        public decimal LowPrice24h { get; set; }
        /// <summary>
        /// Previous price in last 24h
        /// </summary>
        [JsonProperty("prevPrice24h")]
        public decimal PreviousPrice24h { get; set; }
        /// <summary>
        /// Volume last 24h
        /// </summary>
        public decimal Volume24h { get; set; }
        /// <summary>
        /// Turnover last 24h
        /// </summary>
        public decimal Turnover24h { get; set; }
        /// <summary>
        /// Price change percentage since 24h ago
        /// </summary>
        [JsonProperty("price24hPcnt")]
        public decimal PricePercentage24h { get; set; }
        /// <summary>
        /// Usd index price
        /// </summary>
        public decimal? UsdIndexPrice { get; set; }
    }
}
