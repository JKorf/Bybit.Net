namespace Bybit.Net.Interfaces.Clients.DerivativesApi.UnifiedMarginApi
{
    /// <summary>
    /// Bybit Unified Margin API endpoints
    /// </summary>
    public interface IBybitRestClientUnifiedMarginApi
    {
        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        IBybitRestClientUnifiedMarginApiAccount Account { get; }

        /// <summary>
        /// Endpoints related to orders and trades
        /// </summary>
        IBybitRestClientUnifiedMarginApiTrading Trading { get; }
    }
}
