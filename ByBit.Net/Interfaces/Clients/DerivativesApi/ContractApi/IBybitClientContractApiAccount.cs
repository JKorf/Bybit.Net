using Bybit.Net.Enums;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Models.Derivatives.Contract;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.DerivativesApi.ContractApi
{
    /// <summary>
    /// Bybit account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings
    /// </summary>
    public interface IBybitClientContractApiAccount
    {
        #region Positions
        /// <summary>
        /// Get user positions
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-dv_myposition" /></para>
        /// </summary>
        /// <param name="symbol">Filter by symbol</param>
        /// <param name="settleAsset">Settle coin. Either symbol or settleCoin is required. If both are passed, symbol is used first.</param>
        /// <param name="dataFilter">Only work when settleCoin is passed. full: get all positions regardless zero or not based on settle coin. valid: get valid positions based on settle coin</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitDerivativesCursorPage<IEnumerable<BybitContractPosition>>>> GetPositionAsync(string? symbol = null, string? settleAsset = null, SettleDataFilter? dataFilter = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Set auto add margin switch
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-setautoaddmargin" /></para>
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
        /// Switch cross margin mode/isolated margin mode
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-dv_marginswitch" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="tradeMode">Cross/isolated mode</param>
        /// <param name="buyLeverage">Buy leverage</param>
        /// <param name="sellLeverage">Sell leverage</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetTradeModeAsync(string symbol, TradeMode tradeMode, decimal buyLeverage, decimal sellLeverage, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Switch position mode. If you are in One-Way Mode, you can only open one position on Buy or Sell side;
        /// If you are in Hedge Mode, you can open both Buy and Sell side positions simultaneously.
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-dv_switchpositionmode" /></para>
        /// </summary>
        /// <param name="hedgeMode">Hedge mode. OneWay/Hedge are supported</param>
        /// <param name="symbol">The symbol</param>
        /// <param name="asset">Currency alias</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetPositionModeAsync(PositionMode hedgeMode, string? symbol = null, string? asset = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Switch between full or partial Stop loss/Take profit mode
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-dv_switchmode" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="mode">New mode</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetFullPartialPositionModeAsync(string symbol, StopLossTakeProfitMode mode, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Set leverage
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-setleverage" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="buyLeverage">Buy leverage</param>
        /// <param name="sellLeverage">Sell leverage</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetLeverageAsync(string symbol, decimal buyLeverage, decimal sellLeverage, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Set position risk
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-setrisklimit" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="riskId">The risk id to set</param>
        /// <param name="positionMode">Position mode</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetRiskLimitAsync(string symbol, long riskId, PositionMode? positionMode = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get executed user trades
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-usertraderecords" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="startTime">Start timestamp in millisecond</param>
        /// <param name="endTime">End timestamp in millisecond</param>
        /// <param name="tradeType">Execution type</param>
        /// <param name="limit">Data quantity per page: Max data value per page is 50, and default value at 20</param>
        /// <param name="cursor">API pass-through</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitCursorPage<IEnumerable<BybitContractUserTrade>>>> GetUserTradesAsync(string symbol, string? orderId = null,
            DateTime? startTime = null, DateTime? endTime = null, TradeType? tradeType = null, int? limit = null, string? cursor = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get user's closed profit and loss records. The results are ordered in descending order (the first item is the latest).
        /// </summary>
        /// <param name="symbol"> Symbol </param>
        /// <param name="startTime"> Start timestamp point for result, in seconds </param>
        /// <param name="endTime"> End timestamp point for result, in seconds </param>
        /// <param name="limit"> Limit for data size per page, max size is 200. Default as showing 50 pieces of data per page. </param>
        /// <param name="cursor"> Page turning mark </param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitCursorPage<IEnumerable<BybitContractClosedPnlEntry>>>> GetProfitAndLossHistoryAsync(string symbol, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, long? receiveWindow = null, CancellationToken ct = default);

        #endregion

        #region Account

        /// <summary>
        /// Get wallet balances
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-balance" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitContractBalance>>> GetBalancesAsync(string? asset = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get user trading fee rate
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-tradingfeerate" /></para>
        /// </summary>
        /// <param name="symbol"> Symbol </param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitContractTradingFeeRate>>> GetTradingFeeRate(string? symbol = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get user trading fee rate
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-dv_walletrecords" /></para>
        /// </summary>
        /// <param name="asset"> Coin </param>
        /// <param name="startTime">Start timestamp in milliseconds</param>
        /// <param name="endTime">End timestamp in milliseconds. The past year records ONLY</param>
        /// <param name="fundType">Wallet fund type</param>
        /// <param name="limit">Data quantity per page: Max data value per page is 50, and default value at 20</param>
        /// <param name="cursor">API pass-through</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitCursorPage<IEnumerable<BybitContractWalletFundRecord>>>> GetWalletFundRecords(string? asset = null, DateTime? startTime = null, DateTime? endTime = null, WalletFundType? fundType = null, int? limit = null, string? cursor = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get user trading fee rate
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-dv_setmarginmode" /></para>
        /// </summary>
        /// <param name="marginMode"> Margin mode </param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetMarginMode(MarginMode marginMode, long? receiveWindow = null, CancellationToken ct = default);

        #endregion

    }
}