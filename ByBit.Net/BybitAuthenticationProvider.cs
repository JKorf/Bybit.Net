using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Bybit.Net.Clients.CopyTradingApi;
using CryptoExchange.Net.Converters;
using System.Globalization;
using Bybit.Net.Clients.V5;
using System.Text;
using Newtonsoft.Json;
using Bybit.Net.Objects.Options;

namespace Bybit.Net
{
    internal class BybitAuthenticationProvider : AuthenticationProvider
    {
        public string GetApiKey() => _credentials.Key!.GetString();

        public BybitAuthenticationProvider(ApiCredentials credentials) : base(credentials)
        {
        }

        public override void AuthenticateRequest(RestApiClient apiClient, Uri uri, HttpMethod method, Dictionary<string, object> providedParameters, bool auth, ArrayParametersSerialization arraySerialization, HttpMethodParameterPosition parameterPosition, out SortedDictionary<string, object> uriParameters, out SortedDictionary<string, object> bodyParameters, out Dictionary<string, string> headers)
        {
            uriParameters = parameterPosition == HttpMethodParameterPosition.InUri ? new SortedDictionary<string, object>(providedParameters, new BybitComparer()) : new SortedDictionary<string, object>();
            bodyParameters = parameterPosition == HttpMethodParameterPosition.InBody ? new SortedDictionary<string, object>(providedParameters, new BybitComparer()) : new SortedDictionary<string, object>();
            headers = new Dictionary<string, string>();

            if (!auth)
                return;

            var parameters = parameterPosition == HttpMethodParameterPosition.InUri ? uriParameters : bodyParameters;
            var timestamp = DateTimeConverter.ConvertToMilliseconds(GetTimestamp(apiClient).AddMilliseconds(-1000)).Value.ToString(CultureInfo.InvariantCulture);
            if (apiClient is BybitRestClientCopyTradingApi || apiClient is BybitRestClientApi)
            {
                var signPayload = parameterPosition == HttpMethodParameterPosition.InUri ? uri.SetParameters(parameters, arraySerialization).Query.Replace("?", "") : apiClient.requestBodyFormat == RequestBodyFormat.FormData ? parameters.ToFormData() : JsonConvert.SerializeObject(parameters);
                var key = _credentials.Key!.GetString();
                var recvWindow = ((BybitRestOptions)apiClient.ClientOptions).ReceiveWindow.TotalMilliseconds;
                var payload = timestamp + key + recvWindow + signPayload;

                string sign;
                if (_credentials.CredentialType == ApiCredentialsType.Hmac)
                    sign = SignHMACSHA256(payload);
                else
                    sign = SignRSASHA256(Encoding.UTF8.GetBytes(payload), SignOutputType.Base64);

                headers.Add("X-BAPI-API-KEY", key);
                headers.Add("X-BAPI-SIGN", sign);
                headers.Add("X-BAPI-SIGN-TYPE", "2");
                headers.Add("X-BAPI-TIMESTAMP", timestamp);
                headers.Add("X-BAPI-RECV-WINDOW", recvWindow.ToString());
            }
            else
            {
                parameters.Add("api_key", _credentials.Key!.GetString());
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
            if (x == "sign")
                return 1;
            if (y == "sign")
                return -1;

            return x.CompareTo(y);
        }
    }
}
