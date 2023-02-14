using CryptoExchange.Net.Interfaces;

namespace Bybit.Net.Interfaces.Clients.DerivativesApi.UnifiedMarginApi
{
    /// <summary>
    /// Bybit Unified Margin API endpoints
    /// </summary>
    public interface IBybitClientUnifiedMarginApi
    {
        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        IBybitClientUnifiedMarginApiAccount Account { get; }

        /// <summary>
        /// Endpoints related to orders and trades
        /// </summary>
        IBybitClientUnifiedMarginApiTrading Trading { get; }
    }
}
