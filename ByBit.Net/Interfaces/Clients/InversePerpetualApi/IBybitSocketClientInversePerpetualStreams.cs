using Bybit.Net.Enums;
using Bybit.Net.Objects.Models;
using Bybit.Net.Objects.Models.Socket;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.InversePerpetualApi
{
    /// <summary>
    /// Bybit inverse perpetual streams
    /// </summary>
    public interface IBybitSocketClientInversePerpetualStreams : ISocketApiClient
    {
        /// <summary>
        /// Subscribe to public trade updates
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websockettrade" /></para>
        /// </summary>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradesUpdatesAsync(Action<DataEvent<IEnumerable<BybitTradeUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to public trade updates
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websockettrade" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to receive updates for</param>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<IEnumerable<BybitTradeUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to public trade updates
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websockettrade" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to receive updates for</param>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BybitTradeUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to ticker updates. Note that for a symbol the first update is a snapshot, containing all info. After that only partial updates are given for 
        /// properties which have changed. If a property in the update is `null` it isn't changed and should be ignored.
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketinstrumentinfo" /></para>
        /// </summary>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickersUpdatesAsync(Action<DataEvent<BybitTickerUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to ticker updates. Note that for a symbol the first update is a snapshot, containing all info. After that only partial updates are given for 
        /// properties which have changed. If a property in the update is `null` it isn't changed and should be ignored.
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketinstrumentinfo" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to receive updates for</param>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BybitTickerUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to ticker updates. Note that for a symbol the first update is a snapshot, containing all info. After that only partial updates are given for 
        /// properties which have changed. If a property in the update is `null` it isn't changed and should be ignored.
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketinstrumentinfo" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to receive updates for</param>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitTickerUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to orderbook updates
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketorderbook25" /></para>
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketorderbook200" /></para>
        /// </summary>
        /// <param name="limit">The amount of rows to receive updates for. Either 25 or 200.</param>
        /// <param name="snapshotHandler">The event handler for the initial snapshot data</param>
        /// <param name="updateHandler">The event handler for the update messages</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBooksUpdatesAsync(int limit, Action<DataEvent<IEnumerable<BybitOrderBookEntry>>> snapshotHandler, Action<DataEvent<BybitDeltaUpdate<BybitOrderBookEntry>>> updateHandler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to orderbook updates
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketorderbook25" /></para>
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketorderbook200" /></para>
        /// </summary>
        /// <param name="limit">The amount of rows to receive updates for. Either 25 or 200.</param>
        /// <param name="symbol">The symbol to receive updates for</param>
        /// <param name="snapshotHandler">The event handler for the initial snapshot data</param>
        /// <param name="updateHandler">The event handler for the update messages</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, int limit, Action<DataEvent<IEnumerable<BybitOrderBookEntry>>> snapshotHandler, Action<DataEvent<BybitDeltaUpdate<BybitOrderBookEntry>>> updateHandler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to orderbook updates
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketorderbook25" /></para>
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketorderbook200" /></para>
        /// </summary>
        /// <param name="limit">The amount of rows to receive updates for. Either 25 or 200.</param>
        /// <param name="symbols">The symbols to receive updates for</param>
        /// <param name="snapshotHandler">The event handler for the initial snapshot data</param>
        /// <param name="updateHandler">The event handler for the update messages</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(
           IEnumerable<string> symbols,
           int limit,
           Action<DataEvent<IEnumerable<BybitOrderBookEntry>>> snapshotHandler,
           Action<DataEvent<BybitDeltaUpdate<BybitOrderBookEntry>>> updateHandler,
           CancellationToken ct = default);

        /// <summary>
        /// Subscribe to insurance fund updates
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketinsurance" /></para>
        /// </summary>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToInsurancesUpdatesAsync(Action<DataEvent<IEnumerable<BybitInsuranceUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to insurance fund updates
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketinsurance" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to receive updates for</param>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToInsuranceUpdatesAsync(string symbol, Action<DataEvent<IEnumerable<BybitInsuranceUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to insurance fund updates
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketinsurance" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to receive updates for</param>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToInsuranceUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BybitInsuranceUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to kline (candlestick) updates
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketklinev2" /></para>
        /// </summary>
        /// <param name="interval">The interval of the klines</param>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlinesUpdatesAsync(KlineInterval interval, Action<DataEvent<IEnumerable<BybitKlineUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to kline (candlestick) updates
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketklinev2" /></para>
        /// </summary>
        /// <param name="interval">The interval of the klines</param>
        /// <param name="symbol">The symbol to receive updates for</param>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, KlineInterval interval, Action<DataEvent<IEnumerable<BybitKlineUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to kline (candlestick) updates
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketklinev2" /></para>
        /// </summary>
        /// <param name="interval">The interval of the klines</param>
        /// <param name="symbols">The symbols to receive updates for</param>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(IEnumerable<string> symbols, KlineInterval interval, Action<DataEvent<IEnumerable<BybitKlineUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to liquidation order updates
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketliquidation" /></para>
        /// </summary>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToLiquidationsUpdatesAsync(Action<DataEvent<BybitLiquidationUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to liquidation order updates
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketliquidation" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to receive updates for</param>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(string symbol, Action<DataEvent<BybitLiquidationUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to liquidation order updates
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketliquidation" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to receive updates for</param>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitLiquidationUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user position updates
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketposition" /></para>
        /// </summary>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(Action<DataEvent<IEnumerable<BybitPositionUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user trade updates
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketexecution" /></para>
        /// </summary>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(Action<DataEvent<IEnumerable<BybitUserTradeUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user order updates
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketorder" /></para>
        /// </summary>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<IEnumerable<BybitInverseOrderUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user stop order updates
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketstoporder" /></para>
        /// </summary>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToStopOrderUpdatesAsync(Action<DataEvent<IEnumerable<BybitStopOrderUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user balance updates
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketwallet" /></para>
        /// </summary>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(Action<DataEvent<IEnumerable<BybitBalanceUpdate>>> handler, CancellationToken ct = default);
    }
}
