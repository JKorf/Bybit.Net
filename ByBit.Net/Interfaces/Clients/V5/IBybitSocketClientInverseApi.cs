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
    /// Bybit inverse contract data streams
    /// </summary>
    public interface IBybitSocketClientInverseApi : IBybitSocketClientBaseApi
    {
        /// <summary>
        /// Get the shared socket subscription client. This interface is shared with other exhanges to allow for a common implementation for different exchanges.
        /// </summary>
        IBybitSocketClientInverseApiShared SharedClient { get; }

        /// <summary>
        /// Subscribe to ticker updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/ticker" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to subscribe, for example `ETHUSDT`</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitLinearTickerUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to ticker updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/ticker" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to subscribe, for example `ETHUSDT`</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BybitLinearTickerUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to liquidation updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/liquidation" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to subscribe, for example `ETHUSDT`</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitLiquidation>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to liquidation updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/liquidation" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to subscribe, for example `ETHUSDT`</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(string symbol, Action<DataEvent<BybitLiquidation>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to public trade updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/trade" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to subscribe, for example `ETHUSDT`</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BybitTrade>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to public trade updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/trade" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to subscribe, for example `ETHUSDT`</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<IEnumerable<BybitTrade>>> handler, CancellationToken ct = default);
    }
}