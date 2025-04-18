using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Internal deposit status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<InternalDepositStatus>))]
    public enum InternalDepositStatus
    {
        /// <summary>
        /// Processing
        /// </summary>
        [Map("1")]
        Processing,
        /// <summary>
        /// Success
        /// </summary>
        [Map("2")]
        Success,
        /// <summary>
        /// Failed
        /// </summary>
        [Map("3")]
        Failed
    }
}
