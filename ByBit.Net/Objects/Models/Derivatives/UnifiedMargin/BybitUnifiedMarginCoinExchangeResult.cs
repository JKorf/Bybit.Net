using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Derivatives.UnifiedMargin
{
    /// <summary>
    /// Coin exchange result
    /// </summary>
    public class BybitUnifiedMarginCoinExchangeResult
    {
        /// <summary>
        /// Exchange transaction id
        /// </summary>
        [JsonProperty("exchangeTxId")]
        public string ID { get; set; } = string.Empty;

        /// <summary>
        /// From coin
        /// </summary>
        [JsonProperty("fromCoin")]
        public string FromAsset { get; set; } = string.Empty;

        /// <summary>
        /// From amount
        /// </summary>
        public decimal FromAmount { get; set; }

        /// <summary>
        /// From coin
        /// </summary>
        [JsonProperty("toCoin")]
        public string ToAsset { get; set; } = string.Empty;

        /// <summary>
        /// From amount
        /// </summary>
        public decimal ToAmount { get; set; }

        /// <summary>
        /// Create time
        /// </summary>
        [JsonProperty("createdAt"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Exchange rate
        /// </summary>
        public decimal ExchangeRate { get; set; }
    }
}
