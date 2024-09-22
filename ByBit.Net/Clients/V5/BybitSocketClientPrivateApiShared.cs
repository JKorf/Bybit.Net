
using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.V5;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis.Enums;
using CryptoExchange.Net.SharedApis.Interfaces.Socket;
using CryptoExchange.Net.SharedApis.Interfaces.Socket.Futures;
using CryptoExchange.Net.SharedApis.Interfaces.Socket.Spot;
using CryptoExchange.Net.SharedApis.Models;
using CryptoExchange.Net.SharedApis.Models.Options.Endpoints;
using CryptoExchange.Net.SharedApis.Models.Options.Subscriptions;
using CryptoExchange.Net.SharedApis.Models.Socket;
using CryptoExchange.Net.SharedApis.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.V5
{
    internal partial class BybitSocketClientPrivateApi : IBybitSocketClientPrivateApiShared
    {
        public string Exchange => BybitExchange.ExchangeName;
        public CryptoExchange.Net.Objects.TradingMode[] SupportedTradingModes { get; } = new[] { CryptoExchange.Net.Objects.TradingMode.Spot, CryptoExchange.Net.Objects.TradingMode.PerpetualLinear, CryptoExchange.Net.Objects.TradingMode.PerpetualInverse, CryptoExchange.Net.Objects.TradingMode.DeliveryLinear, CryptoExchange.Net.Objects.TradingMode.DeliveryInverse };

        public void SetDefaultExchangeParameter(string key, object value) => ExchangeParameters.SetStaticParameter(Exchange, key, value);
        public void ResetDefaultExchangeParameters() => ExchangeParameters.ResetStaticParameters();

        #region Balance client
        EndpointOptions<SubscribeBalancesRequest> IBalanceSocketClient.SubscribeBalanceOptions { get; } = new EndpointOptions<SubscribeBalancesRequest>(false);
        async Task<ExchangeResult<UpdateSubscription>> IBalanceSocketClient.SubscribeToBalanceUpdatesAsync(SubscribeBalancesRequest request, Action<ExchangeEvent<IEnumerable<SharedBalance>>> handler, CancellationToken ct)
        {
            var validationError = ((IBalanceSocketClient)this).SubscribeBalanceOptions.ValidateRequest(Exchange, request, request.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeResult<UpdateSubscription>(Exchange, validationError);

            var result = await SubscribeToWalletUpdatesAsync(
                update => handler(update.AsExchangeEvent<IEnumerable<SharedBalance>>(Exchange, update.Data.SelectMany(x => x.Assets.Select(x => new SharedBalance(x.Asset, x.AvailableToWithdraw ?? 0, x.WalletBalance))).ToArray())),
                ct: ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }
        #endregion

        #region Spot Order client

        EndpointOptions<SubscribeSpotOrderRequest> ISpotOrderSocketClient.SubscribeSpotOrderOptions { get; } = new EndpointOptions<SubscribeSpotOrderRequest>(false);
        async Task<ExchangeResult<UpdateSubscription>> ISpotOrderSocketClient.SubscribeToSpotOrderUpdatesAsync(SubscribeSpotOrderRequest request, Action<ExchangeEvent<IEnumerable<SharedSpotOrder>>> handler, CancellationToken ct)
        {
            var validationError = ((ISpotOrderSocketClient)this).SubscribeSpotOrderOptions.ValidateRequest(Exchange, request, CryptoExchange.Net.Objects.TradingMode.Spot, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeResult<UpdateSubscription>(Exchange, validationError);

            var result = await SubscribeToOrderUpdatesAsync(
                update => {
                    var data = update.Data.Where(x => x.Category == Category.Spot);
                    if (!data.Any())
                        return;

                    handler(update.AsExchangeEvent<IEnumerable<SharedSpotOrder>>(Exchange, data.Select(x =>
                        new SharedSpotOrder(
                            x.Symbol,
                            x.OrderId.ToString(),
                            x.OrderType == Enums.OrderType.Limit ? CryptoExchange.Net.SharedApis.Enums.SharedOrderType.Limit : x.OrderType == Enums.OrderType.Market ? CryptoExchange.Net.SharedApis.Enums.SharedOrderType.Market : CryptoExchange.Net.SharedApis.Enums.SharedOrderType.Other,
                            x.Side == Enums.OrderSide.Buy ? CryptoExchange.Net.SharedApis.Enums.SharedOrderSide.Buy : CryptoExchange.Net.SharedApis.Enums.SharedOrderSide.Sell,
                            x.Status == Enums.V5.OrderStatus.Cancelled ? CryptoExchange.Net.SharedApis.Enums.SharedOrderStatus.Canceled : (x.Status == Enums.V5.OrderStatus.New || x.Status == Enums.V5.OrderStatus.PartiallyFilled) ? CryptoExchange.Net.SharedApis.Enums.SharedOrderStatus.Open : CryptoExchange.Net.SharedApis.Enums.SharedOrderStatus.Filled,
                            x.CreateTime)
                        {
                            ClientOrderId = x.ClientOrderId?.ToString(),
                            Quantity = x.MarketUnit == Enums.V5.MarketUnit.QuoteAsset ? null : x.Quantity,
                            QuantityFilled = x.QuantityFilled,
                            QuoteQuantity = x.MarketUnit != Enums.V5.MarketUnit.QuoteAsset ? null : x.Quantity,
                            QuoteQuantityFilled = x.ValueFilled,
                            TimeInForce = x.TimeInForce == Enums.TimeInForce.ImmediateOrCancel ? CryptoExchange.Net.SharedApis.Enums.SharedTimeInForce.ImmediateOrCancel : x.TimeInForce == Enums.TimeInForce.FillOrKill ? CryptoExchange.Net.SharedApis.Enums.SharedTimeInForce.FillOrKill : x.TimeInForce == Enums.TimeInForce.GoodTillCanceled ? CryptoExchange.Net.SharedApis.Enums.SharedTimeInForce.GoodTillCanceled : null,
                            UpdateTime = x.UpdateTime,
                            AveragePrice = x.AveragePrice,
                            OrderPrice = x.Price,
                            Fee = x.ExecutedFee,
                            FeeAsset = x.FeeAsset
                        }
                    ).ToArray()));
                },
                ct: ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }
        #endregion

        #region Futures Order client

        EndpointOptions<SubscribeFuturesOrderRequest> IFuturesOrderSocketClient.SubscribeFuturesOrderOptions { get; } = new EndpointOptions<SubscribeFuturesOrderRequest>(false);
        async Task<ExchangeResult<UpdateSubscription>> IFuturesOrderSocketClient.SubscribeToFuturesOrderUpdatesAsync(SubscribeFuturesOrderRequest request, Action<ExchangeEvent<IEnumerable<SharedFuturesOrder>>> handler, CancellationToken ct)
        {
            var validationError = ((IFuturesOrderSocketClient)this).SubscribeFuturesOrderOptions.ValidateRequest(Exchange, request, request.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeResult<UpdateSubscription>(Exchange, validationError);

            var category = request.TradingMode?.IsLinear() == true ? Category.Linear : Category.Inverse;
            var result = await SubscribeToOrderUpdatesAsync(
                update =>
                {
                    var data = update.Data.Where(x => x.Category != Category.Spot);
                    if (request.TradingMode != null)
                        data = data.Where(x => x.Category == category);

                    if (!data.Any())
                        return;

                    handler(update.AsExchangeEvent<IEnumerable<SharedFuturesOrder>>(Exchange, data.Select(x =>
                        new SharedFuturesOrder(
                            x.Symbol,
                            x.OrderId.ToString(),
                            x.OrderType == Enums.OrderType.Limit ? CryptoExchange.Net.SharedApis.Enums.SharedOrderType.Limit : x.OrderType == Enums.OrderType.Market ? CryptoExchange.Net.SharedApis.Enums.SharedOrderType.Market : CryptoExchange.Net.SharedApis.Enums.SharedOrderType.Other,
                            x.Side == Enums.OrderSide.Buy ? CryptoExchange.Net.SharedApis.Enums.SharedOrderSide.Buy : CryptoExchange.Net.SharedApis.Enums.SharedOrderSide.Sell,
                            x.Status == Enums.V5.OrderStatus.Cancelled ? CryptoExchange.Net.SharedApis.Enums.SharedOrderStatus.Canceled : (x.Status == Enums.V5.OrderStatus.New || x.Status == Enums.V5.OrderStatus.PartiallyFilled) ? CryptoExchange.Net.SharedApis.Enums.SharedOrderStatus.Open : CryptoExchange.Net.SharedApis.Enums.SharedOrderStatus.Filled,
                            x.CreateTime)
                        {
                            ClientOrderId = x.ClientOrderId?.ToString(),
                            Quantity = x.MarketUnit == Enums.V5.MarketUnit.QuoteAsset ? null : x.Quantity,
                            QuantityFilled = x.QuantityFilled,
                            QuoteQuantity = x.MarketUnit != Enums.V5.MarketUnit.QuoteAsset ? null : x.Quantity,
                            QuoteQuantityFilled = x.ValueFilled,
                            TimeInForce = x.TimeInForce == Enums.TimeInForce.ImmediateOrCancel ? CryptoExchange.Net.SharedApis.Enums.SharedTimeInForce.ImmediateOrCancel : x.TimeInForce == Enums.TimeInForce.FillOrKill ? CryptoExchange.Net.SharedApis.Enums.SharedTimeInForce.FillOrKill : x.TimeInForce == Enums.TimeInForce.GoodTillCanceled ? CryptoExchange.Net.SharedApis.Enums.SharedTimeInForce.GoodTillCanceled : null,
                            UpdateTime = x.UpdateTime,
                            AveragePrice = x.AveragePrice,
                            PositionSide = x.PositionIdx == Enums.V5.PositionIdx.OneWayMode ? null : x.PositionIdx == Enums.V5.PositionIdx.BuyHedgeMode ? SharedPositionSide.Long : SharedPositionSide.Short,
                            ReduceOnly = x.ReduceOnly,
                            OrderPrice = x.Price,
                            Fee = x.ExecutedFee,
                            FeeAsset = x.FeeAsset
                        }
                    ).ToArray()));
                },
                ct: ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }
        #endregion

        #region User Trade client
        EndpointOptions<SubscribeUserTradeRequest> IUserTradeSocketClient.SubscribeUserTradeOptions { get; } = new EndpointOptions<SubscribeUserTradeRequest>(false);
        async Task<ExchangeResult<UpdateSubscription>> IUserTradeSocketClient.SubscribeToUserTradeUpdatesAsync(SubscribeUserTradeRequest request, Action<ExchangeEvent<IEnumerable<SharedUserTrade>>> handler, CancellationToken ct)
        {
            var validationError = ((IUserTradeSocketClient)this).SubscribeUserTradeOptions.ValidateRequest(Exchange, request, request.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeResult<UpdateSubscription>(Exchange, validationError);

            var category = request.TradingMode == CryptoExchange.Net.Objects.TradingMode.Spot ? Category.Spot : request.TradingMode?.IsLinear() == true ? Category.Linear : Category.Inverse;
            var result = await SubscribeToUserTradeUpdatesAsync(
                update =>
                {
                    var data = update.Data;
                    if (request.TradingMode != null)
                        data = data.Where(x => x.Category == category);

                    if (!data.Any())
                        return;

                    handler(update.AsExchangeEvent<IEnumerable<SharedUserTrade>>(Exchange, data.Select(x =>
                        new SharedUserTrade(
                            x.Symbol,
                            x.OrderId.ToString(),
                            x.TradeId.ToString(),
                            x.Quantity,
                            x.Price,
                            x.Timestamp)
                        {
                            Fee = x.Fee,
                            FeeAsset = x.FeeAsset,
                            Role = x.IsMaker ? SharedRole.Maker : SharedRole.Taker
                        }
                    ).ToArray()));
                },
                ct: ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }
        #endregion

        #region Position client
        EndpointOptions<SubscribePositionRequest> IPositionSocketClient.SubscribePositionOptions { get; } = new EndpointOptions<SubscribePositionRequest>(true);
        async Task<ExchangeResult<UpdateSubscription>> IPositionSocketClient.SubscribeToPositionUpdatesAsync(SubscribePositionRequest request, Action<ExchangeEvent<IEnumerable<SharedPosition>>> handler, CancellationToken ct)
        {
            var validationError = ((IPositionSocketClient)this).SubscribePositionOptions.ValidateRequest(Exchange, request, request.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeResult<UpdateSubscription>(Exchange, validationError);

            var result = await SubscribeToPositionUpdatesAsync(
                update => handler(update.AsExchangeEvent(Exchange, update.Data.Select(x => new SharedPosition(x.Symbol, x.Quantity, x.UpdateTime)
                {
                    AverageOpenPrice = x.AveragePrice,
                    PositionSide = x.PositionIdx == Enums.V5.PositionIdx.OneWayMode ? (x.Side == Enums.PositionSide.Sell ? SharedPositionSide.Short : SharedPositionSide.Long) : x.PositionIdx == Enums.V5.PositionIdx.BuyHedgeMode ? SharedPositionSide.Long : SharedPositionSide.Short,
                    LiquidationPrice = x.LiquidationPrice,
                    Leverage = x.Leverage,
                    UnrealizedPnl = x.UnrealizedPnl
                }))),
                ct: ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }

        #endregion
    }
}
