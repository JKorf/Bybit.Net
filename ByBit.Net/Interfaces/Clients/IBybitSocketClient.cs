using Bybit.Net.Interfaces.Clients.InversePerpetualApi;
using Bybit.Net.Interfaces.Clients.SpotApi;
using Bybit.Net.Interfaces.Clients.UsdPerpetualApi;
using CryptoExchange.Net.Interfaces;

namespace Bybit.Net.Interfaces.Clients
{
    /// <summary>
    /// Client for accessing the bybit websocket API
    /// </summary>
    public interface IBybitSocketClient: ISocketClient
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
        /// Inverse perpetual streams
        /// </summary>
        public IBybitSocketClientInversePerpetualStreams InversePerpetualStreams { get; }
        /// <summary>
        /// Copy trading streams
        /// </summary>
        public IBybitSocketClientCopyTradingStreams CopyTrading { get; }
    }
}
