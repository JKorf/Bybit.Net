using Bybit.Net.Interfaces.Clients.DerivativesApi.UnifiedMarginApi;

namespace Bybit.Net.Clients.DerivativesApi.UnifiedMarginApi
{
    /// <inheritdoc cref="IBybitClientUnifiedMarginApi" />
    public class BybitClientUnifiedMarginApi : IBybitClientUnifiedMarginApi
    {
        /// <inheritdoc />
        public IBybitClientUnifiedMarginApiAccount Account { get; }

        /// <inheritdoc />
        public IBybitClientUnifiedMarginApiTrading Trading { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="baseClient"> Client </param>
        public BybitClientUnifiedMarginApi(BybitClientDerivativesApi baseClient)
        {
            Account = new BybitClientUnifiedMarginApiAccount(baseClient);
            Trading = new BybitClientUnifiedMarginApiTrading(baseClient);
        }
    }
}
