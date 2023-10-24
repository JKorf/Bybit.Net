using Bybit.Net.Clients.SpotApi.v1;
using Bybit.Net.Clients.SpotApi.v2;
using Bybit.Net.Interfaces.Clients.SpotApi;
using Bybit.Net.Objects.Internal.Socket;
using Bybit.Net.Objects.Models.Socket.Spot;
using Bybit.Net.Objects.Options;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.SpotApi
{
    /// <summary>
    /// Base client for Bybit spot socket streams clients
    /// </summary>
    public abstract class BybitSocketClientBaseSpotApi : SocketApiClient
    {
        internal BybitSocketClientBaseSpotApi(ILogger logger, string baseAddress, BybitSocketOptions options, BybitSocketApiOptions apiOptions)
            : base(logger, baseAddress, options, apiOptions)
        {
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
            var bybitAuthProvider = (BybitAuthenticationProvider)socketConnection.ApiClient.AuthenticationProvider;
            var key = bybitAuthProvider.GetApiKey();
            var sign = bybitAuthProvider.Sign($"GET/realtime{expireTime}");

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
            await socketConnection.SendAndWaitAsync(authRequest, ClientOptions.RequestTimeout, null, 1, data =>
            {
                if (data.Type != JTokenType.Object)
                    return false;

                var isValid = (socketConnection.ApiClient as BybitSocketClientBaseSpotApi)?.CheckAuth(data, ref result) ?? false;
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
            if (clientType == typeof(BybitSocketClientSpotApiV1))
            {
                var bRequest = ((BybitSpotRequestMessageV1)subscriptionToUnsub.Request!);
                message = new BybitSpotRequestMessageV1
                {
                    Operation = bRequest.Operation,
                    Symbol = bRequest.Symbol,
                    Event = "cancel"
                };
            }
            else if (clientType == typeof(BybitSocketClientSpotApiV2))
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
            await connection.SendAndWaitAsync(message, ClientOptions.RequestTimeout, null, 1, data =>
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
