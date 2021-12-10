using Bybit.Net.Enums;
using Bybit.Net.Objects.Models;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.Rest.Futures
{
    /// <summary>
    /// Bybit exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.
    /// </summary>
    public interface IBybitClientUsdPerpetualApiExchangeData
    {
        /// <summary>
        /// Get the server time
        /// <para>https://bybit-exchange.github.io/docs/linear/#t-servertime</para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<DateTime>> GetServerTimeAsync(long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// The API announcements for the last 30 days
        /// <para>https://bybit-exchange.github.io/docs/linear/#t-announcement</para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitAnnouncement>>> GetAnnouncementsAsync(long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get all supported symbols
        /// <para>https://bybit-exchange.github.io/docs/linear/#t-querysymbol</para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitSymbol>>> GetSymbolsAsync(long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// The ticker info for a symbol
        /// <para>https://bybit-exchange.github.io/docs/linear/#t-latestsymbolinfo</para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitTicker>>> GetTickerAsync(string? symbol = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get the current order book for a symbol
        /// <para>https://bybit-exchange.github.io/docs/linear/#t-orderbook</para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitOrderBookEntry>>> GetOrderBookAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get public trade history
        /// <para>https://bybit-exchange.github.io/docs/linear/#t-publictradingrecords</para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="limit">Max amount of results</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitTrade>>> GetTradeHistoryAsync(string symbol, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get price klines
        /// <para>https://bybit-exchange.github.io/docs/linear/#t-querykline</para>
        /// </summary>
        /// <param name="symbol">Symbol of the klines</param>
        /// <param name="interval">Interval of the kline data</param>
        /// <param name="from">Start time of the data</param>
        /// <param name="limit">Max amount of candles</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitKline>>> GetKlinesAsync(string symbol, KlineInterval interval, DateTime from, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get index price klines
        /// <para>https://bybit-exchange.github.io/docs/linear/#t-queryindexpricekline</para>
        /// </summary>
        /// <param name="symbol">Symbol of the klines</param>
        /// <param name="interval">Interval of the kline data</param>
        /// <param name="from">Start time of the data</param>
        /// <param name="limit">Max amount of candles</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitIndexPriceKline>>> GetIndexPriceKlinesAsync(string symbol, KlineInterval interval, DateTime from, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get mark price klines
        /// <para>https://bybit-exchange.github.io/docs/linear/#t-markpricekline</para>
        /// </summary>
        /// <param name="symbol">Symbol of the klines</param>
        /// <param name="interval">Interval of the kline data</param>
        /// <param name="from">Start time of the data</param>
        /// <param name="limit">Max amount of candles</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitMarkPriceKline>>> GetMarkPriceKlinesAsync(string symbol, KlineInterval interval, DateTime from, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get premium index klines
        /// <para>https://bybit-exchange.github.io/docs/linear/#t-querypremiumindexkline</para>
        /// </summary>
        /// <param name="symbol">Symbol of the klines</param>
        /// <param name="interval">Interval of the kline data</param>
        /// <param name="from">Start time of the data</param>
        /// <param name="limit">Max amount of candles</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitIndexPriceKline>>> GetPremiumIndexKlinesAsync(string symbol, KlineInterval interval, DateTime from, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get long/short ratio
        /// <para>https://bybit-exchange.github.io/docs/linear/#t-marketaccountratio</para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="period">The data period</param>
        /// <param name="limit">Max amount of results</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitAccountRatio>>> GetLongShortRatioAsync(string symbol, DataPeriod period, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Gets the total amount of unsettled contracts. In other words, the total number of contracts held in open positions.
        /// <para>https://bybit-exchange.github.io/docs/linear/#t-marketopeninterest</para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="period">The period of data</param>
        /// <param name="limit">Max amount of results</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitOpenInterest>>> GetOpenInterestAsync(string symbol, DataPeriod period, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Obtain filled orders worth more than 500,000 USD within the last 24h.
        /// <para>https://bybit-exchange.github.io/docs/linear/#t-marketbigdeal</para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="limit">The max amount of results</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitBigTrade>>> GetRecentBigTradesAsync(string symbol, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get last funding rate
        /// <para>https://bybit-exchange.github.io/docs/linear/#t-fundingrate</para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitFundingRate>> GetLastFundingRateAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);
    }
}