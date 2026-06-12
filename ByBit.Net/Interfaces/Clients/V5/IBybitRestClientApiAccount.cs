using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.V5
{
    /// <summary>
    /// Bybit account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and changing account settings
    /// </summary>
    public interface IBybitRestClientApiAccount
    {
        /// <summary>
        /// Cancel a withdrawal
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/cancel-withdraw" /><br />
        /// Endpoint:<br />
        /// POST /v5/asset/withdraw/cancel
        /// </para>
        /// </summary>
        /// <param name="id">["<c>id</c>"] The id of the withdrawal to cancel</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitOperationResult>> CancelWithdrawalAsync(string id, CancellationToken ct = default);

        /// <summary>
        /// Create an internal transfer between different account types
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/create-inter-transfer" /><br />
        /// Endpoint:<br />
        /// POST /v5/asset/transfer/inter-transfer
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] Asset, for example `ETH`</param>
        /// <param name="quantity">["<c>amount</c>"] Quantity</param>
        /// <param name="fromAccountType">["<c>fromAccountType</c>"] From account type</param>
        /// <param name="toAccountType">["<c>toAccountType</c>"] To account type</param>
        /// <param name="transferId">["<c>transferId</c>"] Client id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitTransferId>> CreateInternalTransferAsync(string asset, decimal quantity, AccountType fromAccountType, AccountType toAccountType, string? transferId = null, CancellationToken ct = default);

        /// <summary>
        /// Transfer between main/sub accounts
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/unitransfer" /><br />
        /// Endpoint:<br />
        /// POST /v5/asset/transfer/universal-transfer
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] The asset, for example `ETH`</param>
        /// <param name="quantity">["<c>amount</c>"] Quantity</param>
        /// <param name="fromMemberId">["<c>fromMemberId</c>"] From member id</param>
        /// <param name="toMemberId">["<c>toMemberId</c>"] To member id</param>
        /// <param name="fromAccountType">["<c>fromAccountType</c>"] From account type</param>
        /// <param name="toAccountType">["<c>toAccountType</c>"] To account type</param>
        /// <param name="transferId">["<c>transferId</c>"] Client id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitTransferId>> CreateUniversalTransferAsync(string asset, decimal quantity, string fromMemberId, string toMemberId, AccountType fromAccountType, AccountType toAccountType, string? transferId = null, CancellationToken ct = default);

        /// <summary>
        /// Get margin configuration info
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/account/account-info" /><br />
        /// Endpoint:<br />
        /// GET /v5/account/info
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitAccountInfo>> GetMarginAccountInfoAsync(CancellationToken ct = default);

        /// <summary>
        /// Get all balances
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/all-balance" /><br />
        /// Endpoint:<br />
        /// GET /v5/asset/transfer/query-account-coins-balance
        /// </para>
        /// </summary>
        /// <param name="accountType">["<c>accountType</c>"] Account type</param>
        /// <param name="memberId">["<c>memberId</c>"] Member id</param>
        /// <param name="asset">["<c>coin</c>"] Asset, for example `ETH`. Can be specify multiple comma separated assets. Required for Unified account.</param>
        /// <param name="withBonus">["<c>withBonus</c>"] Include bonus</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitAllAssetBalances>> GetAllAssetBalancesAsync(AccountType accountType, string? memberId = null, string? asset = null, bool? withBonus = null, CancellationToken ct = default);

        /// <summary>
        /// Get allowed deposit asset info
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/deposit-coin-spec" /><br />
        /// Endpoint:<br />
        /// GET /v5/asset/deposit/query-allowed-list
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] Filter on asset, for example `ETH`</param>
        /// <param name="network">["<c>chain</c>"] Filter on network</param>
        /// <param name="limit">["<c>limit</c>"] Number of results per page</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitAllowedDepositInfoResponse>> GetAllowedDepositAssetInfoAsync(string? asset = null, string? network = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get api key info for the current api key
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/user/apikey-info" /><br />
        /// Endpoint:<br />
        /// GET /v5/user/query-api
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitApiKeyInfo>> GetApiKeyInfoAsync(CancellationToken ct = default);

        /// <summary>
        /// Edit master API key settings
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/user/modify-master-apikey" /><br />
        /// Endpoint:<br />
        /// POST /v5/user/update-api
        /// </para>
        /// </summary>
        /// <param name="readOnly">["<c>readOnly</c>"] Readonly</param>
        /// <param name="permissionContractTradeOrder">Has contract order permission</param>
        /// <param name="permissionContractTradePosition">Has contract position permission</param>
        /// <param name="permissionSpotTrade">Has spot trade permission</param>
        /// <param name="permissionWalletTransfer">Has wallet transfer permission</param>
        /// <param name="permissionWalletSubAccountTransfer">Has permission wallet subaccount transfer permission</param>
        /// <param name="permissionOptionsTrade">Has option trade permission</param>
        /// <param name="permissionExchangeHistory">Has exchange history permission</param>
        /// <param name="permissionCopyTrading">Has copy trade permission</param>
        /// <param name="permissionBlockTrading">Has block trade permission</param>
        /// <param name="permissionNftProductList">Has NFT product list permission</param>
        /// <param name="permissionAffiliate">Has affiliate permission</param>
        /// <param name="ct">Cancelation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitApiKeyInfo>> EditApiKeyAsync(
            bool? readOnly = null,
            bool? permissionContractTradeOrder = null,
            bool? permissionContractTradePosition = null,
            bool? permissionSpotTrade = null,
            bool? permissionWalletTransfer = null,
            bool? permissionWalletSubAccountTransfer = null,
            bool? permissionOptionsTrade = null,
            bool? permissionCopyTrading = null,
            bool? permissionBlockTrading = null,
            bool? permissionExchangeHistory = null,
            bool? permissionNftProductList = null,
            bool? permissionAffiliate = null,
            CancellationToken ct = default);

        /// <summary>
        /// Delete the current API Key
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/user/rm-master-apikey" /><br />
        /// Endpoint:<br />
        /// POST /v5/user/delete-api
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult> DeleteApiKeyAsync(CancellationToken ct = default);

        /// <summary>
        /// Get account types
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/user/wallet-type" /><br />
        /// Endpoint:<br />
        /// GET /v5/user/get-member-type
        /// </para>
        /// </summary>
        /// <param name="subAccountIds">["<c>memberIds</c>"] Master id can request subaccount info</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitAccountTypeInfo[]>> GetAccountTypesAsync(IEnumerable<string>? subAccountIds = null, CancellationToken ct = default);

        /// <summary>
        /// Get asset balance
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/account-coin-balance" /><br />
        /// Endpoint:<br />
        /// GET /v5/asset/transfer/query-account-coin-balance
        /// </para>
        /// </summary>
        /// <param name="accountType">["<c>accountType</c>"] Account type</param>
        /// <param name="asset">["<c>coin</c>"] The asset, for example `ETH`</param>
        /// <param name="memberId">["<c>memberId</c>"] Member id</param>
        /// <param name="withBonus">["<c>withBonus</c>"] Include bonus</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitSingleAssetBalance>> GetAssetBalanceAsync(AccountType accountType, string asset, string? memberId = null, bool? withBonus = null, CancellationToken ct = default);

        /// <summary>
        /// Get current account greek info
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/account/coin-greeks" /><br />
        /// Endpoint:<br />
        /// GET /v5/asset/coin-greeks
        /// </para>
        /// </summary>
        /// <param name="baseAsset">["<c>baseCoin</c>"] Base asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitGreeks>>> GetAssetGreeksAsync(string? baseAsset = null, CancellationToken ct = default);

        /// <summary>
        /// Get coin info including chain info and withdrawal and deposit status
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/coin-info" /><br />
        /// Endpoint:<br />
        /// GET /v5/asset/coin/query-info
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] Filter by asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitUserAssetInfos>> GetAssetInfoAsync(string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Get asset information
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/asset-info" /><br />
        /// Endpoint:<br />
        /// GET /v5/asset/transfer/query-asset-info
        /// </para>
        /// </summary>
        /// <param name="accountType">["<c>accountType</c>"] Account type (spot only atm)</param>
        /// <param name="asset">["<c>coin</c>"] Filter asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitAccountAssetInfo>> GetAssetInfoAsync(AccountType accountType, string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Get wallet balance and account info
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/account/wallet-balance" /><br />
        /// Endpoint:<br />
        /// GET /v5/account/wallet-balance
        /// </para>
        /// </summary>
        /// <param name="accountType">["<c>accountType</c>"] Account info</param>
        /// <param name="asset">["<c>coin</c>"] Filter by asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitBalance>>> GetBalancesAsync(AccountType accountType, string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Get borrow history
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/account/borrow-history" /><br />
        /// Endpoint:<br />
        /// GET /v5/account/borrow-history
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>currency</c>"] Filter by asset, for example `ETH`</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Number of results per page</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitBorrowHistory>>> GetBorrowHistoryAsync(string? asset = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get the collateral information of the current unified margin account, including loan interest rate, loanable amount, collateral conversion rate, whether it can be mortgaged as margin, etc.
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/account/collateral-info" /><br />
        /// Endpoint:<br />
        /// GET /v5/account/collateral-info
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>currency</c>"] Filter by asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitCollateralInfo>>> GetCollateralInfoAsync(string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Get delayed withdrawal amount
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/delay-amount" /><br />
        /// Endpoint:<br />
        /// GET /v5/asset/withdraw/withdrawable-amount
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] The asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitDelayedWithdrawal>> GetDelayedWithdrawQuantityAsync(string asset, CancellationToken ct = default);

        /// <summary>
        /// Get the master deposit address for an asset
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/deposit/master-deposit-addr" /><br />
        /// Endpoint:<br />
        /// GET /v5/asset/deposit/query-address
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] Asset, for example `ETH`</param>
        /// <param name="networkType">["<c>chainType</c>"] Network type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitDepositAddress>> GetDepositAddressAsync(string asset, string? networkType = null, CancellationToken ct = default);

        /// <summary>
        /// Get list of deposits
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/deposit/deposit-record" /><br />
        /// Endpoint:<br />
        /// GET /v5/asset/deposit/query-record
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] Filter by asset, for example `ETH`</param>
        /// <param name="id">["<c>id</c>"] Filter by id</param>
        /// <param name="transactionId">["<c>txID</c>"] Filter by transaction id</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Number of results per page</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitDeposits>> GetDepositsAsync(string? asset = null, string? id = null, string? transactionId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get a list of internal deposits
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/deposit/internal-deposit-record" /><br />
        /// Endpoint:<br />
        /// GET /v5/asset/deposit/query-internal-record
        /// </para>
        /// </summary>
        /// <param name="transactionId">["<c>txID</c>"] Filter by transaction id</param>
        /// <param name="asset">["<c>coin</c>"] Filter by asset, for example `ETH`</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Max results</param>
        /// <param name="cursor">["<c>cursor</c>"] Next page cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitInternalDeposit>>> GetInternalDepositsAsync(
            string? transactionId = null,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get fee rates
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/account/fee-rate" /><br />
        /// Endpoint:<br />
        /// GET /v5/account/fee-rate
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="baseAsset">["<c>baseCoin</c>"] Filter by base asset</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitFeeRate>>> GetFeeRateAsync(Category category, string? symbol = null, string? baseAsset = null, CancellationToken ct = default);

        /// <summary>
        /// Get internal transfer history
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/inter-transfer-list" /><br />
        /// Endpoint:<br />
        /// GET /v5/asset/transfer/query-inter-transfer-list
        /// </para>
        /// </summary>
        /// <param name="transferId">["<c>transferId</c>"] Filter by tansfer id</param>
        /// <param name="asset">["<c>coin</c>"] Filter by asset, for example `ETH`</param>
        /// <param name="transferStatus">["<c>status</c>"] Filter by status</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Number of results per page</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitTransfer>>> GetInternalTransfersAsync(string? transferId = null, string? asset = null, TransferStatus? transferStatus = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get transaction logs in Unified account.
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/account/transaction-log" /><br />
        /// Endpoint:<br />
        /// GET /v5/account/transaction-log
        /// </para>
        /// </summary>
        /// <param name="accountType">["<c>accountType</c>"] Filter by account type</param>
        /// <param name="category">["<c>category</c>"] Filter by category</param>
        /// <param name="asset">["<c>currency</c>"] Filter by asset, for example `ETH`</param>
        /// <param name="baseAsset">["<c>baseCoin</c>"] Filter by base asset</param>
        /// <param name="type">["<c>type</c>"] Filter by type</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Number of results per page</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitTransactionLog>>> GetTransactionHistoryAsync(AccountType? accountType = null, Category? category = null, string? asset = null, string? baseAsset = null, TransactionLogType? type = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get classic account, contract transaction logs
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/account/contract-transaction-log" /><br />
        /// Endpoint:<br />
        /// GET /v5/account/contract-transaction-log
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>currency</c>"] Filter by asset, for example `ETH`</param>
        /// <param name="baseAsset">["<c>baseCoin</c>"] Filter by base asset</param>
        /// <param name="type">["<c>type</c>"] Filter by type</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Number of results per page</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitTransactionLog>>> GetClassicContractTransactionHistoryAsync(
            string? asset = null,
            string? baseAsset = null,
            TransactionLogType? type = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get a list of transferable assets between accounts
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/transferable-coin" /><br />
        /// Endpoint:<br />
        /// GET /v5/asset/transfer/query-transfer-coin-list
        /// </para>
        /// </summary>
        /// <param name="fromAccountType">["<c>fromAccountType</c>"] From account type</param>
        /// <param name="toAccountType">["<c>toAccountType</c>"] To account type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<string>>> GetTransferableAssetsAsync(AccountType fromAccountType, AccountType toAccountType, CancellationToken ct = default);

        /// <summary>
        /// Get universal transfer history
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/unitransfer-list" /><br />
        /// Endpoint:<br />
        /// GET /v5/asset/transfer/query-universal-transfer-list
        /// </para>
        /// </summary>
        /// <param name="transferId">["<c>transferId</c>"] Filter by tansfer id</param>
        /// <param name="asset">["<c>coin</c>"] Filter by asset, for example `ETH`</param>
        /// <param name="transferStatus">["<c>status</c>"] Filter by status</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Number of results per page</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitTransfer>>> GetUniversalTransfersAsync(string? transferId = null, string? asset = null, TransferStatus? transferStatus = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get withdrawal history
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/withdraw/withdraw-record" /><br />
        /// Endpoint:<br />
        /// GET /v5/asset/withdraw/query-record
        /// </para>
        /// </summary>
        /// <param name="withdrawId">["<c>withdrawID</c>"] Filter by withdrawal id</param>
        /// <param name="asset">["<c>coin</c>"] Filter by asset, for example `ETH`</param>
        /// <param name="type">["<c>withdrawType</c>"] Filter by type</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Number of results per page</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="transactionId">["<c>txID</c>"] Transaction hash ID</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitResponse<BybitWithdrawal>>> GetWithdrawalsAsync(string? withdrawId = null, string? asset = null, WithdrawalType? type = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, string? transactionId = null, CancellationToken ct = default);

        /// <summary>
        /// Set auto add margin
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/position/add-margin" /><br />
        /// Endpoint:<br />
        /// POST /v5/position/set-auto-add-margin
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="autoAddMargin">["<c>autoAddMargin</c>"] Auto add margin or not</param>
        /// <param name="positionIdx">["<c>positionIdx</c>"] Position idx</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult> SetAutoAddMarginAsync(Category category, string symbol, bool autoAddMargin, PositionIdx? positionIdx = null, CancellationToken ct = default);

        /// <summary>
        /// Set the account deposits are credited to
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/set-deposit-acct" /><br />
        /// Endpoint:<br />
        /// POST /v5/asset/deposit/deposit-to-account
        /// </para>
        /// </summary>
        /// <param name="accountType">["<c>accountType</c>"] The account</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitOperationResult>> SetDepositAccountAsync(AccountType accountType, CancellationToken ct = default);

        /// <summary>
        /// Set leverage
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/position/leverage" /><br />
        /// Endpoint:<br />
        /// POST /v5/position/set-leverage
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="buyLeverage">["<c>buyLeverage</c>"] Buy leverage. Must be the same as sellLeverage under one-way mode</param>
        /// <param name="sellLeverage">["<c>sellLeverage</c>"] Sell leverage. Must be the same as sellLeverage under one-way mode</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult> SetLeverageAsync(Category category, string symbol, decimal buyLeverage, decimal sellLeverage, CancellationToken ct = default);

        /// <summary>
        /// Set whether an asset should be used for collateral
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/account/set-collateral" /><br />
        /// Endpoint:<br />
        /// POST /v5/account/set-collateral-switch
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] The asset. USDT and USDC can't be switched off</param>
        /// <param name="useForCollateral">["<c>collateralSwitch</c>"] Use the asset for collateral</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult> SetCollateralAssetAsync(
            string asset,
            bool useForCollateral,
            CancellationToken ct = default);

        /// <summary>
        /// Set whether assets should be used for collateral
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/account/batch-set-collateral" /><br />
        /// Endpoint:<br />
        /// POST /v5/account/set-collateral-switch-batch
        /// </para>
        /// </summary>
        /// <param name="assets">["<c>request</c>"] The assets configuration</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult> SetMultipleCollateralAssetsAsync(
            IEnumerable<BybitSetCollateralAssetRequest> assets,
            CancellationToken ct = default);

        /// <summary>
        /// Set the margin mode
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/account/set-margin-mode" /><br />
        /// Endpoint:<br />
        /// POST /v5/account/set-margin-mode
        /// </para>
        /// </summary>
        /// <param name="marginMode">["<c>setMarginMode</c>"] Margin mode</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitSetMarginModeResult>> SetMarginModeAsync(MarginMode marginMode, CancellationToken ct = default);

        /// <summary>
        /// DEPRECATED, SEE https://announcements.bybit.com/en/article/risk-limit-update-transitioning-from-manual-to-auto-adjustment-bltf0fa535064561d9d/
        /// Set the risk limit
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/position/set-risk-limit" /><br />
        /// Endpoint:<br />
        /// POST /v5/position/set-risk-limit
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="riskId">["<c>riskId</c>"] Risk id</param>
        /// <param name="positionIdx">["<c>positionIdx</c>"] Position idx</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitSetRiskLimit>> SetRiskLimitAsync(Category category, string symbol, int riskId, PositionIdx? positionIdx = null, CancellationToken ct = default);

        /// <summary>
        /// Set take profit/stop loss mode
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/position/tpsl-mode" /><br />
        /// Endpoint:<br />
        /// POST /v5/position/set-tpsl-mode
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="tpSlMode">["<c>tpSlMode</c>"] Mode</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitTakeProfitStopLossMode>> SetTakeProfitStopLossModeAsync(Category category, string symbol, StopLossTakeProfitMode tpSlMode, CancellationToken ct = default);

        /// <summary>
        /// Switch cross or isolated margin mode
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/position/cross-isolate" /><br />
        /// Endpoint:<br />
        /// POST /v5/position/switch-isolated
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="tradeMode">["<c>tradeMode</c>"] Trade mode</param>
        /// <param name="buyLeverage">["<c>buyLeverage</c>"] Buy leverage</param>
        /// <param name="sellLeverage">["<c>sellLeverage</c>"] Sell leverage</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult> SwitchCrossIsolatedMarginAsync(Category category, string symbol, TradeMode tradeMode, decimal buyLeverage, decimal sellLeverage, CancellationToken ct = default);

        /// <summary>
        /// Switch position mode
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/position/position-mode" /><br />
        /// Endpoint:<br />
        /// POST /v5/position/switch-mode
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="mode">["<c>mode</c>"] Mode</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="asset">["<c>coin</c>"] Asset</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult> SwitchPositionModeAsync(Category category, PositionMode mode, string? symbol = null, string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Withdraw funds
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/withdraw" /><br />
        /// Endpoint:<br />
        /// POST /v5/asset/withdraw/create
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] Asset, for example `ETH`</param>
        /// <param name="network">["<c>chain</c>"] Network to use</param>
        /// <param name="toAddress">["<c>address</c>"] Target address</param>
        /// <param name="quantity">["<c>amount</c>"] Quantity</param>
        /// <param name="tag">["<c>tag</c>"] Tag</param>
        /// <param name="forceNetwork">["<c>forceChain</c>"] Force on-chain withdrawal</param>
        /// <param name="accountType">["<c>accountType</c>"] Account type to withdraw from</param>
        /// <param name="feeType">["<c>feeType</c>"] Handling fee option</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitId>> WithdrawAsync(string asset, string network, string toAddress, decimal quantity, WithdrawAccountType accountType, string? tag = null, bool? forceNetwork = null, bool? feeType = null, CancellationToken ct = default);

        /// <summary>
        /// Manually add or reduce margin for isolated margin position
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/position/manual-add-margin" /><br />
        /// Endpoint:<br />
        /// POST /v5/position/add-margin
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="margin">["<c>margin</c>"] Margin. Positive for adding, negative for reducing</param>
        /// <param name="positionIdx">["<c>positionIdx</c>"] Position idx</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitPosition>> AddOrReduceMarginAsync(
            Category category,
            string symbol,
            decimal margin,
            PositionIdx? positionIdx = null,
            CancellationToken ct = default);

        /// <summary>
        /// Set the user's maximum leverage in spot cross margin
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/spot-margin-uta/set-leverage" /><br />
        /// Endpoint:<br />
        /// POST /v5/spot-margin-trade/set-leverage
        /// </para>
        /// </summary>
        /// <param name="leverage">["<c>leverage</c>"] New leverage</param>
        /// <param name="asset">["<c>currency</c>"] Asset name</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult> SetSpotMarginLeverageAsync(decimal leverage, string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Query the Spot margin status and leverage of Unified account
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/spot-margin-uta/status" /><br />
        /// Endpoint:<br />
        /// GET /v5/spot-margin-trade/state
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitSpotMarginLeverageStatus>> GetSpotMarginStatusAndLeverageAsync(CancellationToken ct = default);

        /// <summary>
        /// Turn on / off spot margin trade
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/spot-margin-uta/status" /><br />
        /// Endpoint:<br />
        /// POST /v5/spot-margin-trade/switch-mode
        /// </para>
        /// </summary>
        /// <param name="spotMarginMode">["<c>spotMarginMode</c>"] True to enable, false to disable</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitSpotMarginStatus>> SetSpotMarginTradeModeAsync(bool spotMarginMode, CancellationToken ct = default);

        /// <summary>
        /// Get spot margin data
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/spot-margin-uta/vip-margin" /><br />
        /// Endpoint:<br />
        /// GET /v5/spot-margin-trade/data
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>currency</c>"] Filter by asset, for example `ETH`</param>
        /// <param name="vipLevel">["<c>vipLevel</c>"] Filter by VIP level</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitSpotMarginVipMarginList[]>> GetSpotMarginDataAsync(string? asset = null, string? vipLevel = null, CancellationToken ct = default);

        /// <summary>
        /// Get spot margin interest rate history
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/spot-margin-uta/vip-margin" /><br />
        /// Endpoint:<br />
        /// GET /v5/spot-margin-trade/interest-rate-history
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>currency</c>"] The asset, for example `ETH`</param>
        /// <param name="vipLevel">["<c>vipLevel</c>"] VIP level. If not set uses the account VIP level</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitSpotMarginBorrowRate[]>> GetSpotMarginInterestRateHistoryAsync(string asset, string? vipLevel = null, DateTime? startTime = null, DateTime? endTime = null, CancellationToken ct = default);

        /// <summary>
        /// Get broker earnings
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/broker/exchange-earning" /><br />
        /// Endpoint:<br />
        /// GET /v5/broker/earnings-info
        /// </para>
        /// </summary>
        /// <param name="bizType">["<c>bizType</c>"] Filter by bizType</param>
        /// <param name="startTime">["<c>begin</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>end</c>"] Filter by end time</param>
        /// <param name="subAccountId">["<c>uid</c>"] Filter by sub account id</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results</param>
        /// <param name="cursor">["<c>cursor</c>"] Next page cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitBrokerEarnings>> GetBrokerEarningsAsync(string? bizType = null, DateTime? startTime = null, DateTime? endTime = null, string? subAccountId = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get broker account info
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/broker/account-info" /><br />
        /// Endpoint:<br />
        /// GET /v5/broker/account-info
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitBrokerAccountInfo>> GetBrokerAccountInfoAsync(CancellationToken ct = default);

        /// <summary>
        /// Set spot hedging mode
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/account/set-spot-hedge" /><br />
        /// Endpoint:<br />
        /// POST /v5/account/set-hedging-mode
        /// </para>
        /// </summary>
        /// <param name="spotHedgingMode">["<c>setHedgingMode</c>"] Hedging mode on or not</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult> SetSpotHedgingModeAsync(bool spotHedgingMode, CancellationToken ct = default);

        /// <summary>
        /// Manually repay the liabilities of Unified account
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/account/repay-liability" /><br />
        /// Endpoint:<br />
        /// POST /v5/account/quick-repayment
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] Only repay this asset; if null repay all assets</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitLiabilityRepayment[]>> RepayLiabilitiesAsync(string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Request funds for demo trading
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/demo#request-demo-trading-funds" /><br />
        /// Endpoint:<br />
        /// POST /v5/account/demo-apply-money
        /// </para>
        /// </summary>
        /// <param name="funds">["<c>utaDemoApplyMoney</c>"] Dictionary of the asset and amount you want to receive. Only BTC, ETH, USDT or USDC supported</param>
        /// <param name="addOrReduce">["<c>adjustType</c>"] Whether to add(true, default) or reduce (false) the funds with the amounts</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult> RequestDemoFundsAsync(Dictionary<string, decimal> funds, bool? addOrReduce = null, CancellationToken ct = default);

        /// <summary>
        /// Get convert assets list
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/convert/convert-coin-list" /><br />
        /// Endpoint:<br />
        /// GET /v5/asset/exchange/query-coin-list
        /// </para>
        /// </summary>
        /// <param name="accountType">["<c>accountType</c>"] Account type</param>
        /// <param name="asset">["<c>coin</c>"] Filter by asset, for example `USDT`</param>
        /// <param name="side">["<c>side</c>"] Request side, from or to list</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitConvertAsset[]>> GetConvertAssetsAsync(ConvertAccountType accountType, string? asset = null, ConvertAssetSide? side = null, CancellationToken ct = default);

        /// <summary>
        /// Get a convert quote for 2 assets
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/convert/apply-quote" /><br />
        /// Endpoint:<br />
        /// POST /v5/asset/exchange/quote-apply
        /// </para>
        /// </summary>
        /// <param name="accountType">["<c>accountType</c>"] Account type</param>
        /// <param name="fromAsset">From asset (selling)</param>
        /// <param name="toAsset">["<c>toCoin</c>"] To asset (buying)</param>
        /// <param name="quantity">["<c>requestAmount</c>"] Quantity to sell</param>
        /// <param name="clientOrderId">["<c>requestId</c>"] Request id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitConvertQuote>> GetConvertQuoteAsync(ConvertAccountType accountType, string fromAsset, string toAsset, decimal quantity, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Confirm a convert quote and start the conversion
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/convert/confirm-quote" /><br />
        /// Endpoint:<br />
        /// POST /v5/asset/exchange/convert-execute
        /// </para>
        /// </summary>
        /// <param name="quoteTransactionId">["<c>quoteTxId</c>"] The quote transaction id to confirm</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitConvertTransactionResult>> ConvertConfirmQuoteAsync(string quoteTransactionId, CancellationToken ct = default);

        /// <summary>
        /// Get status of a convert transaction
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/convert/get-convert-result" /><br />
        /// Endpoint:<br />
        /// GET /v5/asset/exchange/convert-result-query
        /// </para>
        /// </summary>
        /// <param name="accountType">["<c>accountType</c>"] Account type</param>
        /// <param name="quoteTransactionId">["<c>quoteTxId</c>"] Transaction id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitConvertTransaction>> GetConvertStatusAsync(ConvertAccountType accountType, string quoteTransactionId, CancellationToken ct = default);

        /// <summary>
        /// Get convert history
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/convert/get-convert-history" /><br />
        /// Endpoint:<br />
        /// GET /v5/asset/exchange/query-convert-history
        /// </para>
        /// </summary>
        /// <param name="accountType">["<c>accountType</c>"] Filter by account type</param>
        /// <param name="page">["<c>index</c>"] Page</param>
        /// <param name="pageSize">["<c>limit</c>"] Page size</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitConvertTransaction[]>> GetConvertHistoryAsync(ConvertAccountType? accountType = null, int? page = null, int? pageSize = null, CancellationToken ct = default);

        /// <summary>
        /// Get quantity available for withdrawal/transfer from unified wallet
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/account/unified-trans-amnt" /><br />
        /// Endpoint:<br />
        /// GET /v5/account/withdrawal
        /// </para>
        /// </summary>
        /// <param name="asset">Asset name</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitTransferable>> GetTransferableAsync(string asset, CancellationToken ct = default);

        /// <summary>
        /// Get quantity available for withdrawal/transfer from unified wallet
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/account/unified-trans-amnt" /><br />
        /// Endpoint:<br />
        /// GET /v5/account/withdrawal
        /// </para>
        /// </summary>
        /// <param name="assets">["<c>coinName</c>"] Asset names, can request up to 20 assets</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitTransferable>> GetTransferableAsync(IEnumerable<string> assets, CancellationToken ct = default);

        /// <summary>
        /// Set the behavior when placing an order exceeding the price limit
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/account/set-price-limit" /><br />
        /// Endpoint:<br />
        /// POST /v5/account/set-limit-px-action
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="allowModifyPrice">["<c>modifyEnable</c>"] True: allow the system to adjust the price to nearest allowed, False: fail the order</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult> SetPriceLimitBehaviorAsync(Category category, bool allowModifyPrice, CancellationToken ct = default);

        /// <summary>
        /// Get spot symbols available to the user
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/account/instrument" /><br />
        /// Endpoint:<br />
        /// GET /v5/account/instruments-info
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol</param>
        /// <param name="limit">["<c>limit</c>"] Number of results, max 200</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitResponse<BybitSpotSymbol>>> GetSpotSymbolsAsync(string? symbol = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get linear/inverse symbols available to the user
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/account/instrument" /><br />
        /// Endpoint:<br />
        /// GET /v5/account/instruments-info
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category, either linear or inverse</param>
        /// <param name="symbol">Filter by symbol</param>
        /// <param name="limit">["<c>limit</c>"] Number of results, max 200</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitResponse<BybitLinearInverseSymbol>>> GetLinearInverseSymbolsAsync(
            Category category,
            string? symbol = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get withdrawal addresses
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/withdraw/withdraw-address" /><br />
        /// Endpoint:<br />
        /// GET /v5/asset/withdraw/query-address
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] Filter by asset</param>
        /// <param name="network">["<c>chain</c>"] Filter by network</param>
        /// <param name="addressType">["<c>addressType</c>"] Filter by network type</param>
        /// <param name="limit">["<c>limit</c>"] Number of results, max 50</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitResponse<BybitWithdrawAddress>>> GetWithdrawAddressListAsync(
            string? asset = null,
            string? network = null,
            AddressType? addressType = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get small balance assets
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/convert-small-balance/small-balanc-coins" /><br />
        /// Endpoint:<br />
        /// GET /v5/asset/covert/small-balance-list
        /// </para>
        /// </summary>
        /// <param name="accountType">["<c>accountType</c>"] Account type</param>
        /// <param name="fromAsset">["<c>fromCoin</c>"] From asset filter</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitSmallBalanceAssets>> GetSmallBalanceAssetsAsync(
            ConvertAccountType accountType,
            string? fromAsset = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get small balance exchange quote
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/convert-small-balance/request-quote" /><br />
        /// Endpoint:<br />
        /// POST /v5/asset/covert/get-quote
        /// </para>
        /// </summary>
        /// <param name="accountType">["<c>accountType</c>"] Account type</param>
        /// <param name="fromAssets">["<c>fromCoinList</c>"] Assets to convert</param>
        /// <param name="toAsset">["<c>toCoin</c>"] Output asset</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitSmallBalancesQuote>> GetSmallBalancesQuoteAsync(
            ConvertAccountType accountType,
            IEnumerable<string> fromAssets,
            string toAsset,
            CancellationToken ct = default);

        /// <summary>
        /// Confirm small balances exchange quote
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/convert-small-balance/confirm-quote" /><br />
        /// Endpoint:<br />
        /// POST /v5/asset/covert/small-balance-execute
        /// </para>
        /// </summary>
        /// <param name="quoteId">["<c>quoteId</c>"] Quote id</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitSmallBalancesQuoteResult>> ConfirmSmallBalancesQuoteAsync(
            string quoteId,
            CancellationToken ct = default);

        /// <summary>
        /// Get small balances exchange history
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/convert-small-balance/exchange-history" /><br />
        /// Endpoint:<br />
        /// GET /v5/asset/covert/small-balance-history
        /// </para>
        /// </summary>
        /// <param name="accountType">["<c>accountType</c>"] Filter by account</param>
        /// <param name="quoteId">["<c>quoteId</c>"] Filter by quote id</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="page">["<c>cursor</c>"] Page number</param>
        /// <param name="pageSize">["<c>size</c>"] Page size</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitPage<BybitSmallBalancesExchangeItem>>> GetSmallBalancesExchangeHistoryAsync(
            ConvertAccountType? accountType = null,
            string? quoteId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? page = null,
            int? pageSize = null,
            CancellationToken ct = default);

        /// <summary>
        /// Set Spot Margin auto repay mode
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/spot-margin-uta/set-auto-repay-mode" /><br />
        /// Endpoint:<br />
        /// POST /v5/spot-margin-trade/set-auto-repay-mode
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>currency</c>"] Asset. If not provided set for all assets</param>
        /// <param name="enabled">["<c>autoRepayMode</c>"] Enable or not</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitSpotMarginAutoRepayMode[]>> SetSpotMarginAutoRepayModeAsync(bool enabled, string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Get Spot Margin auto repay mode
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/spot-margin-uta/get-auto-repay-mode" /><br />
        /// Endpoint:<br />
        /// GET /v5/spot-margin-trade/get-auto-repay-mode
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>currency</c>"] Asset. If not provided get mode for all assets</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitSpotMarginAutoRepayMode[]>> GetSpotMarginAutoRepayModeAsync(string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Get spot margin borrow asset data
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/spot-margin-uta/currency-data" /><br />
        /// Endpoint:<br />
        /// GET /v5/spot-margin-trade/currency-data<br />
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>currency</c>"] Filter by asset</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitMarginAssetData[]>> GetSpotMarginAssetDataAsync(string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Sign a trading agreement, required before trading certain products or using certain features
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/user/sign-agreement" /><br />
        /// Endpoint:<br />
        /// POST /v5/user/agreement<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] The category to sign</param>
        /// <param name="agree">["<c>agree</c>"] Agree</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult> SignAgreementAsync(AgreementCategory category, bool agree, CancellationToken ct = default);

        /// <summary>
        /// Get transfer history for the funding account
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/fund-history" /><br />
        /// Endpoint:<br />
        /// GET /v5/asset/fundinghistory<br />
        /// </para>
        /// </summary>
        /// <param name="startTime">["<c>createTimeFrom</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>createTimeTo</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results, max 100</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitResponse<BybitFundingTransfer>>> GetFundingTransactionHistoryAsync(DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get asset overview
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/balance/asset-overview" /><br />
        /// Endpoint:<br />
        /// GET /v5/asset/asset-overview<br />
        /// </para>
        /// </summary>
        /// <param name="memberId">["<c>memberId</c>"] User ID. When using master API key to query sub account assets, this field is required</param>
        /// <param name="valuationAsset">["<c>valuationCurrency</c>"] Valuation fiat asset, defaults to USD</param>
        /// <param name="accountType">["<c>accountType</c>"] Account type filter</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitAccountOverview>> GetAssetOverviewAsync(
            string? memberId = null,
            string? valuationAsset = null,
            AssetAccountType? accountType = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get max order quantity for spread trading
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/spread/trade/max-qty" /><br />
        /// Endpoint:<br />
        /// GET /v5/spread/max-qty<br />
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="side">["<c>side</c>"] Order side</param>
        /// <param name="price">["<c>orderPrice</c>"] Order price</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitMaxSpreadQuantity>> GetSpreadMaxOrderQuantityAsync(
            string symbol,
            OrderSide side,
            decimal price,
            CancellationToken ct = default);

        /// <summary>
        /// Get option asset info
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/account/option-asset-info" /><br />
        /// Endpoint:<br />
        /// GET /v5/account/option-asset-info<br />
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitOptionAssetInfo[]>> GetOptionAssetInfoAsync(CancellationToken ct = default);

        /// <summary>
        /// Get trade statistics for analysis
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/account/trade-info-for-analysis" /><br />
        /// Endpoint:<br />
        /// GET /v5/account/trade-info-for-analysis<br />
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BybitAnalysisTradeInfo>> GetAnalysisTradeInfoAsync(
            string symbol,
            DateTime? startTime = null,
            DateTime? endTime = null,
            CancellationToken ct = default);

    }
}
