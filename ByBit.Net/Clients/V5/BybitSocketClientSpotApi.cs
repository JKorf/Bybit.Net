using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.V5;
using Bybit.Net.Objects.Models.V5;
using Bybit.Net.Objects.Options;
using Bybit.Net.Objects.Sockets.Queries;
using Bybit.Net.Objects.Sockets.Subscriptions;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets.MessageParsing;
using CryptoExchange.Net.Sockets.MessageParsing.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.V5
{
    /// <inheritdoc cref="IBybitSocketClientSpotApi" />
    public class BybitSocketClientSpotApi : BybitSocketClientBaseApi, IBybitSocketClientSpotApi
    {
        private static readonly MessagePath _reqIdPath = MessagePath.Get().Property("req_id");
        private static readonly MessagePath _topicPath = MessagePath.Get().Property("topic");

        internal BybitSocketClientSpotApi(ILogger logger, BybitSocketOptions options)
            : base(logger, options, "/v5/public/spot")
        {
            RegisterPeriodicQuery("Heartbeat", TimeSpan.FromSeconds(20), x => new BybitQuery("ping", null), x => { });
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials) => new BybitAuthenticationProvider(credentials);

        /// <inheritdoc />
        public override string? GetListenerIdentifier(IMessageAccessor message)
        {
            var reqId = message.GetValue<string>(_reqIdPath);
            if (reqId != null)
                return reqId;

            return message.GetValue<string>(_topicPath);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BybitSpotTickerUpdate>> handler, CancellationToken ct = default)
            => SubscribeToTickerUpdatesAsync(new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitSpotTickerUpdate>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<BybitSpotTickerUpdate>(_logger, symbols.Select(x => "tickers." + x).ToArray(), handler);
            return await SubscribeAsync(BaseAddress + _baseEndpoint, subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToLeveragedTokenKlineUpdatesAsync(string symbol, KlineInterval interval, Action<DataEvent<IEnumerable<BybitKlineUpdate>>> handler, CancellationToken ct = default)
            => SubscribeToLeveragedTokenKlineUpdatesAsync(new string[] { symbol }, interval, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToLeveragedTokenKlineUpdatesAsync(IEnumerable<string> symbols, KlineInterval interval, Action<DataEvent<IEnumerable<BybitKlineUpdate>>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<IEnumerable<BybitKlineUpdate>>(_logger, symbols.Select(x => $"kline_lt.{EnumConverter.GetString(interval)}.{x}").ToArray(), handler);
            return await SubscribeAsync(BaseAddress + _baseEndpoint, subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToLeveragedTokenTickerUpdatesAsync(string symbol, Action<DataEvent<BybitLeveragedTokenTicker>> handler, CancellationToken ct = default)
            => SubscribeToLeveragedTokenTickerUpdatesAsync(new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToLeveragedTokenTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitLeveragedTokenTicker>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<BybitLeveragedTokenTicker>(_logger, symbols.Select(x => $"tickers_lt.{x}").ToArray(), handler);
            return await SubscribeAsync(BaseAddress + _baseEndpoint, subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToLeveragedTokenNavUpdatesAsync(string symbol, Action<DataEvent<BybitLeveragedTokenNav>> handler, CancellationToken ct = default)
            => SubscribeToLeveragedTokenNavUpdatesAsync(new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToLeveragedTokenNavUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitLeveragedTokenNav>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<BybitLeveragedTokenNav>(_logger, symbols.Select(x => $"lt.{x}").ToArray(), handler);
            return await SubscribeAsync(BaseAddress + _baseEndpoint, subscription, ct).ConfigureAwait(false);
        }
    }
}
