using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.Derivatives;
using Bybit.Net.Objects.Models.Socket.Derivatives;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.DerivativesApi
{
    /// <summary>
    /// Bybit public Derivatives streams
    /// </summary>
    public interface IBybitSocketClientDerivativesPublicApi : ISocketApiClient
    {
        /// <summary>
        /// Subscribe to orderbook updates
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketorderbookdepth" /></para>
        /// </summary>
        /// <param name="category">Asset category</param>
        /// <param name="limit">The amount of rows to receive updates for. Either 1, 25, 50, 100, 200.</param>
        /// <param name="handler">The event handler for the messages</param>
        /// <param name="symbol">The symbol to receive updates for</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(StreamDerivativesCategory category, string symbol, int limit, Action<DataEvent<BybitDerivativesOrderBookEntry>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to orderbook updates
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketorderbookdepth" /></para>
        /// </summary>
        /// <param name="category">Asset category</param>
        /// <param name="limit">The amount of rows to receive updates for. Either 1, 25, 50, 100, 200.</param>
        /// <param name="handler">The event handler for the messages</param>
        /// <param name="symbols">List of symbols to receive updates for</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBooksUpdatesAsync(StreamDerivativesCategory category, IEnumerable<string> symbols, int limit, Action<DataEvent<BybitDerivativesOrderBookEntry>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to public trade updates
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websockettrade" /></para>
        /// </summary>
        /// <param name="category">Asset category</param>
        /// <param name="symbol">The symbol to receive updates for</param>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(StreamDerivativesCategory category, string symbol, Action<DataEvent<IEnumerable<BybitDerivativesTradeUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to public trade updates
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websockettrade" /></para>
        /// </summary>
        /// <param name="category">Asset category</param>
        /// <param name="symbols">List of symbols to receive updates for</param>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradesUpdatesAsync(StreamDerivativesCategory category, IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BybitDerivativesTradeUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to ticker updates. Note that for a symbol the first update is a snapshot, containing all info. After that only partial updates are given for 
        /// properties which have changed. If a property in the update is `null` it isn't changed and should be ignored.
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketticker_v3" /></para>
        /// </summary>
        /// <param name="category">Asset category</param>
        /// <param name="symbol">The symbol to receive updates for</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(StreamDerivativesCategory category, string symbol, Action<DataEvent<BybitDerivativesTicker>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to ticker updates. Note that for a symbol the first update is a snapshot, containing all info. After that only partial updates are given for 
        /// properties which have changed. If a property in the update is `null` it isn't changed and should be ignored.
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketticker_v3" /></para>
        /// </summary>
        /// <param name="category">Asset category</param>
        /// <param name="symbols">List of symbols to receive updates for</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickersUpdatesAsync(StreamDerivativesCategory category, IEnumerable<string> symbols, Action<DataEvent<BybitDerivativesTicker>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to kline (candlestick) updates
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketkline" /></para>
        /// </summary>
        /// <param name="category">Asset category</param>
        /// <param name="interval">The interval of the klines</param>
        /// <param name="symbol">The symbol to receive updates for</param>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(StreamDerivativesCategory category, string symbol, KlineInterval interval, Action<DataEvent<IEnumerable<BybitDerivativesKlineUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to kline (candlestick) updates
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketkline" /></para>
        /// </summary>
        /// <param name="category">Asset category</param>
        /// <param name="interval">The interval of the klines</param>
        /// <param name="symbols">List of symbols to receive updates for</param>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlinesUpdatesAsync(StreamDerivativesCategory category, IEnumerable<string> symbols, KlineInterval interval, Action<DataEvent<IEnumerable<BybitDerivativesKlineUpdate>>> handler, CancellationToken ct = default);
    }
}
