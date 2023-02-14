using Bybit.Net.Enums;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Models;
using Bybit.Net.Objects.Models.Derivatives;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.DerivativesApi
{
    /// <summary>
    /// Bybit exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.
    /// </summary>
    public interface IBybitClientDerivativesApiExchangeData
    {
        /// <summary>
        /// Get the server time
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-servertime" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default);

        /// <summary>
        /// Get all supported symbols
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_instrhead" /></para>
        /// </summary>
        /// <param name="category"> Derivatives products category.If category is not passed, then return ""For now, linear inverse option are available</param>
        /// <param name="symbol">Symbol</param>
        /// <param name="baseAsset">Base coin.Only valid when category = option.If not passed, BTC by default.</param>
        /// <param name="limit">Limit for data size per cursor, max size is 1000. Default as showing 500 pieces of data per cursor</param>
        /// <param name="cursor">API pass-through</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitDerivativesCursorPage<IEnumerable<BybitDerivativesSymbol>>>> GetSymbolsAsync(Category category, string? symbol = null, string? baseAsset = null, int? limit = null, string? cursor = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// The ticker info for a symbol
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_tickerhead" /></para>
        /// </summary>
        /// <param name="category">Derivatives products category. If category is not passed, then return ""For now, linear inverse option are available</param>
        /// <param name="symbol">The symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitDerivativesTicker>>> GetTickerAsync(Category category, string? symbol = null, CancellationToken ct = default);

        /// <summary>
        /// Get the current order book for a symbol
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_orderbook" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="category">Derivatives products category. If category is not passed, then return ""For now, linear inverse option are available</param>
        /// <param name="limit">25 by default, 500 is max. If option, only 25 is available</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitDerivativesOrderBookEntry>> GetOrderBookAsync(string symbol, Category? category = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get price klines
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_querykline" /></para>
        /// </summary>
        /// <param name="category">Derivatives products category. If category is not passed, then return ""For now, linear inverse including inverse futures are available</param>
        /// <param name="symbol">Symbol of the klines</param>
        /// <param name="interval">Interval of the kline data</param>
        /// <param name="from">Start time of the data</param>
        /// <param name="to">End time of the data</param>
        /// <param name="limit">Max amount of candles</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitKline>>> GetKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime from, DateTime to, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get index price klines
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_indexpricekline" /></para>
        /// </summary>
        /// <param name="category">Derivatives products category. If category is not passed, then return ""For now, linear inverse including inverse futures are available</param>
        /// <param name="symbol">Symbol of the klines</param>
        /// <param name="interval">Interval of the kline data</param>
        /// <param name="from">Start time of the data</param>
        /// <param name="to">End time of the data</param>
        /// <param name="limit">Max amount of candles</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitKline>>> GetIndexPriceKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime from, DateTime to, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get mark price klines
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_markpricekline" /></para>
        /// </summary>
        /// <param name="category">Derivatives products category. If category is not passed, then return ""For now, linear inverse including inverse futures are available</param>
        /// <param name="symbol">Symbol of the klines</param>
        /// <param name="interval">Interval of the kline data</param>
        /// <param name="from">Start time of the data</param>
        /// <param name="to">End time of the data</param>
        /// <param name="limit">Max amount of candles</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitKline>>> GetMarkPriceKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime from, DateTime to, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Gets the total amount of unsettled contracts. In other words, the total number of contracts held in open positions.
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_marketopeninterest" /></para>
        /// </summary>
        /// <param name="category">Derivatives products category. If category is not passed, then return ""For now, linear inverse including inverse futures are available</param>
        /// <param name="symbol">The symbol</param>
        /// <param name="interval"> Open interest interval type </param>
        /// <param name="period">The period of data</param>
        /// <param name="from">Start time of the data</param>
        /// <param name="to">End time of the data</param>
        /// <param name="limit">Max amount of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitDerivativesOpenInterest>>> GetOpenInterestAsync(Category category, string symbol, OpenInterestInterval interval, DataPeriod period, DateTime? from = null, DateTime? to = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get funding rate history
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_historyfundingratehead" /></para>
        /// </summary>
        /// <param name="category">Derivatives products category. If category is not passed, then return ""For now, linear inverse including inverse futures are available</param>
        /// <param name="symbol">The symbol</param>
        /// <param name="from">Start time of the data</param>
        /// <param name="to">End time of the data</param>
        /// <param name="limit">Max amount of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitDerivativesFundingRate>>> GetFundingRateAsync(Category category, string symbol, DateTime? from = null, DateTime? to = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get Risk Limit
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_risklimithead" /></para>
        /// </summary>
        /// <param name="category">Derivatives products category. If category is not passed, then return ""For now, linear inverse including inverse futures are available</param>
        /// <param name="symbol">The symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitDerivativesRiskLimit>>> GetRiskLimitAsync(Category category, string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get option delivery price
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_optiondeliveryhead" /></para>
        /// </summary>
        /// <param name="category">Derivatives products category. If category is not passed, then return ""For now, linear inverse including inverse futures are available</param>
        /// <param name="symbol">The symbol</param>
        /// <param name="baseAsset">Base coin. Only valid when category=option. If not passed, BTC by default.</param>
        /// <param name="limit">Max amount of results</param>
        /// <param name="cursor">API pass-through</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitCursorPage<IEnumerable<BybitDerivativesOptionDeliveryPrice>>>> GetOptionDeliveryPriceAsync(Category? category = null, string? symbol = null, string? baseAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get Trade history
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_publictradingrecords" /></para>
        /// </summary>
        /// <param name="category">Derivatives products category. If category is not passed, then return ""For now, linear inverse including inverse futures are available</param>
        /// <param name="symbol">The symbol</param>
        /// <param name="baseAsset">Base coin. Only valid when category=option. If not passed, BTC by default.</param>
        /// <param name="optionType">Trading type of option</param>
        /// <param name="limit">Max amount of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitDerivativesTrade>>> GetTradeHistoryAsync(Category category, string symbol, string? baseAsset = null, OptionType? optionType = null, int? limit = null, CancellationToken ct = default);
    }
}
