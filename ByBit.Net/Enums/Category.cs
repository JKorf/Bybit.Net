using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Account type
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
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
        /// <remarks> Not supported in private endpoints</remarks>
        [Map("inverse")]
        Inverse,
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
