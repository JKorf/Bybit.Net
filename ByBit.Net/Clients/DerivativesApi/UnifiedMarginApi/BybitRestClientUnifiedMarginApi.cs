using Bybit.Net.Interfaces.Clients.DerivativesApi.UnifiedMarginApi;

namespace Bybit.Net.Clients.DerivativesApi.UnifiedMarginApi
{
    /// <inheritdoc cref="IBybitRestClientUnifiedMarginApi" />
    internal class BybitRestClientUnifiedMarginApi : IBybitRestClientUnifiedMarginApi
    {
        /// <inheritdoc />
        public IBybitRestClientUnifiedMarginApiAccount Account { get; }

        /// <inheritdoc />
        public IBybitRestClientUnifiedMarginApiTrading Trading { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="baseClient"> Client </param>
        public BybitRestClientUnifiedMarginApi(BybitRestClientDerivativesApi baseClient)
        {
            Account = new BybitRestClientUnifiedMarginApiAccount(baseClient);
            Trading = new BybitRestClientUnifiedMarginApiTrading(baseClient);
        }
    }
}
