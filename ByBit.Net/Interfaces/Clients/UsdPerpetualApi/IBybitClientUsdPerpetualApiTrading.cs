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
    public interface IBybitClientUsdPerpetualApiTrading
    {
        Task<WebCallResult<IEnumerable<string>>> CancelAllConditionalOrdersAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<IEnumerable<string>>> CancelAllOrdersAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<BybitStopOrderId>> CancelConditionalOrderAsync(string symbol, string? stopOrderId = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<BybitOrderId>> CancelOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<BybitCursorPage<IEnumerable<BybitConditionalOrderUsd>>>> GetConditionalOrdersAsync(string symbol, string? orderId = null, string? clientOrderId = null, OrderStatus? status = null, SortOrder? order = null, int? pageSize = null, int? page = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<BybitConditionalOrderUsd>> GetOpenConditionalOrderRealTimeAsync(string symbol, string? stopOrderId = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<IEnumerable<BybitConditionalOrder>>> GetOpenConditionalOrdersRealTimeAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<BybitOrder>> GetOpenOrderRealTimeAsync(string symbol, string? orderId = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<IEnumerable<BybitOrder>>> GetOpenOrdersRealTimeAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<BybitCursorPage<IEnumerable<BybitOrder>>>> GetOrdersAsync(string symbol, string? orderId = null, string? clientOrderId = null, OrderStatus? status = null, SortOrder? order = null, int? pageSize = null, int? page = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<IEnumerable<BybitUserTrade>>> GetUserTradesAsync(string symbol, DateTime? startTime = null, DateTime? endTime = null, int? page = null, int? pageSize = null, TradeType? type = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<BybitStopOrderId>> ModifyConditionalOrderAsync(string symbol, string? stopOrderId = null, string? clientOrderId = null, decimal? newPrice = null, decimal? newTriggerPrice = null, decimal? newQuantity = null, decimal? takeProfitPrice = null, decimal? stopLossPrice = null, TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<BybitOrderId>> ModifyOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, decimal? newPrice = null, decimal? newQuantity = null, decimal? takeProfitPrice = null, decimal? stopLossPrice = null, TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<BybitConditionalOrderUsd>> PlaceConditionalOrderAsync(string symbol, OrderSide side, OrderType type, decimal quantity, decimal basePrice, decimal triggerPrice, TimeInForce timeInForce, bool closeOnTrigger, bool reduceOnly, decimal? price = null, TriggerType? triggerType = null, string? clientOrderId = null, decimal? takeProfitPrice = null, decimal? stopLossPrice = null, TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<BybitOrder>> PlaceOrderAsync(string symbol, OrderSide side, OrderType type, decimal quantity, TimeInForce timeInForce, bool reduceOnly, bool closeOnTrigger, decimal? price = null, string? clientOrderId = null, decimal? takeProfitPrice = null, decimal? stopLossPrice = null, TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null, long? receiveWindow = null, CancellationToken ct = default);
    }
}