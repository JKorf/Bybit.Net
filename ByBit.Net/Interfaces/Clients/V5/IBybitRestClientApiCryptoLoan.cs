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
    /// Bybit crypto loan endpoints
    /// </summary>
    public interface IBybitRestClientApiCryptoLoan
    {
        /// <summary>
        /// Get collateral assets
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/crypto-loan/collateral-coin" /></para>
        /// </summary>
        /// <param name="level">Account level</param>
        /// <param name="asset">Filter by asset</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitCollateralAsset[]>> GetCollateralAssetsAsync(
            AccountLevel? level = null,
            string? asset = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get borrowable asssets
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/crypto-loan/loan-coin" /></para>
        /// </summary>
        /// <param name="accountLevel">Filter by account level</param>
        /// <param name="asset">Filter by asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitBorrowAsset[]>> GetBorrowableAssetsAsync(AccountLevel? accountLevel = null, string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Get borrow/collateral limits
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/crypto-loan/acct-borrow-collateral" /></para>
        /// </summary>
        /// <param name="loanAsset">The loan asset, for example `ETH`</param>
        /// <param name="collateralAsset">The collateral asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitBorrowLimits>> GetLimitsAsync(string loanAsset, string collateralAsset, CancellationToken ct = default);

        /// <summary>
        /// Borrow an asset
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/crypto-loan/borrow" /></para>
        /// </summary>
        /// <param name="loanAsset">The loan asset, for example `ETH`</param>
        /// <param name="collateralAsset">The collateral asset, for example `ETH`</param>
        /// <param name="loanQuantity">Quantity to borrow, either this or collateralQuantity should be provided</param>
        /// <param name="collateralQuantity">Quantity to use as collateral, either this or loanQuantity should be provided</param>
        /// <param name="loanTerm">The term for the loan, null for flexible term</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitOrderId>> BorrowAsync(string loanAsset, string collateralAsset, decimal? loanQuantity = null, decimal? collateralQuantity = null, LoanTerm? loanTerm = null, CancellationToken ct = default);

        /// <summary>
        /// Repay a loan
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/crypto-loan/repay" /></para>
        /// </summary>
        /// <param name="orderId">Loan order id</param>
        /// <param name="quantity">Quantity to repay</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitRepayId>> RepayAsync(string orderId, decimal quantity, CancellationToken ct = default);

        /// <summary>
        /// Get unpaid loans
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/crypto-loan/unpaid-loan-order" /></para>
        /// </summary>
        /// <param name="orderId">Filter by loan order id</param>
        /// <param name="loanAsset">Filter by loan asset</param>
        /// <param name="collateralAsset">Filter by collateral asset</param>
        /// <param name="loanType">Filter by loan type</param>
        /// <param name="loanTerm">Filter by loan term</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="cursor">Page cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitResponse<BybitLoan>>> GetOpenLoansAsync(string? orderId = null, string? loanAsset = null, string? collateralAsset = null, LoanType? loanType = null, LoanTerm? loanTerm = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get repayment history
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/crypto-loan/repay-transaction" /></para>
        /// </summary>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="repayId">Filter by repayment id</param>
        /// <param name="loanAsset">Filter by loan asset, for example `ETH`</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="cursor">Page cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitResponse<BybitRepayment>>> GetRepayHistoryAsync(string? orderId = null, string? repayId = null, string? loanAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get completed loan orders
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/crypto-loan/comleted-loan-order" /></para>
        /// </summary>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="loanAsset">Filter by loan asset</param>
        /// <param name="collateralAsset">Filter by collateral asset</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="cursor">Page cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitResponse<BybitLoanOrder>>> GetCompletedLoanOrdersAsync(string? orderId = null, string? loanAsset = null, string? collateralAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get max collateral for a loan
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/crypto-loan/reduce-max-collateral-amt" /></para>
        /// </summary>
        /// <param name="orderId">Order id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitMaxCollateral>> GetMaxCollateralAsync(string orderId, CancellationToken ct = default);

        /// <summary>
        /// Adjust collateral
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/crypto-loan/adjust-collateral" /></para>
        /// </summary>
        /// <param name="orderId">Order id</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="direction">Direction</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitAdjustId>> AdjustCollateralAsync(string orderId, decimal quantity, AdjustDirection direction, CancellationToken ct = default);

        /// <summary>
        /// Get collateral adjustment history
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/crypto-loan/ltv-adjust-history" /></para>
        /// </summary>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="adjustId">Filter by adjust id</param>
        /// <param name="collateralAsset">Filter by collateral asset, for example `ETH`</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="cursor">Page cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitResponse<BybitAdjustHistory>>> GetCollateralAdjustHistoryAsync(string? orderId = null, string? adjustId = null, string? collateralAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

    }
}
