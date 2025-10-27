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
using System.Drawing;
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
        public async Task<WebCallResult<BybitOrderId>> PlaceOrderAsync(
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
            var parameters = new ParameterCollection()
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
            if (triggerDirection != null)
                parameters.AddOptionalParameter("triggerDirection", (int)triggerDirection);
            parameters.AddOptionalParameter("orderFilter", EnumConverter.GetString(orderFilter));
            parameters.AddOptionalParameter("triggerPrice", triggerPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("triggerBy", EnumConverter.GetString(triggerBy));
            parameters.AddOptionalParameter("orderIv", orderIv?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("timeInForce", EnumConverter.GetString(timeInForce));
            parameters.AddOptionalParameter("positionIdx", positionIdx == null ? null : (int)positionIdx);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("takeProfit", takeProfit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("stopLoss", stopLoss?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tpTriggerBy", EnumConverter.GetString(takeProfitTriggerBy));
            parameters.AddOptionalParameter("slTriggerBy", EnumConverter.GetString(stopLossTriggerBy));
            parameters.AddOptionalParameter("reduceOnly", reduceOnly);
            parameters.AddOptionalParameter("closeOnTrigger", closeOnTrigger);
            parameters.AddOptionalParameter("mmp", marketMakerProtection);
            parameters.AddOptionalParameter("tpslMode", EnumConverter.GetString(stopLossTakeProfitMode));
            parameters.AddOptionalParameter("tpOrderType", EnumConverter.GetString(takeProfitOrderType));
            parameters.AddOptionalParameter("slOrderType", EnumConverter.GetString(stopLossOrderType));
            parameters.AddOptionalParameter("tpLimitPrice", takeProfitLimitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("slLimitPrice", stopLossLimitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("smpType", EnumConverter.GetString(selfMatchPreventionType));
            parameters.AddOptionalParameter("marketUnit", EnumConverter.GetString(marketUnit));
            parameters.AddOptionalEnum("slippageToleranceType", slippageToleranceType);
            parameters.AddOptionalString("slippageTolerance", slippageTolerance);
            parameters.AddOptionalEnum("bboSideType", bboSideType);
            parameters.AddOptional("bboLevel", bboLevel);

            var limits = BybitExchange.RateLimiter.GetOrderLimits();
            var limit = category == Category.Spot ? limits.limitSpot : limits.limitOther;
            var categoryIdentifier = category == Category.Spot ? "Spot" : category == Category.Option ? "Option" : "Futures";
            var request = _definitions.GetOrCreate("PlaceOrder" + categoryIdentifier, HttpMethod.Post, "v5/order/create", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(limit, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BybitOrderId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Pre Check Order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitPreCheckResult>> PreCheckOrderAsync(Category category,
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
            var parameters = new ParameterCollection()
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
            if (triggerDirection != null)
                parameters.AddOptionalParameter("triggerDirection", (int)triggerDirection);
            parameters.AddOptionalParameter("orderFilter", EnumConverter.GetString(orderFilter));
            parameters.AddOptionalParameter("triggerPrice", triggerPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("triggerBy", EnumConverter.GetString(triggerBy));
            parameters.AddOptionalParameter("orderIv", orderIv?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("timeInForce", EnumConverter.GetString(timeInForce));
            parameters.AddOptionalParameter("positionIdx", positionIdx == null ? null : (int)positionIdx);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("takeProfit", takeProfit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("stopLoss", stopLoss?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tpTriggerBy", EnumConverter.GetString(takeProfitTriggerBy));
            parameters.AddOptionalParameter("slTriggerBy", EnumConverter.GetString(stopLossTriggerBy));
            parameters.AddOptionalParameter("reduceOnly", reduceOnly);
            parameters.AddOptionalParameter("closeOnTrigger", closeOnTrigger);
            parameters.AddOptionalParameter("mmp", marketMakerProtection);
            parameters.AddOptionalParameter("tpslMode", EnumConverter.GetString(stopLossTakeProfitMode));
            parameters.AddOptionalParameter("tpOrderType", EnumConverter.GetString(takeProfitOrderType));
            parameters.AddOptionalParameter("slOrderType", EnumConverter.GetString(stopLossOrderType));
            parameters.AddOptionalParameter("tpLimitPrice", takeProfitLimitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("slLimitPrice", stopLossLimitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("smpType", EnumConverter.GetString(selfMatchPreventionType));
            parameters.AddOptionalParameter("marketUnit", EnumConverter.GetString(marketUnit));
            parameters.AddOptionalEnum("slippageToleranceType", slippageToleranceType);
            parameters.AddOptionalString("slippageTolerance", slippageTolerance);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/v5/order/pre-check", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitPreCheckResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Place multiple orders

        /// <inheritdoc />
        public async Task<WebCallResult<CallResult<BybitBatchOrderId>[]>> PlaceMultipleOrdersAsync(
            Category category,
            IEnumerable<BybitPlaceOrderRequest> orderRequests,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) },
                { "request", orderRequests.ToArray() }
            };

            var limits = BybitExchange.RateLimiter.GetOrderLimits();
            var limit = category == Category.Spot ? limits.limitSpot : limits.limitOther;
            var categoryIdentifier = category == Category.Spot ? "Spot" : category == Category.Option ? "Option" : "Futures";
            var request = _definitions.GetOrCreate("PlaceOrderBatch" + categoryIdentifier, HttpMethod.Post, "v5/order/create-batch", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(limit, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendRawAsync<BybitList<BybitBatchOrderId>, BybitList<BybitBatchResult>>(request, parameters, ct, singleLimiterWeight: orderRequests.Count()).ConfigureAwait(false);

            if (result.Data.ReturnCode != 0)
                return result.AsError<CallResult<BybitBatchOrderId>[]>(new ServerError(result.Data.ReturnCode, _baseClient.GetErrorInfo(result.Data.ReturnCode, result.Data.ReturnMessage)));

            var resultList = new List<CallResult<BybitBatchOrderId>>(); 
            var resultItems = result.Data.Result.List.ToArray();
            int index = 0;
            foreach (var item in result.Data.ExtInfo.List)
            {                
                var resultItem = resultItems[index++];
                if (item.Code != 0)
                    resultList.Add(new CallResult<BybitBatchOrderId>(new ServerError(item.Code, _baseClient.GetErrorInfo(item.Code, item.Message!))));
                else
                    resultList.Add(new CallResult<BybitBatchOrderId>(resultItem));
            }

            if (resultList.All(x => !x.Success))
                return result.AsErrorWithData<CallResult<BybitBatchOrderId>[]>(new ServerError(new ErrorInfo(ErrorType.AllOrdersFailed, "All order failed")), resultList.ToArray());

            return result.As<CallResult<BybitBatchOrderId>[]>(resultList.ToArray());
        }

        #endregion

        #region Edit order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitOrderId>> EditOrderAsync(
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
            var parameters = new ParameterCollection
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol }
            };

            parameters.AddOptionalString("qty", quantity);
            parameters.AddOptionalString("price", price);
            parameters.AddOptionalString("triggerPrice", triggerPrice);
            parameters.AddOptionalEnum("triggerBy", triggerBy);
            parameters.AddOptionalString("orderIv", orderIv);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("orderLinkId", clientOrderId);
            parameters.AddOptionalString("takeProfit", takeProfit);
            parameters.AddOptionalString("stopLoss", stopLoss);
            parameters.AddOptionalEnum("tpTriggerBy", takeProfitTriggerBy);
            parameters.AddOptionalEnum("slTriggerBy", stopLossTriggerBy);
            parameters.AddOptionalEnum("tpslMode", stopLossTakeProfitMode);
            parameters.AddOptionalString("tpLimitPrice", takeProfitLimitPrice);
            parameters.AddOptionalString("slLimitPrice", stopLossLimitPrice);

            var categoryIdentifier = category == Category.Spot ? "Spot" : category == Category.Option ? "Option" : "Futures";
            var request = _definitions.GetOrCreate("EditOrder" + categoryIdentifier, HttpMethod.Post, "v5/order/amend", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BybitOrderId>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Edit multiple orders

        /// <inheritdoc />
        public async Task<WebCallResult<BybitBatchResult<BybitBatchOrderId>[]>> EditMultipleOrdersAsync(
            Category category,
            IEnumerable<BybitEditOrderRequest> orderRequests,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) },
                { "request", orderRequests.ToArray() }
            };

            var limits = BybitExchange.RateLimiter.GetOrderLimits();
            var limit = category == Category.Spot ? limits.limitSpot : limits.limitOther;
            var categoryIdentifier = category == Category.Spot ? "Spot" : category == Category.Option ? "Option" : "Futures";
            var request = _definitions.GetOrCreate("EditMultiple" + categoryIdentifier, HttpMethod.Post, "v5/order/amend-batch", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(limit, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendRawAsync<BybitList<BybitBatchOrderId>, BybitList<BybitBatchResult>>(request, parameters, ct, singleLimiterWeight: orderRequests.Count()).ConfigureAwait(false);
            if (!result || result.Data == null)
                return result.As<BybitBatchResult<BybitBatchOrderId>[]>(default);

            if (result.Data.ReturnCode != 0)
                return result.AsError<BybitBatchResult<BybitBatchOrderId>[]>(new ServerError(result.Data.ReturnCode, _baseClient.GetErrorInfo(result.Data.ReturnCode, result.Data.ReturnMessage)));

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

            return result.As(resultList.ToArray());
        }

        #endregion

        #region Cancel order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitOrderId>> CancelOrderAsync(
            Category category,
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            OrderFilter? orderFilter = null,
            CancellationToken ct = default)
        {
            if (orderId == null && clientOrderId == null)
                throw new ArgumentException("One of orderId or clientOrderId should be provided");

            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol }
            };

            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("orderFilter", EnumConverter.GetString(orderFilter));

            var limits = BybitExchange.RateLimiter.GetOrderLimits();
            var limit = category == Category.Spot ? limits.limitSpot : limits.limitOther;
            var categoryIdentifier = category == Category.Spot ? "Spot" : category == Category.Option ? "Option" : "Futures";
            var request = _definitions.GetOrCreate("CancelOrder" + categoryIdentifier, HttpMethod.Post, "v5/order/cancel", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(limit, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BybitOrderId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cancel multiple orders

        /// <inheritdoc />
        public async Task<WebCallResult<BybitBatchResult<BybitBatchOrderId>[]>> CancelMultipleOrdersAsync(
            Category category,
            IEnumerable<BybitCancelOrderRequest> orderRequests,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) },
                { "request", orderRequests.ToArray() }
            };

            var limits = BybitExchange.RateLimiter.GetOrderLimits();
            var limit = category == Category.Spot ? limits.limitSpot : limits.limitOther;
            var categoryIdentifier = category == Category.Spot ? "Spot" : category == Category.Option ? "Option" : "Futures";
            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/order/cancel-batch", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(limit, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendRawAsync<BybitList<BybitBatchOrderId>, BybitList<BybitBatchResult>>(request, parameters, ct, singleLimiterWeight: orderRequests.Count()).ConfigureAwait(false);
            if (!result)
                return result.As<BybitBatchResult<BybitBatchOrderId>[]>(default);

            if (result.Data.ReturnCode != 0)
                return result.AsError<BybitBatchResult<BybitBatchOrderId>[]>(new ServerError(result.Data.ReturnCode, _baseClient.GetErrorInfo(result.Data.ReturnCode, result.Data.ReturnMessage)));

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

            return result.As<BybitBatchResult<BybitBatchOrderId>[]>(resultList.ToArray());
        }

        #endregion

        #region Get Open Orders

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitOrder>>> GetOrdersAsync(
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
            var parameters = new ParameterCollection()
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

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/order/realtime", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(50, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitOrder>>(request, parameters, ct).ConfigureAwait(false);
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
            StopOrderType? stopOrderType = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) }
            };

            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("settleCoin", settleAsset);
            parameters.AddOptionalParameter("orderFilter", EnumConverter.GetString(orderFilter));
            parameters.AddOptionalParameter("stopOrderType", EnumConverter.GetString(stopOrderType));

            var categoryIdentifier = category == Category.Spot ? "Spot" : category == Category.Option ? "Option" : "Futures";
            var limit = category == Category.Spot ? 20 : category == Category.Option ? 1 : 10;
            var request = _definitions.GetOrCreate("CancelAll" + categoryIdentifier, HttpMethod.Post, "v5/order/cancel-all", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(limit, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BybitResponse<BybitOrderId>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Order History

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitOrder>>> GetOrderHistoryAsync(
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
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) }
            };

            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("orderFilter", EnumConverter.GetString(orderFilter));
            parameters.AddOptionalParameter("orderStatus", EnumConverter.GetString(status));
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/order/history", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(50, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitOrder>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Borrow Quota

        /// <inheritdoc />
        public async Task<WebCallResult<BybitBorrowQuota>> GetBorrowQuotaAsync(
            string symbol,
            OrderSide side,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(Category.Spot) },
                { "symbol", symbol },
                { "side", EnumConverter.GetString(side) },
            };

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/order/spot-borrow-check", true);
            return await _baseClient.SendAsync<BybitBorrowQuota>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set Disconnect Cancel All

        /// <inheritdoc />
        public async Task<WebCallResult> SetDisconnectCancelAllAsync(
            int windowSeconds,
            ProductType? productType = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection
            {
                { "timeWindow", windowSeconds },
            };
            parameters.AddOptionalEnum("product", productType);

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/order/disconnected-cancel-all", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Disconnect Cancel All

        /// <inheritdoc />
        public async Task<WebCallResult<BybitDcpStatus[]>> GetDisconnectCancelAllConfigAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/account/query-dcp-info", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitDcpStatusWrapper>(request, null, ct).ConfigureAwait(false);
            return result.As<BybitDcpStatus[]>(result.Data?.Infos);
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
            var parameters = new ParameterCollection()
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

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/execution/list", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(50, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitUserTrade>>(request, parameters, ct).ConfigureAwait(false);
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
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) },
            };

            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("settleCoin", settleAsset);
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/position/list", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(50, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitPosition>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Confirm Risk Limit

        /// <inheritdoc />
        public async Task<WebCallResult> ConfirmRiskLimitAsync(
            Category category,
            string symbol,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/position/confirm-pending-mmr", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Asset Exchange History

        /// <inheritdoc />
        public async Task<WebCallResult<BybitAssetExchange[]>> GetAssetExchangeHistoryAsync(
            string? fromAsset = null,
            string? toAsset = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptionalParameter("fromCoin", fromAsset);
            parameters.AddOptionalParameter("toCoin", toAsset);
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/asset/exchange/order-record", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(600, TimeSpan.FromMinutes(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            var result = await _baseClient.SendAsync<BybitAssetExchageWrapper>(request, parameters, ct).ConfigureAwait(false);
            if (!result)
                return result.As<BybitAssetExchange[]>(null);

            return result.As(result.Data.OrderBody);
        }

        #endregion

        #region Get Delivery History

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitDeliveryRecord>>> GetDeliveryHistoryAsync(
            Category category,
            string? symbol = null,
            DateTime? expiryDate = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) }
            };
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("expDate", DateTimeConverter.ConvertToMilliseconds(expiryDate));
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/asset/delivery-record", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitResponse<BybitDeliveryRecord>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Settlement History

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitSettlementRecord>>> GetSettlementHistoryAsync(
            Category category,
            string? symbol = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) }
            };
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/asset/settlement-record", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitResponse<BybitSettlementRecord>>(request, parameters, ct).ConfigureAwait(false);
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
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) }
            };

            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/position/closed-pnl", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(50, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitClosedPnl>>(request, parameters, ct).ConfigureAwait(false);
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
            StopLossTakeProfitMode? stopLossTakeProfitMode = null,
            decimal? takeProfitLimitPrice = null,
            decimal? stopLossLimitPrice = null,
            OrderType? takeProfitOrderType = null,
            OrderType? stopLossOrderType = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "positionIdx", (int)positionIdx }
            };

            parameters.AddOptionalParameter("takeProfit", takeProfit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("stopLoss", stopLoss?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("trailingStop", trailingStop?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tpTriggerBy", EnumConverter.GetString(takeProfitTrigger));
            parameters.AddOptionalParameter("slTriggerBy", EnumConverter.GetString(stopLossTrigger));
            parameters.AddOptionalParameter("activePrice", activePrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tpSize", takeProfitQuantity?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("slSize", stopLossQuantity?.ToString(CultureInfo.InvariantCulture));

            parameters.AddOptionalParameter("tpslMode", EnumConverter.GetString(stopLossTakeProfitMode));
            parameters.AddOptionalParameter("tpLimitPrice", takeProfitLimitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("slLimitPrice", stopLossLimitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tpOrderType", EnumConverter.GetString(takeProfitOrderType));
            parameters.AddOptionalParameter("slOrderType", EnumConverter.GetString(stopLossOrderType));

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/position/trading-stop", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Purchase Leverage Token

        /// <inheritdoc />
        public async Task<WebCallResult<BybitLeverageTokenPurchase>> PurchaseLeverageTokenAsync(string token, decimal quantity, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "ltCoin", token },
                { "ltAmount", quantity.ToString(CultureInfo.InvariantCulture) },
            };

            parameters.AddOptionalParameter("serialNo", clientOrderId);

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/spot-lever-token/purchase", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitLeverageTokenPurchase>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Redeem Leverage Token

        /// <inheritdoc />
        public async Task<WebCallResult<BybitLeverageTokenRedemption>> RedeemLeverageTokenAsync(string token, decimal quantity, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "ltCoin", token },
                { "ltAmount", quantity.ToString(CultureInfo.InvariantCulture) },
            };

            parameters.AddOptionalParameter("serialNo", clientOrderId);

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/spot-lever-token/redeem", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitLeverageTokenRedemption>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get leverage Token Order History

        /// <inheritdoc />
        public async Task<WebCallResult<BybitLeverageTokenHistory[]>> GetLeverageTokenOrderHistoryAsync(string? token = null, string? orderId = null, string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, LeverageTokenRecordType? type = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptionalParameter("serialNo", clientOrderId);
            parameters.AddOptionalParameter("ltOrderType", type == LeverageTokenRecordType.Redeem ? 2 : type == LeverageTokenRecordType.Purchase ? 1 : null);
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("ltCoin", token);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/spot-lever-token/order-record", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(50, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            var result = await _baseClient.SendAsync<BybitResponse<BybitLeverageTokenHistory>>(request, parameters, ct).ConfigureAwait(false);
            if (!result)
                return result.As<BybitLeverageTokenHistory[]>(default);

            return result.As(result.Data.List);
        }

        #endregion

        #region Place Spread Order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitOrderId>> PlaceSpreadOrderAsync(string symbol, OrderSide side, NewOrderType type, decimal quantity, TimeInForce timeInForce, decimal? price = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddEnum("side", side);
            parameters.AddEnum("orderType", type);
            parameters.Add("qty", quantity.ToString(CultureInfo.InvariantCulture));
            parameters.AddEnum("timeInForce", timeInForce);
            parameters.AddOptional("price", price?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptional("orderLinkId", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/v5/spread/order/create", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitOrderId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Edit Spread Order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitOrderId>> EditSpreadOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, decimal? quantity = null, decimal? price = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("orderLinkId", clientOrderId);
            parameters.AddOptional("qty", quantity?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptional("price", price?.ToString(CultureInfo.InvariantCulture));
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/v5/spread/order/amend", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitOrderId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cancel Spread Order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitOrderId>> CancelSpreadOrderAsync(string? orderId = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("orderLinkId", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/v5/spread/order/cancel", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitOrderId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cancel All Spread Orders

        /// <inheritdoc />
        public async Task<WebCallResult<BybitOrderId[]>> CancelAllSpreadOrdersAsync(string? symbol = null, bool? cancelAll = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("cancelAll", cancelAll);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/v5/spread/order/cancel-all", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitList<BybitOrderId>>(request, parameters, ct).ConfigureAwait(false);
            return result.As<BybitOrderId[]>(result.Data?.List);
        }

        #endregion

        #region Get Open Spread Orders

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitSpreadOrder>>> GetOpenSpreadOrdersAsync(string? symbol = null, string? baseAsset = null, string? orderId = null, string? clientOrderId = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("baseCoin", baseAsset);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("orderLinkId", clientOrderId);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v5/spread/order/realtime", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitResponse<BybitSpreadOrder>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Closed Spread Orders

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitClosedSpreadOrder>>> GetClosedSpreadOrdersAsync(string? symbol = null, string? baseAsset = null, string? orderId = null, string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("baseCoin", baseAsset);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v5/spread/order/history", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitResponse<BybitClosedSpreadOrder>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Spread User Trades

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitSpreadUserTrade>>> GetSpreadUserTradesAsync(string? symbol = null, string? orderId = null, string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v5/spread/execution/list", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitResponse<BybitSpreadUserTrade>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

    }
}
