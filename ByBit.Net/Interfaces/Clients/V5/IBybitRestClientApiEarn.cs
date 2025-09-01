using Bybit.Net.Enums;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
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
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/earn/product-info" /></para>
        /// </summary>
        /// <param name="category">Earn category</param>
        /// <param name="asset">The asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitResponse<BybitEarnProduct>>> GetProductInfoAsync(EarnCategory category, string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Place a new Stake or Redeem order
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/earn/create-order" /></para>
        /// </summary>
        /// <param name="category">Earn category</param>
        /// <param name="productId">Product id</param>
        /// <param name="accountType">Account type, either Fund or Unified</param>
        /// <param name="asset">The asset, for example `ETH`</param>
        /// <param name="orderType">Stake or Redeem</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="toAccountType">Target account type</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitOrderId>> PlaceOrderAsync(EarnCategory category, string productId, AccountType accountType, string asset, EarnOrderType orderType, decimal quantity, string? clientOrderId = null, AccountType? toAccountType = null, CancellationToken ct = default);

        /// <summary>
        /// Get order history
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/earn/order-history" /></para>
        /// </summary>
        /// <param name="category">Earn category</param>
        /// <param name="orderId">Order id</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitResponse<BybitEarnOrder>>> GetOrderHistoryAsync(EarnCategory category, string? orderId = null, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Get staked positions
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/earn/position" /></para>
        /// </summary>
        /// <param name="category">Earn category</param>
        /// <param name="productId">Filter by product id</param>
        /// <param name="asset">Filter by asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitResponse<BybitEarnStakedPosition>>> GetStakedPositionsAsync(EarnCategory category, string? productId = null, string? asset = null, CancellationToken ct = default);

    }
}