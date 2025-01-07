using CryptoExchange.Net.Attributes;
using System.Text.Json.Serialization;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// V5 contract types
    /// </summary>
    public enum ContractTypeV5
    {
        /// <summary>
        /// Inverse perpetual
        /// </summary>
        [Map("InversePerpetual")]
        InversePerpetual,
        /// <summary>
        /// Linear perpetual
        /// </summary>
        [Map("LinearPerpetual")]
        LinearPerpetual,
        /// <summary>
        /// Linear futures
        /// </summary>
        [Map("LinearFutures")]
        LinearFutures,
        /// <summary>
        /// Inverse futures
        /// </summary>
        [Map("InverseFutures")]
        InverseFutures
    }
}
