using Bybit.Net.Enums;
using Bybit.Net.Objects.Models;
using Bybit.Net.Objects.Models;
using Bybit.Net.Objects.Models.Spot;
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
    public interface IBybitClientSpotApiExchangeData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitSpotSymbol>>> GetSymbolsAsync(long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="limit"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<BybitSpotOrderBook>> GetOrderBookAsync(string symbol, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="scale"></param>
        /// <param name="limit"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<BybitSpotOrderBook>> GetMergedOrderBookAsync(string symbol, int? scale = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="limit"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitSpotTrade>>> GetTradeHistoryAsync(string symbol, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="interval"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="limit"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitSpotKline>>> GetKlinesAsync(string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<BybitSpotTicker>> GetTickerAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitSpotTicker>>> GetTickersAsync(long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<BybitSpotPrice>> GetPriceAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitSpotPrice>>> GetPricesAsync(long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<BybitSpotBookPrice>> GetBookPriceAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitSpotBookPrice>>> GetBookPricesAsync(long? receiveWindow = null, CancellationToken ct = default);
    }
}