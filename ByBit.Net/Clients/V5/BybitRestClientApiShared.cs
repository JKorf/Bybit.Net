using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Interfaces.Clients.SpotApi;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis.Enums;
using CryptoExchange.Net.SharedApis.Interfaces;
using CryptoExchange.Net.SharedApis.Models;
using CryptoExchange.Net.SharedApis.Models.Rest;
using CryptoExchange.Net.SharedApis.RequestModels;
using CryptoExchange.Net.SharedApis.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.V5
{
    internal partial class BybitRestClientApi : IBybitRestClientApiShared
    {
        public string Exchange => BybitExchange.ExchangeName;

        public IEnumerable<SharedOrderType> SupportedOrderType { get; } = new[]
        {
            SharedOrderType.Limit,
            SharedOrderType.Market,
            SharedOrderType.LimitMaker
        };

        public IEnumerable<SharedTimeInForce> SupportedTimeInForce { get; } = new[]
        {
            SharedTimeInForce.GoodTillCanceled,
            SharedTimeInForce.ImmediateOrCancel,
            SharedTimeInForce.FillOrKill
        };

        public SharedQuantitySupport OrderQuantitySupport { get; } =
            new SharedQuantitySupport(
#warning unclear if limit is supported
                SharedQuantityType.Both,
                SharedQuantityType.Both,
                SharedQuantityType.Both,
                SharedQuantityType.Both);

        async Task<ExchangeWebResult<IEnumerable<SharedKline>>> IKlineRestClient.GetKlinesAsync(GetKlinesRequest request, INextPageToken? pageToken, CancellationToken ct)
        {
            var interval = (Enums.KlineInterval)request.Interval;
            if (!Enum.IsDefined(typeof(Enums.KlineInterval), interval))
                return new ExchangeWebResult<IEnumerable<SharedKline>>(Exchange, new ArgumentError("Interval not supported"));

            // Determine page token
            DateTime? fromTimestamp = null;
            if (pageToken is DateTimeToken dateTimeToken)
                fromTimestamp = dateTimeToken.LastTime;

            var startTime = request.Filter?.StartTime;
            var endTime = request.Filter?.EndTime?.AddSeconds(-1);
            var apiLimit = 1000;

            if (request.Filter?.StartTime != null)
            {
                // Not paginated, check if the data will fit
                var seconds = apiLimit * (int)request.Interval;
                var maxEndTime = (fromTimestamp ?? request.Filter.StartTime).Value.AddSeconds(seconds - 1);
                if (maxEndTime < endTime)
                    endTime = maxEndTime;
            }

            // Get data
            var category = request.ApiType == ApiType.Spot ? Enums.Category.Spot : request.ApiType == ApiType.LinearFutures ? Enums.Category.Linear : Enums.Category.Inverse;
            var result = await ExchangeData.GetKlinesAsync(
                category,
                request.GetSymbol(FormatSymbol),
                interval,
                fromTimestamp ?? request.Filter?.StartTime,
                endTime,
                request.Filter?.Limit ?? apiLimit,
                ct: ct
                ).ConfigureAwait(false);

            if (!result)
                return result.AsExchangeResult<IEnumerable<SharedKline>>(Exchange, default);

            // Get next token
            DateTimeToken? nextToken = null;
            if (request.Filter?.StartTime != null && result.Data.List.Any())
            {
                var maxOpenTime = result.Data.List.Max(x => x.StartTime);
                if (maxOpenTime < request.Filter.EndTime!.Value.AddSeconds(-(int)request.Interval))
                    nextToken = new DateTimeToken(maxOpenTime.AddSeconds((int)interval));
            }

            // Reverse as data is returned in desc order instead of standard asc
            return result.AsExchangeResult(Exchange, result.Data.List.Reverse().Select(x => new SharedKline(x.StartTime, x.ClosePrice, x.HighPrice, x.LowPrice, x.OpenPrice, x.Volume)), nextToken);
        }

        async Task<ExchangeWebResult<IEnumerable<SharedSpotSymbol>>> ISpotSymbolRestClient.GetSpotSymbolsAsync(SharedRequest request, CancellationToken ct)
        {
            var result = await ExchangeData.GetSpotSymbolsAsync(ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<IEnumerable<SharedSpotSymbol>>(Exchange, default);

            return result.AsExchangeResult(Exchange, result.Data.List.Select(s => new SharedSpotSymbol(s.BaseAsset, s.QuoteAsset, s.Name)
            {
                MinTradeQuantity = s.LotSizeFilter?.MinOrderQuantity,
                MaxTradeQuantity = s.LotSizeFilter?.MaxOrderQuantity,
                QuantityStep = s.LotSizeFilter?.BasePrecision,
                PriceStep = s.PriceFilter?.TickSize
            }));
        }

        async Task<ExchangeWebResult<IEnumerable<SharedFuturesSymbol>>> IFuturesSymbolRestClient.GetSymbolsAsync(SharedRequest request, CancellationToken ct)
        {
            var category = request.ApiType == ApiType.Spot ? Enums.Category.Spot : request.ApiType == ApiType.LinearFutures ? Enums.Category.Linear : Enums.Category.Inverse;

            var result = await ExchangeData.GetLinearInverseSymbolsAsync(category, ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<IEnumerable<SharedFuturesSymbol>>(Exchange, default);

            return result.AsExchangeResult(Exchange, result.Data.List.Select(s => new SharedFuturesSymbol(s.BaseAsset, s.QuoteAsset, s.Name)
            {
                MinTradeQuantity = s.LotSizeFilter?.MinOrderQuantity,
                MaxTradeQuantity = s.LotSizeFilter?.MaxOrderQuantity,
                QuantityStep = s.LotSizeFilter?.QuantityStep,
                PriceStep = s.PriceFilter?.TickSize
            }));
        }

        async Task<ExchangeWebResult<IEnumerable<SharedTicker>>> ITickerRestClient.GetTickersAsync(SharedRequest request, CancellationToken ct)
        {
            if (request.ApiType == ApiType.Spot)
            {
                var result = await ExchangeData.GetSpotTickersAsync(ct: ct).ConfigureAwait(false);
                if (!result)
                    return result.AsExchangeResult<IEnumerable<SharedTicker>>(Exchange, default);

                return result.AsExchangeResult<IEnumerable<SharedTicker>>(Exchange, result.Data.List.Select(x => new SharedTicker(x.Symbol, x.LastPrice, x.HighPrice24h, x.LowPrice24h)));
            }
            else
            {
                var result = await ExchangeData.GetLinearInverseTickersAsync(request.ApiType == ApiType.InverseFutures ? Enums.Category.Inverse : Enums.Category.Linear, ct: ct).ConfigureAwait(false);
                if (!result)
                    return result.AsExchangeResult<IEnumerable<SharedTicker>>(Exchange, default);
                
                return result.AsExchangeResult<IEnumerable<SharedTicker>>(Exchange, result.Data.List.Select(x => new SharedTicker(x.Symbol, x.LastPrice, x.HighPrice24h, x.LowPrice24h)));
            }
        }

        async Task<ExchangeWebResult<SharedTicker>> ITickerRestClient.GetTickerAsync(GetTickerRequest request, CancellationToken ct)
        {
            if (request.ApiType == ApiType.Spot)
            {
                var result = await ExchangeData.GetSpotTickersAsync(request.GetSymbol(FormatSymbol), ct).ConfigureAwait(false);
                if (!result)
                    return result.AsExchangeResult<SharedTicker>(Exchange, default);

                var ticker = result.Data.List.Single();
                return result.AsExchangeResult(Exchange, new SharedTicker(ticker.Symbol, ticker.LastPrice, ticker.HighPrice24h, ticker.LowPrice24h));
            }
            else
            {
                var result = await ExchangeData.GetLinearInverseTickersAsync(
                    request.ApiType == ApiType.InverseFutures ? Enums.Category.Inverse : Enums.Category.Linear,
                    request.GetSymbol(FormatSymbol),
                    ct: ct).ConfigureAwait(false);
                if (!result)
                    return result.AsExchangeResult<SharedTicker>(Exchange, default);

                var ticker = result.Data.List.Single();
                return result.AsExchangeResult(Exchange, new SharedTicker(ticker.Symbol, ticker.LastPrice, ticker.HighPrice24h, ticker.LowPrice24h));
            }
        }

        async Task<ExchangeWebResult<IEnumerable<SharedTrade>>> IRecentTradeRestClient.GetRecentTradesAsync(GetRecentTradesRequest request, CancellationToken ct)
        {
            var category = request.ApiType == ApiType.Spot ? Enums.Category.Spot : request.ApiType == ApiType.LinearFutures ? Enums.Category.Linear : Enums.Category.Inverse;

            var result = await ExchangeData.GetTradeHistoryAsync(
                category,
                request.GetSymbol(FormatSymbol),
                limit: request.Limit,
                ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<IEnumerable<SharedTrade>>(Exchange, default);

            return result.AsExchangeResult(Exchange, result.Data.List.Select(x => new SharedTrade(x.Quantity, x.Price, x.Timestamp)));
        }

        async Task<ExchangeWebResult<IEnumerable<SharedBalance>>> IBalanceRestClient.GetBalancesAsync(SharedRequest request, CancellationToken ct)
        {
            // Assume unified account
            // Inverse futures uses CONTRACT, other UNIFIED
            var accountType = request.ApiType == ApiType.InverseFutures ? Enums.AccountType.Contract : Enums.AccountType.Unified;

            var result = await Account.GetBalancesAsync(accountType, ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<IEnumerable<SharedBalance>>(Exchange, default);

            return result.AsExchangeResult(Exchange, result.Data.List.SelectMany(x => x.Assets.Select(x => new SharedBalance(x.Asset, x.WalletBalance, x.Equity ?? 0))));
        }

        async Task<ExchangeWebResult<SharedId>> ISpotOrderRestClient.PlaceOrderAsync(PlaceSpotOrderRequest request, CancellationToken ct)
        {
            if (request.OrderType == SharedOrderType.Other)
                throw new ArgumentException("OrderType can't be `Other`", nameof(request.OrderType));

            var result = await Trading.PlaceOrderAsync(
                Category.Spot,
                request.GetSymbol(FormatSymbol),
                request.Side == SharedOrderSide.Buy ? OrderSide.Buy : OrderSide.Sell,
                request.OrderType == SharedOrderType.Market ? NewOrderType.Market : NewOrderType.Limit,
                quantity: request.Quantity ?? request.QuoteQuantity ?? 0,
                price: request.Price,
                clientOrderId: request.ClientOrderId,
                timeInForce: GetTimeInForce(request.OrderType, request.TimeInForce),
                marketUnit: request.Quantity != null ? Enums.V5.MarketUnit.BaseAsset: Enums.V5.MarketUnit.QuoteAsset
                ).ConfigureAwait(false);

            if (!result)
                return result.AsExchangeResult<SharedId>(Exchange, default);

            return result.AsExchangeResult(Exchange, new SharedId(result.Data.OrderId));
        }

        async Task<ExchangeWebResult<SharedSpotOrder>> ISpotOrderRestClient.GetOrderAsync(GetOrderRequest request, CancellationToken ct)
        {
            var orders = await Trading.GetOrdersAsync(Category.Spot, orderId: request.OrderId).ConfigureAwait(false);
            if (!orders)
                return orders.AsExchangeResult<SharedSpotOrder>(Exchange, default);

            if (!orders.Data.List.Any())
                return new ExchangeWebResult<SharedSpotOrder>(Exchange, new ServerError("Order not found"));

            var order = orders.Data.List.Single();
            return orders.AsExchangeResult(Exchange, new SharedSpotOrder(
                order.Symbol,
                order.OrderId.ToString(),
                ParseOrderType(order.OrderType),
                order.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                ParseOrderStatus(order.Status),
                order.CreateTime)
            {
                ClientOrderId = order.ClientOrderId,
                Price = order.Price,
                Quantity = order.MarketUnit == null || order.MarketUnit == Enums.V5.MarketUnit.BaseAsset ? order.Quantity : null,
                QuantityFilled = order.QuantityFilled,
                UpdateTime = order.UpdateTime,
                TimeInForce = ParseTimeInForce(order.TimeInForce),
                FeeAsset = order.FeeAsset,
                Fee = order.ExecutedFee,
                QuoteQuantity = order.MarketUnit == Enums.V5.MarketUnit.QuoteAsset ? order.Quantity : null,
                QuoteQuantityFilled = order.ValueFilled,
                AveragePrice = order.AveragePrice
            });
        }

        async Task<ExchangeWebResult<IEnumerable<SharedSpotOrder>>> ISpotOrderRestClient.GetOpenOrdersAsync(GetSpotOpenOrdersRequest request, CancellationToken ct)
        {
            string? symbol = null;
            if (request.BaseAsset != null && request.QuoteAsset != null)
                symbol = FormatSymbol(request.BaseAsset, request.QuoteAsset, request.ApiType);

            var orders = await Trading.GetOrdersAsync(Category.Spot, symbol, openOnly: 0).ConfigureAwait(false);
            if (!orders)
                return orders.AsExchangeResult<IEnumerable<SharedSpotOrder>>(Exchange, default);

            return orders.AsExchangeResult(Exchange, orders.Data.List.Select(x => new SharedSpotOrder(
                x.Symbol,
                x.OrderId.ToString(),
                ParseOrderType(x.OrderType),
                x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                ParseOrderStatus(x.Status),
                x.CreateTime)
            {
                ClientOrderId = x.ClientOrderId,
                Price = x.Price,
                Quantity = x.MarketUnit == null || x.MarketUnit == Enums.V5.MarketUnit.BaseAsset ? x.Quantity : null,
                QuantityFilled = x.QuantityFilled,
                UpdateTime = x.UpdateTime,
                TimeInForce = ParseTimeInForce(x.TimeInForce),
                FeeAsset = x.FeeAsset,
                Fee = x.ExecutedFee,
                QuoteQuantity = x.MarketUnit == Enums.V5.MarketUnit.QuoteAsset ? x.Quantity : null,
                QuoteQuantityFilled = x.ValueFilled,
                AveragePrice = x.AveragePrice
            }));
        }

        async Task<ExchangeWebResult<IEnumerable<SharedSpotOrder>>> ISpotOrderRestClient.GetClosedOrdersAsync(GetSpotClosedOrdersRequest request, INextPageToken? pageToken, CancellationToken ct)
        {
            // Determine page token
            string? cursor = null;
            if (pageToken is CursorToken token)
                cursor = token.Cursor;

            // Get data
            var orders = await Trading.GetOrderHistoryAsync(Category.Spot,
                request.GetSymbol(FormatSymbol),
                startTime: request.Filter?.StartTime,
                endTime: request.Filter?.EndTime,
                limit: request.Filter?.Limit
                ).ConfigureAwait(false);
            if (!orders)
                return orders.AsExchangeResult<IEnumerable<SharedSpotOrder>>(Exchange, default);

            // Get next token
            CursorToken? nextToken = null;
            if (!string.IsNullOrWhiteSpace(orders.Data.NextPageCursor))
                nextToken = new CursorToken(orders.Data.NextPageCursor!);

            return orders.AsExchangeResult(Exchange, orders.Data.List.Select(x => new SharedSpotOrder(
                x.Symbol,
                x.OrderId.ToString(),
                ParseOrderType(x.OrderType),
                x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                ParseOrderStatus(x.Status),
                x.CreateTime)
            {
                ClientOrderId = x.ClientOrderId,
                Price = x.Price,
                Quantity = x.MarketUnit == null || x.MarketUnit == Enums.V5.MarketUnit.BaseAsset ? x.Quantity : null,
                QuantityFilled = x.QuantityFilled,
                UpdateTime = x.UpdateTime,
                TimeInForce = ParseTimeInForce(x.TimeInForce),
                FeeAsset = x.FeeAsset,
                Fee = x.ExecutedFee,
                QuoteQuantity = x.MarketUnit == Enums.V5.MarketUnit.QuoteAsset ? x.Quantity : null,
                QuoteQuantityFilled = x.ValueFilled,
                AveragePrice = x.AveragePrice
            }), nextToken);
        }

        async Task<ExchangeWebResult<IEnumerable<SharedUserTrade>>> ISpotOrderRestClient.GetOrderTradesAsync(GetOrderTradesRequest request, CancellationToken ct)
        {
            var trades = await Trading.GetUserTradesAsync(Category.Spot, orderId: request.OrderId).ConfigureAwait(false);
            if (!trades)
                return trades.AsExchangeResult<IEnumerable<SharedUserTrade>>(Exchange, default);

            return trades.AsExchangeResult(Exchange, trades.Data.List.Select(x => new SharedUserTrade(
                x.Symbol,
                x.OrderId,
                x.TradeId,
                x.Quantity,
                x.Price,
                x.Timestamp)
            {
                Fee = x.Fee,
                FeeAsset = x.FeeAsset,
                Role = x.IsMaker ? SharedRole.Maker : SharedRole.Taker
            }));
        }

        async Task<ExchangeWebResult<IEnumerable<SharedUserTrade>>> ISpotOrderRestClient.GetUserTradesAsync(GetUserTradesRequest request, INextPageToken? pageToken, CancellationToken ct)
        {
            // Determine page token
            string? cursor = null;
            if (pageToken is CursorToken token)
                cursor = token.Cursor;

            // Get data
            var trades = await Trading.GetUserTradesAsync(Category.Spot,
                startTime: request.Filter?.StartTime,
                endTime: request.Filter?.EndTime,
                limit: request.Filter?.Limit,
                cursor: cursor).ConfigureAwait(false);
            if (!trades)
                return trades.AsExchangeResult<IEnumerable<SharedUserTrade>>(Exchange, default);

            // Get next token
            CursorToken? nextToken = null;
            if (!string.IsNullOrWhiteSpace(trades.Data.NextPageCursor))
                nextToken = new CursorToken(trades.Data.NextPageCursor!);

            return trades.AsExchangeResult(Exchange, trades.Data.List.Select(x => new SharedUserTrade(
                x.Symbol,
                x.OrderId,
                x.TradeId,
                x.Quantity,
                x.Price,
                x.Timestamp)
            {
                Fee = x.Fee,
                FeeAsset = x.FeeAsset,
                Role = x.IsMaker ? SharedRole.Maker : SharedRole.Taker
            }), nextToken);
        }

        async Task<ExchangeWebResult<SharedId>> ISpotOrderRestClient.CancelOrderAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var order = await Trading.CancelOrderAsync(Category.Spot, FormatSymbol(request.BaseAsset, request.QuoteAsset, request.ApiType), request.OrderId).ConfigureAwait(false);
            if (!order)
                return order.AsExchangeResult<SharedId>(Exchange, default);

            return order.AsExchangeResult(Exchange, new SharedId(order.Data.OrderId));
        }

        private SharedOrderStatus ParseOrderStatus(Enums.V5.OrderStatus status)
        {
            if (status == Enums.V5.OrderStatus.PartiallyFilled || status == Enums.V5.OrderStatus.New || status == Enums.V5.OrderStatus.Created) return SharedOrderStatus.Open;
            if (status == Enums.V5.OrderStatus.Cancelled || status == Enums.V5.OrderStatus.Rejected) return SharedOrderStatus.Canceled;
            return SharedOrderStatus.Filled;
        }

        private SharedOrderType ParseOrderType(OrderType type)
        {
            if (type == OrderType.Market) return SharedOrderType.Market;
            if (type == OrderType.LimitMaker) return SharedOrderType.LimitMaker;
            if (type == OrderType.Limit) return SharedOrderType.Limit;

            return SharedOrderType.Other;
        }

        private SharedTimeInForce? ParseTimeInForce(TimeInForce tif)
        {
            if (tif == TimeInForce.ImmediateOrCancel) return SharedTimeInForce.ImmediateOrCancel;
            if (tif == TimeInForce.FillOrKill) return SharedTimeInForce.FillOrKill;
            if (tif == TimeInForce.GoodTillCanceled) return SharedTimeInForce.GoodTillCanceled;

            return null;
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
    }
}
