using CryptoExchange.Net.SharedApis;

namespace Bybit.Net.Interfaces.Clients.V5
{
    /// <summary>
    /// Shared interface for private user socket API usage
    /// </summary>
    public interface IBybitSocketClientPrivateApiShared :
        IBalanceSocketClient,
        ISpotOrderSocketClient,
        IFuturesOrderSocketClient,
        IUserTradeSocketClient,
        IPositionSocketClient,
        ISpotOrderManagementSocketClient,
        IFuturesOrderManagementSocketClient
    {
    }

    /// <summary>
    /// Shared API interface. Shared APIs provide a common,
    /// exchange-independent contract for accessing functionality across different
    /// exchange client libraries.
    /// </summary>
    public interface IBybitSocketClientPrivateSharedApi :
        ISubscribeBalancesSocket,
        ISubscribeSpotOrdersSocket,
        ISubscribeFuturesOrdersSocket,
        ISubscribeUserTradesSocket,
        ISubscribePositionsSocket,
        IPlaceSpotOrderSocket,
        ICancelSpotOrderSocket,
        IPlaceFuturesOrderSocket,
        ICancelFuturesOrderSocket
    { }
}
