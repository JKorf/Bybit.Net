using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Transfer details
    /// </summary>
    public class BybitTransferDetails
    {
        /// <summary>
        /// Transfer id
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
        /// Timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        public TransferStatus Status { get; set; }
    }

    /// <summary>
    /// Transfer details
    /// </summary>
    public class BybitInternalTransferDetails: BybitTransferDetails
    {
        /// <summary>
        /// From account type
        /// </summary>
        [JsonProperty("from_account_type")]
        public AccountType FromAccountType { get; set; }
        /// <summary>
        /// To account type
        /// </summary>
        [JsonProperty("to_account_type")]
        public AccountType ToAccountType { get; set; }
    }

    /// <summary>
    /// Sub account transfer details
    /// </summary>
    public class BybitSubAccountTransferDetails: BybitTransferDetails
    {
        /// <summary>
        /// User id
        /// </summary>
        [JsonProperty("user_id")]
        public long UserId { get; set; }
        /// <summary>
        /// Sub account id
        /// </summary>
        [JsonProperty("sub_user_id")]
        public long SubAccountId { get; set; }
        /// <summary>
        /// Type
        /// </summary>
        public TransferType Type { get; set; }
    }
}
