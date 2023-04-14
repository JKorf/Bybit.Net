using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using CryptoExchange.Net.Objects;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net;
using Bybit.Net.Objects.Models.V5;
using System.Globalization;
using Bybit.Net.Interfaces.Clients.V5;
using Bybit.Net.Enums.V5;

namespace Bybit.Net.Clients.V5
{
    /// <inheritdoc />
    public class BybitClientApiTrading : IBybitClientApiTrading
    {
        private BybitClientApi _baseClient;

        internal BybitClientApiTrading(BybitClientApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Place order

        /// <inheritdoc />
        public async Task<WebCallResult<Objects.Models.V5.BybitOrderId>> PlaceOrderAsync(
            Category category,
            string symbol,
            OrderSide side,
            NewOrderType type,
            decimal quantity,
            decimal? price = null,
            bool? isLeverage = null,
            TriggerDirection? triggerDirection = null,
            OrderFilter? orderFilter = null,
            decimal? triggerPrice = null,
            TriggerType? triggerBy = null,
            decimal? orderIv = null,
            TimeInForce? timeInForce = null,
            Enums.V5.PositionMode? positionMode = null,
            string? clientOrderId = null,
            decimal? takeProfit = null,
            decimal? stopLoss = null,
            TriggerType? takeProfitTriggerBy = null,
            TriggerType? stopLossTriggerBy = null,
            bool? reduceOnly = null,
            bool? closeOnTrigger = null,
            bool? marketMakerProtection = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "side", EnumConverter.GetString(side) },
                { "orderType", EnumConverter.GetString(type) },
                { "qty", quantity.ToString(CultureInfo.InvariantCulture) }
            };

            if (isLeverage != null)
                parameters.AddOptionalParameter("isLeverage", isLeverage.Value ? 1 : 0);
            parameters.AddOptionalParameter("price", price?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("triggerDirection", EnumConverter.GetString(triggerDirection));
            parameters.AddOptionalParameter("orderFilter", EnumConverter.GetString(orderFilter));
            parameters.AddOptionalParameter("triggerPrice", triggerPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("triggerBy", EnumConverter.GetString(triggerBy));
            parameters.AddOptionalParameter("orderIv", orderIv?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("timeInForce", EnumConverter.GetString(timeInForce));
            parameters.AddOptionalParameter("positionMode", positionMode == null ? null : (int)positionMode);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("takeProfit", takeProfit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("stopLoss", stopLoss?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tpTriggerBy", EnumConverter.GetString(takeProfitTriggerBy));
            parameters.AddOptionalParameter("slTriggerBy", EnumConverter.GetString(stopLossTriggerBy));
            parameters.AddOptionalParameter("reduceOnly", reduceOnly);
            parameters.AddOptionalParameter("closeOnTrigger", closeOnTrigger);
            parameters.AddOptionalParameter("mmp", marketMakerProtection);

            return await _baseClient.SendRequestAsync<Objects.Models.V5.BybitOrderId>(_baseClient.GetUrl("v5/order/create"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Edit order

        /// <inheritdoc />
        public async Task<WebCallResult<Objects.Models.V5.BybitOrderId>> EditOrderAsync(
            Category category,
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            decimal? quantity = null,
            decimal? price = null,
            decimal? triggerPrice = null,
            TriggerType? triggerBy = null,
            decimal? orderIv = null,
            decimal? takeProfit = null,
            decimal? stopLoss = null,
            TriggerType? takeProfitTriggerBy = null,
            TriggerType? stopLossTriggerBy = null,
            CancellationToken ct = default)
        {
            if (orderId == null != (clientOrderId == null))
                throw new ArgumentException("One of orderId or clientOrderId should be provided");

            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol }
            };

            parameters.AddOptionalParameter("qty", quantity?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("price", price?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("triggerPrice", triggerPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("triggerBy", EnumConverter.GetString(triggerBy));
            parameters.AddOptionalParameter("orderIv", orderIv?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("takeProfit", takeProfit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("stopLoss", stopLoss?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tpTriggerBy", EnumConverter.GetString(takeProfitTriggerBy));
            parameters.AddOptionalParameter("slTriggerBy", EnumConverter.GetString(stopLossTriggerBy));

            return await _baseClient.SendRequestAsync<Objects.Models.V5.BybitOrderId>(_baseClient.GetUrl("v5/order/amend"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Cancel order

        /// <inheritdoc />
        public async Task<WebCallResult<Objects.Models.V5.BybitOrderId>> CancelOrderAsync(
            Category category,
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            OrderFilter? orderFilter = null,
            CancellationToken ct = default)
        {
            if (orderId == null == (clientOrderId == null))
                throw new ArgumentException("One of orderId or clientOrderId should be provided");

            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol }
            };

            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("orderFilter", EnumConverter.GetString(orderFilter));

            return await _baseClient.SendRequestAsync<Objects.Models.V5.BybitOrderId>(_baseClient.GetUrl("v5/order/cancel"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get Open Orders

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<Objects.Models.V5.BybitOrder>>> GetOrdersAsync(
            Category category,
            string? symbol = null,
            string? baseAsset = null,
            string? settleAsset = null,
            string? orderId = null,
            string? clientOrderId = null,
            int? openOnly = null,
            OrderFilter? orderFilter = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            if (orderId == null != (clientOrderId == null))
                throw new ArgumentException("One of orderId or clientOrderId should be provided");

            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) }
            };

            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("settleCoin", settleAsset);
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("orderFilter", EnumConverter.GetString(orderFilter));
            parameters.AddOptionalParameter("openOnly", openOnly);
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            return await _baseClient.SendRequestAsync<BybitResponse<Objects.Models.V5.BybitOrder>>(_baseClient.GetUrl("v5/order/realtime"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Cancel All Orders

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitOrderId>>> CancelAllOrderAsync(
            Category category,
            string? symbol = null,
            string? baseAsset = null,
            string? settleAsset = null,
            OrderFilter? orderFilter = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) }
            };

            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("settleCoin", settleAsset);
            parameters.AddOptionalParameter("orderFilter", EnumConverter.GetString(orderFilter));

            return await _baseClient.SendRequestAsync<BybitResponse<BybitOrderId>>(_baseClient.GetUrl("v5/order/cancel-all"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get Order History

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<Objects.Models.V5.BybitOrder>>> GetOrderHistoryAsync(
            Category category,
            string? symbol = null,
            string? baseAsset = null,
            string? orderId = null,
            string? clientOrderId = null,
            Enums.V5.OrderStatus? status = null,
            OrderFilter? orderFilter = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            if (orderId == null != (clientOrderId == null))
                throw new ArgumentException("One of orderId or clientOrderId should be provided");

            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) }
            };

            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("orderFilter", EnumConverter.GetString(orderFilter));
            parameters.AddOptionalParameter("orderStatus", EnumConverter.GetString(status));
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            return await _baseClient.SendRequestAsync<BybitResponse<Objects.Models.V5.BybitOrder>>(_baseClient.GetUrl("v5/order/history"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get Borrow Quota

        /// <inheritdoc />
        public async Task<WebCallResult<BybitBorrowQuota>> GetBorrowQuotaAsync(
            Category category,
            string symbol,
            OrderSide side,
            CancellationToken ct = default)
        {
            if (category != Category.Spot)
                throw new ArgumentException("Category should be spot");

            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "side", EnumConverter.GetString(side) },
            };

            return await _baseClient.SendRequestAsync<BybitBorrowQuota>(_baseClient.GetUrl("v5/order/spot-borrow-check"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Set Disconnect Cancel All

        /// <inheritdoc />
        public async Task<WebCallResult<BybitBorrowQuota>> SetDisconnectCancelAllAsync(
            int windowSeconds,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "timeWindow", windowSeconds },
            };

            return await _baseClient.SendRequestAsync<BybitBorrowQuota>(_baseClient.GetUrl("v5/order/disconnected-cancel-all"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get User Trades

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitUserTrade>>> GetUserTradesAsync(
            Category category,
            string? symbol = null,
            string? baseAsset = null,
            string? orderId = null,
            string? clientOrderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            TradeType? tradeType = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) }
            };

            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("execType", EnumConverter.GetString(tradeType));
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            return await _baseClient.SendRequestAsync<BybitResponse<BybitUserTrade>>(_baseClient.GetUrl("v5/execution/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get Positions

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitPosition>>> GetPositionsAsync(
            Category category,
            string? symbol = null,
            string? baseAsset = null,
            string? settleAsset = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
            };

            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("settleCoin", settleAsset);
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            return await _baseClient.SendRequestAsync<BybitResponse<BybitPosition>>(_baseClient.GetUrl("v5/position/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get Asset Exchange History

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitAssetExchange>>> GetAssetExchangeHistoryAsync(
            string? fromAsset = null,
            string? toAsset = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("fromCoin", fromAsset);
            parameters.AddOptionalParameter("toCoin", toAsset);
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            var result = await _baseClient.SendRequestAsync<BybitAssetExchageWrapper>(_baseClient.GetUrl("v5/asset/exchange/order-record"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<BybitAssetExchange>>(null);

            return result.As(result.Data.OrderBody);
        }

        #endregion

        #region Get Delivery History

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitDeliveryRecord>>> GetDeliveryHistoryAsync(
            Category category,
            string? symbol = null,
            DateTime? expiryDate = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) }
            };
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("expDate", DateTimeConverter.ConvertToMilliseconds(expiryDate));
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            return await _baseClient.SendRequestAsync<BybitResponse<BybitDeliveryRecord>>(_baseClient.GetUrl("v5/asset/delivery-record"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get Settlement History

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitSettlementRecord>>> GetSettlementHistoryAsync(
            Category category,
            string? symbol = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) }
            };
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            return await _baseClient.SendRequestAsync<BybitResponse<BybitSettlementRecord>>(_baseClient.GetUrl("v5/asset/settlement-record"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion


        #region Get Closed Profit And Loss

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitClosedPnl>>> GetClosedProfitLossAsync(
            Category category,
            string? symbol = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) }
            };

            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            return await _baseClient.SendRequestAsync<BybitResponse<BybitClosedPnl>>(_baseClient.GetUrl("v5/position/closed-pnl"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Set Trading Stop

        /// <inheritdoc />
        public async Task<WebCallResult> SetTradingStopAsync(
            Category category,
            string symbol,
            PositionIdx positionIdx,
            decimal? takeProfit = null,
            decimal? stopLoss = null,
            decimal? trailingStop = null,
            TriggerType? takeProfitTrigger = null,
            TriggerType? stopLossTrigger = null,
            decimal? activePrice = null,
            decimal? takeProfitQuantity = null,
            decimal? stopLossQuantity = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "positionIdx", EnumConverter.GetString(positionIdx) }
            };

            parameters.AddOptionalParameter("takeProfit", takeProfit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("stopLoss", stopLoss?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("trailingStop", trailingStop?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tpTriggerBy", EnumConverter.GetString(takeProfitTrigger));
            parameters.AddOptionalParameter("slTriggerBy", EnumConverter.GetString(stopLossTrigger));
            parameters.AddOptionalParameter("activePrice", activePrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tpSize", takeProfitQuantity?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("slSize", stopLossQuantity?.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync(_baseClient.GetUrl("v5/position/trading-stop"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion
    }
}
