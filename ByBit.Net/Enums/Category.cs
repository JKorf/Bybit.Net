using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Account type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<Category>))]
    public enum Category
    {
        /// <summary>
        /// Linear perpetual, including USDC perp.
        /// </summary>
        [Map("linear")]
        Linear,
        /// <summary>
        /// Inverse futures, including inverse perpetual, inverse futures.
        /// </summary>
        [Map("inverse")]
        Inverse,
        /// <summary>
        /// Spot
        /// </summary>
        [Map("spot")]
        Spot,
        /// <summary>
        /// USDC Option
        /// </summary>
        [Map("option")]
        Option,
        /// <summary>
        /// Category not passed
        /// </summary>
        [Map("")]
        Undefined
    }
}
