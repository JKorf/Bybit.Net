using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.InversePerpetualApi;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Models;
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

namespace Bybit.Net.Clients.InversePerpetualApi
{
    /// <inheritdoc />
    public class BybitClientInversePerpetualApiTrading : IBybitClientInversePerpetualApiTrading
    {
        private BybitClientInversePerpetualApi _baseClient;

        internal BybitClientInversePerpetualApiTrading(BybitClientInversePerpetualApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Place order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitInverseOrder>> PlaceOrderAsync(
            string symbol,
            OrderSide side,
            OrderType type,
            decimal quantity,
            TimeInForce timeInForce,
            decimal? price = null,
            bool? closeOnTrigger = null,
            string? clientOrderId = null,
            decimal? takeProfitPrice = null,
            decimal? stopLossPrice = null,
            TriggerType? takeProfitTriggerType = null,
            TriggerType? stopLossTriggerType = null,
            bool? reduceOnly = null,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "side", JsonConvert.SerializeObject(side, new OrderSideConverter(false)) },
                { "symbol", symbol },
                { "order_type", JsonConvert.SerializeObject(type, new OrderTypeConverter(false)) },
                { "qty", quantity.ToString(CultureInfo.InvariantCulture) },
                { "time_in_force", JsonConvert.SerializeObject(timeInForce, new TimeInForceConverter(false)) },
            };

            parameters.AddOptionalParameter("price", price?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("close_on_trigger", closeOnTrigger?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("order_link_id", clientOrderId);
            parameters.AddOptionalParameter("take_profit", takeProfitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("stop_loss", stopLossPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tp_trigger_by", takeProfitTriggerType == null ? null : JsonConvert.SerializeObject(takeProfitTriggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("sl_trigger_by", stopLossTriggerType == null ? null : JsonConvert.SerializeObject(stopLossTriggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("reduce_only", reduceOnly?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitInverseOrder>(_baseClient.GetUrl("v2/private/order/create"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get orders

        /// <inheritdoc />
        public async Task<WebCallResult<BybitCursorPage<IEnumerable<BybitInverseOrder>>>> GetOrdersAsync(
            string symbol,
            OrderStatus? status = null,
            SearchDirection? direction = null,
            int? limit = null,
            string? cursor = null,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };

            parameters.AddOptionalParameter("order_status", status == null ? null : JsonConvert.SerializeObject(status, new OrderStatusConverter(false)));
            parameters.AddOptionalParameter("direction", direction == null ? null : JsonConvert.SerializeObject(direction, new SearchDirectionConverter(false)));
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("cursor", cursor);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitCursorPage<IEnumerable<BybitInverseOrder>>>(_baseClient.GetUrl("v2/private/order/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);

        }

        #endregion

        #region Cancel order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitInverseOrder>> CancelOrderAsync(
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            if (orderId == null && clientOrderId == null || orderId != null && clientOrderId != null)
                throw new ArgumentException($"1 of {nameof(orderId)} or {nameof(clientOrderId)} should be provided");

            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };

            parameters.AddOptionalParameter("order_id", orderId);
            parameters.AddOptionalParameter("order_link_id", clientOrderId);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitInverseOrder>(_baseClient.GetUrl("v2/private/order/cancel"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);

        }

        #endregion

        #region Cancel all order

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitCanceledOrder>>> CancelAllOrdersAsync(
            string symbol,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };

            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<IEnumerable<BybitCanceledOrder>>(_baseClient.GetUrl("v2/private/order/cancelAll"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            if (result && result.Data == null)
                return result.As<IEnumerable<BybitCanceledOrder>>(new BybitCanceledOrder[0]);

            return result;
        }

        #endregion

        #region Modify order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitOrderId>> ModifyOrderAsync(
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            decimal? newPrice = null,
            decimal? newQuantity = null,
            decimal? takeProfitPrice = null,
            decimal? stopLossPrice = null,
            TriggerType? takeProfitTriggerType = null,
            TriggerType? stopLossTriggerType = null,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            if (orderId == null && clientOrderId == null || orderId != null && clientOrderId != null)
                throw new ArgumentException($"1 of {nameof(orderId)} or {nameof(clientOrderId)} should be provided");

            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };

            parameters.AddOptionalParameter("p_r_price", newPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("p_r_qty", newQuantity?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("order_id", orderId);
            parameters.AddOptionalParameter("order_link_id", clientOrderId);
            parameters.AddOptionalParameter("take_profit", takeProfitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("stop_loss", stopLossPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tp_trigger_by", takeProfitTriggerType == null ? null : JsonConvert.SerializeObject(takeProfitTriggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("sl_trigger_by", stopLossTriggerType == null ? null : JsonConvert.SerializeObject(stopLossTriggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitOrderId>(_baseClient.GetUrl("v2/private/order/replace"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);

        }

        #endregion

        #region Get open orders realtime

        /// <inheritdoc />
        public async Task<WebCallResult<BybitInverseOrder>> GetOpenOrderRealTimeAsync(
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            if (orderId == null && clientOrderId == null || orderId != null && clientOrderId != null)
                throw new ArgumentException($"1 of {nameof(orderId)} or {nameof(clientOrderId)} should be provided");

            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };
            parameters.AddOptionalParameter("order_id", orderId);
            parameters.AddOptionalParameter("order_link_id", clientOrderId);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitInverseOrder>(_baseClient.GetUrl("v2/private/order"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);

        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitInverseOrder>>> GetOpenOrdersRealTimeAsync(
            string symbol,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };

            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitInverseOrder>>(_baseClient.GetUrl("v2/private/order"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);

        }

        #endregion

        #region Place conditional order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitConditionalOrder>> PlaceConditionalOrderAsync(
            string symbol,
            OrderSide side,
            OrderType type,
            PositionMode positionMode,
            decimal quantity,
            decimal basePrice,
            decimal triggerPrice,
            TimeInForce timeInForce,
            decimal? price = null,
            TriggerType? triggerType = null,
            bool? closeOnTrigger = null,
            string? clientOrderId = null,
            decimal? takeProfitPrice = null,
            decimal? stopLossPrice = null,
            TriggerType? takeProfitTriggerType = null,
            TriggerType? stopLossTriggerType = null,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "side", JsonConvert.SerializeObject(side, new OrderSideConverter(false)) },
                { "position_idx", JsonConvert.SerializeObject(positionMode, new PositionModeConverter(false)) },
                { "symbol", symbol },
                { "order_type", JsonConvert.SerializeObject(type, new OrderTypeConverter(false)) },
                { "qty", quantity.ToString(CultureInfo.InvariantCulture) },
                { "base_price", basePrice.ToString(CultureInfo.InvariantCulture) },
                { "stop_px", triggerPrice.ToString(CultureInfo.InvariantCulture) },
                { "time_in_force", JsonConvert.SerializeObject(timeInForce, new TimeInForceConverter(false)) },
            };

            parameters.AddOptionalParameter("trigger_by", triggerType == null ? null : JsonConvert.SerializeObject(triggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("price", price?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("close_on_trigger", closeOnTrigger?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("order_link_id", clientOrderId);
            parameters.AddOptionalParameter("take_profit", takeProfitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("stop_loss", stopLossPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tp_trigger_by", takeProfitTriggerType == null ? null : JsonConvert.SerializeObject(takeProfitTriggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("sl_trigger_by", stopLossTriggerType == null ? null : JsonConvert.SerializeObject(stopLossTriggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitConditionalOrder>(_baseClient.GetUrl("v2/private/stop-order/create"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get conditional orders

        /// <inheritdoc />
        public async Task<WebCallResult<BybitCursorPage<IEnumerable<BybitConditionalOrder>>>> GetConditionalOrdersAsync(
            string symbol,
            StopOrderStatus? status = null,
            SearchDirection? direction = null,
            int? limit = null,
            string? cursor = null,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };

            parameters.AddOptionalParameter("order_status", status == null ? null : JsonConvert.SerializeObject(status, new StopOrderStatusConverter(false)));
            parameters.AddOptionalParameter("direction", direction == null ? null : JsonConvert.SerializeObject(direction, new SearchDirectionConverter(false)));
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("cursor", cursor);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitCursorPage<IEnumerable<BybitConditionalOrder>>>(_baseClient.GetUrl("v2/private/stop-order/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);

        }

        #endregion

        #region Cancel conditional order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitStopOrderId>> CancelConditionalOrderAsync(
            string symbol,
            string? stopOrderId = null,
            string? clientOrderId = null,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            if (stopOrderId == null && clientOrderId == null || stopOrderId != null && clientOrderId != null)
                throw new ArgumentException($"1 of {nameof(stopOrderId)} or {nameof(clientOrderId)} should be provided");

            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };

            parameters.AddOptionalParameter("stop_order_id", stopOrderId);
            parameters.AddOptionalParameter("order_link_id", clientOrderId);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitStopOrderId>(_baseClient.GetUrl("v2/private/stop-order/cancel"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);

        }

        #endregion

        #region Cancel all conditional orders

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitCanceledConditionalOrder>>> CancelAllConditionalOrdersAsync(
            string symbol,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };

            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<IEnumerable<BybitCanceledConditionalOrder>>(_baseClient.GetUrl("v2/private/stop-order/cancelAll"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);

            if (result && result.Data == null)
                return result.As<IEnumerable<BybitCanceledConditionalOrder>>(new BybitCanceledConditionalOrder[0]);

            return result;
        }

        #endregion

        #region Modify order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitStopOrderId>> ModifyConditionalOrderAsync(
            string symbol,
            string? stopOrderId = null,
            string? clientOrderId = null,
            decimal? newPrice = null,
            decimal? newTriggerPrice = null,
            decimal? newQuantity = null,
            decimal? takeProfitPrice = null,
            decimal? stopLossPrice = null,
            TriggerType? takeProfitTriggerType = null,
            TriggerType? stopLossTriggerType = null,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            if (stopOrderId == null && clientOrderId == null || stopOrderId != null && clientOrderId != null)
                throw new ArgumentException($"1 of {nameof(stopOrderId)} or {nameof(clientOrderId)} should be provided");

            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };

            parameters.AddOptionalParameter("p_r_price", newPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("p_r_qty", newQuantity?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("p_r_trigger_price", newTriggerPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("stop_order_id", stopOrderId);
            parameters.AddOptionalParameter("order_link_id", clientOrderId);
            parameters.AddOptionalParameter("take_profit", takeProfitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("stop_loss", stopLossPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tp_trigger_by", takeProfitTriggerType == null ? null : JsonConvert.SerializeObject(takeProfitTriggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("sl_trigger_by", stopLossTriggerType == null ? null : JsonConvert.SerializeObject(stopLossTriggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitStopOrderId>(_baseClient.GetUrl("v2/private/stop-order/replace"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);

        }

        #endregion

        #region Get open orders realtime

        /// <inheritdoc />
        public async Task<WebCallResult<BybitConditionalOrder>> GetOpenConditionalOrderRealTimeAsync(
            string symbol,
            string? stopOrderId = null,
            string? clientOrderId = null,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            if (stopOrderId == null && clientOrderId == null || stopOrderId != null && clientOrderId != null)
                throw new ArgumentException($"1 of {nameof(stopOrderId)} or {nameof(clientOrderId)} should be provided");

            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };
            parameters.AddOptionalParameter("stop_order_id", stopOrderId);
            parameters.AddOptionalParameter("order_link_id", clientOrderId);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitConditionalOrder>(_baseClient.GetUrl("v2/private/stop-order"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);

        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitConditionalOrder>>> GetOpenConditionalOrdersRealTimeAsync(
            string symbol,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };

            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitConditionalOrder>>(_baseClient.GetUrl("v2/private/stop-order"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);

        }

        #endregion

        #region User trades

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitUserTrade>>> GetUserTradesAsync(
            string symbol,
            string? orderId = null,
            DateTime? startTime = null,
            int? page = null,
            int? pageSize = null,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };
            parameters.AddOptionalParameter("order_id", orderId);
            parameters.AddOptionalParameter("start_time", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("page", page?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("limit", pageSize?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitTradeWrapper>(_baseClient.GetUrl("v2/private/execution/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<BybitUserTrade>>(default);

            if (result.Data.Trades == null)
                return result.As<IEnumerable<BybitUserTrade>>(new BybitUserTrade[0]);

            return result.As(result.Data.Trades);
        }

        #endregion

        #region Set Trading Stop
        /// <inheritdoc />
        public async Task<WebCallResult<BybitPosition>> SetTradingStopAsync(
            string symbol,
            decimal? takeProfitPrice = null,
            decimal? stopLossPrice = null,
            decimal? trailingStopPrice = null,
            TriggerType? takeProfitTriggerType = null,
            TriggerType? stopLossTriggerType = null,
            decimal? trailingStopTriggerPrice = null,
            decimal? takeProfitQuantity = null,
            decimal? stopLossQuantity = null,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };
            parameters.AddOptionalParameter("take_profit", takeProfitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("stop_loss", stopLossPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("trailing_stop", trailingStopPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tp_trigger_by", takeProfitTriggerType == null ? null : JsonConvert.SerializeObject(takeProfitTriggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("sl_trigger_by", stopLossTriggerType == null ? null : JsonConvert.SerializeObject(stopLossTriggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("new_trailing_active", trailingStopTriggerPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("sl_size", stopLossQuantity?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tp_size", takeProfitQuantity?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitPosition>(_baseClient.GetUrl("v2/private/position/trading-stop"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);            
        }
        #endregion
    }
}
