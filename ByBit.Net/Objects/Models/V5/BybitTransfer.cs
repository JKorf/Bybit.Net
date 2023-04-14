using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Transfer info
    /// </summary>
    public class BybitTransfer
    {
        /// <summary>
        /// Transfer id
        /// </summary>
        public string TransferId { get; set; } = string.Empty;
        /// <summary>
        /// Asset
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonProperty("amount")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// From account
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public AccountType FromAccountType { get; set; }
        /// <summary>
        /// To account
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public AccountType ToAccountType { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public TransferStatus Status { get; set; }
        /// <summary>
        /// [UniversalTransfer] From member id
        /// </summary>
        public string? FromMemberId { get; set; }
        /// <summary>
        /// [UniversalTransfer] To member id
        /// </summary>
        public string? ToMemberId { get; set; }
    }
}
