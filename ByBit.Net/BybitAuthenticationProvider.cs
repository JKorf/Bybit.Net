using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Bybit.Net.Clients.CopyTradingApi;
using System.Globalization;
using Bybit.Net.Clients.V5;
using System.Text;
using Newtonsoft.Json;
using Bybit.Net.Objects.Options;
using CryptoExchange.Net.Clients;

namespace Bybit.Net
{
    internal class BybitAuthenticationProvider : AuthenticationProvider
    {
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
            if (apiClient is BybitRestClientCopyTradingApi || apiClient is BybitRestClientApi)
            {
                var signPayload = parameterPosition == HttpMethodParameterPosition.InUri ? uri.SetParameters(parameters, arraySerialization).Query.Replace("?", "") : requestBodyFormat == RequestBodyFormat.FormData ? parameters.ToFormData() : JsonConvert.SerializeObject(parameters);
                var key = _credentials.Key!;
                var recvWindow = ((BybitRestOptions)apiClient.ClientOptions).ReceiveWindow.TotalMilliseconds;
                var payload = timestamp + key + recvWindow + signPayload;

                string sign;
                if (_credentials.CredentialType == ApiCredentialsType.Hmac)
                    sign = SignHMACSHA256(payload);
                else
                    sign = SignRSASHA256(Encoding.UTF8.GetBytes(payload), SignOutputType.Base64);

                headers ??= new Dictionary<string, string>();
                headers.Add("X-BAPI-API-KEY", key);
                headers.Add("X-BAPI-SIGN", sign);
                headers.Add("X-BAPI-SIGN-TYPE", "2");
                headers.Add("X-BAPI-TIMESTAMP", timestamp);
                headers.Add("X-BAPI-RECV-WINDOW", recvWindow.ToString());
            }
            else
            {
                parameters.Add("api_key", _credentials.Key);
                parameters.Add("timestamp", timestamp);
                var signData = parameterPosition == HttpMethodParameterPosition.InUri ? uri.SetParameters(parameters, arraySerialization).Query.Replace("?", "") : parameters.ToFormData();

                string sign;
                if (_credentials.CredentialType == ApiCredentialsType.Hmac)
                    sign = SignHMACSHA256(signData);
                else
                    sign = SignRSASHA256(Encoding.UTF8.GetBytes(signData));
                parameters.Add("sign", sign);
            }
        }

        public string Sign(string toSign) => SignHMACSHA256(toSign);
    }

    internal class BybitComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (string.Equals(x, "sign", StringComparison.Ordinal))
                return 1;
            if (string.Equals(y, "sign", StringComparison.Ordinal))
                return -1;

            return x.CompareTo(y);
        }
    }
}
