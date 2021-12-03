using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Socket.Spot
{
    /// <summary>
    /// Kline data update
    /// </summary>
    public class BybitSpotKlineUpdate
    {
        /// <summary>
        /// Candle open time
        /// </summary>
        [JsonProperty("t"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime OpenTime { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("s")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Symbol name
        /// </summary>
        [JsonProperty("sn")]
        public string SymbolName { get; set; } = string.Empty;
        /// <summary>
        /// Open price
        /// </summary>
        [JsonProperty("o")]
        public decimal OpenPrice { get; set; }
        /// <summary>
        /// High price
        /// </summary>
        [JsonProperty("h")]
        public decimal HighPrice { get; set; }
        /// <summary>
        /// Low price
        /// </summary>
        [JsonProperty("l")]
        public decimal LowPrice { get; set; }
        /// <summary>
        /// Close price
        /// </summary>
        [JsonProperty("c")]
        public decimal ClosePrice { get; set; }
        /// <summary>
        /// Volume
        /// </summary>
        [JsonProperty("v")]
        public decimal Volume { get; set; }        
    }
}
