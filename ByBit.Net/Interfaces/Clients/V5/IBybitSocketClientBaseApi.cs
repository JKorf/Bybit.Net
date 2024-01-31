using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.V5
{
    /// <summary>
    /// Bybit streaming data subscriptions
    /// </summary>
    public interface IBybitSocketClientBaseApi : ISocketApiClient
    {
        /// <summary>
        /// Subscribe to kline updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/kline" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to subscribe</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(IEnumerable<string> symbols, KlineInterval interval, Action<DataEvent<IEnumerable<BybitKlineUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to kline updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/kline" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to subscribe</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, KlineInterval interval, Action<DataEvent<IEnumerable<BybitKlineUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to order book updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/orderbook" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to subscribe</param>
        /// <param name="depth">The order book depth</param>
        /// <param name="updateHandler">Update handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderbookUpdatesAsync(IEnumerable<string> symbols, int depth, Action<DataEvent<BybitOrderbook>> updateHandler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to order book updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/orderbook" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to subscribe</param>
        /// <param name="depth">The order book depth</param>
        /// <param name="updateHandler">Update handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderbookUpdatesAsync(string symbol, int depth, Action<DataEvent<BybitOrderbook>> updateHandler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to public trade updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/trade" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to subscribe</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BybitTrade>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to public trade updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/trade" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to subscribe</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<IEnumerable<BybitTrade>>> handler, CancellationToken ct = default);
    }
}