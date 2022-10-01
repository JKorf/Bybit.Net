using Bybit.Net.Converters;
using Bybit.Net.Enums;
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
using Bybit.Net.Objects.Models.Spot;
using Bybit.Net.Interfaces.Clients.SpotApi.v1;
using Bybit.Net.Objects.Models.Spot.v1;

namespace Bybit.Net.Clients.SpotApi.v1
{
    /// <inheritdoc />
    public class BybitClientSpotApiExchangeDataV1 : IBybitClientSpotApiExchangeDataV1
    {
        private BybitClientBaseSpotApi _baseClient;

        internal BybitClientSpotApiExchangeDataV1(BybitClientBaseSpotApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Get server time

        /// <inheritdoc />
        public async Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default)
        {
            var result = await _baseClient.SendRequestAsync<BybitSpotTime>(_baseClient.GetUrl("spot/v1/time"), HttpMethod.Get, ct, null, ignoreRatelimit: true).ConfigureAwait(false);
            return result.As(result.Data?.ServerTime ?? default);
        }

        #endregion

        #region Get symbols

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitSpotSymbolV1>>> GetSymbolsAsync(CancellationToken ct = default)
        {
            return await _baseClient.SendRequestAsync<IEnumerable<BybitSpotSymbolV1>>(_baseClient.GetUrl("spot/v1/symbols"), HttpMethod.Get, ct, null).ConfigureAwait(false);
        }

        #endregion

        #region Get Order book

        /// <inheritdoc />
        public async Task<WebCallResult<BybitSpotOrderBook>> GetOrderBookAsync(string symbol, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitSpotOrderBook>(_baseClient.GetUrl("spot/quote/v1/depth"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get Merged order book

        /// <inheritdoc />
        public async Task<WebCallResult<BybitSpotOrderBook>> GetMergedOrderBookAsync(string symbol, int? scale = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("scale", scale?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitSpotOrderBook>(_baseClient.GetUrl("spot/quote/v1/depth/merged"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get trade history

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitSpotTradeV1>>> GetTradeHistoryAsync(string symbol, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitSpotTradeV1>>(_baseClient.GetUrl("spot/quote/v1/trades"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get klines

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitSpotKlineV1>>> GetKlinesAsync(string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "interval", JsonConvert.SerializeObject(interval, new KlineIntervalSpotConverter(false)) }
            };
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitSpotKlineV1>>(_baseClient.GetUrl("spot/quote/v1/kline"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get ticker

        /// <inheritdoc />
        public async Task<WebCallResult<BybitSpotTickerV1>> GetTickerAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };

            return await _baseClient.SendRequestAsync<BybitSpotTickerV1>(_baseClient.GetUrl("spot/quote/v1/ticker/24hr"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get tickers

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitSpotTickerV1>>> GetTickersAsync(CancellationToken ct = default)
        {
            return await _baseClient.SendRequestAsync<IEnumerable<BybitSpotTickerV1>>(_baseClient.GetUrl("spot/quote/v1/ticker/24hr"), HttpMethod.Get, ct, null).ConfigureAwait(false);
        }

        #endregion

        #region Get price

        /// <inheritdoc />
        public async Task<WebCallResult<BybitSpotPrice>> GetPriceAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };

            return await _baseClient.SendRequestAsync<BybitSpotPrice>(_baseClient.GetUrl("spot/quote/v1/ticker/price"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get prices

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitSpotPrice>>> GetPricesAsync(CancellationToken ct = default)
        {
            return await _baseClient.SendRequestAsync<IEnumerable<BybitSpotPrice>>(_baseClient.GetUrl("spot/quote/v1/ticker/price"), HttpMethod.Get, ct, null).ConfigureAwait(false);
        }

        #endregion

        #region Get book price

        /// <inheritdoc />
        public async Task<WebCallResult<BybitSpotBookPriceV1>> GetBookPriceAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };

            return await _baseClient.SendRequestAsync<BybitSpotBookPriceV1>(_baseClient.GetUrl("spot/quote/v1/ticker/book_ticker"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get prices

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitSpotBookPriceV1>>> GetBookPricesAsync(CancellationToken ct = default)
        {
            return await _baseClient.SendRequestAsync<IEnumerable<BybitSpotBookPriceV1>>(_baseClient.GetUrl("spot/quote/v1/ticker/book_ticker"), HttpMethod.Get, ct, null).ConfigureAwait(false);
        }

        #endregion

        #region Get Borrow info

        /// <inheritdoc />
        public async Task<WebCallResult<BybitBorrowInfoV1>> GetBorrowInterestAndQuotaAsync(string asset, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "currency", asset }
            };
            return await _baseClient.SendRequestAsync<BybitBorrowInfoV1>(_baseClient.GetUrl("spot/v1/cross-margin/loan-info"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion
    }
}
