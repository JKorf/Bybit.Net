using Bybit.Net.Clients;
using Bybit.Net.Interfaces.Clients;
using CryptoExchange.Net.Interfaces.CommonClients;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoExchange.Net.Clients
{
    public static class CryptoExchangeClientExtensions
    {
        public static IBybitRestClient Bybit(this ICryptoExchangeClient baseClient) => baseClient.TryGet<IBybitRestClient>() ?? new BybitRestClient();
    }
}
