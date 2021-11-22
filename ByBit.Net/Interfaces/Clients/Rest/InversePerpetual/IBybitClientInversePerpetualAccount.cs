using Bybit.Net.Enums;
using Bybit.Net.Objects.Models;
using ByBit.Net.Objects.Models;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ByBit.Net.Clients.Rest.InversePerpetual
{
    /// <summary>
    /// Ac
    /// </summary>
    public interface IBybitClientInversePerpetualAccount
    {
        /// <summary>
        /// 1
        /// </summary>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<ByBitApiKeyInfo>>> GetApiKeyInfoAsync(long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// 2
        /// </summary>
        /// <param name="fromId"></param>
        /// <param name="direction"></param>
        /// <param name="limit"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitExchangeHistoryEntry>>> GetAssetExchangeHistoryAsync(long? fromId = null, SearchDirection? direction = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);
        
        /// <summary>
        /// 3
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<Dictionary<string, BybitBalance>>> GetBalancesAsync(string? asset = null, long? receiveWindow = null, CancellationToken ct = default);
        
        /// <summary>
        /// 4
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<BybitFundingSettlement>> GetUserLastFundingFeeAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);
        
        /// <summary>
        /// 5
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<BybitPredictedFunding>> GetUserPredictedFundingRateAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);
        
        /// <summary>
        /// 6
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="type"></param>
        /// <param name="pageSize"></param>
        /// <param name="page"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitWalletFundRecord>>> GetWalletFundHistoryAsync(string? asset = null, DateTime? startTime = null, DateTime? endTime = null, WalletFundType? type = null, int? pageSize = null, int? page = null, long? receiveWindow = null, CancellationToken ct = default);
        
        /// <summary>
        /// 7
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="status"></param>
        /// <param name="pageSize"></param>
        /// <param name="page"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitWithdrawal>>> GetWithdrawalHistoryAsync(string? asset = null, DateTime? startTime = null, DateTime? endTime = null, WithdrawStatus? status = null, int? pageSize = null, int? page = null, long? receiveWindow = null, CancellationToken ct = default);
    }
}