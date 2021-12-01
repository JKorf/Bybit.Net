using Bybit.Net.Clients.Rest.Futures;
using CryptoExchange.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Interfaces.Clients
{
    public interface IBybitClient: IRestClient
    {
        IBybitClientInversePerpetualApi InversePerpetualApi { get; }
        IBybitClientUsdPerpetualApi UsdPerpetualApi { get; }
        IBybitClientInverseFuturesApi InverseFuturesApi { get; }
        IBybitClientSpotApi SpotApi { get; }
    }
}
