using Bybit.Net.Objects.Internal.Socket;
using Bybit.Net.Objects.Models.Socket;
using Bybit.Net.Objects;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Net.Logging;
using Bybit.Net.Enums;
using Bybit.Net.Converters;
using Bybit.Net.Interfaces.Clients.InversePerpetualApi;
using Bybit.Net.Interfaces.Clients.UsdPerpetualApi;
using Bybit.Net.Objects.Models.CopyTrading;

namespace Bybit.Net.Clients.InversePerpetualApi
{
    /// <inheritdoc cref="IBybitSocketClientCopyTradingStreams" />
    public class BybitSocketClientCopyTradingStreams : SocketApiClient, IBybitSocketClientCopyTradingStreams
    {
        private readonly Log _log;
        private readonly BybitSocketClient _baseClient;
        private readonly BybitSocketClientOptions _options;

        internal BybitSocketClientCopyTradingStreams(Log log, BybitSocketClient baseClient, BybitSocketClientOptions options)
            : base(options, options.InversePerpetualStreamsOptions)
        {
            _log = log;
            _options = options;
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new BybitAuthenticationProvider(credentials);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(Action<DataEvent<IEnumerable<BybitCopyTradingPositionUpdate>>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = _baseClient.DeserializeInternal<IEnumerable<BybitCopyTradingPositionUpdate>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitCopyTradingPositionUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            });
            return await _baseClient.SubscribeInternalAsync(this, _options.CopyTradingStreamsOptions.BaseAddressAuthenticated,
                new BybitFuturesRequestMessage() { Operation = "subscribe", Parameters = new[] { "copyTradePosition" } },
                null, true, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(Action<DataEvent<IEnumerable<BybitCopyTradingUserTradeUpdate>>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = _baseClient.DeserializeInternal<IEnumerable<BybitCopyTradingUserTradeUpdate>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitCopyTradingUserTradeUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            });
            return await _baseClient.SubscribeInternalAsync(this, _options.CopyTradingStreamsOptions.BaseAddressAuthenticated,
                new BybitFuturesRequestMessage() { Operation = "subscribe", Parameters = new[] { "copyTradeExecution" } },
                null, true, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<IEnumerable<BybitCopyTradingOrderUpdate>>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = _baseClient.DeserializeInternal<IEnumerable<BybitCopyTradingOrderUpdate>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitCopyTradingOrderUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            });
            return await _baseClient.SubscribeInternalAsync(this, _options.CopyTradingStreamsOptions.BaseAddressAuthenticated,
                new BybitFuturesRequestMessage() { Operation = "subscribe", Parameters = new[] { "copyTradeOrder" } },
                null, true, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(Action<DataEvent<BybitCopyTradingBalanceUpdate>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = _baseClient.DeserializeInternal<BybitCopyTradingBalanceUpdate>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitCopyTradingBalanceUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            });
            return await _baseClient.SubscribeInternalAsync(this, _options.CopyTradingStreamsOptions.BaseAddressAuthenticated,
                new BybitFuturesRequestMessage() { Operation = "subscribe", Parameters = new[] { "copyTradeWallet" } },
                null, true, internalHandler, ct).ConfigureAwait(false);
        }

    }
}
