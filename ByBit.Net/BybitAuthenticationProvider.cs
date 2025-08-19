using Bybit.Net.Clients.V5;
using Bybit.Net.Objects.Options;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;

namespace Bybit.Net
{
    internal class BybitAuthenticationProvider : AuthenticationProvider
    {
        private static readonly IStringMessageSerializer _messageSerializer = new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(BybitExchange._serializerContext));

        public BybitAuthenticationProvider(ApiCredentials credentials) : base(credentials)
        {
        }

        public override void ProcessRequest(RestApiClient apiClient, RestRequestConfiguration request)
        {
            if (!request.Authenticated)
                return;

            var timestamp = DateTimeConverter.ConvertToMilliseconds(GetTimestamp(apiClient).AddMilliseconds(-1000)).Value.ToString(CultureInfo.InvariantCulture);
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
                var requestBody = request.BodyFormat == RequestBodyFormat.FormData ? request.BodyParameters.ToFormData() : GetSerializedBody(_messageSerializer, request.BodyParameters);
                payload = timestamp + _credentials.Key + recvWindow + requestBody;
                request.SetBodyContent(requestBody);
            }

            var signature = _credentials.CredentialType == ApiCredentialsType.Hmac ? SignHMACSHA256(payload) : SignRSASHA256(Encoding.UTF8.GetBytes(payload), SignOutputType.Base64);

            request.Headers.Add("X-BAPI-API-KEY", _credentials.Key);
            request.Headers.Add("X-BAPI-SIGN", signature);
            request.Headers.Add("X-BAPI-SIGN-TYPE", "2");
            request.Headers.Add("X-BAPI-TIMESTAMP", timestamp);
            request.Headers.Add("X-BAPI-RECV-WINDOW", recvWindow.ToString());
        }

        public string Sign(string toSign) => SignHMACSHA256(toSign);
    }
}
