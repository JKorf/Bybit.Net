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

    /// <summary>
    /// Shared API interface. Shared APIs provide a common,
    /// exchange-independent contract for accessing functionality across different
    /// exchange client libraries.
    /// </summary>
    public interface IBybitSocketClientSpotSharedApi :
        ISubscribeTickerSocket,
        ISubscribeTradesSocket,
        ISubscribeBookTickerSocket,
        ISubscribeKlinesSocket
    { }
}
