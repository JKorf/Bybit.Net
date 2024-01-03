using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums.V5
{
    /// <summary>
    /// The unit for qty when create Spot market orders for UTA account
    /// </summary>
    public enum MarketUnit
    {
        /// <summary>
        /// For example, buy BTCUSDT, then "qty" unit is BTC
        /// </summary>
        [Map("baseCoin")]
        BaseCoin,
        /// <summary>
        /// For example, sell BTCUSDT, then "qty" unit is USDT
        /// </summary>
        [Map("quoteCoin")]
        QuoteCoin
    }
}
