using Bybit.Net.Enums;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Models;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.UsdPerpetualApi
{
    /// <summary>
    /// Bybit account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and changing account settings
    /// </summary>
    public interface IBybitClientUsdPerpetualApiAccount
    {
        #region Risk
        /// <summary>
        /// Get position risk limit
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/linear/#t-getrisklimit" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitRiskLimit>>> GetRiskLimitAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Set position risk
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/linear/#t-setrisklimit" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="riskId">The risk id to set</param>
        /// <param name="side">Side</param>
        /// <param name="positionMode">Position mode</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitRiskId>> SetRiskLimitAsync(string symbol, OrderSide side, long riskId, PositionMode? positionMode = null, long? receiveWindow = null, CancellationToken ct = default);

        #endregion

        #region Positions
        /// <summary>
        /// Get user positions
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/linear/#t-myposition" /></para>
        /// </summary>
        /// <param name="symbol">Filter by symbol</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitPositionUsd>>> GetPositionAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);
        /// <summary>
        /// Get user positions
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/linear/#t-myposition" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitPositionUsd>>> GetPositionsAsync(long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Set auto add margin switch
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/linear/#t-setautoaddmargin" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="side">Side</param>
        /// <param name="autoAddMargin">Auto add or not</param>
        /// <param name="positionMode">Position mode</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetAutoAddMarginAsync(string symbol, OrderSide side, bool autoAddMargin, PositionMode? positionMode = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Switch Cross/Isolated; must set leverage value when switching from Cross to Isolated
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/linear/#t-marginswitch" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="isIsolated">True is Isolated; false is Cross</param>
        /// <param name="buyLeverage">Buy leverage</param>
        /// <param name="sellLeverage">Sell leverage</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetIsolatedPositionModeAsync(string symbol, bool isIsolated, decimal buyLeverage, decimal sellLeverage, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Switch position mode. If you are in One-Way Mode, you can only open one position on Buy or Sell side;
        /// If you are in Hedge Mode, you can open both Buy and Sell side positions simultaneously.
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/linear/#t-switchpositionmode" /></para>
        /// </summary>
        /// <param name="symbol">Symbol. Required if not passing coin</param>
        /// <param name="asset">Currency alias. Required if not passing symbol</param>
        /// <param name="hedgeMode">True = HedgeMode, False = OneWayMode</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetPositionModeAsync(string symbol, string asset, bool hedgeMode, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Switch between full or partial Stop loss/Take profit mode
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/linear/#t-switchmode" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="mode">New mode</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitTpSlMode>> SetFullPartialPositionModeAsync(string symbol, StopLossTakeProfitMode mode, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Add/reduce margin
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="side">The side</param>
        /// <param name="margin">Margin to add (positive) or remove (negative)</param>
        /// <param name="positionMode">Position mode</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitMarginResult>> AddReduceMarginAsync(string symbol, OrderSide side, decimal margin, PositionMode? positionMode = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Set leverage
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/linear/#t-setleverage" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="buyLeverage">Buy leverage</param>
        /// <param name="sellLeverage">Sell leverage</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetLeverageAsync(string symbol, decimal buyLeverage, decimal sellLeverage, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get user's profit and loss records
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/linear/#t-closedprofitandloss" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to get records for</param>
        /// <param name="startTime">Filter by startTime</param>
        /// <param name="endTime">Filter by endTime</param>
        /// <param name="type">Filter by type</param>
        /// <param name="page">Page</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitPage<IEnumerable<BybitPnlEntry>>>> GetProfitAndLossHistoryAsync(string symbol, DateTime? startTime = null, DateTime? endTime = null, TradeType? type = null, int? page = null, int? pageSize = null, long? receiveWindow = null, CancellationToken ct = default);
        #endregion

        #region Wallet

        /// <summary>
        /// Get wallet fund endpoints
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/linear/#t-walletrecords" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="type">Filter by type</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="page">Page</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitWalletFundRecord>>> GetWalletFundHistoryAsync(string? asset = null, DateTime? startTime = null, DateTime? endTime = null, WalletFundType? type = null, int? pageSize = null, int? page = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get asset exchange history
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/linear/#t-assetexchangerecords" /></para>
        /// </summary>
        /// <param name="fromId">Filter by id</param>
        /// <param name="direction">Filter by direction</param>
        /// <param name="limit">Max records</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitExchangeHistoryEntry>>> GetAssetExchangeHistoryAsync(long? fromId = null, SearchDirection? direction = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get wallet balances
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/linear/#t-balance" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<Dictionary<string, BybitBalance>>> GetBalancesAsync(string? asset = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get withdrawal history
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/linear/#t-withdrawrecords" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="status">Filter by status</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="page">Page</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitWithdrawal>>> GetWithdrawalHistoryAsync(string? asset = null, DateTime? startTime = null, DateTime? endTime = null, WithdrawStatus? status = null, int? pageSize = null, int? page = null, long? receiveWindow = null, CancellationToken ct = default);

        #endregion

        #region Funding

        /// <summary>
        /// Get user last funding fee
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/linear/#t-mylastfundingfee" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitFundingSettlement>> GetUserLastFundingFeeAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get predicted next funding rate
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/linear/#t-predictedfunding" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitPredictedFunding>> GetUserPredictedFundingRateAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);

        #endregion

        /// <summary>
        /// Get Api key info
        /// <para><a href="https://bybit-exchange.github.io/docs/futuresV2/linear/#t-key" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<ByBitApiKeyInfo>>> GetApiKeyInfoAsync(long? receiveWindow = null, CancellationToken ct = default);

    }
}