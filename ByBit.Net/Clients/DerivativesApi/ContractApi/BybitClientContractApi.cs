using Bybit.Net.Interfaces.Clients.DerivativesApi.ContractApi;

namespace Bybit.Net.Clients.DerivativesApi.ContractApi
{
    /// <inheritdoc cref="IBybitClientContractApi" />
    public class BybitClientContractApi : IBybitClientContractApi
    {
        /// <inheritdoc />
        public IBybitClientContractApiAccount Account { get; }

        /// <inheritdoc />
        public IBybitClientContractApiTrading Trading { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="baseClient"> Client </param>
        public BybitClientContractApi(BybitClientDerivativesApi baseClient)
        {
            Account = new BybitClientUnifiedMarginApiAccount(baseClient);
            Trading = new BybitClientContractApiTrading(baseClient);
        }
    }
}
