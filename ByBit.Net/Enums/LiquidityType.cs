using CryptoExchange.Net.Attributes;
using System.Text.Json.Serialization;

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
