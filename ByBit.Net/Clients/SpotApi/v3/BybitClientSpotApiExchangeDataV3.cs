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
using Bybit.Net.Interfaces.Clients.SpotApi.v3;
using Bybit.Net.Objects.Models.Spot;
using Bybit.Net.Objects.Models.Spot.v3;
using Bybit.Net.Objects.Internal;

namespace Bybit.Net.Clients.SpotApi.v3
{
    /// <inheritdoc />
    public class BybitClientSpotApiExchangeDataV3 : IBybitClientSpotApiExchangeDataV3
    {
        private BybitClientBaseSpotApi _baseClient;

        internal BybitClientSpotApiExchangeDataV3(BybitClientBaseSpotApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Get server time

        /// <inheritdoc />
        public async Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default)
        {
            var result = await _baseClient.SendRequestAsync<BybitSpotTime>(_baseClient.GetUrl("spot/v3/public/server-time"), HttpMethod.Get, ct, null, ignoreRatelimit: true).ConfigureAwait(false);
            return result.As(result.Data?.ServerTime ?? default);
        }

        #endregion

        #region Get symbols

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitSpotSymbolV3>>> GetSymbolsAsync(CancellationToken ct = default)
        {
            var result = await _baseClient.SendRequestAsync<BybitList<BybitSpotSymbolV3>>(_baseClient.GetUrl("spot/v3/public/symbols"), HttpMethod.Get, ct, null).ConfigureAwait(false);

            if (!result || result.Data == null)
                return result.As<IEnumerable<BybitSpotSymbolV3>>(default);

            if (result.Data.List == null)
                return result.As<IEnumerable<BybitSpotSymbolV3>>(Array.Empty<BybitSpotSymbolV3>());

            return result.As(result.Data.List);
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

            return await _baseClient.SendRequestAsync<BybitSpotOrderBook>(_baseClient.GetUrl("spot/v3/public/quote/depth"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
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

            return await _baseClient.SendRequestAsync<BybitSpotOrderBook>(_baseClient.GetUrl("spot/v3/public/quote/depth/merged"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get trade history

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitSpotTradeV3>>> GetTradeHistoryAsync(string symbol, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitList<BybitSpotTradeV3>>(_baseClient.GetUrl("spot/v3/public/quote/trades"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);

            if (!result || result.Data == null)
                return result.As<IEnumerable<BybitSpotTradeV3>>(default);

            if (result.Data.List == null)
                return result.As<IEnumerable<BybitSpotTradeV3>>(Array.Empty<BybitSpotTradeV3>());

            return result.As(result.Data.List);
        }

        #endregion

        #region Get klines

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitSpotKlineV3>>> GetKlinesAsync(string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "interval", JsonConvert.SerializeObject(interval, new KlineIntervalSpotConverter(false)) }
            };
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));

            var result = await _baseClient.SendRequestAsync<BybitList<BybitSpotKlineV3>>(_baseClient.GetUrl("spot/v3/public/quote/kline"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);

            if (!result || result.Data == null)
                return result.As<IEnumerable<BybitSpotKlineV3>>(default);

            if (result.Data.List == null)
                return result.As<IEnumerable<BybitSpotKlineV3>>(Array.Empty<BybitSpotKlineV3>());

            return result.As(result.Data.List);
        }

        #endregion

        #region Get ticker

        /// <inheritdoc />
        public async Task<WebCallResult<BybitSpotTickerV3>> GetTickerAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };

            return await _baseClient.SendRequestAsync<BybitSpotTickerV3>(_baseClient.GetUrl("spot/v3/public/quote/ticker/24hr"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get tickers

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitSpotTickerV3>>> GetTickersAsync(CancellationToken ct = default)
        {
            var result = await _baseClient.SendRequestAsync<BybitList<BybitSpotTickerV3>>(_baseClient.GetUrl("spot/v3/public/quote/ticker/24hr"), HttpMethod.Get, ct, null).ConfigureAwait(false);

            if (!result || result.Data == null)
                return result.As<IEnumerable<BybitSpotTickerV3>>(default);

            if (result.Data.List == null)
                return result.As<IEnumerable<BybitSpotTickerV3>>(Array.Empty<BybitSpotTickerV3>());

            return result.As(result.Data.List);
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

            return await _baseClient.SendRequestAsync<BybitSpotPrice>(_baseClient.GetUrl("spot/v3/public/quote/ticker/price"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get prices

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitSpotPrice>>> GetPricesAsync(CancellationToken ct = default)
        {
            var result = await _baseClient.SendRequestAsync<BybitList<BybitSpotPrice>>(_baseClient.GetUrl("spot/v3/public/quote/ticker/price"), HttpMethod.Get, ct, null).ConfigureAwait(false);

            if (!result || result.Data == null)
                return result.As<IEnumerable<BybitSpotPrice>>(default);

            if (result.Data.List == null)
                return result.As<IEnumerable<BybitSpotPrice>>(Array.Empty<BybitSpotPrice>());

            return result.As(result.Data.List);
        }

        #endregion

        #region Get book price

        /// <inheritdoc />
        public async Task<WebCallResult<BybitSpotBookPriceV3>> GetBookPriceAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };

            return await _baseClient.SendRequestAsync<BybitSpotBookPriceV3>(_baseClient.GetUrl("spot/v3/public/quote/ticker/bookTicker"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Get prices

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitSpotBookPriceV3>>> GetBookPricesAsync(CancellationToken ct = default)
        {
            var result = await _baseClient.SendRequestAsync<BybitList<BybitSpotBookPriceV3>>(_baseClient.GetUrl("spot/v3/public/quote/ticker/bookTicker"), HttpMethod.Get, ct, null).ConfigureAwait(false);

            if (!result || result.Data == null)
                return result.As<IEnumerable<BybitSpotBookPriceV3>>(default);

            if (result.Data.List == null)
                return result.As<IEnumerable<BybitSpotBookPriceV3>>(Array.Empty<BybitSpotBookPriceV3>());

            return result.As(result.Data.List);
        }

        #endregion

        #region Get Borrow info

        /// <inheritdoc />
        public async Task<WebCallResult<BybitBorrowInfoV3>> GetBorrowInterestAndQuotaAsync(string asset, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "currency", asset }
            };
            return await _baseClient.SendRequestAsync<BybitBorrowInfoV3>(_baseClient.GetUrl("spot/v3/private/cross-margin-loan-info"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion
    }
}
