using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Account type
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
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
        CopyTrading
    }
}
