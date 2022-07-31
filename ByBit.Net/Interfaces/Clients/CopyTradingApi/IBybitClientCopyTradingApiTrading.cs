using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.CopyTrading;
using CryptoExchange.Net.Objects;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.CopyTradingApi
{
    /// <summary>
    /// Bybit trading endpoints, placing and managing positions.
    /// </summary>
    public interface IBybitClientCopyTradingApiTrading
    {
        /// <summary>
        /// Get your positions
        /// <para><a href="https://bybit-exchange.github.io/docs/copy_trading/#t-ct_wallet_transfer" /></para>
        /// </summary>
        /// <param name="symbol">Filter by symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitCopyTradingPosition>>> GetPositionsAsync(string? symbol = null, CancellationToken ct = default);

        /// <summary>
        /// Close a position
        /// <para><a href="https://bybit-exchange.github.io/docs/copy_trading/#t-ct_positon_close" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="positionMode">Position mode</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> ClosePositionAsync(string symbol, PositionMode positionMode, CancellationToken ct = default);

        /// <summary>
        /// Set leverage
        /// <para><a href="https://bybit-exchange.github.io/docs/copy_trading/#t-ct_set_leverage" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="buyLeverage">Buy leverage</param>
        /// <param name="sellLeverage">Sell leverage</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetLeverageAsync(string symbol, decimal buyLeverage, decimal sellLeverage, CancellationToken ct = default);

        /// <summary>
        /// Place an order
        /// <para><a href="https://bybit-exchange.github.io/docs/copy_trading/#t-ct_create_order" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="side">Order side</param>
        /// <param name="type">Order type</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="price">Price</param>
        /// <param name="clientOrderId">Optional user defined id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitCopyTradingId>> PlaceOrderAsync(string symbol, OrderSide side, OrderType type, decimal quantity, decimal price, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Get orders
        /// <para><a href="https://bybit-exchange.github.io/docs/copy_trading/#t-ct_order_list" /></para>
        /// </summary>
        /// <param name="symbol">Filter by symbol</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="copyTradeOrderType">Filter by copy order type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitCopyTradingOrder>>> GetOrdersAsync(string? symbol = null, string? orderId = null, string? clientOrderId = null, string? copyTradeOrderType = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel an active order
        /// <para><a href="https://bybit-exchange.github.io/docs/copy_trading/#t-ct_cancel_order" /></para>
        /// </summary>
        /// <param name="orderId">Cancel by order id</param>
        /// <param name="clientOrderId">Cancel by client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitCopyTradingId>> CancelOrderAsync(string? orderId = null, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Close an order
        /// <para><a href="https://bybit-exchange.github.io/docs/copy_trading/#t-ct_close_order" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="parentOrderId">Required if not passing parentClientOrderId</param>
        /// <param name="parentClientOrderId">Required if not passing parentOrderId</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitCopyTradingId>> CloseOrderAsync(string symbol, string? clientOrderId = null, string? parentOrderId = null, string? parentClientOrderId = null, CancellationToken ct = default);
    }
}
