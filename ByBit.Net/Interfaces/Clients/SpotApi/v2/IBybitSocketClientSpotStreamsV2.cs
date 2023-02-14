using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.Socket.Spot;
using Bybit.Net.Objects.Models.Spot.v1;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.SpotApi.v2
{
    /// <summary>
    /// Bybit spot streams
    /// </summary>
    public interface IBybitSocketClientSpotStreamsV2 : ISocketApiClient
    {
        /// <summary>
        /// Subscribe to public trade updates
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v1/#t-websocketv2trade" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<BybitSpotTradeUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to order book updates
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v1/#t-websocketv2depth" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, Action<DataEvent<BybitSpotOrderBookUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to kline updates
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v1/#t-websocketv2kline" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="interval">Interval of the kline data</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, KlineInterval interval, Action<DataEvent<BybitSpotKlineUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to book price updates
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v1/#t-websocketv2bookticker" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToBookPriceUpdatesAsync(string symbol, Action<DataEvent<BybitSpotBookPriceV1>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to ticker updates
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v1/#t-websocketv2realtimes" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BybitSpotTickerUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to account data updates
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v1/#t-privatetopics" /></para>
        /// </summary>
        /// <param name="accountUpdateHandler">Account(balance) update handler</param>
        /// <param name="orderUpdateHandler">Order update handler</param>
        /// <param name="stopOrderUpdateHandler"> SL/TP order update handler</param>
        /// <param name="tradeUpdateHandler">User trade update handler</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToAccountUpdatesAsync(
            Action<DataEvent<BybitSpotAccountUpdate>> accountUpdateHandler,
            Action<DataEvent<BybitSpotOrderUpdate>> orderUpdateHandler,
            Action<DataEvent<BybitSpotStopOrderUpdate>> stopOrderUpdateHandler,
            Action<DataEvent<BybitSpotUserTradeUpdate>> tradeUpdateHandler,
            CancellationToken ct = default);
    }
}
