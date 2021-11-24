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
    public class BybitClientUsdFutures : BybitClientFuturesBase//, IBybitInversePerpetualClient
    {
        public BybitClientUsdFuturesAccount Account { get; }
        public BybitClientUsdFuturesExchangeData ExchangeData { get; }
        public BybitClientUsdFuturesTrading Trading { get; }

        #region ctor
        /// <summary>
        /// Create a new instance of BybitClientFutures using the default options
        /// </summary>
        public BybitClientUsdFutures() : this(BybitClientFuturesOptions.Default)
        {
        }

        /// <summary>
        /// Create a new instance of BybitClientFutures using the provided options
        /// </summary>
        public BybitClientUsdFutures(BybitClientFuturesOptions options) : base("Bybit[Futures]", options, options.ApiCredentials == null ? null : new BybitAuthenticationProvider(options.ApiCredentials))
        {
            Account = new BybitClientUsdFuturesAccount(this);
            ExchangeData = new BybitClientUsdFuturesExchangeData(this);
            Trading = new BybitClientUsdFuturesTrading(this);
        }
        #endregion
    }
}
