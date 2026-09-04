using Bybit.Net.Interfaces.Clients.V5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients
{
    /// <summary>
    /// Client for the shared REST and WebSocket API implementations of Bybit
    /// </summary>
    public interface IBybitSharedApiClient
    {
        /// <summary>
        /// REST shared API implementations
        /// </summary>
        IBybitRestClientSharedApi Rest { get; }

        /// <summary>
        /// WebSocket Spot Shared API implementations
        /// </summary>
        IBybitSocketClientSpotSharedApi SpotSocket { get; }

        /// <summary>
        /// WebSocket Linear Futures Shared API implementations
        /// </summary>
        IBybitSocketClientLinearSharedApi LinearSocket { get; }

        /// <summary>
        /// WebSocket Inverse Futures Shared API implementations
        /// </summary>
        IBybitSocketClientInverseSharedApi InverseSocket { get; }

        /// <summary>
        /// WebSocket Private Shared API implementations
        /// </summary>
        IBybitSocketClientPrivateSharedApi PrivateSocket { get; }
    }
}
