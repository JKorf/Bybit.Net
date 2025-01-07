using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Globalization;
using Bybit.Net.Clients.V5;
using System.Text;
using Bybit.Net.Objects.Options;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Interfaces;

namespace Bybit.Net
{
    internal class BybitAuthenticationProvider : AuthenticationProvider
    {
        private static readonly IMessageSerializer _messageSerializer = new SystemTextJsonMessageSerializer();

        public BybitAuthenticationProvider(ApiCredentials credentials) : base(credentials)
        {
        }

        public override void AuthenticateRequest(
            RestApiClient apiClient,
            Uri uri,
            HttpMethod method,
            ref IDictionary<string, object>? uriParameters,
            ref IDictionary<string, object>? bodyParameters,
            ref Dictionary<string, string>? headers,
            bool auth,
            ArrayParametersSerialization arraySerialization,
            HttpMethodParameterPosition parameterPosition,
            RequestBodyFormat requestBodyFormat)
        {
            if (!auth)
                return;

            IDictionary<string, object> parameters;
            if (parameterPosition == HttpMethodParameterPosition.InUri)
            {
                uriParameters ??= new Dictionary<string, object>();
                parameters = uriParameters;
            }
            else
            {
                bodyParameters ??= new Dictionary<string, object>();
                parameters = bodyParameters;
            }
            var timestamp = DateTimeConverter.ConvertToMilliseconds(GetTimestamp(apiClient).AddMilliseconds(-1000)).Value.ToString(CultureInfo.InvariantCulture);
           
            var signPayload = parameterPosition == HttpMethodParameterPosition.InUri ? uri.SetParameters(parameters, arraySerialization).Query.Replace("?", "") : requestBodyFormat == RequestBodyFormat.FormData ? parameters.ToFormData() : _messageSerializer.Serialize(parameters);
            var recvWindow = ((BybitRestOptions)apiClient.ClientOptions).ReceiveWindow.TotalMilliseconds;
            var payload = timestamp + _credentials.Key + recvWindow + signPayload;

            string sign;
            if (_credentials.CredentialType == ApiCredentialsType.Hmac)
                sign = SignHMACSHA256(payload);
            else
                sign = SignRSASHA256(Encoding.UTF8.GetBytes(payload), SignOutputType.Base64);

            headers ??= new Dictionary<string, string>();
            headers.Add("X-BAPI-API-KEY", _credentials.Key);
            headers.Add("X-BAPI-SIGN", sign);
            headers.Add("X-BAPI-SIGN-TYPE", "2");
            headers.Add("X-BAPI-TIMESTAMP", timestamp);
            headers.Add("X-BAPI-RECV-WINDOW", recvWindow.ToString());
        }

        public string Sign(string toSign) => SignHMACSHA256(toSign);
    }
}
