using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Repayment type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<RepayType>))]
    public enum RepayType
    {
        /// <summary>
        /// By user
        /// </summary>
        [Map("1")]
        ByUser,
        /// <summary>
        /// By liquidation
        /// </summary>
        [Map("2")]
        ByLiquidation
    }
}
