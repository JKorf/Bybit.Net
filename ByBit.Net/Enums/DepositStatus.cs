using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Deposit status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<DepositStatus>))]
    public enum DepositStatus
    {
        /// <summary>
        /// Unknown
        /// </summary>
        [Map("0")]
        Unknown,
        /// <summary>
        /// Awaiting confirmations
        /// </summary>
        [Map("1")]
        ToBeConfirmed,
        /// <summary>
        /// Processing
        /// </summary>
        [Map("2")]
        Processing,
        /// <summary>
        /// Success
        /// </summary>
        [Map("3")]
        Success,
        /// <summary>
        /// Failed
        /// </summary>
        [Map("4")]
        DepositFailed
    }
}
