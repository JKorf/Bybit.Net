using CryptoExchange.Net.Interfaces;

namespace Bybit.Net.Interfaces.Clients.DerivativesApi.ContractApi
{
    /// <summary>
    /// Bybit contract API endpoints
    /// </summary>
    public interface IBybitClientContractApi
    {
        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        IBybitClientContractApiAccount Account { get; }

        /// <summary>
        /// Endpoints related to orders and trades
        /// </summary>
        IBybitClientContractApiTrading Trading { get; }
    }
}
