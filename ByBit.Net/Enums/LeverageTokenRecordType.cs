using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Leverage token record type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<LeverageTokenRecordType>))]
    public enum LeverageTokenRecordType
    {
        /// <summary>
        /// Purchase record
        /// </summary>
        [Map("1")]
        Purchase,
        /// <summary>
        /// Redeem record
        /// </summary>
        [Map("2")]
        Redeem
    }
}
