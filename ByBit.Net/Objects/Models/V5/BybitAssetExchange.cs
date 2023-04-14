using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    internal class BybitAssetExchageWrapper : BybitBaseResponse
    {
        public IEnumerable<BybitAssetExchange> OrderBody { get; set; } = Array.Empty<BybitAssetExchange>();
    }

    /// <summary>
    /// Asset exchange info
    /// </summary>
    public class BybitAssetExchange
    {
        /// <summary>
        /// From asset
        /// </summary>
        [JsonProperty("fromCoin")]
        public string FromAsset { get; set; } = string.Empty;
        /// <summary>
        /// To asset
        /// </summary>
        [JsonProperty("toCoin")]
        public string ToAsset { get; set; } = string.Empty;
        /// <summary>
        /// From quantity
        /// </summary>
        [JsonProperty("fromAmount")]
        public decimal FromQuantity { get; set; }
        /// <summary>
        /// To quantity
        /// </summary>
        [JsonProperty("toAmount")]
        public decimal ToQuantity { get; set; }
        /// <summary>
        /// Exchange rate
        /// </summary>
        public decimal ExchangeRate { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("createdTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty("exchangeTxId")]
        public string ExchangeTransactionId { get; set; } = string.Empty;
    }
}
