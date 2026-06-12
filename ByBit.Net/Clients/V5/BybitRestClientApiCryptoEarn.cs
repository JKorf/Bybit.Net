using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using CryptoExchange.Net.Objects;
using Bybit.Net.Objects.Models.V5;
using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.V5;

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
        public async Task<HttpResult<BybitResponse<BybitEarnProduct>>> GetProductInfoAsync(EarnCategory category, string? asset = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("category", category);
            parameters.Add("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/earn/product", BybitExchange.RateLimiter.BybitRest, 1, false);
            var result = await _baseClient.SendAsync<BybitResponse<BybitEarnProduct>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Place Order

        /// <inheritdoc />
        public async Task<HttpResult<BybitOrderId>> PlaceOrderAsync(EarnCategory category, string productId, AccountType accountType, string asset, EarnOrderType orderType, decimal quantity, string? clientOrderId = null, AccountType? toAccountType = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("category", category);
            parameters.Add("productId", productId);
            parameters.Add("accountType", accountType);
            parameters.Add("coin", asset);
            parameters.Add("orderType", orderType);
            parameters.Add("amount", quantity);
            parameters.Add("orderLinkId", clientOrderId ?? Guid.NewGuid().ToString());
            parameters.Add("toAccountType", toAccountType);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/v5/earn/place-order", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitOrderId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Order History

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitEarnOrder>>> GetOrderHistoryAsync(EarnCategory category, string? orderId = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            if (string.IsNullOrEmpty(orderId) && string.IsNullOrEmpty(clientOrderId))
                throw new ArgumentException("orderId or clientOrderId is required");

            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("category", category);
            parameters.Add("orderId", orderId);
            parameters.Add("orderLinkId", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/earn/order", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitResponse<BybitEarnOrder>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Staked Positions

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitEarnStakedPosition>>> GetStakedPositionsAsync(EarnCategory category, string? productId = null, string? asset = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("category", category);
            parameters.Add("productId", productId);
            parameters.Add("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/earn/position", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitResponse<BybitEarnStakedPosition>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

    }
}
