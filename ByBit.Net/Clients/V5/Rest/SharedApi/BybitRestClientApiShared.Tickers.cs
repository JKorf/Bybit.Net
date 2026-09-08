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

        #region Get All Tickers

        async Task<ICallResult<SharedTicker[]>> IGetAllTickers.GetAllTickersAsync(GetTickersRequest request, CancellationToken ct)
            => await ((IGetAllTickersRest)this).GetAllTickersAsync(request, ct).ConfigureAwait(false);

        async Task<HttpResult<SharedTicker[]>> IGetAllTickersRest.GetAllTickersAsync(GetTickersRequest request, CancellationToken ct)
        {
            var validationError = GetAllTickersOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedTicker[]>(Exchange, validationError);

            if (request.TradingMode == TradingMode.Spot)
            {
                var result = await GetAllSpotTickersAsync(request, ct).ConfigureAwait(false);
                if (!result.Success)
                    return HttpResult.Fail<SharedTicker[]>(result);

                return HttpResult.Ok<SharedTicker[]>(result, result.Data);
            }
            else
            {
                var result = await GetAllFuturesTickersAsync(request, ct).ConfigureAwait(false);
                if (!result.Success)
                    return HttpResult.Fail<SharedTicker[]>(result);

                return HttpResult.Ok<SharedTicker[]>(result, result.Data);
            }
        }

        Task<HttpResult<SharedSpotTicker[]>> ISpotTickerRestClient.GetSpotTickersAsync(GetTickersRequest request, CancellationToken ct)
            => GetAllSpotTickersAsync(
                request.TradingMode == null ? request with { TradingMode = TradingMode.Spot } : request,
                ct);

        GetAllTickersOptions ISpotTickerRestClient.GetSpotTickersOptions => GetAllTickersOptions;

        Task<HttpResult<SharedFuturesTicker[]>> IFuturesTickerRestClient.GetFuturesTickersAsync(GetTickersRequest request, CancellationToken ct)
            => GetAllFuturesTickersAsync(
                request.TradingMode == null ? request with { TradingMode = TradingMode.PerpetualLinear } : request,
                ct);

        GetAllTickersOptions IFuturesTickerRestClient.GetFuturesTickersOptions => GetAllTickersOptions;

        public GetAllTickersOptions GetAllTickersOptions { get; } = new GetAllTickersOptions(_exchangeName)
        {
            ParameterRuleOverwrites = [
                RequestParameterRuleOverride<GetTickersRequest>.Required(x => x.TradingMode)
                ]
        };

        public async Task<HttpResult<SharedSpotTicker[]>> GetAllSpotTickersAsync(GetTickersRequest request, CancellationToken ct)
        {
            var validationError = GetAllTickersOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedSpotTicker[]>(Exchange, validationError);

            var result = await _api.ExchangeData.GetSpotTickersAsync(ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedSpotTicker[]>(result);

            return HttpResult.Ok(result, result.Data.List.Select(x =>
                new SharedSpotTicker(
                    ExchangeSymbolCache.ParseSymbol(_topicSpotId, _api.EnvironmentName, null, x.Symbol),
                    x.Symbol,
                    x.LastPrice,
                    x.HighPrice24h,
                    x.LowPrice24h,
                    new SharedOrderQuantity(x.Volume24h, x.Turnover24h),
                    x.PriceChangePercentag24h * 100)
                {
                }).ToArray());
        }

        public async Task<HttpResult<SharedFuturesTicker[]>> GetAllFuturesTickersAsync(GetTickersRequest request, CancellationToken ct)
        {
            var validationError = GetAllTickersOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesTicker[]>(Exchange, validationError);

            var category = request.TradingMode == TradingMode.PerpetualLinear || request.TradingMode == TradingMode.DeliveryLinear
                ? Category.Linear
                : Category.Inverse;
            var resultTicker = await _api.ExchangeData.GetLinearInverseTickersAsync(category, ct: ct).ConfigureAwait(false);
            if (!resultTicker.Success)
                return HttpResult.Fail<SharedFuturesTicker[]>(resultTicker);

            var data = request.TradingMode == TradingMode.PerpetualLinear || request.TradingMode == TradingMode.PerpetualInverse
                ? resultTicker.Data.List.Where(x => x.DeliveryTime == null)
                : resultTicker.Data.List.Where(x => x.DeliveryTime != null);

            return HttpResult.Ok(resultTicker,
                data.Select(x =>
             new SharedFuturesTicker(
                 ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, x.Symbol),
                 x.Symbol,
                 x.LastPrice,
                 x.HighPrice24h,
                 x.LowPrice24h,
                 new SharedOrderQuantity(x.Volume24h, x.Turnover24h),
                 x.PriceChangePercentage24h * 100)
             {
                 FundingRate = x.FundingRate,
                 IndexPrice = x.IndexPrice,
                 MarkPrice = x.MarkPrice,
                 NextFundingTime = x.NextFundingTime
             }
            ).ToArray());
        }

        #endregion

        #region Get Ticker

        async Task<ICallResult<SharedTicker>> IGetTicker.GetTickerAsync(GetTickerRequest request, CancellationToken ct)
            => await ((IGetTickerRest)this).GetTickerAsync(request, ct).ConfigureAwait(false);

        async Task<HttpResult<SharedTicker>> IGetTickerRest.GetTickerAsync(GetTickerRequest request, CancellationToken ct)
        {
            if (request.Symbol!.TradingMode == TradingMode.Spot)
            {
                var result = await GetSpotTickerAsync(request, ct).ConfigureAwait(false);
                if (!result.Success)
                    return HttpResult.Fail<SharedTicker>(result);

                return HttpResult.Ok<SharedTicker>(result, result.Data);
            }
            else
            {
                var result = await GetFuturesTickerAsync(request, ct).ConfigureAwait(false);
                if (!result.Success)
                    return HttpResult.Fail<SharedTicker>(result);

                return HttpResult.Ok<SharedTicker>(result, result.Data);
            }
        }

        GetTickerOptions ISpotTickerRestClient.GetSpotTickerOptions => GetTickerOptions;
        GetTickerOptions IFuturesTickerRestClient.GetFuturesTickerOptions => GetTickerOptions;

        public GetTickerOptions GetTickerOptions { get; } = new GetTickerOptions(_exchangeName);
        public async Task<HttpResult<SharedSpotTicker>> GetSpotTickerAsync(GetTickerRequest request, CancellationToken ct)
        {
            var validationError = GetTickerOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedSpotTicker>(Exchange, validationError);

            if (request.Symbol!.TradingMode == TradingMode.Spot)
            {
                var result = await _api.ExchangeData.GetSpotTickersAsync(request.Symbol!.GetSymbol(FormatSymbol), ct).ConfigureAwait(false);
                if (!result.Success)
                    return HttpResult.Fail<SharedSpotTicker>(result);

                var ticker = result.Data.List.Single();
                return HttpResult.Ok(result,
                    new SharedSpotTicker(
                        ExchangeSymbolCache.ParseSymbol(_topicSpotId, _api.EnvironmentName, null, ticker.Symbol),
                        ticker.Symbol,
                        ticker.LastPrice,
                        ticker.HighPrice24h,
                        ticker.LowPrice24h,
                        new SharedOrderQuantity(ticker.Volume24h, ticker.Turnover24h),
                        ticker.PriceChangePercentag24h * 100)
                    {
                    });
            }
            else
            {
                var result = await _api.ExchangeData.GetLinearInverseTickersAsync(
                    (request.Symbol!.TradingMode == TradingMode.DeliveryInverse || request.Symbol!.TradingMode == TradingMode.PerpetualInverse) ? Category.Inverse : Category.Linear,
                    request.Symbol!.GetSymbol(FormatSymbol),
                    ct: ct).ConfigureAwait(false);
                if (!result.Success)
                    return HttpResult.Fail<SharedSpotTicker>(result);

                var ticker = result.Data.List.Single();
                return HttpResult.Ok(result,
                    new SharedSpotTicker(
                        ExchangeSymbolCache.ParseSymbol(_topicSpotId, _api.EnvironmentName, null, ticker.Symbol),
                        ticker.Symbol,
                        ticker.LastPrice,
                        ticker.HighPrice24h,
                        ticker.LowPrice24h,
                        new SharedOrderQuantity(ticker.Volume24h, ticker.Turnover24h),
                        ticker.PriceChangePercentage24h)
                    {
                    });
            }
        }

        public async Task<HttpResult<SharedFuturesTicker>> GetFuturesTickerAsync(GetTickerRequest request, CancellationToken ct)
        {
            var validationError = GetTickerOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesTicker>(Exchange, validationError);

            var category = request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear ? Category.Linear : Category.Inverse;
            var resultTicker = await _api.ExchangeData.GetLinearInverseTickersAsync(category, request.Symbol!.GetSymbol(FormatSymbol), ct: ct).ConfigureAwait(false);
            if (!resultTicker.Success)
                return HttpResult.Fail<SharedFuturesTicker>(resultTicker);

            var symbol = resultTicker.Data.List.SingleOrDefault();
            if (symbol == null)
                return HttpResult.Fail<SharedFuturesTicker>(resultTicker, new ServerError(new ErrorInfo(ErrorType.UnknownSymbol, "Symbol not found")));

            return HttpResult.Ok(resultTicker,
                new SharedFuturesTicker(
                    ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, symbol.Symbol),
                    symbol.Symbol,
                    symbol.LastPrice,
                    symbol.HighPrice24h,
                    symbol.LowPrice24h,
                    new SharedOrderQuantity(symbol.Volume24h, symbol.Turnover24h),
                    symbol.PriceChangePercentage24h * 100)
                {
                    IndexPrice = symbol.IndexPrice,
                    FundingRate = symbol.FundingRate,
                    MarkPrice = symbol.MarkPrice,
                    NextFundingTime = symbol.NextFundingTime
                });
        }

        #endregion

    }
}
