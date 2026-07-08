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
        /// ["<c>id</c>"] Id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>amount</c>"] Quantity
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// ["<c>type</c>"] Type (1: Internal deposit)
        /// </summary>
        [JsonPropertyName("type")]
        public int Type { get; set; }
        /// <summary>
        /// ["<c>coin</c>"] The asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>address</c>"] Email or phone number
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>status</c>"] Status
        /// </summary>
        [JsonPropertyName("status")]

        public InternalDepositStatus Status { get; set; }
        /// <summary>
        /// ["<c>complianceStatus</c>"] Compliance status, only applicable to Turkey users
        /// </summary>
        [JsonPropertyName("complianceStatus")]

        public TravelRuleStatus? ComplianceStatus { get; set; }
        /// <summary>
        /// ["<c>createdTime</c>"] Timestamp 
        /// </summary>
        [JsonPropertyName("createdTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// ["<c>txID</c>"] Transaction id
        /// </summary>
        [JsonPropertyName("txID")]
        public string TransactionId { get; set; } = string.Empty;
    }
}
