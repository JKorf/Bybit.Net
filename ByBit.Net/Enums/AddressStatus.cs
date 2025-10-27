using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Address status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<AddressStatus>))]
    public enum AddressStatus
    {
        /// <summary>
        /// Normal
        /// </summary>
        [Map("0")]
        Normal,
        /// <summary>
        /// New Addresses are prohibited from withdrawing coins for 24 Hours
        /// </summary>
        [Map("1")]
        Pending
    }
}
