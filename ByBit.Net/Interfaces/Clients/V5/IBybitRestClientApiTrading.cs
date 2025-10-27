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
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/order/cancel-all" /></para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="baseAsset">Filter by base asset, for example `ETH`</param>
        /// <param name="settleAsset">Filter by settle asset</param>
        /// <param name="orderFilter">Order filter</param>
        /// <param name="stopOrderType">Stop order type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitOrderId>>> CancelAllOrderAsync(Category category, string? symbol = null, string? baseAsset = null, string? settleAsset = null, OrderFilter? orderFilter = null, StopOrderType? stopOrderType = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel order
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/order/cancel-order" /></para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">Cancel by order id</param>
        /// <param name="clientOrderId">Cancel by client order id</param>
        /// <param name="orderFilter">Order filter</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitOrderId>> CancelOrderAsync(Category category, string symbol, string? orderId = null, string? clientOrderId = null, OrderFilter? orderFilter = null, CancellationToken ct = default);

        /// <summary>
        /// Edit an order
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/order/amend-order" /></para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">Order id of the order to edit</param>
        /// <param name="clientOrderId">Client order id of the order to edit</param>
        /// <param name="quantity">New quantity</param>
        /// <param name="price">New price</param>
        /// <param name="triggerPrice">New trigger price</param>
        /// <param name="triggerBy">New trigger </param>
        /// <param name="orderIv">New order Iv</param>
        /// <param name="takeProfit">New take profit price</param>
        /// <param name="stopLoss">New stop loss price</param>
        /// <param name="takeProfitTriggerBy">New take profit trigger</param>
        /// <param name="stopLossTriggerBy">New stop profit trigger</param>
        /// <param name="stopLossTakeProfitMode">New stop loss/take profit mode</param>
        /// <param name="takeProfitLimitPrice">New take profit limit price</param>
        /// <param name="stopLossLimitPrice">New stop loss limit price</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitOrderId>> EditOrderAsync(
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
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/asset/exchange" /></para>
        /// </summary>
        /// <param name="fromAsset">Filter by from asset</param>
        /// <param name="toAsset">Filter by to asset</param>
        /// <param name="limit">Number of results per page</param>
        /// <param name="cursor">Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitAssetExchange[]>> GetAssetExchangeHistoryAsync(string? fromAsset = null, string? toAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get spot borrow quota
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/order/spot-borrow-quota" /></para>
        /// </summary>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="side">Side</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitBorrowQuota>> GetBorrowQuotaAsync(string symbol, OrderSide side, CancellationToken ct = default);

        /// <summary>
        /// Get delivery history
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/asset/delivery" /></para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="expiryDate">Filter by expiry date</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Number of results per page</param>
        /// <param name="cursor">Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitDeliveryRecord>>> GetDeliveryHistoryAsync(Category category, string? symbol = null, DateTime? expiryDate = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get real-time open orders
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/order/open-order" /></para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="baseAsset">Filter by base asset, for example `ETH`</param>
        /// <param name="settleAsset">Filter by settle asset, for example `USDT`</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="openOnly">Open only</param>
        /// <param name="orderFilter">Order filter</param>
        /// <param name="limit">Number of results per page</param>
        /// <param name="cursor">Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitOrder>>> GetOrdersAsync(Category category, string? symbol = null, string? baseAsset = null, string? settleAsset = null, string? orderId = null, string? clientOrderId = null, int? openOnly = null, OrderFilter? orderFilter = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get order history
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/order/order-list" /></para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="baseAsset">Filter by base asset, for example `ETH`</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="status">Filter by status</param>
        /// <param name="orderFilter">Order filter</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Number of results per page</param>
        /// <param name="cursor">Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitOrder>>> GetOrderHistoryAsync(Category category, string? symbol = null, string? baseAsset = null, string? orderId = null, string? clientOrderId = null, OrderStatus? status = null, OrderFilter? orderFilter = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get positions
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/position" /></para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="baseAsset">Filter by base asset, for example `ETH`</param>
        /// <param name="settleAsset">Filter by settle asset, for example `USDT`</param>
        /// <param name="limit">Number of results per page</param>
        /// <param name="cursor">Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitPosition>>> GetPositionsAsync(Category category, string? symbol = null, string? baseAsset = null, string? settleAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Confirm risk limit after being marked as only reducing positions
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/position/confirm-mmr" /></para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> ConfirmRiskLimitAsync(Category category, string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get settlement history
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/asset/settlement" /></para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Number of results per page</param>
        /// <param name="cursor">Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitSettlementRecord>>> GetSettlementHistoryAsync(Category category, string? symbol = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get user trade history
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/order/execution" /></para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="baseAsset">Filter by base asset, for example `ETH`</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="tradeType">Filter by trade type</param>
        /// <param name="limit">Number of results per page</param>
        /// <param name="cursor">Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitUserTrade>>> GetUserTradesAsync(Category category, string? symbol = null, string? baseAsset = null, string? orderId = null, string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, TradeType? tradeType = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Place an order
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/order/create-order" /></para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="side">Order side</param>
        /// <param name="type">Order type</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="price">Price</param>
        /// <param name="isLeverage">Is leverage</param>
        /// <param name="triggerDirection">Conditional order direction</param>
        /// <param name="orderFilter">Order filter</param>
        /// <param name="triggerPrice">Trigger price</param>
        /// <param name="triggerBy">Trigger by</param>
        /// <param name="orderIv">Order implied volatility</param>
        /// <param name="timeInForce">Time in force</param>
        /// <param name="positionIdx">Position idx</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="takeProfitOrderType"></param>
        /// <param name="takeProfit">Take profit price</param>
        /// <param name="takeProfitLimitPrice"></param>        
        /// <param name="stopLossOrderType"></param>
        /// <param name="stopLoss">Stop loss price</param>
        /// <param name="stopLossLimitPrice"></param>        
        /// <param name="takeProfitTriggerBy">Take profit trigger</param>
        /// <param name="stopLossTriggerBy">Stop loss trigger</param>
        /// <param name="reduceOnly">Is reduce only</param>
        /// <param name="closeOnTrigger">Close on trigger</param>
        /// <param name="marketMakerProtection">Market maker protection</param>
        /// <param name="stopLossTakeProfitMode">StopLoss / TakeProfit mode</param>
        /// <param name="selfMatchPreventionType">Self match prevention type</param>
        /// <param name="marketUnit">The unit for qty when creating spot market orders for unified trading account</param>
        /// <param name="slippageToleranceType">Slippage tolerance Type for market orders</param>
        /// <param name="slippageTolerance">Slippage tolerance value</param>
        /// <param name="bboSideType">BBO side type</param>
        /// <param name="bboLevel">BBO level (1 - 5)</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitOrderId>> PlaceOrderAsync(
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
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/order/dcp" /></para>
        /// </summary>
        /// <param name="windowSeconds">Time after which to cancel all orders</param>
        /// <param name="productType">Type of product, defaults to Options</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetDisconnectCancelAllAsync(int windowSeconds, ProductType? productType = null, CancellationToken ct = default);

        /// <summary>
        /// Get DisconnectCancelAll/dcp configuration
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/account/dcp-info" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitDcpStatus[]>> GetDisconnectCancelAllConfigAsync(CancellationToken ct = default);

        /// <summary>
        /// Set trading stop parameters
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/position/trading-stop" /></para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="positionIdx">Position idx</param>
        /// <param name="takeProfit">Take profit price</param>
        /// <param name="stopLoss">Stop loss price</param>
        /// <param name="trailingStop">Trailing stop</param>
        /// <param name="takeProfitTrigger">Take profit trigger</param>
        /// <param name="stopLossTrigger">Stop loss trigger</param>
        /// <param name="activePrice">Active price</param>
        /// <param name="takeProfitQuantity">Take profit quantity</param>
        /// <param name="stopLossQuantity">Stop loss quantity</param>
        /// <param name="stopLossTakeProfitMode">StopLoss/TakeProfit mode</param>
        /// <param name="takeProfitLimitPrice">Take profit order limit price</param>
        /// <param name="stopLossLimitPrice">Stop loss order price</param>
        /// <param name="takeProfitOrderType">Take profit order type</param>
        /// <param name="stopLossOrderType">Stop loss order type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetTradingStopAsync(
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
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/position/close-pnl" /></para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Number of results per page</param>
        /// <param name="cursor">Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitClosedPnl>>> GetClosedProfitLossAsync(Category category, string? symbol = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Place multiple orders. Note that a successful response doesn't mean all orders were correctly processed; check the order results in the call response.
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/order/batch-place" /></para>
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="orderRequests">Request data</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<CallResult<BybitBatchOrderId>[]>> PlaceMultipleOrdersAsync(
            Category category,
            IEnumerable<BybitPlaceOrderRequest> orderRequests,
            CancellationToken ct = default);

        /// <summary>
        /// Cancel multiple orders. Note that a successful response doesn't mean all orders were correctly processed; check the order results in the call response.
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/order/batch-cancel" /></para>
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="orderRequests">Request data</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitBatchResult<BybitBatchOrderId>[]>> CancelMultipleOrdersAsync(
            Category category,
            IEnumerable<BybitCancelOrderRequest> orderRequests,
            CancellationToken ct = default);

        /// <summary>
        /// Edit multiple orders. Note that a successful response doesn't mean all orders were correctly processed; check the order results in the call response.
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/order/batch-amend" /></para>
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="orderRequests">Request data</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitBatchResult<BybitBatchOrderId>[]>> EditMultipleOrdersAsync(
            Category category,
            IEnumerable<BybitEditOrderRequest> orderRequests,
            CancellationToken ct = default);

        /// <summary>
        /// Purchase a leverage token
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/lt/purchase" /></para>
        /// </summary>
        /// <param name="token">Token id</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="clientOrderId">Custom order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitLeverageTokenPurchase>> PurchaseLeverageTokenAsync(string token, decimal quantity, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Redeem a leverage token
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/lt/redeem" /></para>
        /// </summary>
        /// <param name="token">Token id</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="clientOrderId">Custom order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitLeverageTokenRedemption>> RedeemLeverageTokenAsync(string token, decimal quantity, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Get leverage token order history
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/lt/order-record" /></para>
        /// </summary>
        /// <param name="token">Filter by token</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="type">Filter by type or record</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitLeverageTokenHistory[]>> GetLeverageTokenOrderHistoryAsync(string? token = null, string? orderId = null, string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, LeverageTokenRecordType? type = null, CancellationToken ct = default);

        /// <summary>
        /// Place a new spread order
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/spread/trade/create-order" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="side">Order side</param>
        /// <param name="type">Order type</param>
        /// <param name="quantity">Order quantity</param>
        /// <param name="timeInForce">Time in force</param>
        /// <param name="price">Limit price</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitOrderId>> PlaceSpreadOrderAsync(string symbol, OrderSide side, NewOrderType type, decimal quantity, TimeInForce timeInForce, decimal? price = null, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Edit an active spread order
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/spread/trade/amend-order" /></para>
        /// </summary>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">Order id, either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">Order id, either this or orderId should be provided</param>
        /// <param name="quantity">New quantity</param>
        /// <param name="price">New price</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitOrderId>> EditSpreadOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, decimal? quantity = null, decimal? price = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel an active spread order
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/spread/trade/cancel-order" /></para>
        /// </summary>
        /// <param name="orderId">Order id of order to cancel, either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">Client order id of order to cancel, either this or orderId should be provided</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitOrderId>> CancelSpreadOrderAsync(string? orderId = null, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel all spread orders
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/spread/trade/cancel-all" /></para>
        /// </summary>
        /// <param name="symbol">Filter orders to cancel by symbol</param>
        /// <param name="cancelAll">Cancel all</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitOrderId[]>> CancelAllSpreadOrdersAsync(string? symbol = null, bool? cancelAll = null, CancellationToken ct = default);

        /// <summary>
        /// Get open spread orders
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/spread/trade/open-order" /></para>
        /// </summary>
        /// <param name="symbol">Filter by symbol</param>
        /// <param name="baseAsset">Filter by base asset</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="cursor">Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitResponse<BybitSpreadOrder>>> GetOpenSpreadOrdersAsync(string? symbol = null, string? baseAsset = null, string? orderId = null, string? clientOrderId = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get spread order history
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/spread/trade/order-history" /></para>
        /// </summary>
        /// <param name="symbol">Filter by symbol</param>
        /// <param name="baseAsset">Filter by base asset</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results, max 50</param>
        /// <param name="cursor">Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitResponse<BybitClosedSpreadOrder>>> GetClosedSpreadOrdersAsync(string? symbol = null, string? baseAsset = null, string? orderId = null, string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// 
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/spread/trade/trade-history" /></para>
        /// </summary>
        /// <param name="symbol">Filter by symbol</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results, max 50</param>
        /// <param name="cursor">Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitResponse<BybitSpreadUserTrade>>> GetSpreadUserTradesAsync(string? symbol = null, string? orderId = null, string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Calculate margin changes for an order before placing it
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/order/pre-check-order" /></para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="side">Order side</param>
        /// <param name="type">Order type</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="price">Price</param>
        /// <param name="isLeverage">Is leverage</param>
        /// <param name="triggerDirection">Conditional order direction</param>
        /// <param name="orderFilter">Order filter</param>
        /// <param name="triggerPrice">Trigger price</param>
        /// <param name="triggerBy">Trigger by</param>
        /// <param name="orderIv">Order implied volatility</param>
        /// <param name="timeInForce">Time in force</param>
        /// <param name="positionIdx">Position idx</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="takeProfitOrderType"></param>
        /// <param name="takeProfit">Take profit price</param>
        /// <param name="takeProfitLimitPrice"></param>        
        /// <param name="stopLossOrderType"></param>
        /// <param name="stopLoss">Stop loss price</param>
        /// <param name="stopLossLimitPrice"></param>        
        /// <param name="takeProfitTriggerBy">Take profit trigger</param>
        /// <param name="stopLossTriggerBy">Stop loss trigger</param>
        /// <param name="reduceOnly">Is reduce only</param>
        /// <param name="closeOnTrigger">Close on trigger</param>
        /// <param name="marketMakerProtection">Market maker protection</param>
        /// <param name="stopLossTakeProfitMode">StopLoss / TakeProfit mode</param>
        /// <param name="selfMatchPreventionType">Self match prevention type</param>
        /// <param name="marketUnit">The unit for qty when creating spot market orders for unified trading account</param>
        /// <param name="slippageToleranceType">Slippage tolerance Type for market orders</param>
        /// <param name="slippageTolerance">Slippage tolerance value</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitPreCheckResult>> PreCheckOrderAsync(Category category,
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
