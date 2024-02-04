using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Bybit.Net.Objects.Models.Socket.Spot;
using Bybit.Net.Enums;
using Bybit.Net.Converters;
using Bybit.Net.Interfaces.Clients.SpotApi.v3;
using Bybit.Net.Objects.Models.Spot.v3;
using Bybit.Net.Objects.Options;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Authentication;
using Bybit.Net.Objects.Sockets.Queries;
using CryptoExchange.Net.Sockets.MessageParsing.Interfaces;
using CryptoExchange.Net.Sockets.MessageParsing;
using Bybit.Net.Objects.Sockets.Subscriptions;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Converters;

namespace Bybit.Net.Clients.SpotApi.v3
{
    /// <inheritdoc cref="IBybitSocketClientSpotApiV3"/>
    public class BybitSocketClientSpotApiV3 : SocketApiClient, IBybitSocketClientSpotApiV3
    {
        private static readonly MessagePath _reqIdPath = MessagePath.Get().Property("req_id");
        private static readonly MessagePath _topicPath = MessagePath.Get().Property("topic");

        internal BybitSocketClientSpotApiV3(ILogger logger, BybitSocketOptions options)
            : base(logger, options.Environment.SocketBaseAddress, options, options.SpotV3Options)
        {
            KeepAliveInterval = TimeSpan.Zero;

            RegisterPeriodicQuery("Heartbeat", TimeSpan.FromSeconds(20), x => new BybitQuery("ping", null), x => { });
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new BybitAuthenticationProvider(credentials);

        /// <inheritdoc />
        public override string? GetListenerIdentifier(IMessageAccessor message)
        {
            var reqId = message.GetValue<string>(_reqIdPath);
            if (reqId != null)
                return reqId;

            return message.GetValue<string>(_topicPath);
        }

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
        public async Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<BybitSpotTradeUpdate>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<BybitSpotTradeUpdate>(_logger, new[] { "trade." + symbol }, handler);
            return await SubscribeAsync(BaseAddress.AppendPath("/spot/public/v3"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, Action<DataEvent<BybitSpotOrderBookUpdate>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<BybitSpotOrderBookUpdate>(_logger, new[] { "orderbook.40." + symbol }, handler);
            return await SubscribeAsync(BaseAddress.AppendPath("/spot/public/v3"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, KlineInterval interval, Action<DataEvent<BybitSpotKlineUpdate>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<BybitSpotKlineUpdate>(_logger, new[] { $"kline.{KlineIntervalSpotConverter.ToString(interval)}.{symbol}" }, handler);
            return await SubscribeAsync(BaseAddress.AppendPath("/spot/public/v3"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToBookPriceUpdatesAsync(string symbol, Action<DataEvent<BybitSpotBookPriceV3>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<BybitSpotBookPriceV3>(_logger, new[] { $"bookticker.{symbol}" }, handler);
            return await SubscribeAsync(BaseAddress.AppendPath("/spot/public/v3"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BybitSpotTickerUpdate>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<BybitSpotTickerUpdate>(_logger, new[] { $"tickers.{symbol}" }, handler);
            return await SubscribeAsync(BaseAddress.AppendPath("/spot/public/v3"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToAccountUpdatesAsync(Action<DataEvent<BybitSpotAccountUpdate>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<BybitSpotAccountUpdate>(_logger, new[] { "outboundAccountInfo" }, handler, true);
            return await SubscribeAsync(BaseAddress.AppendPath("/spot/private/v3"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToUserOrdersUpdatesAsync(Action<DataEvent<BybitSpotOrderUpdate>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<BybitSpotOrderUpdate>(_logger, new[] { "order" }, handler, true);
            return await SubscribeAsync(BaseAddress.AppendPath("/spot/private/v3"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToUserStopOrdersUpdatesAsync(Action<DataEvent<BybitSpotStopOrderUpdate>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<BybitSpotStopOrderUpdate>(_logger, new[] { "stopOrder" }, handler, true);
            return await SubscribeAsync(BaseAddress.AppendPath("/spot/private/v3"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToUserTradesUpdatesAsync(Action<DataEvent<BybitSpotUserTradeUpdate>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<BybitSpotUserTradeUpdate>(_logger, new[] { "ticketInfo" }, handler, true);
            return await SubscribeAsync(BaseAddress.AppendPath("/spot/private/v3"), subscription, ct).ConfigureAwait(false);
        }
    }
}
