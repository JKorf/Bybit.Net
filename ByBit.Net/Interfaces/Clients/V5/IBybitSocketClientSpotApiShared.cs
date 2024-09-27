using CryptoExchange.Net.SharedApis;

namespace Bybit.Net.Interfaces.Clients.V5
{
    /// <summary>
    /// Shared interface for Spot socket API usage
    /// </summary>
    public interface IBybitSocketClientSpotApiShared :
        ITickerSocketClient,
        ITradeSocketClient,
        IBookTickerSocketClient,
        IKlineSocketClient
    {
    }
}
