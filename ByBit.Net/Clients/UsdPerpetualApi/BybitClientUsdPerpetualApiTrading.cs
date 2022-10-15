using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.UsdPerpetualApi;
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

namespace Bybit.Net.Clients.UsdPerpetualApi
{
    /// <inheritdoc />
    public class BybitClientUsdPerpetualApiTrading : IBybitClientUsdPerpetualApiTrading
    {
        private BybitClientUsdPerpetualApi _baseClient;

        internal BybitClientUsdPerpetualApiTrading(BybitClientUsdPerpetualApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Place order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitUsdPerpetualOrder>> PlaceOrderAsync(
            string symbol,
            OrderSide side,
            OrderType type,
            decimal quantity,
            TimeInForce timeInForce,
            bool reduceOnly,
            bool closeOnTrigger,
            decimal? price = null,
            string? clientOrderId = null,
            decimal? takeProfitPrice = null,
            decimal? stopLossPrice = null,
            TriggerType? takeProfitTriggerType = null,
            TriggerType? stopLossTriggerType = null,
            PositionMode? positionMode = null,
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
                { "reduce_only", reduceOnly.ToString() },
                { "close_on_trigger", closeOnTrigger.ToString() }
            };

            parameters.AddOptionalParameter("price", price?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("order_link_id", clientOrderId);
            parameters.AddOptionalParameter("take_profit", takeProfitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("stop_loss", stopLossPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tp_trigger_by", takeProfitTriggerType == null ? null : JsonConvert.SerializeObject(takeProfitTriggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("sl_trigger_by", stopLossTriggerType == null ? null : JsonConvert.SerializeObject(stopLossTriggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("position_idx", positionMode == null ? null : JsonConvert.SerializeObject(positionMode, new PositionModeConverter(false)));
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitUsdPerpetualOrder>(_baseClient.GetUrl("private/linear/order/create"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get orders

        /// <inheritdoc />
        public async Task<WebCallResult<BybitCursorPage<IEnumerable<BybitUsdPerpetualOrder>>>> GetOrdersAsync(
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            OrderStatus? status = null,
            SortOrder? order = null,
            int? pageSize = null,
            int? page = null,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };

            parameters.AddOptionalParameter("order_id", orderId);
            parameters.AddOptionalParameter("order_link_id", clientOrderId);
            parameters.AddOptionalParameter("order_status", status == null ? null : JsonConvert.SerializeObject(status, new OrderStatusConverter(false)));
            parameters.AddOptionalParameter("order", order == null ? null : JsonConvert.SerializeObject(order, new SortOrderConverter(false)));
            parameters.AddOptionalParameter("limit", pageSize?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("page", page?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitCursorPage<IEnumerable<BybitUsdPerpetualOrder>>>(_baseClient.GetUrl("private/linear/order/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);

        }

        #endregion

        #region Cancel order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitOrderId>> CancelOrderAsync(
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

            return await _baseClient.SendRequestAsync<BybitOrderId>(_baseClient.GetUrl("private/linear/order/cancel"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);

        }

        #endregion

        #region Cancel all order

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<string>>> CancelAllOrdersAsync(
            string symbol,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };

            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<IEnumerable<string>>(_baseClient.GetUrl("private/linear/order/cancel-all"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            if (result && result.Data == null)
                return result.As<IEnumerable<string>>(new string[0]);

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

            return await _baseClient.SendRequestAsync<BybitOrderId>(_baseClient.GetUrl("private/linear/order/replace"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);

        }

        #endregion

        #region Get open orders realtime

        /// <inheritdoc />
        public async Task<WebCallResult<BybitUsdPerpetualOrder>> GetOpenOrderRealTimeAsync(
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

            return await _baseClient.SendRequestAsync<BybitUsdPerpetualOrder>(_baseClient.GetUrl("private/linear/order/search"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);

        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitUsdPerpetualOrder>>> GetOpenOrdersRealTimeAsync(
            string symbol,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };

            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitUsdPerpetualOrder>>(_baseClient.GetUrl("private/linear/order/search"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);

        }

        #endregion

        #region Place conditional order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitConditionalOrderUsd>> PlaceConditionalOrderAsync(
            string symbol,
            OrderSide side,
            OrderType type,
            decimal quantity,
            decimal basePrice,
            decimal triggerPrice,
            TimeInForce timeInForce,
            bool closeOnTrigger,
            bool reduceOnly,
            decimal? price = null,
            TriggerType? triggerType = null,
            string? clientOrderId = null,
            decimal? takeProfitPrice = null,
            decimal? stopLossPrice = null,
            TriggerType? takeProfitTriggerType = null,
            TriggerType? stopLossTriggerType = null,
            PositionMode? positionMode = null,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "side", JsonConvert.SerializeObject(side, new OrderSideConverter(false)) },
                { "symbol", symbol },
                { "order_type", JsonConvert.SerializeObject(type, new OrderTypeConverter(false)) },
                { "qty", quantity.ToString(CultureInfo.InvariantCulture) },
                { "base_price", basePrice.ToString(CultureInfo.InvariantCulture) },
                { "stop_px", triggerPrice.ToString(CultureInfo.InvariantCulture) },
                { "time_in_force", JsonConvert.SerializeObject(timeInForce, new TimeInForceConverter(false)) },
                { "close_on_trigger", closeOnTrigger.ToString(CultureInfo.InvariantCulture) },
                { "reduce_only", reduceOnly.ToString(CultureInfo.InvariantCulture) },
            };

            parameters.AddOptionalParameter("trigger_by", triggerType == null ? null : JsonConvert.SerializeObject(triggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("price", price?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("order_link_id", clientOrderId);
            parameters.AddOptionalParameter("take_profit", takeProfitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("stop_loss", stopLossPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tp_trigger_by", takeProfitTriggerType == null ? null : JsonConvert.SerializeObject(takeProfitTriggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("sl_trigger_by", stopLossTriggerType == null ? null : JsonConvert.SerializeObject(stopLossTriggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("position_idx", positionMode == null ? null : JsonConvert.SerializeObject(positionMode, new PositionModeConverter(false)));
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitConditionalOrderUsd>(_baseClient.GetUrl("private/linear/stop-order/create"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get conditional orders

        /// <inheritdoc />
        public async Task<WebCallResult<BybitCursorPage<IEnumerable<BybitConditionalOrderUsd>>>> GetConditionalOrdersAsync(
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            OrderStatus? status = null,
            SortOrder? order = null,
            int? pageSize = null,
            int? page = null,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };

            parameters.AddOptionalParameter("stop_order_id", orderId);
            parameters.AddOptionalParameter("order_link_id", clientOrderId);
            parameters.AddOptionalParameter("stop_order_status", status == null ? null : JsonConvert.SerializeObject(status, new OrderStatusConverter(false)));
            parameters.AddOptionalParameter("order", order == null ? null : JsonConvert.SerializeObject(order, new SortOrderConverter(false)));
            parameters.AddOptionalParameter("limit", pageSize?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("page", page?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitCursorPage<IEnumerable<BybitConditionalOrderUsd>>>(_baseClient.GetUrl("private/linear/stop-order/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);

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

            return await _baseClient.SendRequestAsync<BybitStopOrderId>(_baseClient.GetUrl("private/linear/stop-order/cancel"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);

        }

        #endregion

        #region Cancel all conditional orders

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<string>>> CancelAllConditionalOrdersAsync(
            string symbol,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };

            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<IEnumerable<string>>(_baseClient.GetUrl("private/linear/stop-order/cancel-all"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);

            if (result && result.Data == null)
                return result.As<IEnumerable<string>>(new string[0]);

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

            return await _baseClient.SendRequestAsync<BybitStopOrderId>(_baseClient.GetUrl("private/linear/stop-order/replace"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);

        }

        #endregion

        #region Get open orders realtime

        /// <inheritdoc />
        public async Task<WebCallResult<BybitConditionalOrderUsd>> GetOpenConditionalOrderRealTimeAsync(
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

            return await _baseClient.SendRequestAsync<BybitConditionalOrderUsd>(_baseClient.GetUrl("private/linear/stop-order/search"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);

        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitConditionalOrderUsd>>> GetOpenConditionalOrdersRealTimeAsync(
            string symbol,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };

            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitConditionalOrderUsd>>(_baseClient.GetUrl("private/linear/stop-order/search"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);

        }

        #endregion

        #region User trades

        /// <inheritdoc />
        public async Task<WebCallResult<BybitPage<IEnumerable<BybitUserTrade>>>> GetUserTradesAsync(
            string symbol,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? page = null,
            int? pageSize = null,
            TradeType? type = null,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };
            parameters.AddOptionalParameter("exec_type", type == null ? null : JsonConvert.SerializeObject(type, new TradeTypeConverter(false)));
            parameters.AddOptionalParameter("start_time", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("end_time", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("page", page?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("limit", pageSize?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitPage<IEnumerable<BybitUserTrade>>>(_baseClient.GetUrl("private/linear/trade/execution/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Set Trading Stop
        /// <inheritdoc />
        public async Task<WebCallResult> SetTradingStopAsync(
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
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "side", JsonConvert.SerializeObject(side, new PositionSideConverter(false)) }
            };
            parameters.AddOptionalParameter("take_profit", takeProfitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("stop_loss", stopLossPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("trailing_stop", trailingStopPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tp_trigger_by", takeProfitTriggerType == null ? null : JsonConvert.SerializeObject(takeProfitTriggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("sl_trigger_by", stopLossTriggerType == null ? null : JsonConvert.SerializeObject(stopLossTriggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("sl_size", stopLossQuantity?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tp_size", takeProfitQuantity?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("position_idx", positionMode == null ? null : JsonConvert.SerializeObject(positionMode, new PositionModeConverter(false)));
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("private/linear/position/trading-stop"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return result.AsDataless();
        }
        #endregion
    }
}
