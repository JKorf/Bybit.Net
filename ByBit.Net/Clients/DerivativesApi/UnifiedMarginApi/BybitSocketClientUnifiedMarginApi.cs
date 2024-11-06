using Bybit.Net.Interfaces.Clients.DerivativesApi.UnifiedMarginApi;
using Bybit.Net.Objects;
using Bybit.Net.Objects.Models.Derivatives.UnifiedMargin;
using Bybit.Net.Objects.Models.Socket;
using Bybit.Net.Objects.Models.Socket.Derivatives;
using Bybit.Net.Objects.Models.Socket.Derivatives.UnifiedMargin;
using Bybit.Net.Objects.Options;
using Bybit.Net.Objects.Sockets.Queries;
using Bybit.Net.Objects.Sockets.Subscriptions;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Converters.MessageParsing;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.DerivativesApi.UnifiedMarginApi
{
    /// <inheritdoc cref="IBybitSocketClientUnifiedMarginApi" />
    internal class BybitSocketClientUnifiedMarginApi : SocketApiClient, IBybitSocketClientUnifiedMarginApi
    {
        private static readonly MessagePath _typePath = MessagePath.Get().Property("type");
        private static readonly MessagePath _opPath = MessagePath.Get().Property("op");

        internal BybitSocketClientUnifiedMarginApi(ILogger log, BybitSocketOptions options)
            : base(log, options.Environment.SocketBaseAddress.AppendPath("/unified/private/v3"), options, options.UnifiedMarginOptions)
        {
            KeepAliveInterval = TimeSpan.Zero;

            RegisterPeriodicQuery("Heartbeat", TimeSpan.FromSeconds(20), x => new BybitPingQuery(), x => { });
        }

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null) => baseAsset.ToUpperInvariant() + quoteAsset.ToUpperInvariant();

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new BybitAuthenticationProvider(credentials);

        /// <inheritdoc />
        public override string? GetListenerIdentifier(IMessageAccessor message)
        {
            var type = message.GetValue<string>(_typePath);
            if (string.Equals(type, "COMMAND_RESP", StringComparison.Ordinal)
                || string.Equals(type, "AUTH_RESP", StringComparison.Ordinal))
            {
                return type;
            }

            return message.GetValue<string>(_opPath);
        }

        /// <inheritdoc />
        protected override Task<Query?> GetAuthenticationRequestAsync(SocketConnection connection)
        {
            var expireTime = DateTimeConverter.ConvertToMilliseconds(DateTime.UtcNow.AddSeconds(30))!;
            var authProvider = (BybitAuthenticationProvider)AuthenticationProvider!;
            var key = authProvider.ApiKey;
            var sign = authProvider.Sign($"GET/realtime{expireTime}");

            return Task.FromResult<Query?>(new BybitUnifiedQuery("auth", new object[]
            {
                key,
                expireTime,
                sign
            }));
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(Action<DataEvent<IEnumerable<BybitUnifiedMarginPositionUpdate>>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitUnifiedSubscription<IEnumerable<BybitUnifiedMarginPositionUpdate>>(_logger, new[] { "user.position.unifiedAccount" }, handler, true);
            return await SubscribeAsync(subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(Action<DataEvent<IEnumerable<BybitDerivativesUserTradeUpdate>>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitUnifiedSubscription<IEnumerable<BybitDerivativesUserTradeUpdate>>(_logger, new[] { "user.execution.unifiedAccount" }, handler, true);
            return await SubscribeAsync(subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<IEnumerable<BybitUnifiedMarginOrderUpdate>>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitUnifiedSubscription<IEnumerable<BybitUnifiedMarginOrderUpdate>>(_logger, new[] { "user.order.unifiedAccount" }, handler, true);
            return await SubscribeAsync(subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(Action<DataEvent<BybitUnifiedMarginBalance>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitUnifiedSubscription<BybitUnifiedMarginBalance>(_logger, new[] { "user.wallet.unifiedAccount" }, handler, true);
            return await SubscribeAsync(subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToGreeksUpdatesAsync(Action<DataEvent<IEnumerable<BybitGreeksUpdate>>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitUnifiedSubscription<IEnumerable<BybitGreeksUpdate>>(_logger, new[] { "user.greeks.unifiedAccount" }, handler, true);
            return await SubscribeAsync(subscription, ct).ConfigureAwait(false);
        }
    }
}
