using CryptoExchange.Net.Attributes;

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
        [Map("TakeProfit")]
        TakeProfit,
        /// <summary>
        /// Stop loss
        /// </summary>
        [Map("StopLoss")]
        StopLoss,
        /// <summary>
        /// Trailing stop
        /// </summary>
        [Map("TrailingStop")]
        TrailingStop,
        /// <summary>
        /// Stop
        /// </summary>
        [Map("Stop")]
        Stop,
        /// <summary>
        /// Partial stop loss
        /// </summary>
        [Map("PartialStopLoss")]
        PartialStopLoss,
        /// <summary>
        /// Partial stop loss
        /// </summary>
        [Map("PartialTakeProfit")]
        PartialTakeProfit,
        /// <summary>
        /// Spot TP/SL order
        /// </summary>
        [Map("tpslOrder")]
        TpSlOrder,
        /// <summary>
        /// Unknown type
        /// </summary>
        Unknown
    }
}
