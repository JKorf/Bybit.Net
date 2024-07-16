using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Convert quote
    /// </summary>
    public record BybitConvertQuote
    {
        /// <summary>
        /// Quote transaction id
        /// </summary>
        [JsonProperty("quoteTxId")]
        public string QuoteTransactionId { get; set; } = string.Empty;
        /// <summary>
        /// Exchange rate
        /// </summary>
        [JsonProperty("exchangeRate")]
        public decimal ExchangeRate { get; set; }
        /// <summary>
        /// From asset
        /// </summary>
        [JsonProperty("fromCoin")]
        public string FromAsset { get; set; } = string.Empty;
        /// <summary>
        /// From asset type
        /// </summary>
        [JsonProperty("fromCoinType")]
        public string FromAssetType { get; set; } = string.Empty;
        /// <summary>
        /// To asset
        /// </summary>
        [JsonProperty("toCoin")]
        public string ToAsset { get; set; } = string.Empty;
        /// <summary>
        /// To asset type
        /// </summary>
        [JsonProperty("toCoinType")]
        public string ToAssetType { get; set; } = string.Empty;
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
        /// Expire time
        /// </summary>
        [JsonProperty("expiredTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime ExpireTime { get; set; }
        /// <summary>
        /// Request id
        /// </summary>
        [JsonProperty("requestId")]
        public string? RequestId { get; set; }
    }


}
