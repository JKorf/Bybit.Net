using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Transfer info
    /// </summary>
    [SerializationModel]
    public record BybitTransfer
    {
        /// <summary>
        /// Transfer id
        /// </summary>
        [JsonPropertyName("transferId")]
        public string TransferId { get; set; } = string.Empty;
        /// <summary>
        /// Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// From account
        /// </summary>

        [JsonPropertyName("fromAccountType")]
        public AccountType FromAccountType { get; set; }
        /// <summary>
        /// To account
        /// </summary>

        [JsonPropertyName("toAccountType")]
        public AccountType ToAccountType { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Status
        /// </summary>

        [JsonPropertyName("status")]
        public TransferStatus Status { get; set; }
        /// <summary>
        /// [UniversalTransfer] From member id
        /// </summary>
        [JsonPropertyName("fromMemberId")]
        public string? FromMemberId { get; set; }
        /// <summary>
        /// [UniversalTransfer] To member id
        /// </summary>
        [JsonPropertyName("toMemberId")]
        public string? ToMemberId { get; set; }
    }
}
