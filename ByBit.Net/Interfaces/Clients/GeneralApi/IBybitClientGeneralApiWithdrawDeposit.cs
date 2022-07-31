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
    /// Bybit withdrawal and deposit endpoints
    /// </summary>
    public interface IBybitClientGeneralApiWithdrawDeposit
    {
        /// <summary>
        /// Get deposit information
        /// </summary>
        /// <param name="asset">Filter by asset</param>
        /// <param name="network">Filter by network</param>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitDepositConfig>>> GetSupportedDepositMethodsAsync(
           string? asset = null,
           string? network = null,
           int? page = null,
           int? pageSize = null,
           long? receiveWindow = null,
           CancellationToken ct = default);

        /// <summary>
        /// Get deposit history
        /// </summary>
        /// <param name="asset">Filter by asset</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="direction">Filter by direction</param>
        /// <param name="limit">Max amount of results</param>
        /// <param name="cursor">Page cursor</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitCursorPage<IEnumerable<BybitDeposit>>>> GetDepositHistoryAsync(
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            SearchDirection? direction = null,
            int? limit = null,
            string? cursor = null,
            long? receiveWindow = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get withdrawal history
        /// </summary>
        /// <param name="withdrawalId">Filter by withdrawal id</param>
        /// <param name="asset">Filter by asset</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="direction">Filter by direction</param>
        /// <param name="limit">Max amount of results</param>
        /// <param name="cursor">Page cursor</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitCursorPage<IEnumerable<BybitWithdraw>>>> GetWithdrawalHistoryAsync(
            string? withdrawalId = null,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            SearchDirection? direction = null,
            int? limit = null,
            string? cursor = null,
            long? receiveWindow = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get asset information regarding withdrawal/deposits
        /// </summary>
        /// <param name="asset">Filter by asset</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitAssetInfo>>> GetAssetInfoAsync(
            string? asset = null,
            long? receiveWindow = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get account info
        /// </summary>
        /// <param name="asset">Filter asset</param>
        /// <param name="accountType">Filter account type</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<Dictionary<string, BybitGeneralAccountStatus>>> GetAccountInfoAsync(
           string? asset = null,
           string? accountType = null,
           long? receiveWindow = null,
           CancellationToken ct = default);

        /// <summary>
        /// Create a withdrawal request
        /// </summary>
        /// <param name="asset">Asset to withdraw</param>
        /// <param name="network">Network to use</param>
        /// <param name="address">Address to withdraw to, should be whitelisted</param>
        /// <param name="quantity">Quantity to withdraw</param>
        /// <param name="tag">Tag</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitId>> WithdrawAsync(
            string asset,
            string network,
            string address,
            decimal quantity,
            string? tag = null,
            long? receiveWindow = null,
            CancellationToken ct = default);

        /// <summary>
        /// Cancel withdrawal
        /// </summary>
        /// <param name="withdrawalId">Id to cancel</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> CancelWithdrawalAsync(
            string withdrawalId,
            long? receiveWindow = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get deposit addresses for an asset
        /// </summary>
        /// <param name="asset">The asset to get addresses for</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitDepositAddress>> GetDepositAddressesAsync(
            string asset,
            long? receiveWindow = null,
            CancellationToken ct = default);
    }
}