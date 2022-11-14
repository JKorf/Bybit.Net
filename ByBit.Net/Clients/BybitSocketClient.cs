using Bybit.Net.Objects.Internal.Socket;
using Bybit.Net.Objects;
using CryptoExchange.Net;
using System;
using System.Collections.Generic;
using CryptoExchange.Net.Objects;
using System.Threading.Tasks;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json.Linq;
using System.Linq;
using Bybit.Net.Interfaces.Clients;
using Newtonsoft.Json;
using System.Threading;
using Bybit.Net.Objects.Models.Socket.Spot;
using Bybit.Net.Interfaces.Clients.UsdPerpetualApi;
using Bybit.Net.Interfaces.Clients.InversePerpetualApi;
using Bybit.Net.Clients.SpotApi;
using Bybit.Net.Clients.InversePerpetualApi;
using Bybit.Net.Clients.UsdPerpetualApi;
using Bybit.Net.Clients.SpotApi.v1;
using Bybit.Net.Clients.SpotApi.v2;
using Bybit.Net.Clients.SpotApi.v3;
using Bybit.Net.Interfaces.Clients.SpotApi;
using Bybit.Net.Interfaces.Clients.SpotApi.v1;
using Bybit.Net.Interfaces.Clients.SpotApi.v2;
using Bybit.Net.Interfaces.Clients.SpotApi.v3;

namespace Bybit.Net.Clients
{
    /// <inheritdoc cref="IBybitSocketClient" />
    public class BybitSocketClient : BaseSocketClient, IBybitSocketClient
    {
        /// <inheritdoc />
        public IBybitSocketClientUsdPerpetualStreams UsdPerpetualStreams { get; }
        /// <inheritdoc />
        public IBybitSocketClientInversePerpetualStreams InversePerpetualStreams { get; }
        /// <inheritdoc />
        public IBybitSocketClientSpotStreamsV1 SpotStreamsV1 { get; }
        /// <inheritdoc />
        public IBybitSocketClientSpotStreamsV2 SpotStreamsV2 { get; }
        /// <inheritdoc />
        public IBybitSocketClientSpotStreamsV3 SpotStreamsV3 { get; }

        /// <inheritdoc />
        public IBybitSocketClientCopyTradingStreams CopyTrading { get; }

        /// <summary>
        /// Create a new instance of BybitSocketClientFutures using the default options
        /// </summary>
        public BybitSocketClient() : this(BybitSocketClientOptions.Default)
        {
        }

        /// <summary>
        /// Create a new instance of BybitSocketClientFutures using provided options
        /// </summary>
        /// <param name="options">The options to use for this client</param>
        public BybitSocketClient(BybitSocketClientOptions options) : base("Bybit", options)
        {
            if (options == null)
                throw new ArgumentException("Cant pass null options, use empty constructor for default");

            UsdPerpetualStreams = AddApiClient(new BybitSocketClientUsdPerpetualStreams(log, this, options));
            InversePerpetualStreams = AddApiClient(new BybitSocketClientInversePerpetualStreams(log, options));
            SpotStreamsV1 = AddApiClient(new BybitSocketClientSpotStreamsV1(log, options));
            SpotStreamsV2 = AddApiClient(new BybitSocketClientSpotStreamsV2(log, options));
            SpotStreamsV3 = AddApiClient(new BybitSocketClientSpotStreamsV3(log, options));

            CopyTrading = AddApiClient(new BybitSocketClientCopyTradingStreams(log, options));
        }

        /// <summary>
        /// Set the default options to be used when creating new clients
        /// </summary>
        /// <param name="options"></param>
        public static void SetDefaultOptions(BybitSocketClientOptions options)
        {
            BybitSocketClientOptions.Default = options;
        }
    }
}
