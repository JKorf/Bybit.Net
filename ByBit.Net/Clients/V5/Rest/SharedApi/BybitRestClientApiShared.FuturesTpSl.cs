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
        #region Set Futures TP/SL

        async Task<ICallResult<SharedId>> ISetFuturesTpSl.SetFuturesTpSlAsync(SetTpSlRequest request, CancellationToken ct)
            => await SetFuturesTpSlAsync(request, ct).ConfigureAwait(false);

        public SetFuturesTpSlOptions SetFuturesTpSlOptions { get; } = new SetFuturesTpSlOptions(_exchangeName, true)
        {
            ParameterRuleOverwrites = [
                RequestParameterRuleOverride<SetTpSlRequest>.Required(x => x.PositionMode)
            ]
        };

        public async Task<HttpResult<SharedId>> SetFuturesTpSlAsync(SetTpSlRequest request, CancellationToken ct)
        {
            var validationError = SetFuturesTpSlOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var category = request.Symbol!.TradingMode.IsLinear() ? Category.Linear : Category.Inverse;
            var result = await _api.Trading.SetTradingStopAsync(
                category,
                request.Symbol!.GetSymbol(FormatSymbol),
                positionIdx: request.PositionMode == SharedPositionMode.OneWay ? PositionIdx.OneWayMode : request.PositionSide == SharedPositionSide.Long ? PositionIdx.BuyHedgeMode : PositionIdx.SellHedgeMode,
                takeProfit: request.TpSlSide == SharedTpSlSide.TakeProfit ? request.TriggerPrice : null,
                takeProfitOrderType: request.TpSlSide == SharedTpSlSide.TakeProfit ? OrderType.Market : null,
                stopLoss: request.TpSlSide == SharedTpSlSide.StopLoss ? request.TriggerPrice : null,
                stopLossOrderType: request.TpSlSide == SharedTpSlSide.StopLoss ? OrderType.Market : null,
                stopLossTakeProfitMode: StopLossTakeProfitMode.Full,
                ct: ct).ConfigureAwait(false);

            if (!result.Success)
                return HttpResult.Fail<SharedId>(result);

            // Return
            return HttpResult.Ok(result, new SharedId(""));
        }

        #endregion

        #region Cancel Futures TP/SL

        async Task<ICallResult<bool>> ICancelFuturesTpSl.CancelFuturesTpSlAsync(CancelTpSlRequest request, CancellationToken ct)
            => await CancelFuturesTpSlAsync(request, ct).ConfigureAwait(false);

        public CancelFuturesTpSlOptions CancelFuturesTpSlOptions { get; } = new CancelFuturesTpSlOptions(_exchangeName, true)
        {
            ParameterRuleOverwrites = [
                RequestParameterRuleOverride<CancelTpSlRequest>.Required(x => x.PositionMode)
            ]
        };

        public async Task<HttpResult<bool>> CancelFuturesTpSlAsync(CancelTpSlRequest request, CancellationToken ct)
        {
            var validationError = CancelFuturesTpSlOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<bool>(Exchange, validationError);

            var category = request.Symbol!.TradingMode.IsLinear() ? Category.Linear : Category.Inverse;
            var result = await _api.Trading.SetTradingStopAsync(
                category,
                request.Symbol!.GetSymbol(FormatSymbol),
                positionIdx: request.PositionMode == SharedPositionMode.OneWay ? PositionIdx.OneWayMode : request.PositionSide == SharedPositionSide.Long ? PositionIdx.BuyHedgeMode : PositionIdx.SellHedgeMode,
                takeProfit: request.TpSlSide == SharedTpSlSide.TakeProfit ? 0 : null,
                stopLoss: request.TpSlSide == SharedTpSlSide.StopLoss ? 0 : null,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<bool>(result);

            // Return
            return HttpResult.Ok(result, true);
        }

        #endregion

    }
}
