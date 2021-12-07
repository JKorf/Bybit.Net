using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Kline info
    /// </summary>
    public class BybitIndexPriceKline : BybitKlineBase
    {
        /// <summary>
        /// Open time
        /// </summary>
        [JsonProperty("open_time"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime OpenTime { get; set; }

        /// <summary>
        /// Data recording period
        /// </summary>
        [JsonConverter(typeof(KlineIntervalConverter))]
        public KlineInterval Period { get; set; }

    }
}
