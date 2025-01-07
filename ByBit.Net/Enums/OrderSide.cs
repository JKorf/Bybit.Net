using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Side of an order
    /// </summary>
    public enum OrderSide
    {
        /// <summary>
        /// Buy
        /// </summary>
        [Map("Buy", "BUY")]
        Buy,
        /// <summary>
        /// Sell
        /// </summary>
        [Map("Sell", "SELL")]
        Sell
    }
}
