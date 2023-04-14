using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Leveraged token info
    /// </summary>
    public class BybitLeveragedTokenTicker
    {
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Price 24h change percentage
        /// </summary>
        [JsonProperty("price24hPcnt")]
        public decimal Price24hPercentage { get; set; }
        /// <summary>
        /// Last trade price
        /// </summary>
        public decimal LastPrice { get; set; }
        /// <summary>
        /// Price 24h ago
        /// </summary>
        [JsonProperty("prevPrice24h")]
        public decimal PreviousPrice24h { get; set; }
        /// <summary>
        /// High price
        /// </summary>
        public decimal HighPrice24h { get; set; }
        /// <summary>
        /// Low price
        /// </summary>
        public decimal LowPrice24h { get; set; }
    }
}
