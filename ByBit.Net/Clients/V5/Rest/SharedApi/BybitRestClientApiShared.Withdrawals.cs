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

        #region Get Withdrawal History

        Task<HttpResult<SharedWithdrawal[]>> IWithdrawalRestClient.GetWithdrawalsAsync(GetWithdrawalsRequest request, PageRequest? nextPageToken, CancellationToken ct)
            => GetWithdrawalHistoryAsync(request, nextPageToken, ct);

        GetWithdrawalHistoryOptions IWithdrawalRestClient.GetWithdrawalsOptions => GetWithdrawalHistoryOptions;

        async Task<ICallResult<SharedWithdrawal[]>> IGetWithdrawalHistory.GetWithdrawalHistoryAsync(GetWithdrawalsRequest request, PageRequest? pageRequest, CancellationToken ct)
            => await GetWithdrawalHistoryAsync(request, pageRequest, ct).ConfigureAwait(false);

        public GetWithdrawalHistoryOptions GetWithdrawalHistoryOptions { get; } = new GetWithdrawalHistoryOptions(_exchangeName, false, true, true, 50);
        public async Task<HttpResult<SharedWithdrawal[]>> GetWithdrawalHistoryAsync(GetWithdrawalsRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var validationError = GetWithdrawalHistoryOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedWithdrawal[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var limit = request.Limit ?? 50;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest, true, TimeSpan.FromDays(30));

            // Get data
            var result = await _api.Account.GetWithdrawalsAsync(
                startTime: pageParams.StartTime,
                endTime: pageParams.EndTime,
                asset: request.Asset,
                limit: limit,
                cursor: pageParams.Cursor,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedWithdrawal[]>(result);

            var nextPageRequest = Pagination.GetNextPageRequest(
                () => result.Data.NextPageCursor == null ? null : Pagination.NextPageFromCursor(result.Data.NextPageCursor),
                result.Data.List.Length,
                result.Data.List.Select(x => x.CreateTime),
                request.StartTime,
                request.EndTime ?? DateTime.UtcNow,
                pageParams,
                TimeSpan.FromDays(30));

            return HttpResult.Ok(result, ExchangeHelpers.ApplyFilter(result.Data.List, x => x.CreateTime, request.StartTime, request.EndTime, direction)
                       .Select(x => 
                            new SharedWithdrawal(
                                x.Asset,
                                x.ToAddress, 
                                x.Quantity, 
                                x.Status == WithdrawalStatus.Success, 
                                x.CreateTime,
                                GetWithdrawalStatus(x))
                            {
                                Id = x.Id,
                                Network = x.Network,
                                Tag = x.Tag,
                                TransactionId = x.TransactionId,
                                Fee = x.WithdrawFee
                            })
                       .ToArray(), nextPageRequest);
        }

        #endregion

        private SharedTransferStatus GetWithdrawalStatus(BybitWithdrawal x)
        {
            if (x.Status == WithdrawalStatus.Failed || x.Status == WithdrawalStatus.CanceledByUser || x.Status == WithdrawalStatus.Rejected)
                return SharedTransferStatus.Failed;

            if (x.Status == WithdrawalStatus.Success)
                return SharedTransferStatus.Completed;

            if (x.Status == WithdrawalStatus.BlockchainConfirmed
                || x.Status == WithdrawalStatus.MoreInformationRequired
                || x.Status == WithdrawalStatus.Pending
                || x.Status == WithdrawalStatus.SecurityCheck)
            {
                return SharedTransferStatus.InProgress;
            }

            return SharedTransferStatus.Unknown;
        }



        #region Withdraw

        async Task<ICallResult<SharedId>> IWithdraw.WithdrawAsync(WithdrawRequest request, CancellationToken ct)
            => await WithdrawAsync(request, ct).ConfigureAwait(false);

        public WithdrawOptions WithdrawOptions { get; } = new WithdrawOptions(_exchangeName)
        {
            ParameterRuleOverrides = [            
                RequestParameterRuleOverride<WithdrawRequest>.Required(x => x.Network)
            ],
            ExchangeParameterRules = [
                ExchangeParameterRule.Optional("TravelRuleQuestionnaire", "Travel rule questionnaire", new BybitWithdrawQuestionnaireEu())
            ]
        };

        public async Task<HttpResult<SharedId>> WithdrawAsync(WithdrawRequest request, CancellationToken ct)
        {
            var validationError = WithdrawOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            // Get data
            var questionnaire = ExchangeParameters.GetValue<BybitWithdrawQuestionnaireEu?>(request.ExchangeParameters, Exchange, "TravelRuleQuestionnaire");
            var withdrawal = await _api.Account.WithdrawAsync(
                request.Asset,
                toAddress: request.Address,
                quantity: request.Quantity,
                network: request.Network!,
                tag: request.AddressTag,
                accountType: WithdrawAccountType.FundAndUta,
                questionnaire: questionnaire,
                ct: ct).ConfigureAwait(false);
            if (!withdrawal.Success)
                return HttpResult.Fail<SharedId>(withdrawal);

            return HttpResult.Ok(withdrawal, new SharedId(withdrawal.Data.Id));
        }

        #endregion

    }
}
