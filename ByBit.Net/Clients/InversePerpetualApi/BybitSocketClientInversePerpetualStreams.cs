using Bybit.Net.Objects.Internal.Socket;
using Bybit.Net.Objects.Models;
using Bybit.Net.Objects.Models.Socket;
using Bybit.Net.Objects;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Net.Logging;
using Bybit.Net.Enums;
using Bybit.Net.Converters;
using Bybit.Net.Interfaces.Clients.InversePerpetualApi;
using CryptoExchange.Net.Converters;

namespace Bybit.Net.Clients.InversePerpetualApi
{
    /// <inheritdoc cref="IBybitSocketClientInversePerpetualStreams" />
    public class BybitSocketClientInversePerpetualStreams : SocketApiClient, IBybitSocketClientInversePerpetualStreams
    {
        private readonly BybitSocketClientOptions _options;

        internal BybitSocketClientInversePerpetualStreams(Log log, BybitSocketClientOptions options)
            : base(log, options, options.InversePerpetualStreamsOptions)
        {
            _log = log;
            _options = options;

            ContinueOnQueryResponse = true;
            UnhandledMessageExpected = true;
            KeepAliveInterval = TimeSpan.Zero;

            SendPeriodic("Ping", options.InversePerpetualStreamsOptions.PingInterval, (connection) =>
            {
                return new BybitRequestMessage() { Operation = "ping" };
            });
            AddGenericHandler("Heartbeat", (evnt) => { });
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new BybitAuthenticationProvider(credentials);

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

                var desResult = Deserialize<IEnumerable<BybitTradeUpdate>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitTradeUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, desResult.Data.First().Symbol));
            });
            return await SubscribeAsync(
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
                var innerData = data.Data["type"]?.ToString() == "delta" ? data.Data["data"]?["update"]?[0] : data.Data["data"];
                if (innerData == null)
                    return;

                var desResult = Deserialize<BybitTickerUpdate>(innerData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitTickerUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, desResult.Data.Symbol));

            });
            return await SubscribeAsync(
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
                    var desResult = Deserialize<BybitDeltaUpdate<BybitOrderBookEntry>>(internalData);
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
                    var desResult = Deserialize<IEnumerable<BybitOrderBookEntry>>(internalData);
                    if (!desResult)
                    {
                        _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitOrderBookEntry)} object: " + desResult.Error);
                        return;
                    }

                    snapshotHandler(data.As(desResult.Data, desResult.Data.First().Symbol));
                }
            });
            var topic = limit == 25 ? "orderBookL2_25." : "orderBook_200.100ms.";
            return await SubscribeAsync(
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

                var desResult = Deserialize<IEnumerable<BybitInsuranceUpdate>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitInsuranceUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, desResult.Data.First().Asset));
            });
            return await SubscribeAsync(
                new BybitRequestMessage() { Operation = "subscribe", Parameters = symbols.Select(s => "insurance." + s).ToArray() },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToKlinesUpdatesAsync(KlineInterval interval, Action<DataEvent<IEnumerable<BybitKlineUpdate>>> handler, CancellationToken ct = default)
            => SubscribeToKlineUpdatesAsync(new string[] { "*" }, interval, handler, ct);

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
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitInsuranceUpdate)} object: " + desResult.Error);
                    return;
                }

                var topic = data.Data["topic"]!.ToString();
                handler(data.As(desResult.Data, topic.Substring(topic.IndexOf('.') + 1)));
            });
            return await SubscribeAsync(
                new BybitRequestMessage() { Operation = "subscribe", Parameters = symbols.Select(s => "klineV2." + JsonConvert.SerializeObject(interval, new KlineIntervalConverter(false)) + "." + s).ToArray() },
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

                var desResult = Deserialize<BybitLiquidationUpdate>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitLiquidationUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, desResult.Data.Symbol));
            });
            return await SubscribeAsync(
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

                var desResult = Deserialize<IEnumerable<BybitPositionUpdate>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitPositionUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            });
            return await SubscribeAsync(_options.InversePerpetualStreamsOptions.BaseAddressAuthenticated,
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

                var desResult = Deserialize<IEnumerable<BybitUserTradeUpdate>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitUserTradeUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            });
            return await SubscribeAsync(_options.InversePerpetualStreamsOptions.BaseAddressAuthenticated,
                new BybitRequestMessage() { Operation = "subscribe", Parameters = new[] { "execution" } },
                null, true, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<IEnumerable<BybitInverseOrderUpdate>>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = Deserialize<IEnumerable<BybitInverseOrderUpdate>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitInverseOrderUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            });
            return await SubscribeAsync(_options.InversePerpetualStreamsOptions.BaseAddressAuthenticated,
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

                var desResult = Deserialize<IEnumerable<BybitStopOrderUpdate>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitStopOrderUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            });
            return await SubscribeAsync(_options.InversePerpetualStreamsOptions.BaseAddressAuthenticated,
                new BybitRequestMessage() { Operation = "subscribe", Parameters = new[] { "stop_order" } },
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

                var desResult = Deserialize<IEnumerable<BybitBalanceUpdate>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitBalanceUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            });
            return await SubscribeAsync(_options.InversePerpetualStreamsOptions.BaseAddressAuthenticated,
                new BybitRequestMessage() { Operation = "subscribe", Parameters = new[] { "wallet" } },
                null, true, internalHandler, ct).ConfigureAwait(false);
        }


        /// <inheritdoc />
        protected override async Task<CallResult<bool>> AuthenticateSocketAsync(SocketConnection socketConnection)
        {
            if (socketConnection.ApiClient.AuthenticationProvider == null)
                return new CallResult<bool>(new NoApiCredentialsError());

            var expireTime = DateTimeConverter.ConvertToMilliseconds(DateTime.UtcNow.AddSeconds(30))!;
            var key = socketConnection.ApiClient.AuthenticationProvider.Credentials.Key!.GetString();
            var sign = socketConnection.ApiClient.AuthenticationProvider.Sign($"GET/realtime{expireTime}");

            var authRequest = new BybitRequestMessage()
            {
                Operation = "auth",
                Parameters = new object[]
                {
                    key,
                    expireTime,
                    sign
                }
            };

            var result = false;
            var error = "unspecified error";
            await socketConnection.SendAndWaitAsync(authRequest, Options.SocketResponseTimeout, null, data =>
            {
                if (data.Type != JTokenType.Object)
                    return false;

                var operation = data["request"]?["op"]?.ToString();
                var args = data["request"]?["args"].Select(p => p.ToString()).ToList();
                if (operation != "auth")
                    return false;

                result = data["success"]?.Value<bool>() == true;
                error = data["ret_msg"]?.ToString();
                return true;
                
            }).ConfigureAwait(false);
            return result ? new CallResult<bool>(result) : new CallResult<bool>(new ServerError(error));
        }

        /// <inheritdoc />
        protected override bool HandleQueryResponse<T>(SocketConnection socketConnection, object request, JToken data, out CallResult<T> callResult)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        protected override bool HandleSubscriptionResponse(SocketConnection socketConnection, SocketSubscription subscription, object request, JToken data, out CallResult<object>? callResult)
        {
            callResult = null;
            if (data.Type != JTokenType.Object)
                return false;
                        
            var requestParams = ((BybitRequestMessage)request).Parameters;
            var operation = data["request"]?["op"]?.ToString();
            var args = data["request"]?["args"].Select(p => p.ToString()).ToList();
            if (operation != "subscribe")
                return false;

            if (requestParams.Any(p => !args.Contains(p)))
                return false;

            var success = data["success"]?.Value<bool>() == true;
            if (success)
                callResult = new CallResult<object>(true);
            else
                callResult = new CallResult<object>(new ServerError(data["ret_msg"]!.ToString()));
            return true;            
        }

        /// <inheritdoc />
        protected override bool MessageMatchesHandler(SocketConnection socketConnection, JToken message, object request)
        {
            if (message.Type != JTokenType.Object)
                return false;

            var topic = message["topic"]?.ToString();
            if (topic == null)
                return false;

            var requestParams = ((BybitRequestMessage)request).Parameters;
            if (requestParams.Any(p => topic == p.ToString()))
                return true;

            if (topic.Contains('.'))
            {
                // Some subscriptions have topics like orderbook.ETHUSDT
                // Split on `.` to get the topic and symbol
                var split = topic.Split('.');
                var symbol = split.Last();
                if (symbol.Length == 0)
                    return false;

                var mainTopic = topic.Substring(0, topic.Length - symbol.Length - 1);
                if (requestParams.Any(p => (string)p == (mainTopic + ".*")))
                    return true;
            }

            return false;
        }

        /// <inheritdoc />
        protected override bool MessageMatchesHandler(SocketConnection socketConnection, JToken message, string identifier)
        {
            if (identifier == "Heartbeat")
            {
                if (message.Type != JTokenType.Object)
                    return false;

                var ret = message["ret_msg"];
                if (ret == null)
                    return false;

                var isPing = ret.ToString() == "pong";
                if (!isPing)
                    return false;

                return true;
            }

            if (identifier == "AccountInfo")
            {
                if (message.Type != JTokenType.Array)
                    return false;

                var updateType = ((JArray)message)[0]["e"]?.ToString();
                if (updateType == null)
                    return false;

                return updateType == "outboundAccountInfo" || updateType == "stop_executionReport" || updateType == "executionReport" || updateType == "order" || updateType == "ticketInfo";
            }

            return false;
        }

        /// <inheritdoc />
        protected override async Task<bool> UnsubscribeAsync(SocketConnection connection, SocketSubscription subscriptionToUnsub)
        {
            var requestParams = ((BybitRequestMessage)subscriptionToUnsub.Request!).Parameters;
            var message = new BybitRequestMessage { Operation = "unsubscribe", Parameters = requestParams };

            var result = false;
            await connection.SendAndWaitAsync(message, Options.SocketResponseTimeout, null, data =>
            {
                if (data.Type != JTokenType.Object)
                    return false;

                var operation = data["request"]?["op"]?.ToString();
                var args = data["request"]?["args"].Select(p => p.ToString()).ToList();
                if (operation != "unsubscribe")
                    return false;

                if (requestParams.Any(p => !args.Contains(p)))
                    return false;

                result = data["success"]?.Value<bool>() == true;
                return true;
            }).ConfigureAwait(false);
            return result;
        }
    }
}
