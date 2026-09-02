using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.V5;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.V5
{
    internal partial class BybitSocketClientPrivateSharedApi
    {
        #region Spot Order client

        async Task<WebSocketResult<UpdateSubscription>> ISpotOrderSocketClient.SubscribeToSpotOrderUpdatesAsync(SubscribeSpotOrderRequest request, Action<DataEvent<SharedSpotOrder[]>> handler, CancellationToken ct)
            => await SubscribeToSpotOrderUpdatesAsync(request, x => handler(x.ToType<SharedSpotOrder[]>(x.Data)), ct).ConfigureAwait(false);

        public SubscribeSpotOrderOptions SubscribeSpotOrderOptions { get; } = new SubscribeSpotOrderOptions(_exchangeName, false);
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToSpotOrderUpdatesAsync(SubscribeSpotOrderRequest request, Action<DataEvent<SharedSpotOrderUpdate[]>> handler, CancellationToken ct)
        {
            var validationError = SubscribeSpotOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return WebSocketResult.Fail<UpdateSubscription>(_exchangeName, validationError);

            var result = await _api.SubscribeToOrderUpdatesAsync(
                update => {
                    var data = update.Data.Where(x => x.Category == Category.Spot);
                    if (!data.Any())
                        return;

                    handler(update.ToType<SharedSpotOrderUpdate[]>(data.Select(x =>
                        new SharedSpotOrderUpdate(
                            ExchangeSymbolCache.ParseSymbol(_topicSpotId, _api.EnvironmentName, null, x.Symbol),
                            x.Symbol,
                            x.OrderId.ToString(),
                            x.OrderType == Enums.OrderType.Limit ? SharedOrderType.Limit : x.OrderType == Enums.OrderType.Market ? SharedOrderType.Market : SharedOrderType.Other,
                            x.Side == Enums.OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                            ParseOrderStatus(x.Status),
                            x.CreateTime)
                        {
                            ClientOrderId = x.ClientOrderId?.ToString(),
                            OrderQuantity = new SharedOrderQuantity(x.MarketUnit == MarketUnit.QuoteAsset ? null : x.Quantity, x.MarketUnit == MarketUnit.QuoteAsset ? x.Quantity : null),
                            QuantityFilled = new SharedOrderQuantity(x.QuantityFilled, x.ValueFilled),
                            TimeInForce = x.TimeInForce == Enums.TimeInForce.ImmediateOrCancel ? SharedTimeInForce.ImmediateOrCancel : x.TimeInForce == Enums.TimeInForce.FillOrKill ? SharedTimeInForce.FillOrKill : x.TimeInForce == Enums.TimeInForce.GoodTillCanceled ? SharedTimeInForce.GoodTillCanceled : null,
                            UpdateTime = x.UpdateTime,
                            AveragePrice = x.AveragePrice,
                            OrderPrice = x.Price == 0 ? null : x.Price,
#pragma warning disable CS0618 // Type or member is obsolete
                            Fee = x.ExecutedFee,
                            FeeAsset = x.FeeAsset,
#pragma warning restore CS0618 // Type or member is obsolete
                            TriggerPrice = x.TriggerPrice,
                            IsTriggerOrder = x.TriggerPrice != null
                        }
                    ).ToArray()));
                },
                ct: ct).ConfigureAwait(false);

            return result;
        }

        private SharedOrderStatus ParseOrderStatus(OrderStatus status)
        {
            if (status == OrderStatus.Active
                || status == OrderStatus.PartiallyFilled
                || status == OrderStatus.Created
                || status == OrderStatus.New
                || status == OrderStatus.Untriggered)
            {
                return SharedOrderStatus.Open;
            }

            if (status == OrderStatus.Cancelled
                || status == OrderStatus.PartiallyFilledCanceled
                || status == OrderStatus.Deactivated
                || status == OrderStatus.Rejected)
            {
                return SharedOrderStatus.Canceled;
            }

            if (status == OrderStatus.Filled)
                return SharedOrderStatus.Filled;

            return SharedOrderStatus.Unknown;
        }
        #endregion

        #region Spot Order client

        public SharedFeeDeductionType SpotFeeDeductionType => SharedFeeDeductionType.DeductFromOutput;
        public SharedFeeAssetType SpotFeeAssetType => SharedFeeAssetType.OutputAsset;
        public SharedOrderType[] SpotSupportedOrderTypes { get; } = new[] { SharedOrderType.Limit, SharedOrderType.Market };
        public SharedTimeInForce[] SpotSupportedTimeInForce { get; } = new[] { SharedTimeInForce.GoodTillCanceled, SharedTimeInForce.ImmediateOrCancel, SharedTimeInForce.FillOrKill };
        public SharedQuantitySupport SpotSupportedOrderQuantity { get; } = new SharedQuantitySupport(
                SharedQuantityType.BaseAsset,
                SharedQuantityType.BaseAsset,
                SharedQuantityType.BaseAndQuoteAsset,
                SharedQuantityType.BaseAndQuoteAsset);

        public string GenerateClientOrderId() => ExchangeHelpers.RandomString(32);

        async Task<ICallResult<SharedId>> IPlaceSpotOrder.PlaceSpotOrderAsync(PlaceSpotOrderRequest request, CancellationToken ct)
            => await PlaceSpotOrderAsync(request, ct).ConfigureAwait(false);

        PlaceSpotOrderOptions IPlaceSpotOrder.PlaceSpotOrderOptions
            => PlaceSpotOrderOptions;

        public PlaceSpotOrderSocketOptions PlaceSpotOrderOptions { get; } = new PlaceSpotOrderSocketOptions(_exchangeName);
        public async Task<QueryResult<SharedId>> PlaceSpotOrderAsync(PlaceSpotOrderRequest request, CancellationToken ct)
        {
            var validationError = PlaceSpotOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return QueryResult.Fail<SharedId>(Exchange, validationError);

            var result = await _api.PlaceOrderAsync(
                Category.Spot,
                request.Symbol!.GetSymbol(FormatSymbol),
                request.Side == SharedOrderSide.Buy ? OrderSide.Buy : OrderSide.Sell,
                request.OrderType == SharedOrderType.Market ? NewOrderType.Market : NewOrderType.Limit,
                quantity: request.Quantity?.QuantityInBaseAsset ?? request.Quantity?.QuantityInQuoteAsset ?? 0,
                price: request.Price,
                clientOrderId: request.ClientOrderId,
                timeInForce: GetTimeInForce(request.OrderType, request.TimeInForce),
                marketUnit: request.Quantity?.QuantityInBaseAsset != null ? MarketUnit.BaseAsset : MarketUnit.QuoteAsset,
                ct: ct).ConfigureAwait(false);

            if (!result.Success)
                return QueryResult.Fail<SharedId>(result);

            return QueryResult.Ok(result, new SharedId(result.Data.OrderId));
        }

        public CancelSpotOrderSocketOptions CancelSpotOrderOptions { get; } = new CancelSpotOrderSocketOptions(_exchangeName, true);
        public async Task<QueryResult<SharedId>> CancelSpotOrderAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var validationError = CancelSpotOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return QueryResult.Fail<SharedId>(Exchange, validationError);

            var order = await _api.CancelOrderAsync(Category.Spot, request.Symbol!.GetSymbol(FormatSymbol), request.OrderId, ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return QueryResult.Fail<SharedId>(order);

            return QueryResult.Ok(order, new SharedId(order.Data.OrderId));
        }

        private TimeInForce? GetTimeInForce(SharedOrderType type, SharedTimeInForce? tif)
        {
            if (type == SharedOrderType.LimitMaker) return TimeInForce.PostOnly;
            if (type == SharedOrderType.Market) return null;
            if (tif == SharedTimeInForce.ImmediateOrCancel) return TimeInForce.ImmediateOrCancel;
            if (tif == SharedTimeInForce.FillOrKill) return TimeInForce.FillOrKill;
            if (tif == SharedTimeInForce.GoodTillCanceled) return TimeInForce.GoodTillCanceled;

            return null;
        }

        #endregion
    }
}
