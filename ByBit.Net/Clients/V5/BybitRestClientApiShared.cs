using Bybit.Net;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Interfaces.Clients.SpotApi;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis.Interfaces;
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

        async Task<WebCallResult<IEnumerable<SharedKline>>> IKlineRestClient.GetKlinesAsync(GetKlinesRequest request, CancellationToken ct)
        {
            var interval = (Enums.KlineInterval)request.Interval.TotalSeconds;
            if (!Enum.IsDefined(typeof(Enums.KlineInterval), interval))
                return new WebCallResult<IEnumerable<SharedKline>>(new ArgumentError("Interval not supported"));

            var category = request.ApiType == ApiType.Spot ? Enums.Category.Spot : request.ApiType == ApiType.LinearFutures ? Enums.Category.Linear : Enums.Category.Inverse;

            var result = await ExchangeData.GetKlinesAsync(
                category,
                FormatSymbol(request.BaseAsset, request.QuoteAsset, request.ApiType),
                interval,
                request.StartTime,
                request.EndTime,
                request.Limit,
                ct: ct
                ).ConfigureAwait(false);

            if (!result)
                return result.As<IEnumerable<SharedKline>>(default);

            // Reverse as data is returned in desc order instead of standard asc
            return result.As(result.Data.List.Select(x => new SharedKline(x.StartTime, x.ClosePrice, x.HighPrice, x.LowPrice, x.OpenPrice, x.Volume)));
        }

        async Task<WebCallResult<IEnumerable<SharedSpotSymbol>>> ISpotSymbolRestClient.GetSymbolsAsync(SharedRequest request, CancellationToken ct)
        {
            var result = await ExchangeData.GetSpotSymbolsAsync(ct: ct).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<SharedSpotSymbol>>(default);

            return result.As(result.Data.List.Select(s => new SharedSpotSymbol(s.BaseAsset, s.QuoteAsset, s.Name)
            {
                MinTradeQuantity = s.LotSizeFilter?.MinOrderQuantity,
                MaxTradeQuantity = s.LotSizeFilter?.MaxOrderQuantity,
                QuantityStep = s.LotSizeFilter?.BasePrecision,
                PriceStep = s.PriceFilter?.TickSize
            }));
        }

        async Task<WebCallResult<IEnumerable<SharedFuturesSymbol>>> IFuturesSymbolRestClient.GetSymbolsAsync(SharedRequest request, CancellationToken ct)
        {
            var category = request.ApiType == ApiType.Spot ? Enums.Category.Spot : request.ApiType == ApiType.LinearFutures ? Enums.Category.Linear : Enums.Category.Inverse;

            var result = await ExchangeData.GetLinearInverseSymbolsAsync(category, ct: ct).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<SharedFuturesSymbol>>(default);

            return result.As(result.Data.List.Select(s => new SharedFuturesSymbol(s.BaseAsset, s.QuoteAsset, s.Name)
            {
                MinTradeQuantity = s.LotSizeFilter?.MinOrderQuantity,
                MaxTradeQuantity = s.LotSizeFilter?.MaxOrderQuantity,
                QuantityStep = s.LotSizeFilter?.QuantityStep,
                PriceStep = s.PriceFilter?.TickSize
            }));
        }

        async Task<WebCallResult<IEnumerable<SharedTicker>>> ITickerRestClient.GetTickersAsync(SharedRequest request, CancellationToken ct)
        {
            if (request.ApiType == ApiType.Spot)
            {
                var result = await ExchangeData.GetSpotTickersAsync(ct: ct).ConfigureAwait(false);
                if (!result)
                    return result.As<IEnumerable<SharedTicker>>(default);

                return result.As<IEnumerable<SharedTicker>>(result.Data.List.Select(x => new SharedTicker(x.Symbol, x.LastPrice, x.HighPrice24h, x.LowPrice24h)));
            }
            else
            {
                var result = await ExchangeData.GetLinearInverseTickersAsync(request.ApiType == ApiType.InverseFutures ? Enums.Category.Inverse : Enums.Category.Linear, ct: ct).ConfigureAwait(false);
                if (!result)
                    return result.As<IEnumerable<SharedTicker>>(default);
                
                return result.As<IEnumerable<SharedTicker>>(result.Data.List.Select(x => new SharedTicker(x.Symbol, x.LastPrice, x.HighPrice24h, x.LowPrice24h)));
            }
        }

        async Task<WebCallResult<SharedTicker>> ITickerRestClient.GetTickerAsync(GetTickerRequest request, CancellationToken ct)
        {
            if (request.ApiType == ApiType.Spot)
            {
                var result = await ExchangeData.GetSpotTickersAsync(FormatSymbol(request.BaseAsset, request.QuoteAsset, request.ApiType), ct).ConfigureAwait(false);
                if (!result)
                    return result.As<SharedTicker>(default);

                var ticker = result.Data.List.Single();
                return result.As(new SharedTicker(ticker.Symbol, ticker.LastPrice, ticker.HighPrice24h, ticker.LowPrice24h));
            }
            else
            {
                var result = await ExchangeData.GetLinearInverseTickersAsync(
                    request.ApiType == ApiType.InverseFutures ? Enums.Category.Inverse : Enums.Category.Linear,
                    FormatSymbol(request.BaseAsset, request.QuoteAsset, request.ApiType),
                    ct: ct).ConfigureAwait(false);
                if (!result)
                    return result.As<SharedTicker>(default);

                var ticker = result.Data.List.Single();
                return result.As(new SharedTicker(ticker.Symbol, ticker.LastPrice, ticker.HighPrice24h, ticker.LowPrice24h));
            }
        }

        async Task<WebCallResult<IEnumerable<SharedTrade>>> ITradeRestClient.GetTradesAsync(GetTradesRequest request, CancellationToken ct)
        {
            if (request.StartTime != null || request.EndTime != null)
                return new WebCallResult<IEnumerable<SharedTrade>>(new ArgumentError("Start/EndTime filtering not supported"));

            var category = request.ApiType == ApiType.Spot ? Enums.Category.Spot : request.ApiType == ApiType.LinearFutures ? Enums.Category.Linear : Enums.Category.Inverse;

            var result = await ExchangeData.GetTradeHistoryAsync(
                category,
                FormatSymbol(request.BaseAsset, request.QuoteAsset, request.ApiType),
                limit: request.Limit,
                ct: ct).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<SharedTrade>>(default);

            return result.As(result.Data.List.Select(x => new SharedTrade(x.Quantity, x.Price, x.Timestamp)));
        }

        async Task<WebCallResult<IEnumerable<SharedBalance>>> IBalanceRestClient.GetBalancesAsync(SharedRequest request, CancellationToken ct)
        {
            // Assume unified account
            // Inverse futures uses CONTRACT, other UNIFIED
            var accountType = request.ApiType == ApiType.InverseFutures ? Enums.AccountType.Contract : Enums.AccountType.Unified;

            var result = await Account.GetBalancesAsync(accountType, ct: ct).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<SharedBalance>>(default);

            return result.As(result.Data.List.SelectMany(x => x.Assets.Select(x => new SharedBalance(x.Asset, x.WalletBalance, x.Equity ?? 0))));
        }
    }
}
