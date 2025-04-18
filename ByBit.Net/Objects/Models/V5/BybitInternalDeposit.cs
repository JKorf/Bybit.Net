using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Internal deposit info
    /// </summary>
    [SerializationModel]
    public record BybitInternalDeposit
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Type (1: Internal deposit)
        /// </summary>
        [JsonPropertyName("type")]
        public int Type { get; set; }
        /// <summary>
        /// The asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Email or phone number
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;
        /// <summary>
        /// Status
        /// </summary>
        [JsonPropertyName("status")]

        public InternalDepositStatus Status { get; set; }
        /// <summary>
        /// Timestamp 
        /// </summary>
        [JsonPropertyName("createdTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Transaction id
        /// </summary>
        [JsonPropertyName("txID")]
        public string TransactionId { get; set; } = string.Empty;
    }
}
