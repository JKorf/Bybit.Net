using CryptoExchange.Net;
using CryptoExchange.Net.SharedApis;
using System;

namespace Bybit.Net
{
    /// <summary>
    /// Bybit exchange information and configuration
    /// </summary>
    public static class BybitExchange
    {
        /// <summary>
        /// Exchange name
        /// </summary>
        public static string ExchangeName => "Bybit";

        /// <summary>
        /// Url to the main website
        /// </summary>
        public static string Url { get; } = "https://www.bybit.com";

        /// <summary>
        /// Urls to the API documentation
        /// </summary>
        public static string[] ApiDocsUrl { get; } = new[] {
            "https://bybit-exchange.github.io/docs/v3/intro",
            "https://bybit-exchange.github.io/docs/v5/intro"
            };

        /// <summary>
        /// Format a base and quote asset to a Bybit recognized symbol 
        /// </summary>
        /// <param name="baseAsset">Base asset</param>
        /// <param name="quoteAsset">Quote asset</param>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="deliverTime">Delivery time for delivery futures</param>
        /// <returns></returns>
        public static string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
        {
            if (tradingMode == TradingMode.Spot)
                return baseAsset.ToUpperInvariant() + quoteAsset.ToUpperInvariant();

            if (tradingMode.IsLinear())
            {
                if (tradingMode.IsPerpetual())
                {
                    if (quoteAsset == "USDC")
                        return baseAsset + "PERP";

                    return baseAsset.ToUpperInvariant() + quoteAsset.ToUpperInvariant();
                }

                return baseAsset.ToUpperInvariant() + "-" + deliverTime!.Value.ToString("ddMMMyy").ToUpperInvariant();
            }

            return baseAsset.ToUpperInvariant() + quoteAsset.ToUpperInvariant() + (deliverTime == null ? string.Empty : (ExchangeHelpers.GetDeliveryMonthSymbol(deliverTime.Value) + deliverTime.Value.ToString("yy")));
        }
    }
}
