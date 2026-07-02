using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Exchange info
    /// </summary>
    [SerializationModel]
    public record BybitAssetExchangePage : BybitBaseResponse
    {
        /// <summary>
        /// ["<c>orderBody</c>"] Asset exchange records
        /// </summary>
        [JsonPropertyName("orderBody")]
        public BybitAssetExchange[] OrderBody { get; set; } = Array.Empty<BybitAssetExchange>();
    }

    /// <summary>
    /// Asset exchange info
    /// </summary>
    [SerializationModel]
    public record BybitAssetExchange
    {
        /// <summary>
        /// ["<c>fromCoin</c>"] From asset
        /// </summary>
        [JsonPropertyName("fromCoin")]
        public string FromAsset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>toCoin</c>"] To asset
        /// </summary>
        [JsonPropertyName("toCoin")]
        public string ToAsset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>fromAmount</c>"] From quantity
        /// </summary>
        [JsonPropertyName("fromAmount")]
        public decimal FromQuantity { get; set; }
        /// <summary>
        /// ["<c>toAmount</c>"] To quantity
        /// </summary>
        [JsonPropertyName("toAmount")]
        public decimal ToQuantity { get; set; }
        /// <summary>
        /// ["<c>exchangeRate</c>"] Exchange rate
        /// </summary>
        [JsonPropertyName("exchangeRate")]
        public decimal ExchangeRate { get; set; }
        /// <summary>
        /// ["<c>createdTime</c>"] Timestamp
        /// </summary>
        [JsonPropertyName("createdTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// ["<c>exchangeTxId</c>"] Id
        /// </summary>
        [JsonPropertyName("exchangeTxId")]
        public string ExchangeTransactionId { get; set; } = string.Empty;
    }
}
