using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.SharedApis;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Bybit.Net.Clients.V5
{
    internal partial class BybitRestClientSharedApi
    {
        #region Deposit client
        public GetDepositAddressesOptions GetDepositAddressesOptions { get; } = new GetDepositAddressesOptions(_exchangeName, true);

        public async Task<HttpResult<SharedDepositAddress[]>> GetDepositAddressesAsync(GetDepositAddressesRequest request, CancellationToken ct)
        {
            var validationError = GetDepositAddressesOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedDepositAddress[]>(Exchange, validationError);

            var depositAddresses = await _api.Account.GetDepositAddressAsync(request.Asset, request.Network).ConfigureAwait(false);
            if (!depositAddresses.Success)
                return HttpResult.Fail<SharedDepositAddress[]>(depositAddresses);

            return HttpResult.Ok(depositAddresses, depositAddresses.Data.Networks.Select(x => new SharedDepositAddress(depositAddresses.Data.Asset, x.DepositAddress)
            {
                TagOrMemo = x.DepositTag,
                Network = x.Network,
            }
            ).ToArray());
        }

        Task<HttpResult<SharedDeposit[]>> IDepositRestClient.GetDepositsAsync(GetDepositsRequest request, PageRequest? nextPageToken, CancellationToken ct)
            => GetDepositHistoryAsync(request, nextPageToken, ct);
        GetDepositHistoryOptions IDepositRestClient.GetDepositsOptions => GetDepositHistoryOptions;


        public GetDepositHistoryOptions GetDepositHistoryOptions { get; } = new GetDepositHistoryOptions(_exchangeName, false, true, true, 50);
        public async Task<HttpResult<SharedDeposit[]>> GetDepositHistoryAsync(GetDepositsRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var validationError = GetDepositHistoryOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedDeposit[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var limit = request.Limit ?? 50;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest, true, TimeSpan.FromDays(30));

            // Get data
            var result = await _api.Account.GetDepositsAsync(
                startTime: pageParams.StartTime,
                endTime: pageParams.EndTime,
                asset: request.Asset,
                limit: limit,
                cursor: pageParams.Cursor,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedDeposit[]>(result);

            var nextPageRequest = Pagination.GetNextPageRequest(
                () => result.Data.NextPageCursor == null ? null : Pagination.NextPageFromCursor(result.Data.NextPageCursor),
                result.Data.Deposits.Length,
                result.Data.Deposits.Select(x => x.SuccessTime ?? default),
                request.StartTime,
                request.EndTime ?? DateTime.UtcNow,
                pageParams,
                TimeSpan.FromDays(30));

            return HttpResult.Ok(result, ExchangeHelpers.ApplyFilter(result.Data.Deposits, x => x.SuccessTime ?? default, request.StartTime, request.EndTime, direction)
                       .Select(x => 
                            new SharedDeposit(
                                x.Asset, 
                                x.Quantity, 
                                x.Status == DepositStatus.Success,
                                x.SuccessTime ?? new DateTime(),
                                ParseTransferStatus(x.Status))
                            {
                                Network = x.Network,
                                TransactionId = x.TransactionId,
                            })
                       .ToArray(), nextPageRequest);
        }

        private SharedTransferStatus ParseTransferStatus(DepositStatus status)
        {
            if (status == DepositStatus.Success || status == DepositStatus.SuccessAfterRollback || status == DepositStatus.CreditedToFundingPool)
                return SharedTransferStatus.Completed;
            if (status == DepositStatus.DepositFailed)
                return SharedTransferStatus.Failed;
            if (status == DepositStatus.Processing
                || status == DepositStatus.ToBeConfirmed
                || status == DepositStatus.PendingCreditToFundingPool
                || status == DepositStatus.PendingAfterRollback
                || status == DepositStatus.RollbackProcessing)
            {
                return SharedTransferStatus.InProgress;
            }

            return SharedTransferStatus.Unknown;
        }

        #endregion
    }
}
