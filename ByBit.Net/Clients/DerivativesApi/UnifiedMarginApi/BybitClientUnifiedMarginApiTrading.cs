using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.DerivativesApi.UnifiedMarginApi;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Models.Derivatives;
using Bybit.Net.Objects.Models.Derivatives.UnifiedMargin;
using CryptoExchange.Net;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.DerivativesApi.UnifiedMarginApi
{
    /// <inheritdoc />
    public class BybitClientUnifiedMarginApiTrading : IBybitClientUnifiedMarginApiTrading
    {
        private readonly BybitClientDerivativesApi _baseClient;

        internal BybitClientUnifiedMarginApiTrading(BybitClientDerivativesApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Place order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitDerivativesOrderId>> PlaceOrderAsync(Category category, string symbol, OrderSide side, OrderType type, decimal quantity, TimeInForce timeInForce, decimal? price = null, decimal? basePrice = null, decimal? triggerPrice = null, PositionMode? positionMode = null, TriggerType? triggerType = null, decimal? iv = null, string? clientOrderId = null, decimal? takeProfitPrice = null, decimal? stopLossPrice = null, TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null, bool? reduceOnly = null, bool? closeOnTrigger = null, bool? marketMakerProtection = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "side", JsonConvert.SerializeObject(side, new OrderSideConverter(false)) },
                { "orderType", JsonConvert.SerializeObject(type, new OrderTypeConverter(false)) },
                { "qty", quantity.ToString(CultureInfo.InvariantCulture) },
                { "timeInForce", JsonConvert.SerializeObject(timeInForce, new TimeInForceConverter(false)) }
            };

            parameters.AddOptionalParameter("price", price?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("basePrice", basePrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("triggerPrice", triggerPrice?.ToString(CultureInfo.InvariantCulture));

            parameters.AddOptionalParameter("positionIdx", positionMode == null ? null : JsonConvert.SerializeObject(positionMode, new PositionModeConverter(false)));
            parameters.AddOptionalParameter("triggerBy", triggerType == null ? null : JsonConvert.SerializeObject(triggerType, new TriggerTypeConverter(false)));

            parameters.AddOptionalParameter("iv", iv?.ToString(CultureInfo.InvariantCulture));

            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("takeProfit", takeProfitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("stopLoss", stopLossPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tpTriggerBy", takeProfitTriggerType == null ? null : JsonConvert.SerializeObject(takeProfitTriggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("slTriggerBy", stopLossTriggerType == null ? null : JsonConvert.SerializeObject(stopLossTriggerType, new TriggerTypeConverter(false)));

            parameters.AddOptionalParameter("reduceOnly", reduceOnly?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("closeOnTrigger", closeOnTrigger?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("mmp", marketMakerProtection?.ToString(CultureInfo.InvariantCulture));

            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitDerivativesOrderId>(_baseClient.GetUrl("unified/v3/private/order/create"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region ReplaceOrderAsync

        /// <inheritdoc />
        public async Task<WebCallResult<BybitDerivativesOrderId>> ReplaceOrderAsync(Category category, string symbol, string? orderId = null, string? clientOrderId = null, OrderFilter? orderFilter = null, decimal? iv = null, decimal? triggerPrice = null, decimal? quantity = null, decimal? price = null, decimal? takeProfitPrice = null, decimal? stopLossPrice = null, TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null, TriggerType? triggerType = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            if (orderId == null && clientOrderId == null || orderId != null && clientOrderId != null)
                throw new ArgumentException($"1 of {nameof(orderId)} or {nameof(clientOrderId)} should be provided");

            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
            };

            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("orderFilter", orderFilter == null ? null : EnumConverter.GetString(orderFilter));
            parameters.AddOptionalParameter("iv", iv?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("triggerPrice", triggerPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("qty", quantity?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("price", price?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("takeProfit", takeProfitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("stopLoss", stopLossPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tpTriggerBy", takeProfitTriggerType == null ? null : JsonConvert.SerializeObject(takeProfitTriggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("slTriggerBy", stopLossTriggerType == null ? null : JsonConvert.SerializeObject(stopLossTriggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("triggerBy", triggerType == null ? null : JsonConvert.SerializeObject(triggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitDerivativesOrderId>(_baseClient.GetUrl("unified/v3/private/order/replace"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Cancel order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitDerivativesOrderId>> CancelOrderAsync(Category category, string symbol, string? orderId = null, string? clientOrderId = null, OrderFilter? orderFilter = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            if (orderId == null && clientOrderId == null || orderId != null && clientOrderId != null)
                throw new ArgumentException($"1 of {nameof(orderId)} or {nameof(clientOrderId)} should be provided");

            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
            };

            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("orderFilter", orderFilter == null ? null : EnumConverter.GetString(orderFilter));
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitDerivativesOrderId>(_baseClient.GetUrl("unified/v3/private/order/cancel"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Cancel all orders

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitUnifiedMarginCancelledOrder>>> CancelAllOrdersAsync(Category category, string? baseAsset = null, string? settleAsset = null, string? symbol = null, OrderFilter? orderFilter = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
               { "category", EnumConverter.GetString(category) }
            };

            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("settleCoin", settleAsset);
            parameters.AddOptionalParameter("orderFilter", orderFilter == null ? null : EnumConverter.GetString(orderFilter));
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitList<BybitUnifiedMarginCancelledOrder>>(_baseClient.GetUrl("unified/v3/private/order/cancel-all"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            if (!result || result.Data == null)
                return result.As<IEnumerable<BybitUnifiedMarginCancelledOrder>>(default);

            if (result.Data.List == null)
                return result.As<IEnumerable<BybitUnifiedMarginCancelledOrder>>(Array.Empty<BybitUnifiedMarginCancelledOrder>());

            return result.As(result.Data.List);
        }

        #endregion

        #region Get orders

        /// <inheritdoc />
        public async Task<WebCallResult<BybitDerivativesCursorPage<IEnumerable<BybitUnifiedMarginOrder>>>> GetOrdersAsync(Category category, string? symbol = null, string? baseAsset = null, string? orderId = null, string? clientOrderId = null, OrderStatus? status = null, OrderFilter? orderFilter = null, SearchDirection? direction = null, int? limit = null, string? cursor = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) }
            };

            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("orderStatus", status == null ? null : JsonConvert.SerializeObject(status, new OrderStatusConverter(false)));
            parameters.AddOptionalParameter("orderFilter", orderFilter == null ? null : EnumConverter.GetString(orderFilter));

            parameters.AddOptionalParameter("direction", direction == null ? null : JsonConvert.SerializeObject(direction, new SearchDirectionConverter(false)));
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("cursor", cursor);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitDerivativesCursorPage<IEnumerable<BybitUnifiedMarginOrder>>>(_baseClient.GetUrl("unified/v3/private/order/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get open orders

        /// <inheritdoc />
        public async Task<WebCallResult<BybitDerivativesCursorPage<IEnumerable<BybitUnifiedMarginOrder>>>> GetOpenOrdersRealTimeAsync(Category category, string? symbol = null, string? baseAsset = null, string? orderId = null, string? clientOrderId = null, OrderFilter? orderFilter = null, SearchDirection? direction = null, int? limit = null, string? cursor = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) }
            };

            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("orderFilter", orderFilter == null ? null : EnumConverter.GetString(orderFilter));

            parameters.AddOptionalParameter("direction", direction == null ? null : JsonConvert.SerializeObject(direction, new SearchDirectionConverter(false)));
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("cursor", cursor);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitDerivativesCursorPage<IEnumerable<BybitUnifiedMarginOrder>>>(_baseClient.GetUrl("unified/v3/private/order/unfilled-orders"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion
    }
}
