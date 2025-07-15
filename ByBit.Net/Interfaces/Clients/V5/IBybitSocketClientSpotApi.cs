using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.V5
{
    /// <summary>
    /// Bybit spot data streams
    /// </summary>
    public interface IBybitSocketClientSpotApi : IBybitSocketClientBaseApi
    {
        /// <summary>
        /// Get the shared socket subscription client. This interface is shared with other exchanges to allow for a common implementation for different exchanges.
        /// </summary>
        IBybitSocketClientSpotApiShared SharedClient { get; }

        /// <summary>
        /// Subscribe to leveraged token kline updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/etp-kline" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to subscribe, for example `ETHUSDT`</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToLeveragedTokenKlineUpdatesAsync(IEnumerable<string> symbols, KlineInterval interval, Action<DataEvent<BybitKlineUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to leveraged token kline updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/etp-kline" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to subscribe, for example `ETHUSDT`</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToLeveragedTokenKlineUpdatesAsync(string symbol, KlineInterval interval, Action<DataEvent<BybitKlineUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to leveraged token NAV updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/etp-nav" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to subscribe, for example `ETHUSDT`</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToLeveragedTokenNavUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitLeveragedTokenNav>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to leveraged token NAV updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/etp-nav" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to subscribe, for example `ETHUSDT`</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToLeveragedTokenNavUpdatesAsync(string symbol, Action<DataEvent<BybitLeveragedTokenNav>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to leveraged token ticker updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/etp-ticker" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to subscribe, for example `ETHUSDT`</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToLeveragedTokenTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitLeveragedTokenTicker>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to leveraged token ticker updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/etp-ticker" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to subscribe, for example `ETHUSDT`</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToLeveragedTokenTickerUpdatesAsync(string symbol, Action<DataEvent<BybitLeveragedTokenTicker>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to ticker updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/ticker" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to subscribe, for example `ETHUSDT`</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitSpotTickerUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to ticker updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/ticker" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to subscribe, for example `ETHUSDT`</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BybitSpotTickerUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to public trade updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/trade" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to subscribe, for example `ETHUSDT`</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitTrade[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to public trade updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/trade" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to subscribe, for example `ETHUSDT`</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<BybitTrade[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to order price limit updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/order-price-limit" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to subscribe, for example `ETHUSDT`</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        Task<CallResult<UpdateSubscription>> SubscribeToPriceLimitUpdatesAsync(string symbol, Action<DataEvent<BybitOrderPriceLimit>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to order price limit updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/order-price-limit" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to subscribe, for example `ETHUSDT`</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        Task<CallResult<UpdateSubscription>> SubscribeToPriceLimitUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitOrderPriceLimit>> handler, CancellationToken ct = default);
    }
}
