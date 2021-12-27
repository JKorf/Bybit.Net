using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Socket.Spot
{
    /// <summary>
    /// Ticker info
    /// </summary>
    public class BybitSpotTickerUpdate
    {
        /// <summary>
        /// Timestamp of the data
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("t")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("s")]
        public string Symbol { get; set; } = string.Empty;
        private decimal _changePercentage;
        /// <summary>
        /// Change percentage compared to 24 hours ago
        /// </summary>
        [JsonProperty("m")]
        public decimal ChangePercentage
        {
            get => _changePercentage * 100;
            set => _changePercentage = value;
        }
        /// <summary>
        /// Volume
        /// </summary>
        [JsonProperty("v")]
        public decimal Volume { get; set; }
        /// <summary>
        /// Quote volume
        /// </summary>
        [JsonProperty("qv")]
        public decimal QuoteVolume { get; set; }
        /// <summary>
        /// Last trade price
        /// </summary>
        [JsonProperty("c")]
        public decimal LastPrice { get; set; }
        /// <summary>
        /// 24 hour high price
        /// </summary>
        [JsonProperty("h")]
        public decimal HighPrice { get; set; }
        /// <summary>
        /// 24 hour low price
        /// </summary>
        [JsonProperty("l")]
        public decimal LowPrice { get; set; }
        /// <summary>
        /// Price 24 hours ago
        /// </summary>
        [JsonProperty("o")]
        public decimal OpenPrice { get; set; }
    }
}
