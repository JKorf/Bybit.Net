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
        /// Spot streams
        /// </summary>
        public IBybitSocketClientSpotStreams SpotStreams { get; }
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
