using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Position mode
    /// </summary>
    public enum PositionMode
    {
        /// <summary>
        /// One way
        /// </summary>
        [Map("0")]
        OneWay,
        /// <summary>
        /// Buy side of both side mode
        /// </summary>
        [Map("1")]
        BothSideBuy,
        /// <summary>
        /// Sell side of both side mode
        /// </summary>
        [Map("2")]
        BothSideSell
    }
}
