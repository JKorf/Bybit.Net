using Bybit.Net.Clients.Rest.Futures;
using CryptoExchange.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Interfaces.Clients
{
    public interface IBybitClient: IRestClient
    {
        IBybitClientInversePerpetual InversePerpetual { get; }
        IBybitClientUsdPerpetual UsdPerpetual { get; }
        IBybitClientInverseFutures InverseFutures { get; }
        IBybitClientSpot Spot { get; }
    }
}
