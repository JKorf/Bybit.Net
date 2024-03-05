using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.Socket.Spot;
using CryptoExchange.Net.Objects;
using System;
using System.Threading;
using System.Threading.Tasks;
using Bybit.Net.Objects.Models.Spot.v3;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects.Sockets;

namespace Bybit.Net.Interfaces.Clients.SpotApi.v3
{
    /// <summary>
    /// Bybit spot streams
    /// </summary>
    public interface IBybitSocketClientSpotApiV3 : ISocketApiClient
    {
        /// <summary>
        /// Subscribe to public trade updates
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v3/#t-websockettrade" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<BybitSpotTradeUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to order book updates
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v3/#t-websocketdepth" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, Action<DataEvent<BybitSpotOrderBookUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to kline updates
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/#t-websocketv2kline" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="interval">Interval of the kline data</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, KlineInterval interval, Action<DataEvent<BybitSpotKlineUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to book price updates
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/#t-websocketv2bookticker" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToBookPriceUpdatesAsync(string symbol, Action<DataEvent<BybitSpotBookPriceV3>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to ticker updates
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/#t-websocketv2realtimes" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BybitSpotTickerUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to account balances update
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/#t-privatetopics" /></para>
        /// </summary>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToAccountUpdatesAsync(Action<DataEvent<BybitSpotAccountUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to orders updates
        /// </summary>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToUserOrdersUpdatesAsync(Action<DataEvent<BybitSpotOrderUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to SL/TP orders updates
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v3/#t-websocketspotstoporder" /></para>
        /// </summary>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToUserStopOrdersUpdatesAsync(Action<DataEvent<BybitSpotStopOrderUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Susbcribe to user trade updates
        /// </summary>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToUserTradesUpdatesAsync(Action<DataEvent<BybitSpotUserTradeUpdate>> handler, CancellationToken ct = default);
    }
}
