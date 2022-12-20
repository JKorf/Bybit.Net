using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Account type
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum LiquidityType
    {
        /// <summary>
        /// Liquidity taker
        /// </summary>
        [Map("TAKER")]
        Taker,
        /// <summary>
        /// Liquidity maker
        /// </summary>
        [Map("MAKER")]
        Maker,
        /// <summary>
        /// RemovedLiquidity
        /// </summary>
        [Map("REMOVEDLIQUIDITY")]
        RemovedLiquidity
    }
}
