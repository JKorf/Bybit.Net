using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Account mode
    /// </summary>
    [JsonConverter(typeof(EnumConverter<AccountMode>))]
    public enum AccountMode
    {
        /// <summary>
        /// Classic
        /// </summary>
        [Map("1")]
        Classic,
        /// <summary>
        /// UMA
        /// </summary>
        [Map("2")]
        UniversalMarginAccount,
        /// <summary>
        /// UTA
        /// </summary>
        [Map("3")]
        UniversalTransferAccount
    }
}
