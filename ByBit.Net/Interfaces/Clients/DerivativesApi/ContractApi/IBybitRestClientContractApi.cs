namespace Bybit.Net.Interfaces.Clients.DerivativesApi.ContractApi
{
    /// <summary>
    /// Bybit contract API endpoints
    /// </summary>
    public interface IBybitRestClientContractApi
    {
        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        IBybitRestClientContractApiAccount Account { get; }

        /// <summary>
        /// Endpoints related to orders and trades
        /// </summary>
        IBybitRestClientContractApiTrading Trading { get; }
    }
}
