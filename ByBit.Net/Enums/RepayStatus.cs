using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Repayment status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<RepayStatus>))]
    public enum RepayStatus
    {
        /// <summary>
        /// Success
        /// </summary>
        [Map("1")]
        Success,
        /// <summary>
        /// Processing
        /// </summary>
        [Map("2")]
        Processing
    }
}
