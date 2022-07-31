using Bybit.Net.Enums;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Models;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.InverseFuturesApi
{
    /// <summary>
    /// Bybit trading endpoints, placing and managing orders.
    /// </summary>
    public interface IBybitClientInverseFuturesApiTrading
    {
        #region Orders
        /// <summary>
        /// Place a new order
        /// <para><a href="https://bybit-exchange.github.io/docs/inverse_futures/#t-placeactive" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="side">Order side</param>
        /// <param name="type">Order type</param>
        /// <param name="positionMode">Position mode</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="timeInForce">Time in force</param>
        /// <param name="price">Price</param>
        /// <param name="reduceOnly">True means your position can only reduce in size if this order is triggered</param>
        /// <param name="closeOnTrigger">For a closing order. It can only reduce your position, not increase it. If the account has insufficient available balance when the closing order is triggered, then other active orders of similar contracts will be cancelled or reduced. It can be used to ensure your stop loss reduces your position regardless of current available margin.</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="takeProfitPrice">Take profit price, only take effect upon opening the position</param>
        /// <param name="stopLossPrice">Stop loss price, only take effect upon opening the position</param>
        /// <param name="takeProfitTriggerType">Take profit trigger price type, default: LastPrice</param>
        /// <param name="stopLossTriggerType">Stop loss trigger price type, default: LastPrice</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitInverseOrder>> PlaceOrderAsync(string symbol, OrderSide side, OrderType type, PositionMode positionMode, decimal quantity, TimeInForce timeInForce, decimal? price = null, bool? closeOnTrigger = null, string? clientOrderId = null, decimal? takeProfitPrice = null, decimal? stopLossPrice = null, TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null, bool? reduceOnly = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Change an exising order. Either orderId or clientOrderId should be provided
        /// <para><a href="https://bybit-exchange.github.io/docs/inverse_futures/#t-replaceactive" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="orderId">Stop order id</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="newPrice">New price to set</param>
        /// <param name="newQuantity">New quantity to set</param>
        /// <param name="takeProfitPrice">New take profit price</param>
        /// <param name="stopLossPrice">New stop loss price</param>
        /// <param name="takeProfitTriggerType">New take profit trigger type</param>
        /// <param name="stopLossTriggerType">New stop loss profit price</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitOrderId>> ModifyOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, decimal? newPrice = null, decimal? newQuantity = null, decimal? takeProfitPrice = null, decimal? stopLossPrice = null, TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get order information. Either orderId or clientOrderId should be provided
        /// <para><a href="https://bybit-exchange.github.io/docs/inverse_futures/#t-queryactive" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="orderId"></param>
        /// <param name="clientOrderId"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<BybitInverseOrder>> GetOpenOrderRealTimeAsync(string symbol, string? orderId = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get order information for up to 500 orders
        /// <para><a href="https://bybit-exchange.github.io/docs/inverse_futures/#t-queryactive" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitInverseOrder>>> GetOpenOrdersRealTimeAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get orders
        /// <para><a href="https://bybit-exchange.github.io/docs/inverse_futures/#t-getactive" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="status">Filter by status</param>
        /// <param name="direction">Filter by direction</param>
        /// <param name="limit">Max amount of results</param>
        /// <param name="cursor">Page cursor</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitCursorPage<IEnumerable<BybitInverseOrder>>>> GetOrdersAsync(string symbol, OrderStatus? status = null, SearchDirection? direction = null, int? limit = null, string? cursor = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel an order, either orderId or clientOrderId should be provided
        /// <para><a href="https://bybit-exchange.github.io/docs/inverse_futures/#t-cancelactive" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="orderId">The id of the order to cancel</param>
        /// <param name="clientOrderId">The client order id of the conditional order to cancel</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitInverseOrder>> CancelOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel all active orders for a symbol
        /// <para><a href="https://bybit-exchange.github.io/docs/inverse_futures/#t-cancelallactive" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitCanceledOrder>>> CancelAllOrdersAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);

        #endregion

        #region Conditional orders
        /// <summary>
        /// Place a new conditional order
        /// <para><a href="https://bybit-exchange.github.io/docs/inverse_futures/#t-placecond" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="side">Order side</param>
        /// <param name="type">Order type</param>
        /// <param name="positionMode">Position mode</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="basePrice">It will be used to compare with the value of trigger price, to decide whether your conditional order will be triggered by crossing trigger price from upper side or lower side. Mainly used to identify the expected direction of the current conditional order.</param>
        /// <param name="triggerPrice">Trigger price</param>
        /// <param name="timeInForce">Time in force</param>
        /// <param name="price">Price</param>
        /// <param name="triggerType">Trigger type</param>
        /// <param name="closeOnTrigger">For a closing order. It can only reduce your position, not increase it. If the account has insufficient available balance when the closing order is triggered, then other active orders of similar contracts will be cancelled or reduced. It can be used to ensure your stop loss reduces your position regardless of current available margin.</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="takeProfitPrice">Take profit price, only take effect upon opening the position</param>
        /// <param name="stopLossPrice">Stop loss price, only take effect upon opening the position</param>
        /// <param name="takeProfitTriggerType">Take profit trigger price type, default: LastPrice</param>
        /// <param name="stopLossTriggerType">Stop loss trigger price type, default: LastPrice</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitConditionalOrder>> PlaceConditionalOrderAsync(string symbol, OrderSide side, OrderType type, PositionMode positionMode, decimal quantity, decimal basePrice, decimal triggerPrice, TimeInForce timeInForce, decimal? price = null, TriggerType? triggerType = null, bool? closeOnTrigger = null, string? clientOrderId = null, decimal? takeProfitPrice = null, decimal? stopLossPrice = null, TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Change an exising order. Either stopOrderId or clientOrderId should be provided
        /// <para><a href="https://bybit-exchange.github.io/docs/inverse_futures/#t-replacecond" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="stopOrderId">Stop order id</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="newPrice">New price to set</param>
        /// <param name="newTriggerPrice">New trigger price to set</param>
        /// <param name="newQuantity">New quantity to set</param>
        /// <param name="takeProfitPrice">New take profit price</param>
        /// <param name="stopLossPrice">New stop loss price</param>
        /// <param name="takeProfitTriggerType">New take profit trigger type</param>
        /// <param name="stopLossTriggerType">New stop loss profit price</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitStopOrderId>> ModifyConditionalOrderAsync(string symbol, string? stopOrderId = null, string? clientOrderId = null, decimal? newPrice = null, decimal? newTriggerPrice = null, decimal? newQuantity = null, decimal? takeProfitPrice = null, decimal? stopLossPrice = null, TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get a list of conditional orders
        /// <para><a href="https://bybit-exchange.github.io/docs/inverse_futures/#t-getcond" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="status">Filter by status</param>
        /// <param name="direction">Filter by direction</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="cursor">Page cursor</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitCursorPage<IEnumerable<BybitConditionalOrder>>>> GetConditionalOrdersAsync(string symbol, StopOrderStatus? status = null, SearchDirection? direction = null, int? limit = null, string? cursor = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get conditional order information. Either stopOrderId or clientOrderId should be provided
        /// <para><a href="https://bybit-exchange.github.io/docs/inverse_futures/#t-querycond" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="stopOrderId">The order id</param>
        /// <param name="clientOrderId">The client order id</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitConditionalOrder>> GetOpenConditionalOrderRealTimeAsync(string symbol, string? stopOrderId = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get order information for up to 10 conditional orders
        /// <para><a href="https://bybit-exchange.github.io/docs/inverse_futures/#t-querycond" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitConditionalOrder>>> GetOpenConditionalOrdersRealTimeAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel a conditional order, either stopOrderId or clientOrderId should be provided
        /// <para><a href="https://bybit-exchange.github.io/docs/inverse_futures/#t-cancelcond" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="stopOrderId">The id of the conditional order to cancel</param>
        /// <param name="clientOrderId">The client order id of the conditional order to cancel</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitStopOrderId>> CancelConditionalOrderAsync(string symbol, string? stopOrderId = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel all active conditional orders for a symbol
        /// <para><a href="https://bybit-exchange.github.io/docs/inverse_futures/#t-cancelallcond" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitCanceledConditionalOrder>>> CancelAllConditionalOrdersAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);

        #endregion

        /// <summary>
        /// Get executed user trades
        /// <para><a href="https://bybit-exchange.github.io/docs/inverse_futures/#t-usertraderecords" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="page">Page</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitUserTrade>>> GetUserTradesAsync(string symbol, string? orderId = null, DateTime? startTime = null, int? page = null, int? pageSize = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Set take profit, stop loss, and trailing stop for your open position
        /// <para><a href="https://bybit-exchange.github.io/docs/inverse_futures/#t-tradingstop" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="positionMode">The position mode</param>
        /// <param name="takeProfitPrice">The new take profit price. Setting it to null will not change the value, setting it to 0 will remove the current TakeProfit</param>
        /// <param name="stopLossPrice">The new stop loss price. Setting it to null will not change the value, setting it to 0 will remove the current StopLoss</param>
        /// <param name="trailingStopPrice">Setting it to null will not change the value, setting it to 0 will remove the current TrailingStop</param>
        /// <param name="takeProfitTriggerType">Take profit trigger type, defaults to LastPrice</param>
        /// <param name="stopLossTriggerType">Stop loss trigger type, defaults to LastPrice</param>
        /// <param name="trailingStopTriggerPrice">Trailing stop trigger price. Trailing stops are triggered only when the price reaches the specified price. Trailing stops are triggered immediately by default.</param>
        /// <param name="takeProfitQuantity">Take profit quantity when in Partial mode</param>
        /// <param name="stopLossQuantity">Stop loss quantity when in Partial mode</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitPosition>> SetTradingStopAsync(
            string symbol,
            PositionMode positionMode,
            decimal? takeProfitPrice = null,
            decimal? stopLossPrice = null,
            decimal? trailingStopPrice = null,
            TriggerType? takeProfitTriggerType = null,
            TriggerType? stopLossTriggerType = null,
            decimal? trailingStopTriggerPrice = null,
            decimal? takeProfitQuantity = null,
            decimal? stopLossQuantity = null,
            long? receiveWindow = null,
            CancellationToken ct = default);
    }
}