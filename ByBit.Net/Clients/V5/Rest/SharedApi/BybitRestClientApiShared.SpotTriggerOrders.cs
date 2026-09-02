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
        #region Spot Trigger Order Client
        public PlaceSpotTriggerOrderOptions PlaceSpotTriggerOrderOptions { get; } = new PlaceSpotTriggerOrderOptions(_exchangeName, false);

        public async Task<HttpResult<SharedId>> PlaceSpotTriggerOrderAsync(PlaceSpotTriggerOrderRequest request, CancellationToken ct)
        {
            var validationError = PlaceSpotTriggerOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var result = await _api.Trading.PlaceOrderAsync(
                Category.Spot,
                request.Symbol!.GetSymbol(FormatSymbol),
                request.OrderSide == SharedOrderSide.Buy ? OrderSide.Buy : OrderSide.Sell,
                request.OrderPrice == null ? NewOrderType.Market : NewOrderType.Limit,
                quantity: request.Quantity?.QuantityInBaseAsset ?? request.Quantity?.QuantityInQuoteAsset ?? 0,
                price: request.OrderPrice,
                clientOrderId: request.ClientOrderId,
                triggerPrice: request.TriggerPrice,
                orderFilter: OrderFilter.StopOrder,
                timeInForce: GetTimeInForce(request.OrderPrice == null ? SharedOrderType.Market : SharedOrderType.Limit, request.TimeInForce),
                marketUnit: request.Quantity?.QuantityInBaseAsset != null ? MarketUnit.BaseAsset : MarketUnit.QuoteAsset,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedId>(result);

            // Return
            return HttpResult.Ok(result, new SharedId(result.Data.OrderId.ToString()));
        }

        public GetSpotTriggerOrderOptions GetSpotTriggerOrderOptions { get; } = new GetSpotTriggerOrderOptions(_exchangeName, true)
        {
        };
        public async Task<HttpResult<SharedSpotTriggerOrder>> GetSpotTriggerOrderAsync(GetOrderRequest request, CancellationToken ct)
        {
            var validationError = GetSpotTriggerOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedSpotTriggerOrder>(Exchange, validationError);

            var orders = await _api.Trading.GetOrdersAsync(Category.Spot, orderId: request.OrderId, ct: ct).ConfigureAwait(false);
            if (!orders.Success)
                return HttpResult.Fail<SharedSpotTriggerOrder>(orders);

            if (!orders.Data.List.Any())
                return HttpResult.Fail<SharedSpotTriggerOrder>(Exchange, new ServerError(new ErrorInfo(ErrorType.UnknownOrder, "Order not found")));

            var order = orders.Data.List.Single();
            return HttpResult.Ok(orders, new SharedSpotTriggerOrder(
                ExchangeSymbolCache.ParseSymbol(_topicSpotId, _api.EnvironmentName, null, order.Symbol),
                order.Symbol,
                order.OrderId.ToString(),
                ParseOrderType(order.OrderType),
                order.Side == OrderSide.Buy ? SharedTriggerOrderDirection.Enter: SharedTriggerOrderDirection.Exit,
                ParseTriggerOrderStatus(order),
                order.TriggerPrice ?? 0,
                order.CreateTime)
            {
                PlacedOrderId = order.OrderId,
                OrderPrice = order.Price,
                OrderQuantity = new SharedOrderQuantity(order.MarketUnit == null || order.MarketUnit == MarketUnit.BaseAsset ? order.Quantity : null, order.MarketUnit == MarketUnit.QuoteAsset ? order.Quantity : null),
                QuantityFilled = new SharedOrderQuantity(order.QuantityFilled, order.ValueFilled),
                UpdateTime = order.UpdateTime,
                TimeInForce = ParseTimeInForce(order.TimeInForce),
                FeeAsset = order.FeeAsset,
                Fee = order.ExecutedFee,
                AveragePrice = order.AveragePrice == 0 ? null : order.AveragePrice,
                ClientOrderId = order.ClientOrderId
            });
        }

        public CancelSpotTriggerOrderOptions CancelSpotTriggerOrderOptions { get; } = new CancelSpotTriggerOrderOptions(_exchangeName, true);
        public async Task<HttpResult<SharedId>> CancelSpotTriggerOrderAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var validationError = CancelSpotTriggerOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var order = await _api.Trading.CancelOrderAsync(
                Category.Spot,
                request.Symbol!.GetSymbol(FormatSymbol),
                request.OrderId,
                ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return HttpResult.Fail<SharedId>(order);

            return HttpResult.Ok(order, new SharedId(request.OrderId));
        }

        private SharedTriggerOrderStatus ParseTriggerOrderStatus(BybitOrder order)
        {
            if (order.Status == OrderStatus.Filled)
                return SharedTriggerOrderStatus.Filled;

            if (order.Status == OrderStatus.Cancelled ||
                order.Status == OrderStatus.Rejected ||
                order.Status == OrderStatus.Deactivated ||
                order.Status == OrderStatus.PartiallyFilledCanceled)
            {
                return SharedTriggerOrderStatus.CanceledOrRejected;
            }

            if (order.Status == OrderStatus.Active
                || order.Status == OrderStatus.Created
                || order.Status == OrderStatus.PartiallyFilled
                || order.Status == OrderStatus.New
                || order.Status == OrderStatus.Untriggered)
            {
                return SharedTriggerOrderStatus.Active;
            }

            if (order.Status == OrderStatus.Triggered)
                return SharedTriggerOrderStatus.Triggered;

            return SharedTriggerOrderStatus.Unknown;
        }

        #endregion
    }
}
