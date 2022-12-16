﻿using Bybit.Net.Interfaces.Clients.DerivativesApi.ContractApi;
using Bybit.Net.Interfaces.Clients.DerivativesApi.UnifiedMarginApi;
using CryptoExchange.Net.Interfaces;
using System;

namespace Bybit.Net.Interfaces.Clients.DerivativesApi
{
    /// <summary>
    /// Bybit Derivatives v3 endpoints
    /// </summary>
    public interface IBybitClientDerivativesApi : IDisposable
    {
        /// <summary>
        /// The factory for creating requests. Used for unit testing
        /// </summary>
        IRequestFactory RequestFactory { get; set; }

        /// <summary>
        /// Endpoints related to retrieving market and system data
        /// </summary>
        IBybitClientDerivativesApiExchangeData ExchangeData { get; }

        /// <summary>
        /// Bybit Contract endpoints
        /// </summary>
        IBybitClientContractApi ContractApi { get; }

        /// <summary>
        /// Bybit Unified Margin endpoints
        /// </summary>
        IBybitClientUnifiedMarginApi UnifiedMarginApi { get; }
    }
}
