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
        public async Task<HttpResult<BybitCollateralAsset[]>> GetCollateralAssetsAsync(
            AccountLevel? level = null,
            string? asset = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("currency", asset);
            parameters.Add("vipLevel", level == AccountLevel.Default ? "VIP0" : level == AccountLevel.VipSupreme ? "VIP99": level?.ToString());

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/crypto-loan/collateral-data", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitCollateralAssets>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BybitCollateralAsset[]>(result);
            return HttpResult.Ok(result, result.Data.Assets);
        }

        #endregion

        #region Get Borrowable Assets

        /// <inheritdoc />
        public async Task<HttpResult<BybitBorrowAsset[]>> GetBorrowableAssetsAsync(AccountLevel? level = null, string? asset = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("currency", asset);
            parameters.Add("vipLevel", level == AccountLevel.Default ? "VIP0" : level == AccountLevel.VipSupreme ? "VIP99" : level?.ToString());

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/crypto-loan/loanable-data", BybitExchange.RateLimiter.BybitRest, 1, false);
            var result = await _baseClient.SendAsync<BybitBorrowAssetWrapper>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BybitBorrowAsset[]>(result);
            return HttpResult.Ok(result, result.Data.VipAssetList);
        }

        #endregion

        #region Get Limits

        /// <inheritdoc />
        public async Task<HttpResult<BybitBorrowLimits>> GetLimitsAsync(string loanAsset, string collateralAsset, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("loanCurrency", loanAsset);
            parameters.Add("collateralCurrency", collateralAsset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/crypto-loan/borrowable-collateralisable-number", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitBorrowLimits>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Borrow

        /// <inheritdoc />
        public async Task<HttpResult<BybitOrderId>> BorrowAsync(string loanAsset, string collateralAsset, decimal? loanQuantity = null, decimal? collateralQuantity = null, LoanTerm? loanTerm = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("loanCurrency", loanAsset);
            parameters.Add("collateralCurrency", collateralAsset);
            parameters.Add("loanAmount", loanQuantity);
            parameters.Add("collateralAmount", collateralQuantity);
            parameters.Add("loanTerm", loanTerm);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/v5/crypto-loan/borrow", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitOrderId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Repay

        /// <inheritdoc />
        public async Task<HttpResult<BybitRepayId>> RepayAsync(string orderId, decimal quantity, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("orderId", orderId);
            parameters.Add("amount", quantity);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/v5/crypto-loan/repay", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitRepayId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Open Loans

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitLoan>>> GetOpenLoansAsync(string? orderId = null, string? loanAsset = null, string? collateralAsset = null, LoanType? loanType = null, LoanTerm? loanTerm = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("orderId", orderId);
            parameters.Add("loanCurrency", loanAsset);
            parameters.Add("collateralCurrency", collateralAsset);
            parameters.Add("loanTermType", loanType);
            parameters.Add("loanTerm", loanTerm);
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/crypto-loan/ongoing-orders", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitResponse<BybitLoan>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Repay History

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitRepayment>>> GetRepayHistoryAsync(string? orderId = null, string? repayId = null, string? loanAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("orderId", orderId);
            parameters.Add("repayId", repayId);
            parameters.Add("loanCurrency", loanAsset);
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/crypto-loan/repayment-history", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitResponse<BybitRepayment>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Completed Loan Orders

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitLoanOrder>>> GetCompletedLoanOrdersAsync(string? orderId = null, string? loanAsset = null, string? collateralAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("orderId", orderId);
            parameters.Add("loanCurrency", loanAsset);
            parameters.Add("collateralCurrency", collateralAsset);
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/crypto-loan/borrow-history", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitResponse<BybitLoanOrder>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Max Collateral

        /// <inheritdoc />
        public async Task<HttpResult<BybitMaxCollateral>> GetMaxCollateralAsync(string orderId, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("orderId", orderId);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/crypto-loan/max-collateral-amount", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitMaxCollateral>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Adjust Collateral

        /// <inheritdoc />
        public async Task<HttpResult<BybitAdjustId>> AdjustCollateralAsync(string orderId, decimal quantity, AdjustDirection direction, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("orderID", orderId);
            parameters.Add("amount", quantity);
            parameters.Add("direction", direction);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/v5/crypto-loan/adjust-ltv", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitAdjustId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Collateral Adjust History

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitAdjustHistory>>> GetCollateralAdjustHistoryAsync(string? orderId = null, string? adjustId = null, string? collateralAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("orderId", orderId);
            parameters.Add("adjustId", adjustId);
            parameters.Add("collateralCurrency", collateralAsset);
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/crypto-loan/adjustment-history", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitResponse<BybitAdjustHistory>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

    }
}
