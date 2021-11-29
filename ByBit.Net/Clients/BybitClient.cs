using Bybit.Net.Clients.Rest.Futures;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients
{
    public class BybitClient: RestClient, IBybitClient
    {
        public IBybitClientSpot Spot { get; }
        public IBybitClientInversePerpetual InversePerpetual { get; }
        public IBybitClientInverseFutures InverseFutures { get; }
        public IBybitClientUsdPerpetual UsdPerpetual { get; }

        #region constructor/destructor
        /// <summary>
        /// Create a new instance of BinanceClient using the default options
        /// </summary>
        public BybitClient() : this(BybitClientOptions.Default)
        {
        }

        /// <summary>
        /// Create a new instance of BinanceClient using provided options
        /// </summary>
        /// <param name="options">The options to use for this client</param>
        public BybitClient(BybitClientOptions options) : base("Bybit", options)
        {
            InversePerpetual = new BybitClientInversePerpetual(this, options);
            InverseFutures = new BybitClientInverseFutures(this, options);
            UsdPerpetual = new BybitClientUsdPerpetual(this, options);
            //Spot = new BybitClientSpot(this, options);
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

        internal Task<WebCallResult<T>> SendRequestInternal<T>(RestSubClient subClient, Uri uri, HttpMethod method, CancellationToken cancellationToken,
            Dictionary<string, object>? parameters = null, bool signed = false, HttpMethodParameterPosition? postPosition = null,
            ArrayParametersSerialization? arraySerialization = null, int weight = 1, JsonSerializer? deserializer = null) where T : class
        {
            return base.SendRequestAsync<T>(subClient, uri, method, cancellationToken, parameters, signed, postPosition, arraySerialization, weight, deserializer);
        }
    }
}
