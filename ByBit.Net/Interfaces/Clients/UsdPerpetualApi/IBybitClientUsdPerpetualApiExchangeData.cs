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
        Task<WebCallResult<IEnumerable<BybitAnnouncement>>> GetAnnouncementsAsync(CancellationToken ct = default);
        Task<WebCallResult<IEnumerable<BybitIndexPriceKline>>> GetIndexPriceKlinesAsync(string symbol, KlineInterval interval, DateTime from, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<IEnumerable<BybitKline>>> GetKlinesAsync(string symbol, KlineInterval interval, DateTime from, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<BybitFundingRate>> GetLastFundingRateAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<IEnumerable<BybitAccountRatio>>> GetLongShortRatioAsync(string symbol, DataPeriod period, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<IEnumerable<BybitMarkPriceKline>>> GetMarkPriceKlinesAsync(string symbol, KlineInterval interval, DateTime from, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<IEnumerable<BybitOpenInterest>>> GetOpenInterestAsync(string symbol, DataPeriod period, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<IEnumerable<BybitOrderBookEntry>>> GetOrderBookAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<IEnumerable<BybitIndexPriceKline>>> GetPremiumIndexKlinesAsync(string symbol, KlineInterval interval, DateTime from, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<IEnumerable<BybitBigTrade>>> GetRecentBigTradesAsync(string symbol, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default);
        Task<WebCallResult<IEnumerable<BybitSymbol>>> GetSymbolsAsync(long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<IEnumerable<BybitTicker>>> GetTickerAsync(string? symbol = null, long? receiveWindow = null, CancellationToken ct = default);
        Task<WebCallResult<IEnumerable<BybitTrade>>> GetTradeHistoryAsync(string symbol, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);
    }
}