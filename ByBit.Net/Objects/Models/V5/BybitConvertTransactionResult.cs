using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Transaction info
    /// </summary>
    [SerializationModel]
    public record BybitConvertTransactionResult
    {
        /// <summary>
        /// Quote transaction id
        /// </summary>
        [JsonPropertyName("quoteTxId")]
        public string QuoteTransactionId { get; set; } = string.Empty;
        /// <summary>
        /// Convert status
        /// </summary>
        [JsonPropertyName("exchangeStatus")]
        public ConvertTransactionStatus Status { get; set; }
    }
}
