using Bybit.Net.Clients.MessageHandlers;
using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.V5;
using Bybit.Net.Objects.Models.V5;
using Bybit.Net.Objects.Options;
using Bybit.Net.Objects.Sockets;
using Bybit.Net.Objects.Sockets.Queries;
using Bybit.Net.Objects.Sockets.Subscriptions;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Converters.MessageParsing;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.Objects.Sockets;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.V5
{
    /// <inheritdoc cref="IBybitSocketClientSpotApi" />
    internal partial class BybitSocketClientSpotApi : BybitSocketClientBaseApi, IBybitSocketClientSpotApi
    {
        private static readonly MessagePath _reqIdPath = MessagePath.Get().Property("req_id");
        private static readonly MessagePath _topicPath = MessagePath.Get().Property("topic");

        internal BybitSocketClientSpotApi(ILogger logger, BybitSocketOptions options)
            : base(logger, options, "/v5/public/spot")
        {
            RegisterPeriodicQuery(
                "Heartbeat",
                TimeSpan.FromSeconds(20),
                x => new BybitQuery(this, "ping", null) { RequestTimeout = TimeSpan.FromSeconds(5) },
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

        public override ISocketMessageHandler CreateMessageConverter(WebSocketMessageType messageType) => new BybitSocketMessageHandler1();

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials) => new BybitAuthenticationProvider(credentials);

        public IBybitSocketClientSpotApiShared SharedClient => this;

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
            var internalHandler = new Action<DateTime, string?, BybitSpotSocketEvent<BybitSpotTickerUpdate>>((receiveTime, originalData, data) =>
            {
                handler(
                    new DataEvent<BybitSpotTickerUpdate>(data.Data, receiveTime, originalData)
                        .WithUpdateType(string.Equals(data.Type, "snapshot", StringComparison.Ordinal) ? SocketUpdateType.Snapshot : SocketUpdateType.Update)
                        .WithStreamId(data.Topic)
                        .WithSymbol(data.Data.Symbol)
                        .WithDataTimestamp(data.Timestamp)
                    );
            });

            var subscription = new BybitSubscription<BybitSpotTickerUpdate>(_logger, this, symbols.Select(x => "tickers." + x).ToArray(), internalHandler);
            return await SubscribeAsync(_wsPublicAddress.AppendPath(_baseEndpoint), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<BybitTrade[]>> handler, CancellationToken ct = default)
            => SubscribeToTradeUpdatesAsync(new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitTrade[]>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, BybitSpotSocketEvent<BybitTrade[]>>((receiveTime, originalData, data) =>
            {
                handler(
                    new DataEvent<BybitTrade[]>(data.Data, receiveTime, originalData)
                        .WithUpdateType(SocketUpdateType.Update)
                        .WithStreamId(data.Topic)
                        .WithSymbol(data.Data.First().Symbol)
                        .WithDataTimestamp(data.Timestamp)
                    );
            });

            var subscription = new BybitSubscription<BybitTrade[]>(_logger, this, symbols.Select(s => $"publicTrade.{s}").ToArray(), internalHandler);
            return await SubscribeAsync(_wsPublicAddress.AppendPath(_baseEndpoint), subscription, ct).ConfigureAwait(false);
        }

    }
}
