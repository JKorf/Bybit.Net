using Bybit.Net.Interfaces.Clients.DerivativesApi.ContractApi;

namespace Bybit.Net.Clients.DerivativesApi.ContractApi
{
    /// <inheritdoc cref="IBybitRestClientContractApi" />
    public class BybitRestClientContractApi : IBybitRestClientContractApi
    {
        /// <inheritdoc />
        public IBybitRestClientContractApiAccount Account { get; }

        /// <inheritdoc />
        public IBybitRestClientContractApiTrading Trading { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="baseClient"> Client </param>
        public BybitRestClientContractApi(BybitRestClientDerivativesApi baseClient)
        {
            Account = new BybitClientUnifiedMarginApiAccount(baseClient);
            Trading = new BybitRestClientContractApiTrading(baseClient);
        }
    }
}
