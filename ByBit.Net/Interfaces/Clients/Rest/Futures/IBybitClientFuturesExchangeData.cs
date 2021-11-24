using Bybit.Net.Enums;
using Bybit.Net.Objects.Models;
using Bybit.Net.Objects.Models;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.Rest.Futures
{
    /// <summary>
    /// ex
    /// </summary>
    public interface IBybitClientFuturesExchangeData
    {
        /// <summary>
        /// 1
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitAnnouncement>>> GetAnnouncementsAsync(CancellationToken ct = default);
        
        /// <summary>
        /// 2
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="interval"></param>
        /// <param name="from"></param>
        /// <param name="limit"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitIndexPriceKline>>> GetIndexPriceKlinesAsync(string symbol, KlineInterval interval, DateTime from, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);
        
        /// <summary>
        /// 3
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="interval"></param>
        /// <param name="from"></param>
        /// <param name="limit"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitKline>>> GetInverseKlinesAsync(string symbol, KlineInterval interval, DateTime from, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// 3
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="interval"></param>
        /// <param name="from"></param>
        /// <param name="limit"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitKline>>> GetLinearKlinesAsync(string symbol, KlineInterval interval, DateTime from, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// 4
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<BybitFundingRate>> GetInverseLastFundingRateAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// 4
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<BybitFundingRate>> GetLinearLastFundingRateAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// 5
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="period"></param>
        /// <param name="limit"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitAccountRatio>>> GetLongShortRatioAsync(string symbol, DataPeriod period, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);
        
        /// <summary>
        /// 6
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="interval"></param>
        /// <param name="from"></param>
        /// <param name="limit"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitMarkPriceKline>>> GetMarkPriceKlinesAsync(string symbol, KlineInterval interval, DateTime from, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);
        
        /// <summary>
        /// 7
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="period"></param>
        /// <param name="limit"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitOpenInterest>>> GetOpenInterestAsync(string symbol, DataPeriod period, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);
        
        /// <summary>
        /// 7
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitOrderBookEntry>>> GetOrderBookAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);
        
        /// <summary>
        /// 8
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="interval"></param>
        /// <param name="from"></param>
        /// <param name="limit"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitIndexPriceKline>>> GetPremiumIndexKlinesAsync(string symbol, KlineInterval interval, DateTime from, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);
        
        /// <summary>
        /// 9
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="limit"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitBigTrade>>> GetRecentBigTradesAsync(string symbol, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);
        
        /// <summary>
        /// 10
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default);
        
        /// <summary>
        /// 11
        /// </summary>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitSymbol>>> GetSymbolsAsync(long? receiveWindow = null, CancellationToken ct = default);
        
        /// <summary>
        /// 12
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitTicker>>> GetTickerAsync(string? symbol = null, long? receiveWindow = null, CancellationToken ct = default);
        
        /// <summary>
        /// 13
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="fromId"></param>
        /// <param name="limit"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitTrade>>> GetTradeHistoryAsync(string symbol, long? fromId = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);
    }
}