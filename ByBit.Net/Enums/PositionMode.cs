using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Position mode
    /// </summary>
    public enum PositionMode
    {
        /// <summary>
        /// Merge single
        /// </summary>
        [Map("0")]
        MergedSingle,
        /// <summary>
        /// Both sides
        /// </summary>
        [Map("3")]
        BothSides
    }
}
