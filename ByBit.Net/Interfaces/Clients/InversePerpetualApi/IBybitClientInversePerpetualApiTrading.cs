using Bybit.Net.Enums;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Models;
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
    public interface IBybitClientInversePerpetualApiTrading
    {
        Task<WebCallResult<IEnumerable<BybitCanceledConditionalOrder>>> CancelAllConditionalOrdersAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<IEnumerable<BybitCanceledOrder>>> CancelAllOrdersAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<BybitStopOrderId>> CancelConditionalOrderAsync(string symbol, string? stopOrderId = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<BybitOrder>> CancelOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<BybitCursorPage<IEnumerable<BybitConditionalOrder>>>> GetConditionalOrdersAsync(string symbol, StopOrderStatus? status = null, SearchDirection? direction = null, int? limit = null, string? cursor = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<BybitConditionalOrder>> GetOpenConditionalOrderRealTimeAsync(string symbol, string? stopOrderId = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<IEnumerable<BybitConditionalOrder>>> GetOpenConditionalOrdersRealTimeAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<BybitOrder>> GetOpenOrderRealTimeAsync(string symbol, string? orderId = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<IEnumerable<BybitOrder>>> GetOpenOrdersRealTimeAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<BybitCursorPage<IEnumerable<BybitOrder>>>> GetOrdersAsync(string symbol, OrderStatus? status = null, SearchDirection? direction = null, int? limit = null, string? cursor = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<IEnumerable<BybitUserTrade>>> GetUserTradesAsync(string symbol, string? orderId = null, DateTime? startTime = null, int? page = null, int? pageSize = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<BybitStopOrderId>> ModifyConditionalOrderAsync(string symbol, string? stopOrderId = null, string? clientOrderId = null, decimal? newPrice = null, decimal? newTriggerPrice = null, decimal? newQuantity = null, decimal? takeProfitPrice = null, decimal? stopLossPrice = null, TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<BybitOrderId>> ModifyOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, decimal? newPrice = null, decimal? newQuantity = null, decimal? takeProfitPrice = null, decimal? stopLossPrice = null, TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<BybitConditionalOrder>> PlaceConditionalOrderAsync(string symbol, OrderSide side, OrderType type, PositionMode positionMode, decimal quantity, decimal basePrice, decimal triggerPrice, TimeInForce timeInForce, decimal? price = null, TriggerType? triggerType = null, bool? closeOnTrigger = null, string? clientOrderId = null, decimal? takeProfitPrice = null, decimal? stopLossPrice = null, TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<BybitOrder>> PlaceOrderAsync(string symbol, OrderSide side, OrderType type, PositionMode positionMode, decimal quantity, TimeInForce timeInForce, decimal? price = null, bool? closeOnTrigger = null, string? clientOrderId = null, decimal? takeProfitPrice = null, decimal? stopLossPrice = null, TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null, bool? reduceOnly = null, long? receiveWindow = null, CancellationToken ct = default);
    }
}