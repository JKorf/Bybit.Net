using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.DerivativesApi;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Models;
using Bybit.Net.Objects.Models.Derivatives;
using CryptoExchange.Net;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.DerivativesApi
{
    /// <inheritdoc />
    public class BybitClientDerivativesApiExchangeData : IBybitClientDerivativesApiExchangeData
    {
        private readonly BybitClientDerivativesApi _baseClient;

        internal BybitClientDerivativesApiExchangeData(BybitClientDerivativesApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Get funding rate

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitDerivativesFundingRate>>> GetFundingRateAsync(Category category, string symbol, DateTime? from = null, DateTime? to = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol }
            };

            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(from)!);
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(to)!);
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitList<BybitDerivativesFundingRate>>(_baseClient.GetUrl("derivatives/v3/public/funding/history-funding-rate"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<BybitDerivativesFundingRate>>(default);

            return result.As(result.Data.List);
        }

        #endregion

        #region Get klines

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitKline>>> GetKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime from, DateTime to, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "interval", JsonConvert.SerializeObject(interval, new KlineIntervalConverter(false)) },
                { "start", DateTimeConverter.ConvertToMilliseconds(from)! },
                { "end", DateTimeConverter.ConvertToMilliseconds(to)!}
            };

            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitSymbolCategoryList<BybitDerivativesKlineEntry>>(_baseClient.GetUrl("derivatives/v3/public/kline"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);

            if (!result || result.Data == null)
                return result.As<IEnumerable<BybitKline>>(default);

            return result.As(result.Data.List.Select(item => new BybitKline()
            {
                Symbol = result.Data.Symbol,
                Interval = interval,
                Turnover = item.Turnover,
                Volume = item.Volume,
                ClosePrice = item.Close,
                OpenPrice = item.Open,
                HighPrice = item.High,
                LowPrice = item.Low,
                OpenTime = item.Start
            }));
        }

        #endregion

        #region Get index price klines

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitKline>>> GetIndexPriceKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime from, DateTime to, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "interval", JsonConvert.SerializeObject(interval, new KlineIntervalConverter(false)) },
                { "start", DateTimeConverter.ConvertToMilliseconds(from)! },
                { "end", DateTimeConverter.ConvertToMilliseconds(to)!}
            };

            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitSymbolCategoryList<BybitDerivativesKlineEntry>>(_baseClient.GetUrl("derivatives/v3/public/index-price-kline"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);

            if (!result || result.Data == null)
                return result.As<IEnumerable<BybitKline>>(default);

            return result.As(result.Data.List.Select(item => new BybitKline()
            {
                Symbol = result.Data.Symbol,
                Interval = interval,
                Turnover = item.Turnover,
                Volume = item.Volume,
                ClosePrice = item.Close,
                OpenPrice = item.Open,
                HighPrice = item.High,
                LowPrice = item.Low,
                OpenTime = item.Start
            }));
        }

        #endregion

        #region Get mark price klines

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitKline>>> GetMarkPriceKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime from, DateTime to, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "interval", JsonConvert.SerializeObject(interval, new KlineIntervalConverter(false)) },
                { "start", DateTimeConverter.ConvertToMilliseconds(from)! },
                { "end", DateTimeConverter.ConvertToMilliseconds(to)!}
            };

            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitSymbolCategoryList<BybitUnifiedMarginMarkPriceKlineEntry>>(_baseClient.GetUrl("derivatives/v3/public/mark-price-kline"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);

            if (!result || result.Data == null)
                return result.As<IEnumerable<BybitKline>>(default);

            return result.As(result.Data.List.Select(item => new BybitKline()
            {
                Symbol = result.Data.Symbol,
                Interval = interval,
                ClosePrice = item.Close,
                OpenPrice = item.Open,
                HighPrice = item.High,
                LowPrice = item.Low,
                OpenTime = item.Start
            }));
        }

        #endregion

        #region Get open interest

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitDerivativesOpenInterest>>> GetOpenInterestAsync(Category category, string symbol, OpenInterestInterval interval, DataPeriod period, DateTime? from = null, DateTime? to = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "interval", EnumConverter.GetString(interval) },
            };

            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(from)!);
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(to)!);
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitSymbolCategoryList<BybitDerivativesOpenInterest>>(_baseClient.GetUrl("derivatives/v3/public/open-interest"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
            if (!result || result.Data == null)
                return result.As<IEnumerable<BybitDerivativesOpenInterest>>(default);

            if (result.Data.List == null)
                return result.As<IEnumerable<BybitDerivativesOpenInterest>>(Array.Empty<BybitDerivativesOpenInterest>());

            return result.As(result.Data.List);
        }

        #endregion

        #region Get option delivery

        /// <inheritdoc />/
        public async Task<WebCallResult<BybitCursorPage<IEnumerable<BybitDerivativesOptionDeliveryPrice>>>> GetOptionDeliveryPriceAsync(Category? category = null, string? symbol = null, string? baseAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();

            parameters.AddOptionalParameter("category", EnumConverter.GetString(category));
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("baseAsset", baseAsset);
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("cursor", cursor);

            return await _baseClient.SendRequestAsync<BybitCursorPage<IEnumerable<BybitDerivativesOptionDeliveryPrice>>>(_baseClient.GetUrl("derivatives/v3/public/delivery-price"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get order book

        /// <inheritdoc />
        public async Task<WebCallResult<BybitDerivativesOrderBookEntry>> GetOrderBookAsync(string symbol, Category? category = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };

            parameters.AddOptionalParameter("category", EnumConverter.GetString(category));
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitDerivativesOrderBookEntry>(_baseClient.GetUrl("derivatives/v3/public/order-book/L2"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get risk limit

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitDerivativesRiskLimit>>> GetRiskLimitAsync(Category category, string symbol, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol }
            };

            var result = await _baseClient.SendRequestAsync<BybitCategoryList<BybitDerivativesRiskLimit>>(_baseClient.GetUrl("derivatives/v3/public/risk-limit/list"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
            if (!result || result.Data == null)
                return result.As<IEnumerable<BybitDerivativesRiskLimit>>(default);

            if (result.Data.List == null)
                return result.As<IEnumerable<BybitDerivativesRiskLimit>>(Array.Empty<BybitDerivativesRiskLimit>());

            return result.As(result.Data.List);
        }

        #endregion

        #region Get server time

        /// <inheritdoc />
        public async Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default)
        {
            var result = await _baseClient.SendRequestWrapperAsync<BybitDerivativesServerTime>(_baseClient.GetUrl("/v3/public/time"), HttpMethod.Get, ct, null, ignoreRatelimit: true).ConfigureAwait(false);
            if (!result)
                return result.As<DateTime>(default);

            return result.As<DateTime>(result.Data.Result.ServerTime);
        }

        #endregion

        #region Get symbols

        /// <inheritdoc />
        public async Task<WebCallResult<BybitDerivativesCursorPage<IEnumerable<BybitDerivativesSymbol>>>> GetSymbolsAsync(Category category, string? symbol = null, string? baseAsset = null, int? limit = null, string? cursor = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) }
            };

            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("cursor", cursor);

            return await _baseClient.SendRequestAsync<BybitDerivativesCursorPage<IEnumerable<BybitDerivativesSymbol>>>(_baseClient.GetUrl("derivatives/v3/public/instruments-info"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get tickers

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitDerivativesTicker>>> GetTickerAsync(Category category, string? symbol = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) }
            };

            parameters.AddOptionalParameter("symbol", symbol);

            var result = await _baseClient.SendRequestAsync<BybitCategoryList<BybitDerivativesTicker>>(_baseClient.GetUrl("derivatives/v3/public/tickers"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
            if (!result || result.Data == null)
                return result.As<IEnumerable<BybitDerivativesTicker>>(default);

            if (result.Data.List == null)
                return result.As<IEnumerable<BybitDerivativesTicker>>(Array.Empty<BybitDerivativesTicker>());

            return result.As(result.Data.List);
        }

        #endregion

        #region Get trade history

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitDerivativesTrade>>> GetTradeHistoryAsync(Category category, string symbol, string? baseAsset = null, OptionType? optionType = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol }
            };

            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("optionType", EnumConverter.GetString(optionType));
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitCategoryList<BybitDerivativesTrade>>(_baseClient.GetUrl("derivatives/v3/public/recent-trade"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
            if (!result || result.Data == null)
                return result.As<IEnumerable<BybitDerivativesTrade>>(default);

            if (result.Data.List == null)
                return result.As<IEnumerable<BybitDerivativesTrade>>(Array.Empty<BybitDerivativesTrade>());

            return result.As(result.Data.List);
        }

        #endregion
    }
}
