using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Product type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<ProductType>))]
    public enum ProductType
    {
        /// <summary>
        /// Options
        /// </summary>
        [Map("OPTIONS", "3")]
        Options,
        /// <summary>
        /// Derivatives
        /// </summary>
        [Map("DERIVATIVES", "1")]
        Derivatives,
        /// <summary>
        /// Spot
        /// </summary>
        [Map("SPOT", "2")]
        Spot,
        /// <summary>
        /// Spread
        /// </summary>
        [Map("SPREAD", "4")]
        Spread
    }
}
