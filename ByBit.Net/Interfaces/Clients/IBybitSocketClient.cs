using Bybit.Net.Interfaces.Clients.DerivativesApi;
using Bybit.Net.Interfaces.Clients.DerivativesApi.ContractApi;
using Bybit.Net.Interfaces.Clients.DerivativesApi.UnifiedMarginApi;
using Bybit.Net.Interfaces.Clients.InversePerpetualApi;
using Bybit.Net.Interfaces.Clients.SpotApi.v1;
using Bybit.Net.Interfaces.Clients.SpotApi.v2;
using Bybit.Net.Interfaces.Clients.SpotApi.v3;
using Bybit.Net.Interfaces.Clients.UsdPerpetualApi;
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
        public IBybitSocketClientUsdPerpetualStreams UsdPerpetualStreams { get; }
        /// <summary>
        /// Spot streams v1
        /// </summary>
        public IBybitSocketClientSpotStreamsV1 SpotStreamsV1 { get; }
        /// <summary>
        /// Spot streams v2
        /// </summary>
        public IBybitSocketClientSpotStreamsV2 SpotStreamsV2 { get; }
        /// <summary>
        /// Spot streams v3
        /// </summary>
        public IBybitSocketClientSpotStreamsV3 SpotStreamsV3 { get; }
        /// <summary>
        /// Inverse perpetual streams
        /// </summary>
        public IBybitSocketClientInversePerpetualStreams InversePerpetualStreams { get; }
        /// <summary>
        /// Copy trading streams
        /// </summary>
        public IBybitSocketClientCopyTradingStreams CopyTrading { get; }
        /// <summary>
        /// Derivatives public streams
        /// </summary>
        public IBybitSocketClientDerivativesPublicStreams DerivativesPublic { get; }
        /// <summary>
        /// Unified margin private streams
        /// </summary>
        public IBybitSocketClientUnifiedMarginStreams UnifiedMarginPrivate { get; }
        /// <summary>
        /// Contract private streams
        /// </summary>
        public IBybitSocketClientContractStreams ContractPrivate { get; }
    }
}
