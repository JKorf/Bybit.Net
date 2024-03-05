using Bybit.Net.Interfaces.Clients.V5;
using Bybit.Net.Objects.Models.V5;
using Bybit.Net.Objects.Options;
using Bybit.Net.Objects.Sockets.Queries;
using Bybit.Net.Objects.Sockets.Subscriptions;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.MessageParsing;
using CryptoExchange.Net.Sockets.MessageParsing.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.V5
{
    /// <inheritdoc cref="IBybitSocketClientPrivateApi" />
    public class BybitSocketClientPrivateApi : SocketApiClient, IBybitSocketClientPrivateApi
    {
        private static readonly MessagePath _reqIdPath = MessagePath.Get().Property("req_id");
        private static readonly MessagePath _topicPath = MessagePath.Get().Property("topic");

        internal BybitSocketClientPrivateApi(ILogger logger, BybitSocketOptions options)
            : base(logger, options.Environment.SocketBaseAddress, options, options.V5Options)
        {
            UnhandledMessageExpected = true;
            KeepAliveInterval = TimeSpan.Zero;

            RegisterPeriodicQuery("Heartbeat", TimeSpan.FromSeconds(20), x => new BybitQuery("ping", null), x => { });
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials) => new BybitAuthenticationProvider(credentials);

        /// <inheritdoc />
        protected override Query? GetAuthenticationRequest()
        {
            var expireTime = DateTimeConverter.ConvertToMilliseconds(DateTime.UtcNow.AddSeconds(30))!;
            var authProvider = (BybitAuthenticationProvider)AuthenticationProvider!;
            var key = authProvider.GetApiKey();
            var sign = authProvider.Sign($"GET/realtime{expireTime}");

            return new BybitQuery("auth", new object[]
            {
                key,
                expireTime,
                sign
            });
        }

        /// <inheritdoc />
        public override string? GetListenerIdentifier(IMessageAccessor message)
        {
            var reqId = message.GetValue<string>(_reqIdPath);
            if (reqId != null)
                return reqId;

            return message.GetValue<string>(_topicPath);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(Action<DataEvent<IEnumerable<BybitPositionUpdate>>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<IEnumerable<BybitPositionUpdate>>(_logger, new[] { "position" }, handler, true);
            return await SubscribeAsync(BaseAddress.AppendPath("/v5/private"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(Action<DataEvent<IEnumerable<BybitUserTradeUpdate>>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<IEnumerable<BybitUserTradeUpdate>>(_logger, new[] { "execution" }, handler, true);
            return await SubscribeAsync(BaseAddress.AppendPath("/v5/private"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<IEnumerable<BybitOrderUpdate>>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<IEnumerable<BybitOrderUpdate>>(_logger, new[] { "order" }, handler, true);
            return await SubscribeAsync(BaseAddress.AppendPath("/v5/private"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToWalletUpdatesAsync(Action<DataEvent<IEnumerable<BybitBalance>>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<IEnumerable<BybitBalance>>(_logger, new[] { "wallet" }, handler, true);
            return await SubscribeAsync(BaseAddress.AppendPath("/v5/private"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToGreekUpdatesAsync(Action<DataEvent<IEnumerable<BybitGreeks>>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<IEnumerable<BybitGreeks>>(_logger, new[] { "greeks" }, handler, true);
            return await SubscribeAsync(BaseAddress.AppendPath("/v5/private"), subscription, ct).ConfigureAwait(false);
        }
    }
}
