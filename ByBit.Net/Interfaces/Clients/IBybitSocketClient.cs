using Bybit.Net.Interfaces.Clients.DerivativesApi;
using Bybit.Net.Interfaces.Clients.DerivativesApi.ContractApi;
using Bybit.Net.Interfaces.Clients.DerivativesApi.UnifiedMarginApi;
using Bybit.Net.Interfaces.Clients.InversePerpetualApi;
using Bybit.Net.Interfaces.Clients.SpotApi.v1;
using Bybit.Net.Interfaces.Clients.SpotApi.v2;
using Bybit.Net.Interfaces.Clients.SpotApi.v3;
using Bybit.Net.Interfaces.Clients.UsdPerpetualApi;
using Bybit.Net.Interfaces.Clients.V5;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Interfaces;

namespace Bybit.Net.Interfaces.Clients
{
    /// <summary>
    /// Client for accessing the bybit websocket API
    /// </summary>
    public interface IBybitSocketClient : ISocketClient
    {
        /// <summary>
        /// USD perpetual streams
        /// </summary>
        public IBybitSocketClientUsdPerpetualApi UsdPerpetualApi { get; }
        /// <summary>
        /// Spot streams v1
        /// </summary>
        public IBybitSocketClientSpotApiV1 SpotV1Api { get; }
        /// <summary>
        /// Spot streams v2
        /// </summary>
        public IBybitSocketClientSpotApiV2 SpotV2Api { get; }
        /// <summary>
        /// Spot streams v3
        /// </summary>
        public IBybitSocketClientSpotApiV3 SpotV3Api { get; }
        /// <summary>
        /// Inverse perpetual streams
        /// </summary>
        public IBybitSocketClientInversePerpetualApi InversePerpetualApi { get; }
        /// <summary>
        /// Copy trading streams
        /// </summary>
        public IBybitSocketClientCopyTradingApi CopyTradingApi { get; }
        /// <summary>
        /// Derivatives public streams
        /// </summary>
        public IBybitSocketClientDerivativesPublicApi DerivativesApi { get; }
        /// <summary>
        /// Unified margin private streams
        /// </summary>
        public IBybitSocketClientUnifiedMarginApi UnifiedMarginApi { get; }
        /// <summary>
        /// Contract private streams
        /// </summary>
        public IBybitSocketClientContractApi ContractApi { get; }
        /// <summary>
        /// V5 Spot streams
        /// </summary>
        public IBybitSocketClientSpotApi V5SpotApi { get; }
        /// <summary>
        /// V5 Linear streams
        /// </summary>
        public IBybitSocketClientLinearApi V5LinearApi { get; }
        /// <summary>
        /// V5 Inverse contract streams
        /// </summary>
        public IBybitSocketClientInverseApi V5InverseApi { get; }
        /// <summary>
        /// V5 Option streams
        /// </summary>
        public IBybitSocketClientOptionApi V5OptionsApi { get; }
        /// <summary>
        /// V5 Private streams
        /// </summary>
        public IBybitSocketClientPrivateApi V5PrivateApi { get; }

        /// <summary>
        /// Set the API credentials for this client. All Api clients in this client will use the new credentials, regardless of earlier set options.
        /// </summary>
        /// <param name="credentials">The credentials to set</param>
        void SetApiCredentials(ApiCredentials credentials);
    }
}
