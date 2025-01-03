using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Liquidity type
    /// </summary>
    public enum TradeLiquidity
    {
        /// <summary>
        /// Maker
        /// </summary>
        [Map("AddedLiquidity")]
        Maker,
        /// <summary>
        /// Taker
        /// </summary>
        [Map("RemovedLiquidity")]
        Taker,
        /// <summary>
        /// Other
        /// </summary>
        [Map("LiquidityIndNA")]
        Other
    }
}
