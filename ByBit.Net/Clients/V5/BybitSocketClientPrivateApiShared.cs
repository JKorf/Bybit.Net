
using Bybit.Net.Interfaces.Clients.V5;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis.Enums;
using CryptoExchange.Net.SharedApis.Interfaces.Socket;
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

        async Task<CallResult<UpdateSubscription>> IBalanceSocketClient.SubscribeToBalanceUpdatesAsync(SharedRequest request, Action<DataEvent<IEnumerable<SharedBalance>>> handler, CancellationToken ct)
        {
            var result = await SubscribeToWalletUpdatesAsync(
                update => handler(update.As(update.Data.SelectMany(x => x.Assets.Select(x => new SharedBalance(x.Asset, x.Free ?? 0, x.Equity ?? 0))))),
                ct: ct).ConfigureAwait(false);

            return result;
        }

        async Task<CallResult<UpdateSubscription>> ISpotOrderSocketClient.SubscribeToOrderUpdatesAsync(SharedRequest request, Action<DataEvent<IEnumerable<SharedSpotOrder>>> handler, CancellationToken ct)
        {
            var result = await SubscribeToOrderUpdatesAsync(
                update => handler(update.As<IEnumerable<SharedSpotOrder>>(update.Data.Select(x =>
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

            return result;
        }

        async Task<CallResult<UpdateSubscription>> ISpotUserTradeSocketClient.SubscribeToUserTradeUpdatesAsync(SharedRequest request, Action<DataEvent<IEnumerable<SharedUserTrade>>> handler, CancellationToken ct)
        {
            var result = await SubscribeToUserTradeUpdatesAsync(
                update => handler(update.As(update.Data.Select(x =>
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

            return result;
        }
    }
}
