using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using CryptoExchange.Net.Objects;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net;
using Bybit.Net.Enums;
using System.Globalization;
using Bybit.Net.Interfaces.Clients.V5;
using Bybit.Net.Objects.Internal;
using System.Linq;
using CryptoExchange.Net.RateLimiting.Guards;
using System.Reflection.Emit;

namespace Bybit.Net.Clients.V5
{
    /// <inheritdoc />
    internal class BybitRestClientApiEarn : IBybitRestClientApiEarn
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();

        private BybitRestClientApi _baseClient;

        internal BybitRestClientApiEarn(BybitRestClientApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Get Product Info

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitEarnProduct>>> GetProductInfoAsync(EarnCategory category, string? asset = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.AddOptional("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v5/earn/product", BybitExchange.RateLimiter.BybitRest, 1, false);
            var result = await _baseClient.SendAsync<BybitResponse<BybitEarnProduct>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Place Order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitOrderId>> PlaceOrderAsync(EarnCategory category, string productId, AccountType accountType, string asset, EarnOrderType orderType, decimal quantity, string? clientOrderId = null, AccountType? toAccountType = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.Add("productId", productId);
            parameters.AddEnum("accountType", accountType);
            parameters.Add("coin", asset);
            parameters.AddEnum("orderType", orderType);
            parameters.AddString("amount", quantity);
            parameters.Add("orderLinkId", clientOrderId ?? Guid.NewGuid().ToString());
            parameters.AddOptionalEnum("toAccountType", toAccountType);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/v5/earn/place-order", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitOrderId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Order History

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitEarnOrder>>> GetOrderHistoryAsync(EarnCategory category, string? orderId = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            if (string.IsNullOrEmpty(orderId) && string.IsNullOrEmpty(clientOrderId))
                throw new ArgumentException("orderId or clientOrderId is required");

            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("orderLinkId", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v5/earn/order", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitResponse<BybitEarnOrder>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Staked Positions

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitEarnStakedPosition>>> GetStakedPositionsAsync(EarnCategory category, string? productId = null, string? asset = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.AddOptional("productId", productId);
            parameters.AddOptional("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v5/earn/position", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitResponse<BybitEarnStakedPosition>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

    }
}
