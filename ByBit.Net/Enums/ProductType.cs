using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Product type
    /// </summary>
    public enum ProductType
    {
        /// <summary>
        /// Options
        /// </summary>
        [Map("OPTIONS")]
        Options,
        /// <summary>
        /// Derivatives
        /// </summary>
        [Map("DERIVATIVES")]
        Derivatives,
        /// <summary>
        /// Spot
        /// </summary>
        [Map("SPOT")]
        Spot
    }
}
