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
        #region Futures Order client

        async Task<WebSocketResult<UpdateSubscription>> IFuturesOrderSocketClient.SubscribeToFuturesOrderUpdatesAsync(SubscribeFuturesOrderRequest request, Action<DataEvent<SharedFuturesOrder[]>> handler, CancellationToken ct)
            => await SubscribeToFuturesOrderUpdatesAsync(request, x => handler(x.ToType<SharedFuturesOrder[]>(x.Data)), ct).ConfigureAwait(false);

        public SubscribeFuturesOrderOptions SubscribeFuturesOrderOptions { get; } = new SubscribeFuturesOrderOptions(_exchangeName, false);
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToFuturesOrderUpdatesAsync(SubscribeFuturesOrderRequest request, Action<DataEvent<SharedFuturesOrderUpdate[]>> handler, CancellationToken ct)
        {
            var validationError = SubscribeFuturesOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return WebSocketResult.Fail<UpdateSubscription>(_exchangeName, validationError);

            var category = request.TradingMode?.IsLinear() == true ? Category.Linear : Category.Inverse;
            var result = await _api.SubscribeToOrderUpdatesAsync(
                update =>
                {
                    var data = update.Data.Where(x => x.Category != Category.Spot);
                    if (request.TradingMode != null)
                        data = data.Where(x => x.Category == category);

                    if (!data.Any())
                        return;

                    handler(update.ToType<SharedFuturesOrderUpdate[]>(data.Select(x =>
                        new SharedFuturesOrderUpdate(
                            ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, x.Symbol),
                            x.Symbol,
                            x.OrderId.ToString(),
                            x.OrderType == Enums.OrderType.Limit ? SharedOrderType.Limit : x.OrderType == Enums.OrderType.Market ? SharedOrderType.Market : SharedOrderType.Other,
                            x.Side == Enums.OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                            ParseOrderStatus(x.Status),
                            x.CreateTime)
                        {
                            ClientOrderId = x.ClientOrderId?.ToString(),
                            OrderQuantity = new SharedOrderQuantity(x.Quantity, contractQuantity: x.Quantity),
                            QuantityFilled = new SharedOrderQuantity(x.QuantityFilled, x.ValueFilled, x.QuantityFilled),
                            TimeInForce = x.TimeInForce == Enums.TimeInForce.ImmediateOrCancel ?SharedTimeInForce.ImmediateOrCancel : x.TimeInForce == Enums.TimeInForce.FillOrKill ? SharedTimeInForce.FillOrKill : x.TimeInForce == Enums.TimeInForce.GoodTillCanceled ? SharedTimeInForce.GoodTillCanceled : null,
                            UpdateTime = x.UpdateTime,
                            AveragePrice = x.AveragePrice,
                            PositionSide = x.PositionIdx == Enums.PositionIdx.OneWayMode ? null : x.PositionIdx == Enums.PositionIdx.BuyHedgeMode ? SharedPositionSide.Long : SharedPositionSide.Short,
                            ReduceOnly = x.ReduceOnly,
                            OrderPrice = x.Price == 0 ? null : x.Price,
#pragma warning disable CS0618 // Type or member is obsolete
                            Fee = x.ExecutedFee,
                            FeeAsset = x.FeeAsset,
#pragma warning restore CS0618 // Type or member is obsolete
                            TriggerPrice = x.TriggerPrice,
                            StopLossPrice = x.StopLoss,
                            TakeProfitPrice = x.TakeProfit,
                            IsTriggerOrder = x.TriggerPrice > 0
                        }
                    ).ToArray()));
                },
                ct: ct).ConfigureAwait(false);

            return result;
        }
        #endregion

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

        public PlaceFuturesOrderSocketOptions PlaceFuturesOrderOptions { get; } = new PlaceFuturesOrderSocketOptions(_exchangeName, true);
        public async Task<QueryResult<SharedId>> PlaceFuturesOrderAsync(PlaceFuturesOrderRequest request, CancellationToken ct)
        {
            var validationError = PlaceFuturesOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return QueryResult.Fail<SharedId>(Exchange, validationError);

            var category = request.Symbol!.TradingMode.IsLinear() ? Category.Linear : Category.Inverse;
            var result = await _api.PlaceOrderAsync(
                category,
                request.Symbol!.GetSymbol(FormatSymbol),
                request.Side == SharedOrderSide.Buy ? OrderSide.Buy : OrderSide.Sell,
                request.OrderType == SharedOrderType.Limit ? NewOrderType.Limit : NewOrderType.Market,
                quantity: request.Quantity?.QuantityInBaseAsset ?? request.Quantity?.QuantityInContracts ?? 0,
                price: request.Price,
                positionIdx: request.PositionSide == null ? PositionIdx.OneWayMode : request.PositionSide == SharedPositionSide.Long ? PositionIdx.BuyHedgeMode : PositionIdx.SellHedgeMode,
                reduceOnly: request.ReduceOnly,
                timeInForce: GetTimeInForce(request.OrderType, request.TimeInForce),
                clientOrderId: request.ClientOrderId,
                stopLoss: request.StopLossPrice,
                takeProfit: request.TakeProfitPrice,
                ct: ct).ConfigureAwait(false);

            if (!result.Success)
                return QueryResult.Fail<SharedId>(result);

            return QueryResult.Ok(result, new SharedId(result.Data.OrderId.ToString()));
        }

        public CancelFuturesOrderSocketOptions CancelFuturesOrderOptions { get; } = new CancelFuturesOrderSocketOptions(_exchangeName, true);
        public async Task<QueryResult<SharedId>> CancelFuturesOrderAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var validationError = CancelFuturesOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return QueryResult.Fail<SharedId>(Exchange, validationError);

            var category = (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var order = await _api.CancelOrderAsync(category, request.Symbol!.GetSymbol(FormatSymbol), request.OrderId, ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return QueryResult.Fail<SharedId>(order);

            return QueryResult.Ok(order, new SharedId(order.Data.OrderId.ToString()));
        }
        #endregion
    }
}
