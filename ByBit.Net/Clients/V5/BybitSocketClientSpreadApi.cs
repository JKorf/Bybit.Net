using Bybit.Net.Interfaces.Clients.V5;
using Bybit.Net.Objects.Models.V5;
using Bybit.Net.Objects.Options;
using Bybit.Net.Objects.Sockets.Queries;
using Bybit.Net.Objects.Sockets.Subscriptions;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.MessageParsing;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.V5
{
    /// <inheritdoc cref="IBybitSocketClientSpreadApi" />
    internal partial class BybitSocketClientSpreadApi : SocketApiClient, IBybitSocketClientSpreadApi
    {
        private static readonly MessagePath _typePath = MessagePath.Get().Property("type");
        private static readonly MessagePath _successPath = MessagePath.Get().Property("data").Property("successTopics");
        private static readonly MessagePath _failPath = MessagePath.Get().Property("data").Property("failTopics");
        private static readonly MessagePath _topicPath = MessagePath.Get().Property("topic");
        private static readonly MessagePath _opPath = MessagePath.Get().Property("op");

        private readonly string _wsPublicAddress;

        internal BybitSocketClientSpreadApi(ILogger log, BybitSocketOptions options)
            : base(log, options.Environment.SocketBaseAddress, options, options.V5Options)
        {
            KeepAliveInterval = TimeSpan.Zero; // Server doesn't respond to ping frames
            _wsPublicAddress = options.Environment.Name == BybitEnvironment.DemoTrading.Name ? BybitEnvironment.Live.SocketBaseAddress : options.Environment.SocketBaseAddress;

            RegisterPeriodicQuery(
                "Heartbeat",
                TimeSpan.FromSeconds(20),
                x => new BybitPingQuery(),
                (connection, result) =>
                {
                    if (result.Error?.ErrorType == ErrorType.Timeout)
                    {
                        // Ping timeout, reconnect
                        _logger.LogWarning("[Sckt {SocketId}] Ping response timeout, reconnecting", connection.SocketId);
                        _ = connection.TriggerReconnectAsync();
                    }
                });
        }

        protected override IByteMessageAccessor CreateAccessor(WebSocketMessageType type) => new SystemTextJsonByteMessageAccessor(SerializerOptions.WithConverters(BybitExchange._serializerContext));
        protected override IMessageSerializer CreateSerializer() => new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(BybitExchange._serializerContext));

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
            => BybitExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverTime);

        /// <inheritdoc />
        public override string? GetListenerIdentifier(IMessageAccessor message)
        {
            var type = message.GetValue<string>(_typePath);
            if (string.Equals(type, "COMMAND_RESP", StringComparison.Ordinal))
            {
                var result = new List<string?>();
                var success = message.GetValues<string>(_successPath);
                if (success == null)
                    return null;

                result.AddRange(success);
                var fails = message.GetValues<string>(_failPath)!;
                result.AddRange(fails);
                return "resp" + string.Join("-", result.OrderBy(s => s));
            }

            var op = message.GetValue<string>(_opPath);
            if (string.Equals(op, "pong", StringComparison.Ordinal))
                return "pong";

            return message.GetValue<string>(_topicPath);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BybitSpreadTickerUpdate>> handler, CancellationToken ct = default)
            => SubscribeToTickerUpdatesAsync(new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitSpreadTickerUpdate>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitOptionsSubscription<BybitSpreadTickerUpdate>(_logger, symbols.Select(x => $"tickers.{x}").ToArray(), handler);
            return await SubscribeAsync(_wsPublicAddress.AppendPath("/v5/public/spread"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<BybitTrade[]>> handler, CancellationToken ct = default)
            => SubscribeToTradeUpdatesAsync(new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitTrade[]>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitOptionsSubscription<BybitTrade[]>(_logger, symbols.Select(s => $"publicTrade.{s}").ToArray(), handler);
            return await SubscribeAsync(_wsPublicAddress.AppendPath("/v5/public/spread"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual Task<CallResult<UpdateSubscription>> SubscribeToOrderbookUpdatesAsync(string symbol, int depth, Action<DataEvent<BybitOrderbook>> updateHandler, CancellationToken ct = default)
            => SubscribeToOrderbookUpdatesAsync(new string[] { symbol }, depth, updateHandler, ct);

        /// <inheritdoc />
        public async virtual Task<CallResult<UpdateSubscription>> SubscribeToOrderbookUpdatesAsync(IEnumerable<string> symbols, int depth, Action<DataEvent<BybitOrderbook>> updateHandler, CancellationToken ct = default)
        {
            var subscription = new BybitOptionsSubscription<BybitOrderbook>(_logger, symbols.Select(s => $"orderbook.{depth}.{s}").ToArray(), updateHandler);
            return await SubscribeAsync(_wsPublicAddress.AppendPath("/v5/public/spread"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials) => new BybitAuthenticationProvider(credentials);
    }
}
