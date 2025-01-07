﻿using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.V5;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.V5
{
    /// <inheritdoc />
    internal class BybitRestClientApiExchangeData : IBybitRestClientApiExchangeData
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
        private BybitRestClientApi _baseClient;

        internal BybitRestClientApiExchangeData(BybitRestClientApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Get Announcements

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitAnnouncement>>> GetAnnouncementsAsync(string locale, string? type = null, string? tag = null, int? page = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "locale", locale },
            };
            parameters.AddOptionalParameter("type", type);
            parameters.AddOptionalParameter("tag", tag);
            parameters.AddOptionalParameter("page", page);
            parameters.AddOptionalParameter("limit", limit);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/announcements/index", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitAnnouncement>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Server Time

        /// <inheritdoc />
        public async Task<WebCallResult<BybitTime>> GetServerTimeAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/market/time", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitTime>(request, null, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get klines

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitKline>>> GetKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "interval", EnumConverter.GetString(interval) },
            };
            parameters.AddOptionalParameter("start", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("end", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/market/kline", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitKline>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Mark Price klines

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitBasicKline>>> GetMarkPriceKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "interval", EnumConverter.GetString(interval) },
            };
            parameters.AddOptionalParameter("start", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("end", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/market/mark-price-kline", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitBasicKline>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Index Price klines

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitBasicKline>>> GetIndexPriceKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "interval", EnumConverter.GetString(interval) },
            };
            parameters.AddOptionalParameter("start", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("end", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/market/index-price-kline", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitBasicKline>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Premium Index Price klines

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitBasicKline>>> GetPremiumIndexPriceKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "interval", EnumConverter.GetString(interval) },
            };
            parameters.AddOptionalParameter("start", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("end", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/market/premium-index-price-kline", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitBasicKline>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Spot symbols

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitSpotSymbol>>> GetSpotSymbolsAsync(string? symbol = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(Category.Spot) }
            };
            parameters.AddOptionalParameter("symbol", symbol);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/market/instruments-info", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitSpotSymbol>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Option symbols

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitOptionSymbol>>> GetOptionSymbolsAsync(string? symbol = null, string? baseAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(Category.Option) }
            };
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/market/instruments-info", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitOptionSymbol>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Linear Inverse symbols

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitLinearInverseSymbol>>> GetLinearInverseSymbolsAsync(
            Category category,
            string? symbol = null,
            string? baseAsset = null,
            SymbolStatus? status = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            if (category != Category.Linear && category != Category.Inverse)
                throw new ArgumentException("Invalid category; should be Linear or Inverse");

            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) }
            };
            parameters.AddOptionalEnum("status", status);
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/market/instruments-info", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitLinearInverseSymbol>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get order book

        /// <inheritdoc />
        public async Task<WebCallResult<BybitOrderbook>> GetOrderbookAsync(Category category, string symbol, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("limit", limit);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/market/orderbook", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitOrderbook>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Spot Tickers

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitSpotTicker>>> GetSpotTickersAsync(string? symbol = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(Category.Spot) }
            };
            parameters.AddOptionalParameter("symbol", symbol);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/market/tickers", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitSpotTicker>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Option Tickers

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitOptionTicker>>> GetOptionTickersAsync(string? symbol = null, string? baseAsset = null, string? expirationDate = null, CancellationToken ct = default)
        {
            if (symbol == null && baseAsset == null)
                throw new ArgumentException("Either symbol or baseAsset should be provided");

            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(Category.Option) }
            };
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("expDate", expirationDate);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/market/tickers", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitOptionTicker>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Linear/Inverse Tickers

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitLinearInverseTicker>>> GetLinearInverseTickersAsync(Category category, string? symbol = null, string? baseAsset = null, string? expirationDate = null, CancellationToken ct = default)
        {
            if (category != Category.Linear && category != Category.Inverse)
                throw new ArgumentException("Invalid category; should be Linear or Inverse");

            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) }
            };
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("expDate", expirationDate);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/market/tickers", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitLinearInverseTicker>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Funding Rate History

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitFundingHistory>>> GetFundingRateHistoryAsync(Category category, string symbol, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            if (category != Category.Linear && category != Category.Inverse)
                throw new ArgumentException("Invalid category; should be Linear or Inverse");

            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("limit", limit);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/market/funding/history", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitFundingHistory>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Trade History

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitTradeHistory>>> GetTradeHistoryAsync(Category category, string symbol, string? baseAsset = null, OptionType? optionType = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("optionType", EnumConverter.GetString(optionType));
            parameters.AddOptionalParameter("limit", limit);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/market/recent-trade", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitTradeHistory>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Open Interest

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitOpenInterest>>> GetOpenInterestAsync(Category category, string symbol, OpenInterestInterval interestInterval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            if (category != Category.Linear && category != Category.Inverse)
                throw new ArgumentException("Invalid category; should be Linear or Inverse");

            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "intervalTime", EnumConverter.GetString(interestInterval) },
            };
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/market/open-interest", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitOpenInterest>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Historical Volatility

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitHistoricalVolatility>>> GetHistoricalVolatilityAsync(string? baseAsset = null, int? period = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(Category.Option) },
            };
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("period", period);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/market/historical-volatility", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<IEnumerable<BybitHistoricalVolatility>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Insurance

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitInsurance>>> GetInsuranceAsync(string? asset = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptionalParameter("coin", asset);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/market/insurance", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitInsurance>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Risk Limit

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitRiskLimit>>> GetRiskLimitAsync(Category category, string? symbol = null, string? cursor = null, CancellationToken ct = default)
        {
            if (category != Category.Linear && category != Category.Inverse)
                throw new ArgumentException("Invalid category; should be Linear or Inverse");

            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) }
            };
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/market/risk-limit", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitRiskLimit>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Delivery Price

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitDeliveryPrice>>> GetDeliveryPriceAsync(Category category, string? symbol = null, string? baseAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            if (category != Category.Linear && category != Category.Inverse)
                throw new ArgumentException("Invalid category; should be Linear or Inverse");

            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) }
            };
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/market/delivery-price", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitDeliveryPrice>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Leverage Token Info

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitLeverageToken>>> GetLeverageTokensAsync(string? leverageToken = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptionalParameter("ltCoin", leverageToken);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/spot-lever-token/info", BybitExchange.RateLimiter.BybitRest, 1, false);
            var result = await _baseClient.SendAsync<BybitLeverageTokenWrapper>(request, parameters, ct).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<BybitLeverageToken>>(default);

            return result.As(result.Data.List);
        }

        #endregion

        #region Get Leverage Token Market 

        /// <inheritdoc />
        public async Task<WebCallResult<BybitLeverageTokenMarket>> GetLeverageTokenMarketAsync(string leverageToken, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "ltCoin", leverageToken }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/spot-lever-token/reference", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitLeverageTokenMarket>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Long Short Ratio

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitLongShortRatio>>> GetLongShortRatioAsync(
            Category category,
            string symbol,
            DataPeriod period,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "symbol", symbol }
            };
            parameters.AddEnum("category", category);
            parameters.AddEnum("period", period);
            parameters.AddOptionalMillisecondsString("startTime", startTime);
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", limit);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/market/account-ratio", BybitExchange.RateLimiter.BybitRest, 1, false);
            var result = await _baseClient.SendAsync<BybitList<BybitLongShortRatio>>(request, parameters, ct).ConfigureAwait(false);
            if (!result || result.Data == null)
                return result.As<IEnumerable<BybitLongShortRatio>>(default);

            if (result.Data.List == null)
                return result.As<IEnumerable<BybitLongShortRatio>>(Array.Empty<BybitLongShortRatio>());

            return result.As(result.Data.List);
        }


        #endregion

    }
}
