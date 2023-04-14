using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Position status
    /// </summary>
    public enum PositionStatus
    {
        /// <summary>
        /// Normal
        /// </summary>
        [Map("Normal")]
        Normal,
        /// <summary>
        /// Liquidation
        /// </summary>
        [Map("Liq")]
        Liqidation,
        /// <summary>
        /// Auto deleverage
        /// </summary>
        [Map("Adl")]
        AutoDeleverage
    }
}
