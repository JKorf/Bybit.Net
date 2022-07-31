using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Universal transfer info
    /// </summary>
    public class BybitUniversalTransfer
    {
        /// <summary>
        /// Tranfer id
        /// </summary>
        [JsonProperty("transfer_id")]
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
        /// Status
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public UniversalTransferStatus Status { get; set; }
        /// <summary>
        /// From account type
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public AccountType FromAccountType { get; set; }
        /// <summary>
        /// To account type
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public AccountType ToAccountType { get; set; }
        /// <summary>
        /// From member id
        /// </summary>
        public string FromMemberId { get; set; } = string.Empty;
        /// <summary>
        /// To member id
        /// </summary>
        public string ToMemberId { get; set; } = string.Empty;
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
