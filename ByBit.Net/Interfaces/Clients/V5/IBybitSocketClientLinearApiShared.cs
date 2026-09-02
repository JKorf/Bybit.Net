using CryptoExchange.Net.SharedApis;

namespace Bybit.Net.Interfaces.Clients.V5
{
    /// <summary>
    /// Shared interface for Spot linear futures API usage
    /// </summary>
    public interface IBybitSocketClientLinearApiShared :
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
    public interface IBybitSocketClientLinearSharedApi :
        ISubscribeTickerSocket,
        ISubscribeTradesSocket,
        ISubscribeBookTickerSocket,
        ISubscribeKlinesSocket
    { }
}
