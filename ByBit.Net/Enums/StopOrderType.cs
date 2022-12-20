namespace Bybit.Net.Enums
{
    /// <summary>
    /// Stop order type
    /// </summary>
    public enum StopOrderType
    {
        /// <summary>
        /// Take profit
        /// </summary>
        TakeProfit,
        /// <summary>
        /// Stop loss
        /// </summary>
        StopLoss,
        /// <summary>
        /// Trailing stop
        /// </summary>
        TrailingStop,
        /// <summary>
        /// Stop
        /// </summary>
        Stop,
        /// <summary>
        /// Partial stop loss
        /// </summary>
        PartialStopLoss,
        /// <summary>
        /// Unknown type
        /// </summary>
        Unknown
    }
}
