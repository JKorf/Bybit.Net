using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.Spot;
using Bybit.Net.Objects.Models.Spot.v3;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.SpotApi.v3
{
    /// <summary>
    /// Bybit exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.
    /// </summary>
    public interface IBybitClientSpotApiExchangeDataV3
    {
        /// <summary>
        /// Get the server time
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v3/#t-servertime" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default);

        /// <summary>
        /// Get all supported symbols
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v3/#t-getsymbols" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitSpotSymbolV3>>> GetSymbolsAsync(CancellationToken ct = default);

        /// <summary>
        /// Get the current order book for a symbol
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v3/#t-orderbook" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="limit">The number of rows</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitSpotOrderBook>> GetOrderBookAsync(string symbol, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get merged order book based on the scale
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v3/#t-mergedorderbook" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="scale">The scale of the order book. 1 means 1 digit</param>
        /// <param name="limit">The amount of rows</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitSpotOrderBook>> GetMergedOrderBookAsync(string symbol, int? scale = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get public trade history
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v3/#t-publictradingrecords" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="limit">Max amount of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitSpotTradeV3>>> GetTradeHistoryAsync(string symbol, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get price klines
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v3/#t-querykline" /></para>
        /// </summary>
        /// <param name="symbol">Symbol of the klines</param>
        /// <param name="interval">Interval of the kline data</param>
        /// <param name="startTime">Start time of the data</param>
        /// <param name="endTime">End time of the data</param>
        /// <param name="limit">Max amount of candles</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitSpotKlineV3>>> GetKlinesAsync(string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// The ticker info for a symbol
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v3/#t-spot_latestsymbolinfo" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitSpotTickerV3>> GetTickerAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// The ticker info for all symbols
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v3/#t-spot_latestsymbolinfo" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitSpotTickerV3>>> GetTickersAsync(CancellationToken ct = default);

        /// <summary>
        /// Get the last trade price of a symbol
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v3/#t-lasttradedprice" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitSpotPrice>> GetPriceAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get the last trade price of all symbols
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v3/#t-lasttradedprice" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitSpotPrice>>> GetPricesAsync(CancellationToken ct = default);

        /// <summary>
        /// Get the best ask/bid price for a symbol
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v3/#t-bestbidask" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitSpotBookPriceV3>> GetBookPriceAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get the best ask/bid prices for all symbols
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v3/#t-bestbidask" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitSpotBookPriceV3>>> GetBookPricesAsync(CancellationToken ct = default);

        /// <summary>
        /// Get borrow info
        /// </summary>
        /// <param name="asset">The asset to retrieve info on</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitBorrowInfoV3>> GetBorrowInterestAndQuotaAsync(string asset, CancellationToken ct = default);
    }
}