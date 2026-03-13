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

        public override ApiCredentialsType[] SupportedCredentialTypes => [ApiCredentialsType.Hmac, ApiCredentialsType.Rsa];

        public override string PublicKey => ApiCredentials.PublicKey;

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
                payload = timestamp + ApiCredentials.PublicKey + recvWindow + queryString;
                request.SetQueryString(queryString);
            }
            else
            {
                var requestBody = request.BodyFormat == RequestBodyFormat.FormData
                        ? (request.BodyParameters?.ToFormData() ?? string.Empty)
                        : GetSerializedBody(_messageSerializer, request.BodyParameters ?? new Dictionary<string, object>());
                payload = timestamp + ApiCredentials.PublicKey + recvWindow + requestBody;
                request.SetBodyContent(requestBody);
            }

            var signature = 
                ApiCredentials.CredentialType == ApiCredentialsType.Hmac
                    ? SignHMACSHA256(ApiCredentials.Hmac!, payload)
                    : SignRSASHA256(ApiCredentials.Rsa!, Encoding.UTF8.GetBytes(payload), SignOutputType.Base64);

            request.Headers ??= new Dictionary<string, string>();
            request.Headers.Add("X-BAPI-API-KEY", ApiCredentials.PublicKey);
            request.Headers.Add("X-BAPI-SIGN", signature);
            request.Headers.Add("X-BAPI-SIGN-TYPE", "2");
            request.Headers.Add("X-BAPI-TIMESTAMP", timestamp);
            request.Headers.Add("X-BAPI-RECV-WINDOW", recvWindow.ToString());
        }

        public override Query? GetAuthenticationQuery(SocketApiClient apiClient, SocketConnection connection, Dictionary<string, object?>? context = null)
        {
            var expireTime = DateTimeConverter.ConvertToMilliseconds(GetTimestamp(apiClient).AddSeconds(30))!;
            var key = ApiCredentials.PublicKey;
            var sign =
                ApiCredentials.CredentialType == ApiCredentialsType.Hmac
                    ? SignHMACSHA256(ApiCredentials.Hmac!, $"GET/realtime{expireTime}")
                    : SignRSASHA256(ApiCredentials.Rsa!, Encoding.UTF8.GetBytes($"GET/realtime{expireTime}"), SignOutputType.Base64);

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
