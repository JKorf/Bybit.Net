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
        /// <param name="symbols">The symbols to subscribe, for example `ETHUSDT`</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(IEnumerable<string> symbols, KlineInterval interval, Action<DataEvent<BybitKlineUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to kline updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/kline" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to subscribe, for example `ETHUSDT`</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, KlineInterval interval, Action<DataEvent<BybitKlineUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to order book updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/orderbook" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to subscribe, for example `ETHUSDT`</param>
        /// <param name="depth">The order book depth</param>
        /// <param name="updateHandler">Update handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderbookUpdatesAsync(IEnumerable<string> symbols, int depth, Action<DataEvent<BybitOrderbook>> updateHandler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to order book updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/orderbook" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to subscribe, for example `ETHUSDT`</param>
        /// <param name="depth">The order book depth<br />
        /// Linear, Inverse and spot symbols: 1, 50, 200 or 1000<br />
        /// Option symbols: 25 or 100
        /// </param>
        /// <param name="updateHandler">Update handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderbookUpdatesAsync(string symbol, int depth, Action<DataEvent<BybitOrderbook>> updateHandler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to RPI order book updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/orderbook-rpi" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to subscribe, for example `ETHUSDT`</param>
        /// <param name="updateHandler">Update handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        Task<CallResult<UpdateSubscription>> SubscribeToRpiOrderbookUpdatesAsync(string symbol, Action<DataEvent<BybitRpiOrderbook>> updateHandler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to RPI order book updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/orderbook-rpi" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to subscribe, for example `ETHUSDT`</param>
        /// <param name="updateHandler">Update handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        Task<CallResult<UpdateSubscription>> SubscribeToRpiOrderbookUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitRpiOrderbook>> updateHandler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to system status updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/system/system-status" /></para>
        /// </summary>
        /// <param name="handler">Update handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        Task<CallResult<UpdateSubscription>> SubscribeToSystemStatusUpdatesAsync(Action<DataEvent<BybitSystemStatus[]>> handler, CancellationToken ct = default);
    }
}
