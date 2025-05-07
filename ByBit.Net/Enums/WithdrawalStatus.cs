using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Withdrawal status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<WithdrawalStatus>))]
    public enum WithdrawalStatus
    {
        /// <summary>
        /// Security check
        /// </summary>
        [Map("SecurityCheck")]
        SecurityCheck,
        /// <summary>
        /// Pending
        /// </summary>
        [Map("Pending")]
        Pending,
        /// <summary>
        /// Success
        /// </summary>
        [Map("success")]
        Success,
        /// <summary>
        /// Canceled by user
        /// </summary>
        [Map("CancelByUser")]
        CanceledByUser,
        /// <summary>
        /// Rejected
        /// </summary>
        [Map("Reject")]
        Rejected,
        /// <summary>
        /// Failed
        /// </summary>
        [Map("Fail")]
        Failed,
        /// <summary>
        /// Blockchain confirmed
        /// </summary>
        [Map("BlockchainConfirmed")]
        BlockchainConfirmed,
        /// <summary>
        /// More information required
        /// </summary>
        [Map("MoreInformationRequired")]
        MoreInformationRequired
    }
}
