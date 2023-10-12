using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Leverage token market info
    /// </summary>
    public class BybitLeverageTokenMarket
    {
        /// <summary>
        /// Basket
        /// </summary>
        [JsonProperty("basket")]
        public decimal Basket { get; set; }
        /// <summary>
        /// Circulating supply in the secondary market
        /// </summary>
        [JsonProperty("circulation")]
        public decimal Circulation { get; set; }
        /// <summary>
        /// Real leverage calculated by last traded price
        /// </summary>
        [JsonProperty("leverage")]
        public decimal Leverage { get; set; }
        /// <summary>
        /// Net value
        /// </summary>
        [JsonProperty("nav")]
        public decimal Nav { get; set; }
        /// <summary>
        /// Update time for net asset value
        /// </summary>
        [JsonProperty("navTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime NavTime { get; set; }
        /// <summary>
        /// Token name
        /// </summary>
        [JsonProperty("ltCoin")]
        public string Token { get; set; } = string.Empty;
    }
}
