using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Leveraged token nav info
    /// </summary>
    public record BybitLeveragedTokenNav
    {
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("time")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Net asset value
        /// </summary>
        public decimal Nav { get; set; }
        /// <summary>
        /// Basket position
        /// </summary>
        public decimal BasketPosition { get; set; }
        /// <summary>
        /// Leverage
        /// </summary>
        public decimal Leverage { get; set; }
        /// <summary>
        /// Basket loan
        /// </summary>
        public decimal BasketLoan { get; set; }
        /// <summary>
        /// Circulation
        /// </summary>
        public decimal Circulation { get; set; }
        /// <summary>
        /// Basket
        /// </summary>
        public decimal Basket { get; set; }
    }
}
