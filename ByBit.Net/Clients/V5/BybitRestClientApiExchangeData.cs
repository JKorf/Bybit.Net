using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.V5;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net;
using CryptoExchange.Net.Converters;
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
    public class BybitRestClientApiExchangeData : IBybitRestClientApiExchangeData
    {
        private BybitRestClientApi _baseClient;

        internal BybitRestClientApiExchangeData(BybitRestClientApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Get Announcements

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitAnnouncement>>> GetAnnouncementsAsync(string locale, string? type = null, string? tag = null, int? page = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "locale", locale },
            };
            parameters.AddOptionalParameter("type", type);
            parameters.AddOptionalParameter("tag", tag);
            parameters.AddOptionalParameter("page", page);
            parameters.AddOptionalParameter("limit", limit);

            return await _baseClient.SendRequestAsync<BybitResponse<BybitAnnouncement>>(_baseClient.GetUrl("v5/announcements/index"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get Server Time

        /// <inheritdoc />
        public async Task<WebCallResult<BybitTime>> GetServerTimeAsync(CancellationToken ct = default)
        {
            // V5 doesn't have it's own server time endpoint (yet)
            return await _baseClient.SendRequestAsync<BybitTime>(_baseClient.GetUrl("v3/public/time"), HttpMethod.Get, ct, null).ConfigureAwait(false);
        }

        #endregion

        #region Get klines

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitKline>>> GetKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "interval", EnumConverter.GetString(interval) },
            };
            parameters.AddOptionalParameter("start", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("end", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitResponse<BybitKline>>(_baseClient.GetUrl("v5/market/kline"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get Mark Price klines

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitBasicKline>>> GetMarkPriceKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "interval", EnumConverter.GetString(interval) },
            };
            parameters.AddOptionalParameter("start", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("end", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitResponse<BybitBasicKline>>(_baseClient.GetUrl("v5/market/mark-price-kline"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get Index Price klines

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitBasicKline>>> GetIndexPriceKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "interval", EnumConverter.GetString(interval) },
            };
            parameters.AddOptionalParameter("start", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("end", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitResponse<BybitBasicKline>>(_baseClient.GetUrl("v5/market/index-price-kline"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get Premium Index Price klines

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitBasicKline>>> GetPremiumIndexPriceKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "interval", EnumConverter.GetString(interval) },
            };
            parameters.AddOptionalParameter("start", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("end", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitResponse<BybitBasicKline>>(_baseClient.GetUrl("v5/market/premium-index-price-kline"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get Spot symbols

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitSpotSymbol>>> GetSpotSymbolsAsync(string? symbol = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(Category.Spot) }
            };
            parameters.AddOptionalParameter("symbol", symbol);

            return await _baseClient.SendRequestAsync<BybitResponse<BybitSpotSymbol>>(_baseClient.GetUrl("v5/market/instruments-info"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get Option symbols

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitOptionSymbol>>> GetOptionSymbolsAsync(string? symbol = null, string? baseAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(Category.Option) }
            };
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            return await _baseClient.SendRequestAsync<BybitResponse<BybitOptionSymbol>>(_baseClient.GetUrl("v5/market/instruments-info"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get Option symbols

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitLinearInverseSymbol>>> GetLinearInverseSymbolsAsync(Category category, string? symbol = null, string? baseAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            if (category != Category.Linear && category != Category.Inverse)
                throw new ArgumentException("Invalid category; should be Linear or Inverse");

            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) }
            };
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            return await _baseClient.SendRequestAsync<BybitResponse<BybitLinearInverseSymbol>>(_baseClient.GetUrl("v5/market/instruments-info"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get order book

        /// <inheritdoc />
        public async Task<WebCallResult<BybitOrderbook>> GetOrderbookAsync(Category category, string symbol, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("limit", limit);

            return await _baseClient.SendRequestAsync<BybitOrderbook>(_baseClient.GetUrl("v5/market/orderbook"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get Spot Tickers

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitSpotTicker>>> GetSpotTickersAsync(string? symbol = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(Category.Spot) }
            };
            parameters.AddOptionalParameter("symbol", symbol);

            return await _baseClient.SendRequestAsync<BybitResponse<BybitSpotTicker>>(_baseClient.GetUrl("v5/market/tickers"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get Option Tickers

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitOptionTicker>>> GetOptionTickersAsync(string? symbol = null, string? baseAsset = null, string? expirationDate = null, CancellationToken ct = default)
        {
            if (symbol == null && baseAsset == null)
                throw new ArgumentException("Either symbol or baseAsset should be provided");

            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(Category.Option) }
            };
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("expDate", expirationDate);

            return await _baseClient.SendRequestAsync<BybitResponse<BybitOptionTicker>>(_baseClient.GetUrl("v5/market/tickers"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get Linear/Inverse Tickers

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitLinearInverseTicker>>> GetLinearInverseTickersAsync(Category category, string? symbol = null, string? baseAsset = null, string? expirationDate = null, CancellationToken ct = default)
        {
            if (category != Category.Linear && category != Category.Inverse)
                throw new ArgumentException("Invalid category; should be Linear or Inverse");

            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) }
            };
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("expDate", expirationDate);

            return await _baseClient.SendRequestAsync<BybitResponse<BybitLinearInverseTicker>>(_baseClient.GetUrl("v5/market/tickers"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get Funding Rate History

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitFundingHistory>>> GetFundingRateHistoryAsync(Category category, string symbol, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            if (category != Category.Linear && category != Category.Inverse)
                throw new ArgumentException("Invalid category; should be Linear or Inverse");

            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("limit", limit);

            return await _baseClient.SendRequestAsync<BybitResponse<BybitFundingHistory>>(_baseClient.GetUrl("v5/market/funding/history"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get Trade History

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitTradeHistory>>> GetTradeHistoryAsync(Category category, string symbol, string? baseAsset = null, OptionType? optionType = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("optionType", EnumConverter.GetString(optionType));
            parameters.AddOptionalParameter("limit", limit);

            return await _baseClient.SendRequestAsync<BybitResponse<BybitTradeHistory>>(_baseClient.GetUrl("v5/market/recent-trade"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get Open Interest

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitOpenInterest>>> GetOpenInterestAsync(Category category, string symbol, OpenInterestInterval interestInterval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            if (category != Category.Linear && category != Category.Inverse)
                throw new ArgumentException("Invalid category; should be Linear or Inverse");

            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "intervalTime", EnumConverter.GetString(interestInterval) },
            };
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            return await _baseClient.SendRequestAsync<BybitResponse<BybitOpenInterest>>(_baseClient.GetUrl("v5/market/open-interest"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get Historic Volatility

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitHistoricalVolatility>>> GetHistoricalVolatilityAsync(Category category, string? baseAsset = null, int? period = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            if (category != Category.Option)
                throw new ArgumentException("Invalid category; should be Option");

            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
            };
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("period", period);

            return await _baseClient.SendRequestAsync<IEnumerable<BybitHistoricalVolatility>>(_baseClient.GetUrl("v5/market/historical-volatility"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get Insurance

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitInsurance>>> GetInsuranceAsync(string? asset = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("coin", asset);

            return await _baseClient.SendRequestAsync<BybitResponse<BybitInsurance>>(_baseClient.GetUrl("v5/market/insurance"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get Risk Limit

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitRiskLimit>>> GetRiskLimitAsync(Category category, string? symbol = null, CancellationToken ct = default)
        {
            if (category != Category.Linear && category != Category.Inverse)
                throw new ArgumentException("Invalid category; should be Linear or Inverse");

            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) }
            };
            parameters.AddOptionalParameter("symbol", symbol);

            return await _baseClient.SendRequestAsync<BybitResponse<BybitRiskLimit>>(_baseClient.GetUrl("v5/market/risk-limit"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get Delivery Price

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitDeliveryPrice>>> GetDeliveryPriceAsync(Category category, string? symbol = null, string? baseAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            if (category != Category.Linear && category != Category.Inverse)
                throw new ArgumentException("Invalid category; should be Linear or Inverse");

            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) }
            };
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            return await _baseClient.SendRequestAsync<BybitResponse<BybitDeliveryPrice>>(_baseClient.GetUrl("v5/market/delivery-price"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get Leverage Token Info

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitLeverageToken>>> GetLeverageTokensAsync(string? leverageToken = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("ltCoin", leverageToken);

            var result = await _baseClient.SendRequestAsync<BybitLeverageTokenWrapper>(_baseClient.GetUrl("v5/spot-lever-token/info"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<BybitLeverageToken>>(default);

            return result.As(result.Data.List);
        }

        #endregion

        #region Get Leverage Token Market 

        /// <inheritdoc />
        public async Task<WebCallResult<BybitLeverageTokenMarket>> GetLeverageTokenMarketAsync(string leverageToken, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "ltCoin", leverageToken }
            };

            return await _baseClient.SendRequestAsync<BybitLeverageTokenMarket>(_baseClient.GetUrl("v5/spot-lever-token/reference"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion
    }
}
