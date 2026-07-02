using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using CryptoExchange.Net.Objects;
using Bybit.Net.Enums;
using CryptoExchange.Net;
using Bybit.Net.Objects.Models.V5;
using System.Globalization;
using Bybit.Net.Interfaces.Clients.V5;
using Bybit.Net.Objects.Internal;
using System.Linq;
using CryptoExchange.Net.RateLimiting.Guards;
using CryptoExchange.Net.Objects.Errors;

namespace Bybit.Net.Clients.V5
{
    /// <inheritdoc />
    internal class BybitRestClientApiTrading : IBybitRestClientApiTrading
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
        private readonly BybitRestClientApi _baseClient;

        internal BybitRestClientApiTrading(BybitRestClientApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Place order

        /// <inheritdoc />
        public async Task<HttpResult<BybitOrderId>> PlaceOrderAsync(
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
            PositionIdx? positionIdx = null,
            string? clientOrderId = null,
            OrderType? takeProfitOrderType = null,
            decimal? takeProfit = null,
            decimal? takeProfitLimitPrice = null,
            OrderType? stopLossOrderType = null,
            decimal? stopLoss = null,
            decimal? stopLossLimitPrice = null,
            TriggerType? takeProfitTriggerBy = null,
            TriggerType? stopLossTriggerBy = null,
            bool? reduceOnly = null,
            bool? closeOnTrigger = null,
            bool? marketMakerProtection = null,
            StopLossTakeProfitMode? stopLossTakeProfitMode = null,
            SelfMatchPreventionType? selfMatchPreventionType = null,
            MarketUnit? marketUnit = null,
            SlippageToleranceType? slippageToleranceType = null,
            decimal? slippageTolerance = null,
            BboSideType? bboSideType = null,
            int? bboLevel = null,
            CancellationToken ct = default
        )
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "side", EnumConverter.GetString(side) },
                { "orderType", EnumConverter.GetString(type) },
                { "qty", quantity.ToString(CultureInfo.InvariantCulture) }
            };

            if (isLeverage != null)
                parameters.Add("isLeverage", isLeverage.Value ? 1 : 0);
            parameters.Add("price", price?.ToString(CultureInfo.InvariantCulture));
            if (triggerDirection != null)
                parameters.Add("triggerDirection", (int)triggerDirection);
            parameters.Add("orderFilter", EnumConverter.GetString(orderFilter));
            parameters.Add("triggerPrice", triggerPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.Add("triggerBy", EnumConverter.GetString(triggerBy));
            parameters.Add("orderIv", orderIv?.ToString(CultureInfo.InvariantCulture));
            parameters.Add("timeInForce", EnumConverter.GetString(timeInForce));
            parameters.Add("positionIdx", positionIdx == null ? null : (int)positionIdx);
            parameters.Add("orderLinkId", clientOrderId);
            parameters.Add("takeProfit", takeProfit?.ToString(CultureInfo.InvariantCulture));
            parameters.Add("stopLoss", stopLoss?.ToString(CultureInfo.InvariantCulture));
            parameters.Add("tpTriggerBy", EnumConverter.GetString(takeProfitTriggerBy));
            parameters.Add("slTriggerBy", EnumConverter.GetString(stopLossTriggerBy));
            parameters.Add("reduceOnly", reduceOnly);
            parameters.Add("closeOnTrigger", closeOnTrigger);
            parameters.Add("mmp", marketMakerProtection);
            parameters.Add("tpslMode", EnumConverter.GetString(stopLossTakeProfitMode));
            parameters.Add("tpOrderType", EnumConverter.GetString(takeProfitOrderType));
            parameters.Add("slOrderType", EnumConverter.GetString(stopLossOrderType));
            parameters.Add("tpLimitPrice", takeProfitLimitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.Add("slLimitPrice", stopLossLimitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.Add("smpType", EnumConverter.GetString(selfMatchPreventionType));
            parameters.Add("marketUnit", EnumConverter.GetString(marketUnit));
            parameters.Add("slippageToleranceType", slippageToleranceType);
            parameters.Add("slippageTolerance", slippageTolerance);
            parameters.Add("bboSideType", bboSideType);
            parameters.Add("bboLevel", bboLevel);

            var limits = BybitExchange.RateLimiter.GetOrderLimits();
            var limit = category == Category.Spot ? limits.limitSpot : limits.limitOther;
            var categoryIdentifier = category == Category.Spot ? "Spot" : category == Category.Option ? "Option" : "Futures";
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/order/create", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(limit, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding), identifier: "PlaceOrder" + categoryIdentifier);
            var result = await _baseClient.SendAsync<BybitOrderId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Pre Check Order

        /// <inheritdoc />
        public async Task<HttpResult<BybitPreCheckResult>> PreCheckOrderAsync(Category category,
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
            PositionIdx? positionIdx = null,
            string? clientOrderId = null,
            OrderType? takeProfitOrderType = null,
            decimal? takeProfit = null,
            decimal? takeProfitLimitPrice = null,
            OrderType? stopLossOrderType = null,
            decimal? stopLoss = null,
            decimal? stopLossLimitPrice = null,
            TriggerType? takeProfitTriggerBy = null,
            TriggerType? stopLossTriggerBy = null,
            bool? reduceOnly = null,
            bool? closeOnTrigger = null,
            bool? marketMakerProtection = null,
            StopLossTakeProfitMode? stopLossTakeProfitMode = null,
            SelfMatchPreventionType? selfMatchPreventionType = null,
            MarketUnit? marketUnit = null,
            SlippageToleranceType? slippageToleranceType = null,
            decimal? slippageTolerance = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "side", EnumConverter.GetString(side) },
                { "orderType", EnumConverter.GetString(type) },
                { "qty", quantity.ToString(CultureInfo.InvariantCulture) }
            };

            if (isLeverage != null)
                parameters.Add("isLeverage", isLeverage.Value ? 1 : 0);
            parameters.Add("price", price?.ToString(CultureInfo.InvariantCulture));
            if (triggerDirection != null)
                parameters.Add("triggerDirection", (int)triggerDirection);
            parameters.Add("orderFilter", EnumConverter.GetString(orderFilter));
            parameters.Add("triggerPrice", triggerPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.Add("triggerBy", EnumConverter.GetString(triggerBy));
            parameters.Add("orderIv", orderIv?.ToString(CultureInfo.InvariantCulture));
            parameters.Add("timeInForce", EnumConverter.GetString(timeInForce));
            parameters.Add("positionIdx", positionIdx == null ? null : (int)positionIdx);
            parameters.Add("orderLinkId", clientOrderId);
            parameters.Add("takeProfit", takeProfit?.ToString(CultureInfo.InvariantCulture));
            parameters.Add("stopLoss", stopLoss?.ToString(CultureInfo.InvariantCulture));
            parameters.Add("tpTriggerBy", EnumConverter.GetString(takeProfitTriggerBy));
            parameters.Add("slTriggerBy", EnumConverter.GetString(stopLossTriggerBy));
            parameters.Add("reduceOnly", reduceOnly);
            parameters.Add("closeOnTrigger", closeOnTrigger);
            parameters.Add("mmp", marketMakerProtection);
            parameters.Add("tpslMode", EnumConverter.GetString(stopLossTakeProfitMode));
            parameters.Add("tpOrderType", EnumConverter.GetString(takeProfitOrderType));
            parameters.Add("slOrderType", EnumConverter.GetString(stopLossOrderType));
            parameters.Add("tpLimitPrice", takeProfitLimitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.Add("slLimitPrice", stopLossLimitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.Add("smpType", EnumConverter.GetString(selfMatchPreventionType));
            parameters.Add("marketUnit", EnumConverter.GetString(marketUnit));
            parameters.Add("slippageToleranceType", slippageToleranceType);
            parameters.Add("slippageTolerance", slippageTolerance);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/v5/order/pre-check", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitPreCheckResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Place multiple orders

        /// <inheritdoc />
        public async Task<HttpResult<CallResult<BybitBatchOrderId>[]>> PlaceMultipleOrdersAsync(
            Category category,
            IEnumerable<BybitPlaceOrderRequest> orderRequests,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "request", orderRequests.ToArray() }
            };

            var limits = BybitExchange.RateLimiter.GetOrderLimits();
            var limit = category == Category.Spot ? limits.limitSpot : limits.limitOther;
            var categoryIdentifier = category == Category.Spot ? "Spot" : category == Category.Option ? "Option" : "Futures";
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/order/create-batch", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(limit, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding), identifier: "PlaceOrderBatch" + categoryIdentifier);
            var result = await _baseClient.SendRawAsync<BybitList<BybitBatchOrderId>, BybitList<BybitBatchResult>>(request, parameters, ct, singleLimiterWeight: orderRequests.Count()).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<CallResult<BybitBatchOrderId>[]>(result);

            if (result.Data.ReturnCode != 0)
                return HttpResult.Fail<CallResult<BybitBatchOrderId>[]>(result, new ServerError(result.Data.ReturnCode, _baseClient.GetErrorInfo(result.Data.ReturnCode, result.Data.ReturnMessage)));

            var resultList = new List<CallResult<BybitBatchOrderId>>(); 
            var resultItems = result.Data.Result.List.ToArray();
            int index = 0;
            foreach (var item in result.Data.ExtInfo.List)
            {                
                var resultItem = resultItems[index++];
                if (item.Code != 0)
                    resultList.Add(CallResult<BybitBatchOrderId>.Fail(new ServerError(item.Code, _baseClient.GetErrorInfo(item.Code, item.Message!))));
                else
                    resultList.Add(CallResult<BybitBatchOrderId>.Ok(resultItem));
            }

            if (resultList.All(x => !x.Success))
                return HttpResult.Fail<CallResult<BybitBatchOrderId>[]>(result, new ServerError(new ErrorInfo(ErrorType.AllOrdersFailed, "All order failed")), resultList.ToArray());

            return HttpResult.Ok(result, resultList.ToArray());
        }

        #endregion

        #region Edit order

        /// <inheritdoc />
        public async Task<HttpResult<BybitOrderId>> EditOrderAsync(
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
            StopLossTakeProfitMode? stopLossTakeProfitMode = null,
            decimal? takeProfitLimitPrice = null,
            decimal? stopLossLimitPrice = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol }
            };

            parameters.Add("qty", quantity);
            parameters.Add("price", price);
            parameters.Add("triggerPrice", triggerPrice);
            parameters.Add("triggerBy", triggerBy);
            parameters.Add("orderIv", orderIv);
            parameters.Add("orderId", orderId);
            parameters.Add("orderLinkId", clientOrderId);
            parameters.Add("takeProfit", takeProfit);
            parameters.Add("stopLoss", stopLoss);
            parameters.Add("tpTriggerBy", takeProfitTriggerBy);
            parameters.Add("slTriggerBy", stopLossTriggerBy);
            parameters.Add("tpslMode", stopLossTakeProfitMode);
            parameters.Add("tpLimitPrice", takeProfitLimitPrice);
            parameters.Add("slLimitPrice", stopLossLimitPrice);

            var categoryIdentifier = category == Category.Spot ? "Spot" : category == Category.Option ? "Option" : "Futures";
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/order/amend", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding), identifier: "EditOrder" + categoryIdentifier);
            return await _baseClient.SendAsync<BybitOrderId>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Edit multiple orders

        /// <inheritdoc />
        public async Task<HttpResult<BybitBatchResult<BybitBatchOrderId>[]>> EditMultipleOrdersAsync(
            Category category,
            IEnumerable<BybitEditOrderRequest> orderRequests,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "request", orderRequests.ToArray() }
            };

            var limits = BybitExchange.RateLimiter.GetOrderLimits();
            var limit = category == Category.Spot ? limits.limitSpot : limits.limitOther;
            var categoryIdentifier = category == Category.Spot ? "Spot" : category == Category.Option ? "Option" : "Futures";
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/order/amend-batch", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(limit, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding), identifier: "EditMultiple" + categoryIdentifier);
            var result = await _baseClient.SendRawAsync<BybitList<BybitBatchOrderId>, BybitList<BybitBatchResult>>(request, parameters, ct, singleLimiterWeight: orderRequests.Count()).ConfigureAwait(false);
            if (!result.Success || result.Data == null)
                return HttpResult.Fail<BybitBatchResult<BybitBatchOrderId>[]>(result);

            if (result.Data.ReturnCode != 0)
                return HttpResult.Fail<BybitBatchResult<BybitBatchOrderId>[]>(result, new ServerError(result.Data.ReturnCode, _baseClient.GetErrorInfo(result.Data.ReturnCode, result.Data.ReturnMessage)));

            var resultList = new List<BybitBatchResult<BybitBatchOrderId>>();
            var resultItems = result.Data.Result.List.ToArray();
            int index = 0;
            foreach (var item in result.Data.ExtInfo.List)
            {
                resultList.Add(new BybitBatchResult<BybitBatchOrderId>
                {
                    Code = item.Code,
                    Message = item.Message,
                    Data = resultItems[index++]
                });
            }

            return HttpResult.Ok(result, resultList.ToArray());
        }

        #endregion

        #region Cancel order

        /// <inheritdoc />
        public async Task<HttpResult<BybitOrderId>> CancelOrderAsync(
            Category category,
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            OrderFilter? orderFilter = null,
            CancellationToken ct = default)
        {
            if (orderId == null && clientOrderId == null)
                throw new ArgumentException("One of orderId or clientOrderId should be provided");

            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol }
            };

            parameters.Add("orderId", orderId);
            parameters.Add("orderLinkId", clientOrderId);
            parameters.Add("orderFilter", EnumConverter.GetString(orderFilter));

            var limits = BybitExchange.RateLimiter.GetOrderLimits();
            var limit = category == Category.Spot ? limits.limitSpot : limits.limitOther;
            var categoryIdentifier = category == Category.Spot ? "Spot" : category == Category.Option ? "Option" : "Futures";
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/order/cancel", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(limit, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding), identifier: "CancelOrder" + categoryIdentifier);
            var result = await _baseClient.SendAsync<BybitOrderId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cancel multiple orders

        /// <inheritdoc />
        public async Task<HttpResult<BybitBatchResult<BybitBatchOrderId>[]>> CancelMultipleOrdersAsync(
            Category category,
            IEnumerable<BybitCancelOrderRequest> orderRequests,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "request", orderRequests.ToArray() }
            };

            var limits = BybitExchange.RateLimiter.GetOrderLimits();
            var limit = category == Category.Spot ? limits.limitSpot : limits.limitOther;
            var categoryIdentifier = category == Category.Spot ? "Spot" : category == Category.Option ? "Option" : "Futures";
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/order/cancel-batch", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(limit, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendRawAsync<BybitList<BybitBatchOrderId>, BybitList<BybitBatchResult>>(request, parameters, ct, singleLimiterWeight: orderRequests.Count()).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BybitBatchResult<BybitBatchOrderId>[]>(result);

            if (result.Data.ReturnCode != 0)
                return HttpResult.Fail<BybitBatchResult<BybitBatchOrderId>[]>(result, new ServerError(result.Data.ReturnCode, _baseClient.GetErrorInfo(result.Data.ReturnCode, result.Data.ReturnMessage)));

            var resultList = new List<BybitBatchResult<BybitBatchOrderId>>();
            var resultItems = result.Data.Result.List.ToArray(); 
            int index = 0;
            foreach (var item in result.Data.ExtInfo.List)
            {
                var resultItem = resultItems[index++];
                resultList.Add(new BybitBatchResult<BybitBatchOrderId>
                {
                    Code = item.Code,
                    Message = item.Message,
                    Data = resultItem
                });
            }

            return HttpResult.Ok(result, resultList.ToArray());
        }

        #endregion

        #region Get Open Orders

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitOrder>>> GetOrdersAsync(
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
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) }
            };

            parameters.Add("symbol", symbol);
            parameters.Add("baseCoin", baseAsset);
            parameters.Add("settleCoin", settleAsset);
            parameters.Add("orderId", orderId);
            parameters.Add("orderLinkId", clientOrderId);
            parameters.Add("orderFilter", EnumConverter.GetString(orderFilter));
            parameters.Add("openOnly", openOnly);
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/order/realtime", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(50, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitOrder>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Cancel All Orders

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitOrderId>>> CancelAllOrderAsync(
            Category category,
            string? symbol = null,
            string? baseAsset = null,
            string? settleAsset = null,
            OrderFilter? orderFilter = null,
            StopOrderType? stopOrderType = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) }
            };

            parameters.Add("symbol", symbol);
            parameters.Add("baseCoin", baseAsset);
            parameters.Add("settleCoin", settleAsset);
            parameters.Add("orderFilter", EnumConverter.GetString(orderFilter));
            parameters.Add("stopOrderType", EnumConverter.GetString(stopOrderType));

            var categoryIdentifier = category == Category.Spot ? "Spot" : category == Category.Option ? "Option" : "Futures";
            var limit = category == Category.Spot ? 20 : category == Category.Option ? 1 : 10;
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/order/cancel-all", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(limit, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding), identifier: "CancelAll" + categoryIdentifier);
            return await _baseClient.SendAsync<BybitResponse<BybitOrderId>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Order History

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitOrder>>> GetOrderHistoryAsync(
            Category category,
            string? symbol = null,
            string? baseAsset = null,
            string? orderId = null,
            string? clientOrderId = null,
            OrderStatus? status = null,
            OrderFilter? orderFilter = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) }
            };

            parameters.Add("symbol", symbol);
            parameters.Add("baseCoin", baseAsset);
            parameters.Add("orderId", orderId);
            parameters.Add("orderLinkId", clientOrderId);
            parameters.Add("orderFilter", EnumConverter.GetString(orderFilter));
            parameters.Add("orderStatus", EnumConverter.GetString(status));
            parameters.Add("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.Add("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/order/history", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(50, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitOrder>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Borrow Quota

        /// <inheritdoc />
        public async Task<HttpResult<BybitBorrowQuota>> GetBorrowQuotaAsync(
            string symbol,
            OrderSide side,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(Category.Spot) },
                { "symbol", symbol },
                { "side", EnumConverter.GetString(side) },
            };

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/order/spot-borrow-check", true);
            return await _baseClient.SendAsync<BybitBorrowQuota>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set Disconnect Cancel All

        /// <inheritdoc />
        public async Task<HttpResult> SetDisconnectCancelAllAsync(
            int windowSeconds,
            ProductType? productType = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "timeWindow", windowSeconds },
            };
            parameters.Add("product", productType);

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/order/disconnected-cancel-all", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Disconnect Cancel All

        /// <inheritdoc />
        public async Task<HttpResult<BybitDcpStatus[]>> GetDisconnectCancelAllConfigAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/account/query-dcp-info", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitDcpStatusWrapper>(request, null, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BybitDcpStatus[]>(result);

            return HttpResult.Ok(result, result.Data.Infos);
        }

        #endregion

        #region Get User Trades

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitUserTrade>>> GetUserTradesAsync(
            Category category,
            string? symbol = null,
            string? baseAsset = null,
            string? orderId = null,
            string? clientOrderId = null,
            string? settleAsset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            TradeType? tradeType = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) }
            };

            parameters.Add("symbol", symbol);
            parameters.Add("baseCoin", baseAsset);
            parameters.Add("settleCoin", settleAsset);
            parameters.Add("orderId", orderId);
            parameters.Add("orderLinkId", clientOrderId);
            parameters.Add("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.Add("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.Add("execType", EnumConverter.GetString(tradeType));
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/execution/list", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(50, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitUserTrade>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Positions

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitPosition>>> GetPositionsAsync(
            Category category,
            string? symbol = null,
            string? baseAsset = null,
            string? settleAsset = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
            };

            parameters.Add("symbol", symbol);
            parameters.Add("baseCoin", baseAsset);
            parameters.Add("settleCoin", settleAsset);
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/position/list", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(50, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitPosition>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Confirm Risk Limit

        /// <inheritdoc />
        public async Task<HttpResult> ConfirmRiskLimitAsync(
            Category category,
            string symbol,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/position/confirm-pending-mmr", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Asset Exchange History

        /// <inheritdoc />
        public async Task<HttpResult<BybitAssetExchangePage>> GetAssetExchangeHistoryAsync(
            string? fromAsset = null,
            string? toAsset = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("fromCoin", fromAsset);
            parameters.Add("toCoin", toAsset);
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/asset/exchange/order-record", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(600, TimeSpan.FromMinutes(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitAssetExchangePage>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Delivery History

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitDeliveryRecord>>> GetDeliveryHistoryAsync(
            Category category,
            string? symbol = null,
            DateTime? expiryDate = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) }
            };
            parameters.Add("symbol", symbol);
            parameters.Add("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.Add("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.Add("expDate", DateTimeConverter.ConvertToMilliseconds(expiryDate));
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/asset/delivery-record", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitResponse<BybitDeliveryRecord>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Settlement History

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitSettlementRecord>>> GetSettlementHistoryAsync(
            Category category,
            string? symbol = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) }
            };
            parameters.Add("symbol", symbol);
            parameters.Add("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.Add("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/asset/settlement-record", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitResponse<BybitSettlementRecord>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Closed Profit And Loss

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitClosedPnl>>> GetClosedProfitLossAsync(
            Category category,
            string? symbol = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) }
            };

            parameters.Add("symbol", symbol);
            parameters.Add("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.Add("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/position/closed-pnl", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(50, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitClosedPnl>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set Trading Stop

        /// <inheritdoc />
        public async Task<HttpResult> SetTradingStopAsync(
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
            StopLossTakeProfitMode? stopLossTakeProfitMode = null,
            decimal? takeProfitLimitPrice = null,
            decimal? stopLossLimitPrice = null,
            OrderType? takeProfitOrderType = null,
            OrderType? stopLossOrderType = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "positionIdx", (int)positionIdx }
            };

            parameters.Add("takeProfit", takeProfit?.ToString(CultureInfo.InvariantCulture));
            parameters.Add("stopLoss", stopLoss?.ToString(CultureInfo.InvariantCulture));
            parameters.Add("trailingStop", trailingStop?.ToString(CultureInfo.InvariantCulture));
            parameters.Add("tpTriggerBy", EnumConverter.GetString(takeProfitTrigger));
            parameters.Add("slTriggerBy", EnumConverter.GetString(stopLossTrigger));
            parameters.Add("activePrice", activePrice?.ToString(CultureInfo.InvariantCulture));
            parameters.Add("tpSize", takeProfitQuantity?.ToString(CultureInfo.InvariantCulture));
            parameters.Add("slSize", stopLossQuantity?.ToString(CultureInfo.InvariantCulture));

            parameters.Add("tpslMode", EnumConverter.GetString(stopLossTakeProfitMode));
            parameters.Add("tpLimitPrice", takeProfitLimitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.Add("slLimitPrice", stopLossLimitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.Add("tpOrderType", EnumConverter.GetString(takeProfitOrderType));
            parameters.Add("slOrderType", EnumConverter.GetString(stopLossOrderType));

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/position/trading-stop", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Purchase Leverage Token

        /// <inheritdoc />
        public async Task<HttpResult<BybitLeverageTokenPurchase>> PurchaseLeverageTokenAsync(string token, decimal quantity, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "ltCoin", token },
                { "ltAmount", quantity.ToString(CultureInfo.InvariantCulture) },
            };

            parameters.Add("serialNo", clientOrderId);

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/spot-lever-token/purchase", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitLeverageTokenPurchase>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Redeem Leverage Token

        /// <inheritdoc />
        public async Task<HttpResult<BybitLeverageTokenRedemption>> RedeemLeverageTokenAsync(string token, decimal quantity, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "ltCoin", token },
                { "ltAmount", quantity.ToString(CultureInfo.InvariantCulture) },
            };

            parameters.Add("serialNo", clientOrderId);

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/spot-lever-token/redeem", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitLeverageTokenRedemption>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get leverage Token Order History

        /// <inheritdoc />
        public async Task<HttpResult<BybitLeverageTokenHistory[]>> GetLeverageTokenOrderHistoryAsync(string? token = null, string? orderId = null, string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, LeverageTokenRecordType? type = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("serialNo", clientOrderId);
            parameters.Add("ltOrderType", type == LeverageTokenRecordType.Redeem ? 2 : type == LeverageTokenRecordType.Purchase ? 1 : null);
            parameters.Add("limit", limit);
            parameters.Add("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.Add("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.Add("orderId", orderId);
            parameters.Add("ltCoin", token);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/spot-lever-token/order-record", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(50, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            var result = await _baseClient.SendAsync<BybitResponse<BybitLeverageTokenHistory>>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BybitLeverageTokenHistory[]>(result);

            return HttpResult.Ok(result, result.Data.List);
        }

        #endregion

        #region Place Spread Order

        /// <inheritdoc />
        public async Task<HttpResult<BybitOrderId>> PlaceSpreadOrderAsync(string symbol, OrderSide side, NewOrderType type, decimal quantity, TimeInForce timeInForce, decimal? price = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("side", side);
            parameters.Add("orderType", type);
            parameters.Add("qty", quantity.ToString(CultureInfo.InvariantCulture));
            parameters.Add("timeInForce", timeInForce);
            parameters.Add("price", price?.ToString(CultureInfo.InvariantCulture));
            parameters.Add("orderLinkId", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/v5/spread/order/create", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitOrderId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Edit Spread Order

        /// <inheritdoc />
        public async Task<HttpResult<BybitOrderId>> EditSpreadOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, decimal? quantity = null, decimal? price = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("orderId", orderId);
            parameters.Add("orderLinkId", clientOrderId);
            parameters.Add("qty", quantity?.ToString(CultureInfo.InvariantCulture));
            parameters.Add("price", price?.ToString(CultureInfo.InvariantCulture));
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/v5/spread/order/amend", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitOrderId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cancel Spread Order

        /// <inheritdoc />
        public async Task<HttpResult<BybitOrderId>> CancelSpreadOrderAsync(string? orderId = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("orderId", orderId);
            parameters.Add("orderLinkId", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/v5/spread/order/cancel", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitOrderId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cancel All Spread Orders

        /// <inheritdoc />
        public async Task<HttpResult<BybitOrderId[]>> CancelAllSpreadOrdersAsync(string? symbol = null, bool? cancelAll = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("cancelAll", cancelAll);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/v5/spread/order/cancel-all", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitList<BybitOrderId>>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BybitOrderId[]>(result);

            return HttpResult.Ok(result, result.Data.List);
        }

        #endregion

        #region Get Open Spread Orders

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitSpreadOrder>>> GetOpenSpreadOrdersAsync(string? symbol = null, string? baseAsset = null, string? orderId = null, string? clientOrderId = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("baseCoin", baseAsset);
            parameters.Add("orderId", orderId);
            parameters.Add("orderLinkId", clientOrderId);
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/spread/order/realtime", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitResponse<BybitSpreadOrder>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Closed Spread Orders

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitClosedSpreadOrder>>> GetClosedSpreadOrdersAsync(string? symbol = null, string? baseAsset = null, string? orderId = null, string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("baseCoin", baseAsset);
            parameters.Add("orderId", orderId);
            parameters.Add("orderLinkId", clientOrderId);
            parameters.Add("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.Add("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/spread/order/history", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitResponse<BybitClosedSpreadOrder>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Spread User Trades

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitSpreadUserTrade>>> GetSpreadUserTradesAsync(string? symbol = null, string? orderId = null, string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("orderId", orderId);
            parameters.Add("orderLinkId", clientOrderId);
            parameters.Add("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.Add("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/spread/execution/list", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitResponse<BybitSpreadUserTrade>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

    }
}
