using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.SharedApis;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Bybit.Net.Clients.V5
{
    internal partial class BybitRestClientSharedApi
    {
        #region Futures Order Client

        public SharedFeeDeductionType FuturesFeeDeductionType => SharedFeeDeductionType.AddToCost;
        public SharedFeeAssetType FuturesFeeAssetType => SharedFeeAssetType.InputAsset;
        public SharedOrderType[] FuturesSupportedOrderTypes { get; } = new[] { SharedOrderType.Limit, SharedOrderType.Market };
        public SharedTimeInForce[] FuturesSupportedTimeInForce { get; } = new[] { SharedTimeInForce.GoodTillCanceled, SharedTimeInForce.ImmediateOrCancel, SharedTimeInForce.FillOrKill };
        public SharedQuantitySupport FuturesSupportedOrderQuantity { get; } = new SharedQuantitySupport(
                SharedQuantityType.BaseAsset,
                SharedQuantityType.BaseAsset,
                SharedQuantityType.BaseAsset,
                SharedQuantityType.BaseAsset);

        public PlaceFuturesOrderOptions PlaceFuturesOrderOptions { get; } = new PlaceFuturesOrderOptions(_exchangeName, true);
        public async Task<HttpResult<SharedId>> PlaceFuturesOrderAsync(PlaceFuturesOrderRequest request, CancellationToken ct)
        {
            var validationError = PlaceFuturesOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var category = request.Symbol!.TradingMode.IsLinear() ? Category.Linear : Category.Inverse;
            var result = await _api.Trading.PlaceOrderAsync(
                category,
                request.Symbol!.GetSymbol(FormatSymbol),
                request.Side == SharedOrderSide.Buy ? OrderSide.Buy : OrderSide.Sell,
                request.OrderType == SharedOrderType.Limit ? NewOrderType.Limit : NewOrderType.Market,
                quantity: request.Quantity?.QuantityInBaseAsset ?? request.Quantity?.QuantityInContracts ?? 0,
                price: request.Price,
                positionIdx: request.PositionSide == null ? PositionIdx.OneWayMode: request.PositionSide == SharedPositionSide.Long ? PositionIdx.BuyHedgeMode : PositionIdx.SellHedgeMode,
                reduceOnly: request.ReduceOnly,
                timeInForce: GetTimeInForce(request.OrderType, request.TimeInForce),
                clientOrderId: request.ClientOrderId,
                stopLoss: request.StopLossPrice,
                takeProfit: request.TakeProfitPrice,
                ct: ct).ConfigureAwait(false);

            if (!result.Success)
                return HttpResult.Fail<SharedId>(result);

            return HttpResult.Ok(result, new SharedId(result.Data.OrderId.ToString()));
        }

        public GetFuturesOrderOptions GetFuturesOrderOptions { get; } = new GetFuturesOrderOptions(_exchangeName, true);
        public async Task<HttpResult<SharedFuturesOrder>> GetFuturesOrderAsync(GetOrderRequest request, CancellationToken ct)
        {
            var validationError = GetFuturesOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesOrder>(Exchange, validationError);

            var category = (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var orders = await _api.Trading.GetOrdersAsync(category, symbol: request.Symbol!.GetSymbol(FormatSymbol), orderId: request.OrderId, ct: ct).ConfigureAwait(false);
            if (!orders.Success)
                return HttpResult.Fail<SharedFuturesOrder>(orders);

            var order = orders.Data.List.SingleOrDefault();
            if (order == null)
                return HttpResult.Fail<SharedFuturesOrder>(orders, new ServerError(new ErrorInfo(ErrorType.UnknownOrder, "Order not found")));

            return HttpResult.Ok(orders, new SharedFuturesOrder(
                ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, order.Symbol),
                order.Symbol,
                order.OrderId.ToString(),
                ParseOrderType(order.OrderType),
                order.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                ParseOrderStatus(order.Status),
                order.CreateTime)
            {
                ClientOrderId = order.ClientOrderId,
                AveragePrice = order.AveragePrice == 0 ? null : order.AveragePrice,
                OrderPrice = order.Price,
                OrderQuantity = new SharedOrderQuantity(order.Quantity, contractQuantity: order.Quantity),
                QuantityFilled = new SharedOrderQuantity(order.QuantityFilled, order.ValueFilled, order.QuantityFilled),
                TimeInForce = ParseTimeInForce(order.TimeInForce),
                UpdateTime = order.UpdateTime,
                PositionSide = order.PositionIdx == PositionIdx.OneWayMode ? null : order.PositionIdx == Enums.PositionIdx.BuyHedgeMode ? SharedPositionSide.Long : SharedPositionSide.Short,
                ReduceOnly = order.ReduceOnly,
#pragma warning disable CS0618 // Type or member is obsolete
                Fee = order.ExecutedFee,
                FeeAsset = order.FeeAsset,
#pragma warning restore CS0618 // Type or member is obsolete
                TriggerPrice = order.TriggerPrice,
                StopLossPrice = order.StopLoss,
                TakeProfitPrice = order.TakeProfit,
                IsTriggerOrder = order.TriggerPrice > 0
            });
        }

        public GetOpenFuturesOrdersOptions GetOpenFuturesOrdersOptions { get; } = new GetOpenFuturesOrdersOptions(_exchangeName, true)
        {
            OptionalExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription(["SettleAsset", "settleCoin"], typeof(string), "Settlement asset filter", "USDT")
            }
        };
        public async Task<HttpResult<SharedFuturesOrder[]>> GetOpenFuturesOrdersAsync(GetOpenOrdersRequest request, CancellationToken ct)
        {
            var validationError = GetOpenFuturesOrdersOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesOrder[]>(Exchange, validationError);

            var tradingMode = request.Symbol?.TradingMode ?? request.TradingMode ?? TradingMode.PerpetualLinear;
            var category = (tradingMode == TradingMode.PerpetualLinear || tradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;

            var symbol = request.Symbol?.GetSymbol(FormatSymbol);
            if (symbol == null && request.GetParamValue<string?>(Exchange, "SettleAsset", "settleCoin") == null)
                return HttpResult.Fail<SharedFuturesOrder[]>(Exchange, ArgumentError.Invalid("SettleAsset", "Either the Symbol request parameter or the SettleAsset exchange parameter is required"));

            var orders = await _api.Trading.GetOrdersAsync(
                category,
                symbol,
                openOnly: 0, 
                settleAsset: symbol != null ? null : request.GetParamValue<string?>(Exchange, "SettleAsset", "settleCoin"),
                ct: ct
                ).ConfigureAwait(false);
            if (!orders.Success)
                return HttpResult.Fail<SharedFuturesOrder[]>(orders);

            return HttpResult.Ok(orders, orders.Data.List.Select(x => new SharedFuturesOrder(
                ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, x.Symbol), 
                x.Symbol,
                x.OrderId.ToString(),
                ParseOrderType(x.OrderType),
                x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                ParseOrderStatus(x.Status),
                x.CreateTime)
            {
                ClientOrderId = x.ClientOrderId,
                AveragePrice = x.AveragePrice == 0 ? null : x.AveragePrice,
                OrderPrice = x.Price,
                OrderQuantity = new SharedOrderQuantity(x.Quantity, contractQuantity: x.Quantity),
                QuantityFilled = new SharedOrderQuantity(x.QuantityFilled, x.ValueFilled, x.QuantityFilled),
                TimeInForce = ParseTimeInForce(x.TimeInForce),
                UpdateTime = x.UpdateTime,
                PositionSide = x.PositionIdx == PositionIdx.OneWayMode ? null : x.PositionIdx == Enums.PositionIdx.BuyHedgeMode ? SharedPositionSide.Long : SharedPositionSide.Short,
                ReduceOnly = x.ReduceOnly,
#pragma warning disable CS0618 // Type or member is obsolete
                Fee = x.ExecutedFee,
                FeeAsset = x.FeeAsset,
#pragma warning restore CS0618 // Type or member is obsolete
                TriggerPrice = x.TriggerPrice,
                StopLossPrice = x.StopLoss,
                TakeProfitPrice = x.TakeProfit,
                IsTriggerOrder = x.TriggerPrice > 0
            }).ToArray());
        }

        public GetFuturesClosedOrdersOptions GetClosedFuturesOrdersOptions { get; } = new GetFuturesClosedOrdersOptions(_exchangeName, false, true, true, 50);
        public async Task<HttpResult<SharedFuturesOrder[]>> GetClosedFuturesOrdersAsync(GetClosedOrdersRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var validationError = GetClosedFuturesOrdersOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesOrder[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var limit = request.Limit ?? 50;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest, true, TimeSpan.FromDays(7));

            // Get data
            var category = (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var result = await _api.Trading.GetOrderHistoryAsync(
                category,
                request.Symbol!.GetSymbol(FormatSymbol),
                startTime: pageParams.StartTime,
                endTime: pageParams.EndTime,
                limit: limit,
                cursor: pageParams.Cursor,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedFuturesOrder[]>(result);

            var nextPageRequest = Pagination.GetNextPageRequest(
               () => result.Data.NextPageCursor == null ? null : Pagination.NextPageFromCursor(result.Data.NextPageCursor),
               result.Data.List.Length,
               result.Data.List.Select(x => x.CreateTime),
               request.StartTime,
               request.EndTime ?? DateTime.UtcNow,
               pageParams,
               TimeSpan.FromDays(7));

            return HttpResult.Ok(result, ExchangeHelpers.ApplyFilter(result.Data.List, x => x.CreateTime, request.StartTime, request.EndTime, direction)
                       .Select(x => 
                            new SharedFuturesOrder(
                                ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, x.Symbol), 
                                x.Symbol,
                                x.OrderId.ToString(),
                                ParseOrderType(x.OrderType),
                                x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                                ParseOrderStatus(x.Status),
                                x.CreateTime)
                            {
                                ClientOrderId = x.ClientOrderId,
                                AveragePrice = x.AveragePrice == 0 ? null : x.AveragePrice,
                                OrderPrice = x.Price,
                                OrderQuantity = new SharedOrderQuantity(x.Quantity, contractQuantity: x.Quantity),
                                QuantityFilled = new SharedOrderQuantity(x.QuantityFilled, x.ValueFilled, x.QuantityFilled),
                                TimeInForce = ParseTimeInForce(x.TimeInForce),
                                UpdateTime = x.UpdateTime,
                                PositionSide = x.PositionIdx == PositionIdx.OneWayMode ? null : x.PositionIdx == Enums.PositionIdx.BuyHedgeMode ? SharedPositionSide.Long : SharedPositionSide.Short,
                                ReduceOnly = x.ReduceOnly,
#pragma warning disable CS0618 // Type or member is obsolete
                                Fee = x.ExecutedFee,
                                FeeAsset = x.FeeAsset,
#pragma warning restore CS0618 // Type or member is obsolete
                                TriggerPrice = x.TriggerPrice,
                                StopLossPrice = x.StopLoss,
                                TakeProfitPrice = x.TakeProfit,
                                IsTriggerOrder = x.TriggerPrice > 0
                            })
                       .ToArray(), nextPageRequest);
        }

        public GetFuturesOrderTradesOptions GetFuturesOrderTradesOptions { get; } = new GetFuturesOrderTradesOptions(_exchangeName, true);
        public async Task<HttpResult<SharedUserTrade[]>> GetFuturesOrderTradesAsync(GetOrderTradesRequest request, CancellationToken ct)
        {
            var validationError = GetFuturesOrderTradesOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedUserTrade[]>(Exchange, validationError);

            var category = (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var orders = await _api.Trading.GetUserTradesAsync(category, orderId: request.OrderId, ct: ct).ConfigureAwait(false);
            if (!orders.Success)
                return HttpResult.Fail<SharedUserTrade[]>(orders);

            return HttpResult.Ok(orders, orders.Data.List.Select(x => new SharedUserTrade(
                ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, x.Symbol), 
                x.Symbol,
                x.OrderId.ToString(),
                x.TradeId,
                x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                new SharedOrderQuantity(x.Quantity),
                x.Price,
                x.Timestamp)
            {
                ClientOrderId = x.ClientOrderId,
                Fee = x.Fee,
                FeeAsset = x.FeeAsset,
                Role = x.IsMaker ? SharedRole.Maker : SharedRole.Taker
            }).ToArray());
        }

        Task<HttpResult<SharedUserTrade[]>> IFuturesOrderRestClient.GetFuturesUserTradesAsync(GetUserTradesRequest request, PageRequest? nextPageToken, CancellationToken ct)
            => GetFuturesUserTradeHistoryAsync(request, nextPageToken, ct);
        GetFuturesUserTradeHistoryOptions IFuturesOrderRestClient.GetFuturesUserTradesOptions => GetFuturesUserTradeHistoryOptions;

        public GetFuturesUserTradeHistoryOptions GetFuturesUserTradeHistoryOptions { get; } = new GetFuturesUserTradeHistoryOptions(_exchangeName, false, true, true, 50);
        public async Task<HttpResult<SharedUserTrade[]>> GetFuturesUserTradeHistoryAsync(GetUserTradesRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var validationError = GetFuturesUserTradeHistoryOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedUserTrade[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var limit = request.Limit ?? 50;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest, true, TimeSpan.FromDays(7));

            // Get data
            var category = (request.Symbol == null || request.Symbol.TradingMode == TradingMode.PerpetualLinear || request.Symbol.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var result = await _api.Trading.GetUserTradesAsync(
                category,
                symbol: request.Symbol?.GetSymbol(FormatSymbol),
                startTime: pageParams.StartTime,
                endTime: pageParams.EndTime,
                limit: limit,
                cursor: pageParams.Cursor,
                ct: ct
                ).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedUserTrade[]>(result);

            var nextPageRequest = Pagination.GetNextPageRequest(
                () => result.Data.NextPageCursor == null ? null : Pagination.NextPageFromCursor(result.Data.NextPageCursor),
                result.Data.List.Length,
                result.Data.List.Select(x => x.Timestamp),
                request.StartTime,
                request.EndTime ?? DateTime.UtcNow,
                pageParams,
                TimeSpan.FromDays(7));

            return HttpResult.Ok(result, ExchangeHelpers.ApplyFilter(result.Data.List, x => x.Timestamp, request.StartTime, request.EndTime, direction)
                       .Select(x => 
                            new SharedUserTrade(
                                ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, x.Symbol), 
                                x.Symbol,
                                x.OrderId.ToString(),
                                x.TradeId,
                                x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                                new SharedOrderQuantity(x.Quantity),
                                x.Price,
                                x.Timestamp)
                            {
                                ClientOrderId = x.ClientOrderId,
                                Fee = x.Fee,
                                FeeAsset = x.FeeAsset,
                                Role = x.IsMaker ? SharedRole.Maker : SharedRole.Taker
                            })
                       .ToArray(), nextPageRequest);
        }

        public CancelFuturesOrderOptions CancelFuturesOrderOptions { get; } = new CancelFuturesOrderOptions(_exchangeName, true);
        public async Task<HttpResult<SharedId>> CancelFuturesOrderAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var validationError = CancelFuturesOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var category = (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var order = await _api.Trading.CancelOrderAsync(category, request.Symbol!.GetSymbol(FormatSymbol), request.OrderId, ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return HttpResult.Fail<SharedId>(order);

            return HttpResult.Ok(order, new SharedId(order.Data.OrderId.ToString()));
        }

        public GetPositionsOptions GetPositionsOptions { get; } = new GetPositionsOptions(_exchangeName, true)
        {
            OptionalExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription(["SettleAsset", "settleCoin"], typeof(string), "Settlement asset filter", "USDT")
            }
        };
        public async Task<HttpResult<SharedPosition[]>> GetPositionsAsync(GetPositionsRequest request, CancellationToken ct)
        {
            var validationError = GetPositionsOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedPosition[]>(Exchange, validationError);

            var tradingMode = request.Symbol?.TradingMode ?? request.TradingMode ?? TradingMode.PerpetualLinear;
            var category = (tradingMode == TradingMode.PerpetualLinear || tradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;

            var settleAsset = request.GetParamValue<string?>(Exchange, "SettleAsset", "settleCoin");
            var symbol = request.Symbol?.GetSymbol(FormatSymbol);
            if (symbol == null
                && settleAsset == null
                && category == Category.Linear)
            {
                return HttpResult.Fail<SharedPosition[]>(Exchange, ArgumentError.Invalid("SettleAsset", "Either the Symbol request parameter or the SettleAsset exchange parameter is required for linear positions"));
            }

            var result = await _api.Trading.GetPositionsAsync(
                category,
                symbol: symbol,
                settleAsset: symbol != null ? null : settleAsset,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedPosition[]>(result);

            return HttpResult.Ok(result, result.Data.List.Select(x => 
                new SharedPosition(
                    ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, x.Symbol),
                    x.Symbol,
                    new SharedOrderQuantity(x.Quantity), 
                    x.UpdateTime)
                {
                    UnrealizedPnl = x.UnrealizedPnl,
                    LiquidationPrice = x.LiquidationPrice,
                    AverageOpenPrice = x.AveragePrice,
                    Leverage = x.Leverage,
                    StopLossPrice = x.StopLoss,
                    TakeProfitPrice = x.TakeProfit,
                    PositionMode = x.PositionIdx == PositionIdx.OneWayMode ? SharedPositionMode.OneWay : SharedPositionMode.HedgeMode,
                    PositionSide = x.Side == PositionSide.None ? SharedPositionSide.Long : x.Side == PositionSide.Sell ? SharedPositionSide.Short : SharedPositionSide.Long
                }).ToArray());
        }

        public ClosePositionOptions ClosePositionOptions { get; } = new ClosePositionOptions(_exchangeName, true)
        {
            RequiredRequestParameters = new List<ParameterDescription>
            {
                new ParameterDescription(nameof(ClosePositionRequest.PositionSide), typeof(SharedPositionSide), "Side of position to close", SharedPositionSide.Long),
                new ParameterDescription(nameof(ClosePositionRequest.Quantity), typeof(decimal), "Quantity of position to close", 1m)
            }
        };
        public async Task<HttpResult<SharedId>> ClosePositionAsync(ClosePositionRequest request, CancellationToken ct)
        {
            var validationError = ClosePositionOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var category = (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var symbol = request.Symbol!.GetSymbol(FormatSymbol);

            var result = await _api.Trading.PlaceOrderAsync(
                category,
                symbol,
                request.PositionSide == SharedPositionSide.Short ? OrderSide.Buy : OrderSide.Sell,
                NewOrderType.Market,
                request.Quantity!.Value,
                positionIdx: request.PositionMode == SharedPositionMode.OneWay ? PositionIdx.OneWayMode : request.PositionSide == SharedPositionSide.Long ? PositionIdx.BuyHedgeMode : PositionIdx.SellHedgeMode,
                reduceOnly: true,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedId>(result);

            return HttpResult.Ok(result, new SharedId(result.Data.OrderId.ToString()));
        }
        #endregion

        #region Futures Client Id Order Client

        public GetFuturesOrderByClientOrderIdOptions GetFuturesOrderByClientOrderIdOptions { get; } = new GetFuturesOrderByClientOrderIdOptions(_exchangeName, true);
        public async Task<HttpResult<SharedFuturesOrder>> GetFuturesOrderByClientOrderIdAsync(GetOrderRequest request, CancellationToken ct)
        {
            var validationError = GetFuturesOrderByClientOrderIdOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesOrder>(Exchange, validationError);

            var category = (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var orders = await _api.Trading.GetOrdersAsync(category, clientOrderId: request.OrderId, ct: ct).ConfigureAwait(false);
            if (!orders.Success)
                return HttpResult.Fail<SharedFuturesOrder>(orders);

            if (!orders.Data.List.Any())
                return HttpResult.Fail<SharedFuturesOrder>(Exchange, new ServerError(new ErrorInfo(ErrorType.UnknownOrder, "Order not found")));

            var order = orders.Data.List.Single();
            return HttpResult.Ok(orders, new SharedFuturesOrder(
                ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, order.Symbol),
                order.Symbol,
                order.OrderId.ToString(),
                ParseOrderType(order.OrderType),
                order.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                ParseOrderStatus(order.Status),
                order.CreateTime)
            {
                ClientOrderId = order.ClientOrderId,
                AveragePrice = order.AveragePrice == 0 ? null : order.AveragePrice,
                OrderPrice = order.Price,
                OrderQuantity = new SharedOrderQuantity(order.Quantity, contractQuantity: order.Quantity),
                QuantityFilled = new SharedOrderQuantity(order.QuantityFilled, order.ValueFilled, order.QuantityFilled),
                TimeInForce = ParseTimeInForce(order.TimeInForce),
                UpdateTime = order.UpdateTime,
                PositionSide = order.PositionIdx == PositionIdx.OneWayMode ? null : order.PositionIdx == Enums.PositionIdx.BuyHedgeMode ? SharedPositionSide.Long : SharedPositionSide.Short,
                ReduceOnly = order.ReduceOnly,
#pragma warning disable CS0618 // Type or member is obsolete
                Fee = order.ExecutedFee,
                FeeAsset = order.FeeAsset,
#pragma warning restore CS0618 // Type or member is obsolete
                TriggerPrice = order.TriggerPrice,
                StopLossPrice = order.StopLoss,
                TakeProfitPrice = order.TakeProfit,
                IsTriggerOrder = order.TriggerPrice > 0
            });
        }

        public CancelFuturesOrderByClientOrderIdOptions CancelFuturesOrderByClientOrderIdOptions { get; } = new CancelFuturesOrderByClientOrderIdOptions(_exchangeName, true);
        public async Task<HttpResult<SharedId>> CancelFuturesOrderByClientOrderIdAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var validationError = CancelFuturesOrderByClientOrderIdOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var category = (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var order = await _api.Trading.CancelOrderAsync(category, request.Symbol!.GetSymbol(FormatSymbol), clientOrderId: request.OrderId, ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return HttpResult.Fail<SharedId>(order);

            return HttpResult.Ok(order, new SharedId(order.Data.OrderId.ToString()));
        }
        #endregion
    }
}
