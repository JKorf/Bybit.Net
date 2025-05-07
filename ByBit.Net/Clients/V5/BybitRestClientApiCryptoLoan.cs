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
    internal class BybitRestClientApiCryptoLoan : IBybitRestClientApiCryptoLoan
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();

        private BybitRestClientApi _baseClient;

        internal BybitRestClientApiCryptoLoan(BybitRestClientApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Get Collateral Assets

        /// <inheritdoc />
        public async Task<WebCallResult<BybitCollateralAsset[]>> GetCollateralAssetsAsync(
            AccountLevel? level = null,
            string? asset = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("currency", asset);
            parameters.AddOptional("vipLevel", level == AccountLevel.Default ? "VIP0" : level == AccountLevel.VipSupreme ? "VIP99": level?.ToString());

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/crypto-loan/collateral-data", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitCollateralAssets>(request, parameters, ct).ConfigureAwait(false);
            return result.As<BybitCollateralAsset[]>(result.Data?.Assets);
        }

        #endregion

        #region Get Borrowable Assets

        /// <inheritdoc />
        public async Task<WebCallResult<BybitBorrowAsset[]>> GetBorrowableAssetsAsync(AccountLevel? level = null, string? asset = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("currency", asset);
            parameters.AddOptional("vipLevel", level == AccountLevel.Default ? "VIP0" : level == AccountLevel.VipSupreme ? "VIP99" : level?.ToString());

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v5/crypto-loan/loanable-data", BybitExchange.RateLimiter.BybitRest, 1, false);
            var result = await _baseClient.SendAsync<BybitBorrowAssetWrapper>(request, parameters, ct).ConfigureAwait(false);
            return result.As<BybitBorrowAsset[]>(result.Data?.VipAssetList);
        }

        #endregion

        #region Get Limits

        /// <inheritdoc />
        public async Task<WebCallResult<BybitBorrowLimits>> GetLimitsAsync(string loanAsset, string collateralAsset, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("loanCurrency", loanAsset);
            parameters.Add("collateralCurrency", collateralAsset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v5/crypto-loan/borrowable-collateralisable-number", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitBorrowLimits>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Borrow

        /// <inheritdoc />
        public async Task<WebCallResult<BybitOrderId>> BorrowAsync(string loanAsset, string collateralAsset, decimal? loanQuantity = null, decimal? collateralQuantity = null, LoanTerm? loanTerm = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("loanCurrency", loanAsset);
            parameters.Add("collateralCurrency", collateralAsset);
            parameters.AddOptionalString("loanAmount", loanQuantity);
            parameters.AddOptionalString("collateralAmount", collateralQuantity);
            parameters.AddOptionalEnum("loanTerm", loanTerm);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/v5/crypto-loan/borrow", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitOrderId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Repay

        /// <inheritdoc />
        public async Task<WebCallResult<BybitRepayId>> RepayAsync(string orderId, decimal quantity, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("orderId", orderId);
            parameters.AddString("amount", quantity);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/v5/crypto-loan/repay", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitRepayId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Open Loans

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitLoan>>> GetOpenLoansAsync(string? orderId = null, string? loanAsset = null, string? collateralAsset = null, LoanType? loanType = null, LoanTerm? loanTerm = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("loanCurrency", loanAsset);
            parameters.AddOptional("collateralCurrency", collateralAsset);
            parameters.AddOptionalEnum("loanTermType", loanType);
            parameters.AddOptionalEnum("loanTerm", loanTerm);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v5/crypto-loan/ongoing-orders", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitResponse<BybitLoan>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Repay History

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitRepayment>>> GetRepayHistoryAsync(string? orderId = null, string? repayId = null, string? loanAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("repayId", repayId);
            parameters.AddOptional("loanCurrency", loanAsset);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v5/crypto-loan/repayment-history", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitResponse<BybitRepayment>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Completed Loan Orders

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitLoanOrder>>> GetCompletedLoanOrdersAsync(string? orderId = null, string? loanAsset = null, string? collateralAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("loanCurrency", loanAsset);
            parameters.AddOptional("collateralCurrency", collateralAsset);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v5/crypto-loan/borrow-history", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitResponse<BybitLoanOrder>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Max Collateral

        /// <inheritdoc />
        public async Task<WebCallResult<BybitMaxCollateral>> GetMaxCollateralAsync(string orderId, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("orderId", orderId);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v5/crypto-loan/max-collateral-amount", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitMaxCollateral>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Adjust Collateral

        /// <inheritdoc />
        public async Task<WebCallResult<BybitAdjustId>> AdjustCollateralAsync(string orderId, decimal quantity, AdjustDirection direction, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("orderID", orderId);
            parameters.AddString("amount", quantity);
            parameters.AddEnum("direction", direction);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/v5/crypto-loan/adjust-ltv", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitAdjustId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Collateral Adjust History

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitAdjustHistory>>> GetCollateralAdjustHistoryAsync(string? orderId = null, string? adjustId = null, string? collateralAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("adjustId", adjustId);
            parameters.AddOptional("collateralCurrency", collateralAsset);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v5/crypto-loan/adjustment-history", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitResponse<BybitAdjustHistory>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

    }
}
