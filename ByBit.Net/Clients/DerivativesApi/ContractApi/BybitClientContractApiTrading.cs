using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.DerivativesApi.ContractApi;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Models.Contract;
using Bybit.Net.Objects.Models.Derivatives;
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

namespace Bybit.Net.Clients.DerivativesApi.ContractApi
{
    /// <inheritdoc />
    internal class BybitClientContractApiTrading : IBybitClientContractApiTrading
    {
        private readonly BybitClientDerivativesApi _baseClient;

        internal BybitClientContractApiTrading(BybitClientDerivativesApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region PlaceOrderAsync

        /// <inheritdoc />
        public async Task<WebCallResult<BybitDerivativesOrderId>> PlaceOrderAsync(string symbol, OrderSide side, OrderType type, decimal quantity, TimeInForce timeInForce, bool? reduceOnly = null, bool? closeOnTrigger = null, decimal? price = null, string? clientOrderId = null, decimal? takeProfitPrice = null, decimal? stopLossPrice = null, TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null, PositionMode? positionMode = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "side", JsonConvert.SerializeObject(side, new OrderSideConverter(false)) },
                { "orderType", JsonConvert.SerializeObject(type, new OrderTypeConverter(false)) },
                { "qty", quantity.ToString(CultureInfo.InvariantCulture) },
                { "timeInForce", JsonConvert.SerializeObject(timeInForce, new TimeInForceConverter(false)) }
            };

            parameters.AddOptionalParameter("price", price?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("positionIdx", positionMode == null ? null : JsonConvert.SerializeObject(positionMode, new PositionModeConverter(false)));

            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("takeProfit", takeProfitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("stopLoss", stopLossPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tpTriggerBy", takeProfitTriggerType == null ? null : JsonConvert.SerializeObject(takeProfitTriggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("slTriggerBy", stopLossTriggerType == null ? null : JsonConvert.SerializeObject(stopLossTriggerType, new TriggerTypeConverter(false)));

            parameters.AddOptionalParameter("reduceonly", reduceOnly?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("closeontrigger", closeOnTrigger?.ToString(CultureInfo.InvariantCulture));

            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitDerivativesOrderId>(_baseClient.GetUrl("contract/v3/private/order/create"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region ReplaceOrderAsync

        /// <inheritdoc />
        public async Task<WebCallResult<BybitDerivativesOrderId>> ReplaceOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, decimal? quantity = null, decimal? price = null, decimal? triggerPrice = null, decimal? takeProfitPrice = null, decimal? stopLossPrice = null, TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null, TriggerType? triggerType = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            if (orderId == null && clientOrderId == null || orderId != null && clientOrderId != null)
                throw new ArgumentException($"1 of {nameof(orderId)} or {nameof(clientOrderId)} should be provided");

            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };

            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("triggerPrice", triggerPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("qty", quantity?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("price", price?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("takeProfit", takeProfitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("stopLoss", stopLossPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tpTriggerBy", takeProfitTriggerType == null ? null : JsonConvert.SerializeObject(takeProfitTriggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("slTriggerBy", stopLossTriggerType == null ? null : JsonConvert.SerializeObject(stopLossTriggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("triggerBy", triggerType == null ? null : JsonConvert.SerializeObject(triggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitDerivativesOrderId>(_baseClient.GetUrl("contract/v3/private/order/replace"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region CancelOrderAsync

        /// <inheritdoc />
        public async Task<WebCallResult<BybitDerivativesOrderId>> CancelOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            if (orderId == null && clientOrderId == null || orderId != null && clientOrderId != null)
                throw new ArgumentException($"1 of {nameof(orderId)} or {nameof(clientOrderId)} should be provided");

            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };

            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitDerivativesOrderId>(_baseClient.GetUrl("contract/v3/private/order/cancel"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region CancelAllOrdersAsync

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitDerivativesOrderId>>> CancelAllOrdersAsync(string? symbol = null, string? settleAsset = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();

       //     parameters.AddOptionalParameter("category", EnumConverter.GetString(Category.Linear));
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("settleCoin", settleAsset);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitList<BybitDerivativesOrderId>>(_baseClient.GetUrl("contract/v3/private/order/cancel-all"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            if (!result || result.Data == null)
                return result.As<IEnumerable<BybitDerivativesOrderId>>(default);

            if (result.Data.List == null)
                return result.As<IEnumerable<BybitDerivativesOrderId>>(Array.Empty<BybitDerivativesOrderId>());

            return result.As(result.Data.List);
        }

        #endregion

        #region GetOrdersAsync

        /// <inheritdoc />
        public async Task<WebCallResult<BybitCursorPage<IEnumerable<BybitContractOrder>>>> GetOrdersAsync(string symbol, string? orderId = null, string? clientOrderId = null, OrderStatus? status = null, OrderFilter? orderFilter = null, int? limit = null, string? cursor = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();

            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("orderStatus", status == null ? null : JsonConvert.SerializeObject(status, new OrderStatusConverter(false)));
            parameters.AddOptionalParameter("orderFilter", orderFilter == null ? null : EnumConverter.GetString(orderFilter));

            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("cursor", cursor);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitCursorPage<IEnumerable<BybitContractOrder>>>(_baseClient.GetUrl("contract/v3/private/order/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region GetOpenOrdersRealTimeAsync

        /// <inheritdoc />
        public async Task<WebCallResult<BybitCursorPage<IEnumerable<BybitContractOrder>>>> GetOpenOrdersRealTimeAsync(string? symbol = null, string? orderId = null, string? clientOrderId = null, string? settleAsset = null, OrderFilter? orderFilter = null, int? limit = null, string? cursor = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();

            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("orderFilter", orderFilter == null ? null : EnumConverter.GetString(orderFilter));

            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("cursor", cursor);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitCursorPage<IEnumerable<BybitContractOrder>>>(_baseClient.GetUrl("contract/v3/private/order/unfilled-orders"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region SetTradingStop

        /// <inheritdoc />
        public async Task<WebCallResult> SetTradingStop(string symbol, decimal? takeProfitPrice = null, decimal? stopLossPrice = null, decimal? activePrice = null, decimal? trailingStop = null, TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null, decimal? stopLossSize = null, decimal? takeProfitSize = null, PositionMode? positionMode = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };

            parameters.AddOptionalParameter("takeProfit", takeProfitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("stopLoss", stopLossPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("activePrice", activePrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("trailingStop", trailingStop?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tpTriggerBy", positionMode == null ? null : JsonConvert.SerializeObject(takeProfitTriggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("slTriggerBy", positionMode == null ? null : JsonConvert.SerializeObject(stopLossTriggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("slSize", stopLossSize?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tpSize", takeProfitSize?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("positionIdx", positionMode == null ? null : JsonConvert.SerializeObject(positionMode, new PositionModeConverter(false)));
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("contract/v3/private/position/trading-stop"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return result.AsDataless();
        }

        #endregion
    }
}
