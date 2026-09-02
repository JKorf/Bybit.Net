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
        #region Spot Ticker client

        Task<HttpResult<SharedSpotTicker[]>> ISpotTickerRestClient.GetSpotTickersAsync(GetTickersRequest request, CancellationToken ct)
            => GetAllSpotTickersAsync(request, ct);
        GetAllSpotTickersOptions ISpotTickerRestClient.GetSpotTickersOptions => GetAllSpotTickersOptions;


        public GetAllSpotTickersOptions GetAllSpotTickersOptions { get; } = new GetAllSpotTickersOptions(_exchangeName);
        public async Task<HttpResult<SharedSpotTicker[]>> GetAllSpotTickersAsync(GetTickersRequest request, CancellationToken ct)
        {
            var validationError = GetAllSpotTickersOptions.ValidateRequest(request, this);
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

        public GetSpotTickerOptions GetSpotTickerOptions { get; } = new GetSpotTickerOptions(_exchangeName);
        public async Task<HttpResult<SharedSpotTicker>> GetSpotTickerAsync(GetTickerRequest request, CancellationToken ct)
        {
            var validationError = GetSpotTickerOptions.ValidateRequest(request, this);
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

        #endregion
    }
}
