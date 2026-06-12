using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.V5
{
    /// <summary>
    /// Bybit trading endpoints, placing and managing orders.
    /// </summary>
    public interface IBybitRestClientApiTrading
    {
        /// <summary>
        /// Cancel all orders
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/order/cancel-all" /><br />
        /// Endpoint:<br />
        /// POST /v5/order/cancel-all
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="baseAsset">["<c>baseCoin</c>"] Filter by base asset, for example `ETH`</param>
        /// <param name="settleAsset">["<c>settleCoin</c>"] Filter by settle asset</param>
        /// <param name="orderFilter">["<c>orderFilter</c>"] Order filter</param>
        /// <param name="stopOrderType">["<c>stopOrderType</c>"] Stop order type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitOrderId>>> CancelAllOrderAsync(Category category, string? symbol = null, string? baseAsset = null, string? settleAsset = null, OrderFilter? orderFilter = null, StopOrderType? stopOrderType = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel order
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/order/cancel-order" /><br />
        /// Endpoint:<br />
        /// POST /v5/order/cancel
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">["<c>orderId</c>"] Cancel by order id</param>
        /// <param name="clientOrderId">["<c>orderLinkId</c>"] Cancel by client order id</param>
        /// <param name="orderFilter">["<c>orderFilter</c>"] Order filter</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitOrderId>> CancelOrderAsync(Category category, string symbol, string? orderId = null, string? clientOrderId = null, OrderFilter? orderFilter = null, CancellationToken ct = default);

        /// <summary>
        /// Edit an order
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/order/amend-order" /><br />
        /// Endpoint:<br />
        /// POST /v5/order/amend
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">["<c>orderId</c>"] Order id of the order to edit</param>
        /// <param name="clientOrderId">["<c>orderLinkId</c>"] Client order id of the order to edit</param>
        /// <param name="quantity">["<c>qty</c>"] New quantity</param>
        /// <param name="price">["<c>price</c>"] New price</param>
        /// <param name="triggerPrice">["<c>triggerPrice</c>"] New trigger price</param>
        /// <param name="triggerBy">["<c>triggerBy</c>"] New trigger </param>
        /// <param name="orderIv">["<c>orderIv</c>"] New order Iv</param>
        /// <param name="takeProfit">["<c>takeProfit</c>"] New take profit price</param>
        /// <param name="stopLoss">["<c>stopLoss</c>"] New stop loss price</param>
        /// <param name="takeProfitTriggerBy">["<c>tpTriggerBy</c>"] New take profit trigger</param>
        /// <param name="stopLossTriggerBy">["<c>slTriggerBy</c>"] New stop profit trigger</param>
        /// <param name="stopLossTakeProfitMode">["<c>tpslMode</c>"] New stop loss/take profit mode</param>
        /// <param name="takeProfitLimitPrice">["<c>tpLimitPrice</c>"] New take profit limit price</param>
        /// <param name="stopLossLimitPrice">["<c>slLimitPrice</c>"] New stop loss limit price</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitOrderId>> EditOrderAsync(
            Category category, 
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            decimal? quantity = null,
            decimal? price = null,
            decimal? triggerPrice = null,
            TriggerType? triggerBy = null,
            decimal? orderIv = null,
            decimal? takeProfit = null,
            decimal? stopLoss = null,
            TriggerType? takeProfitTriggerBy = null,
            TriggerType? stopLossTriggerBy = null,
            StopLossTakeProfitMode? stopLossTakeProfitMode = null,
            decimal? takeProfitLimitPrice = null,
            decimal? stopLossLimitPrice = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get asset exchange history
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/exchange" /><br />
        /// Endpoint:<br />
        /// GET /v5/asset/exchange/order-record
        /// </para>
        /// </summary>
        /// <param name="fromAsset">["<c>fromCoin</c>"] Filter by from asset</param>
        /// <param name="toAsset">["<c>toCoin</c>"] Filter by to asset</param>
        /// <param name="limit">["<c>limit</c>"] Number of results per page</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitAssetExchange[]>> GetAssetExchangeHistoryAsync(string? fromAsset = null, string? toAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get spot borrow quota
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/order/spot-borrow-quota" /><br />
        /// Endpoint:<br />
        /// GET /v5/order/spot-borrow-check
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="side">["<c>side</c>"] Side</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitBorrowQuota>> GetBorrowQuotaAsync(string symbol, OrderSide side, CancellationToken ct = default);

        /// <summary>
        /// Get delivery history
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/delivery" /><br />
        /// Endpoint:<br />
        /// GET /v5/asset/delivery-record
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="expiryDate">["<c>expDate</c>"] Filter by expiry date</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Number of results per page</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitDeliveryRecord>>> GetDeliveryHistoryAsync(Category category, string? symbol = null, DateTime? expiryDate = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get real-time open orders
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/order/open-order" /><br />
        /// Endpoint:<br />
        /// GET /v5/order/realtime
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="baseAsset">["<c>baseCoin</c>"] Filter by base asset, for example `ETH`</param>
        /// <param name="settleAsset">["<c>settleCoin</c>"] Filter by settle asset, for example `USDT`</param>
        /// <param name="orderId">["<c>orderId</c>"] Filter by order id</param>
        /// <param name="clientOrderId">["<c>orderLinkId</c>"] Filter by client order id</param>
        /// <param name="openOnly">["<c>openOnly</c>"] Open only</param>
        /// <param name="orderFilter">["<c>orderFilter</c>"] Order filter</param>
        /// <param name="limit">["<c>limit</c>"] Number of results per page</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitOrder>>> GetOrdersAsync(Category category, string? symbol = null, string? baseAsset = null, string? settleAsset = null, string? orderId = null, string? clientOrderId = null, int? openOnly = null, OrderFilter? orderFilter = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get order history
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/order/order-list" /><br />
        /// Endpoint:<br />
        /// GET /v5/order/history
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="baseAsset">["<c>baseCoin</c>"] Filter by base asset, for example `ETH`</param>
        /// <param name="orderId">["<c>orderId</c>"] Filter by order id</param>
        /// <param name="clientOrderId">["<c>orderLinkId</c>"] Filter by client order id</param>
        /// <param name="status">["<c>orderStatus</c>"] Filter by status</param>
        /// <param name="orderFilter">["<c>orderFilter</c>"] Order filter</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Number of results per page</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitOrder>>> GetOrderHistoryAsync(Category category, string? symbol = null, string? baseAsset = null, string? orderId = null, string? clientOrderId = null, OrderStatus? status = null, OrderFilter? orderFilter = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get positions
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/position" /><br />
        /// Endpoint:<br />
        /// GET /v5/position/list
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="baseAsset">["<c>baseCoin</c>"] Filter by base asset, for example `ETH`</param>
        /// <param name="settleAsset">["<c>settleCoin</c>"] Filter by settle asset, for example `USDT`</param>
        /// <param name="limit">["<c>limit</c>"] Number of results per page</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitPosition>>> GetPositionsAsync(Category category, string? symbol = null, string? baseAsset = null, string? settleAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Confirm risk limit after being marked as only reducing positions
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/position/confirm-mmr" /><br />
        /// Endpoint:<br />
        /// POST /v5/position/confirm-pending-mmr
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult> ConfirmRiskLimitAsync(Category category, string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get settlement history
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/settlement" /><br />
        /// Endpoint:<br />
        /// GET /v5/asset/settlement-record
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Number of results per page</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitSettlementRecord>>> GetSettlementHistoryAsync(Category category, string? symbol = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get user trade history
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/order/execution" /><br />
        /// Endpoint:<br />
        /// GET /v5/execution/list
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="baseAsset">["<c>baseCoin</c>"] Filter by base asset, for example `ETH`</param>
        /// <param name="orderId">["<c>orderId</c>"] Filter by order id</param>
        /// <param name="clientOrderId">["<c>orderLinkId</c>"] Filter by client order id</param>
        /// <param name="settleAsset">["<c>settleCoin</c>"] Filter by settle asset</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="tradeType">["<c>execType</c>"] Filter by trade type</param>
        /// <param name="limit">["<c>limit</c>"] Number of results per page</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitUserTrade>>> GetUserTradesAsync(
            Category category,
            string? symbol = null,
            string? baseAsset = null,
            string? orderId = null,
            string? clientOrderId = null,            
            string? settleAsset = null,
            DateTime? startTime = null, 
            DateTime? endTime = null,
            TradeType? tradeType = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default);

        /// <summary>
        /// Place an order
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/order/create-order" /><br />
        /// Endpoint:<br />
        /// POST /v5/order/create
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="side">["<c>side</c>"] Order side</param>
        /// <param name="type">["<c>orderType</c>"] Order type</param>
        /// <param name="quantity">["<c>qty</c>"] Quantity</param>
        /// <param name="price">["<c>price</c>"] Price</param>
        /// <param name="isLeverage">["<c>isLeverage</c>"] Is leverage</param>
        /// <param name="triggerDirection">["<c>triggerDirection</c>"] Conditional order direction</param>
        /// <param name="orderFilter">["<c>orderFilter</c>"] Order filter</param>
        /// <param name="triggerPrice">["<c>triggerPrice</c>"] Trigger price</param>
        /// <param name="triggerBy">["<c>triggerBy</c>"] Trigger by</param>
        /// <param name="orderIv">["<c>orderIv</c>"] Order implied volatility</param>
        /// <param name="timeInForce">["<c>timeInForce</c>"] Time in force</param>
        /// <param name="positionIdx">["<c>positionIdx</c>"] Position idx</param>
        /// <param name="clientOrderId">["<c>orderLinkId</c>"] Client order id</param>
        /// <param name="takeProfitOrderType">["<c>tpOrderType</c>"]</param>
        /// <param name="takeProfit">["<c>takeProfit</c>"] Take profit price</param>
        /// <param name="takeProfitLimitPrice">["<c>tpLimitPrice</c>"]</param>        
        /// <param name="stopLossOrderType">["<c>slOrderType</c>"]</param>
        /// <param name="stopLoss">["<c>stopLoss</c>"] Stop loss price</param>
        /// <param name="stopLossLimitPrice">["<c>slLimitPrice</c>"]</param>        
        /// <param name="takeProfitTriggerBy">["<c>tpTriggerBy</c>"] Take profit trigger</param>
        /// <param name="stopLossTriggerBy">["<c>slTriggerBy</c>"] Stop loss trigger</param>
        /// <param name="reduceOnly">["<c>reduceOnly</c>"] Is reduce only</param>
        /// <param name="closeOnTrigger">["<c>closeOnTrigger</c>"] Close on trigger</param>
        /// <param name="marketMakerProtection">["<c>mmp</c>"] Market maker protection</param>
        /// <param name="stopLossTakeProfitMode">["<c>tpslMode</c>"] StopLoss / TakeProfit mode</param>
        /// <param name="selfMatchPreventionType">["<c>smpType</c>"] Self match prevention type</param>
        /// <param name="marketUnit">["<c>marketUnit</c>"] The unit for qty when creating spot market orders for unified trading account</param>
        /// <param name="slippageToleranceType">["<c>slippageToleranceType</c>"] Slippage tolerance Type for market orders</param>
        /// <param name="slippageTolerance">["<c>slippageTolerance</c>"] Slippage tolerance value</param>
        /// <param name="bboSideType">["<c>bboSideType</c>"] BBO side type</param>
        /// <param name="bboLevel">["<c>bboLevel</c>"] BBO level (1 - 5)</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitOrderId>> PlaceOrderAsync(
            Category category, 
            string symbol, 
            OrderSide side,
            NewOrderType type,
            decimal quantity,
            decimal? price = null,
            bool? isLeverage = null,
            TriggerDirection? triggerDirection = null,
            OrderFilter? orderFilter = null,
            decimal? triggerPrice = null,
            TriggerType? triggerBy = null,
            decimal? orderIv = null,
            TimeInForce? timeInForce = null,
            PositionIdx? positionIdx = null,
            string? clientOrderId = null,
            OrderType? takeProfitOrderType = null,
            decimal? takeProfit = null,
            decimal? takeProfitLimitPrice = null,
            OrderType? stopLossOrderType = null,
            decimal? stopLoss = null,
            decimal? stopLossLimitPrice = null,
            TriggerType? takeProfitTriggerBy = null,
            TriggerType? stopLossTriggerBy = null,
            bool? reduceOnly = null,
            bool? closeOnTrigger = null,
            bool? marketMakerProtection = null,
            StopLossTakeProfitMode? stopLossTakeProfitMode = null,
            SelfMatchPreventionType? selfMatchPreventionType = null,
            MarketUnit? marketUnit = null,
            SlippageToleranceType? slippageToleranceType = null,
            decimal? slippageTolerance = null,
            BboSideType? bboSideType = null,
            int? bboLevel = null,
            CancellationToken ct = default);

        /// <summary>
        /// Set cancel all timeout on websocket disconnect
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/order/dcp" /><br />
        /// Endpoint:<br />
        /// POST /v5/order/disconnected-cancel-all
        /// </para>
        /// </summary>
        /// <param name="windowSeconds">["<c>timeWindow</c>"] Time after which to cancel all orders</param>
        /// <param name="productType">["<c>product</c>"] Type of product, defaults to Options</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult> SetDisconnectCancelAllAsync(int windowSeconds, ProductType? productType = null, CancellationToken ct = default);

        /// <summary>
        /// Get DisconnectCancelAll/dcp configuration
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/account/dcp-info" /><br />
        /// Endpoint:<br />
        /// GET /v5/account/query-dcp-info
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitDcpStatus[]>> GetDisconnectCancelAllConfigAsync(CancellationToken ct = default);

        /// <summary>
        /// Set trading stop parameters
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/position/trading-stop" /><br />
        /// Endpoint:<br />
        /// POST /v5/position/trading-stop
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="positionIdx">["<c>positionIdx</c>"] Position idx</param>
        /// <param name="takeProfit">["<c>takeProfit</c>"] Take profit price</param>
        /// <param name="stopLoss">["<c>stopLoss</c>"] Stop loss price</param>
        /// <param name="trailingStop">["<c>trailingStop</c>"] Trailing stop</param>
        /// <param name="takeProfitTrigger">["<c>tpTriggerBy</c>"] Take profit trigger</param>
        /// <param name="stopLossTrigger">["<c>slTriggerBy</c>"] Stop loss trigger</param>
        /// <param name="activePrice">["<c>activePrice</c>"] Active price</param>
        /// <param name="takeProfitQuantity">["<c>tpSize</c>"] Take profit quantity</param>
        /// <param name="stopLossQuantity">["<c>slSize</c>"] Stop loss quantity</param>
        /// <param name="stopLossTakeProfitMode">["<c>tpslMode</c>"] StopLoss/TakeProfit mode</param>
        /// <param name="takeProfitLimitPrice">["<c>tpLimitPrice</c>"] Take profit order limit price</param>
        /// <param name="stopLossLimitPrice">["<c>slLimitPrice</c>"] Stop loss order price</param>
        /// <param name="takeProfitOrderType">["<c>tpOrderType</c>"] Take profit order type</param>
        /// <param name="stopLossOrderType">["<c>slOrderType</c>"] Stop loss order type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult> SetTradingStopAsync(
            Category category, 
            string symbol, 
            PositionIdx positionIdx, 
            decimal? takeProfit = null, 
            decimal? stopLoss = null, 
            decimal? trailingStop = null, 
            TriggerType? takeProfitTrigger = null, 
            TriggerType? stopLossTrigger = null,
            decimal? activePrice = null,
            decimal? takeProfitQuantity = null, 
            decimal? stopLossQuantity = null,
            StopLossTakeProfitMode? stopLossTakeProfitMode = null,
            decimal? takeProfitLimitPrice = null,
            decimal? stopLossLimitPrice = null,
            OrderType? takeProfitOrderType = null,
            OrderType? stopLossOrderType = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get closed profit and loss
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/position/close-pnl" /><br />
        /// Endpoint:<br />
        /// GET /v5/position/closed-pnl
        /// </para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Number of results per page</param>
        /// <param name="cursor">Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitClosedPnl>>> GetClosedProfitLossAsync(Category category, string? symbol = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Place multiple orders. Note that a successful response doesn't mean all orders were correctly processed; check the order results in the call response.
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/order/batch-place" /><br />
        /// Endpoint:<br />
        /// POST /v5/order/create-batch
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] The category</param>
        /// <param name="orderRequests">["<c>request</c>"] Request data</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<CallResult<BybitBatchOrderId>[]>> PlaceMultipleOrdersAsync(
            Category category,
            IEnumerable<BybitPlaceOrderRequest> orderRequests,
            CancellationToken ct = default);

        /// <summary>
        /// Cancel multiple orders. Note that a successful response doesn't mean all orders were correctly processed; check the order results in the call response.
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/order/batch-cancel" /><br />
        /// Endpoint:<br />
        /// POST /v5/order/cancel-batch
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] The category</param>
        /// <param name="orderRequests">["<c>request</c>"] Request data</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitBatchResult<BybitBatchOrderId>[]>> CancelMultipleOrdersAsync(
            Category category,
            IEnumerable<BybitCancelOrderRequest> orderRequests,
            CancellationToken ct = default);

        /// <summary>
        /// Edit multiple orders. Note that a successful response doesn't mean all orders were correctly processed; check the order results in the call response.
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/order/batch-amend" /><br />
        /// Endpoint:<br />
        /// POST /v5/order/amend-batch
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] The category</param>
        /// <param name="orderRequests">["<c>request</c>"] Request data</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitBatchResult<BybitBatchOrderId>[]>> EditMultipleOrdersAsync(
            Category category,
            IEnumerable<BybitEditOrderRequest> orderRequests,
            CancellationToken ct = default);

        /// <summary>
        /// Purchase a leverage token
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/lt/purchase" /><br />
        /// Endpoint:<br />
        /// POST /v5/spot-lever-token/purchase
        /// </para>
        /// </summary>
        /// <param name="token">["<c>ltCoin</c>"] Token id</param>
        /// <param name="quantity">["<c>ltAmount</c>"] Quantity</param>
        /// <param name="clientOrderId">["<c>serialNo</c>"] Custom order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitLeverageTokenPurchase>> PurchaseLeverageTokenAsync(string token, decimal quantity, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Redeem a leverage token
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/lt/redeem" /><br />
        /// Endpoint:<br />
        /// POST /v5/spot-lever-token/redeem
        /// </para>
        /// </summary>
        /// <param name="token">["<c>ltCoin</c>"] Token id</param>
        /// <param name="quantity">["<c>ltAmount</c>"] Quantity</param>
        /// <param name="clientOrderId">["<c>serialNo</c>"] Custom order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitLeverageTokenRedemption>> RedeemLeverageTokenAsync(string token, decimal quantity, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Get leverage token order history
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/lt/order-record" /><br />
        /// Endpoint:<br />
        /// GET /v5/spot-lever-token/order-record
        /// </para>
        /// </summary>
        /// <param name="token">["<c>ltCoin</c>"] Filter by token</param>
        /// <param name="orderId">["<c>orderId</c>"] Filter by order id</param>
        /// <param name="clientOrderId">["<c>serialNo</c>"] Filter by client order id</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results</param>
        /// <param name="type">["<c>ltOrderType</c>"] Filter by type or record</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitLeverageTokenHistory[]>> GetLeverageTokenOrderHistoryAsync(string? token = null, string? orderId = null, string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, LeverageTokenRecordType? type = null, CancellationToken ct = default);

        /// <summary>
        /// Place a new spread order
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/spread/trade/create-order" /><br />
        /// Endpoint:<br />
        /// POST /v5/spread/order/create
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] The symbol</param>
        /// <param name="side">["<c>side</c>"] Order side</param>
        /// <param name="type">["<c>orderType</c>"] Order type</param>
        /// <param name="quantity">["<c>qty</c>"] Order quantity</param>
        /// <param name="timeInForce">["<c>timeInForce</c>"] Time in force</param>
        /// <param name="price">["<c>price</c>"] Limit price</param>
        /// <param name="clientOrderId">["<c>orderLinkId</c>"] Client order id</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitOrderId>> PlaceSpreadOrderAsync(string symbol, OrderSide side, NewOrderType type, decimal quantity, TimeInForce timeInForce, decimal? price = null, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Edit an active spread order
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/spread/trade/amend-order" /><br />
        /// Endpoint:<br />
        /// POST /v5/spread/order/amend
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">["<c>orderId</c>"] Order id, either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">["<c>orderLinkId</c>"] Order id, either this or orderId should be provided</param>
        /// <param name="quantity">["<c>qty</c>"] New quantity</param>
        /// <param name="price">["<c>price</c>"] New price</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitOrderId>> EditSpreadOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, decimal? quantity = null, decimal? price = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel an active spread order
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/spread/trade/cancel-order" /><br />
        /// Endpoint:<br />
        /// POST /v5/spread/order/cancel
        /// </para>
        /// </summary>
        /// <param name="orderId">["<c>orderId</c>"] Order id of order to cancel, either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">["<c>orderLinkId</c>"] Client order id of order to cancel, either this or orderId should be provided</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitOrderId>> CancelSpreadOrderAsync(string? orderId = null, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel all spread orders
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/spread/trade/cancel-all" /><br />
        /// Endpoint:<br />
        /// POST /v5/spread/order/cancel-all
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] Filter orders to cancel by symbol</param>
        /// <param name="cancelAll">["<c>cancelAll</c>"] Cancel all</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitOrderId[]>> CancelAllSpreadOrdersAsync(string? symbol = null, bool? cancelAll = null, CancellationToken ct = default);

        /// <summary>
        /// Get open spread orders
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/spread/trade/open-order" /><br />
        /// Endpoint:<br />
        /// GET /v5/spread/order/realtime
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol</param>
        /// <param name="baseAsset">["<c>baseCoin</c>"] Filter by base asset</param>
        /// <param name="orderId">["<c>orderId</c>"] Filter by order id</param>
        /// <param name="clientOrderId">["<c>orderLinkId</c>"] Filter by client order id</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitResponse<BybitSpreadOrder>>> GetOpenSpreadOrdersAsync(string? symbol = null, string? baseAsset = null, string? orderId = null, string? clientOrderId = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get spread order history
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/spread/trade/order-history" /><br />
        /// Endpoint:<br />
        /// GET /v5/spread/order/history
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol</param>
        /// <param name="baseAsset">["<c>baseCoin</c>"] Filter by base asset</param>
        /// <param name="orderId">["<c>orderId</c>"] Filter by order id</param>
        /// <param name="clientOrderId">["<c>orderLinkId</c>"] Filter by client order id</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results, max 50</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitResponse<BybitClosedSpreadOrder>>> GetClosedSpreadOrdersAsync(string? symbol = null, string? baseAsset = null, string? orderId = null, string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// 
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/spread/trade/trade-history" /><br />
        /// Endpoint:<br />
        /// GET /v5/spread/execution/list
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol</param>
        /// <param name="orderId">["<c>orderId</c>"] Filter by order id</param>
        /// <param name="clientOrderId">["<c>orderLinkId</c>"] Filter by client order id</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results, max 50</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitResponse<BybitSpreadUserTrade>>> GetSpreadUserTradesAsync(string? symbol = null, string? orderId = null, string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Calculate margin changes for an order before placing it
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/order/pre-check-order" /><br />
        /// Endpoint:<br />
        /// POST /v5/order/pre-check
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="side">["<c>side</c>"] Order side</param>
        /// <param name="type">["<c>orderType</c>"] Order type</param>
        /// <param name="quantity">["<c>qty</c>"] Quantity</param>
        /// <param name="price">["<c>price</c>"] Price</param>
        /// <param name="isLeverage">["<c>isLeverage</c>"] Is leverage</param>
        /// <param name="triggerDirection">["<c>triggerDirection</c>"] Conditional order direction</param>
        /// <param name="orderFilter">["<c>orderFilter</c>"] Order filter</param>
        /// <param name="triggerPrice">["<c>triggerPrice</c>"] Trigger price</param>
        /// <param name="triggerBy">["<c>triggerBy</c>"] Trigger by</param>
        /// <param name="orderIv">["<c>orderIv</c>"] Order implied volatility</param>
        /// <param name="timeInForce">["<c>timeInForce</c>"] Time in force</param>
        /// <param name="positionIdx">["<c>positionIdx</c>"] Position idx</param>
        /// <param name="clientOrderId">["<c>orderLinkId</c>"] Client order id</param>
        /// <param name="takeProfitOrderType">["<c>tpOrderType</c>"]</param>
        /// <param name="takeProfit">["<c>takeProfit</c>"] Take profit price</param>
        /// <param name="takeProfitLimitPrice">["<c>tpLimitPrice</c>"]</param>        
        /// <param name="stopLossOrderType">["<c>slOrderType</c>"]</param>
        /// <param name="stopLoss">["<c>stopLoss</c>"] Stop loss price</param>
        /// <param name="stopLossLimitPrice">["<c>slLimitPrice</c>"]</param>        
        /// <param name="takeProfitTriggerBy">["<c>tpTriggerBy</c>"] Take profit trigger</param>
        /// <param name="stopLossTriggerBy">["<c>slTriggerBy</c>"] Stop loss trigger</param>
        /// <param name="reduceOnly">["<c>reduceOnly</c>"] Is reduce only</param>
        /// <param name="closeOnTrigger">["<c>closeOnTrigger</c>"] Close on trigger</param>
        /// <param name="marketMakerProtection">["<c>mmp</c>"] Market maker protection</param>
        /// <param name="stopLossTakeProfitMode">["<c>tpslMode</c>"] StopLoss / TakeProfit mode</param>
        /// <param name="selfMatchPreventionType">["<c>smpType</c>"] Self match prevention type</param>
        /// <param name="marketUnit">["<c>marketUnit</c>"] The unit for qty when creating spot market orders for unified trading account</param>
        /// <param name="slippageToleranceType">["<c>slippageToleranceType</c>"] Slippage tolerance Type for market orders</param>
        /// <param name="slippageTolerance">["<c>slippageTolerance</c>"] Slippage tolerance value</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitPreCheckResult>> PreCheckOrderAsync(Category category,
            string symbol,
            OrderSide side,
            NewOrderType type,
            decimal quantity,
            decimal? price = null,
            bool? isLeverage = null,
            TriggerDirection? triggerDirection = null,
            OrderFilter? orderFilter = null,
            decimal? triggerPrice = null,
            TriggerType? triggerBy = null,
            decimal? orderIv = null,
            TimeInForce? timeInForce = null,
            PositionIdx? positionIdx = null,
            string? clientOrderId = null,
            OrderType? takeProfitOrderType = null,
            decimal? takeProfit = null,
            decimal? takeProfitLimitPrice = null,
            OrderType? stopLossOrderType = null,
            decimal? stopLoss = null,
            decimal? stopLossLimitPrice = null,
            TriggerType? takeProfitTriggerBy = null,
            TriggerType? stopLossTriggerBy = null,
            bool? reduceOnly = null,
            bool? closeOnTrigger = null,
            bool? marketMakerProtection = null,
            StopLossTakeProfitMode? stopLossTakeProfitMode = null,
            SelfMatchPreventionType? selfMatchPreventionType = null,
            MarketUnit? marketUnit = null,
            SlippageToleranceType? slippageToleranceType = null,
            decimal? slippageTolerance = null,
            CancellationToken ct = default);

    }
}
