using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.Socket.Spot;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.SpotApi.v1
{
    /// <summary>
    /// Bybit spot streams
    /// </summary>
    public interface IBybitSocketClientSpotStreamsV1 : ISocketApiClient
    {
        /// <summary>
        /// Subscribe to public trade updates
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v1/#t-websockettrade" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<BybitSpotTradeUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to order book updates
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v1/#t-websocketdepth" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, Action<DataEvent<BybitSpotOrderBookUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to kline updates
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v1/#t-websocketkline" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="interval">Interval of the kline data</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, KlineInterval interval, Action<DataEvent<BybitSpotKlineUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to ticker updates
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v1/#t-websocketrealtimes" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BybitSpotTickerUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to aggregated order book updates
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v1/#t-websocketmergeddepth" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="dumpScale">It refers to the number of decimal places, eg 1 for 50000.5 or 0 for 50000</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookMergedUpdatesAsync(string symbol, int dumpScale, Action<DataEvent<BybitSpotOrderBookUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to diff of order book updates
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v1/#t-websocketdiffdepth" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookDiffUpdatesAsync(string symbol, Action<DataEvent<BybitSpotOrderBookUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to leverage token net value updates
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v1/#t-websocketltnetvalue" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToLeverageTokenUpdatesAsync(string symbol, Action<DataEvent<BybitSpotLeverageUpdate>> handler, CancellationToken ct = default);
    }
}
