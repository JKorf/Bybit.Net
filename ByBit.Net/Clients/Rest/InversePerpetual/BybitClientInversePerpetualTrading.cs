using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Models;
using ByBit.Net.Objects.Internal;
using ByBit.Net.Objects.Models;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ByBit.Net.Clients.Rest.InversePerpetual
{
    /// <summary>
    /// Spot system endpoints
    /// </summary>
    public class BybitClientInversePerpetualTrading : IBybitClientInversePerpetualTrading
    //: IBybitInversePerpetualClientAccount
    {
        private readonly BybitClientInversePerpetual _baseClient;

        internal BybitClientInversePerpetualTrading(BybitClientInversePerpetual baseClient)
        {
            _baseClient = baseClient;
        }

        #region Place order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitOrder>> PlaceOrderAsync(
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
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitOrder>(_baseClient.GetUrl("private/order/create"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get open orders

        /// <inheritdoc />
        public async Task<WebCallResult<BybitCursorPage<IEnumerable<BybitOrder>>>> GetOpenOrdersAsync(
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
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitCursorPage<IEnumerable<BybitOrder>>>(_baseClient.GetUrl("private/order/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);

        }

        #endregion

        #region Cancel order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitOrder>> CancelOrderAsync(
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            if ((orderId == null && clientOrderId == null) || (orderId != null && clientOrderId != null))
                throw new ArgumentException($"1 of {nameof(orderId)} or {nameof(clientOrderId)} should be provided");

            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };

            parameters.AddOptionalParameter("order_id", orderId);
            parameters.AddOptionalParameter("order_link_id", clientOrderId);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitOrder>(_baseClient.GetUrl("private/order/cancel"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);

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

            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitCanceledOrder>>(_baseClient.GetUrl("private/order/cancelAll"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);

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
            if ((orderId == null && clientOrderId == null) || (orderId != null && clientOrderId != null))
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
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitOrderId>(_baseClient.GetUrl("private/order/replace"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);

        }

        #endregion

        #region Get open orders realtime

        /// <inheritdoc />
        public async Task<WebCallResult<BybitOrder>> GetOpenOrderRealTimeAsync(
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            if ((orderId == null && clientOrderId == null) || (orderId != null && clientOrderId != null))
                throw new ArgumentException($"1 of {nameof(orderId)} or {nameof(clientOrderId)} should be provided");

            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };
            parameters.AddOptionalParameter("order_id", orderId);
            parameters.AddOptionalParameter("order_link_id", clientOrderId);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitOrder>(_baseClient.GetUrl("private/order"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);

        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitOrder>>> GetOpenOrdersRealTimeAsync(
            string symbol,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };

            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitOrder>>(_baseClient.GetUrl("private/order"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);

        }

        #endregion

        #region Place conditional order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitConditionalOrder>> PlaceConditionalOrderAsync(
            string symbol,
            OrderSide side,
            OrderType type,
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
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitConditionalOrder>(_baseClient.GetUrl("private/stop-order/create"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion
    }
}
