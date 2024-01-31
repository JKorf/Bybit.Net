using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums.V5
{
    /// <summary>
    /// Position idx
    /// </summary>
    public enum PositionIdx
    {
        /// <summary>
        /// One way mode
        /// </summary>
        [Map("0")]
        OneWayMode = 0,
        /// <summary>
        /// Buy side of hedge mode
        /// </summary>
        [Map("1")]
        BuyHedgeMode = 1,
        /// <summary>
        /// Sell side of hedge mode
        /// </summary>
        [Map("2")]
        SellHedgeMode = 2
    }
}
