using Bybit.Net.Interfaces.Clients.V5;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects.Options;

namespace Bybit.Net.Interfaces.Clients
{
    /// <summary>
    /// Client for accessing the bybit websocket API
    /// </summary>
    public interface IBybitSocketClient : ISocketClient<BybitCredentials>
    {
        /// <summary>
        /// V5 Spot streams
        /// </summary>
        /// <see cref="IBybitSocketClientSpotApi"/>
        public IBybitSocketClientSpotApi V5SpotApi { get; }
        /// <summary>
        /// V5 Linear streams
        /// </summary>
        /// <see cref="IBybitSocketClientLinearApi"/>
        public IBybitSocketClientLinearApi V5LinearApi { get; }
        /// <summary>
        /// V5 Inverse contract streams
        /// </summary>
        /// <see cref="IBybitSocketClientInverseApi"/>
        public IBybitSocketClientInverseApi V5InverseApi { get; }
        /// <summary>
        /// V5 Option streams
        /// </summary>
        /// <see cref="IBybitSocketClientOptionApi"/>
        public IBybitSocketClientOptionApi V5OptionsApi { get; }
        /// <summary>
        /// V5 Spread streams
        /// </summary>
        /// <see cref="IBybitSocketClientSpreadApi"/>
        public IBybitSocketClientSpreadApi V5SpreadApi { get; }
        /// <summary>
        /// V5 Private streams
        /// </summary>
        /// <see cref="IBybitSocketClientPrivateApi"/>
        public IBybitSocketClientPrivateApi V5PrivateApi { get; }

    }
}
