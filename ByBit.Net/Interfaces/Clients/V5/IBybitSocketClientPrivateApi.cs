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
    /// Bybit user data streams
    /// </summary>
    public interface IBybitSocketClientPrivateApi : ISocketApiClient
    {
        /// <summary>
        /// Subscribe to Greek updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/private/greek" /></para>
        /// </summary>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToGreekUpdatesAsync(Action<DataEvent<IEnumerable<BybitGreeks>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to order updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/private/order" /></para>
        /// </summary>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<IEnumerable<BybitOrderUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to position updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/private/position" /></para>
        /// </summary>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(Action<DataEvent<IEnumerable<BybitPositionUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to trade updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/private/execution" /></para>
        /// </summary>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(Action<DataEvent<IEnumerable<BybitUserTradeUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to wallet balance updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/private/wallet" /></para>
        /// </summary>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToWalletUpdatesAsync(Action<DataEvent<IEnumerable<BybitBalance>>> handler, CancellationToken ct = default);
    }
}