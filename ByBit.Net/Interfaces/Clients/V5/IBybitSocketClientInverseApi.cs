﻿using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
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
        /// Subscribe to ticker updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/ticker" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to subscribe</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitLinearTickerUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to ticker updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/ticker" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to subscribe</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BybitLinearTickerUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to liquidation updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/liquidation" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to subscribe</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitLiquidation>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to liquidation updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/public/liquidation" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to subscribe</param>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(string symbol, Action<DataEvent<BybitLiquidation>> handler, CancellationToken ct = default);

    }
}