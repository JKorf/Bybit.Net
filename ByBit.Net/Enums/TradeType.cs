using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Trade type
    /// </summary>
    public enum TradeType
    {
        /// <summary>
        /// Normal trade
        /// </summary>
        [Map("Trade")]
        Trade,
        /// <summary>
        /// Adl trade
        /// </summary>
        [Map("AdlTrade")]
        AdlTrade,
        /// <summary>
        /// Funding trade
        /// </summary>
        [Map("Funding")]
        Funding,
        /// <summary>
        /// Bankruptcy trade
        /// </summary>
        [Map("BustTrade")]
        BustTrade,
        /// <summary>
        /// Settle
        /// </summary>
        [Map("Settle")]
        Settle,
        /// <summary>
        /// Delivery
        /// </summary>
        [Map("Delivery")]
        Delivery
    }
}
