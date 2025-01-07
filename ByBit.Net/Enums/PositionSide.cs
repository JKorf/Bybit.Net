using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Side of a position
    /// </summary>
    public enum PositionSide
    {
        /// <summary>
        /// Buy
        /// </summary>
        [Map("Buy")]
        Buy,
        /// <summary>
        /// Sell
        /// </summary>
        [Map("Sell")]
        Sell,
        /// <summary>
        /// None
        /// </summary>
        [Map("None")]
        None
    }
}
