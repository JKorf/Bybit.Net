using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Internal.Socket;
using Bybit.Net.Objects.Models;
using Bybit.Net.Objects.Models.Socket;
using Bybit.Net;
using Bybit.Net.Objects;
using Bybit.Net.Objects.Models;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Net.Logging;
using Bybit.Net.Interfaces.Clients.InversePerpetual;

namespace Bybit.Net.Clients.Socket
{
    /// <inheritdoc />
    public class BybitSocketClientInversePerpetual: SocketSubClient, IBybitSocketClientInversePerpetual
    {
        private readonly Log _log;
        private readonly BybitSocketClient _baseClient;
        private readonly BybitSocketClientOptions _options;

        /// <summary>
        /// Create a new instance of BybitSocketClientFutures using provided options
        /// </summary>
        /// <param name="options">The options to use for this client</param>
        public BybitSocketClientInversePerpetual(Log log, BybitSocketClient baseClient, BybitSocketClientOptions options)
            : base(options.OptionsInversePerpetual, options.OptionsInversePerpetual.ApiCredentials == null ? null : new BybitAuthenticationProvider(options.OptionsInversePerpetual.ApiCredentials))
        {
            _log = log;
            _options = options;
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTradesUpdatesAsync(Action<DataEvent<IEnumerable<BybitTradeUpdate>>> handler, CancellationToken ct = default)
            => SubscribeToTradeUpdatesAsync(new string[] { "*" }, handler, ct);

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<IEnumerable<BybitTradeUpdate>>> handler, CancellationToken ct = default)
            => SubscribeToTradeUpdatesAsync(new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BybitTradeUpdate>>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = _baseClient.DeserializeInternal<IEnumerable<BybitTradeUpdate>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitTradeUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, desResult.Data.First().Symbol));
            });
            return await _baseClient.SubscribeInternalAsync(this,
                new BybitRequestMessage() { Operation = "subscribe", Parameters = symbols.Select(s => "trade." + s).ToArray() },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTickersUpdatesAsync(Action<DataEvent<BybitTickerUpdate>> handler, CancellationToken ct = default)
            => SubscribeToTickerUpdatesAsync(new string[] { "*" }, handler, ct);

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BybitTickerUpdate>> handler, CancellationToken ct = default)
            => SubscribeToTickerUpdatesAsync(new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitTickerUpdate>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var innerData = data.Data["type"]?.ToString() == "delta" ? data.Data["data"]?["update"]?[0]: data.Data["data"];
                if (innerData == null)
                    return;

                var desResult = _baseClient.DeserializeInternal<BybitTickerUpdate>(innerData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitTickerUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, desResult.Data.Symbol));
                
            });
            return await _baseClient.SubscribeInternalAsync(this,
                new BybitRequestMessage() { Operation = "subscribe", Parameters = symbols.Select(s => "instrument_info.100ms." + s).ToArray() },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToOrderBooksUpdatesAsync(int limit, Action<DataEvent<IEnumerable<BybitOrderBookEntry>>> snapshotHandler, Action<DataEvent<BybitDeltaUpdate<BybitOrderBookEntry>>> updateHandler, CancellationToken ct = default)
            => SubscribeToOrderBookUpdatesAsync(new string[] { "*" }, limit, snapshotHandler, updateHandler, ct);

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, int limit, Action<DataEvent<IEnumerable<BybitOrderBookEntry>>> snapshotHandler, Action<DataEvent<BybitDeltaUpdate<BybitOrderBookEntry>>> updateHandler, CancellationToken ct = default)
            => SubscribeToOrderBookUpdatesAsync(new string[] { symbol }, limit, snapshotHandler, updateHandler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(
            IEnumerable<string> symbols, 
            int limit,
            Action<DataEvent<IEnumerable<BybitOrderBookEntry>>> snapshotHandler, 
            Action<DataEvent<BybitDeltaUpdate<BybitOrderBookEntry>>> updateHandler,
            CancellationToken ct = default)
        {
            limit.ValidateIntValues(nameof(limit), 25, 200);

            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                if (data.Data["type"]?.ToString() == "delta")
                {
                    var desResult = _baseClient.DeserializeInternal<BybitDeltaUpdate<BybitOrderBookEntry>>(internalData);
                    if (!desResult)
                    {
                        _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitOrderBookEntry)} object: " + desResult.Error);
                        return;
                    }

                    string symbol = desResult.Data.Insert.FirstOrDefault()?.Symbol ?? desResult.Data.Update.FirstOrDefault()?.Symbol ?? desResult.Data.Delete.First().Symbol;
                    updateHandler(data.As(desResult.Data, symbol));
                }
                else
                {
                    var desResult = _baseClient.DeserializeInternal<IEnumerable<BybitOrderBookEntry>>(internalData);
                    if (!desResult)
                    {
                        _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitOrderBookEntry)} object: " + desResult.Error);
                        return;
                    }

                    snapshotHandler(data.As(desResult.Data, desResult.Data.First().Symbol));
                }
            });
            var topic = limit == 25 ? "orderBookL2_25." : "orderBook_200.100ms.";
            return await _baseClient.SubscribeInternalAsync(this,
                new BybitRequestMessage() { Operation = "subscribe", Parameters = symbols.Select(s => topic + s).ToArray() },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToInsurancesUpdatesAsync(Action<DataEvent<IEnumerable<BybitInsuranceUpdate>>> handler, CancellationToken ct = default)
            => SubscribeToInsuranceUpdatesAsync(new string[] { "*" }, handler, ct);

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToInsuranceUpdatesAsync(string symbol, Action<DataEvent<IEnumerable<BybitInsuranceUpdate>>> handler, CancellationToken ct = default)
            => SubscribeToInsuranceUpdatesAsync(new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToInsuranceUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BybitInsuranceUpdate>>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = _baseClient.DeserializeInternal<IEnumerable<BybitInsuranceUpdate>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitInsuranceUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, desResult.Data.First().Asset));
            });
            return await _baseClient.SubscribeInternalAsync(this,
                new BybitRequestMessage() { Operation = "subscribe", Parameters = symbols.Select(s => "insurance." + s).ToArray() },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToKlinesUpdatesAsync(Action<DataEvent<IEnumerable<BybitKlineUpdate>>> handler, CancellationToken ct = default)
            => SubscribeToKlineUpdatesAsync(new string[] { "*" }, handler, ct);

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, Action<DataEvent<IEnumerable<BybitKlineUpdate>>> handler, CancellationToken ct = default)
            => SubscribeToKlineUpdatesAsync(new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BybitKlineUpdate>>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = _baseClient.DeserializeInternal<IEnumerable<BybitKlineUpdate>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitInsuranceUpdate)} object: " + desResult.Error);
                    return;
                }

                var topic = data.Data["topic"]!.ToString();
                handler(data.As(desResult.Data, topic.Split('.').Last()));
            });
            return await _baseClient.SubscribeInternalAsync(this,
                new BybitRequestMessage() { Operation = "subscribe", Parameters = symbols.Select(s => "klineV2.1." + s).ToArray() },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToLiquidationsUpdatesAsync(Action<DataEvent<BybitLiquidationUpdate>> handler, CancellationToken ct = default)
            => SubscribeToLiquidationUpdatesAsync(new string[] { "*" }, handler, ct);

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(string symbol, Action<DataEvent<BybitLiquidationUpdate>> handler, CancellationToken ct = default)
            => SubscribeToLiquidationUpdatesAsync(new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitLiquidationUpdate>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = _baseClient.DeserializeInternal<BybitLiquidationUpdate>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitLiquidationUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, desResult.Data.Symbol));
            });
            return await _baseClient.SubscribeInternalAsync(this,
                new BybitRequestMessage() { Operation = "subscribe", Parameters = symbols.Select(s => "liquidation." + s).ToArray() },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(Action<DataEvent<IEnumerable<BybitPositionUpdate>>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = _baseClient.DeserializeInternal<IEnumerable<BybitPositionUpdate>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitPositionUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            });
            return await _baseClient.SubscribeInternalAsync(this, _options.OptionsInversePerpetual.BaseAddressAuthenticated,
                new BybitRequestMessage() { Operation = "subscribe", Parameters = new[] { "position" } },
                null, true, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(Action<DataEvent<IEnumerable<BybitUserTradeUpdate>>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = _baseClient.DeserializeInternal<IEnumerable<BybitUserTradeUpdate>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitUserTradeUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            });
            return await _baseClient.SubscribeInternalAsync(this, _options.OptionsInversePerpetual.BaseAddressAuthenticated,
                new BybitRequestMessage() { Operation = "subscribe", Parameters = new[] { "execution" } },
                null, true, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<IEnumerable<BybitOrderUpdate>>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = _baseClient.DeserializeInternal<IEnumerable<BybitOrderUpdate>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitOrderUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            });
            return await _baseClient.SubscribeInternalAsync(this, _options.OptionsInversePerpetual.BaseAddressAuthenticated,
                new BybitRequestMessage() { Operation = "subscribe", Parameters = new[] { "order" } },
                null, true, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToStopOrderUpdatesAsync(Action<DataEvent<IEnumerable<BybitStopOrderUpdate>>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = _baseClient.DeserializeInternal<IEnumerable<BybitStopOrderUpdate>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitStopOrderUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            });
            return await _baseClient.SubscribeInternalAsync(this, _options.OptionsInversePerpetual.BaseAddressAuthenticated,
                new BybitRequestMessage() { Operation = "subscribe", Parameters = new[] { "order" } },
                null, true, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(Action<DataEvent<IEnumerable<BybitBalanceUpdate>>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = _baseClient.DeserializeInternal<IEnumerable<BybitBalanceUpdate>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitBalanceUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));   
            });
            return await _baseClient.SubscribeInternalAsync(this, _options.OptionsInversePerpetual.BaseAddressAuthenticated,
                new BybitRequestMessage() { Operation = "subscribe", Parameters = new[] { "wallet" } },
                null, true, internalHandler, ct).ConfigureAwait(false);
        }
    }
}
