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


        #region Get Position History

        async Task<ICallResult<SharedPositionHistory[]>> IGetPositionHistory.GetPositionHistoryAsync(GetPositionHistoryRequest request, PageRequest? pageRequest, CancellationToken ct)
            => await GetPositionHistoryAsync(request, pageRequest, ct).ConfigureAwait(false);

        public GetPositionHistoryOptions GetPositionHistoryOptions { get; } = new GetPositionHistoryOptions(_exchangeName, false, true, true, 100);
        public async Task<HttpResult<SharedPositionHistory[]>> GetPositionHistoryAsync(GetPositionHistoryRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var validationError = GetPositionHistoryOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedPositionHistory[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var limit = request.Limit ?? 100;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest);

            // Get data
            var tradingMode = request.Symbol?.TradingMode ?? request.TradingMode ?? TradingMode.PerpetualLinear;
            var category = tradingMode.IsLinear() ? Category.Linear : Category.Inverse;
            var result = await _api.Trading.GetClosedProfitLossAsync(
                category,
                symbol: request.Symbol?.GetSymbol(FormatSymbol),
                startTime: pageParams.StartTime,
                endTime: pageParams.EndTime,
                limit: limit,
                cursor: pageParams.Cursor,
                ct: ct
                ).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedPositionHistory[]>(result);

            var nextPageRequest = Pagination.GetNextPageRequest(
                () => result.Data.NextPageCursor == null ? null : Pagination.NextPageFromCursor(result.Data.NextPageCursor),
                result.Data.List.Length,
                result.Data.List.Select(x => x.CreateTime),
                request.StartTime,
                request.EndTime ?? DateTime.UtcNow,
                pageParams);

            return HttpResult.Ok(result, ExchangeHelpers.ApplyFilter(result.Data.List, x => x.CreateTime, request.StartTime, request.EndTime, direction)
                       .Select(x => 
                            new SharedPositionHistory(
                                ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, x.Symbol), 
                                x.Symbol,
                                x.Side == OrderSide.Sell ? SharedPositionSide.Long : SharedPositionSide.Short,
                                x.AverageEntryPrice,
                                x.AverageExitPrice,
                                new SharedOrderQuantity(x.ClosedSize),
                                x.ClosedPnl,
                                x.UpdateTime)
                            {
                                Leverage = x.Leverage,
                                OrderId = x.OrderId
                            })
                       .ToArray(), nextPageRequest);
        }

        #endregion

    }
}
