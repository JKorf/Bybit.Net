using Bybit.Net.Clients.SpotApi.v1;
using Bybit.Net.Clients.SpotApi.v2;
using Bybit.Net.Interfaces.Clients.SpotApi;
using Bybit.Net.Objects;
using Bybit.Net.Objects.Internal.Socket;
using Bybit.Net.Objects.Models.Socket.Spot;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.SpotApi
{
    /// <summary>
    /// Base client for Bybit spot socket streams clients
    /// </summary>
    public abstract class BybitBaseSocketClientSpotStreams : SocketApiClient
    {
        /// <summary>
        /// Options
        /// </summary>
        protected readonly BybitSocketClientOptions _options;

        internal BybitBaseSocketClientSpotStreams(Log log, BybitSocketClientOptions options, BybitSocketApiClientOptions apiOptions)
            : base(log, options, apiOptions)
        {
            _log = log;
            _options = options;

            ContinueOnQueryResponse = true;
            UnhandledMessageExpected = true;
            KeepAliveInterval = TimeSpan.Zero;

            SendPeriodic("Ping", apiOptions.PingInterval, (connection) =>
            {
                return new BybitSpotPing() { Ping = DateTimeConverter.ConvertToMilliseconds(DateTime.UtcNow)!.Value };
            });
            AddGenericHandler("Heartbeat", (evnt) => { });
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new BybitAuthenticationProvider(credentials);

        /// <summary>
        /// Check auth data for valid
        /// </summary>
        /// <param name="data"> Response data </param>
        /// <param name="isSuccess"> Flag if auth is succeeded </param>
        /// <returns> Flag if response is valid </returns>
        public abstract bool CheckAuth(JToken data, ref bool isSuccess);


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

                var isValid = (socketConnection.ApiClient as BybitBaseSocketClientSpotStreams)?.CheckAuth(data, ref result) ?? false;
                return isValid;
                
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

            var bRequest = (IBybitSpotRequestValidable)request;
            var forcedExit = false;

            var success = bRequest.ValidateResponse(data, ref forcedExit);
            if (forcedExit)
            {
                return false;
            }

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

            return (request as IBybitSpotRequestValidable)?.MatchReponse(message) ?? false;            
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
            object? message = null;
            var isCheckable = false;
            var clientType = GetType();
            if (clientType == typeof(BybitSocketClientSpotStreamsV1))
            {
                var bRequest = ((BybitSpotRequestMessageV1)subscriptionToUnsub.Request!);
                message = new BybitSpotRequestMessageV1
                {
                    Operation = bRequest.Operation,
                    Symbol = bRequest.Symbol,
                    Event = "cancel"
                };
            }
            else if (clientType == typeof(BybitSocketClientSpotStreamsV2))
            {
                isCheckable = true;
                var bRequest = ((BybitSpotRequestMessageV2)subscriptionToUnsub.Request!);
                message = new BybitSpotRequestMessageV2
                {
                    Operation = bRequest.Operation,
                    Parameters = new Dictionary<string, object>
                    {
                        { "symbol", bRequest.Parameters["symbol"] }
                    },
                    Event = "cancel"
                };
            }

            var result = false;
            await connection.SendAndWaitAsync(message, Options.SocketResponseTimeout, null, data =>
            {
                if (!isCheckable)
                {
                    //// Got fallback message only in version 2,3. In version 1 we get a plain responseData
                    result = true;
                    return true;
                }

                if (data.Type != JTokenType.Object)
                    return false;

                result = data["success"]?.Value<bool>() == true;
                return true;
            }).ConfigureAwait(false);
            return result;            
        }
    }
}
