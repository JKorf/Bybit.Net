using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Contract type
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum ContractType
    {
        /// <summary>
        /// Future
        /// </summary>
        [Map("Future")]
        Future,
        /// <summary>
        /// Perpetual
        /// </summary>
        [Map("Perpetual")]
        Perpetual,
        /// <summary>
        /// Linear perpetual
        /// </summary>
        [Map("LinearPerpetual")]
        LinearPerpetual
    }

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
