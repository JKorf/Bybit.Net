using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Convert status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<ConvertTransactionStatus>))]
    public enum ConvertTransactionStatus
    {
        /// <summary>
        /// Initial
        /// </summary>
        [Map("init")]
        Initial,
        /// <summary>
        /// Processing
        /// </summary>
        [Map("processing")]
        Processing,
        /// <summary>
        /// Successful
        /// </summary>
        [Map("success")]
        Success,
        /// <summary>
        /// Failure
        /// </summary>
        [Map("failure")]
        Failed
    }
}
