using Bybit.Net.Objects.Internal.Socket;
using Bybit.Net.Objects;
using CryptoExchange.Net;
using System;
using System.Collections.Generic;
using CryptoExchange.Net.Objects;
using System.Threading.Tasks;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json.Linq;
using System.Linq;
using Bybit.Net.Interfaces.Clients;
using Newtonsoft.Json;
using System.Threading;
using Bybit.Net.Objects.Models.Socket.Spot;
using Bybit.Net.Interfaces.Clients.UsdPerpetualApi;
using Bybit.Net.Interfaces.Clients.SpotApi;
using Bybit.Net.Interfaces.Clients.InversePerpetualApi;
using Bybit.Net.Clients.SpotApi;
using Bybit.Net.Clients.InversePerpetualApi;
using Bybit.Net.Clients.UsdPerpetualApi;

namespace Bybit.Net.Clients
{
    /// <inheritdoc cref="IBybitSocketClient" />
    public class BybitSocketClient: BaseSocketClient, IBybitSocketClient
    {
        /// <inheritdoc />
        public IBybitSocketClientUsdPerpetualStreams UsdPerpetualStreams { get; }
        /// <inheritdoc />
        public IBybitSocketClientInversePerpetualStreams InversePerpetualStreams { get; }
        /// <inheritdoc />
        public IBybitSocketClientSpotStreams SpotStreams { get; }

        /// <inheritdoc />
        public IBybitSocketClientCopyTradingStreams CopyTrading { get; }

        /// <summary>
        /// Create a new instance of BybitSocketClientFutures using the default options
        /// </summary>
        public BybitSocketClient() : this(BybitSocketClientOptions.Default)
        {
        }

        /// <summary>
        /// Create a new instance of BybitSocketClientFutures using provided options
        /// </summary>
        /// <param name="options">The options to use for this client</param>
        public BybitSocketClient(BybitSocketClientOptions options) : base("Bybit", options)
        {
            if (options == null)
                throw new ArgumentException("Cant pass null options, use empty constructor for default");

            ContinueOnQueryResponse = true;
            UnhandledMessageExpected = true;
            KeepAliveInterval = TimeSpan.Zero;

            UsdPerpetualStreams = AddApiClient(new BybitSocketClientUsdPerpetualStreams(log, this, options));
            InversePerpetualStreams = AddApiClient(new BybitSocketClientInversePerpetualStreams(log, this, options));
            SpotStreams = AddApiClient(new BybitSocketClientSpotStreams(log, this, options));
            CopyTrading = AddApiClient(new BybitSocketClientCopyTradingStreams(log, this, options));

            SendPeriodic("Ping", options.PingInterval, (connection) => {
                if(connection.ApiClient.GetType() == typeof(BybitSocketClientSpotStreams))
                    return new BybitSpotPing() { Ping = DateTimeConverter.ConvertToMilliseconds(DateTime.UtcNow)!.Value };
                else
                    return new BybitFuturesRequestMessage() { Operation = "ping" };
            });
            AddGenericHandler("Heartbeat", (evnt) => { });
        }

        /// <summary>
        /// Set the default options to be used when creating new clients
        /// </summary>
        /// <param name="options"></param>
        public static void SetDefaultOptions(BybitSocketClientOptions options)
        {
            BybitSocketClientOptions.Default = options;
        }

        internal CallResult<T> DeserializeInternal<T>(JToken obj, JsonSerializer? serializer = null, int? requestId = null)
            => Deserialize<T>(obj, serializer, requestId);

        internal Task<CallResult<UpdateSubscription>> SubscribeInternalAsync<T>(SocketApiClient apiClient, object? request, string? identifier, bool authenticated, Action<DataEvent<T>> dataHandler, CancellationToken ct)
        {
            return SubscribeAsync(apiClient, request, identifier, authenticated, dataHandler, ct);
        }

        internal Task<CallResult<UpdateSubscription>> SubscribeInternalAsync<T>(SocketApiClient apiClient, string url, object? request, string? identifier, bool authenticated, Action<DataEvent<T>> dataHandler, CancellationToken ct)
        {
            return SubscribeAsync(apiClient, url, request, identifier, authenticated, dataHandler, ct);
        }

        internal Task<CallResult<T>> QueryInternalAsync<T>(SocketApiClient apiClient, object request, bool authenticated)
            => QueryAsync<T>(apiClient, request, authenticated);

        /// <inheritdoc />
        protected override async Task<CallResult<bool>> AuthenticateSocketAsync(SocketConnection socketConnection)
        {
            if (socketConnection.ApiClient.AuthenticationProvider == null)
                return new CallResult<bool>(new NoApiCredentialsError());

            var expireTime = DateTimeConverter.ConvertToMilliseconds(DateTime.UtcNow.AddSeconds(5))!;
            var key = socketConnection.ApiClient.AuthenticationProvider.Credentials.Key!.GetString();
            var sign = socketConnection.ApiClient.AuthenticationProvider.Sign($"GET/realtime{expireTime}");

            var authRequest = new BybitFuturesRequestMessage()
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
            await socketConnection.SendAndWaitAsync(authRequest, ClientOptions.SocketResponseTimeout, data =>
            {
                if (data.Type != JTokenType.Object)
                    return false;

                if (socketConnection.ApiClient.GetType() == typeof(BybitSocketClientSpotStreams))
                {
                    var auth = data["auth"]?.ToString();
                    result = auth == "success";
                    return auth != null;
                }
                else
                {
                    var operation = data["request"]?["op"]?.ToString();
                    var args = data["request"]?["args"].Select(p => p.ToString()).ToList();
                    if (operation != "auth")
                        return false;

                    result = data["success"]?.Value<bool>() == true;
                    error = data["ret_msg"]?.ToString();
                    return true;
                }
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

            if (socketConnection.ApiClient.GetType() == typeof(BybitSocketClientSpotStreams))
            {
                var bRequest = ((BybitSpotRequestMessage)request);
                var requestSymbols = bRequest.Parameters["symbol"]?.ToString().Split(',');
                var operation = data["event"]?.ToString();
                var topic = data["topic"]?.ToString();
                var symbols = data["params"]?["symbol"]?.ToString().Split(',').ToList();
                if (operation != "sub")
                    return false;

                if (topic != bRequest.Operation)
                    return false;

                if (requestSymbols.Any(p => symbols?.Contains(p) != true))
                    return false;

                var success = data["msg"]?.Value<string>() == "Success";
                if (success)
                    callResult = new CallResult<object>(true);
                else
                    callResult = new CallResult<object>(new ServerError(data["ret_msg"]!.ToString()));
                return true;
            }
            else
            {
                var requestParams = ((BybitFuturesRequestMessage)request).Parameters;
                var operation = data["request"]?["op"]?.ToString();
                var args = data["request"]?["args"].Select(p => p.ToString()).ToList();
                if (operation != "subscribe")
                    return false;

                if (requestParams.Any(p => !args.Contains(p)))
                    return false;

                var success = data["success"]?.Value<bool>() == true;
                if(success)
                    callResult = new CallResult<object>(true);
                else
                    callResult = new CallResult<object>(new ServerError(data["ret_msg"]!.ToString()));
                return true;
            }
        }

        /// <inheritdoc />
        protected override bool MessageMatchesHandler(SocketConnection socketConnection, JToken message, object request)
        {
            if (message.Type != JTokenType.Object)
                return false;

            var topic = message["topic"]?.ToString();
            if (topic == null)
                return false;

            if (socketConnection.ApiClient.GetType() == typeof(BybitSocketClientSpotStreams))
            {
                // Spot subscriptions
                var bRequest = ((BybitSpotRequestMessage)request);
                var requestSymbols = bRequest.Parameters["symbol"]?.ToString().Split(',');
                var symbol = message["params"]?["symbol"]?.ToString();

                if (bRequest.Operation != topic)
                    return false;

                if (!requestSymbols.Contains(symbol))
                    return false;

                var klineInterval = message["params"]?["klineType"]?.ToString();
                if (klineInterval != null && bRequest.Parameters.ContainsKey("klineType"))
                {
                    if (klineInterval != (string)bRequest.Parameters["klineType"])
                        return false;
                }

                return true;
            }
            else
            {
                // Futures subscriptions
                var requestParams = ((BybitFuturesRequestMessage)request).Parameters;
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

            if(identifier == "AccountInfo")
            {
                if (message.Type != JTokenType.Array)
                    return false;

                var updateType = ((JArray)message)[0]["e"]?.ToString();
                if (updateType == null)
                    return false;

                return updateType == "outboundAccountInfo" || updateType == "executionReport" || updateType == "ticketInfo";
            }

            return false;
        }

        /// <inheritdoc />
        protected override async Task<bool> UnsubscribeAsync(SocketConnection connection, SocketSubscription subscriptionToUnsub)
        {
            if (connection.ApiClient.GetType() == typeof(BybitSocketClientSpotStreams))
            {
                var bRequest = ((BybitSpotRequestMessage)subscriptionToUnsub.Request!);
                var message = new BybitSpotRequestMessage 
                { 
                    Operation = bRequest.Operation, 
                    Parameters =  new Dictionary<string, object>
                    {
                        { "symbol", bRequest.Parameters["symbol"] }
                    },
                    Event = "cancel" 
                };

                var result = false;
                await connection.SendAndWaitAsync(message, ClientOptions.SocketResponseTimeout, data =>
                {
                    if (data.Type != JTokenType.Object)
                        return false;

                    // TODo

                    result = data["success"]?.Value<bool>() == true;
                    return true;
                }).ConfigureAwait(false);
                return result;
            }
            else
            {
                var requestParams = ((BybitFuturesRequestMessage)subscriptionToUnsub.Request!).Parameters;
                var message = new BybitFuturesRequestMessage { Operation = "unsubscribe", Parameters = requestParams };

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

                    result = data["success"]?.Value<bool>() == true;
                    return true;
                }).ConfigureAwait(false);
                return result;
            }
        }
    }
}
