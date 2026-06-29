using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net.Objects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.V5
{
    /// <summary>
    /// Bybit exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.
    /// </summary>
    public interface IBybitRestClientApiExchangeData
    {
        /// <summary>
        /// Get server announcements
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/announcement" /><br />
        /// Endpoint:<br />
        /// GET /v5/announcements/index
        /// </para>
        /// </summary>
        /// <param name="locale">["<c>locale</c>"] Language, for example en-US</param>
        /// <param name="type">["<c>type</c>"] Filter by type</param>
        /// <param name="tag">["<c>tag</c>"] Filter by tag</param>
        /// <param name="page">["<c>page</c>"] Page</param>
        /// <param name="limit">["<c>limit</c>"] Page size</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitAnnouncement>>> GetAnnouncementsAsync(string locale, string? type = null, string? tag = null, int? page = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get server time
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v3/server-time" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/time
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitTime>> GetServerTimeAsync(CancellationToken ct = default);

        /// <summary>
        /// Get delivery price
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/delivery-price" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/delivery-price
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="baseAsset">["<c>baseCoin</c>"] Filter by base asset, for example `ETH`</param>
        /// <param name="settleAsset">["<c>settleCoin</c>"] Filter by settlement asset</param>
        /// <param name="limit">["<c>limit</c>"] Number of results per page</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitDeliveryPrice>>> GetDeliveryPriceAsync(Category category, string? symbol = null, string? baseAsset = null, string? settleAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get funding rate history
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/history-fund-rate" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/funding/history
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitFundingHistory>>> GetFundingRateHistoryAsync(Category category, string symbol, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get historical volatility
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/iv" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/historical-volatility
        /// </para>
        /// </summary>
        /// <param name="baseAsset">["<c>baseCoin</c>"] Filter by base asset, for example `ETH`</param>
        /// <param name="quoteAsset">["<c>quoteCoin</c>"] Quote asset, `USD` or `USDT`</param>
        /// <param name="period">["<c>period</c>"] Period</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitHistoricalVolatility[]>> GetHistoricalVolatilityAsync(string? baseAsset = null, string? quoteAsset = null, int? period = null, DateTime? startTime = null, DateTime? endTime = null, CancellationToken ct = default);

        /// <summary>
        /// Get index price klines
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/index-kline" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/index-price-kline
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="interval">["<c>interval</c>"] Kline interval</param>
        /// <param name="startTime">["<c>start</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>end</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitBasicKline>>> GetIndexPriceKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get insurance pool data
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/insurance" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/insurance
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] Asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitInsurance>>> GetInsuranceAsync(string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Get klines
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/kline" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/kline
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="interval">["<c>interval</c>"] Kline interval</param>
        /// <param name="startTime">["<c>start</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>end</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitKline>>> GetKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get linear/inverse symbols
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/instrument" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/instruments-info
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="baseAsset">["<c>baseCoin</c>"] Base asset, for example `ETH`</param>
        /// <param name="status">["<c>status</c>"] Filter by status</param>
        /// <param name="symbolType">["<c>symbolType</c>"] Filter by symbol type</param>
        /// <param name="limit">["<c>limit</c>"] Number of results per page</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitLinearInverseSymbol>>> GetLinearInverseSymbolsAsync(
            Category category,
            string? symbol = null,
            string? baseAsset = null,
            SymbolStatus? status = null,
            SymbolType? symbolType = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get linear/inverse tickers
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/tickers" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/tickers
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="baseAsset">["<c>baseCoin</c>"] Base asset, for example `ETH`</param>
        /// <param name="expirationDate">["<c>expDate</c>"] Expiration date</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitLinearInverseTicker>>> GetLinearInverseTickersAsync(Category category, string? symbol = null, string? baseAsset = null, string? expirationDate = null, CancellationToken ct = default);

        /// <summary>
        /// Get mark price klines
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/mark-kline" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/mark-price-kline
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="interval">["<c>interval</c>"] Kline interval</param>
        /// <param name="startTime">["<c>start</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>end</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitBasicKline>>> GetMarkPriceKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get open interest
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/open-interest" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/open-interest
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="interestInterval">["<c>intervalTime</c>"] Interval</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Number of results per page</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitOpenInterest>>> GetOpenInterestAsync(Category category, string symbol, OpenInterestInterval interestInterval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get option symbols
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/instrument" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/instruments-info
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="baseAsset">["<c>baseCoin</c>"] Base asset, for example `ETH`</param>
        /// <param name="limit">["<c>limit</c>"] Number of results per page</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitOptionSymbol>>> GetOptionSymbolsAsync(string? symbol = null, string? baseAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get option tickers
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/tickers" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/tickers
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="baseAsset">["<c>baseCoin</c>"] Filter by asset, for example `ETH`</param>
        /// <param name="expirationDate">["<c>expDate</c>"] Expiration date</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitOptionTicker>>> GetOptionTickersAsync(string? symbol = null, string? baseAsset = null, string? expirationDate = null, CancellationToken ct = default);

        /// <summary>
        /// Get order book
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/orderbook" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/orderbook
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="limit">["<c>limit</c>"] Limit of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitOrderbook>> GetOrderbookAsync(Category category, string symbol, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get RPI order book
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/rpi-orderbook" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/rpi_orderbook
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="limit">["<c>limit</c>"] Limit of results, max 50</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitOrderbook>> GetRpiOrderbookAsync(Category category, string symbol, int limit, CancellationToken ct = default);

        /// <summary>
        /// Get premium index klines
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/preimum-index-kline" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/premium-index-price-kline
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="interval">["<c>interval</c>"] Kline interval</param>
        /// <param name="startTime">["<c>start</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>end</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Number of results per page</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitBasicKline>>> GetPremiumIndexPriceKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get risk limits
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="cursor">["<c>cursor</c>"] Next page cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitRiskLimit>>> GetRiskLimitAsync(Category category, string? symbol = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get spot symbols
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/instrument" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/instruments-info
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitSpotSymbol>>> GetSpotSymbolsAsync(string? symbol = null, CancellationToken ct = default);

        /// <summary>
        /// Spot tickers
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/tickers" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/tickers
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitSpotTicker>>> GetSpotTickersAsync(string? symbol = null, CancellationToken ct = default);

        /// <summary>
        /// Get trade history
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/recent-trade" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/recent-trade
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="baseAsset">["<c>baseCoin</c>"] Base asset, for example `ETH`</param>
        /// <param name="optionType">["<c>optionType</c>"] Option type</param>
        /// <param name="limit">["<c>limit</c>"] Limit of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitTradeHistory>>> GetTradeHistoryAsync(Category category, string symbol, string? baseAsset = null, OptionType? optionType = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get leverage token info
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/lt/leverage-token-info" /><br />
        /// Endpoint:<br />
        /// GET /v5/spot-lever-token/info
        /// </para>
        /// </summary>
        /// <param name="leverageToken">["<c>ltCoin</c>"] Filter by token</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitLeverageToken[]>> GetLeverageTokensAsync(string? leverageToken = null, CancellationToken ct = default);

        /// <summary>
        /// Get leveraged token market info
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/lt/leverage-token-reference" /><br />
        /// Endpoint:<br />
        /// GET /v5/spot-lever-token/reference
        /// </para>
        /// </summary>
        /// <param name="leverageToken">["<c>ltCoin</c>"] Token</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitLeverageTokenMarket>> GetLeverageTokenMarketAsync(string leverageToken, CancellationToken ct = default);

        /// <summary>
        /// Get long/short ratio history
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/long-short-ratio" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/account-ratio
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="period">["<c>period</c>"] Data recording period</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Limit for data size per page</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitLongShortRatio[]>> GetLongShortRatioAsync(Category category, string symbol, DataPeriod period, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get UTA loan tiered collateral ratio
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/spot-margin-uta/tier-collateral-ratio" /><br />
        /// Endpoint:<br />
        /// GET /v5/spot-margin-trade/collateral
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>currency</c>"] Filter by asset</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitSpotMarginCollateralRatio[]>> GetSpotMarginTieredCollateralRatioAsync(string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Get spread trading symbols
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/spread/market/instrument" /><br />
        /// Endpoint:<br />
        /// GET /v5/spread/instrument
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="baseAsset">["<c>baseCoin</c>"] Filter by base asset</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results, max 500</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitSpreadSymbol[]>> GetSpreadSymbolsAsync(string? symbol = null, string? baseAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get spread trading order book
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/spread/market/orderbook" /><br />
        /// Endpoint:<br />
        /// GET /v5/spread/orderbook
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results, max 25</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitOrderbook>> GetSpreadOrderBookAsync(string symbol, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get spread tickers
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/spread/market/tickers" /><br />
        /// Endpoint:<br />
        /// GET /v5/spread/tickers
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitSpreadTicker>> GetSpreadTickersAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get spread symbol recent trades
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/spread/market/recent-trade" /><br />
        /// Endpoint:<br />
        /// GET /v5/spread/recent-trade
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results, max 1000</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitSpreadTrade[]>> GetSpreadRecentTradesAsync(string symbol, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get order price limits
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/order-price-limit" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/price-limit
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] Symbol name, for example `ETHUSDT`</param>
        /// <param name="category">["<c>category</c>"] Category. Defaults to Linear</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitOrderPriceLimit>> GetOrderPriceLimitAsync(string symbol, Category? category = null, CancellationToken ct = default);

        /// <summary>
        /// Get the system status messages
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/system-status" /><br />
        /// Endpoint:<br />
        /// GET /v5/system/status
        /// </para>
        /// </summary>
        /// <param name="id">["<c>id</c>"] Filter by id</param>
        /// <param name="status">["<c>state</c>"] Filter by status</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitSystemStatus[]>> GetSystemStatusAsync(string? id = null, SystemStatus? status = null, CancellationToken ct = default);

        /// <summary>
        /// Get ADL alerts
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/adl-alert" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/adlAlert
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitAdlAlert[]>> GetAdlAlertsAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get components which make up the index price
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/index-components" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/index-price-components
        /// </para>
        /// </summary>
        /// <param name="indexName">["<c>indexName</c>"] Index name</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitIndexComponents>> GetIndexPriceComponentsAsync(string indexName, CancellationToken ct = default);
    }
}
