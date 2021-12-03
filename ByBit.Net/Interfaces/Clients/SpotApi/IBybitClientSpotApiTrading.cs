using Bybit.Net.Enums;
using Bybit.Net.Objects.Models;
using Bybit.Net.Objects.Models;
using Bybit.Net.Objects.Models.Spot;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.Rest.Futures
{
    /// <summary>
    /// Bybit trading endpoints, placing and mananging orders.
    /// </summary>
    public interface IBybitClientSpotApiTrading
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="side"></param>
        /// <param name="type"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        /// <param name="timeInForce"></param>
        /// <param name="clientOrderId"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<BybitSpotOrderPlaced>> PlaceOrderAsync(string symbol, OrderSide side, OrderType type, decimal quantity, decimal? price = null, TimeInForce? timeInForce = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="clientOrderId"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<BybitSpotOrder>> GetOrderAsync(long? orderId = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="orderId"></param>
        /// <param name="limit"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitSpotOrder>>> GetOpenOrdersAsync(string? symbol = null, long? orderId = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="orderId"></param>
        /// <param name="limit"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitSpotOrder>>> GetOrdersAsync(string? symbol = null, long? orderId = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="clientOrderId"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<BybitSpotOrderPlaced>> CancelOrderAsync(long? orderId = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="fromId"></param>
        /// <param name="toId"></param>
        /// <param name="limit"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitSpotUserTrade>>> GetUserTradesAsync(string? symbol = null, long? fromId = null, long? toId = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);
    }
}