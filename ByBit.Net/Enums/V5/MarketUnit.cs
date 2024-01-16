using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums.V5
{
    /// <summary>
    /// The unit for quantity when creating Spot market orders for UTA account
    /// </summary>
    public enum MarketUnit
    {
        /// <summary>
        /// For example, when buying on BTCUSDT, then "quantity" unit is BTC
        /// </summary>
        [Map("baseCoin")]
        BaseAsset,
        /// <summary>
        /// For example, when selling on BTCUSDT, then "quantity" unit is USDT
        /// </summary>
        [Map("quoteCoin")]
        QuoteAsset
    }
}
