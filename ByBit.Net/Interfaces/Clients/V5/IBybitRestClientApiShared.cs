using CryptoExchange.Net.SharedApis.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Interfaces.Clients
{
    public interface IBybitRestClientApiShared :
        ITickerRestClient,
        ISpotSymbolRestClient,
        IFuturesSymbolRestClient,
        IKlineRestClient,
        ITradeRestClient,
        IBalanceRestClient
    {
    }
}
