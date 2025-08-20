using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Account type to withdraw from
    /// </summary>
    [JsonConverter(typeof(EnumConverter<WithdrawAccountType>))]
    public enum WithdrawAccountType
    {
        /// <summary>
        /// Spot account
        /// </summary>
        [Map("SPOT")]
        Spot,
        /// <summary>
        /// Funding account
        /// </summary>
        [Map("FUND")]
        Fund,
        /// <summary>
        /// UTA account
        /// </summary>
        [Map("UTA")]
        Uta,
        /// <summary>
        /// Use funding account first and UTA account after
        /// </summary>
        [Map("FUND,UTA")]
        FundAndUta,
    }
}
