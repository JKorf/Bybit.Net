using CryptoExchange.Net;
using System;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Interfaces.Clients.SpotApi.v3;
using Bybit.Net.Interfaces.Clients.DerivativesApi.UnifiedMarginApi;
using Bybit.Net.Interfaces.Clients.DerivativesApi.ContractApi;
using Bybit.Net.Interfaces.Clients.DerivativesApi;
using CryptoExchange.Net.Authentication;
using Bybit.Net.Clients.V5;
using Bybit.Net.Interfaces.Clients.V5;
using Microsoft.Extensions.Logging;
using Bybit.Net.Objects.Options;
using Bybit.Net.Clients.DerivativesApi;
using Bybit.Net.Clients.DerivativesApi.ContractApi;
using Bybit.Net.Clients.DerivativesApi.UnifiedMarginApi;
using Bybit.Net.Clients.SpotApi.v3;

namespace Bybit.Net.Clients
{
    /// <inheritdoc cref="IBybitSocketClient" />
    public class BybitSocketClient : BaseSocketClient, IBybitSocketClient
    {
        /// <inheritdoc />
        public IBybitSocketClientSpotApiV3 SpotV3Api { get; }
        /// <inheritdoc />
        public IBybitSocketClientDerivativesPublicApi DerivativesApi { get; }
        /// <inheritdoc />
        public IBybitSocketClientUnifiedMarginApi UnifiedMarginApi { get; }
        /// <inheritdoc />
        public IBybitSocketClientContractApi ContractApi { get; }
        /// <inheritdoc />
        public IBybitSocketClientSpotApi V5SpotApi { get; }
        /// <inheritdoc />
        public IBybitSocketClientLinearApi V5LinearApi { get; }
        /// <inheritdoc />
        public IBybitSocketClientInverseApi V5InverseApi { get; }
        /// <inheritdoc />
        public IBybitSocketClientOptionApi V5OptionsApi { get; }
        /// <inheritdoc />
        public IBybitSocketClientPrivateApi V5PrivateApi { get; }

        /// <summary>
        /// Create a new instance of the BybitSocketClient
        /// </summary>
        /// <param name="loggerFactory">The logger factory</param>
        public BybitSocketClient(ILoggerFactory? loggerFactory = null) : this((x) => { }, loggerFactory)
        {
        }

        /// <summary>
        /// Create a new instance of the BybitSocketClient
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public BybitSocketClient(Action<BybitSocketOptions> optionsDelegate) : this(optionsDelegate, null)
        {
        }

        /// <summary>
        /// Create a new instance of the BybitSocketClient
        /// </summary>
        /// <param name="loggerFactory">The logger factory</param>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public BybitSocketClient(Action<BybitSocketOptions> optionsDelegate, ILoggerFactory? loggerFactory = null) : base(loggerFactory, "Bybit")
        {
            var options = BybitSocketOptions.Default.Copy();
            optionsDelegate(options);
            Initialize(options);

            SpotV3Api = AddApiClient(new BybitSocketClientSpotApiV3(_logger, options));

            DerivativesApi = AddApiClient(new BybitSocketClientDerivativesPublicApi(_logger, options));
            UnifiedMarginApi = AddApiClient(new BybitSocketClientUnifiedMarginApi(_logger, options));
            ContractApi = AddApiClient(new BybitSocketClientContractApi(_logger, options));

            V5SpotApi = AddApiClient(new BybitSocketClientSpotApi(_logger, options));
            V5InverseApi = AddApiClient(new BybitSocketClientInverseApi(_logger, options));
            V5LinearApi = AddApiClient(new BybitSocketClientLinearApi(_logger, options));
            V5OptionsApi = AddApiClient(new BybitSocketClientOptionApi(_logger, options));
            V5PrivateApi = AddApiClient(new BybitSocketClientPrivateApi(_logger, options));
        }

        /// <summary>
        /// Set the default options to be used when creating new clients
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public static void SetDefaultOptions(Action<BybitSocketOptions> optionsDelegate)
        {
            var options = BybitSocketOptions.Default.Copy();
            optionsDelegate(options);
            BybitSocketOptions.Default = options;
        }

        /// <inheritdoc />
        public void SetApiCredentials(ApiCredentials credentials)
        {
            SpotV3Api.SetApiCredentials(credentials);
            DerivativesApi.SetApiCredentials(credentials);
            UnifiedMarginApi.SetApiCredentials(credentials);
            ContractApi.SetApiCredentials(credentials);
            V5LinearApi.SetApiCredentials(credentials);
            V5OptionsApi.SetApiCredentials(credentials);
            V5PrivateApi.SetApiCredentials(credentials);
            V5SpotApi.SetApiCredentials(credentials);
        }
    }
}
