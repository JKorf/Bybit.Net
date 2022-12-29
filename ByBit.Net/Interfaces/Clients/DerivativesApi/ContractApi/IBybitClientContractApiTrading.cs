using Bybit.Net.Enums;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Models.Contract;
using Bybit.Net.Objects.Models.Derivatives;
using CryptoExchange.Net.Objects;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.DerivativesApi.ContractApi
{
    /// <summary>
    /// Bybit trading endpoints, placing and managing orders.
    /// </summary>
    public interface IBybitClientContractApiTrading
    {
        #region Orders
        /// <summary>
        /// Place a new order
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-dv_placeorder" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="side">Order side</param>
        /// <param name="type">Order type</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="timeInForce">Time in force</param>
        /// <param name="price">Price</param>
        /// <param name="reduceOnly">True means your position can only reduce in size if this order is triggered</param>
        /// <param name="closeOnTrigger">For a closing order. It can only reduce your position, not increase it. If the account has insufficient available balance when the closing order is triggered, then other active orders of similar contracts will be cancelled or reduced. It can be used to ensure your stop loss reduces your position regardless of current available margin.</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="takeProfitPrice">Take profit price, only take effect upon opening the position</param>
        /// <param name="stopLossPrice">Stop loss price, only take effect upon opening the position</param>
        /// <param name="takeProfitTriggerType">Take profit trigger price type, default: LastPrice</param>
        /// <param name="stopLossTriggerType">Stop loss trigger price type, default: LastPrice</param>
        /// <param name="positionMode">Position mode</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitDerivativesOrderId>> PlaceOrderAsync(string symbol, OrderSide side, OrderType type, decimal quantity, TimeInForce timeInForce, bool? reduceOnly = null, bool? closeOnTrigger = null, decimal? price = null, string? clientOrderId = null, decimal? takeProfitPrice = null, decimal? stopLossPrice = null, TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null, PositionMode? positionMode = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Change an exising order. Either orderId or clientOrderId should be provided
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_replaceorder" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="orderId">Order ID. Required if not passing orderLinkId</param>
        /// <param name="clientOrderId">Client order id</param>
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
        Task<WebCallResult<BybitDerivativesOrderId>> ReplaceOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, decimal? quantity = null, decimal? price = null, decimal? triggerPrice = null, decimal? takeProfitPrice = null, decimal? stopLossPrice = null, TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null, TriggerType? triggerType = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel an order, either orderId or clientOrderId should be provided
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-contract_cancelorder" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="orderId">The id of the order to cancel</param>
        /// <param name="clientOrderId">The client order id of the conditional order to cancel</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitDerivativesOrderId>> CancelOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel all orders that are unfilled or partially filled. Fully filled orders cannot be cancelled.
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-contract_cancelallorders" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="settleAsset">Cancel orders by settle coin</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitDerivativesOrderId>>> CancelAllOrdersAsync(string? symbol = null, string? settleAsset = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get orders
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-contract_getorder" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="status">Filter by status</param>
        /// <param name="orderFilter">Conditional order or active order</param>
        /// <param name="limit"> Limit for data size per page, max size is 200. Default as showing 50 pieces of data per page. </param>
        /// <param name="cursor"> Page turning mark </param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitCursorPage<IEnumerable<BybitContractOrder>>>> GetOrdersAsync(string symbol, string? orderId = null, string? clientOrderId = null, OrderStatus? status = null, OrderFilter? orderFilter = null, int? limit = null, string? cursor = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Query real-time order information
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-contract_getrealtimeorder" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="settleAsset">Settle coin. Either symbol or settleCoin is required. If both are passed, symbol is used first.</param>
        /// <param name="orderFilter">Conditional order or active order</param>
        /// <param name="limit"> Limit for data size per page, max size is 200. Default as showing 50 pieces of data per page. </param>
        /// <param name="cursor"> Page turning mark </param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitCursorPage<IEnumerable<BybitContractOrder>>>> GetOpenOrdersRealTimeAsync(string? symbol = null, string? orderId = null, string? clientOrderId = null, string? settleAsset = null, OrderFilter? orderFilter = null, int? limit = null, string? cursor = null, long? receiveWindow = null, CancellationToken ct = default);
        #endregion

        /// <summary>
        /// Set take profit, stop loss, and trailing stop for your open position. If using partial mode, TP/SL/TS orders will not close your entire position.
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="takeProfitPrice">Cannot be less than 0, 0 means cancel TP</param>
        /// <param name="stopLossPrice">Cannot be less than 0, 0 means cancel SL</param>
        /// <param name="activePrice">Trailing stop trigger price. Trailing stop will only be triggered when this price is touched </param>
        /// <param name="trailingStop">Cannot be less than 0, 0 means cancel TS</param>
        /// <param name="takeProfitTriggerType">Take profit trigger price type</param>
        /// <param name="stopLossTriggerType">Stop loss trigger price type</param>
        /// <param name="stopLossSize">Stop loss quantity</param>
        /// <param name="takeProfitSize">Take profit quantity</param>
        /// <param name="positionMode">Position mode</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetTradingStop(string symbol, decimal? takeProfitPrice = null,
            decimal? stopLossPrice = null, decimal? activePrice = null, decimal? trailingStop = null,
            TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null,
            decimal? stopLossSize = null, decimal? takeProfitSize = null, PositionMode? positionMode = null,
            long? receiveWindow = null, CancellationToken ct = default);
    }
}