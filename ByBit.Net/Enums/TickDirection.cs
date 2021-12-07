namespace Bybit.Net.Enums
{
    /// <summary>
    /// Tick direction
    /// </summary>
    public enum TickDirection
    {
        /// <summary>
        /// Price rise tick
        /// </summary>
        PlusTick,
        /// <summary>
        /// Trade occurs at the same price as the previous trade, which occurred at a price higher than that for the trade preceding it
        /// </summary>
        ZeroPlusTick,
        /// <summary>
        /// Price drop tick
        /// </summary>
        MinusTick,
        /// <summary>
        /// Trade occurs at the same price as the previous trade, which occurred at a price lower than that for the trade preceding it
        /// </summary>
        ZeroMinusTick
    }
}
