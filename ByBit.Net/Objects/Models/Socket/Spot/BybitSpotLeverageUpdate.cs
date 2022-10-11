using System;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.Socket.Spot
{
    /// <summary>
    /// Leverage Token Net value update
    /// </summary>
    public class BybitSpotLeverageUpdate
    {
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("t")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        /// <remarks> Please make sure to add "NAV" as a suffix to the name of the pair you're querying </remarks>
        [JsonProperty("s")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Net asset value
        /// </summary>
        [JsonProperty("nav")]
        public decimal NetAssetValue { get; set; }
        /// <summary>
        /// Basket value
        /// </summary>
        [JsonProperty("b")]
        public decimal BasketValue { get; set; }
        /// <summary>
        /// Real Leverage calculated by last traded price.
        /// </summary>
        [JsonProperty("l")]
        public decimal RealLeverage { get; set; }
        /// <summary>
        /// Basket loan
        /// </summary>
        [JsonProperty("loan")]
        public decimal BasketLoan { get; set; }
        /// <summary>
        /// Circulating supply in the secondary market
        /// </summary>
        [JsonProperty("ti")]
        public decimal CirculatingSupply { get; set; }
        /// <summary>
        /// Total position value = basket value * total circulation
        /// </summary>
        [JsonProperty("n")]
        public decimal TotalPositionValue { get; set; }
    }
}