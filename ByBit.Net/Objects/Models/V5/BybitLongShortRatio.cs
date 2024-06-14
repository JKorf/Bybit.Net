using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Long/short ratio
    /// </summary>
    public record BybitLongShortRatio
    {
        /// <summary>
        /// Symbol name
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// The ratio of users with net long position
        /// </summary>
        [JsonProperty("buyRatio")]
        public decimal BuyRatio { get; set; }
        /// <summary>
        /// The ratio of users with net short position
        /// </summary>
        [JsonProperty("sellRatio")]
        public decimal SellRatio { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("timestamp"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
