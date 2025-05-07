using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Withdrawal type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<WithdrawalType>))]
    public enum WithdrawalType
    {
        /// <summary>
        /// On chain
        /// </summary>
        [Map("0")]
        OnChain,
        /// <summary>
        /// Off chain
        /// </summary>
        [Map("1")]
        OffChain,
        /// <summary>
        /// Both
        /// </summary>
        [Map("2")]
        Both
    }
}
