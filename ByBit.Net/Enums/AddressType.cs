using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Address type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<AddressType>))]
    public enum AddressType
    {
        /// <summary>
        /// OnChain Address Type(Regular Address Type and Universal Address Type)
        /// </summary>
        [Map("0")]
        OnChain,
        /// <summary>
        /// Internal Transfer Address Type 
        /// </summary>
        [Map("1")]
        Internal,
        /// <summary>
        /// On chain address and internal transfer address type 
        /// </summary>
        [Map("2")]
        OnChainAndInternal,
    }
}
