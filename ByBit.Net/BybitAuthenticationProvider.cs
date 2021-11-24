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

namespace Bybit.Net
{
    internal class BybitAuthenticationProvider : AuthenticationProvider
    {
        private readonly object _signLock = new object();
        private readonly HMACSHA256 _encryptor;

        public BybitAuthenticationProvider(ApiCredentials credentials) : base(credentials)
        {
            if (credentials.Secret == null)
                throw new ArgumentException("No valid API credentials provided. Key/Secret needed.");

            _encryptor = new HMACSHA256(Encoding.ASCII.GetBytes(credentials.Secret.GetString()));
        }

        public override Dictionary<string, string> AddAuthenticationToHeaders(string uri, HttpMethod method, Dictionary<string, object> parameters, bool signed, HttpMethodParameterPosition parameterPosition, ArrayParametersSerialization arraySerialization)
        {
            return base.AddAuthenticationToHeaders(uri, method, parameters, signed, parameterPosition, arraySerialization);
        }

        public override Dictionary<string, object> AddAuthenticationToParameters(string uri, HttpMethod method, Dictionary<string, object> parameters, bool signed, HttpMethodParameterPosition parameterPosition, ArrayParametersSerialization arraySerialization)
        {
            if (!signed)
                return parameters;

            var timestamp = (long)Math.Round((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds);
            string signData;

            parameters.Add("api_key", Credentials.Key!.GetString());
            parameters.Add("timestamp", timestamp);
            parameters = parameters.OrderBy(p => p.Key).ToDictionary(p => p.Key, p => p.Value);
            if (parameterPosition == HttpMethodParameterPosition.InUri)
            {
                signData = parameters.CreateParamString(true, arraySerialization);
            }
            else
            {
                var formData = HttpUtility.ParseQueryString(string.Empty);
                foreach (var kvp in parameters)
                {
                    if (kvp.Value.GetType().IsArray)
                    {
                        var array = (Array)kvp.Value;
                        foreach (var value in array)
                            formData.Add(kvp.Key, value.ToString());
                    }
                    else
                        formData.Add(kvp.Key, kvp.Value.ToString());
                }
                signData = formData.ToString();
            }

            lock (_signLock)
                parameters.Add("sign", ByteToString(_encryptor.ComputeHash(Encoding.UTF8.GetBytes(signData))));
            return parameters;
        }

        public override string Sign(string toSign)
        {
            lock (_signLock)
                return ByteToString(_encryptor.ComputeHash(Encoding.UTF8.GetBytes(toSign)));
        }
    }
}
