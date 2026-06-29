using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.SharedApis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.V5
{
    internal partial class BybitRestClientApi : IBybitRestClientApiShared
    {
        private const string _topicSpotId = "BybitSpot";
        private const string _topicFuturesId = "BybitFutures";

        private const string _exchangeName = "Bybit";
        public TradingMode[] SupportedTradingModes => new[] { TradingMode.Spot, TradingMode.PerpetualLinear, TradingMode.DeliveryLinear, TradingMode.PerpetualInverse, TradingMode.DeliveryInverse };

        private TradingMode[] FuturesTradingModes { get; } = new[] { TradingMode.PerpetualLinear, TradingMode.DeliveryLinear, TradingMode.PerpetualInverse, TradingMode.DeliveryInverse }; 

        public void SetDefaultExchangeParameter(string key, object value) => ExchangeParameters.SetStaticParameter(Exchange, key, value);
        public void ResetDefaultExchangeParameters() => ExchangeParameters.ResetStaticParameters();
        public SharedClientInfo Discover() => SharedUtils.GetClientInfo(BybitExchange.Metadata, this);

        #region Kline client

        GetKlinesOptions IKlineRestClient.GetKlinesOptions { get; } = new GetKlinesOptions(_exchangeName, false, true, true, 1000, false,
            SharedKlineInterval.OneMinute,
            SharedKlineInterval.FiveMinutes,
            SharedKlineInterval.FifteenMinutes,
            SharedKlineInterval.ThirtyMinutes,
            SharedKlineInterval.OneHour,
            SharedKlineInterval.TwoHours,
            SharedKlineInterval.FourHours,
            SharedKlineInterval.SixHours,
            SharedKlineInterval.TwelveHours,
            SharedKlineInterval.OneDay,
            SharedKlineInterval.OneWeek,
            SharedKlineInterval.OneMonth);
        async Task<HttpResult<SharedKline[]>> IKlineRestClient.GetKlinesAsync(GetKlinesRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var interval = (KlineInterval)request.Interval;

            var validationError = SharedClient.GetKlinesOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedKline[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var symbol = request.Symbol!.GetSymbol(FormatSymbol);
            var limit = request.Limit ?? 1000;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest, true);

            // Get data
            var category = request.Symbol!.TradingMode == TradingMode.Spot ? Category.Spot : (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var result = await ExchangeData.GetKlinesAsync(
                category,
                symbol,
                interval,
                startTime: pageParams.StartTime,
                endTime: pageParams.EndTime,
                limit: limit,
                ct: ct
                ).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedKline[]>(result);

            var nextPageRequest = Pagination.GetNextPageRequest(
                    () => Pagination.NextPageFromTime(pageParams, result.Data.List.Min(x => x.StartTime)),
                    result.Data.List.Length,
                    result.Data.List.Select(x => x.StartTime),
                    request.StartTime,
                    request.EndTime ?? DateTime.UtcNow,
                    pageParams);

            return HttpResult.Ok(result, ExchangeHelpers.ApplyFilter(result.Data.List, x => x.StartTime, request.StartTime, request.EndTime, direction)
                   .Select(x => 
                        new SharedKline(
                            request.Symbol,
                            symbol, 
                            x.StartTime,
                            x.ClosePrice,
                            x.HighPrice,
                            x.LowPrice,
                            x.OpenPrice,
                            x.Volume))
                   .ToArray(), nextPageRequest);
        }

        #endregion

        #region Spot Symbol client

        GetSpotSymbolsOptions ISpotSymbolRestClient.GetSpotSymbolsOptions { get; } = new GetSpotSymbolsOptions(_exchangeName, false);
        async Task<HttpResult<SharedSpotSymbol[]>> ISpotSymbolRestClient.GetSpotSymbolsAsync(GetSymbolsRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetSpotSymbolsOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedSpotSymbol[]>(Exchange, validationError);

            var result = await ExchangeData.GetSpotSymbolsAsync(ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedSpotSymbol[]>(result);

            var response = HttpResult.Ok(result, result.Data.List.Select(s => new SharedSpotSymbol(s.BaseAsset, s.QuoteAsset, s.Name, s.Status == SymbolStatus.Trading)
            {
                MinTradeQuantity = s.LotSizeFilter?.MinOrderQuantity,
                MaxTradeQuantity = s.LotSizeFilter?.MaxOrderQuantity,
                MinNotionalValue = s.LotSizeFilter?.MinOrderValue,
                QuantityStep = s.LotSizeFilter?.BasePrecision,
                PriceStep = s.PriceFilter?.TickSize
            }).ToArray());

            ExchangeSymbolCache.UpdateSymbolInfo(_topicSpotId, EnvironmentName, null, response.Data!);
            return response;
        }

        async Task<ExchangeCallResult<SharedSymbol[]>> ISpotSymbolRestClient.GetSpotSymbolsForBaseAssetAsync(string baseAsset)
        {
            if (!ExchangeSymbolCache.HasCached(_topicSpotId, EnvironmentName, null))
            {
                var symbols = await ((ISpotSymbolRestClient)this).GetSpotSymbolsAsync(new GetSymbolsRequest()).ConfigureAwait(false);
                if (!symbols.Success)
                    return ExchangeCallResult<SharedSymbol[]>.Fail(Exchange, symbols.Error!);
            }

            return ExchangeCallResult<SharedSymbol[]>.Ok(Exchange, ExchangeSymbolCache.GetSymbolsForBaseAsset(_topicSpotId, EnvironmentName, null, baseAsset));
        }

        async Task<ExchangeCallResult<bool>> ISpotSymbolRestClient.SupportsSpotSymbolAsync(SharedSymbol symbol)
        {
            if (symbol.TradingMode != TradingMode.Spot)
                throw new ArgumentException(nameof(symbol), "Only Spot symbols allowed");

            if (!ExchangeSymbolCache.HasCached(_topicSpotId, EnvironmentName, null))
            {
                var symbols = await ((ISpotSymbolRestClient)this).GetSpotSymbolsAsync(new GetSymbolsRequest()).ConfigureAwait(false);
                if (!symbols.Success)
                    return ExchangeCallResult<bool>.Fail(Exchange, symbols.Error!);
            }

            return ExchangeCallResult<bool>.Ok(Exchange, ExchangeSymbolCache.SupportsSymbol(_topicSpotId, EnvironmentName, null, symbol));
        }

        async Task<ExchangeCallResult<bool>> ISpotSymbolRestClient.SupportsSpotSymbolAsync(string symbolName)
        {
            if (!ExchangeSymbolCache.HasCached(_topicSpotId, EnvironmentName, null))
            {
                var symbols = await ((ISpotSymbolRestClient)this).GetSpotSymbolsAsync(new GetSymbolsRequest()).ConfigureAwait(false);
                if (!symbols.Success)
                    return ExchangeCallResult<bool>.Fail(Exchange, symbols.Error!);
            }

            return ExchangeCallResult<bool>.Ok(Exchange, ExchangeSymbolCache.SupportsSymbol(_topicSpotId, EnvironmentName, null, symbolName));
        }
        #endregion

        #region Spot Ticker client

        GetSpotTickersOptions ISpotTickerRestClient.GetSpotTickersOptions { get; } = new GetSpotTickersOptions(_exchangeName);
        async Task<HttpResult<SharedSpotTicker[]>> ISpotTickerRestClient.GetSpotTickersAsync(GetTickersRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetSpotTickersOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedSpotTicker[]>(Exchange, validationError);

            var result = await ExchangeData.GetSpotTickersAsync(ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedSpotTicker[]>(result);

            return HttpResult.Ok(result, result.Data.List.Select(x => new SharedSpotTicker(ExchangeSymbolCache.ParseSymbol(_topicSpotId, EnvironmentName, null, x.Symbol), x.Symbol, x.LastPrice, x.HighPrice24h, x.LowPrice24h, x.Volume24h, x.PriceChangePercentag24h * 100)
            {
                QuoteVolume = x.Turnover24h
            }).ToArray());
        }

        GetSpotTickerOptions ISpotTickerRestClient.GetSpotTickerOptions { get; } = new GetSpotTickerOptions(_exchangeName);
        async Task<HttpResult<SharedSpotTicker>> ISpotTickerRestClient.GetSpotTickerAsync(GetTickerRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetSpotTickerOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedSpotTicker>(Exchange, validationError);

            if (request.Symbol!.TradingMode == TradingMode.Spot)
            {
                var result = await ExchangeData.GetSpotTickersAsync(request.Symbol!.GetSymbol(FormatSymbol), ct).ConfigureAwait(false);
                if (!result.Success)
                    return HttpResult.Fail<SharedSpotTicker>(result);

                var ticker = result.Data.List.Single();
                return HttpResult.Ok(result, new SharedSpotTicker(ExchangeSymbolCache.ParseSymbol(_topicSpotId, EnvironmentName, null, ticker.Symbol), ticker.Symbol, ticker.LastPrice, ticker.HighPrice24h, ticker.LowPrice24h, ticker.Volume24h, ticker.PriceChangePercentag24h * 100)
                {
                    QuoteVolume = ticker.Turnover24h
                });
            }
            else
            {
                var result = await ExchangeData.GetLinearInverseTickersAsync(
                    (request.Symbol!.TradingMode == TradingMode.DeliveryInverse || request.Symbol!.TradingMode == TradingMode.PerpetualInverse) ? Category.Inverse : Category.Linear,
                    request.Symbol!.GetSymbol(FormatSymbol),
                    ct: ct).ConfigureAwait(false);
                if (!result.Success)
                    return HttpResult.Fail<SharedSpotTicker>(result);

                var ticker = result.Data.List.Single();
                return HttpResult.Ok(result, new SharedSpotTicker(ExchangeSymbolCache.ParseSymbol(_topicSpotId, EnvironmentName, null, ticker.Symbol), ticker.Symbol, ticker.LastPrice, ticker.HighPrice24h, ticker.LowPrice24h, ticker.Volume24h, ticker.PriceChangePercentage24h)
                {
                    QuoteVolume = ticker.Turnover24h
                });
            }
        }

        #endregion

        #region Book Ticker client

        GetBookTickerOptions IBookTickerRestClient.GetBookTickerOptions { get; } = new GetBookTickerOptions(_exchangeName, false);
        async Task<HttpResult<SharedBookTicker>> IBookTickerRestClient.GetBookTickerAsync(GetBookTickerRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetBookTickerOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedBookTicker>(Exchange, validationError);

            var category = request.Symbol!.TradingMode == TradingMode.Spot ? Category.Spot : (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var resultTicker = await ExchangeData.GetOrderbookAsync(category, request.Symbol!.GetSymbol(FormatSymbol), 1, ct: ct).ConfigureAwait(false);
            if (!resultTicker.Success)
                return HttpResult.Fail<SharedBookTicker>(resultTicker);

            return HttpResult.Ok(resultTicker, new SharedBookTicker(
                ExchangeSymbolCache.ParseSymbol(request.Symbol!.TradingMode == TradingMode.Spot ? _topicSpotId : _topicFuturesId, EnvironmentName, null, resultTicker.Data.Symbol),
                resultTicker.Data.Symbol,
                resultTicker.Data.Asks[0].Price,
                resultTicker.Data.Asks[0].Quantity,
                resultTicker.Data.Bids[0].Price,
                resultTicker.Data.Bids[0].Quantity));
        }

        #endregion

        #region Recent Trade client
        GetRecentTradesOptions IRecentTradeRestClient.GetRecentTradesOptions { get; } = new GetRecentTradesOptions(_exchangeName, 1000, false);

        async Task<HttpResult<SharedTrade[]>> IRecentTradeRestClient.GetRecentTradesAsync(GetRecentTradesRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetRecentTradesOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedTrade[]>(Exchange, validationError);

            var category = request.Symbol!.TradingMode == TradingMode.Spot ? Category.Spot : (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;

            var result = await ExchangeData.GetTradeHistoryAsync(
                category,
                request.Symbol!.GetSymbol(FormatSymbol),
                limit: request.Limit,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedTrade[]>(result);

            return HttpResult.Ok(result, result.Data.List.Select(x =>
            new SharedTrade(request.Symbol, x.Symbol, x.Quantity, x.Price, x.Timestamp)
            {
                Side = x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell
            }).ToArray());
        }

        #endregion

        #region Balance client
        GetBalancesOptions IBalanceRestClient.GetBalancesOptions { get; } = new GetBalancesOptions(_exchangeName, AccountTypeFilter.Spot, AccountTypeFilter.Futures, AccountTypeFilter.Funding, AccountTypeFilter.Margin, AccountTypeFilter.Option);
        async Task<HttpResult<SharedBalance[]>> IBalanceRestClient.GetBalancesAsync(GetBalancesRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetBalancesOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedBalance[]>(Exchange, validationError);

            var result = await Account.GetBalancesAsync(AccountType.Unified, ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedBalance[]>(result);

            return HttpResult.Ok(result, result.Data.List.SelectMany(x => x.Assets.Select(x => 
                new SharedBalance(
                    SupportedTradingModes, 
                    x.Asset,
                    (x.WalletBalance ?? 0) - (x.Locked ?? 0),
                    x.Equity ?? 0))).ToArray());
        }

        #endregion

        #region Spot Order client

        SharedFeeDeductionType ISpotOrderRestClient.SpotFeeDeductionType => SharedFeeDeductionType.DeductFromOutput;
        SharedFeeAssetType ISpotOrderRestClient.SpotFeeAssetType => SharedFeeAssetType.OutputAsset;
        SharedOrderType[] ISpotOrderRestClient.SpotSupportedOrderTypes { get; } = new[] { SharedOrderType.Limit, SharedOrderType.Market };
        SharedTimeInForce[] ISpotOrderRestClient.SpotSupportedTimeInForce { get; } = new[] { SharedTimeInForce.GoodTillCanceled, SharedTimeInForce.ImmediateOrCancel, SharedTimeInForce.FillOrKill };
        SharedQuantitySupport ISpotOrderRestClient.SpotSupportedOrderQuantity { get; } = new SharedQuantitySupport(
                SharedQuantityType.BaseAsset,
                SharedQuantityType.BaseAsset,
                SharedQuantityType.BaseAndQuoteAsset,
                SharedQuantityType.BaseAndQuoteAsset);

        string ISpotOrderRestClient.GenerateClientOrderId() => ExchangeHelpers.RandomString(32);

        PlaceSpotOrderOptions ISpotOrderRestClient.PlaceSpotOrderOptions { get; } = new PlaceSpotOrderOptions(_exchangeName);
        async Task<HttpResult<SharedId>> ISpotOrderRestClient.PlaceSpotOrderAsync(PlaceSpotOrderRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.PlaceSpotOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var result = await Trading.PlaceOrderAsync(
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
                return HttpResult.Fail<SharedId>(result);

            return HttpResult.Ok(result, new SharedId(result.Data.OrderId));
        }

        GetSpotOrderOptions ISpotOrderRestClient.GetSpotOrderOptions { get; } = new GetSpotOrderOptions(_exchangeName, true);
        async Task<HttpResult<SharedSpotOrder>> ISpotOrderRestClient.GetSpotOrderAsync(GetOrderRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetSpotOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedSpotOrder>(Exchange, validationError);

            var orders = await Trading.GetOrdersAsync(Category.Spot, orderId: request.OrderId, ct: ct).ConfigureAwait(false);
            if (!orders.Success)
                return HttpResult.Fail<SharedSpotOrder>(orders);

            if (!orders.Data.List.Any())
                return HttpResult.Fail<SharedSpotOrder>(Exchange, new ServerError(new ErrorInfo(ErrorType.UnknownOrder, "Order not found")));

            var order = orders.Data.List.Single();
            return HttpResult.Ok(orders, new SharedSpotOrder(
                ExchangeSymbolCache.ParseSymbol(_topicSpotId, EnvironmentName, null, order.Symbol),
                order.Symbol,
                order.OrderId.ToString(),
                ParseOrderType(order.OrderType),
                order.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                ParseOrderStatus(order.Status),
                order.CreateTime)
            {
                ClientOrderId = order.ClientOrderId,
                OrderPrice = order.Price,
                OrderQuantity = new SharedOrderQuantity(order.MarketUnit == null || order.MarketUnit == MarketUnit.BaseAsset ? order.Quantity : null, order.MarketUnit == MarketUnit.QuoteAsset ? order.Quantity : null),
                QuantityFilled = new SharedOrderQuantity(order.QuantityFilled, order.ValueFilled),
                UpdateTime = order.UpdateTime,
                TimeInForce = ParseTimeInForce(order.TimeInForce),
                FeeAsset = order.FeeAsset,
                Fee = order.ExecutedFee,
                AveragePrice = order.AveragePrice == 0 ? null : order.AveragePrice,
                TriggerPrice = order.TriggerPrice,
                IsTriggerOrder = order.TriggerPrice != null
            });
        }

        GetOpenSpotOrdersOptions ISpotOrderRestClient.GetOpenSpotOrdersOptions { get; } = new GetOpenSpotOrdersOptions(_exchangeName, true);
        async Task<HttpResult<SharedSpotOrder[]>> ISpotOrderRestClient.GetOpenSpotOrdersAsync(GetOpenOrdersRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetOpenSpotOrdersOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedSpotOrder[]>(Exchange, validationError);

            var symbol = request.Symbol?.GetSymbol(FormatSymbol);
            var orders = await Trading.GetOrdersAsync(Category.Spot, symbol, openOnly: 0, ct: ct).ConfigureAwait(false);
            if (!orders.Success)
                return HttpResult.Fail<SharedSpotOrder[]>(orders);

            return HttpResult.Ok(orders, orders.Data.List.Select(x => new SharedSpotOrder(
                ExchangeSymbolCache.ParseSymbol(_topicSpotId, EnvironmentName, null, x.Symbol), 
                x.Symbol,
                x.OrderId.ToString(),
                ParseOrderType(x.OrderType),
                x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                ParseOrderStatus(x.Status),
                x.CreateTime)
            {
                ClientOrderId = x.ClientOrderId,
                OrderPrice = x.Price,
                OrderQuantity = new SharedOrderQuantity(x.MarketUnit == null || x.MarketUnit == MarketUnit.BaseAsset ? x.Quantity : null, x.MarketUnit == MarketUnit.QuoteAsset ? x.Quantity : null),
                QuantityFilled = new SharedOrderQuantity(x.QuantityFilled, x.ValueFilled),
                UpdateTime = x.UpdateTime,
                TimeInForce = ParseTimeInForce(x.TimeInForce),
                FeeAsset = x.FeeAsset,
                Fee = x.ExecutedFee,
                AveragePrice = x.AveragePrice == 0 ? null : x.AveragePrice,
                TriggerPrice = x.TriggerPrice,
                IsTriggerOrder = x.TriggerPrice != null
            }).ToArray());
        }

        GetSpotClosedOrdersOptions ISpotOrderRestClient.GetClosedSpotOrdersOptions { get; } = new GetSpotClosedOrdersOptions(_exchangeName, false, true, true, 50);
        async Task<HttpResult<SharedSpotOrder[]>> ISpotOrderRestClient.GetClosedSpotOrdersAsync(GetClosedOrdersRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var validationError = SharedClient.GetClosedSpotOrdersOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedSpotOrder[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var limit = request.Limit ?? 50;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest, true, maxPeriod: TimeSpan.FromDays(7));

            // Get data
            var result = await Trading.GetOrderHistoryAsync(Category.Spot,
                request.Symbol!.GetSymbol(FormatSymbol),
                startTime: pageParams.StartTime,
                endTime: pageParams.EndTime,
                limit: limit,
                cursor: pageParams.Cursor,
                ct: ct
                ).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedSpotOrder[]>(result);

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
                            new SharedSpotOrder(
                                ExchangeSymbolCache.ParseSymbol(_topicSpotId, EnvironmentName, null, x.Symbol), 
                                x.Symbol,
                                x.OrderId.ToString(),
                                ParseOrderType(x.OrderType),
                                x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                                ParseOrderStatus(x.Status),
                                x.CreateTime)
                            {
                                ClientOrderId = x.ClientOrderId,
                                OrderPrice = x.Price,
                                OrderQuantity = new SharedOrderQuantity(x.MarketUnit == null || x.MarketUnit == MarketUnit.BaseAsset ? x.Quantity : null, x.MarketUnit == MarketUnit.QuoteAsset ? x.Quantity : null),
                                QuantityFilled = new SharedOrderQuantity(x.QuantityFilled, x.ValueFilled),
                                UpdateTime = x.UpdateTime,
                                TimeInForce = ParseTimeInForce(x.TimeInForce),
                                FeeAsset = x.FeeAsset,
                                Fee = x.ExecutedFee,
                                AveragePrice = x.AveragePrice == 0 ? null : x.AveragePrice,
                                TriggerPrice = x.TriggerPrice,
                                IsTriggerOrder = x.TriggerPrice != null
                            })
                       .ToArray(), nextPageRequest);
        }

        GetSpotOrderTradesOptions ISpotOrderRestClient.GetSpotOrderTradesOptions { get; } = new GetSpotOrderTradesOptions(_exchangeName, true);
        async Task<HttpResult<SharedUserTrade[]>> ISpotOrderRestClient.GetSpotOrderTradesAsync(GetOrderTradesRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetSpotOrderTradesOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedUserTrade[]>(Exchange, validationError);

            var trades = await Trading.GetUserTradesAsync(Category.Spot, orderId: request.OrderId, ct: ct).ConfigureAwait(false);
            if (!trades.Success)
                return HttpResult.Fail<SharedUserTrade[]>(trades);

            return HttpResult.Ok(trades, trades.Data.List.Select(x => new SharedUserTrade(
                ExchangeSymbolCache.ParseSymbol(_topicSpotId, EnvironmentName, null, x.Symbol), 
                x.Symbol,
                x.OrderId,
                x.TradeId,
                x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                x.Quantity,
                x.Price,
                x.Timestamp)
            {
                ClientOrderId = x.ClientOrderId,
                Fee = x.Fee,
                FeeAsset = x.FeeAsset,
                Role = x.IsMaker ? SharedRole.Maker : SharedRole.Taker
            }).ToArray());
        }

        GetSpotUserTradesOptions ISpotOrderRestClient.GetSpotUserTradesOptions { get; } = new GetSpotUserTradesOptions(_exchangeName, false, true, true, 100);
        async Task<HttpResult<SharedUserTrade[]>> ISpotOrderRestClient.GetSpotUserTradesAsync(GetUserTradesRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var validationError = SharedClient.GetSpotUserTradesOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedUserTrade[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var limit = request.Limit ?? 50;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest, true, TimeSpan.FromDays(7));

            // Get data
            var result = await Trading.GetUserTradesAsync(
                Category.Spot,
                symbol: request.Symbol?.GetSymbol(FormatSymbol),
                startTime: pageParams.StartTime,
                endTime: pageParams.EndTime,
                limit: limit,
                cursor: pageParams.Cursor,
                ct: ct).ConfigureAwait(false);
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
                                ExchangeSymbolCache.ParseSymbol(_topicSpotId, EnvironmentName, null, x.Symbol), 
                                x.Symbol,
                                x.OrderId,
                                x.TradeId,
                                x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                                x.Quantity,
                                x.Price,
                                x.Timestamp)
                            {
                                ClientOrderId = x.ClientOrderId,
                                Fee = x.Fee,
                                FeeAsset = x.FeeAsset,
                                Role = x.IsMaker ? SharedRole.Maker : SharedRole.Taker
                            }).ToArray(), nextPageRequest);
        }

        CancelSpotOrderOptions ISpotOrderRestClient.CancelSpotOrderOptions { get; } = new CancelSpotOrderOptions(_exchangeName, true);
        async Task<HttpResult<SharedId>> ISpotOrderRestClient.CancelSpotOrderAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.CancelSpotOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var order = await Trading.CancelOrderAsync(Category.Spot, request.Symbol!.GetSymbol(FormatSymbol), request.OrderId, ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return HttpResult.Fail<SharedId>(order);

            return HttpResult.Ok(order, new SharedId(order.Data.OrderId));
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

        #endregion

        #region Spot Client Id Order Client

        GetSpotOrderByClientOrderIdOptions ISpotOrderClientIdRestClient.GetSpotOrderByClientOrderIdOptions { get; } = new GetSpotOrderByClientOrderIdOptions(_exchangeName, true);
        async Task<HttpResult<SharedSpotOrder>> ISpotOrderClientIdRestClient.GetSpotOrderByClientOrderIdAsync(GetOrderRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetSpotOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedSpotOrder>(Exchange, validationError);

            var orders = await Trading.GetOrdersAsync(Category.Spot, clientOrderId: request.OrderId, ct: ct).ConfigureAwait(false);
            if (!orders.Success)
                return HttpResult.Fail<SharedSpotOrder>(orders);

            if (!orders.Data.List.Any())
                return HttpResult.Fail<SharedSpotOrder>(Exchange, new ServerError(new ErrorInfo(ErrorType.UnknownOrder, "Order not found")));

            var order = orders.Data.List.Single();
            return HttpResult.Ok(orders, new SharedSpotOrder(
                ExchangeSymbolCache.ParseSymbol(_topicSpotId, EnvironmentName, null, order.Symbol),
                order.Symbol,
                order.OrderId.ToString(),
                ParseOrderType(order.OrderType),
                order.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                ParseOrderStatus(order.Status),
                order.CreateTime)
            {
                ClientOrderId = order.ClientOrderId,
                OrderPrice = order.Price,
                OrderQuantity = new SharedOrderQuantity(order.MarketUnit == null || order.MarketUnit == MarketUnit.BaseAsset ? order.Quantity : null, order.MarketUnit == MarketUnit.QuoteAsset ? order.Quantity : null),
                QuantityFilled = new SharedOrderQuantity(order.QuantityFilled, order.ValueFilled),
                UpdateTime = order.UpdateTime,
                TimeInForce = ParseTimeInForce(order.TimeInForce),
                FeeAsset = order.FeeAsset,
                Fee = order.ExecutedFee,
                AveragePrice = order.AveragePrice == 0 ? null : order.AveragePrice,
                TriggerPrice = order.TriggerPrice,
                IsTriggerOrder = order.TriggerPrice != null
            });
        }

        CancelSpotOrderByClientOrderIdOptions ISpotOrderClientIdRestClient.CancelSpotOrderByClientOrderIdOptions { get; } = new CancelSpotOrderByClientOrderIdOptions(_exchangeName, true);
        async Task<HttpResult<SharedId>> ISpotOrderClientIdRestClient.CancelSpotOrderByClientOrderIdAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.CancelSpotOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var order = await Trading.CancelOrderAsync(Category.Spot, request.Symbol!.GetSymbol(FormatSymbol), clientOrderId: request.OrderId, ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return HttpResult.Fail<SharedId>(order);

            return HttpResult.Ok(order, new SharedId(order.Data.OrderId));
        }
        #endregion

        #region Asset client
        GetAssetOptions IAssetsRestClient.GetAssetOptions { get; } = new GetAssetOptions(_exchangeName, false);
        async Task<HttpResult<SharedAsset>> IAssetsRestClient.GetAssetAsync(GetAssetRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetAssetOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedAsset>(Exchange, validationError);

            var assets = await Account.GetAssetInfoAsync(request.Asset, ct: ct).ConfigureAwait(false);
            if (!assets.Success)
                return HttpResult.Fail<SharedAsset>(assets);

            var asset = assets.Data.Assets.SingleOrDefault();
            if (asset == null)
                return HttpResult.Fail<SharedAsset>(assets, new ServerError(new ErrorInfo(ErrorType.UnknownAsset, "Asset not found")));

            return HttpResult.Ok(assets, new SharedAsset(asset.Name)
            {
                Networks = asset.Networks.Select(x => new SharedAssetNetwork(x.Network)
                {
                    MinConfirmations = x.Confirmation,
                    DepositEnabled = x.NetworkDeposit,
                    MinWithdrawQuantity = x.MinWithdraw,
                    WithdrawEnabled = x.NetworkWithdraw,
                    WithdrawFee = x.WithdrawFee,
                    ContractAddress = x.ContractAddress
                }).ToArray()
            });
        }

        GetAssetsOptions IAssetsRestClient.GetAssetsOptions { get; } = new GetAssetsOptions(_exchangeName, true);
        async Task<HttpResult<SharedAsset[]>> IAssetsRestClient.GetAssetsAsync(GetAssetsRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetAssetsOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedAsset[]>(Exchange, validationError);

            var assets = await Account.GetAssetInfoAsync(ct: ct).ConfigureAwait(false);
            if (!assets.Success)
                return HttpResult.Fail<SharedAsset[]>(assets);

            return HttpResult.Ok(assets, assets.Data.Assets.Select(x => new SharedAsset(x.Name)
            {
                Networks = x.Networks.Select(x => new SharedAssetNetwork(x.Network)
                {
                    MinConfirmations = x.Confirmation,
                    DepositEnabled = x.NetworkDeposit,
                    MinWithdrawQuantity = x.MinWithdraw,
                    WithdrawEnabled = x.NetworkWithdraw,
                    WithdrawFee = x.WithdrawFee,
                    ContractAddress = x.ContractAddress
                }).ToArray()
            }).ToArray());
        }

        #endregion

        #region Deposit client
        GetDepositAddressesOptions IDepositRestClient.GetDepositAddressesOptions { get; } = new GetDepositAddressesOptions(_exchangeName, true);

        async Task<HttpResult<SharedDepositAddress[]>> IDepositRestClient.GetDepositAddressesAsync(GetDepositAddressesRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetDepositAddressesOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedDepositAddress[]>(Exchange, validationError);

            var depositAddresses = await Account.GetDepositAddressAsync(request.Asset, request.Network).ConfigureAwait(false);
            if (!depositAddresses.Success)
                return HttpResult.Fail<SharedDepositAddress[]>(depositAddresses);

            return HttpResult.Ok(depositAddresses, depositAddresses.Data.Networks.Select(x => new SharedDepositAddress(depositAddresses.Data.Asset, x.DepositAddress)
            {
                TagOrMemo = x.DepositTag,
                Network = x.Network,
            }
            ).ToArray());
        }

        GetDepositsOptions IDepositRestClient.GetDepositsOptions { get; } = new GetDepositsOptions(_exchangeName, false, true, true, 50);
        async Task<HttpResult<SharedDeposit[]>> IDepositRestClient.GetDepositsAsync(GetDepositsRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var validationError = SharedClient.GetDepositsOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedDeposit[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var limit = request.Limit ?? 50;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest, true, TimeSpan.FromDays(30));

            // Get data
            var result = await Account.GetDepositsAsync(
                startTime: pageParams.StartTime,
                endTime: pageParams.EndTime,
                asset: request.Asset,
                limit: limit,
                cursor: pageParams.Cursor,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedDeposit[]>(result);

            var nextPageRequest = Pagination.GetNextPageRequest(
                () => result.Data.NextPageCursor == null ? null : Pagination.NextPageFromCursor(result.Data.NextPageCursor),
                result.Data.Deposits.Length,
                result.Data.Deposits.Select(x => x.SuccessTime ?? default),
                request.StartTime,
                request.EndTime ?? DateTime.UtcNow,
                pageParams,
                TimeSpan.FromDays(30));

            return HttpResult.Ok(result, ExchangeHelpers.ApplyFilter(result.Data.Deposits, x => x.SuccessTime ?? default, request.StartTime, request.EndTime, direction)
                       .Select(x => 
                            new SharedDeposit(
                                x.Asset, 
                                x.Quantity, 
                                x.Status == DepositStatus.Success,
                                x.SuccessTime ?? new DateTime(),
                                ParseTransferStatus(x.Status))
                            {
                                Network = x.Network,
                                TransactionId = x.TransactionId,
                            })
                       .ToArray(), nextPageRequest);
        }

        private SharedTransferStatus ParseTransferStatus(DepositStatus status)
        {
            if (status == DepositStatus.Success)
                return SharedTransferStatus.Completed;
            if (status == DepositStatus.DepositFailed)
                return SharedTransferStatus.Failed;
            if (status == DepositStatus.Processing || status == DepositStatus.ToBeConfirmed)
                return SharedTransferStatus.InProgress;

            return SharedTransferStatus.Unknown;
        }

        #endregion

        #region Order Book client

        GetOrderBookOptions IOrderBookRestClient.GetOrderBookOptions { get; } = new GetOrderBookOptions(_exchangeName, 1, 500, false);
        async Task<HttpResult<SharedOrderBook>> IOrderBookRestClient.GetOrderBookAsync(GetOrderBookRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetOrderBookOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedOrderBook>(Exchange, validationError);

            var category = request.Symbol!.TradingMode == TradingMode.Spot ? Category.Spot : (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var result = await ExchangeData.GetOrderbookAsync(
                category,
                request.Symbol!.GetSymbol(FormatSymbol),
                limit: request.Limit ?? 20,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedOrderBook>(result);

            return HttpResult.Ok(result, new SharedOrderBook(result.Data.Asks, result.Data.Bids));
        }

        #endregion

        #region Withdrawal client

        GetWithdrawalsOptions IWithdrawalRestClient.GetWithdrawalsOptions { get; } = new GetWithdrawalsOptions(_exchangeName, false, true, true, 50);
        async Task<HttpResult<SharedWithdrawal[]>> IWithdrawalRestClient.GetWithdrawalsAsync(GetWithdrawalsRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var validationError = SharedClient.GetWithdrawalsOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedWithdrawal[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var limit = request.Limit ?? 50;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest, true, TimeSpan.FromDays(30));

            // Get data
            var result = await Account.GetWithdrawalsAsync(
                startTime: pageParams.StartTime,
                endTime: pageParams.EndTime,
                asset: request.Asset,
                limit: limit,
                cursor: pageParams.Cursor,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedWithdrawal[]>(result);

            var nextPageRequest = Pagination.GetNextPageRequest(
                () => result.Data.NextPageCursor == null ? null : Pagination.NextPageFromCursor(result.Data.NextPageCursor),
                result.Data.List.Length,
                result.Data.List.Select(x => x.CreateTime),
                request.StartTime,
                request.EndTime ?? DateTime.UtcNow,
                pageParams,
                TimeSpan.FromDays(30));

            return HttpResult.Ok(result, ExchangeHelpers.ApplyFilter(result.Data.List, x => x.CreateTime, request.StartTime, request.EndTime, direction)
                       .Select(x => 
                            new SharedWithdrawal(
                                x.Asset,
                                x.ToAddress, 
                                x.Quantity, 
                                x.Status == WithdrawalStatus.Success, 
                                x.CreateTime,
                                GetWithdrawalStatus(x))
                            {
                                Id = x.Id,
                                Network = x.Network,
                                Tag = x.Tag,
                                TransactionId = x.TransactionId,
                                Fee = x.WithdrawFee
                            })
                       .ToArray(), nextPageRequest);
        }

        private SharedTransferStatus GetWithdrawalStatus(BybitWithdrawal x)
        {
            if (x.Status == WithdrawalStatus.Failed || x.Status == WithdrawalStatus.CanceledByUser || x.Status == WithdrawalStatus.Rejected)
                return SharedTransferStatus.Failed;

            if (x.Status == WithdrawalStatus.Success)
                return SharedTransferStatus.Completed;

            if (x.Status == WithdrawalStatus.BlockchainConfirmed
                || x.Status == WithdrawalStatus.MoreInformationRequired
                || x.Status == WithdrawalStatus.Pending
                || x.Status == WithdrawalStatus.SecurityCheck)
            {
                return SharedTransferStatus.InProgress;
            }

            return SharedTransferStatus.Unknown;
        }

        #endregion

        #region Withdraw client

        WithdrawOptions IWithdrawRestClient.WithdrawOptions { get; } = new WithdrawOptions(_exchangeName)
        {
            RequiredOptionalParameters = new List<ParameterDescription>
            {
                new ParameterDescription(nameof(WithdrawRequest.Network), typeof(string), "The network the withdrawal should use", "ETH")
            }
        };

        async Task<HttpResult<SharedId>> IWithdrawRestClient.WithdrawAsync(WithdrawRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.WithdrawOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            // Get data
            var withdrawal = await Account.WithdrawAsync(
                request.Asset,
                toAddress: request.Address,
                quantity: request.Quantity,
                network: request.Network!,
                tag: request.AddressTag,
                accountType: WithdrawAccountType.FundAndUta,
                ct: ct).ConfigureAwait(false);
            if (!withdrawal.Success)
                return HttpResult.Fail<SharedId>(withdrawal);

            return HttpResult.Ok(withdrawal, new SharedId(withdrawal.Data.Id));
        }

        #endregion

        #region Futures Ticker client

        GetFuturesTickerOptions IFuturesTickerRestClient.GetFuturesTickerOptions { get; } = new GetFuturesTickerOptions(_exchangeName);
        async Task<HttpResult<SharedFuturesTicker>> IFuturesTickerRestClient.GetFuturesTickerAsync(GetTickerRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetFuturesTickerOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesTicker>(Exchange, validationError);

            var category = (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var resultTicker = await ExchangeData.GetLinearInverseTickersAsync(category, request.Symbol!.GetSymbol(FormatSymbol), ct: ct).ConfigureAwait(false);
            if (!resultTicker.Success)
                return HttpResult.Fail<SharedFuturesTicker>(resultTicker);

            var symbol = resultTicker.Data.List.SingleOrDefault();
            if (symbol == null)
                return HttpResult.Fail<SharedFuturesTicker>(resultTicker, new ServerError(new ErrorInfo(ErrorType.UnknownSymbol, "Symbol not found")));

            return HttpResult.Ok(resultTicker,
                new SharedFuturesTicker(
                    ExchangeSymbolCache.ParseSymbol(_topicFuturesId, EnvironmentName, null, symbol.Symbol),
                    symbol.Symbol,
                    symbol.LastPrice,
                    symbol.HighPrice24h,
                    symbol.LowPrice24h,
                    symbol.Volume24h,
                    symbol.PriceChangePercentage24h * 100)
                {
                    IndexPrice = symbol.IndexPrice,
                    FundingRate = symbol.FundingRate,
                    MarkPrice = symbol.MarkPrice,
                    NextFundingTime = symbol.NextFundingTime
                });
        }

        GetFuturesTickersOptions IFuturesTickerRestClient.GetFuturesTickersOptions { get; } = new GetFuturesTickersOptions(_exchangeName);

        async Task<HttpResult<SharedFuturesTicker[]>> IFuturesTickerRestClient.GetFuturesTickersAsync(GetTickersRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetFuturesTickersOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesTicker[]>(Exchange, validationError);

            var category = (request.TradingMode == null || request.TradingMode == TradingMode.PerpetualLinear || request.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var resultTicker = await ExchangeData.GetLinearInverseTickersAsync(category, ct: ct).ConfigureAwait(false);
            if (!resultTicker.Success)
                return HttpResult.Fail<SharedFuturesTicker[]>(resultTicker);

            return HttpResult.Ok(resultTicker,
                resultTicker.Data.List.Select(x =>
             new SharedFuturesTicker(ExchangeSymbolCache.ParseSymbol(_topicFuturesId, EnvironmentName, null, x.Symbol), x.Symbol, x.LastPrice, x.HighPrice24h, x.LowPrice24h, x.Volume24h, x.PriceChangePercentage24h * 100)
             {
                 FundingRate = x.FundingRate,
                 IndexPrice = x.IndexPrice,
                 MarkPrice = x.MarkPrice,
                 NextFundingTime = x.NextFundingTime
             }
            ).ToArray());
        }

        #endregion

        #region Futures Symbol client

        GetFuturesSymbolsOptions IFuturesSymbolRestClient.GetFuturesSymbolsOptions { get; } = new GetFuturesSymbolsOptions(_exchangeName, false);
        async Task<HttpResult<SharedFuturesSymbol[]>> IFuturesSymbolRestClient.GetFuturesSymbolsAsync(GetSymbolsRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetFuturesSymbolsOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesSymbol[]>(Exchange, validationError);

            var category = (request.TradingMode == null || request.TradingMode == TradingMode.PerpetualLinear || request.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var result = await ExchangeData.GetLinearInverseSymbolsAsync(category, limit: 1000, ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedFuturesSymbol[]>(result);

            IEnumerable<BybitLinearInverseSymbol> data = result.Data.List;
            if (request.TradingMode != null)
            {
                data = data.Where(x =>
                    request.TradingMode == TradingMode.PerpetualLinear ? x.ContractType == ContractTypeV5.LinearPerpetual :
                    request.TradingMode == TradingMode.PerpetualInverse ? x.ContractType == ContractTypeV5.InversePerpetual :
                    request.TradingMode == TradingMode.DeliveryLinear ? x.ContractType == ContractTypeV5.LinearFutures :
                    x.ContractType == ContractTypeV5.InverseFutures);
            }

            var response = HttpResult.Ok(result, data.Select(s => new SharedFuturesSymbol(
                s.ContractType == ContractTypeV5.LinearPerpetual ? TradingMode.PerpetualLinear:
                s.ContractType == ContractTypeV5.InversePerpetual ? TradingMode.PerpetualInverse:
                s.ContractType == ContractTypeV5.LinearFutures ? TradingMode.DeliveryLinear :
                TradingMode.DeliveryInverse,
                s.BaseAsset, s.QuoteAsset, s.Name, s.Status == SymbolStatus.Trading)
            {
                MinTradeQuantity = s.LotSizeFilter?.MinOrderQuantity,
                MinNotionalValue = s.LotSizeFilter?.MinNotionalValue,
                PriceStep = s.PriceFilter?.TickSize,
                QuantityStep = s.LotSizeFilter?.QuantityStep,
                DeliveryTime = s.DeliveryTime,
                ContractSize = 1,
                MaxLongLeverage = s.LeverageFilter?.MaxLeverage,
                MaxShortLeverage = s.LeverageFilter?.MaxLeverage
            }).ToArray());

            ExchangeSymbolCache.UpdateSymbolInfo(_topicFuturesId, EnvironmentName, null, response.Data!);
            return response;
        }

        async Task<ExchangeCallResult<SharedSymbol[]>> IFuturesSymbolRestClient.GetFuturesSymbolsForBaseAssetAsync(string baseAsset)
        {
            if (!ExchangeSymbolCache.HasCached(_topicFuturesId, EnvironmentName, null))
            {
                var symbols = await ((IFuturesSymbolRestClient)this).GetFuturesSymbolsAsync(new GetSymbolsRequest()).ConfigureAwait(false);
                if (!symbols.Success)
                    return ExchangeCallResult<SharedSymbol[]>.Fail(Exchange, symbols.Error!);
            }

            return ExchangeCallResult<SharedSymbol[]>.Ok(Exchange, ExchangeSymbolCache.GetSymbolsForBaseAsset(_topicFuturesId, EnvironmentName, null, baseAsset));
        }

        async Task<ExchangeCallResult<bool>> IFuturesSymbolRestClient.SupportsFuturesSymbolAsync(SharedSymbol symbol)
        {
            if (symbol.TradingMode == TradingMode.Spot)
                throw new ArgumentException(nameof(symbol), "Spot symbols not allowed");

            if (!ExchangeSymbolCache.HasCached(_topicFuturesId, EnvironmentName, null))
            {
                var symbols = await ((IFuturesSymbolRestClient)this).GetFuturesSymbolsAsync(new GetSymbolsRequest()).ConfigureAwait(false);
                if (!symbols.Success)
                    return ExchangeCallResult<bool>.Fail(Exchange, symbols.Error!);
            }

            return ExchangeCallResult<bool>.Ok(Exchange, ExchangeSymbolCache.SupportsSymbol(_topicFuturesId, EnvironmentName, null, symbol));
        }

        async Task<ExchangeCallResult<bool>> IFuturesSymbolRestClient.SupportsFuturesSymbolAsync(string symbolName)
        {
            if (!ExchangeSymbolCache.HasCached(_topicFuturesId, EnvironmentName, null))
            {
                var symbols = await ((IFuturesSymbolRestClient)this).GetFuturesSymbolsAsync(new GetSymbolsRequest()).ConfigureAwait(false);
                if (!symbols.Success)
                    return ExchangeCallResult<bool>.Fail(Exchange, symbols.Error!);
            }

            return ExchangeCallResult<bool>.Ok(Exchange, ExchangeSymbolCache.SupportsSymbol(_topicFuturesId, EnvironmentName, null, symbolName));
        }
        #endregion

        #region Leverage client
        SharedLeverageSettingMode ILeverageRestClient.LeverageSettingType => SharedLeverageSettingMode.PerSymbol;

        GetLeverageOptions ILeverageRestClient.GetLeverageOptions { get; } = new GetLeverageOptions(_exchangeName, true);
        async Task<HttpResult<SharedLeverage>> ILeverageRestClient.GetLeverageAsync(GetLeverageRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetLeverageOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedLeverage>(Exchange, validationError);

            var category = (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var result = await Trading.GetPositionsAsync(
                category,
                symbol: request.Symbol!.GetSymbol(FormatSymbol),
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedLeverage>(result);

            var position = result.Data.List.SingleOrDefault(x => x.PositionIdx == (request.PositionSide == null ? PositionIdx.OneWayMode : request.PositionSide == SharedPositionSide.Short ? PositionIdx.SellHedgeMode : PositionIdx.BuyHedgeMode));

            return HttpResult.Ok(result, new SharedLeverage(position?.Leverage ?? 0)
            {
                Side = request.PositionSide
            });
        }

        SetLeverageOptions ILeverageRestClient.SetLeverageOptions { get; } = new SetLeverageOptions(_exchangeName);
        async Task<HttpResult<SharedLeverage>> ILeverageRestClient.SetLeverageAsync(SetLeverageRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.SetLeverageOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedLeverage>(Exchange, validationError);

            var category = (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var result = await Account.SetLeverageAsync(
                category,
                symbol: request.Symbol!.GetSymbol(FormatSymbol),
                request.Leverage,
                request.Leverage,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedLeverage>(result);

            return HttpResult.Ok(result, new SharedLeverage(request.Leverage)
            {
                Side = request.Side
            });
        }
        #endregion

        #region Mark Klines client

        GetMarkPriceKlinesOptions IMarkPriceKlineRestClient.GetMarkPriceKlinesOptions { get; } = new GetMarkPriceKlinesOptions(_exchangeName, false, true, true, 1000, false);

        async Task<HttpResult<SharedFuturesKline[]>> IMarkPriceKlineRestClient.GetMarkPriceKlinesAsync(GetKlinesRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var interval = (KlineInterval)request.Interval;

            var validationError = SharedClient.GetMarkPriceKlinesOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesKline[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var symbol = request.Symbol!.GetSymbol(FormatSymbol);
            var limit = request.Limit ?? 1000;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest, true);

            var category = (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var result = await ExchangeData.GetMarkPriceKlinesAsync(
                category,
                symbol,
                interval,
                startTime: pageParams.StartTime,
                endTime: pageParams.EndTime,
                limit: limit,
                ct: ct
                ).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedFuturesKline[]>(result);

            var nextPageRequest = Pagination.GetNextPageRequest(
                    () => Pagination.NextPageFromTime(pageParams, result.Data.List.Min(x => x.StartTime)),
                    result.Data.List.Length,
                    result.Data.List.Select(x => x.StartTime),
                    request.StartTime,
                    request.EndTime ?? DateTime.UtcNow,
                    pageParams);

            return HttpResult.Ok(result, ExchangeHelpers.ApplyFilter(result.Data.List, x => x.StartTime, request.StartTime, request.EndTime, direction)
                   .Select(x => 
                        new SharedFuturesKline(
                            request.Symbol,
                            symbol,
                            x.StartTime,
                            x.ClosePrice,
                            x.HighPrice,
                            x.LowPrice,
                            x.OpenPrice))
                   .ToArray(), nextPageRequest);
        }

        #endregion

        #region Index Klines client

        GetIndexPriceKlinesOptions IIndexPriceKlineRestClient.GetIndexPriceKlinesOptions { get; } = new GetIndexPriceKlinesOptions(_exchangeName, false, true, true, 50, false);

        async Task<HttpResult<SharedFuturesKline[]>> IIndexPriceKlineRestClient.GetIndexPriceKlinesAsync(GetKlinesRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var interval = (KlineInterval)request.Interval;

            var validationError = SharedClient.GetMarkPriceKlinesOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesKline[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var symbol = request.Symbol!.GetSymbol(FormatSymbol);
            var limit = request.Limit ?? 1000;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest, true);

            var category = (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var result = await ExchangeData.GetIndexPriceKlinesAsync(
                category,
                symbol,
                interval,
                startTime: pageParams.StartTime,
                endTime: pageParams.EndTime,
                limit: limit,
                ct: ct
                ).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedFuturesKline[]>(result);

            var nextPageRequest = Pagination.GetNextPageRequest(
                    () => Pagination.NextPageFromTime(pageParams, result.Data.List.Min(x => x.StartTime)),
                    result.Data.List.Length,
                    result.Data.List.Select(x => x.StartTime),
                    request.StartTime,
                    request.EndTime ?? DateTime.UtcNow,
                    pageParams);

            return HttpResult.Ok(result, ExchangeHelpers.ApplyFilter(result.Data.List, x => x.StartTime, request.StartTime, request.EndTime, direction)
                   .Select(x =>
                        new SharedFuturesKline(
                            request.Symbol,
                            symbol,
                            x.StartTime,
                            x.ClosePrice,
                            x.HighPrice,
                            x.LowPrice,
                            x.OpenPrice))
                   .ToArray(), nextPageRequest);
        }

        #endregion

        #region Open Interest client

        GetOpenInterestOptions IOpenInterestRestClient.GetOpenInterestOptions { get; } = new GetOpenInterestOptions(_exchangeName, true);
        async Task<HttpResult<SharedOpenInterest>> IOpenInterestRestClient.GetOpenInterestAsync(GetOpenInterestRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetOpenInterestOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedOpenInterest>(Exchange, validationError);

            var category = (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var result = await ExchangeData.GetLinearInverseTickersAsync(
                category,
                request.Symbol!.GetSymbol(FormatSymbol),
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedOpenInterest>(result);

            return HttpResult.Ok(result, new SharedOpenInterest(result.Data.List.Single().OpenInterest ?? 0));
        }

        #endregion

        #region Funding Rate client
        GetFundingRateHistoryOptions IFundingRateRestClient.GetFundingRateHistoryOptions { get; } = new GetFundingRateHistoryOptions(_exchangeName, false, true, true, 200, false);

        async Task<HttpResult<SharedFundingRate[]>> IFundingRateRestClient.GetFundingRateHistoryAsync(GetFundingRateHistoryRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var validationError = SharedClient.GetFundingRateHistoryOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFundingRate[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var symbol = request.Symbol!.GetSymbol(FormatSymbol);
            var limit = request.Limit ?? 200;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest, true);

            // Get data
            var category = (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var result = await ExchangeData.GetFundingRateHistoryAsync(
                category,
                symbol,
                startTime: pageParams.StartTime,
                endTime: pageParams.EndTime,
                limit: limit,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedFundingRate[]>(result);

            var nextPageRequest = Pagination.GetNextPageRequest(
                    () => Pagination.NextPageFromTime(pageParams, result.Data.List.Min(x => x.Timestamp)),
                    result.Data.List.Length,
                    result.Data.List.Select(x => x.Timestamp),
                    request.StartTime,
                    request.EndTime ?? DateTime.UtcNow,
                    pageParams);

            return HttpResult.Ok(result, ExchangeHelpers.ApplyFilter(result.Data.List, x => x.Timestamp, request.StartTime, request.EndTime, direction)
                   .Select(x =>
                        new SharedFundingRate(x.FundingRate, x.Timestamp))
                   .ToArray(), nextPageRequest);
        }
        #endregion

        #region Futures Order Client

        SharedFeeDeductionType IFuturesOrderRestClient.FuturesFeeDeductionType => SharedFeeDeductionType.AddToCost;
        SharedFeeAssetType IFuturesOrderRestClient.FuturesFeeAssetType => SharedFeeAssetType.InputAsset;
        SharedOrderType[] IFuturesOrderRestClient.FuturesSupportedOrderTypes { get; } = new[] { SharedOrderType.Limit, SharedOrderType.Market };
        SharedTimeInForce[] IFuturesOrderRestClient.FuturesSupportedTimeInForce { get; } = new[] { SharedTimeInForce.GoodTillCanceled, SharedTimeInForce.ImmediateOrCancel, SharedTimeInForce.FillOrKill };
        SharedQuantitySupport IFuturesOrderRestClient.FuturesSupportedOrderQuantity { get; } = new SharedQuantitySupport(
                SharedQuantityType.BaseAsset,
                SharedQuantityType.BaseAsset,
                SharedQuantityType.BaseAsset,
                SharedQuantityType.BaseAsset);

        string IFuturesOrderRestClient.GenerateClientOrderId() => ExchangeHelpers.RandomString(32);

        PlaceFuturesOrderOptions IFuturesOrderRestClient.PlaceFuturesOrderOptions { get; } = new PlaceFuturesOrderOptions(_exchangeName, true);
        async Task<HttpResult<SharedId>> IFuturesOrderRestClient.PlaceFuturesOrderAsync(PlaceFuturesOrderRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.PlaceFuturesOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var category = request.Symbol!.TradingMode.IsLinear() ? Category.Linear : Category.Inverse;
            var result = await Trading.PlaceOrderAsync(
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

        GetFuturesOrderOptions IFuturesOrderRestClient.GetFuturesOrderOptions { get; } = new GetFuturesOrderOptions(_exchangeName, true);
        async Task<HttpResult<SharedFuturesOrder>> IFuturesOrderRestClient.GetFuturesOrderAsync(GetOrderRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetFuturesOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesOrder>(Exchange, validationError);

            var category = (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var orders = await Trading.GetOrdersAsync(category, symbol: request.Symbol!.GetSymbol(FormatSymbol), orderId: request.OrderId, ct: ct).ConfigureAwait(false);
            if (!orders.Success)
                return HttpResult.Fail<SharedFuturesOrder>(orders);

            var order = orders.Data.List.SingleOrDefault();
            if (order == null)
                return HttpResult.Fail<SharedFuturesOrder>(orders, new ServerError(new ErrorInfo(ErrorType.UnknownOrder, "Order not found")));

            return HttpResult.Ok(orders, new SharedFuturesOrder(
                ExchangeSymbolCache.ParseSymbol(_topicFuturesId, EnvironmentName, null, order.Symbol),
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
                Fee = order.ExecutedFee,
                FeeAsset = order.FeeAsset,
                TriggerPrice = order.TriggerPrice,
                StopLossPrice = order.StopLoss,
                TakeProfitPrice = order.TakeProfit,
                IsTriggerOrder = order.TriggerPrice > 0
            });
        }

        GetOpenFuturesOrdersOptions IFuturesOrderRestClient.GetOpenFuturesOrdersOptions { get; } = new GetOpenFuturesOrdersOptions(_exchangeName, true)
        {
            OptionalExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription(["SettleAsset", "settleCoin"], typeof(string), "Settlement asset filter", "USDT")
            }
        };
        async Task<HttpResult<SharedFuturesOrder[]>> IFuturesOrderRestClient.GetOpenFuturesOrdersAsync(GetOpenOrdersRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetOpenFuturesOrdersOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesOrder[]>(Exchange, validationError);

            var tradingMode = request.Symbol?.TradingMode ?? request.TradingMode ?? TradingMode.PerpetualLinear;
            var category = (tradingMode == TradingMode.PerpetualLinear || tradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;

            var symbol = request.Symbol?.GetSymbol(FormatSymbol);
            if (symbol == null && request.GetParamValue<string?>(Exchange, "SettleAsset", "settleCoin") == null)
                return HttpResult.Fail<SharedFuturesOrder[]>(Exchange, ArgumentError.Invalid("SettleAsset", "Either the Symbol request parameter or the SettleAsset exchange parameter is required"));

            var orders = await Trading.GetOrdersAsync(
                category,
                symbol,
                openOnly: 0, 
                settleAsset: symbol != null ? null : request.GetParamValue<string?>(Exchange, "SettleAsset", "settleCoin"),
                ct: ct
                ).ConfigureAwait(false);
            if (!orders.Success)
                return HttpResult.Fail<SharedFuturesOrder[]>(orders);

            return HttpResult.Ok(orders, orders.Data.List.Select(x => new SharedFuturesOrder(
                ExchangeSymbolCache.ParseSymbol(_topicFuturesId, EnvironmentName, null, x.Symbol), 
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
                Fee = x.ExecutedFee,
                FeeAsset = x.FeeAsset,
                TriggerPrice = x.TriggerPrice,
                StopLossPrice = x.StopLoss,
                TakeProfitPrice = x.TakeProfit,
                IsTriggerOrder = x.TriggerPrice > 0
            }).ToArray());
        }

        GetFuturesClosedOrdersOptions IFuturesOrderRestClient.GetClosedFuturesOrdersOptions { get; } = new GetFuturesClosedOrdersOptions(_exchangeName, false, true, true, 50);
        async Task<HttpResult<SharedFuturesOrder[]>> IFuturesOrderRestClient.GetClosedFuturesOrdersAsync(GetClosedOrdersRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var validationError = SharedClient.GetClosedFuturesOrdersOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesOrder[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var limit = request.Limit ?? 50;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest, true, TimeSpan.FromDays(7));

            // Get data
            var category = (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var result = await Trading.GetOrderHistoryAsync(
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
                                ExchangeSymbolCache.ParseSymbol(_topicFuturesId, EnvironmentName, null, x.Symbol), 
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
                                Fee = x.ExecutedFee,
                                FeeAsset = x.FeeAsset,
                                TriggerPrice = x.TriggerPrice,
                                StopLossPrice = x.StopLoss,
                                TakeProfitPrice = x.TakeProfit,
                                IsTriggerOrder = x.TriggerPrice > 0
                            })
                       .ToArray(), nextPageRequest);
        }

        GetFuturesOrderTradesOptions IFuturesOrderRestClient.GetFuturesOrderTradesOptions { get; } = new GetFuturesOrderTradesOptions(_exchangeName, true);
        async Task<HttpResult<SharedUserTrade[]>> IFuturesOrderRestClient.GetFuturesOrderTradesAsync(GetOrderTradesRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetFuturesOrderTradesOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedUserTrade[]>(Exchange, validationError);

            var category = (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var orders = await Trading.GetUserTradesAsync(category, orderId: request.OrderId, ct: ct).ConfigureAwait(false);
            if (!orders.Success)
                return HttpResult.Fail<SharedUserTrade[]>(orders);

            return HttpResult.Ok(orders, orders.Data.List.Select(x => new SharedUserTrade(
                ExchangeSymbolCache.ParseSymbol(_topicFuturesId, EnvironmentName, null, x.Symbol), 
                x.Symbol,
                x.OrderId.ToString(),
                x.TradeId,
                x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                x.Quantity,
                x.Price,
                x.Timestamp)
            {
                ClientOrderId = x.ClientOrderId,
                Fee = x.Fee,
                FeeAsset = x.FeeAsset,
                Role = x.IsMaker ? SharedRole.Maker : SharedRole.Taker
            }).ToArray());
        }

        GetFuturesUserTradesOptions IFuturesOrderRestClient.GetFuturesUserTradesOptions { get; } = new GetFuturesUserTradesOptions(_exchangeName, false, true, true, 50);
        async Task<HttpResult<SharedUserTrade[]>> IFuturesOrderRestClient.GetFuturesUserTradesAsync(GetUserTradesRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var validationError = SharedClient.GetFuturesUserTradesOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedUserTrade[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var limit = request.Limit ?? 50;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest, true, TimeSpan.FromDays(7));

            // Get data
            var category = (request.Symbol == null || request.Symbol.TradingMode == TradingMode.PerpetualLinear || request.Symbol.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var result = await Trading.GetUserTradesAsync(
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
                                ExchangeSymbolCache.ParseSymbol(_topicFuturesId, EnvironmentName, null, x.Symbol), 
                                x.Symbol,
                                x.OrderId.ToString(),
                                x.TradeId,
                                x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                                x.Quantity,
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

        CancelFuturesOrderOptions IFuturesOrderRestClient.CancelFuturesOrderOptions { get; } = new CancelFuturesOrderOptions(_exchangeName, true);
        async Task<HttpResult<SharedId>> IFuturesOrderRestClient.CancelFuturesOrderAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.CancelFuturesOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var category = (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var order = await Trading.CancelOrderAsync(category, request.Symbol!.GetSymbol(FormatSymbol), request.OrderId, ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return HttpResult.Fail<SharedId>(order);

            return HttpResult.Ok(order, new SharedId(order.Data.OrderId.ToString()));
        }

        GetPositionsOptions IFuturesOrderRestClient.GetPositionsOptions { get; } = new GetPositionsOptions(_exchangeName, true)
        {
            OptionalExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription(["SettleAsset", "settleCoin"], typeof(string), "Settlement asset filter", "USDT")
            }
        };
        async Task<HttpResult<SharedPosition[]>> IFuturesOrderRestClient.GetPositionsAsync(GetPositionsRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetPositionsOptions.ValidateRequest(request, this);
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

            var result = await Trading.GetPositionsAsync(
                category,
                symbol: symbol,
                settleAsset: symbol != null ? null : settleAsset,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedPosition[]>(result);

            return HttpResult.Ok(result, result.Data.List.Select(x => new SharedPosition(ExchangeSymbolCache.ParseSymbol(_topicFuturesId, EnvironmentName, null, x.Symbol), x.Symbol, x.Quantity, x.UpdateTime)
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

        ClosePositionOptions IFuturesOrderRestClient.ClosePositionOptions { get; } = new ClosePositionOptions(_exchangeName, true)
        {
            RequiredOptionalParameters = new List<ParameterDescription>
            {
                new ParameterDescription(nameof(ClosePositionRequest.PositionSide), typeof(SharedPositionSide), "Side of position to close", SharedPositionSide.Long),
                new ParameterDescription(nameof(ClosePositionRequest.Quantity), typeof(decimal), "Quantity of position to close", 1m)
            }
        };
        async Task<HttpResult<SharedId>> IFuturesOrderRestClient.ClosePositionAsync(ClosePositionRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.ClosePositionOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var category = (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var symbol = request.Symbol!.GetSymbol(FormatSymbol);

            var result = await Trading.PlaceOrderAsync(
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

        GetFuturesOrderByClientOrderIdOptions IFuturesOrderClientIdRestClient.GetFuturesOrderByClientOrderIdOptions { get; } = new GetFuturesOrderByClientOrderIdOptions(_exchangeName, true);
        async Task<HttpResult<SharedFuturesOrder>> IFuturesOrderClientIdRestClient.GetFuturesOrderByClientOrderIdAsync(GetOrderRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetFuturesOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesOrder>(Exchange, validationError);

            var category = (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var orders = await Trading.GetOrdersAsync(category, clientOrderId: request.OrderId, ct: ct).ConfigureAwait(false);
            if (!orders.Success)
                return HttpResult.Fail<SharedFuturesOrder>(orders);

            if (!orders.Data.List.Any())
                return HttpResult.Fail<SharedFuturesOrder>(Exchange, new ServerError(new ErrorInfo(ErrorType.UnknownOrder, "Order not found")));

            var order = orders.Data.List.Single();
            return HttpResult.Ok(orders, new SharedFuturesOrder(
                ExchangeSymbolCache.ParseSymbol(_topicFuturesId, EnvironmentName, null, order.Symbol),
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
                Fee = order.ExecutedFee,
                FeeAsset = order.FeeAsset,
                TriggerPrice = order.TriggerPrice,
                StopLossPrice = order.StopLoss,
                TakeProfitPrice = order.TakeProfit,
                IsTriggerOrder = order.TriggerPrice > 0
            });
        }

        CancelFuturesOrderByClientOrderIdOptions IFuturesOrderClientIdRestClient.CancelFuturesOrderByClientOrderIdOptions { get; } = new CancelFuturesOrderByClientOrderIdOptions(_exchangeName, true);
        async Task<HttpResult<SharedId>> IFuturesOrderClientIdRestClient.CancelFuturesOrderByClientOrderIdAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.CancelFuturesOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var category = (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var order = await Trading.CancelOrderAsync(category, request.Symbol!.GetSymbol(FormatSymbol), clientOrderId: request.OrderId, ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return HttpResult.Fail<SharedId>(order);

            return HttpResult.Ok(order, new SharedId(order.Data.OrderId.ToString()));
        }
        #endregion

        #region Position Mode client

        SharedPositionModeSelection IPositionModeRestClient.PositionModeSettingType => SharedPositionModeSelection.PerSymbol;

        GetPositionModeOptions IPositionModeRestClient.GetPositionModeOptions { get; } = new GetPositionModeOptions(_exchangeName);
        async Task<HttpResult<SharedPositionModeResult>> IPositionModeRestClient.GetPositionModeAsync(GetPositionModeRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetPositionModeOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedPositionModeResult>(Exchange, validationError);

            var tradingMode = request.Symbol?.TradingMode ?? request.TradingMode ?? TradingMode.PerpetualLinear;
            var category = (tradingMode == TradingMode.PerpetualLinear || tradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var result = await Trading.GetPositionsAsync(
                category,
                request.Symbol?.GetSymbol(FormatSymbol),
                limit: 1,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedPositionModeResult>(result);

            if (!result.Data.List.Any())
                return HttpResult.Fail<SharedPositionModeResult>(Exchange, new ServerError(new ErrorInfo(ErrorType.NoPosition, "Position not found")));

            return HttpResult.Ok(result, new SharedPositionModeResult(result.Data.List.Single().PositionIdx == PositionIdx.OneWayMode ? SharedPositionMode.OneWay : SharedPositionMode.HedgeMode));
        }

        SetPositionModeOptions IPositionModeRestClient.SetPositionModeOptions { get; } = new SetPositionModeOptions(_exchangeName);
        async Task<HttpResult<SharedPositionModeResult>> IPositionModeRestClient.SetPositionModeAsync(SetPositionModeRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.SetPositionModeOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedPositionModeResult>(Exchange, validationError);

            var tradingMode = request.Symbol?.TradingMode ?? request.TradingMode ?? TradingMode.PerpetualLinear;
            var category = (tradingMode == TradingMode.PerpetualLinear || tradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var result = await Account.SwitchPositionModeAsync(
                category,
                symbol: request.Symbol?.GetSymbol(FormatSymbol),
                mode: request.PositionMode == SharedPositionMode.HedgeMode ? PositionMode.BothSides : PositionMode.MergedSingle, ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedPositionModeResult>(result);

            return HttpResult.Ok(result, new SharedPositionModeResult(request.PositionMode));
        }
        #endregion

        #region Position History client

        GetPositionHistoryOptions IPositionHistoryRestClient.GetPositionHistoryOptions { get; } = new GetPositionHistoryOptions(_exchangeName, false, true, true, 100);
        async Task<HttpResult<SharedPositionHistory[]>> IPositionHistoryRestClient.GetPositionHistoryAsync(GetPositionHistoryRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var validationError = SharedClient.GetPositionHistoryOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedPositionHistory[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var limit = request.Limit ?? 100;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest);

            // Get data
            var tradingMode = request.Symbol?.TradingMode ?? request.TradingMode ?? TradingMode.PerpetualLinear;
            var category = tradingMode.IsLinear() ? Category.Linear : Category.Inverse;
            var result = await Trading.GetClosedProfitLossAsync(
                category,
                symbol: request.Symbol?.GetSymbol(FormatSymbol),
                startTime: pageParams.StartTime,
                endTime: pageParams.EndTime,
                limit: limit,
                cursor: pageParams.Cursor,
                ct: ct
                ).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedPositionHistory[]>(result);

            var nextPageRequest = Pagination.GetNextPageRequest(
                () => result.Data.NextPageCursor == null ? null : Pagination.NextPageFromCursor(result.Data.NextPageCursor),
                result.Data.List.Length,
                result.Data.List.Select(x => x.CreateTime),
                request.StartTime,
                request.EndTime ?? DateTime.UtcNow,
                pageParams);

            return HttpResult.Ok(result, ExchangeHelpers.ApplyFilter(result.Data.List, x => x.CreateTime, request.StartTime, request.EndTime, direction)
                       .Select(x => 
                            new SharedPositionHistory(
                                ExchangeSymbolCache.ParseSymbol(_topicFuturesId, EnvironmentName, null, x.Symbol), 
                                x.Symbol,
                                x.Side == OrderSide.Sell ? SharedPositionSide.Long : SharedPositionSide.Short,
                                x.AverageEntryPrice,
                                x.AverageExitPrice,
                                x.ClosedSize,
                                x.ClosedPnl,
                                x.UpdateTime)
                            {
                                Leverage = x.Leverage,
                                OrderId = x.OrderId
                            })
                       .ToArray(), nextPageRequest);
        }
        #endregion

        #region Fee Client
        GetFeeOptions IFeeRestClient.GetFeeOptions { get; } = new GetFeeOptions(_exchangeName, true);

        async Task<HttpResult<SharedFee>> IFeeRestClient.GetFeesAsync(GetFeeRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetFeeOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFee>(Exchange, validationError);

            // Get data
            var category = request.Symbol!.TradingMode == TradingMode.Spot ? Category.Spot : (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var result = await Account.GetFeeRateAsync(category, request.Symbol!.GetSymbol(FormatSymbol), ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedFee>(result);

            var symbol = result.Data.List.SingleOrDefault();
            if (symbol == null)
                return HttpResult.Fail<SharedFee>(result, new ServerError(new ErrorInfo(ErrorType.Unknown, "Not found")));

            // Return
            return HttpResult.Ok(result, new SharedFee(symbol.MakerFeeRate * 100, symbol.TakerFeeRate * 100));
        }
        #endregion

        #region Spot Trigger Order Client
        PlaceSpotTriggerOrderOptions ISpotTriggerOrderRestClient.PlaceSpotTriggerOrderOptions { get; } = new PlaceSpotTriggerOrderOptions(_exchangeName, false);

        async Task<HttpResult<SharedId>> ISpotTriggerOrderRestClient.PlaceSpotTriggerOrderAsync(PlaceSpotTriggerOrderRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.PlaceSpotTriggerOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var result = await Trading.PlaceOrderAsync(
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

        GetSpotTriggerOrderOptions ISpotTriggerOrderRestClient.GetSpotTriggerOrderOptions { get; } = new GetSpotTriggerOrderOptions(_exchangeName, true)
        {
        };
        async Task<HttpResult<SharedSpotTriggerOrder>> ISpotTriggerOrderRestClient.GetSpotTriggerOrderAsync(GetOrderRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetSpotTriggerOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedSpotTriggerOrder>(Exchange, validationError);

            var orders = await Trading.GetOrdersAsync(Category.Spot, orderId: request.OrderId, ct: ct).ConfigureAwait(false);
            if (!orders.Success)
                return HttpResult.Fail<SharedSpotTriggerOrder>(orders);

            if (!orders.Data.List.Any())
                return HttpResult.Fail<SharedSpotTriggerOrder>(Exchange, new ServerError(new ErrorInfo(ErrorType.UnknownOrder, "Order not found")));

            var order = orders.Data.List.Single();
            return HttpResult.Ok(orders, new SharedSpotTriggerOrder(
                ExchangeSymbolCache.ParseSymbol(_topicSpotId, EnvironmentName, null, order.Symbol),
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

        CancelSpotTriggerOrderOptions ISpotTriggerOrderRestClient.CancelSpotTriggerOrderOptions { get; } = new CancelSpotTriggerOrderOptions(_exchangeName, true);
        async Task<HttpResult<SharedId>> ISpotTriggerOrderRestClient.CancelSpotTriggerOrderAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.CancelSpotTriggerOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var order = await Trading.CancelOrderAsync(
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

        #region Futures Trigger Order Client
        PlaceFuturesTriggerOrderOptions IFuturesTriggerOrderRestClient.PlaceFuturesTriggerOrderOptions { get; } = new PlaceFuturesTriggerOrderOptions(_exchangeName, false)
        {
            RequiredOptionalParameters = new List<ParameterDescription>
            {
                new ParameterDescription(nameof(PlaceFuturesTriggerOrderRequest.PositionMode), typeof(SharedPositionMode), "The position mode the account is in", SharedPositionMode.OneWay)
            }
        };

        async Task<HttpResult<SharedId>> IFuturesTriggerOrderRestClient.PlaceFuturesTriggerOrderAsync(PlaceFuturesTriggerOrderRequest request, CancellationToken ct)
        {
            var side = GetTriggerOrderSide(request);
            var validationError = SharedClient.PlaceFuturesTriggerOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var category = request.Symbol!.TradingMode.IsLinear() ? Category.Linear : Category.Inverse;
            var result = await Trading.PlaceOrderAsync(
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

        GetFuturesTriggerOrderOptions IFuturesTriggerOrderRestClient.GetFuturesTriggerOrderOptions { get; } = new GetFuturesTriggerOrderOptions(_exchangeName, true)
        {
        };
        async Task<HttpResult<SharedFuturesTriggerOrder>> IFuturesTriggerOrderRestClient.GetFuturesTriggerOrderAsync(GetOrderRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetFuturesTriggerOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesTriggerOrder>(Exchange, validationError);

            var category = request.Symbol!.TradingMode.IsLinear() ? Category.Linear : Category.Inverse;
            var orders = await Trading.GetOrdersAsync(category, orderId: request.OrderId, ct: ct).ConfigureAwait(false);
            if (!orders.Success)
                return HttpResult.Fail<SharedFuturesTriggerOrder>(orders);

            if (!orders.Data.List.Any())
                return HttpResult.Fail<SharedFuturesTriggerOrder>(Exchange, new ServerError(new ErrorInfo(ErrorType.UnknownOrder, "Order not found")));

            var order = orders.Data.List.Single();
            return HttpResult.Ok(orders, new SharedFuturesTriggerOrder(
                ExchangeSymbolCache.ParseSymbol(_topicFuturesId, EnvironmentName, null, order.Symbol),
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

        CancelFuturesTriggerOrderOptions IFuturesTriggerOrderRestClient.CancelFuturesTriggerOrderOptions { get; } = new CancelFuturesTriggerOrderOptions(_exchangeName, true);
        async Task<HttpResult<SharedId>> IFuturesTriggerOrderRestClient.CancelFuturesTriggerOrderAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.CancelFuturesTriggerOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var category = request.Symbol!.TradingMode.IsLinear() ? Category.Linear : Category.Inverse;
            var order = await Trading.CancelOrderAsync(
                category,
                request.Symbol!.GetSymbol(FormatSymbol),
                request.OrderId,
                ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return HttpResult.Fail<SharedId>(order);

            return HttpResult.Ok(order, new SharedId(request.OrderId));
        }

        private OrderSide GetTriggerOrderSide(PlaceFuturesTriggerOrderRequest request)
        {
            if (request.PositionSide == SharedPositionSide.Long)
                return request.OrderDirection == SharedTriggerOrderDirection.Enter ? OrderSide.Buy : OrderSide.Sell;

            return request.OrderDirection == SharedTriggerOrderDirection.Enter ? OrderSide.Sell : OrderSide.Buy;
        }
        #endregion

        #region Tp/SL Client
        SetFuturesTpSlOptions IFuturesTpSlRestClient.SetFuturesTpSlOptions { get; } = new SetFuturesTpSlOptions(_exchangeName, true)
        {
            RequiredOptionalParameters = new List<ParameterDescription>
            {
                new ParameterDescription(nameof(PlaceFuturesTriggerOrderRequest.PositionMode), typeof(SharedPositionMode), "PositionMode the account is in", SharedPositionMode.OneWay)
            }
        };

        async Task<HttpResult<SharedId>> IFuturesTpSlRestClient.SetFuturesTpSlAsync(SetTpSlRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.SetFuturesTpSlOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var category = request.Symbol!.TradingMode.IsLinear() ? Category.Linear : Category.Inverse;
            var result = await Trading.SetTradingStopAsync(
                category,
                request.Symbol!.GetSymbol(FormatSymbol),
                positionIdx: request.PositionMode == SharedPositionMode.OneWay ? PositionIdx.OneWayMode : request.PositionSide == SharedPositionSide.Long ? PositionIdx.BuyHedgeMode : PositionIdx.SellHedgeMode,
                takeProfit: request.TpSlSide == SharedTpSlSide.TakeProfit ? request.TriggerPrice : null,
                takeProfitOrderType: request.TpSlSide == SharedTpSlSide.TakeProfit ? OrderType.Market : null,
                stopLoss: request.TpSlSide == SharedTpSlSide.StopLoss ? request.TriggerPrice : null,
                stopLossOrderType: request.TpSlSide == SharedTpSlSide.StopLoss ? OrderType.Market : null,
                stopLossTakeProfitMode: StopLossTakeProfitMode.Full,
                ct: ct).ConfigureAwait(false);

            if (!result.Success)
                return HttpResult.Fail<SharedId>(result);

            // Return
            return HttpResult.Ok(result, new SharedId(""));
        }

        CancelFuturesTpSlOptions IFuturesTpSlRestClient.CancelFuturesTpSlOptions { get; } = new CancelFuturesTpSlOptions(_exchangeName, true)
        {
            RequiredOptionalParameters = new List<ParameterDescription>
            {
                new ParameterDescription(nameof(CancelTpSlRequest.PositionMode), typeof(SharedPositionMode), "Position mode the account is in", SharedPositionMode.OneWay)
            }
        };

        async Task<HttpResult<bool>> IFuturesTpSlRestClient.CancelFuturesTpSlAsync(CancelTpSlRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.CancelFuturesTpSlOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<bool>(Exchange, validationError);

            var category = request.Symbol!.TradingMode.IsLinear() ? Category.Linear : Category.Inverse;
            var result = await Trading.SetTradingStopAsync(
                category,
                request.Symbol!.GetSymbol(FormatSymbol),
                positionIdx: request.PositionMode == SharedPositionMode.OneWay ? PositionIdx.OneWayMode : request.PositionSide == SharedPositionSide.Long ? PositionIdx.BuyHedgeMode : PositionIdx.SellHedgeMode,
                takeProfit: request.TpSlSide == SharedTpSlSide.TakeProfit ? 0 : null,
                stopLoss: request.TpSlSide == SharedTpSlSide.StopLoss ? 0 : null,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<bool>(result);

            // Return
            return HttpResult.Ok(result, true);
        }

        #endregion

        #region Transfer client

        TransferOptions ITransferRestClient.TransferOptions { get; } = new TransferOptions(_exchangeName, [
            SharedAccountType.Funding,
            SharedAccountType.Unified
            ]);
        async Task<HttpResult<SharedId>> ITransferRestClient.TransferAsync(TransferRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.TransferOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var fromType = GetTransferType(request.FromAccountType);
            var toType = GetTransferType(request.ToAccountType);
            if (fromType == null || toType == null)
                return HttpResult.Fail<SharedId>(Exchange, ArgumentError.Invalid("To/From AccountType", "invalid to/from account combination"));

            // Get data
            var transfer = await Account.CreateInternalTransferAsync(
                request.Asset,
                request.Quantity,
                fromType.Value,
                toType.Value,
                ct: ct).ConfigureAwait(false);
            if (!transfer.Success)
                return HttpResult.Fail<SharedId>(transfer);

            return HttpResult.Ok(transfer, new SharedId(transfer.Data.TransferId));
        }

        private AccountType? GetTransferType(SharedAccountType type)
        {
            if (type == SharedAccountType.Funding) return AccountType.Fund;
            if (type == SharedAccountType.Unified) return AccountType.Unified;
            return null;
        }

        #endregion
    }
}
