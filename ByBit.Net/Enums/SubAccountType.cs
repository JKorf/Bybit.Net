using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Sub account type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<SubAccountType>))]
    public enum SubAccountType
    {
        /// <summary>
        /// Normal account
        /// </summary>
        [Map("1")]
        NormalAccount,
        /// <summary>
        /// Custodial account
        /// </summary>
        [Map("6")]
        CustodialAccount
    }
}
