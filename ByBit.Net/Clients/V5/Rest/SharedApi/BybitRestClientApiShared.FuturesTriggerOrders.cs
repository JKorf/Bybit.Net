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
        #region Place Futures Trigger Order

        async Task<ICallResult<SharedId>> IPlaceFuturesTriggerOrder.PlaceFuturesTriggerOrderAsync(PlaceFuturesTriggerOrderRequest request, CancellationToken ct)
            => await PlaceFuturesTriggerOrderAsync(request, ct).ConfigureAwait(false);

        public PlaceFuturesTriggerOrderOptions PlaceFuturesTriggerOrderOptions { get; } = new PlaceFuturesTriggerOrderOptions(_exchangeName, false)
        {
            RequiredRequestParameters = new List<ParameterDescription>
            {
                new ParameterDescription(nameof(PlaceFuturesTriggerOrderRequest.PositionMode), typeof(SharedPositionMode), "The position mode the account is in", SharedPositionMode.OneWay)
            }
        };

        public async Task<HttpResult<SharedId>> PlaceFuturesTriggerOrderAsync(PlaceFuturesTriggerOrderRequest request, CancellationToken ct)
        {
            var side = GetTriggerOrderSide(request);
            var validationError = PlaceFuturesTriggerOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var category = request.Symbol!.TradingMode.IsLinear() ? Category.Linear : Category.Inverse;
            var result = await _api.Trading.PlaceOrderAsync(
                category,
                request.Symbol!.GetSymbol(FormatSymbol),
                side,
                request.OrderPrice == null ? NewOrderType.Market : NewOrderType.Limit,
                quantity: request.Quantity?.QuantityInBaseAsset ?? request.Quantity?.QuantityInContracts ?? 0,
                price: request.OrderPrice,
                clientOrderId: request.ClientOrderId,
                triggerPrice: request.TriggerPrice,
                triggerDirection: request.PriceDirection == SharedTriggerPriceDirection.PriceAbove ? TriggerDirection.Rise: TriggerDirection.Fall,
                timeInForce: GetTimeInForce(request.OrderPrice == null ? SharedOrderType.Market : SharedOrderType.Limit, request.TimeInForce),
                positionIdx: request.PositionMode == SharedPositionMode.OneWay ? PositionIdx.OneWayMode : request.PositionSide == SharedPositionSide.Long ? PositionIdx.BuyHedgeMode : PositionIdx.SellHedgeMode,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedId>(result);

            // Return
            return HttpResult.Ok(result, new SharedId(result.Data.OrderId.ToString()));
        }

        #endregion

        #region Get Futures Trigger Order

        async Task<ICallResult<SharedFuturesTriggerOrder>> IGetFuturesTriggerOrder.GetFuturesTriggerOrderAsync(GetOrderRequest request, CancellationToken ct)
            => await GetFuturesTriggerOrderAsync(request, ct).ConfigureAwait(false);

        public GetFuturesTriggerOrderOptions GetFuturesTriggerOrderOptions { get; } = new GetFuturesTriggerOrderOptions(_exchangeName, true)
        {
        };
        public async Task<HttpResult<SharedFuturesTriggerOrder>> GetFuturesTriggerOrderAsync(GetOrderRequest request, CancellationToken ct)
        {
            var validationError = GetFuturesTriggerOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesTriggerOrder>(Exchange, validationError);

            var category = request.Symbol!.TradingMode.IsLinear() ? Category.Linear : Category.Inverse;
            var orders = await _api.Trading.GetOrdersAsync(category, orderId: request.OrderId, ct: ct).ConfigureAwait(false);
            if (!orders.Success)
                return HttpResult.Fail<SharedFuturesTriggerOrder>(orders);

            if (!orders.Data.List.Any())
                return HttpResult.Fail<SharedFuturesTriggerOrder>(Exchange, new ServerError(new ErrorInfo(ErrorType.UnknownOrder, "Order not found")));

            var order = orders.Data.List.Single();
            return HttpResult.Ok(orders, new SharedFuturesTriggerOrder(
                ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, order.Symbol),
                order.Symbol,
                order.OrderId.ToString(),
                ParseOrderType(order.OrderType),
                order.Side == OrderSide.Buy ? SharedTriggerOrderDirection.Enter : SharedTriggerOrderDirection.Exit,
                ParseTriggerOrderStatus(order),
                order.TriggerPrice ?? 0,
                order.PositionIdx == PositionIdx.BuyHedgeMode ? SharedPositionSide.Long : order.PositionIdx == PositionIdx.SellHedgeMode ? SharedPositionSide.Short : null,
                order.CreateTime)
            {
                PlacedOrderId = order.OrderId,
                OrderPrice = order.Price,
                OrderQuantity = new SharedOrderQuantity(order.Quantity, contractQuantity: order.Quantity),
                QuantityFilled = new SharedOrderQuantity(order.QuantityFilled, order.ValueFilled, order.QuantityFilled),
                UpdateTime = order.UpdateTime,
                TimeInForce = ParseTimeInForce(order.TimeInForce),
                FeeAsset = order.FeeAsset,
                Fee = order.ExecutedFee,
                AveragePrice = order.AveragePrice == 0 ? null : order.AveragePrice,
                PositionSide = order.PositionIdx == PositionIdx.OneWayMode ? null : order.PositionIdx == PositionIdx.BuyHedgeMode ? SharedPositionSide.Long : SharedPositionSide.Short,
                ClientOrderId = order.ClientOrderId
            });
        }

        #endregion

        #region Cancel Futures Trigger Order

        async Task<ICallResult<SharedId>> ICancelFuturesTriggerOrder.CancelFuturesTriggerOrderAsync(CancelOrderRequest request, CancellationToken ct)
            => await CancelFuturesTriggerOrderAsync(request, ct).ConfigureAwait(false);

        public CancelFuturesTriggerOrderOptions CancelFuturesTriggerOrderOptions { get; } = new CancelFuturesTriggerOrderOptions(_exchangeName, true);
        public async Task<HttpResult<SharedId>> CancelFuturesTriggerOrderAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var validationError = CancelFuturesTriggerOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var category = request.Symbol!.TradingMode.IsLinear() ? Category.Linear : Category.Inverse;
            var order = await _api.Trading.CancelOrderAsync(
                category,
                request.Symbol!.GetSymbol(FormatSymbol),
                request.OrderId,
                ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return HttpResult.Fail<SharedId>(order);

            return HttpResult.Ok(order, new SharedId(request.OrderId));
        }

        #endregion

        private OrderSide GetTriggerOrderSide(PlaceFuturesTriggerOrderRequest request)
        {
            if (request.PositionSide == SharedPositionSide.Long)
                return request.OrderDirection == SharedTriggerOrderDirection.Enter ? OrderSide.Buy : OrderSide.Sell;

            return request.OrderDirection == SharedTriggerOrderDirection.Enter ? OrderSide.Sell : OrderSide.Buy;
        }
    }
}
