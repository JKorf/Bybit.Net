using Bybit.Net.Objects;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using System;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Net.Logging;
using Bybit.Net.Objects.Models.Socket.Spot;
using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.Spot;
using Bybit.Net.Interfaces.Clients.SpotApi;

namespace Bybit.Net.Clients.SpotApi
{
    /// <inheritdoc cref="IBybitSocketClientSpotStreamsV2" />
    public abstract class BybitBaseSocketClientSpotStreams : SocketApiClient
    {
        protected readonly Log _log;
        protected readonly BybitSocketClient _baseClient;
        protected readonly BybitSocketClientOptions _options;

        internal BybitBaseSocketClientSpotStreams(Log log, BybitSocketClient baseClient, BybitSocketClientOptions options, BybitSocketApiClientOptions apiOptions)
            : base(options, apiOptions)
        {
            _log = log;
            _options = options;
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new BybitAuthenticationProvider(credentials);
    }
}
