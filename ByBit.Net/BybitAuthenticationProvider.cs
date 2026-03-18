using Bybit.Net.Objects.Options;
using Bybit.Net.Objects.Sockets.Queries;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Bybit.Net
{
    internal class BybitAuthenticationProvider : AuthenticationProvider<BybitCredentials>
    {
        private static readonly IStringMessageSerializer _messageSerializer = new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(BybitExchange._serializerContext));

        public override string Key => ApiCredentials.Credential.Key;

        public BybitAuthenticationProvider(BybitCredentials credentials) : base(credentials)
        {
        }

        public override void ProcessRequest(RestApiClient apiClient, RestRequestConfiguration request)
        {
            if (!request.Authenticated)
                return;

            var timestamp = GetMillisecondTimestamp(apiClient);
            var recvWindow = ((BybitRestOptions)apiClient.ClientOptions).ReceiveWindow.TotalMilliseconds;
            string payload;
            if (request.ParameterPosition == HttpMethodParameterPosition.InUri)
            {
                var queryString = request.GetQueryString();
                payload = timestamp + ApiCredentials.Credential.Key + recvWindow + queryString;
                request.SetQueryString(queryString);
            }
            else
            {
                var requestBody = request.BodyFormat == RequestBodyFormat.FormData
                        ? (request.BodyParameters?.ToFormData() ?? string.Empty)
                        : GetSerializedBody(_messageSerializer, request.BodyParameters ?? new Dictionary<string, object>());
                payload = timestamp + ApiCredentials.Credential.Key + recvWindow + requestBody;
                request.SetBodyContent(requestBody);
            }

            string signature;
            if (ApiCredentials.Credential is HMACCredential hmacCred)
                signature = SignHMACSHA256(hmacCred, payload);
            else if (ApiCredentials.Credential is RSACredential rsaCred)
                signature = SignRSASHA256(rsaCred, Encoding.UTF8.GetBytes(payload), SignOutputType.Base64);
            else
                throw new NotImplementedException();

            request.Headers ??= new Dictionary<string, string>();
            request.Headers.Add("X-BAPI-API-KEY", ApiCredentials.Credential.Key);
            request.Headers.Add("X-BAPI-SIGN", signature);
            request.Headers.Add("X-BAPI-SIGN-TYPE", "2");
            request.Headers.Add("X-BAPI-TIMESTAMP", timestamp);
            request.Headers.Add("X-BAPI-RECV-WINDOW", recvWindow.ToString());
        }

        public override Query? GetAuthenticationQuery(SocketApiClient apiClient, SocketConnection connection, Dictionary<string, object?>? context = null)
        {
            var expireTime = DateTimeConverter.ConvertToMilliseconds(GetTimestamp(apiClient).AddSeconds(30))!;
            var key = ApiCredentials.Credential.Key;

            string sign;
            if (ApiCredentials.Credential is HMACCredential hmacCred)
                sign = SignHMACSHA256(hmacCred, $"GET/realtime{expireTime}");
            else if (ApiCredentials.Credential is RSACredential rsaCred)
                sign = SignRSASHA256(rsaCred, Encoding.UTF8.GetBytes($"GET/realtime{expireTime}"), SignOutputType.Base64);
            else
                throw new NotImplementedException();

            if (connection.ConnectionUri.AbsolutePath.EndsWith("private"))
            {
                // Auth subscription
                return new BybitQuery(apiClient, "auth", new object[]
                {
                    key,
                    expireTime,
                    sign
                });
            }
            else
            {
                // Trading

                return new BybitRequestQuery<object>(apiClient, "auth", null, new object[]
                {
                    key,
                    expireTime,
                    sign
                });
            }
        }
    }
}
