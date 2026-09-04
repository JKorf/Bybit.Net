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
        #region Get Futures Ticker

        async Task<ICallResult<SharedFuturesTicker>> IGetFuturesTicker.GetFuturesTickerAsync(GetTickerRequest request, CancellationToken ct)
            => await GetFuturesTickerAsync(request, ct).ConfigureAwait(false);

        public GetFuturesTickerOptions GetFuturesTickerOptions { get; } = new GetFuturesTickerOptions(_exchangeName);
        public async Task<HttpResult<SharedFuturesTicker>> GetFuturesTickerAsync(GetTickerRequest request, CancellationToken ct)
        {
            var validationError = GetFuturesTickerOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesTicker>(Exchange, validationError);

            var category = (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
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

        #region Get All Futures Tickers

        Task<HttpResult<SharedFuturesTicker[]>> IFuturesTickerRestClient.GetFuturesTickersAsync(GetTickersRequest request, CancellationToken ct)
            => GetAllFuturesTickersAsync(request, ct);

        GetAllFuturesTickersOptions IFuturesTickerRestClient.GetFuturesTickersOptions => GetAllFuturesTickersOptions;

        async Task<ICallResult<SharedFuturesTicker[]>> IGetAllFuturesTickers.GetAllFuturesTickersAsync(GetTickersRequest request, CancellationToken ct)
            => await GetAllFuturesTickersAsync(request, ct).ConfigureAwait(false);

        public GetAllFuturesTickersOptions GetAllFuturesTickersOptions { get; } = new GetAllFuturesTickersOptions(_exchangeName);

        public async Task<HttpResult<SharedFuturesTicker[]>> GetAllFuturesTickersAsync(GetTickersRequest request, CancellationToken ct)
        {
            var validationError = GetAllFuturesTickersOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesTicker[]>(Exchange, validationError);

            var category = (request.TradingMode == null || request.TradingMode == TradingMode.PerpetualLinear || request.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var resultTicker = await _api.ExchangeData.GetLinearInverseTickersAsync(category, ct: ct).ConfigureAwait(false);
            if (!resultTicker.Success)
                return HttpResult.Fail<SharedFuturesTicker[]>(resultTicker);

            return HttpResult.Ok(resultTicker,
                resultTicker.Data.List.Select(x =>
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

    }
}
