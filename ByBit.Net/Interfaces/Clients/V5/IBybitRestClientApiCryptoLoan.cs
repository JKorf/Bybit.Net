using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net.Objects;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.V5
{
    /// <summary>
    /// Bybit crypto loan endpoints
    /// </summary>
    public interface IBybitRestClientApiCryptoLoan
    {
        /// <summary>
        /// Get collateral assets
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/crypto-loan/collateral-coin" /><br />
        /// Endpoint:<br />
        /// GET /v5/crypto-loan/collateral-data
        /// </para>
        /// </summary>
        /// <param name="level">["<c>vipLevel</c>"] Account level</param>
        /// <param name="asset">["<c>currency</c>"] Filter by asset</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitCollateralAsset[]>> GetCollateralAssetsAsync(
            AccountLevel? level = null,
            string? asset = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get borrowable asssets
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/crypto-loan/loan-coin" /><br />
        /// Endpoint:<br />
        /// GET /v5/crypto-loan/loanable-data
        /// </para>
        /// </summary>
        /// <param name="accountLevel">["<c>vipLevel</c>"] Filter by account level</param>
        /// <param name="asset">["<c>currency</c>"] Filter by asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitBorrowAsset[]>> GetBorrowableAssetsAsync(AccountLevel? accountLevel = null, string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Get borrow/collateral limits
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/crypto-loan/acct-borrow-collateral" /><br />
        /// Endpoint:<br />
        /// GET /v5/crypto-loan/borrowable-collateralisable-number
        /// </para>
        /// </summary>
        /// <param name="loanAsset">["<c>loanCurrency</c>"] The loan asset, for example `ETH`</param>
        /// <param name="collateralAsset">["<c>collateralCurrency</c>"] The collateral asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitBorrowLimits>> GetLimitsAsync(string loanAsset, string collateralAsset, CancellationToken ct = default);

        /// <summary>
        /// Borrow an asset
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/crypto-loan/borrow" /><br />
        /// Endpoint:<br />
        /// POST /v5/crypto-loan/borrow
        /// </para>
        /// </summary>
        /// <param name="loanAsset">["<c>loanCurrency</c>"] The loan asset, for example `ETH`</param>
        /// <param name="collateralAsset">["<c>collateralCurrency</c>"] The collateral asset, for example `ETH`</param>
        /// <param name="loanQuantity">["<c>loanAmount</c>"] Quantity to borrow, either this or collateralQuantity should be provided</param>
        /// <param name="collateralQuantity">["<c>collateralAmount</c>"] Quantity to use as collateral, either this or loanQuantity should be provided</param>
        /// <param name="loanTerm">["<c>loanTerm</c>"] The term for the loan, null for flexible term</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitOrderId>> BorrowAsync(string loanAsset, string collateralAsset, decimal? loanQuantity = null, decimal? collateralQuantity = null, LoanTerm? loanTerm = null, CancellationToken ct = default);

        /// <summary>
        /// Repay a loan
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/crypto-loan/repay" /><br />
        /// Endpoint:<br />
        /// POST /v5/crypto-loan/repay
        /// </para>
        /// </summary>
        /// <param name="orderId">["<c>orderId</c>"] Loan order id</param>
        /// <param name="quantity">["<c>amount</c>"] Quantity to repay</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitRepayId>> RepayAsync(string orderId, decimal quantity, CancellationToken ct = default);

        /// <summary>
        /// Get unpaid loans
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/crypto-loan/unpaid-loan-order" /><br />
        /// Endpoint:<br />
        /// GET /v5/crypto-loan/ongoing-orders
        /// </para>
        /// </summary>
        /// <param name="orderId">["<c>orderId</c>"] Filter by loan order id</param>
        /// <param name="loanAsset">["<c>loanCurrency</c>"] Filter by loan asset</param>
        /// <param name="collateralAsset">["<c>collateralCurrency</c>"] Filter by collateral asset</param>
        /// <param name="loanType">["<c>loanTermType</c>"] Filter by loan type</param>
        /// <param name="loanTerm">["<c>loanTerm</c>"] Filter by loan term</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results</param>
        /// <param name="cursor">["<c>cursor</c>"] Page cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitResponse<BybitLoan>>> GetOpenLoansAsync(string? orderId = null, string? loanAsset = null, string? collateralAsset = null, LoanType? loanType = null, LoanTerm? loanTerm = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get repayment history
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/crypto-loan/repay-transaction" /><br />
        /// Endpoint:<br />
        /// GET /v5/crypto-loan/repayment-history
        /// </para>
        /// </summary>
        /// <param name="orderId">["<c>orderId</c>"] Filter by order id</param>
        /// <param name="repayId">["<c>repayId</c>"] Filter by repayment id</param>
        /// <param name="loanAsset">["<c>loanCurrency</c>"] Filter by loan asset, for example `ETH`</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results</param>
        /// <param name="cursor">["<c>cursor</c>"] Page cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitResponse<BybitRepayment>>> GetRepayHistoryAsync(string? orderId = null, string? repayId = null, string? loanAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get completed loan orders
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/crypto-loan/comleted-loan-order" /><br />
        /// Endpoint:<br />
        /// GET /v5/crypto-loan/borrow-history
        /// </para>
        /// </summary>
        /// <param name="orderId">["<c>orderId</c>"] Filter by order id</param>
        /// <param name="loanAsset">["<c>loanCurrency</c>"] Filter by loan asset</param>
        /// <param name="collateralAsset">["<c>collateralCurrency</c>"] Filter by collateral asset</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results</param>
        /// <param name="cursor">["<c>cursor</c>"] Page cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitResponse<BybitLoanOrder>>> GetCompletedLoanOrdersAsync(string? orderId = null, string? loanAsset = null, string? collateralAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get max collateral for a loan
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/crypto-loan/reduce-max-collateral-amt" /><br />
        /// Endpoint:<br />
        /// GET /v5/crypto-loan/max-collateral-amount
        /// </para>
        /// </summary>
        /// <param name="orderId">["<c>orderId</c>"] Order id</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitMaxCollateral>> GetMaxCollateralAsync(string orderId, CancellationToken ct = default);

        /// <summary>
        /// Adjust collateral
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/crypto-loan/adjust-collateral" /><br />
        /// Endpoint:<br />
        /// POST /v5/crypto-loan/adjust-ltv
        /// </para>
        /// </summary>
        /// <param name="orderId">["<c>orderID</c>"] Order id</param>
        /// <param name="quantity">["<c>amount</c>"] Quantity</param>
        /// <param name="direction">["<c>direction</c>"] Direction</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitAdjustId>> AdjustCollateralAsync(string orderId, decimal quantity, AdjustDirection direction, CancellationToken ct = default);

        /// <summary>
        /// Get collateral adjustment history
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/crypto-loan/ltv-adjust-history" /><br />
        /// Endpoint:<br />
        /// GET /v5/crypto-loan/adjustment-history
        /// </para>
        /// </summary>
        /// <param name="orderId">["<c>orderId</c>"] Filter by order id</param>
        /// <param name="adjustId">["<c>adjustId</c>"] Filter by adjust id</param>
        /// <param name="collateralAsset">["<c>collateralCurrency</c>"] Filter by collateral asset, for example `ETH`</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results</param>
        /// <param name="cursor">["<c>cursor</c>"] Page cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitResponse<BybitAdjustHistory>>> GetCollateralAdjustHistoryAsync(string? orderId = null, string? adjustId = null, string? collateralAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

    }
}
