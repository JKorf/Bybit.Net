using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.DerivativesApi;
using Bybit.Net.Objects;
using Bybit.Net.Objects.Internal.Socket;
using Bybit.Net.Objects.Models;
using Bybit.Net.Objects.Models.Derivatives;
using Bybit.Net.Objects.Models.Socket.Derivatives;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Logging;
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

namespace Bybit.Net.Clients.DerivativesApi
{
    /// <inheritdoc cref="IBybitSocketClientDerivativesPublicStreams" />
    public class BybitSocketClientDerivativesPublicStreams : SocketApiClient, IBybitSocketClientDerivativesPublicStreams
    {
        private readonly BybitSocketClientOptions _options;

        internal BybitSocketClientDerivativesPublicStreams(Log log, BybitSocketClientOptions options)
            : base(log, options, options.DerivativesPublicStreamsOptions)
        {
            _options = options;

            ContinueOnQueryResponse = true;
            UnhandledMessageExpected = true;
            KeepAliveInterval = TimeSpan.Zero;

            SendPeriodic("Ping", options.DerivativesPublicStreamsOptions.PingInterval, (connection) =>
            {
                return new BybitRequestMessage() { Operation = "ping" };
            });
            AddGenericHandler("Heartbeat", (evnt) => { });
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(StreamDerivativesCategory category, string symbol, int limit, Action<DataEvent<BybitDerivativesOrderBookEntry>> snapshotHandler, Action<DataEvent<BybitDerivativesOrderBookEntry>> deltaHandler, CancellationToken ct = default)
            => SubscribeToOrderBooksUpdatesAsync(category, new string[] { symbol }, limit, snapshotHandler, deltaHandler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderBooksUpdatesAsync(StreamDerivativesCategory category, IEnumerable<string> symbols, int limit, Action<DataEvent<BybitDerivativesOrderBookEntry>> snapshotHandler, Action<DataEvent<BybitDerivativesOrderBookEntry>> deltaHandler, CancellationToken ct = default)
        {
            limit.ValidateIntValues(nameof(limit), 1, 25, 50, 100, 200);

            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var type = data.Data["type"]?.ToString();
                var internalData = data.Data["data"];
                if (internalData == null || type == null || string.IsNullOrWhiteSpace(type))
                    return;

                var desResult = Deserialize<BybitDerivativesOrderBookEntry>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitOrderBookEntry)} object: " + desResult.Error);
                    return;
                }

                if (type.Equals("snapshot", StringComparison.Ordinal))
                {
                    snapshotHandler(data.As(desResult.Data, desResult.Data.Symbol));
                }
                else
                {
                    deltaHandler(data.As(desResult.Data, desResult.Data.Symbol));
                }
            });

            var topic = $"orderbook.{limit}.";
            return await SubscribeAsync(
                _options.DerivativesPublicStreamsOptions.GetPublicAddress(category),
                new BybitDerivativesRequestMessage() { Operation = "subscribe", CustomisedId = Guid.NewGuid().ToString(), Parameters = symbols.Select(s => topic + s).ToArray() },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(StreamDerivativesCategory category, string symbol, Action<DataEvent<IEnumerable<BybitDerivativesTradeUpdate>>> handler, CancellationToken ct = default)
            => SubscribeToTradesUpdatesAsync(category, new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTradesUpdatesAsync(StreamDerivativesCategory category, IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BybitDerivativesTradeUpdate>>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = Deserialize<IEnumerable<BybitDerivativesTradeUpdate>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitDerivativesTradeUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, desResult.Data.First().Symbol));
            });

            return await SubscribeAsync(
                 _options.DerivativesPublicStreamsOptions.GetPublicAddress(category),
                new BybitDerivativesRequestMessage() { Operation = "subscribe", CustomisedId = Guid.NewGuid().ToString(), Parameters = symbols.Select(s => "publicTrade." + s).ToArray() },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(StreamDerivativesCategory category, string symbol, Action<DataEvent<BybitDerivativesTicker>> snapshotHandler, Action<DataEvent<BybitDerivativesTickerUpdate>> updateHandler, CancellationToken ct = default)
            => SubscribeToTickersUpdatesAsync(category, new string[] { symbol }, snapshotHandler, updateHandler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTickersUpdatesAsync(StreamDerivativesCategory category, IEnumerable<string> symbols, Action<DataEvent<BybitDerivativesTicker>> snapshotHandler, Action<DataEvent<BybitDerivativesTickerUpdate>> updateHandler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                if (data.Data["type"]?.ToString() == "delta")
                {
                    var desResult = Deserialize<BybitDerivativesTickerUpdate>(internalData);
                    if (!desResult)
                    {
                        _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitDerivativesTickerUpdate)} object: " + desResult.Error);
                        return;
                    }

                    updateHandler(data.As(desResult.Data, desResult.Data.Symbol));
                }
                else
                {
                    var desResult = Deserialize<BybitDerivativesTicker>(internalData);
                    if (!desResult)
                    {
                        _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitDerivativesTicker)} object: " + desResult.Error);
                        return;
                    }

                    snapshotHandler(data.As(desResult.Data, desResult.Data.Symbol));
                }
            });

            return await SubscribeAsync(
                 _options.DerivativesPublicStreamsOptions.GetPublicAddress(category),
                new BybitDerivativesRequestMessage() { Operation = "subscribe", CustomisedId = Guid.NewGuid().ToString(), Parameters = symbols.Select(s => "tickers." + s).ToArray() },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(StreamDerivativesCategory category, string symbol, KlineInterval interval, Action<DataEvent<IEnumerable<BybitDerivativesKlineUpdate>>> handler, CancellationToken ct = default)
            => SubscribeToKlinesUpdatesAsync(category, new string[] { symbol }, interval, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToKlinesUpdatesAsync(StreamDerivativesCategory category, IEnumerable<string> symbols, KlineInterval interval, Action<DataEvent<IEnumerable<BybitDerivativesKlineUpdate>>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = Deserialize<IEnumerable<BybitDerivativesKlineUpdate>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitDerivativesKlineUpdate)} object: " + desResult.Error);
                    return;
                }

                var topic = data.Data["topic"]!.ToString();
                handler(data.As(desResult.Data, topic.Split('.').Last()));
            });

            return await SubscribeAsync(
                _options.DerivativesPublicStreamsOptions.GetPublicAddress(category),
                new BybitDerivativesRequestMessage() { Operation = "subscribe", CustomisedId = Guid.NewGuid().ToString(), Parameters = symbols.Select(s => "kline." + JsonConvert.SerializeObject(interval, new KlineIntervalConverter(false)) + "." + s).ToArray() },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new BybitAuthenticationProvider(credentials);

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

            var operation = data["op"]?.ToString();
            if (operation != "subscribe")
                return false;

            var id = ((BybitDerivativesRequestMessage)request).CustomisedId;
            if (!id.Equals(data["req_id"]?.ToString()))
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
                if (requestParams.Any(p => (string)p == mainTopic + ".*"))
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
