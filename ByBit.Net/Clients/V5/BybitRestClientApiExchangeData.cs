using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.V5;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using System;
using System.Globalization;
using System.Linq;
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
        public async Task<HttpResult<BybitResponse<BybitAnnouncement>>> GetAnnouncementsAsync(string locale, string? type = null, string? tag = null, int? page = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "locale", locale },
            };
            parameters.Add("type", type);
            parameters.Add("tag", tag);
            parameters.Add("page", page);
            parameters.Add("limit", limit);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/announcements/index", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitAnnouncement>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Server Time

        /// <inheritdoc />
        public async Task<HttpResult<BybitTime>> GetServerTimeAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/market/time", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitTime>(request, null, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get klines

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitKline>>> GetKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "interval", EnumConverter.GetString(interval) },
            };
            parameters.Add("start", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.Add("end", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.Add("limit", limit?.ToString(CultureInfo.InvariantCulture));

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/market/kline", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitKline>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Mark Price klines

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitBasicKline>>> GetMarkPriceKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "interval", EnumConverter.GetString(interval) },
            };
            parameters.Add("start", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.Add("end", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.Add("limit", limit?.ToString(CultureInfo.InvariantCulture));

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/market/mark-price-kline", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitBasicKline>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Index Price klines

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitBasicKline>>> GetIndexPriceKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "interval", EnumConverter.GetString(interval) },
            };
            parameters.Add("start", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.Add("end", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.Add("limit", limit?.ToString(CultureInfo.InvariantCulture));

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/market/index-price-kline", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitBasicKline>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Premium Index Price klines

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitBasicKline>>> GetPremiumIndexPriceKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "interval", EnumConverter.GetString(interval) },
            };
            parameters.Add("start", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.Add("end", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.Add("limit", limit?.ToString(CultureInfo.InvariantCulture));

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/market/premium-index-price-kline", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitBasicKline>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Spot symbols

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitSpotSymbol>>> GetSpotSymbolsAsync(string? symbol = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(Category.Spot) }
            };
            parameters.Add("symbol", symbol);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/market/instruments-info", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitSpotSymbol>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Option symbols

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitOptionSymbol>>> GetOptionSymbolsAsync(string? symbol = null, string? baseAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(Category.Option) }
            };
            parameters.Add("symbol", symbol);
            parameters.Add("baseCoin", baseAsset);
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/market/instruments-info", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitOptionSymbol>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Linear Inverse symbols

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitLinearInverseSymbol>>> GetLinearInverseSymbolsAsync(
            Category category,
            string? symbol = null,
            string? baseAsset = null,
            SymbolStatus? status = null,
            SymbolType? symbolType = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            if (category != Category.Linear && category != Category.Inverse)
                throw new ArgumentException("Invalid category; should be Linear or Inverse");

            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) }
            };
            parameters.Add("status", status);
            parameters.Add("symbolType", symbolType);
            parameters.Add("symbol", symbol);
            parameters.Add("baseCoin", baseAsset);
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/market/instruments-info", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitLinearInverseSymbol>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Order Book

        /// <inheritdoc />
        public async Task<HttpResult<BybitOrderbook>> GetOrderbookAsync(Category category, string symbol, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol }
            };
            parameters.Add("limit", limit);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/market/orderbook", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitOrderbook>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get RPI Order Book

        /// <inheritdoc />
        public async Task<HttpResult<BybitOrderbook>> GetRpiOrderbookAsync(Category category, string symbol, int limit, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol }
            };
            parameters.AddParameter("limit", limit);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/market/rpi_orderbook", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitOrderbook>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Spot Tickers

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitSpotTicker>>> GetSpotTickersAsync(string? symbol = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(Category.Spot) }
            };
            parameters.Add("symbol", symbol);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/market/tickers", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitSpotTicker>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Option Tickers

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitOptionTicker>>> GetOptionTickersAsync(string? symbol = null, string? baseAsset = null, string? expirationDate = null, CancellationToken ct = default)
        {
            if (symbol == null && baseAsset == null)
                throw new ArgumentException("Either symbol or baseAsset should be provided");

            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(Category.Option) }
            };
            parameters.Add("symbol", symbol);
            parameters.Add("baseCoin", baseAsset);
            parameters.Add("expDate", expirationDate);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/market/tickers", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitOptionTicker>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Linear/Inverse Tickers

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitLinearInverseTicker>>> GetLinearInverseTickersAsync(Category category, string? symbol = null, string? baseAsset = null, string? expirationDate = null, CancellationToken ct = default)
        {
            if (category != Category.Linear && category != Category.Inverse)
                throw new ArgumentException("Invalid category; should be Linear or Inverse");

            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) }
            };
            parameters.Add("symbol", symbol);
            parameters.Add("baseCoin", baseAsset);
            parameters.Add("expDate", expirationDate);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/market/tickers", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitLinearInverseTicker>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Funding Rate History

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitFundingHistory>>> GetFundingRateHistoryAsync(Category category, string symbol, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            if (category != Category.Linear && category != Category.Inverse)
                throw new ArgumentException("Invalid category; should be Linear or Inverse");

            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol }
            };
            parameters.Add("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.Add("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.Add("limit", limit);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/market/funding/history", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitFundingHistory>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Trade History

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitTradeHistory>>> GetTradeHistoryAsync(Category category, string symbol, string? baseAsset = null, OptionType? optionType = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol }
            };
            parameters.Add("baseCoin", baseAsset);
            parameters.Add("optionType", EnumConverter.GetString(optionType));
            parameters.Add("limit", limit);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/market/recent-trade", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitTradeHistory>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Open Interest

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitOpenInterest>>> GetOpenInterestAsync(Category category, string symbol, OpenInterestInterval interestInterval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            if (category != Category.Linear && category != Category.Inverse)
                throw new ArgumentException("Invalid category; should be Linear or Inverse");

            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "intervalTime", EnumConverter.GetString(interestInterval) },
            };
            parameters.Add("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.Add("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/market/open-interest", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitOpenInterest>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Historical Volatility

        /// <inheritdoc />
        public async Task<HttpResult<BybitHistoricalVolatility[]>> GetHistoricalVolatilityAsync(string? baseAsset = null, string? quoteAsset = null, int? period = null, DateTime? startTime = null, DateTime? endTime = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(Category.Option) },
            };
            parameters.Add("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.Add("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.Add("baseCoin", baseAsset);
            parameters.Add("quoteCoin", quoteAsset);
            parameters.Add("period", period);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/market/historical-volatility", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitHistoricalVolatility[]>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Insurance

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitInsurance>>> GetInsuranceAsync(string? asset = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/market/insurance", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitInsurance>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Risk Limit

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitRiskLimit>>> GetRiskLimitAsync(Category category, string? symbol = null, string? cursor = null, CancellationToken ct = default)
        {
            if (category != Category.Linear && category != Category.Inverse)
                throw new ArgumentException("Invalid category; should be Linear or Inverse");

            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) }
            };
            parameters.Add("symbol", symbol);
            parameters.Add("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/market/risk-limit", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitRiskLimit>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Delivery Price

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitDeliveryPrice>>> GetDeliveryPriceAsync(Category category, string? symbol = null, string? baseAsset = null, string? settleAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) }
            };
            parameters.Add("symbol", symbol);
            parameters.Add("baseCoin", baseAsset);
            parameters.Add("settleCoin", settleAsset);
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/market/delivery-price", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitResponse<BybitDeliveryPrice>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Leverage Token Info

        /// <inheritdoc />
        public async Task<HttpResult<BybitLeverageToken[]>> GetLeverageTokensAsync(string? leverageToken = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("ltCoin", leverageToken);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/spot-lever-token/info", BybitExchange.RateLimiter.BybitRest, 1, false);
            var result = await _baseClient.SendAsync<BybitLeverageTokenWrapper>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BybitLeverageToken[]>(result);

            return HttpResult.Ok(result, result.Data.List);
        }

        #endregion

        #region Get Leverage Token Market 

        /// <inheritdoc />
        public async Task<HttpResult<BybitLeverageTokenMarket>> GetLeverageTokenMarketAsync(string leverageToken, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "ltCoin", leverageToken }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/spot-lever-token/reference", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitLeverageTokenMarket>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Long Short Ratio

        /// <inheritdoc />
        public async Task<HttpResult<BybitLongShortRatio[]>> GetLongShortRatioAsync(
            Category category,
            string symbol,
            DataPeriod period,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "symbol", symbol }
            };
            parameters.Add("category", category);
            parameters.Add("period", period);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/market/account-ratio", BybitExchange.RateLimiter.BybitRest, 1, false);
            var result = await _baseClient.SendAsync<BybitList<BybitLongShortRatio>>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success || result.Data == null)
                return HttpResult.Fail<BybitLongShortRatio[]>(result);

            if (result.Data.List == null)
                return HttpResult.Ok<BybitLongShortRatio[]>(result, Array.Empty<BybitLongShortRatio>());

            return HttpResult.Ok(result, result.Data.List);
        }


        #endregion

        #region Get Spot Margin Tiered Collateral Ratio

        /// <inheritdoc />
        public async Task<HttpResult<BybitSpotMarginCollateralRatio[]>> GetSpotMarginTieredCollateralRatioAsync(string? asset = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("currency", asset);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/spot-margin-trade/collateral", BybitExchange.RateLimiter.BybitRest, 1, false);
            var result = await _baseClient.SendAsync<BybitResponse<BybitSpotMarginCollateralRatio>>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BybitSpotMarginCollateralRatio[]>(result);

            return HttpResult.Ok(result, result.Data.List);
        }

        #endregion

        #region Get Spread Symbols

        /// <inheritdoc />
        public async Task<HttpResult<BybitSpreadSymbol[]>> GetSpreadSymbolsAsync(string? symbol = null, string? baseAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("baseCoin", baseAsset);
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/spread/instrument", BybitExchange.RateLimiter.BybitRest, 1, false);
            var result = await _baseClient.SendAsync<BybitList<BybitSpreadSymbol>>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BybitSpreadSymbol[]>(result);

            return HttpResult.Ok(result, result.Data.List);
        }

        #endregion

        #region Get Spread Order Book

        /// <inheritdoc />
        public async Task<HttpResult<BybitOrderbook>> GetSpreadOrderBookAsync(string symbol, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/spread/orderbook", BybitExchange.RateLimiter.BybitRest, 1, false);
            var result = await _baseClient.SendAsync<BybitOrderbook>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Spread Tickers

        /// <inheritdoc />
        public async Task<HttpResult<BybitSpreadTicker>> GetSpreadTickersAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/spread/tickers", BybitExchange.RateLimiter.BybitRest, 1, false);
            var result = await _baseClient.SendAsync<BybitList<BybitSpreadTicker>>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BybitSpreadTicker>(result);

            return HttpResult.Ok(result, result.Data.List.Single());
        }

        #endregion

        #region Get Spread Recent Trades

        /// <inheritdoc />
        public async Task<HttpResult<BybitSpreadTrade[]>> GetSpreadRecentTradesAsync(string symbol, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/spread/recent-trade", BybitExchange.RateLimiter.BybitRest, 1, false);
            var result = await _baseClient.SendAsync<BybitList<BybitSpreadTrade>>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BybitSpreadTrade[]>(result);

            return HttpResult.Ok(result, result.Data.List);
        }

        #endregion

        #region Get Order Price

        /// <inheritdoc />
        public async Task<HttpResult<BybitOrderPriceLimit>> GetOrderPriceLimitAsync(string symbol, Category? category = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("category", category);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/market/price-limit", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitOrderPriceLimit>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get System Status

        /// <inheritdoc />
        public async Task<HttpResult<BybitSystemStatus[]>> GetSystemStatusAsync(string? id = null, SystemStatus? status = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("id", id);
            parameters.Add("state", status);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/system/status", BybitExchange.RateLimiter.BybitRest, 1, false);
            var result = await _baseClient.SendAsync<BybitList<BybitSystemStatus>>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BybitSystemStatus[]>(result);

            return HttpResult.Ok(result, result.Data.List);
        }

        #endregion

        #region Get ADL Alerts

        /// <inheritdoc />
        public async Task<HttpResult<BybitAdlAlert[]>> GetAdlAlertsAsync(string symbol,CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/market/adlAlert", BybitExchange.RateLimiter.BybitRest, 1, false);
            var result = await _baseClient.SendAsync<BybitList<BybitAdlAlert>>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BybitAdlAlert[]>(result);

            return HttpResult.Ok(result, result.Data.List);
        }

        #endregion

        #region Get Index Price Components

        /// <inheritdoc />
        public async Task<HttpResult<BybitIndexComponents>> GetIndexPriceComponentsAsync(string indexName, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("indexName", indexName);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/market/index-price-components", BybitExchange.RateLimiter.BybitRest, 1, false);
            return await _baseClient.SendAsync<BybitIndexComponents>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion
    }
}
