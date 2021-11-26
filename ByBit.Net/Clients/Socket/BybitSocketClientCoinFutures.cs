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

namespace Bybit.Net.Clients.Socket
{
    /// <inheritdoc />
    public class BybitSocketClientCoinFutures: SocketClient
    {
        /// <summary>
        /// Create a new instance of BybitSocketClientFutures using the default options
        /// </summary>
        public BybitSocketClientCoinFutures() : this(BybitSocketClientFuturesOptions.Default)
        {
        }

        /// <summary>
        /// Create a new instance of BybitSocketClientFutures using provided options
        /// </summary>
        /// <param name="options">The options to use for this client</param>
        public BybitSocketClientCoinFutures(BybitSocketClientFuturesOptions options) : base("Bybit[Futures]", options, options.ApiCredentials == null ? null : new BybitAuthenticationProvider(options.ApiCredentials))
        {
            if (options == null)
                throw new ArgumentException("Cant pass null options, use empty constructor for default");

            ContinueOnQueryResponse = true;
            UnhandledMessageExpected = true;

            SendPeriodic(TimeSpan.FromSeconds(30), (connection) => new BybitRequestMessage() { Operation = "ping" });
            AddGenericHandler("Heartbeat", (evnt) => { });
        }

        /// <summary>
        /// Set the API key and secret
        /// </summary>
        /// <param name="apiKey">The api key</param>
        /// <param name="apiSecret">The api secret</param>
         public void SetApiCredentials(string apiKey, string apiSecret)
        {
            SetAuthenticationProvider(new BybitAuthenticationProvider(new ApiCredentials(apiKey, apiSecret)));
        }

        /// <summary>
        /// set the default options used when creating a client without specifying options
        /// </summary>
        /// <param name="newDefaultOptions"></param>
        public static void SetDefaultOptions(BybitSocketClientFuturesOptions newDefaultOptions)
        {
            BybitSocketClientFuturesOptions.Default = newDefaultOptions;
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

                var desResult = Deserialize<IEnumerable<BybitTradeUpdate>>(internalData);
                if (!desResult)
                {
                    log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitTradeUpdate)} object: " + desResult.Error);
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
                var innerData = data.Data["type"]?.ToString() == "delta" ? data.Data["data"]?["update"]?[0]: data.Data["data"];
                if (innerData == null)
                    return;

                var desResult = Deserialize<BybitTickerUpdate>(innerData);
                if (!desResult)
                {
                    log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitTickerUpdate)} object: " + desResult.Error);
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
                        log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitOrderBookEntry)} object: " + desResult.Error);
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
                        log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitOrderBookEntry)} object: " + desResult.Error);
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
                    log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitInsuranceUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, desResult.Data.First().Asset));
            });
            return await SubscribeAsync(
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

                var desResult = Deserialize<IEnumerable<BybitKlineUpdate>>(internalData);
                if (!desResult)
                {
                    log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitInsuranceUpdate)} object: " + desResult.Error);
                    return;
                }

                var topic = data.Data["topic"]!.ToString();
                handler(data.As(desResult.Data, topic.Split('.').Last()));
            });
            return await SubscribeAsync(
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

                var desResult = Deserialize<BybitLiquidationUpdate>(internalData);
                if (!desResult)
                {
                    log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitLiquidationUpdate)} object: " + desResult.Error);
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
                    log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitPositionUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            });
            return await SubscribeAsync(
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
                    log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitUserTradeUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            });
            return await SubscribeAsync(
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

                var desResult = Deserialize<IEnumerable<BybitOrderUpdate>>(internalData);
                if (!desResult)
                {
                    log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitOrderUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            });
            return await SubscribeAsync(
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
                    log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitStopOrderUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            });
            return await SubscribeAsync(
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

                var desResult = Deserialize<IEnumerable<BybitBalanceUpdate>>(internalData);
                if (!desResult)
                {
                    log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitBalanceUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            });
            return await SubscribeAsync(
                new BybitRequestMessage() { Operation = "subscribe", Parameters = new[] { "wallet" } },
                null, true, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        protected override async Task<CallResult<bool>> AuthenticateSocketAsync(SocketConnection socketConnection)
        {
            if (authProvider == null)
                return new CallResult<bool>(false, new NoApiCredentialsError());

            var expireTime = DateTimeConverter.ConvertToMilliseconds(DateTime.UtcNow.AddSeconds(5));
            var key = authProvider.Credentials.Key!.GetString();
            var sign = authProvider.Sign($"GET/realtime{expireTime}");

            var authRequest = new BybitRequestMessage() { 
                Operation = "auth",
                Parameters = new object[]
                {
                    key,
                    expireTime,
                    sign
                }
            };

            var result = false;
            var error = "";
            await socketConnection.SendAndWaitAsync(authRequest, ClientOptions.SocketResponseTimeout, data =>
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
            return new CallResult<bool>(result, result ? null: new ServerError(error));
        }

        /// <inheritdoc />
        protected override bool HandleQueryResponse<T>(SocketConnection socketConnection, object request, JToken data, out CallResult<T>? callResult)
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

            callResult = new CallResult<object>(default, null);
            return data["success"]?.Value<bool>() == true;
        }

        /// <inheritdoc />
        protected override bool MessageMatchesHandler(JToken message, object request)
        {
            if (message.Type != JTokenType.Object)
                return false;

            var topic = message["topic"]?.ToString();
            if (topic == null)
                return false;

            var requestParams = ((BybitRequestMessage)request).Parameters;
            if (requestParams.Any(p => topic == p.ToString()))
                return true;

            var split = topic.Split('.');
            var symbol = split.Last();
            var mainTopic = topic.Substring(0, topic.Length - symbol.Length - 1);

            if (requestParams.Any(p => (string)p == (mainTopic + ".*")))
                return true;

            return false;
        }

        /// <inheritdoc />
        protected override bool MessageMatchesHandler(JToken message, string identifier)
        {
            if(identifier == "Heartbeat")
            {
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
            await connection.SendAndWaitAsync(message, ClientOptions.SocketResponseTimeout, data =>
            {
                if (data.Type != JTokenType.Object)
                    return false;

                var operation = data["request"]?["op"]?.ToString();
                var args = data["request"]?["args"].Select(p => p.ToString()).ToList();
                if (operation != "unsubscribe")
                    return false;

                if (requestParams.Any(p => !args.Contains(p)))
                    return false;

                result =  data["success"]?.Value<bool>() == true;
                return true;
            }).ConfigureAwait(false);
            return result;
        }
    }
}
