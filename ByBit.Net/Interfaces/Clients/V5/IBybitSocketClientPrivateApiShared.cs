using CryptoExchange.Net.SharedApis.Interfaces.Socket;
using System;
using System.Collections.Generic;
using System.Text;

namespace Binance.Net.Interfaces.Clients.V5
{
    public interface IBybitSocketClientPrivateApiShared :
        IBalanceSocketClient,
        ISpotOrderSocketClient
    {
    }
}
