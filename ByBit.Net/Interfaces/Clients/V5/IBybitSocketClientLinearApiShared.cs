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
}
