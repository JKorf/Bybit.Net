﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using CryptoExchange.Net.Objects;
using Bybit.Net.Objects.Models.V5;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Bybit.Net.Interfaces.Clients.V5;
using Bybit.Net.Objects.Options;
using CryptoExchange.Net.Objects.Sockets;
using Bybit.Net.Objects.Sockets.Subscriptions;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net;
using CryptoExchange.Net.SharedApis;

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

        internal BybitSocketClientBaseApi(ILogger log, BybitSocketOptions options, string baseEndpoint)
            : base(log, options.Environment.SocketBaseAddress, options, options.V5Options)
        {
            _baseEndpoint = baseEndpoint;

            UnhandledMessageExpected = true;
            KeepAliveInterval = TimeSpan.Zero;
        }

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
                => BybitExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverTime);

        /// <inheritdoc />
        public virtual Task<CallResult<UpdateSubscription>> SubscribeToOrderbookUpdatesAsync(string symbol, int depth, Action<DataEvent<BybitOrderbook>> updateHandler, CancellationToken ct = default)
            => SubscribeToOrderbookUpdatesAsync(new string[] { symbol }, depth, updateHandler, ct);

        /// <inheritdoc />
        public async virtual Task<CallResult<UpdateSubscription>> SubscribeToOrderbookUpdatesAsync(IEnumerable<string> symbols, int depth, Action<DataEvent<BybitOrderbook>> updateHandler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<BybitOrderbook>(_logger, symbols.Select(s => $"orderbook.{depth}.{s}").ToArray(), updateHandler);
            return await SubscribeAsync(BaseAddress + _baseEndpoint, subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, KlineInterval interval, Action<DataEvent<IEnumerable<BybitKlineUpdate>>> handler, CancellationToken ct = default)
            => SubscribeToKlineUpdatesAsync(new string[] { symbol }, interval, handler, ct);

        /// <inheritdoc />
        public async virtual Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(IEnumerable<string> symbols, KlineInterval interval, Action<DataEvent<IEnumerable<BybitKlineUpdate>>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<IEnumerable<BybitKlineUpdate>>(_logger, symbols.Select(x => $"kline.{EnumConverter.GetString(interval)}.{x}").ToArray(), handler);
            return await SubscribeAsync(BaseAddress + _baseEndpoint, subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(string symbol, Action<DataEvent<BybitLiquidation>> handler, CancellationToken ct = default)
            => SubscribeToLiquidationUpdatesAsync(new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async virtual Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitLiquidation>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<BybitLiquidation>(_logger, symbols.Select(x => $"liquidation.{x}").ToArray(), handler);
            return await SubscribeAsync(BaseAddress + _baseEndpoint, subscription, ct).ConfigureAwait(false);
        }
    }
}
