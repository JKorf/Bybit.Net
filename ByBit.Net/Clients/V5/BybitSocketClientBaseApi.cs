using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using CryptoExchange.Net.Objects;
using Bybit.Net.Objects.Models.V5;
using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.V5;
using Bybit.Net.Objects.Options;
using CryptoExchange.Net.Objects.Sockets;
using Bybit.Net.Objects.Sockets.Subscriptions;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.Interfaces;
using System.Net.WebSockets;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects.Errors;

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


            UnhandledMessageExpected = true;
            KeepAliveInterval = TimeSpan.Zero;

            MessageSendSizeLimit = 21000;
        }

        protected override IByteMessageAccessor CreateAccessor(WebSocketMessageType type) => new SystemTextJsonByteMessageAccessor(SerializerOptions.WithConverters(BybitExchange._serializerContext));
        protected override IMessageSerializer CreateSerializer() => new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(BybitExchange._serializerContext));

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
                => BybitExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverTime);

        /// <inheritdoc />
        public virtual Task<CallResult<UpdateSubscription>> SubscribeToOrderbookUpdatesAsync(string symbol, int depth, Action<DataEvent<BybitOrderbook>> updateHandler, CancellationToken ct = default)
            => SubscribeToOrderbookUpdatesAsync(new string[] { symbol }, depth, updateHandler, ct);

        /// <inheritdoc />
        public async virtual Task<CallResult<UpdateSubscription>> SubscribeToOrderbookUpdatesAsync(IEnumerable<string> symbols, int depth, Action<DataEvent<BybitOrderbook>> updateHandler, CancellationToken ct = default)
        {
            var subscription = new BybitOrderBookSubscription(_logger, this, symbols.Select(s => $"orderbook.{depth}.{s}").ToArray(), updateHandler);
            return await SubscribeAsync(_wsPublicAddress.AppendPath(_baseEndpoint), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, KlineInterval interval, Action<DataEvent<BybitKlineUpdate[]>> handler, CancellationToken ct = default)
            => SubscribeToKlineUpdatesAsync(new string[] { symbol }, interval, handler, ct);

        /// <inheritdoc />
        public async virtual Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(IEnumerable<string> symbols, KlineInterval interval, Action<DataEvent<BybitKlineUpdate[]>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<BybitKlineUpdate[]>(_logger, this, symbols.Select(x => $"kline.{EnumConverter.GetString(interval)}.{x}").ToArray(), handler);
            return await SubscribeAsync(_wsPublicAddress.AppendPath(_baseEndpoint), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(string symbol, Action<DataEvent<BybitLiquidation>> handler, CancellationToken ct = default)
            => SubscribeToLiquidationUpdatesAsync(new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async virtual Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitLiquidation>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<BybitLiquidation>(_logger, this, symbols.Select(x => $"liquidation.{x}").ToArray(), handler);
            return await SubscribeAsync(_wsPublicAddress.AppendPath(_baseEndpoint), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual Task<CallResult<UpdateSubscription>> SubscribeToAllLiquidationUpdatesAsync(string symbol, Action<DataEvent<BybitLiquidationUpdate[]>> handler, CancellationToken ct = default)
            => SubscribeToAllLiquidationUpdatesAsync(new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async virtual Task<CallResult<UpdateSubscription>> SubscribeToAllLiquidationUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitLiquidationUpdate[]>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<BybitLiquidationUpdate[]>(_logger, this, symbols.Select(x => $"allLiquidation.{x}").ToArray(), handler);
            return await SubscribeAsync(_wsPublicAddress.AppendPath(_baseEndpoint), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual Task<CallResult<UpdateSubscription>> SubscribeToPriceLimitUpdatesAsync(string symbol, Action<DataEvent<BybitOrderPriceLimit>> handler, CancellationToken ct = default)
            => SubscribeToPriceLimitUpdatesAsync(new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async virtual Task<CallResult<UpdateSubscription>> SubscribeToPriceLimitUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitOrderPriceLimit>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<BybitOrderPriceLimit>(_logger, this, symbols.Select(x => $"priceLimit.{x}").ToArray(), 
                x => 
                { 
                    x.Data.Timestamp = x.DataTime ?? x.ReceiveTime; 
                    handler(x);
                });
            return await SubscribeAsync(_wsPublicAddress.AppendPath(_baseEndpoint), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async virtual Task<CallResult<UpdateSubscription>> SubscribeToSystemStatusUpdatesAsync(Action<DataEvent<BybitSystemStatus[]>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<BybitSystemStatus[]>(_logger, this, ["system.status"], handler);
            return await SubscribeAsync(_wsPublicAddress.AppendPath("/v5/public/misc/status"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual Task<CallResult<UpdateSubscription>> SubscribeToRpiOrderbookUpdatesAsync(string symbol, Action<DataEvent<BybitRpiOrderbook>> updateHandler, CancellationToken ct = default)
            => SubscribeToRpiOrderbookUpdatesAsync(new string[] { symbol }, updateHandler, ct);

        /// <inheritdoc />
        public async virtual Task<CallResult<UpdateSubscription>> SubscribeToRpiOrderbookUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitRpiOrderbook>> updateHandler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<BybitRpiOrderbook>(_logger, this, symbols.Select(s => $"orderbook.rpi.{s}").ToArray(), updateHandler);
            return await SubscribeAsync(_wsPublicAddress.AppendPath(_baseEndpoint), subscription, ct).ConfigureAwait(false);
        }
    }
}
