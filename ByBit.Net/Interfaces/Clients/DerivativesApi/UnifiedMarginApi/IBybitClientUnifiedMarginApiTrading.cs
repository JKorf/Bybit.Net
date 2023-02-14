using Bybit.Net.Enums;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Models.Derivatives;
using Bybit.Net.Objects.Models.Derivatives.UnifiedMargin;
using CryptoExchange.Net.Objects;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.DerivativesApi.UnifiedMarginApi
{
    /// <summary>
    /// Bybit trading endpoints, placing and managing orders.
    /// </summary>
    public interface IBybitClientUnifiedMarginApiTrading
    {
        #region Orders

        /// <summary>
        /// Place a new order
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_placeorder" /></para>
        /// </summary>
        /// <param name="category">Type of derivatives product: linear or option.</param>
        /// <param name="symbol">The symbol</param>
        /// <param name="side">Order side</param>
        /// <param name="type">Order type</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="timeInForce">Time in force</param>
        /// <param name="reduceOnly">True means your position can only reduce in size if this order is triggered</param>
        /// <param name="closeOnTrigger">For a closing order. It can only reduce your position, not increase it. If the account has insufficient available balance when the closing order is triggered, then other active orders of similar contracts will be cancelled or reduced. It can be used to ensure your stop loss reduces your position regardless of current available margin.</param>
        /// <param name="marketMakerProtection">Market maker protection, "true" means this order is a market maker protection order.</param>
        /// <param name="price">c</param>
        /// <param name="basePrice">It will be used to compare with the value of triggerPrice, to decide whether your conditional order will be triggered by crossing trigger price from upper side or lower side. Mainly used to identify the expected direction of the current conditional order.</param>
        /// <param name="triggerPrice">Trigger price. If you're expecting the price to rise to trigger your conditional order, make sure triggerPrice more max(market price, basePrice) else, triggerPrice less min (market price, basePrice)</param>
        /// <param name="positionMode">Position mode</param>
        /// <param name="triggerType">Trigger price type: Market price/Mark price</param>
        /// <param name="iv">Implied volatility, for options only; parameters are passed according to the real value; for example, for 10%, 0.1 is passed</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="takeProfitPrice">Take profit price, only take effect upon opening the position</param>
        /// <param name="stopLossPrice">Stop loss price, only take effect upon opening the position</param>
        /// <param name="takeProfitTriggerType">Take profit trigger price type, default: LastPrice</param>
        /// <param name="stopLossTriggerType">Stop loss trigger price type, default: LastPrice</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitDerivativesOrderId>> PlaceOrderAsync(Category category, string symbol, OrderSide side, OrderType type, decimal quantity, TimeInForce timeInForce, decimal? price = null, decimal? basePrice = null, decimal? triggerPrice = null, PositionMode? positionMode = null, TriggerType? triggerType = null, decimal? iv = null, string? clientOrderId = null, decimal? takeProfitPrice = null, decimal? stopLossPrice = null, TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null, bool? reduceOnly = null, bool? closeOnTrigger = null, bool? marketMakerProtection = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Change an exising order. Either orderId or clientOrderId should be provided
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_replaceorder" /></para>
        /// </summary>
        /// <param name="category">Type of derivatives product: linear or option.</param>
        /// <param name="symbol">The symbol</param>
        /// <param name="orderId">Order ID. Required if not passing orderLinkId</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="orderFilter">Conditional order or active order</param>
        /// <param name="iv">Implied volatility, for options only; parameters are passed according to the real value; for example, for 10%, 0.1 is passed</param>
        /// <param name="triggerPrice">Trigger price</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="price">Quantity</param>
        /// <param name="takeProfitPrice">Take profit price, only take effect upon opening the position</param>
        /// <param name="stopLossPrice">Stop loss price, only take effect upon opening the position</param>
        /// <param name="takeProfitTriggerType">Take profit trigger price type, default: LastPrice</param>
        /// <param name="stopLossTriggerType">Stop loss trigger price type, default: LastPrice</param>>
        /// <param name="triggerType">Trigger price type: Market price/Mark price</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitDerivativesOrderId>> ReplaceOrderAsync(Category category, string symbol, string? orderId = null, string? clientOrderId = null, OrderFilter? orderFilter = null, decimal? iv = null, decimal? triggerPrice = null, decimal? quantity = null, decimal? price = null, decimal? takeProfitPrice = null, decimal? stopLossPrice = null, TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null, TriggerType? triggerType = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel an order, either orderId or clientOrderId should be provided
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_cancelorder" /></para>
        /// </summary>
        /// <param name="category">Type of derivatives product: linear or option</param>
        /// <param name="symbol">The symbol</param>
        /// <param name="orderId">The id of the order to cancel</param>
        /// <param name="clientOrderId">The client order id of the conditional order to cancel</param>
        /// <param name="orderFilter">Conditional order or active order</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitDerivativesOrderId>> CancelOrderAsync(Category category, string symbol, string? orderId = null, string? clientOrderId = null, OrderFilter? orderFilter = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel all active orders for a symbol
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_cancelallorders" /></para>
        /// </summary>
        /// <param name="category">Type of derivatives product: linear or option</param>
        /// <param name="baseAsset">Base Coin</param>
        /// <param name="settleAsset">Settle Coin. It's invalid for option</param>
        /// <param name="symbol">The symbol</param>
        /// <param name="orderFilter">Conditional order or active order</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitUnifiedMarginCancelledOrder>>> CancelAllOrdersAsync(Category category, string? baseAsset = null, string? settleAsset = null, string? symbol = null, OrderFilter? orderFilter = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get orders
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_getorder" /></para>
        /// </summary>
        /// <param name="category"></param>
        /// <param name="symbol">The symbol</param>
        /// <param name="baseAsset"></param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="status">Filter by status</param>
        /// <param name="orderFilter">Conditional order or active order</param>
        /// <param name="direction">Search direction</param>
        /// <param name="limit">Data quantity per page: Max data value per page is 50, and default value at 20</param>
        /// <param name="cursor">API pass-through</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitDerivativesCursorPage<IEnumerable<BybitUnifiedMarginOrder>>>> GetOrdersAsync(Category category, string? symbol = null, string? baseAsset = null, string? orderId = null, string? clientOrderId = null, OrderStatus? status = null, OrderFilter? orderFilter = null, SearchDirection? direction = null, int? limit = null, string? cursor = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get orders
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_queryorderrealtime" /></para>
        /// </summary>
        /// <param name="category"></param>
        /// <param name="symbol">The symbol</param>
        /// <param name="baseAsset">Base coin. When category=option. If not passed, BTC by default.</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="orderFilter">Conditional order or active order</param>
        /// <param name="direction">Search direction</param>
        /// <param name="limit">Data quantity per page: Max data value per page is 50, and default value at 20</param>
        /// <param name="cursor">API pass-through</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitDerivativesCursorPage<IEnumerable<BybitUnifiedMarginOrder>>>> GetOpenOrdersRealTimeAsync(Category category, string? symbol = null, string? baseAsset = null, string? orderId = null, string? clientOrderId = null, OrderFilter? orderFilter = null, SearchDirection? direction = null, int? limit = null, string? cursor = null, long? receiveWindow = null, CancellationToken ct = default);

        #endregion
    }
}