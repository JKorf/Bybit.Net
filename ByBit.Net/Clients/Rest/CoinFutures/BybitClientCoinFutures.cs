using Bybit.Net;
using Bybit.Net.Objects;
using Bybit.Net.Objects.Internal;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.ExchangeInterfaces;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.Rest.Futures
{
    public class BybitClientCoinFutures : BybitClientFuturesBase//, IBybitInversePerpetualClient
    {

        public BybitClientCoinFuturesIPAccount PerpetualAccount { get; }
        public BybitClientCoinFuturesIFAccount FuturesAccount { get; }

        public BybitClientCoinFuturesExchangeData ExchangeData { get; }

        public BybitClientCoinFuturesIPTrading PerpetualTrading { get; }
        public BybitClientCoinFuturesIFTrading FuturesTrading { get; }

        #region ctor
        /// <summary>
        /// Create a new instance of BybitClientFutures using the default options
        /// </summary>
        public BybitClientCoinFutures() : this(BybitClientFuturesOptions.Default)
        {
        }

        /// <summary>
        /// Create a new instance of BybitClientFutures using the provided options
        /// </summary>
        public BybitClientCoinFutures(BybitClientFuturesOptions options) : base("Bybit[Futures]", options, options.ApiCredentials == null ? null : new BybitAuthenticationProvider(options.ApiCredentials))
        {
            PerpetualAccount = new BybitClientCoinFuturesIPAccount(this);
            FuturesAccount = new BybitClientCoinFuturesIFAccount(this);
            ExchangeData = new BybitClientCoinFuturesExchangeData(this);
            PerpetualTrading = new BybitClientCoinFuturesIPTrading(this);
            FuturesTrading = new BybitClientCoinFuturesIFTrading(this);
        }
        #endregion

        /// <summary>
        /// Sets the default options to use for new clients
        /// </summary>
        /// <param name="options">The options to use for new clients</param>
        public static void SetDefaultOptions(BybitClientFuturesOptions options)
        {
            BybitClientFuturesOptions.Default = options;
        }

        /// <summary>
        /// Set the API key and secret. Api keys can be managed at https://bittrex.com/Manage#sectionApi
        /// </summary>
        /// <param name="apiKey">The api key</param>
        /// <param name="apiSecret">The api secret</param>
        public void SetApiCredentials(string apiKey, string apiSecret)
        {
            SetAuthenticationProvider(new BybitAuthenticationProvider(new ApiCredentials(apiKey, apiSecret)));
        }
    }
}
