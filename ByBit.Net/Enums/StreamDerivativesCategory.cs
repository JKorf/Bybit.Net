using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Stream category of Symbol to subscribe for Derivatives public streams
    /// </summary>
    /// <remarks> In Bybit, for now, BTCPERP is USDC perp, BTCUSDT is usdt perp, And BTC-10DEC22-20000-C is option.</remarks>
    public enum StreamDerivativesCategory
    {
        /// <summary>
        /// USDT perpetual
        /// </summary>
        [Map("contract/usdt")]
        USDTPerp,
        /// <summary>
        /// USDC perpetual
        /// </summary>
        [Map("contract/usdc")]
        USDCPerp,
        /// <summary>
        /// USDC option
        /// </summary>
        [Map("option/usdc")]
        USDCOption,
        /// <summary>
        /// Inverse
        /// </summary>
        [Map("contract/inverse")]
        Inverse
    }
}
