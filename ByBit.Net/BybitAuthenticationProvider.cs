using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Linq;
using CryptoExchange.Net.Converters;
using System.Globalization;

namespace Bybit.Net
{
    internal class BybitAuthenticationProvider : AuthenticationProvider
    {
        public BybitAuthenticationProvider(ApiCredentials credentials) : base(credentials)
        {
        }

        public override void AuthenticateBodyRequest(RestApiClient apiClient, Uri uri, HttpMethod method, SortedDictionary<string, object> parameters, Dictionary<string, string> headers, bool auth, ArrayParametersSerialization arraySerialization)
        {
            if (!auth)
                return;

            parameters.Add("api_key", Credentials.Key!.GetString());
            parameters.Add("timestamp", GetTimestamp(apiClient));
            parameters.Add("sign", SignHMACSHA256(parameters.ToFormData()));
        }

        public override void AuthenticateUriRequest(RestApiClient apiClient, Uri uri, HttpMethod method, SortedDictionary<string, object> parameters, Dictionary<string, string> headers, bool auth, ArrayParametersSerialization arraySerialization)
        {
            if (!auth)
                return;

            parameters.Add("api_key", Credentials.Key!.GetString());
            parameters.Add("timestamp", GetTimestamp(apiClient));
            parameters.Add("sign", SignHMACSHA256(uri.SetParameters(parameters).Query.Replace("?", "")));
        }

        internal string GetTimestamp(RestApiClient apiClient) => DateTimeConverter.ConvertToMilliseconds(DateTime.UtcNow.Add(apiClient.GetTimeOffset()))!.Value.ToString(CultureInfo.InvariantCulture);

        public override string Sign(string toSign) => SignHMACSHA256(toSign);
    }
}
