using Bybit.Net.Enums;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Models;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.GeneralApi
{
    /// <summary>
    /// Bybit asset transfer endpoints
    /// </summary>
    public interface IBybitClientGeneralApiTransfer
    {
        /// <summary>
        /// Create a new transfer from one account type to the other
        /// <para><a href="https://bybit-exchange.github.io/docs/account_asset/#t-createinternaltransfer" /></para>
        /// </summary>
        /// <param name="transferId">A generated UUID, should be unique</param>
        /// <param name="asset">The asset to transfer</param>
        /// <param name="quantity">Quantity to transfer</param>
        /// <param name="fromAccountType">From account</param>
        /// <param name="toAccountType">To account</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitTransfer>> CreateInternalTransferAsync(string transferId, string asset, decimal quantity, AccountType fromAccountType, AccountType toAccountType, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Create a new transfer for a subaccount
        /// <para><a href="https://bybit-exchange.github.io/docs/account_asset/#t-createsubaccounttransfer" /></para>
        /// </summary>
        /// <param name="transferId">A generated UUID, should be unique</param>
        /// <param name="asset">The asset to transfer</param>
        /// <param name="quantity">Quantity to transfer</param>
        /// <param name="subAccountId">The sub account id</param>
        /// <param name="type">The type of the transfer</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitTransfer>> CreateSubAccountTransferAsync(string transferId, string asset, decimal quantity, string subAccountId, TransferType type, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get history of transfers
        /// <para><a href="https://bybit-exchange.github.io/docs/account_asset/#t-querytransferlist" /></para>
        /// </summary>
        /// <param name="transferId">Filter by transfer id</param>
        /// <param name="asset">Filter by asset</param>
        /// <param name="status">Filter by status</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="direction">Filter by direction</param>
        /// <param name="limit">Max amount of results</param>
        /// <param name="cursor">Page cursor</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitCursorPage<IEnumerable<BybitInternalTransferDetails>>>> GetTransferHistoryAsync(
            string? transferId = null,
            string? asset = null,
            TransferStatus? status = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            SearchDirection? direction = null,
            int? limit = null,
            string? cursor = null,
            long? receiveWindow = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get history of sub account transfers
        /// <para><a href="https://bybit-exchange.github.io/docs/account_asset/#t-querysubaccounttransferlist" /></para>
        /// </summary>
        /// <param name="transferId">Filter by transfer id</param>
        /// <param name="asset">Filter by asset</param>
        /// <param name="status">Filter by status</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="direction">Filter by direction</param>
        /// <param name="limit">Max amount of results</param>
        /// <param name="cursor">Page cursor</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitCursorPage<IEnumerable<BybitSubAccountTransferDetails>>>> GetSubAccountTransferHistoryAsync(
            string? transferId = null,
            string? asset = null,
            TransferStatus? status = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            SearchDirection? direction = null,
            int? limit = null,
            string? cursor = null,
            long? receiveWindow = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get a list of subaccount ids
        /// <para><a href="https://bybit-exchange.github.io/docs/account_asset/#t-querysubaccountlist" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitSubAccountList>> GetSubAccountsAsync(long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Enable universal transfers between sub accounts
        /// <para><a href="https://bybit-exchange.github.io/docs/account_asset/#t-enableuniversaltransfer" /></para>
        /// </summary>
        /// <param name="subaccountIds">Sub account ids to enable</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> EnableSubaccountsUniversalTransferAsync(IEnumerable<string>? subaccountIds = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Create a new universal transfer
        /// <para><a href="https://bybit-exchange.github.io/docs/account_asset/#t-createuniversaltransfer" /></para>
        /// </summary>
        /// <param name="transferId">Unique id</param>
        /// <param name="asset">Asset</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="fromMemberId">From id</param>
        /// <param name="toMemberId">To id</param>
        /// <param name="fromAccountType">From type</param>
        /// <param name="toAccountType">To type</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitTransferId>> UniversalTransferAsync(string transferId, string asset, decimal quantity, string fromMemberId, string toMemberId, AccountType fromAccountType, AccountType toAccountType, long? receiveWindow = null, CancellationToken ct = default);


        /// <summary>
        /// Get history of universal account transfers
        /// <para><a href="https://bybit-exchange.github.io/docs/account_asset/#t-queryuniversetransferlist" /></para>
        /// </summary>
        /// <param name="transferId">Filter by transfer id</param>
        /// <param name="asset">Filter by asset</param>
        /// <param name="status">Filter by status</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="direction">Filter by direction</param>
        /// <param name="limit">Max amount of results</param>
        /// <param name="cursor">Page cursor</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitCursorPage<IEnumerable<BybitUniversalTransfer>>>> GetUniversalTransferHistoryAsync(
            string? transferId = null,
            string? asset = null,
            TransferStatus? status = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            SearchDirection? direction = null,
            int? limit = null,
            string? cursor = null,
            long? receiveWindow = null,
            CancellationToken ct = default);
    }
}