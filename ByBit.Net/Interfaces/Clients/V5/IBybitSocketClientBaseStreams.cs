using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.V5
{
    /// <summary>
    /// Bybit streaming data subscriptions
    /// </summary>
    public interface IBybitSocketClientBaseStreams : ISocketApiClient
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
        /// Subscribe to liquidation updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/liquidation" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to subscribe</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BybitLiquidation>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to liquidation updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/liquidation" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to subscribe</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(string symbol, Action<DataEvent<IEnumerable<BybitLiquidation>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to order book updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/orderbook" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to subscribe</param>
        /// <param name="depth">The order book depth</param>
        /// <param name="snapshotHandler">Handler for a snapshot update. Snapshot updates contain the full order book</param>
        /// <param name="updateHandler">Handler for updates. These will only contain the changed entries</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderbookUpdatesAsync(IEnumerable<string> symbols, int depth, Action<DataEvent<BybitOrderbook>> snapshotHandler, Action<DataEvent<BybitOrderbook>> updateHandler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to order book updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/orderbook" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to subscribe</param>
        /// <param name="depth">The order book depth</param>
        /// <param name="snapshotHandler">Handler for a snapshot update. Snapshot updates contain the full order book</param>
        /// <param name="updateHandler">Handler for updates. These will only contain the changed entries</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderbookUpdatesAsync(string symbol, int depth, Action<DataEvent<BybitOrderbook>> snapshotHandler, Action<DataEvent<BybitOrderbook>> updateHandler, CancellationToken ct = default);

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