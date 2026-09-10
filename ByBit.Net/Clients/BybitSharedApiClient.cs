using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Interfaces.Clients.V5;
using CryptoExchange.Net.SharedApis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bybit.Net.Clients
{
    /// <inheritdoc />
    public class BybitSharedApiClient : SharedApiClientBase, IBybitSharedApiClient
    {
        /// <inheritdoc />
        public IBybitRestClientSharedApi Rest { get; }
        /// <inheritdoc />
        public IBybitSocketClientSpotSharedApi SpotSocket { get; }
        /// <inheritdoc />
        public IBybitSocketClientLinearSharedApi LinearSocket { get; }
        /// <inheritdoc />
        public IBybitSocketClientInverseSharedApi InverseSocket { get; }
        /// <inheritdoc />
        public IBybitSocketClientPrivateSharedApi PrivateSocket { get; }

        /// <summary>
        /// ctor
        /// </summary>
        public BybitSharedApiClient(
            IBybitRestClient restClient,
            IBybitSocketClient socketClient)
            :base (new[] { SharedTransport.Rest, SharedTransport.Socket },
                restClient.V5Api.SharedApi,
                socketClient.V5SpotApi.SharedApi,
                socketClient.V5LinearApi.SharedApi,
                socketClient.V5InverseApi.SharedApi,
                socketClient.V5PrivateApi.SharedApi)
        {
            Rest = restClient.V5Api.SharedApi;
            SpotSocket = socketClient.V5SpotApi.SharedApi;
            LinearSocket = socketClient.V5LinearApi.SharedApi;
            InverseSocket = socketClient.V5InverseApi.SharedApi;
            PrivateSocket = socketClient.V5PrivateApi.SharedApi;
        }
    }
}
