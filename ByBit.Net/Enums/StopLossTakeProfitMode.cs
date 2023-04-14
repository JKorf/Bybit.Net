using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// StopLoss/TakeProfit mode
    /// </summary>
    public enum StopLossTakeProfitMode
    {
        /// <summary>
        /// Full take profit/stop loss mode (a single TP order and a single SL order can be placed, covering the entire position)
        /// </summary>
        [Map("Full")]
        Full,
        /// <summary>
        /// Partial take profit/stop loss mode (multiple TP and SL orders can be placed, covering portions of the position)
        /// </summary>
        [Map("Partial")]
        Partial
    }
}
