using Bybit.Net.Clients.Rest.Futures;
using CryptoExchange.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Interfaces.Clients
{
    public interface IBybitClient: IRestClient
    {
        IBybitClientInversePerpetual InversePerpetualApi { get; }
        IBybitClientUsdPerpetual UsdPerpetualApi { get; }
        IBybitClientInverseFutures InverseFuturesApi { get; }
        IBybitClientSpot SpotApi { get; }
    }
}
