using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.V5
{
    /// <summary>
    /// Bybit user data streams
    /// </summary>
    public interface IBybitSocketClientPrivateApi : ISocketApiClient
    {
        /// <summary>
        /// Get the shared socket subscription client. This interface is shared with other exchanges to allow for a common implementation for different exchanges.
        /// </summary>
        IBybitSocketClientPrivateApiShared SharedClient { get; }

        /// <summary>
        /// Subscribe to Greek updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/private/greek" /></para>
        /// </summary>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToGreekUpdatesAsync(Action<DataEvent<BybitGreeks[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to order updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/private/order" /></para>
        /// </summary>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<BybitOrderUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to position updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/private/position" /></para>
        /// </summary>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(Action<DataEvent<BybitPositionUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to trade updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/private/execution" /></para>
        /// </summary>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(Action<DataEvent<BybitUserTradeUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to minimal trade updates. There is less data available, but updates are pushed significantly faster
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/private/fast-execution" /></para>
        /// </summary>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToMinimalUserTradeUpdatesAsync(Action<DataEvent<BybitMinimalUserTradeUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to wallet balance updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/private/wallet" /></para>
        /// </summary>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToWalletUpdatesAsync(Action<DataEvent<BybitBalance[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to spread order updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/spread/websocket/private/order" /></para>
        /// </summary>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToSpreadOrderUpdatesAsync(Action<DataEvent<BybitOrderUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to spread user trade updates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/spread/websocket/private/execution" /></para>
        /// </summary>
        /// <param name="handler">Data handler</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToSpreadUserTradeUpdatesAsync(Action<DataEvent<BybitSpreadUserTradeUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Place a new order
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/trade/guideline" /></para>
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
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<CallResult<BybitOrderId>> PlaceOrderAsync(Category category,
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
            CancellationToken ct = default);

        /// <summary>
        /// Edit an order
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/trade/guideline" /></para>
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
        Task<CallResult<BybitOrderId>> EditOrderAsync(Category category,
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
        /// Cancel an order
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/trade/guideline" /></para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">Cancel by order id</param>
        /// <param name="clientOrderId">Cancel by client order id</param>
        /// <param name="orderFilter">Order filter</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<CallResult<BybitOrderId>> CancelOrderAsync(Category category,
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            OrderFilter? orderFilter = null,
            CancellationToken ct = default);

        /// <summary>
        /// Place multiple orders
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/trade/guideline#request-parameters-2" /></para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="orderRequests">Order requests</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<CallResult<CallResult<BybitBatchOrderId>[]>> PlaceMultipleOrdersAsync(
            Category category,
            IEnumerable<BybitPlaceOrderRequest> orderRequests,
            CancellationToken ct = default);

        /// <summary>
        /// Edit multiple orders
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/trade/guideline#request-parameters-2" /></para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="orderRequests">Order requests</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<CallResult<BybitBatchResult<BybitBatchOrderId>[]>> EditMultipleOrdersAsync(
            Category category,
            IEnumerable<BybitEditOrderRequest> orderRequests,
            CancellationToken ct = default);

        /// <summary>
        /// Cancel multiple orders
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/trade/guideline#request-parameters-2" /></para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="orderRequests">Order requests</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<CallResult<BybitBatchResult<BybitBatchOrderId>[]>> CancelMultipleOrdersAsync(
            Category category,
            IEnumerable<BybitCancelOrderRequest> orderRequests,
            CancellationToken ct = default);

        /// <summary>
        /// Subscribe to disconnect cancel all topics. It doesn't provide updates, but works with the <see href="https://bybit-exchange.github.io/docs/v5/order/dcp">DisconnectCancelAll</see> configuration
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/websocket/private/dcp" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="ct">Cancellation token. Cancelling will cancel the subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToDisconnectCancelAllTopicAsync(ProductType productType, CancellationToken ct = default);
    }
}
