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
        GoodTillCanceled,
        /// <summary>
        /// Fill at least partially upon placing or cancel
        /// </summary>
        ImmediateOrCancel,
        /// <summary>
        /// Fill fully upon placing or cancel
        /// </summary>
        FillOrKill,
        /// <summary>
        /// Only place order if the order is added to the order book instead of being filled immediately
        /// </summary>
        PostOnly
    }
}
