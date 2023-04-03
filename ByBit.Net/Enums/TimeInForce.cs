using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Time in force
    /// </summary>
    public enum TimeInForce
    {
        /// <summary>
        /// Good till canceled by user
        /// </summary>
        [Map("GTC")]
        GoodTillCanceled,
        /// <summary>
        /// Fill at least partially upon placing or cancel
        /// </summary>
        [Map("IOC")]
        ImmediateOrCancel,
        /// <summary>
        /// Fill fully upon placing or cancel
        /// </summary>
        [Map("FOK")]
        FillOrKill,
        /// <summary>
        /// Only place order if the order is added to the order book instead of being filled immediately
        /// </summary>
        PostOnly
    }
}
