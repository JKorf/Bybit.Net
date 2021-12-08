using Bybit.Net.Clients.Rest.Futures;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects;
using CryptoExchange.Net;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Bybit.Net.Clients
{
    /// <inheritdoc cref="IBybitClient" />
    public class BybitClient : BaseRestClient, IBybitClient
    {
        /// <inheritdoc />
        public IBybitClientGeneralApi GeneralApi { get; }
        /// <inheritdoc />
        public IBybitClientSpotApi SpotApi { get; }
        /// <inheritdoc />
        public IBybitClientInversePerpetualApi InversePerpetualApi { get; }
        /// <inheritdoc />
        public IBybitClientInverseFuturesApi InverseFuturesApi { get; }
        /// <inheritdoc />
        public IBybitClientUsdPerpetualApi UsdPerpetualApi { get; }

        #region constructor/destructor
        /// <summary>
        /// Create a new instance of the BybitClient using the default options
        /// </summary>
        public BybitClient() : this(BybitClientOptions.Default)
        {
        }

        /// <summary>
        /// Create a new instance of the BybitClient using provided options
        /// </summary>
        /// <param name="options">The options to use for this client</param>
        public BybitClient(BybitClientOptions options) : base("Bybit", options)
        {
            InversePerpetualApi = new BybitClientInversePerpetualApi(log, this, options);
            InverseFuturesApi = new BybitClientInverseFuturesApi(log, this, options);
            UsdPerpetualApi = new BybitClientUsdPerpetualApi(log, this, options);
            SpotApi = new BybitClientSpotApi(log, this, options);
            GeneralApi = new BybitClientGeneralApi(log, this, options);

            requestBodyFormat = RequestBodyFormat.FormData;
            ParameterPositions[HttpMethod.Delete] = HttpMethodParameterPosition.InUri;
        }
        #endregion

        /// <summary>
        /// Set the default options to be used when creating new clients
        /// </summary>
        /// <param name="options"></param>
        public static void SetDefaultOptions(BybitClientOptions options)
        {
            BybitClientOptions.Default = options;
        }

        internal Task<WebCallResult<T>> SendRequestInternal<T>(RestApiClient apiClient, Uri uri, HttpMethod method, CancellationToken cancellationToken,
            Dictionary<string, object>? parameters = null, bool signed = false, HttpMethodParameterPosition? postPosition = null,
            ArrayParametersSerialization? arraySerialization = null, int weight = 1, JsonSerializer? deserializer = null) where T : class
        {
            return base.SendRequestAsync<T>(apiClient, uri, method, cancellationToken, parameters, signed, postPosition, arraySerialization, weight, deserializer);
        }

        /// <inheritdoc />
        protected override IComparer<string> GetParameterComparer()
        {
            return new BybitComparer();
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
}
