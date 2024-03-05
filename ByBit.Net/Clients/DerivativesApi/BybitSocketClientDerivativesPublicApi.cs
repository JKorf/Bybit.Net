using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.DerivativesApi;
using Bybit.Net.Objects.Models.Derivatives;
using Bybit.Net.Objects.Models.Socket.Derivatives;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.DerivativesApi
{
    /// <inheritdoc cref="IBybitSocketClientDerivativesPublicApi" />
    public class BybitSocketClientDerivativesPublicApi : SocketApiClient, IBybitSocketClientDerivativesPublicApi
    {
        private static readonly MessagePath _reqIdPath = MessagePath.Get().Property("req_id");
        private static readonly MessagePath _topicPath = MessagePath.Get().Property("topic");

        internal BybitSocketClientDerivativesPublicApi(ILogger log, BybitSocketOptions options)
            : base(log, options.Environment.SocketBaseAddress, options, options.DerivativesPublicOptions)
        {
            UnhandledMessageExpected = true;
            KeepAliveInterval = TimeSpan.Zero;
            HandleMessageBeforeConfirmation = true;

            RegisterPeriodicQuery("Heartbeat", TimeSpan.FromSeconds(20), x => new BybitQuery("ping", null), x => { });
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
        public Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(StreamDerivativesCategory category, string symbol, int limit, Action<DataEvent<BybitDerivativesOrderBookEntry>> handler, CancellationToken ct = default)
            => SubscribeToOrderBooksUpdatesAsync(category, new string[] { symbol }, limit, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderBooksUpdatesAsync(StreamDerivativesCategory category, IEnumerable<string> symbols, int limit, Action<DataEvent<BybitDerivativesOrderBookEntry>> handler, CancellationToken ct = default)
        {
            limit.ValidateIntValues(nameof(limit), 1, 25, 50, 100, 200);

            var subscription = new BybitSubscription<BybitDerivativesOrderBookEntry>(_logger, symbols.Select(x => $"orderbook.{limit}." + x).ToArray(), handler);
            return await SubscribeAsync(BaseAddress + $"/{EnumConverter.GetString(category)}/public/v3", subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(StreamDerivativesCategory category, string symbol, Action<DataEvent<IEnumerable<BybitDerivativesTradeUpdate>>> handler, CancellationToken ct = default)
            => SubscribeToTradesUpdatesAsync(category, new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTradesUpdatesAsync(StreamDerivativesCategory category, IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BybitDerivativesTradeUpdate>>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<IEnumerable<BybitDerivativesTradeUpdate>>(_logger, symbols.Select(x => $"publicTrade." + x).ToArray(), handler);
            return await SubscribeAsync(BaseAddress + $"/{EnumConverter.GetString(category)}/public/v3", subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(StreamDerivativesCategory category, string symbol, Action<DataEvent<BybitDerivativesTicker>> handler, CancellationToken ct = default)
            => SubscribeToTickersUpdatesAsync(category, new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTickersUpdatesAsync(StreamDerivativesCategory category, IEnumerable<string> symbols, Action<DataEvent<BybitDerivativesTicker>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<BybitDerivativesTicker>(_logger, symbols.Select(x => $"tickers." + x).ToArray(), handler);
            return await SubscribeAsync(BaseAddress + $"/{EnumConverter.GetString(category)}/public/v3", subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(StreamDerivativesCategory category, string symbol, KlineInterval interval, Action<DataEvent<IEnumerable<BybitDerivativesKlineUpdate>>> handler, CancellationToken ct = default)
            => SubscribeToKlinesUpdatesAsync(category, new string[] { symbol }, interval, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToKlinesUpdatesAsync(StreamDerivativesCategory category, IEnumerable<string> symbols, KlineInterval interval, Action<DataEvent<IEnumerable<BybitDerivativesKlineUpdate>>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<IEnumerable<BybitDerivativesKlineUpdate>>(_logger, symbols.Select(x => "kline." + JsonConvert.SerializeObject(interval, new KlineIntervalConverter(false)) + "." + x).ToArray(), handler);
            return await SubscribeAsync(BaseAddress + $"/{EnumConverter.GetString(category)}/public/v3", subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new BybitAuthenticationProvider(credentials);
    }
}
