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
    internal class BybitAuthenticationProvider : AuthenticationProvider
    {
        private static readonly IStringMessageSerializer _messageSerializer = new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(BybitExchange._serializerContext));

        public override ApiCredentialsType[] SupportedCredentialTypes => [ApiCredentialsType.Hmac, ApiCredentialsType.RsaPem, ApiCredentialsType.RsaXml];

        public BybitAuthenticationProvider(ApiCredentials credentials) : base(credentials)
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
                payload = timestamp + _credentials.Key + recvWindow + queryString;
                request.SetQueryString(queryString);
            }
            else
            {
                var requestBody = request.BodyFormat == RequestBodyFormat.FormData
                        ? (request.BodyParameters?.ToFormData() ?? string.Empty)
                        : GetSerializedBody(_messageSerializer, request.BodyParameters ?? new Dictionary<string, object>());
                payload = timestamp + _credentials.Key + recvWindow + requestBody;
                request.SetBodyContent(requestBody);
            }

            var signature = _credentials.CredentialType == ApiCredentialsType.Hmac ? SignHMACSHA256(payload) : SignRSASHA256(Encoding.UTF8.GetBytes(payload), SignOutputType.Base64);

            request.Headers ??= new Dictionary<string, string>();
            request.Headers.Add("X-BAPI-API-KEY", _credentials.Key);
            request.Headers.Add("X-BAPI-SIGN", signature);
            request.Headers.Add("X-BAPI-SIGN-TYPE", "2");
            request.Headers.Add("X-BAPI-TIMESTAMP", timestamp);
            request.Headers.Add("X-BAPI-RECV-WINDOW", recvWindow.ToString());
        }

        public override Query? GetAuthenticationQuery(SocketApiClient apiClient, SocketConnection connection, Dictionary<string, object?>? context = null)
        {
            if (connection.ConnectionUri.AbsolutePath.EndsWith("private"))
            {
                // Auth subscription
                var expireTime = DateTimeConverter.ConvertToMilliseconds(GetTimestamp(apiClient).AddSeconds(30))!;
                var key = ApiKey;
                var sign = SignHMACSHA256($"GET/realtime{expireTime}");

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
                var expireTime = DateTimeConverter.ConvertToMilliseconds(GetTimestamp(apiClient).AddSeconds(30))!;
                var key = ApiKey;
                var sign = SignHMACSHA256($"GET/realtime{expireTime}");

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
