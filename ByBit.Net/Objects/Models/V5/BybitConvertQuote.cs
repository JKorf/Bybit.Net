using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Convert quote
    /// </summary>
    [SerializationModel]
    public record BybitConvertQuote
    {
        /// <summary>
        /// Quote transaction id
        /// </summary>
        [JsonPropertyName("quoteTxId")]
        public string QuoteTransactionId { get; set; } = string.Empty;
        /// <summary>
        /// Exchange rate
        /// </summary>
        [JsonPropertyName("exchangeRate")]
        public decimal ExchangeRate { get; set; }
        /// <summary>
        /// From asset
        /// </summary>
        [JsonPropertyName("fromCoin")]
        public string FromAsset { get; set; } = string.Empty;
        /// <summary>
        /// From asset type
        /// </summary>
        [JsonPropertyName("fromCoinType")]
        public string FromAssetType { get; set; } = string.Empty;
        /// <summary>
        /// To asset
        /// </summary>
        [JsonPropertyName("toCoin")]
        public string ToAsset { get; set; } = string.Empty;
        /// <summary>
        /// To asset type
        /// </summary>
        [JsonPropertyName("toCoinType")]
        public string ToAssetType { get; set; } = string.Empty;
        /// <summary>
        /// From quantity
        /// </summary>
        [JsonPropertyName("fromAmount")]
        public decimal FromQuantity { get; set; }
        /// <summary>
        /// To quantity
        /// </summary>
        [JsonPropertyName("toAmount")]
        public decimal ToQuantity { get; set; }
        /// <summary>
        /// Expire time
        /// </summary>
        [JsonPropertyName("expiredTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime ExpireTime { get; set; }
        /// <summary>
        /// Request id
        /// </summary>
        [JsonPropertyName("requestId")]
        public string? RequestId { get; set; }
    }


}
