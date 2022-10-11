using Bybit.Net.Objects;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Logging;
using Newtonsoft.Json.Linq;

namespace Bybit.Net.Clients.SpotApi
{
    /// <summary>
    /// Base client for Bybit spot socket streams clients
    /// </summary>
    public abstract class BybitBaseSocketClientSpotStreams : SocketApiClient
    {
        /// <summary>
        /// Log
        /// </summary>
        protected readonly Log _log;
        /// <summary>
        /// Base client
        /// </summary>
        protected readonly BybitSocketClient _baseClient;
        /// <summary>
        /// Options
        /// </summary>
        protected readonly BybitSocketClientOptions _options;

        internal BybitBaseSocketClientSpotStreams(Log log, BybitSocketClient baseClient, BybitSocketClientOptions options, BybitSocketApiClientOptions apiOptions)
            : base(options, apiOptions)
        {
            _log = log;
            _options = options;
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new BybitAuthenticationProvider(credentials);

        /// <summary>
        /// Check auth data for valid
        /// </summary>
        /// <param name="data"> Response data </param>
        /// <param name="isSuccess"> Flag if auth is succeeded </param>
        /// <returns> Flag if response is valid </returns>
        public abstract bool CheckAuth(JToken data, ref bool isSuccess);
    }
}
