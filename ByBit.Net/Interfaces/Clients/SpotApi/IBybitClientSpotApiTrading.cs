using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.Spot;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.SpotApi
{
    /// <summary>
    /// Bybit trading endpoints, placing and managing orders.
    /// </summary>
    public interface IBybitClientSpotApiTrading
    {
        /// <summary>
        /// Place a new order
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/#t-placeactive" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="side">Order side</param>
        /// <param name="type">Order type</param>
        /// <param name="quantity">Quantity of the order. Note that for market buy orders this is the quantity of quote asset, otherwise it's in base asset</param>
        /// <param name="price">Price</param>
        /// <param name="timeInForce">Time in force</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitSpotOrderPlaced>> PlaceOrderAsync(string symbol, OrderSide side, OrderType type, decimal quantity, decimal? price = null, TimeInForce? timeInForce = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get order, either orderId or clientOrderId should be provided
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/#t-getactive" /></para>
        /// </summary>
        /// <param name="orderId">The id of the order</param>
        /// <param name="clientOrderId">The client order id</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitSpotOrder>> GetOrderAsync(long? orderId = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get open orders
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/#t-openorders" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="orderId">Filter by order id, will only return orders with an orderId smaller than this</param>
        /// <param name="limit">Max amount of results</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitSpotOrder>>> GetOpenOrdersAsync(string? symbol = null, long? orderId = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get orders
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/#t-orderhistory" /></para>
        /// </summary>
        /// <param name="symbol">Filter by symbol</param>
        /// <param name="orderId">Filter by order id, will only return orders with an orderId smaller than this</param>
        /// <param name="limit">Max amount of results</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitSpotOrder>>> GetOrdersAsync(string? symbol = null, long? orderId = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel an active order. Either orderId or clientOrderId should be provided
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/#t-cancelactive" /></para>
        /// </summary>
        /// <param name="orderId">The order id</param>
        /// <param name="clientOrderId">The client order id</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitSpotOrderPlaced>> CancelOrderAsync(long? orderId = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel multiple orders based on the provided parameters
        /// </summary>
        /// <param name="symbol">The symbol to cancel orders on</param>
        /// <param name="side">Only cancel buy or sell orders</param>
        /// <param name="orderTypes">Only cancel orders fitting the order types, default only cancels Limit orders (not LimitMaker orders)</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> CancelMultipleOrderAsync(string symbol, OrderSide? side = null, IEnumerable<OrderType>? orderTypes = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get user trade history
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/#t-tradehistory" /></para>
        /// </summary>
        /// <param name="symbol">Filter by symbol</param>
        /// <param name="fromId">Filter by start id</param>
        /// <param name="toId">Filter by end id</param>
        /// <param name="limit">Max amount of results</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitSpotUserTrade>>> GetUserTradesAsync(string? symbol = null, long? fromId = null, long? toId = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Place a new borrow order
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/#t-borrowmarginloan" /></para>
        /// </summary>
        /// <param name="asset">The asset to borrow</param>
        /// <param name="quantity">The quantity to borrow</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<long>> PlaceBorrowOrderAsync(string asset, decimal quantity, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Place a new borrow order
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/#t-repaymarginloan" /></para>
        /// </summary>
        /// <param name="asset">The asset to repay</param>
        /// <param name="quantity">The quantity to repay</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<long>> PlaceRepayOrderAsync(string asset, decimal quantity, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get borrow records
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/#t-queryborrowinginfo" /></para>
        /// </summary>
        /// <param name="startTime">Filter by borrow time</param>
        /// <param name="endTime">Filter by borrow time</param>
        /// <param name="asset">Filter by asset</param>
        /// <param name="status">Filter by status</param>
        /// <param name="limit">Max amount of results</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitBorrowRecord>>> GetBorrowRecordsAsync(DateTime? startTime = null, DateTime? endTime = null, string? asset = null, BorrowStatus? status = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get repayment records
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/#t-queryrepaymenthistory" /></para>
        /// </summary>
        /// <param name="startTime">Filter by borrow time</param>
        /// <param name="endTime">Filter by borrow time</param>
        /// <param name="asset">Filter by asset</param>
        /// <param name="limit">Max amount of results</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitRepayRecord>>> GetRepayRecordsAsync(DateTime? startTime = null, DateTime? endTime = null, string? asset = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);
    }
}