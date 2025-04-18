using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Earn order status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<EarnOrderStatus>))]
    public enum EarnOrderStatus
    {
        /// <summary>
        /// Success
        /// </summary>
        [Map("Success")]
        Success,
        /// <summary>
        /// Failed
        /// </summary>
        [Map("Fail")]
        Failed,
        /// <summary>
        /// Pending
        /// </summary>
        [Map("Pending")]
        Pending
    }
}
