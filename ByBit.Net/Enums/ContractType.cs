using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// V5 contract types
    /// </summary>
    [JsonConverter(typeof(EnumConverter<ContractTypeV5>))]
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
        InverseFutures,
        /// <summary>
        /// Spot
        /// </summary>
        [Map("Spot")]
        Spot
    }
}
