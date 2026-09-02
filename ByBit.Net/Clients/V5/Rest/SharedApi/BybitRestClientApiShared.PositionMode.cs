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
        #region Position Mode client

        public SharedPositionModeSelection PositionModeSettingType => SharedPositionModeSelection.PerSymbol;

        public GetPositionModeOptions GetPositionModeOptions { get; } = new GetPositionModeOptions(_exchangeName);
        public async Task<HttpResult<SharedPositionModeResult>> GetPositionModeAsync(GetPositionModeRequest request, CancellationToken ct)
        {
            var validationError = GetPositionModeOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedPositionModeResult>(Exchange, validationError);

            var tradingMode = request.Symbol?.TradingMode ?? request.TradingMode ?? TradingMode.PerpetualLinear;
            var category = (tradingMode == TradingMode.PerpetualLinear || tradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var result = await _api.Trading.GetPositionsAsync(
                category,
                request.Symbol?.GetSymbol(FormatSymbol),
                limit: 1,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedPositionModeResult>(result);

            if (!result.Data.List.Any())
                return HttpResult.Fail<SharedPositionModeResult>(Exchange, new ServerError(new ErrorInfo(ErrorType.NoPosition, "Position not found")));

            return HttpResult.Ok(result, new SharedPositionModeResult(result.Data.List.Single().PositionIdx == PositionIdx.OneWayMode ? SharedPositionMode.OneWay : SharedPositionMode.HedgeMode));
        }

        public SetPositionModeOptions SetPositionModeOptions { get; } = new SetPositionModeOptions(_exchangeName);
        public async Task<HttpResult<SharedPositionModeResult>> SetPositionModeAsync(SetPositionModeRequest request, CancellationToken ct)
        {
            var validationError = SetPositionModeOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedPositionModeResult>(Exchange, validationError);

            var tradingMode = request.Symbol?.TradingMode ?? request.TradingMode ?? TradingMode.PerpetualLinear;
            var category = (tradingMode == TradingMode.PerpetualLinear || tradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var result = await _api.Account.SwitchPositionModeAsync(
                category,
                symbol: request.Symbol?.GetSymbol(FormatSymbol),
                mode: request.PositionMode == SharedPositionMode.HedgeMode ? PositionMode.BothSides : PositionMode.MergedSingle, ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedPositionModeResult>(result);

            return HttpResult.Ok(result, new SharedPositionModeResult(request.PositionMode));
        }
        #endregion
    }
}
