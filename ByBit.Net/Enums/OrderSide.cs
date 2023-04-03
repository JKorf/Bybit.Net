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
        [Map("Buy")]
        Buy,
        /// <summary>
        /// Sell
        /// </summary>
        [Map("Sell")]
        Sell
    }
}
