using Bybit.Net.Objects;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Clients
{
    public class BybitClientV5 : BaseRestClient
    {
        /// <summary>
        /// Create a new instance of the BybitClient using the default options
        /// </summary>
        public BybitClientV5() : this(BybitClientOptions.Default)
        {
        } 
        
        /// <summary>
        /// Create a new instance of the BybitClient using provided options
        /// </summary>
        /// <param name="options">The options to use for this client</param>
        public BybitClientV5(BybitClientOptions options) : base("Bybit", options)
        {
            //InversePerpetualApi = AddApiClient(new BybitClientInversePerpetualApi(log, options));
        }

        /// <summary>
        /// Set the default options to be used when creating new clients
        /// </summary>
        /// <param name="options"></param>
        public static void SetDefaultOptions(BybitClientOptions options)
        {
            BybitClientOptions.Default = options;
        }

        /// <inheritdoc />
        public void SetApiCredentials(ApiCredentials credentials)
        {
            //InversePerpetualApi.SetApiCredentials(credentials);
        }
    }
}
