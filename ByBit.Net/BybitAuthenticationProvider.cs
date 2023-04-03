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

namespace Bybit.Net
{
    internal class BybitAuthenticationProvider : AuthenticationProvider
    {
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
            if (apiClient is BybitClientCopyTradingApi || apiClient is BybitClientApi)
            {
                var signPayload = parameterPosition == HttpMethodParameterPosition.InUri ? uri.SetParameters(parameters, arraySerialization).Query.Replace("?", "") : parameters.ToFormData();
                var key = Credentials.Key!.GetString();
                var recvWindow = 5000;
                var sign = SignHMACSHA256(timestamp + key + recvWindow + signPayload);
                headers.Add("X-BAPI-API-KEY", key);
                headers.Add("X-BAPI-SIGN", sign);
                headers.Add("X-BAPI-SIGN-TYPE", "2");
                headers.Add("X-BAPI-TIMESTAMP", timestamp);
                headers.Add("X-BAPI-RECV-WINDOW", recvWindow.ToString());
            }
            else
            {
                parameters.Add("api_key", Credentials.Key!.GetString());
                parameters.Add("timestamp", timestamp);
                parameters.Add("sign", SignHMACSHA256(parameterPosition == HttpMethodParameterPosition.InUri ? uri.SetParameters(parameters, arraySerialization).Query.Replace("?", "") : parameters.ToFormData()));
            }
        }

        public override string Sign(string toSign) => SignHMACSHA256(toSign);
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
