using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Options trade
    /// </summary>
    public record BybitOptionTrade : BybitTrade
    {
        /// <summary>
        /// Mark price
        /// </summary>
        [JsonProperty("mP")]
        public decimal MarkPrice { get; set; }
        /// <summary>
        /// Index price
        /// </summary>
        [JsonProperty("iP")]
        public decimal IndexPrice { get; set; }
        /// <summary>
        /// Mark iv
        /// </summary>
        [JsonProperty("mIv")]
        public decimal MarkIv { get; set; }
        /// <summary>
        /// Index iv
        /// </summary>
        [JsonProperty("iv")]
        public decimal IndexIv { get; set; }
    }
}
