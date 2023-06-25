using Bybit.Net.Interfaces.Clients.DerivativesApi.ContractApi;
using Bybit.Net.Interfaces.Clients.DerivativesApi.UnifiedMarginApi;
using CryptoExchange.Net.Interfaces;
using System;

namespace Bybit.Net.Interfaces.Clients.DerivativesApi
{
    /// <summary>
    /// Bybit Derivatives v3 endpoints
    /// </summary>
    public interface IBybitRestClientDerivativesApi : IRestApiClient, IDisposable
    {
        /// <summary>
        /// Endpoints related to retrieving market and system data
        /// </summary>
        IBybitRestClientDerivativesApiExchangeData ExchangeData { get; }

        /// <summary>
        /// Bybit Contract endpoints
        /// </summary>
        IBybitRestClientContractApi ContractApi { get; }

        /// <summary>
        /// Bybit Unified Margin endpoints
        /// </summary>
        IBybitRestClientUnifiedMarginApi UnifiedMarginApi { get; }
    }
}
