using Bybit.Net.Objects.Internal.Socket;
using Bybit.Net.Objects;
using CryptoExchange.Net;
using System;
using System.Collections.Generic;
using System.Text;
using CryptoExchange.Net.Objects;
using System.Threading.Tasks;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json.Linq;
using System.Linq;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Interfaces.Clients.UsdPerpetual;
using Bybit.Net.Interfaces.Clients.InversePerpetual;
using Bybit.Net.Interfaces.Clients.InverseFutures;
using Bybit.Net.Interfaces.Clients.Spot;
using Newtonsoft.Json;
using System.Threading;
using Bybit.Net.Clients.Socket;
using Bybit.Net.Clients.Rest.Futures;

namespace Bybit.Net.Clients
{
    public class BybitSocketClient: BaseSocketClient, IBybitSocketClient
    {
        public IBybitSocketClientUsdPerpetual UsdPerpetualStreams { get; }
        public IBybitSocketClientInversePerpetual InversePerpetualStreams { get; }
        public IBybitSocketClientInverseFutures InverseFuturesStreams { get; }
        public IBybitSocketClientSpot SpotStreams { get; }

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
        public BybitSocketClient(BybitSocketClientOptions options) : base("Bybit[Futures]", options)
        {
            if (options == null)
                throw new ArgumentException("Cant pass null options, use empty constructor for default");

            ContinueOnQueryResponse = true;
            UnhandledMessageExpected = true;

            UsdPerpetualStreams = new BybitSocketClientUsdPerpetual(log, this, options);
            InversePerpetualStreams = new BybitSocketClientInversePerpetual(log, this, options);
            //InverseFutures = new BybitSocketClientInverseFutures(log, this, options);
            //Spot = new BybitSocketClientSpot(log, this, options);

            SendPeriodic(TimeSpan.FromSeconds(30), (connection) => new BybitRequestMessage() { Operation = "ping" });
            AddGenericHandler("Heartbeat", (evnt) => { });
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
                return new CallResult<bool>(false, new NoApiCredentialsError());

            var expireTime = DateTimeConverter.ConvertToMilliseconds(DateTime.UtcNow.AddSeconds(5));
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
            return new CallResult<bool>(result, result ? null : new ServerError(error));
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
            if (identifier == "Heartbeat")
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

                result = data["success"]?.Value<bool>() == true;
                return true;
            }).ConfigureAwait(false);
            return result;
        }
    }
}
