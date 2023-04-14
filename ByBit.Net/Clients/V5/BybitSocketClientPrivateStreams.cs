using Bybit.Net.Interfaces.Clients.V5;
using Bybit.Net.Objects;
using Bybit.Net.Objects.Internal.Socket;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.V5
{
    /// <inheritdoc cref="IBybitSocketClientPrivateStreams" />
    public class BybitSocketClientPrivateStreams : SocketApiClient, IBybitSocketClientPrivateStreams
    {
        private readonly BybitSocketClientOptions _options;

        internal BybitSocketClientPrivateStreams(Log log, BybitSocketClientOptions options)
            : base(log, options, options.V5StreamsOptions)
        {
            _options = options;

            ContinueOnQueryResponse = true;
            UnhandledMessageExpected = true;
            KeepAliveInterval = TimeSpan.Zero;

            SendPeriodic("Ping", options.V5StreamsOptions.PingInterval, (connection) =>
            {
                return new BybitV5RequestMessage("ping", Array.Empty<object>(), NextId().ToString());
            });
            AddGenericHandler("Heartbeat", (evnt) => { });
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

                handler(data.As(desResult.Data, data.Data["topic"]!.ToString().Split('.').Last()));
            });

            return await SubscribeAsync(
                 _options.V5StreamsOptions.BaseAddressAuthenticated,
                new BybitV5RequestMessage("subscribe", new[] { "position" }, NextId().ToString()),
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

                handler(data.As(desResult.Data, data.Data["topic"]!.ToString().Split('.').Last()));
            });

            return await SubscribeAsync(
                 _options.V5StreamsOptions.BaseAddressAuthenticated,
                new BybitV5RequestMessage("subscribe", new[] { "execution" }, NextId().ToString()),
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
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitOrderUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, data.Data["topic"]!.ToString().Split('.').Last()));
            });

            return await SubscribeAsync(
                 _options.V5StreamsOptions.BaseAddressAuthenticated,
                new BybitV5RequestMessage("subscribe", new[] { "order" }, NextId().ToString()),
                null, true, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToWalletUpdatesAsync(Action<DataEvent<IEnumerable<BybitBalance>>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = Deserialize<IEnumerable<BybitBalance>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitBalance)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, data.Data["topic"]!.ToString().Split('.').Last()));
            });

            return await SubscribeAsync(
                 _options.V5StreamsOptions.BaseAddressAuthenticated,
                new BybitV5RequestMessage("subscribe", new[] { "wallet" }, NextId().ToString()),
                null, true, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToGreekUpdatesAsync(Action<DataEvent<IEnumerable<BybitGreeks>>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = Deserialize<IEnumerable<BybitGreeks>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitGreeks)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, data.Data["topic"]!.ToString().Split('.').Last()));
            });

            return await SubscribeAsync(
                 _options.V5StreamsOptions.BaseAddressAuthenticated,
                new BybitV5RequestMessage("subscribe", new[] { "greeks" }, NextId().ToString()),
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

                var operation = data["op"]?.ToString();
                if (operation != "auth")
                    return false;

                result = data["success"]?.Value<bool>() == true;
                error = data["ret_msg"]?.ToString();
                return true;

            }).ConfigureAwait(false);
            return result ? new CallResult<bool>(result) : new CallResult<bool>(new ServerError(error));
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials) => new BybitAuthenticationProvider(credentials);
        /// <inheritdoc />
        protected override bool HandleQueryResponse<T>(SocketConnection socketConnection, object request, JToken data, out CallResult<T> callResult) => throw new NotImplementedException();
        /// <inheritdoc />
        protected override bool HandleSubscriptionResponse(SocketConnection socketConnection, SocketSubscription subscription, object request, JToken data, out CallResult<object>? callResult)
        {
            callResult = null;
            if (data.Type != JTokenType.Object)
                return false;

            var messageRequestId = data["req_id"]?.ToString();
            if (messageRequestId != null)
            {
                // Matched based on request id
                var id = ((BybitV5RequestMessage)request).RequestId;
                if (id != messageRequestId)
                    return false;

                var success1 = data["success"]?.Value<bool>() == true;
                if (success1)
                    callResult = new CallResult<object>(true);
                else
                    callResult = new CallResult<object>(new ServerError(data["ret_msg"]!.ToString()));
                return true;
            }

            // No request id
            // Check subs
            var success = data["success"]?.Value<bool>();
            if (success == null)
                return false;

            var topics = data["data"]?["successTopics"]?.ToObject<string[]>();
            if (topics == null)
                return false;

            var requestTopics = ((BybitV5RequestMessage)request).Parameters;
            if (!topics.All(requestTopics.Contains))
                return false;

            callResult = success == true ? new CallResult<object>(true) : new CallResult<object>(new ServerError(data.ToString()));
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

            var requestParams = ((BybitV5RequestMessage)request).Parameters;
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

                var ret = message["ret_msg"] ?? message["op"];
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
            var requestParams = ((BybitV5RequestMessage)subscriptionToUnsub.Request!).Parameters;
            var message = new BybitV5RequestMessage("unsubscribe", requestParams, NextId().ToString());

            var result = false;
            await connection.SendAndWaitAsync(message, Options.SocketResponseTimeout, null, data =>
            {
                if (data.Type != JTokenType.Object)
                    return false;

                var messageRequestId = data["req_id"]?.ToString();
                if (messageRequestId != null)
                {
                    // Matched based on request id
                    var id = message.RequestId;
                    if (id != messageRequestId)
                        return false;

                    return true;
                }

                // No request id
                var success = data["success"]?.Value<bool>();
                if (success == null)
                    return false;

                return true;
            }).ConfigureAwait(false);
            return result;
        }
    }
}
