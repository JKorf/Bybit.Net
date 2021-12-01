using Bybit.Net.Interfaces.Clients.InverseFutures;
using Bybit.Net.Interfaces.Clients.InversePerpetual;
using Bybit.Net.Interfaces.Clients.Spot;
using Bybit.Net.Interfaces.Clients.UsdPerpetual;
using CryptoExchange.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Interfaces.Clients
{
    public interface IBybitSocketClient: ISocketClient
    {
        public IBybitSocketClientUsdPerpetual UsdPerpetualStreams { get; }
        public IBybitSocketClientSpot SpotStreams { get; }
        public IBybitSocketClientInversePerpetual InversePerpetualStreams { get; }
        public IBybitSocketClientInverseFutures InverseFuturesStreams { get; }
    }
}
