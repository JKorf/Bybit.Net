using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net.Objects;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.V5
{
    /// <summary>
    /// Bybit Earn endpoints
    /// </summary>
    public interface IBybitRestClientApiEarn
    {
        /// <summary>
        /// Get Earn product info
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/earn/product-info" /><br />
        /// Endpoint:<br />
        /// GET /v5/earn/product
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Earn category</param>
        /// <param name="asset">["<c>coin</c>"] The asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitResponse<BybitEarnProduct>>> GetProductInfoAsync(EarnCategory category, string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Place a new Stake or Redeem order
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/earn/create-order" /><br />
        /// Endpoint:<br />
        /// POST /v5/earn/place-order
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Earn category</param>
        /// <param name="productId">["<c>productId</c>"] Product id</param>
        /// <param name="accountType">["<c>accountType</c>"] Account type, either Fund or Unified</param>
        /// <param name="asset">["<c>coin</c>"] The asset, for example `ETH`</param>
        /// <param name="orderType">["<c>orderType</c>"] Stake or Redeem</param>
        /// <param name="quantity">["<c>amount</c>"] Quantity</param>
        /// <param name="clientOrderId">["<c>orderLinkId</c>"] Client order id</param>
        /// <param name="toAccountType">["<c>toAccountType</c>"] Target account type</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitOrderId>> PlaceOrderAsync(EarnCategory category, string productId, AccountType accountType, string asset, EarnOrderType orderType, decimal quantity, string? clientOrderId = null, AccountType? toAccountType = null, CancellationToken ct = default);

        /// <summary>
        /// Get order history
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/earn/order-history" /><br />
        /// Endpoint:<br />
        /// GET /v5/earn/order
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Earn category</param>
        /// <param name="orderId">["<c>orderId</c>"] Order id</param>
        /// <param name="clientOrderId">["<c>orderLinkId</c>"] Client order id</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitResponse<BybitEarnOrder>>> GetOrderHistoryAsync(EarnCategory category, string? orderId = null, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Get staked positions
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/earn/position" /><br />
        /// Endpoint:<br />
        /// GET /v5/earn/position
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Earn category</param>
        /// <param name="productId">["<c>productId</c>"] Filter by product id</param>
        /// <param name="asset">["<c>coin</c>"] Filter by asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitResponse<BybitEarnStakedPosition>>> GetStakedPositionsAsync(EarnCategory category, string? productId = null, string? asset = null, CancellationToken ct = default);

    }
}