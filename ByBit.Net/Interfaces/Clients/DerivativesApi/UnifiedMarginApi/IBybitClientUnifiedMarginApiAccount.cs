using Bybit.Net.Enums;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Models.Derivatives.UnifiedMargin;
using Bybit.Net.Objects.Models.UnifiedMargin;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.DerivativesApi.UnifiedMarginApi
{
    /// <summary>
    /// Bybit account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings
    /// </summary>
    public interface IBybitClientUnifiedMarginApiAccount
    {
        /// <summary>
        /// Check, if Unified Margin Account enabled for current credentials
        /// </summary>
        /// <returns> Flag if UMA enabled </returns>
        Task<WebCallResult<bool>> IsUMAEnabled();

        /// <summary>
        /// Query wallet balance
        /// </summary>
        /// <param name="asset">Currency alias. If the parameter coin is not passed, all wallet balance will be returned. Multiple parameters can be passed, which should be separated using commas, such as USDC, USDT</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitUnifiedMarginBalance>> GetWalletBalance(string? asset = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Set position risk
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_setrisklimit" /></para>
        /// </summary>
        /// <param name="category">Type of derivatives product: linear or option</param>
        /// <param name="symbol">The symbol</param>
        /// <param name="riskId">The risk id to set</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetRiskLimitAsync(Category category, string symbol, long riskId, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Modify leverage
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_setleverage" /></para>
        /// </summary>
        /// <param name="category">Type of derivatives product: linear or option</param>
        /// <param name="symbol">Name of Contract</param>
        /// <param name="buyLeverage">leverage of the corresponding risk limit</param>
        /// <param name="cellLeverage">leverage of the corresponding risk limit</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns> Flag if successfull </returns>
        Task<WebCallResult> SetLeverageAsync(Category category, string symbol, decimal buyLeverage, decimal cellLeverage, long? receiveWindow = null, CancellationToken ct = default);

        #region Positions
        /// <summary>
        /// Get user positions
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_myposition" /></para>
        /// </summary>
        /// <param name="category">Type of derivatives product: linear or option</param>
        /// <param name="symbol">Name of Contract</param>
        /// <param name="baseAsset">Base coin. When category=option. If not passed, BTC by default.</param>
        /// <param name="direction"></param>
        /// <param name="limit"></param>
        /// <param name="cursor"></param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitDerivativesCursorPage<IEnumerable<BybitUnifiedMarginPosition>>>> GetPositionAsync(Category category, string? symbol = null, string? baseAsset = null, SearchDirection? direction = null, int? limit = null, string? cursor = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Switch between full or partial Stop loss/Take profit mode
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_switchmode" /></para>
        /// </summary>
        /// <param name="category">Type of derivatives product: linear or option</param>
        /// <param name="symbol">The symbol</param>
        /// <param name="mode">New mode</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetFullPartialPositionModeAsync(Category category, string symbol, StopLossTakeProfitMode mode, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Set position TP/SL and trailing stop.
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_switchmode" /></para>
        /// </summary>
        /// <param name="category"> Derivatives products category. If category is not passed, then return ""For now, linear is available</param>
        /// <param name="symbol"> Name of Contract</param>
        /// <param name="takeProfit"> ≥ 0, if = 0, cancel take-profit (TP)</param>
        /// <param name="stopLoss"> ≥ 0, if = 0, cancel stop-loss (SL)</param>
        /// <param name="trailingStop"> ≥ 0, if = 0, cancel trailing stop (TS)</param>
        /// <param name="tpTriggerBy">Type of take-profit activation price, LastPrice by default</param>
        /// <param name="slTriggerBy">Type of stop-loss activation price, LastPrice by default</param>
        /// <param name="activePrice">Trailing stop trigger price. Trailing stop will only be triggered when this price is touched (trailing stop will be immediately triggered by default)</param>
        /// <param name="slSize">Quantity of stop-loss orders with the TP/SL mode on selected positions</param>
        /// <param name="tpSize">Quantity of take-profit orders with the TP/SL mode on selected positions</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetSlTpAsync(Category category, string symbol, decimal? takeProfit = null, decimal? stopLoss = null, decimal? trailingStop = null, TriggerType? tpTriggerBy = null, TriggerType? slTriggerBy = null, decimal? activePrice = null, decimal? slSize = null, decimal? tpSize = null, long? receiveWindow = null, CancellationToken ct = default);

        #endregion

        #region Wallet

        /// <summary>
        /// Query trading history
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_querytransactionlogs" /></para>
        /// </summary>
        /// <param name="category">	Type of derivatives product: linear or option</param>
        /// <param name="asset">USDC, USDT, BTC, and ETH</param>
        /// <param name="baseAsset">Base coin</param>
        /// <param name="startTime">Starting timestamp</param>
        /// <param name="endTime">Ending timestamp</param>
        /// <param name="direction"></param>
        /// <param name="limit"></param>
        /// <param name="cursor"></param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitDerivativesCursorPage<IEnumerable<BybitUnifiedMarginTransactionLog>>>> GetTransactionLogAsync(Category category, string asset, string? baseAsset = null, DateTime? startTime = null, DateTime? endTime = null, SearchDirection? direction = null, int? limit = null, string? cursor = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Fund transfer between accounts
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_transfer" /></para>
        /// </summary>
        /// <param name="transferId">UUID, globally unique</param>
        /// <param name="amount">Exchanged amount</param>
        /// <param name="currency">Currency alias</param>
        /// <param name="fromAccountType">Account type</param>
        /// <param name="toAccountType">Account type</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitUnifiedMarginTransferInfo>> TransferFundsAsync(string transferId, decimal amount, string currency, AccountType fromAccountType, AccountType toAccountType, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Exchange Coins
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_queryexchangerecords" /></para>
        /// </summary>
        /// <param name="fromCoint"></param>
        /// <param name="toCoint"></param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitUnifiedMarginCoinExchangeResult>>> ExchangeCoinsAsync(string? fromCoint = null, string? toCoint = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get Borrow History
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_interestbillstatement" /></para>
        /// </summary>
        /// <param name="asset">USDC, USDT, BTC, and ETH</param>
        /// <param name="startTime">Starting timestamp</param>
        /// <param name="endTime">Ending timestamp</param>
        /// <param name="direction"></param>
        /// <param name="limit"></param>
        /// <param name="cursor"></param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitCursorPage<IEnumerable<BybitUnifiedMarginBorrowRecord>>>> GetBorrowHistoryAsync(string? asset = null, DateTime? startTime = null, DateTime? endTime = null, SearchDirection? direction = null, int? limit = null, string? cursor = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get borrow rate
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_queryloaninterest" /></para>
        /// </summary>
        /// <param name="asset">Only for UDDC, USDT. If not passed, USDT-USDC interests are returned. You could pass multiple currency separated by comma, e.a USDC,USDT</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitUnifiedMarginBorrowRate>>> GetBorrowRateAsync(string? asset = null, long? receiveWindow = null, CancellationToken ct = default);

        #endregion

        /// <summary>
        /// Get 7-day Trading History
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_usertraderecords7day" /></para>
        /// </summary>
        /// <param name="category"></param>
        /// <param name="symbol">The symbol</param>
        /// <param name="baseAsset">Base coin. When category=option. If not passed, BTC by default.</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="orderFilter">Conditional order or active order</param>
        /// <param name="startTime">Filter by startTime</param>
        /// <param name="endTime">Filter by endTime</param>
        /// <param name="type">Filter by type</param>
        /// <param name="direction">Search direction</param>
        /// <param name="limit">Data quantity per page: Max data value per page is 50, and default value at 20</param>
        /// <param name="cursor">API pass-through</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitDerivativesCursorPage<IEnumerable<BybitUnifiedMarginPnlEntry>>>> GetProfitAndLossHistoryAsync(Category category, string? symbol = null, string? baseAsset = null, string? orderId = null, string? clientOrderId = null, OrderFilter? orderFilter = null, DateTime? startTime = null, DateTime? endTime = null, TradeType? type = null, SearchDirection? direction = null, int? limit = null, string? cursor = null, long? receiveWindow = null, CancellationToken ct = default);
    }
}