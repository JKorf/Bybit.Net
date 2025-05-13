using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Product status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<EarnProductStatus>))]
    public enum EarnProductStatus
    {
        /// <summary>
        /// Available
        /// </summary>
        [Map("Available")]
        Available,
        /// <summary>
        /// Not available
        /// </summary>
        [Map("NotAvailable")]
        NotAvailable
    }
}
