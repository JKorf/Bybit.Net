using Bybit.Net.Clients.MessageHandlers;
using Bybit.Net.Interfaces.Clients.V5;
using Bybit.Net.Objects.Models.V5;
using Bybit.Net.Objects.Options;
using Bybit.Net.Objects.Sockets;
using Bybit.Net.Objects.Sockets.Queries;
using Bybit.Net.Objects.Sockets.Subscriptions;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.MessageParsing;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
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
        private readonly string _wsPublicAddress;

        internal BybitSocketClientSpreadApi(ILogger log, BybitSocketOptions options)
            : base(log, options.Environment.SocketBaseAddress, options, options.V5Options)
        {
            KeepAliveInterval = TimeSpan.Zero; // Server doesn't respond to ping frames
            _wsPublicAddress = options.Environment.Name == BybitEnvironment.DemoTrading.Name ? BybitEnvironment.Live.SocketBaseAddress : options.Environment.SocketBaseAddress;

            _clientName = "BybitSocketClientApi";

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

        protected override IMessageSerializer CreateSerializer() => new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(BybitExchange._serializerContext));
        public override ISocketMessageHandler CreateMessageConverter(WebSocketMessageType messageType) => new BybitSocketMessageHandler2();

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
            => BybitExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverTime);

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BybitSpreadTickerUpdate>> handler, CancellationToken ct = default)
            => SubscribeToTickerUpdatesAsync(new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitSpreadTickerUpdate>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, BybitSpotSocketEvent<BybitSpreadTickerUpdate>>((receiveTime, originalData, data) =>
            {
                UpdateTimeOffset(data.Timestamp);

                handler(
                    new DataEvent<BybitSpreadTickerUpdate>(BybitExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(string.Equals(data.Type, "snapshot", StringComparison.Ordinal) ? SocketUpdateType.Snapshot : SocketUpdateType.Update)
                        .WithStreamId(data.Topic)
                        .WithSymbol(data.Data.Symbol)
                        .WithDataTimestamp(data.Timestamp, GetTimeOffset())
                    );
            });

            var subscription = new BybitOptionsSubscription<BybitSpreadTickerUpdate>(_logger, symbols.Select(x => $"tickers.{x}").ToArray(), internalHandler);
            return await SubscribeAsync(_wsPublicAddress.AppendPath("/v5/public/spread"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<BybitTrade[]>> handler, CancellationToken ct = default)
            => SubscribeToTradeUpdatesAsync(new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitTrade[]>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, BybitSpotSocketEvent<BybitTrade[]>>((receiveTime, originalData, data) =>
            {
                UpdateTimeOffset(data.Timestamp);

                handler(
                    new DataEvent<BybitTrade[]>(BybitExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(string.Equals(data.Type, "snapshot", StringComparison.Ordinal) ? SocketUpdateType.Snapshot : SocketUpdateType.Update)
                        .WithStreamId(data.Topic)
                        .WithSymbol(data.Data.First().Symbol)
                        .WithDataTimestamp(data.Timestamp, GetTimeOffset())
                    );
            });

            var subscription = new BybitOptionsSubscription<BybitTrade[]>(_logger, symbols.Select(s => $"publicTrade.{s}").ToArray(), internalHandler);
            return await SubscribeAsync(_wsPublicAddress.AppendPath("/v5/public/spread"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual Task<CallResult<UpdateSubscription>> SubscribeToOrderbookUpdatesAsync(string symbol, int depth, Action<DataEvent<BybitOrderbook>> updateHandler, CancellationToken ct = default)
            => SubscribeToOrderbookUpdatesAsync(new string[] { symbol }, depth, updateHandler, ct);

        /// <inheritdoc />
        public async virtual Task<CallResult<UpdateSubscription>> SubscribeToOrderbookUpdatesAsync(IEnumerable<string> symbols, int depth, Action<DataEvent<BybitOrderbook>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, BybitSpotSocketEvent<BybitOrderbook>>((receiveTime, originalData, data) =>
            {
                UpdateTimeOffset(data.Timestamp);

                handler(
                    new DataEvent<BybitOrderbook>(BybitExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(string.Equals(data.Type, "snapshot", StringComparison.Ordinal) ? SocketUpdateType.Snapshot : SocketUpdateType.Update)
                        .WithStreamId(data.Topic)
                        .WithSymbol(data.Data.Symbol)
                        .WithDataTimestamp(data.Timestamp, GetTimeOffset())
                    );
            });

            var subscription = new BybitOptionsSubscription<BybitOrderbook>(_logger, symbols.Select(s => $"orderbook.{depth}.{s}").ToArray(), internalHandler);
            return await SubscribeAsync(_wsPublicAddress.AppendPath("/v5/public/spread"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials) => new BybitAuthenticationProvider(credentials);
    }
}
