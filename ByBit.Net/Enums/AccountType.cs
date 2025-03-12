using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Account type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<AccountType>))]
    public enum AccountType
    {
        /// <summary>
        /// Contract account (futures)
        /// </summary>
        [Map("CONTRACT")]
        Contract,
        /// <summary>
        /// Spot account
        /// </summary>
        [Map("SPOT")]
        Spot,
        /// <summary>
        /// Investment (defi) account
        /// </summary>
        [Map("INVESTMENT")]
        Investment,
        /// <summary>
        /// Copy trading account
        /// </summary>
        [Map("COPYTRADING")]
        CopyTrading,
        /// <summary>
        /// Option account
        /// </summary>
        [Map("OPTION")]
        Option,
        /// <summary>
        /// Funding account
        /// </summary>
        [Map("FUND")]
        Fund,
        /// <summary>
        /// Unified account
        /// </summary>
        [Map("UNIFIED")]
        Unified,
    }
}
