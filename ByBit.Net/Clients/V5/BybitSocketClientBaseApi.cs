using Bybit.Net.Objects;
using Bybit.Net.Objects.Internal.Socket;
using CryptoExchange.Net;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Objects;
using Bybit.Net.Objects.Models.V5;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Bybit.Net.Interfaces.Clients.V5;
using Bybit.Net.Objects.Options;

namespace Bybit.Net.Clients.V5
{
    /// <inheritdoc cref="IBybitSocketClientBaseApi" />
    public abstract class BybitSocketClientBaseApi : SocketApiClient, IBybitSocketClientBaseApi
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

            ContinueOnQueryResponse = true;
            UnhandledMessageExpected = true;
            KeepAliveInterval = TimeSpan.Zero;
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<IEnumerable<BybitTrade>>> handler, CancellationToken ct = default)
            => SubscribeToTradeUpdatesAsync(new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BybitTrade>>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = Deserialize<IEnumerable<BybitTrade>>(internalData);
                if (!desResult)
                {
                    _logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(BybitTrade)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, desResult.Data.First().Symbol));
            });

            return await SubscribeAsync(
                 BaseAddress + _baseEndpoint,
                new BybitV5RequestMessage("subscribe", symbols.Select(s => "publicTrade." + s).ToArray(), ExchangeHelpers.NextId().ToString()),
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToOrderbookUpdatesAsync(string symbol, int depth, Action<DataEvent<BybitOrderbook>> snapshotHandler, Action<DataEvent<BybitOrderbook>> updateHandler, CancellationToken ct = default)
            => SubscribeToOrderbookUpdatesAsync(new string[] { symbol }, depth, snapshotHandler, updateHandler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderbookUpdatesAsync(IEnumerable<string> symbols, int depth, Action<DataEvent<BybitOrderbook>> snapshotHandler, Action<DataEvent<BybitOrderbook>> updateHandler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = Deserialize<BybitOrderbook>(internalData);
                if (!desResult)
                {
                    _logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(BybitOrderbook)} object: " + desResult.Error);
                    return;
                }

                if (data.Data["type"]?.ToString() == "snapshot")
                    snapshotHandler(data.As(desResult.Data, desResult.Data.Symbol));
                else
                    updateHandler(data.As(desResult.Data, desResult.Data.Symbol));
            });

            return await SubscribeAsync(
                 BaseAddress + _baseEndpoint,
                new BybitV5RequestMessage("subscribe", symbols.Select(s => $"orderbook.{depth}.{s}").ToArray(), ExchangeHelpers.NextId().ToString()),
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, KlineInterval interval, Action<DataEvent<IEnumerable<BybitKlineUpdate>>> handler, CancellationToken ct = default)
            => SubscribeToKlineUpdatesAsync(new string[] { symbol }, interval, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(IEnumerable<string> symbols, KlineInterval interval, Action<DataEvent<IEnumerable<BybitKlineUpdate>>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = Deserialize<IEnumerable<BybitKlineUpdate>>(internalData);
                if (!desResult)
                {
                    _logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(BybitKlineUpdate)} object: " + desResult.Error);
                    return;
                }

                var topic = data.Data["topic"]!.ToString();
                handler(data.As(desResult.Data, topic.Substring(topic.IndexOf('.') + 1)));
            });

            return await SubscribeAsync(
                 BaseAddress + _baseEndpoint,
                new BybitV5RequestMessage("subscribe", symbols.Select(s => $"kline.{EnumConverter.GetString(interval)}.{s}").ToArray(), ExchangeHelpers.NextId().ToString()),
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(string symbol, Action<DataEvent<BybitLiquidation>> handler, CancellationToken ct = default)
            => SubscribeToLiquidationUpdatesAsync(new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitLiquidation>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = Deserialize<BybitLiquidation>(internalData);
                if (!desResult)
                {
                    _logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(BybitLiquidation)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, data.Data["topic"]!.ToString().Split('.').Last()));
            });

            return await SubscribeAsync(
                 BaseAddress + _baseEndpoint,
                new BybitV5RequestMessage("subscribe", symbols.Select(s => $"liquidation.{s}").ToArray(), ExchangeHelpers.NextId().ToString()),
                null, false, internalHandler, ct).ConfigureAwait(false);
        }
    }
}
