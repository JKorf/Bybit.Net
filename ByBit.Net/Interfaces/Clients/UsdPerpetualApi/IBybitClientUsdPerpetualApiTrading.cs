using Bybit.Net.Enums;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Models;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.UsdPerpetualApi
{
    /// <summary>
    /// Bybit trading endpoints, placing and managing orders.
    /// </summary>
    public interface IBybitClientUsdPerpetualApiTrading
    {
        #region Orders
        /// <summary>
        /// Place a new order
        /// <para><a href="https://bybit-exchange.github.io/docs/linear/#t-placeactive" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="side">Order side</param>
        /// <param name="type">Order type</param>
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
        /// <param name="positionMode">Position mode</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitUsdPerpetualOrder>> PlaceOrderAsync(string symbol, OrderSide side, OrderType type, decimal quantity, TimeInForce timeInForce, bool reduceOnly, bool closeOnTrigger, decimal? price = null, string? clientOrderId = null, decimal? takeProfitPrice = null, decimal? stopLossPrice = null, TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null, PositionMode? positionMode = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Change an exising order. Either orderId or clientOrderId should be provided
        /// <para><a href="https://bybit-exchange.github.io/docs/linear/#t-replaceactive" /></para>
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
        /// Get orders
        /// <para><a href="https://bybit-exchange.github.io/docs/linear/#t-getactive" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="status">Filter by status</param>
        /// <param name="order">The result order</param>
        /// <param name="page">The page</param>
        /// <param name="pageSize">The page size</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitCursorPage<IEnumerable<BybitUsdPerpetualOrder>>>> GetOrdersAsync(string symbol, string? orderId = null, string? clientOrderId = null, OrderStatus? status = null, SortOrder? order = null, int? pageSize = null, int? page = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get order information for up to 500 orders
        /// <para><a href="https://bybit-exchange.github.io/docs/linear/#t-queryactive" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitUsdPerpetualOrder>>> GetOpenOrdersRealTimeAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get order information. Either orderId or clientOrderId should be provided
        /// <para><a href="https://bybit-exchange.github.io/docs/linear/#t-queryactive" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="orderId"></param>
        /// <param name="clientOrderId"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<BybitUsdPerpetualOrder>> GetOpenOrderRealTimeAsync(string symbol, string? orderId = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel an order, either orderId or clientOrderId should be provided
        /// <para><a href="https://bybit-exchange.github.io/docs/linear/#t-cancelactive" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="orderId">The id of the order to cancel</param>
        /// <param name="clientOrderId">The client order id of the conditional order to cancel</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitOrderId>> CancelOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel all active orders for a symbol
        /// <para><a href="https://bybit-exchange.github.io/docs/linear/#t-cancelallactive" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<string>>> CancelAllOrdersAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);
        #endregion

        #region Conditional orders
        /// <summary>
        /// Place a new conditional order
        /// <para><a href="https://bybit-exchange.github.io/docs/linear/#t-placecond" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="side">Order side</param>
        /// <param name="type">Order type</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="basePrice">It will be used to compare with the value of trigger price, to decide whether your conditional order will be triggered by crossing trigger price from upper side or lower side. Mainly used to identify the expected direction of the current conditional order.</param>
        /// <param name="triggerPrice">Trigger price</param>
        /// <param name="timeInForce">Time in force</param>
        /// <param name="price">Price</param>
        /// <param name="triggerType">Trigger type</param>
        /// <param name="reduceOnly">True means your position can only reduce in size if this order is triggered. When reduce_only is true, take profit/stop loss cannot be set</param>
        /// <param name="closeOnTrigger">For a closing order. It can only reduce your position, not increase it. If the account has insufficient available balance when the closing order is triggered, then other active orders of similar contracts will be cancelled or reduced. It can be used to ensure your stop loss reduces your position regardless of current available margin.</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="takeProfitPrice">Take profit price, only take effect upon opening the position</param>
        /// <param name="stopLossPrice">Stop loss price, only take effect upon opening the position</param>
        /// <param name="takeProfitTriggerType">Take profit trigger price type, default: LastPrice</param>
        /// <param name="stopLossTriggerType">Stop loss trigger price type, default: LastPrice</param>
        /// <param name="positionMode">Position mode</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitConditionalOrderUsd>> PlaceConditionalOrderAsync(string symbol, OrderSide side, OrderType type, decimal quantity, decimal basePrice, decimal triggerPrice, TimeInForce timeInForce, bool closeOnTrigger, bool reduceOnly, decimal? price = null, TriggerType? triggerType = null, string? clientOrderId = null, decimal? takeProfitPrice = null, decimal? stopLossPrice = null, TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null, PositionMode? positionMode = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Change an exising order. Either stopOrderId or clientOrderId should be provided
        /// <para><a href="https://bybit-exchange.github.io/docs/linear/#t-replacecond" /></para>
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
        /// Get order information for up to 10 conditional orders
        /// <para><a href="https://bybit-exchange.github.io/docs/linear/#t-querycond" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitConditionalOrder>>> GetOpenConditionalOrdersRealTimeAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get conditional order information. Either stopOrderId or clientOrderId should be provided
        /// <para><a href="https://bybit-exchange.github.io/docs/linear/#t-querycond" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="stopOrderId">The order id</param>
        /// <param name="clientOrderId">The client order id</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitConditionalOrderUsd>> GetOpenConditionalOrderRealTimeAsync(string symbol, string? stopOrderId = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get a list of conditional orders
        /// <para><a href="https://bybit-exchange.github.io/docs/linear/#t-getcond" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="stopOrderId">Filter by order id</param>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="status">Filter by status</param>
        /// <param name="order">Result order</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="page">Page</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitCursorPage<IEnumerable<BybitConditionalOrderUsd>>>> GetConditionalOrdersAsync(string symbol, string? stopOrderId = null, string? clientOrderId = null, OrderStatus? status = null, SortOrder? order = null, int? pageSize = null, int? page = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel a conditional order, either stopOrderId or clientOrderId should be provided
        /// <para><a href="https://bybit-exchange.github.io/docs/linear/#t-cancelcond" /></para>
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
        /// <para><a href="https://bybit-exchange.github.io/docs/linear/#t-cancelallcond" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<string>>> CancelAllConditionalOrdersAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);

        #endregion

        /// <summary>
        /// Get executed user trades
        /// <para><a href="https://bybit-exchange.github.io/docs/linear/#t-usertraderecords" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="type">Filter by type</param>
        /// <param name="page">Page</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitPage<IEnumerable<BybitUserTrade>>>> GetUserTradesAsync(string symbol, DateTime? startTime = null, DateTime? endTime = null, int? page = null, int? pageSize = null, TradeType? type = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Set take profit, stop loss, and trailing stop for your open position
        /// <para><a href="https://bybit-exchange.github.io/docs/linear/#t-tradingstop" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="side">The position side</param>
        /// <param name="takeProfitPrice">The new take profit price. Setting it to null will not change the value, setting it to 0 will remove the current TakeProfit</param>
        /// <param name="stopLossPrice">The new stop loss price. Setting it to null will not change the value, setting it to 0 will remove the current StopLoss</param>
        /// <param name="trailingStopPrice">Setting it to null will not change the value, setting it to 0 will remove the current TrailingStop</param>
        /// <param name="takeProfitTriggerType">Take profit trigger type, defaults to LastPrice</param>
        /// <param name="stopLossTriggerType">Stop loss trigger type, defaults to LastPrice</param>
        /// <param name="takeProfitQuantity">Take profit quantity when in Partial mode</param>
        /// <param name="stopLossQuantity">Stop loss quantity when in Partial mode</param>
        /// <param name="positionMode">Position mode</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetTradingStopAsync(
            string symbol,
            PositionSide side,
            decimal? takeProfitPrice = null,
            decimal? stopLossPrice = null,
            decimal? trailingStopPrice = null,
            TriggerType? takeProfitTriggerType = null,
            TriggerType? stopLossTriggerType = null,
            decimal? takeProfitQuantity = null,
            decimal? stopLossQuantity = null,
            PositionMode? positionMode = null,
            long? receiveWindow = null,
            CancellationToken ct = default);
    }
}