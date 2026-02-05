using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.V5;
using Bybit.Net.Objects.Models.V5;
using Bybit.Net.Objects.Options;
using Bybit.Net.Objects.Sockets;
using Bybit.Net.Objects.Sockets.Subscriptions;
using CryptoExchange.Net;
using CryptoExchange.Net.Clients;
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
    /// <inheritdoc cref="IBybitSocketClientBaseApi" />
    internal abstract class BybitSocketClientBaseApi : SocketApiClient, IBybitSocketClientBaseApi
    {
        /// <inheritdoc />
        public new BybitSocketOptions ClientOptions => (BybitSocketOptions)base.ClientOptions;

        /// <summary>
        /// Base endpoint
        /// </summary>
        protected readonly string _baseEndpoint;

        /// <summary>
        /// Address to connect to for public data
        /// </summary>
        protected readonly string _wsPublicAddress;

        protected override ErrorMapping ErrorMapping => BybitErrors.WebsocketErrors;

        internal BybitSocketClientBaseApi(ILogger log, BybitSocketOptions options, string baseEndpoint)
            : base(log, options.Environment.SocketBaseAddress, options, options.V5Options)
        {
            _baseEndpoint = baseEndpoint;
            // For demo trading the live environment should be used for market data
            _wsPublicAddress = options.Environment.Name == BybitEnvironment.DemoTrading.Name ? BybitEnvironment.Live.SocketBaseAddress : options.Environment.SocketBaseAddress;

            _clientName = "BybitSocketClientApi";

            UnhandledMessageExpected = true;
            KeepAliveInterval = TimeSpan.Zero;

            MessageSendSizeLimit = 21000;
        }

        protected override IMessageSerializer CreateSerializer() => new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(BybitExchange._serializerContext));

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
                => BybitExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverTime);

        /// <inheritdoc />
        public virtual Task<CallResult<UpdateSubscription>> SubscribeToOrderbookUpdatesAsync(string symbol, int depth, Action<DataEvent<BybitOrderbook>> updateHandler, CancellationToken ct = default)
            => SubscribeToOrderbookUpdatesAsync(new string[] { symbol }, depth, updateHandler, ct);

        /// <inheritdoc />
        public async virtual Task<CallResult<UpdateSubscription>> SubscribeToOrderbookUpdatesAsync(IEnumerable<string> symbols, int depth, Action<DataEvent<BybitOrderbook>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitOrderBookSubscription(_logger, this, symbols.Select(s => $"orderbook.{depth}.{s}").ToArray(), handler);
            return await SubscribeAsync(_wsPublicAddress.AppendPath(_baseEndpoint), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, KlineInterval interval, Action<DataEvent<BybitKlineUpdate[]>> handler, CancellationToken ct = default)
            => SubscribeToKlineUpdatesAsync(new string[] { symbol }, interval, handler, ct);

        /// <inheritdoc />
        public async virtual Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(IEnumerable<string> symbols, KlineInterval interval, Action<DataEvent<BybitKlineUpdate[]>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, BybitSpotSocketEvent<BybitKlineUpdate[]>>((receiveTime, originalData, data) =>
            {
                UpdateTimeOffset(data.Timestamp);

                handler(
                    new DataEvent<BybitKlineUpdate[]>(BybitExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(string.Equals(data.Type, "snapshot", StringComparison.Ordinal) ? SocketUpdateType.Snapshot : SocketUpdateType.Update)
                        .WithStreamId(data.Topic)
                        .WithSymbol(data.Topic.Substring(data.Topic.LastIndexOf('.') + 1))
                        .WithDataTimestamp(data.Timestamp, GetTimeOffset())
                    );
            });

            var subscription = new BybitSubscription<BybitKlineUpdate[]>(_logger, this, symbols.Select(x => $"kline.{EnumConverter.GetString(interval)}.{x}").ToArray(), internalHandler);
            return await SubscribeAsync(_wsPublicAddress.AppendPath(_baseEndpoint), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(string symbol, Action<DataEvent<BybitLiquidation>> handler, CancellationToken ct = default)
            => SubscribeToLiquidationUpdatesAsync(new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async virtual Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitLiquidation>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, BybitSpotSocketEvent<BybitLiquidation>>((receiveTime, originalData, data) =>
            {
                UpdateTimeOffset(data.Timestamp);

                handler(
                    new DataEvent<BybitLiquidation>(BybitExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(string.Equals(data.Type, "snapshot", StringComparison.Ordinal) ? SocketUpdateType.Snapshot : SocketUpdateType.Update)
                        .WithStreamId(data.Topic)
                        .WithSymbol(data.Data.Symbol)
                        .WithDataTimestamp(data.Timestamp, GetTimeOffset())
                    );
            });

            var subscription = new BybitSubscription<BybitLiquidation>(_logger, this, symbols.Select(x => $"liquidation.{x}").ToArray(), internalHandler);
            return await SubscribeAsync(_wsPublicAddress.AppendPath(_baseEndpoint), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual Task<CallResult<UpdateSubscription>> SubscribeToAllLiquidationUpdatesAsync(string symbol, Action<DataEvent<BybitLiquidationUpdate[]>> handler, CancellationToken ct = default)
            => SubscribeToAllLiquidationUpdatesAsync(new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async virtual Task<CallResult<UpdateSubscription>> SubscribeToAllLiquidationUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitLiquidationUpdate[]>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, BybitSpotSocketEvent<BybitLiquidationUpdate[]>>((receiveTime, originalData, data) =>
            {
                UpdateTimeOffset(data.Timestamp);

                handler(
                    new DataEvent<BybitLiquidationUpdate[]>(BybitExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(string.Equals(data.Type, "snapshot", StringComparison.Ordinal) ? SocketUpdateType.Snapshot : SocketUpdateType.Update)
                        .WithStreamId(data.Topic)
                        .WithSymbol(data.Data.First().Symbol)
                        .WithDataTimestamp(data.Timestamp, GetTimeOffset())
                    );
            });
            var subscription = new BybitSubscription<BybitLiquidationUpdate[]>(_logger, this, symbols.Select(x => $"allLiquidation.{x}").ToArray(), internalHandler);
            return await SubscribeAsync(_wsPublicAddress.AppendPath(_baseEndpoint), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual Task<CallResult<UpdateSubscription>> SubscribeToPriceLimitUpdatesAsync(string symbol, Action<DataEvent<BybitOrderPriceLimit>> handler, CancellationToken ct = default)
            => SubscribeToPriceLimitUpdatesAsync(new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async virtual Task<CallResult<UpdateSubscription>> SubscribeToPriceLimitUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitOrderPriceLimit>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, BybitSpotSocketEvent<BybitOrderPriceLimit>>((receiveTime, originalData, data) =>
            {
                UpdateTimeOffset(data.Timestamp);

                data.Data.Timestamp = data.Timestamp;
                handler(
                    new DataEvent<BybitOrderPriceLimit>(BybitExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(string.Equals(data.Type, "snapshot", StringComparison.Ordinal) ? SocketUpdateType.Snapshot : SocketUpdateType.Update)
                        .WithStreamId(data.Topic)
                        .WithSymbol(data.Data.Symbol)
                        .WithDataTimestamp(data.Timestamp, GetTimeOffset())
                    );
            });

            var subscription = new BybitSubscription<BybitOrderPriceLimit>(_logger, this, symbols.Select(x => $"priceLimit.{x}").ToArray(), internalHandler);
            return await SubscribeAsync(_wsPublicAddress.AppendPath(_baseEndpoint), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async virtual Task<CallResult<UpdateSubscription>> SubscribeToSystemStatusUpdatesAsync(Action<DataEvent<BybitSystemStatus[]>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, BybitSpotSocketEvent<BybitSystemStatus[]>>((receiveTime, originalData, data) =>
            {
                UpdateTimeOffset(data.Timestamp);

                handler(
                    new DataEvent<BybitSystemStatus[]>(BybitExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(string.Equals(data.Type, "snapshot", StringComparison.Ordinal) ? SocketUpdateType.Snapshot : SocketUpdateType.Update)
                        .WithStreamId(data.Topic)
                        .WithDataTimestamp(data.Timestamp, GetTimeOffset())
                    );
            });

            var subscription = new BybitSubscription<BybitSystemStatus[]>(_logger, this, ["system.status"], internalHandler);
            return await SubscribeAsync(_wsPublicAddress.AppendPath("/v5/public/misc/status"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual Task<CallResult<UpdateSubscription>> SubscribeToRpiOrderbookUpdatesAsync(string symbol, Action<DataEvent<BybitRpiOrderbook>> updateHandler, CancellationToken ct = default)
            => SubscribeToRpiOrderbookUpdatesAsync(new string[] { symbol }, updateHandler, ct);

        /// <inheritdoc />
        public async virtual Task<CallResult<UpdateSubscription>> SubscribeToRpiOrderbookUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitRpiOrderbook>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, BybitSpotSocketEvent<BybitRpiOrderbook>>((receiveTime, originalData, data) =>
            {
                UpdateTimeOffset(data.Timestamp);

                handler(
                    new DataEvent<BybitRpiOrderbook>(BybitExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(string.Equals(data.Type, "snapshot", StringComparison.Ordinal) ? SocketUpdateType.Snapshot : SocketUpdateType.Update)
                        .WithStreamId(data.Topic)
                        .WithSymbol(data.Data.Symbol)
                        .WithDataTimestamp(data.Timestamp, GetTimeOffset())
                    );
            });

            var subscription = new BybitSubscription<BybitRpiOrderbook>(_logger, this, symbols.Select(s => $"orderbook.rpi.{s}").ToArray(), internalHandler);
            return await SubscribeAsync(_wsPublicAddress.AppendPath(_baseEndpoint), subscription, ct).ConfigureAwait(false);
        }
    }
}
