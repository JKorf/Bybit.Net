
using Bybit.Net.Interfaces.Clients.V5;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis.Enums;
using CryptoExchange.Net.SharedApis.Interfaces.Socket;
using CryptoExchange.Net.SharedApis.Interfaces.Socket.Futures;
using CryptoExchange.Net.SharedApis.Models;
using CryptoExchange.Net.SharedApis.Models.FilterOptions;
using CryptoExchange.Net.SharedApis.Models.Socket;
using CryptoExchange.Net.SharedApis.RequestModels;
using CryptoExchange.Net.SharedApis.ResponseModels;
using CryptoExchange.Net.SharedApis.SubscribeModels;
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
        public ApiType[] SupportedApiTypes { get; } = new[] { ApiType.Spot, ApiType.PerpetualLinear, ApiType.PerpetualInverse, ApiType.DeliveryLinear, ApiType.DeliveryInverse };

        #region Balance client
        SubscriptionOptions IBalanceSocketClient.SubscribeBalanceOptions { get; } = new SubscriptionOptions("SubscribeBalanceRequest", false);
        async Task<ExchangeResult<UpdateSubscription>> IBalanceSocketClient.SubscribeToBalanceUpdatesAsync(Action<ExchangeEvent<IEnumerable<SharedBalance>>> handler, ApiType? apiType, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IBalanceSocketClient)this).SubscribeBalanceOptions.ValidateRequest(Exchange, exchangeParameters, apiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeResult<UpdateSubscription>(Exchange, validationError);

            var result = await SubscribeToWalletUpdatesAsync(
                update => handler(update.AsExchangeEvent(Exchange, update.Data.SelectMany(x => x.Assets.Select(x => new SharedBalance(x.Asset, x.Free ?? 0, x.Equity ?? 0))))),
                ct: ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }
        #endregion

        #region Spot Order client

        SubscriptionOptions ISpotOrderSocketClient.SubscribeSpotOrderOptions { get; } = new SubscriptionOptions("SubscribeSpotOrderRequest", false);
        async Task<ExchangeResult<UpdateSubscription>> ISpotOrderSocketClient.SubscribeToSpotOrderUpdatesAsync(Action<ExchangeEvent<IEnumerable<SharedSpotOrder>>> handler, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IBalanceSocketClient)this).SubscribeBalanceOptions.ValidateRequest(Exchange, exchangeParameters, ApiType.Spot, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeResult<UpdateSubscription>(Exchange, validationError);

            var result = await SubscribeToOrderUpdatesAsync(
                update => handler(update.AsExchangeEvent<IEnumerable<SharedSpotOrder>>(Exchange, update.Data.Select(x =>
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
                        Price = x.Price,
                        Fee = x.ExecutedFee,
                        FeeAsset = x.FeeAsset
                    }
                ))),
                ct: ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }
        #endregion

        #region Spot Order client

        SubscriptionOptions IFuturesOrderSocketClient.SubscribeFuturesOrderOptions { get; } = new SubscriptionOptions("SubscribeFuturesOrderRequest", false);
        async Task<ExchangeResult<UpdateSubscription>> IFuturesOrderSocketClient.SubscribeToFuturesOrderUpdatesAsync(Action<ExchangeEvent<IEnumerable<SharedFuturesOrder>>> handler, ApiType? apiType, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IFuturesOrderSocketClient)this).SubscribeFuturesOrderOptions.ValidateRequest(Exchange, exchangeParameters, apiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeResult<UpdateSubscription>(Exchange, validationError);

            var result = await SubscribeToOrderUpdatesAsync(
                update => handler(update.AsExchangeEvent(Exchange, update.Data.Select(x =>
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
                        Price = x.Price,
                        Fee = x.ExecutedFee,
                        FeeAsset = x.FeeAsset
                    }
                ))),
                ct: ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }
        #endregion

        #region User Trade client
        SubscriptionOptions IUserTradeSocketClient.SubscribeUserTradeOptions { get; } = new SubscriptionOptions("SubscribeUserTradeRequest", false);
        async Task<ExchangeResult<UpdateSubscription>> IUserTradeSocketClient.SubscribeToUserTradeUpdatesAsync(Action<ExchangeEvent<IEnumerable<SharedUserTrade>>> handler, ApiType? apiType, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IUserTradeSocketClient)this).SubscribeUserTradeOptions.ValidateRequest(Exchange, exchangeParameters, apiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeResult<UpdateSubscription>(Exchange, validationError);

#warning TODO apply ApiType filter
            var result = await SubscribeToUserTradeUpdatesAsync(
                update => handler(update.AsExchangeEvent(Exchange, update.Data.Select(x =>
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
                ))),
                ct: ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }
        #endregion

        #region Position client
        SubscriptionOptions IPositionSocketClient.SubscribePositionOptions { get; } = new SubscriptionOptions("SubscribePositionRequest", true);
        async Task<ExchangeResult<UpdateSubscription>> IPositionSocketClient.SubscribeToPositionUpdatesAsync(Action<ExchangeEvent<IEnumerable<SharedPosition>>> handler, ApiType? apiType, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IUserTradeSocketClient)this).SubscribeUserTradeOptions.ValidateRequest(Exchange, exchangeParameters, ApiType.Spot, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeResult<UpdateSubscription>(Exchange, validationError);

            var result = await SubscribeToPositionUpdatesAsync(
                update => handler(update.AsExchangeEvent(Exchange, update.Data.Select(x => new SharedPosition(x.Symbol, x.Quantity, x.UpdateTime)
                {
                    AverageEntryPrice = x.AveragePrice,
                    PositionSide = x.Side == Enums.PositionSide.Sell ? SharedPositionSide.Short : SharedPositionSide.Long,
                    LiquidationPrice = x.LiquidationPrice,
                    InitialMargin = x.InitialMargin,
                    Leverage = x.Leverage,
                    UnrealizedPnl = x.UnrealizedPnl
                }))),
                ct: ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }

        #endregion
    }
}
