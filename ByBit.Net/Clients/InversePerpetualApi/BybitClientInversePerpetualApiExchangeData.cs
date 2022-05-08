using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.InversePerpetualApi;
using Bybit.Net.Objects.Models;
using CryptoExchange.Net;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.InversePerpetualApi
{
    /// <inheritdoc />
    public class BybitClientInversePerpetualApiExchangeData : IBybitClientInversePerpetualApiExchangeData
    {
        private BybitClientInversePerpetualApi _baseClient;

        internal BybitClientInversePerpetualApiExchangeData(BybitClientInversePerpetualApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Get klines

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitKline>>> GetKlinesAsync(string symbol, KlineInterval interval, DateTime from, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "interval", JsonConvert.SerializeObject(interval, new KlineIntervalConverter(false)) },
                { "from", DateTimeConverter.ConvertToSeconds(from)! },
            };
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitKline>>(_baseClient.GetUrl("v2/public/kline/list"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get trade history

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitTrade>>> GetTradeHistoryAsync(string symbol, long? fromId = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("fromId", fromId?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitTrade>>(_baseClient.GetUrl("v2/public/trading-records"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get last funding rate

        /// <inheritdoc />
        public async Task<WebCallResult<BybitFundingRate>> GetLastFundingRateAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };

            return await _baseClient.SendRequestAsync<BybitFundingRate>(_baseClient.GetUrl("v2/public/funding/prev-funding-rate"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get mark price klines

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitMarkPriceKline>>> GetMarkPriceKlinesAsync(string symbol, KlineInterval interval, DateTime from, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "interval", JsonConvert.SerializeObject(interval, new KlineIntervalConverter(false)) },
                { "from",  DateTimeConverter.ConvertToSeconds(from)! },
            };
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitMarkPriceKline>>(_baseClient.GetUrl("v2/public/mark-price-kline"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get index price klines

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitIndexPriceKline>>> GetIndexPriceKlinesAsync(string symbol, KlineInterval interval, DateTime from, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "interval", JsonConvert.SerializeObject(interval, new KlineIntervalConverter(false)) },
                { "from",  DateTimeConverter.ConvertToSeconds(from) },
            };
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitIndexPriceKline>>(_baseClient.GetUrl("v2/public/index-price-kline"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get premium index price klines

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitIndexPriceKline>>> GetPremiumIndexKlinesAsync(string symbol, KlineInterval interval, DateTime from, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "interval", JsonConvert.SerializeObject(interval, new KlineIntervalConverter(false)) },
                { "from", DateTimeConverter.ConvertToSeconds(from)! },
            };
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitIndexPriceKline>>(_baseClient.GetUrl("v2/public/premium-index-kline"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get server time

        /// <inheritdoc />
        public async Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default)
        {
            var result = await _baseClient.SendRequestWrapperAsync<object>(_baseClient.GetUrl("v2/public/time"), HttpMethod.Get, ct, null, ignoreRatelimit: true).ConfigureAwait(false);
            if (!result)
                return result.As<DateTime>(default);

            return result.As(result.Data.Timestamp);
        }

        #endregion

        #region Get announcement

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitAnnouncement>>> GetAnnouncementsAsync(CancellationToken ct = default)
        {
            return await _baseClient.SendRequestAsync<IEnumerable<BybitAnnouncement>>(_baseClient.GetUrl("v2/public/announcement"), HttpMethod.Get, ct, null).ConfigureAwait(false);
        }

        #endregion

        #region Get order book

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitOrderBookEntry>>> GetOrderBookAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };

            return await _baseClient.SendRequestAsync<IEnumerable<BybitOrderBookEntry>>(_baseClient.GetUrl("v2/public/orderBook/L2"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get tickers

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitTicker>>> GetTickersAsync(string? symbol = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("symbol", symbol);

            return await _baseClient.SendRequestAsync<IEnumerable<BybitTicker>>(_baseClient.GetUrl("v2/public/tickers"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get symbols

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitSymbol>>> GetSymbolsAsync(CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();

            return await _baseClient.SendRequestAsync<IEnumerable<BybitSymbol>>(_baseClient.GetUrl("v2/public/symbols"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get open interest

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitOpenInterest>>> GetOpenInterestAsync(string symbol, DataPeriod period, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "period", JsonConvert.SerializeObject(period, new DataPeriodConverter(false)) }
            };
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitOpenInterest>>(_baseClient.GetUrl("v2/public/open-interest"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get recent big trades

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitBigTrade>>> GetRecentBigTradesAsync(string symbol, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitBigTrade>>(_baseClient.GetUrl("v2/public/big-deal"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get long short ratio

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitAccountRatio>>> GetLongShortRatioAsync(string symbol, DataPeriod period, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "period", JsonConvert.SerializeObject(period, new DataPeriodConverter(false)) }
            };
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));
            return await _baseClient.SendRequestAsync<IEnumerable<BybitAccountRatio>>(_baseClient.GetUrl("v2/public/account-ratio"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion
    }
}
