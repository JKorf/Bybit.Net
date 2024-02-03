using Bybit.Net.Clients;
using Bybit.Net.Interfaces.Clients;
using CryptoExchange.Net.Interfaces.CommonClients;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoExchange.Net.Clients
{
    /// <summary>
    /// Extensions for the ICryptoRestClient and ICryptoSocketClient interfaces
    /// </summary>
    public static class CryptoClientExtensions
    {
        /// <summary>
        /// Get the Bybit REST Api client
        /// </summary>
        /// <param name="baseClient"></param>
        /// <returns></returns>
        public static IBybitRestClient Bybit(this ICryptoRestClient baseClient) => baseClient.TryGet<IBybitRestClient>(() => new BybitRestClient());

        /// <summary>
        /// Get the Bybit Websocket Api client
        /// </summary>
        /// <param name="baseClient"></param>
        /// <returns></returns>
        public static IBybitSocketClient Bybit(this ICryptoSocketClient baseClient) => baseClient.TryGet<IBybitSocketClient>(() => new BybitSocketClient());
    }
}
