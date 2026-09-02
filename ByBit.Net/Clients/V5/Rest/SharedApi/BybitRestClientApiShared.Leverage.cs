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
        #region Leverage client
        public SharedLeverageSettingMode LeverageSettingType => SharedLeverageSettingMode.PerSymbol;

        public GetLeverageOptions GetLeverageOptions { get; } = new GetLeverageOptions(_exchangeName, true);
        public async Task<HttpResult<SharedLeverage>> GetLeverageAsync(GetLeverageRequest request, CancellationToken ct)
        {
            var validationError = GetLeverageOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedLeverage>(Exchange, validationError);

            var category = (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var result = await _api.Trading.GetPositionsAsync(
                category,
                symbol: request.Symbol!.GetSymbol(FormatSymbol),
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedLeverage>(result);

            var position = result.Data.List.SingleOrDefault(x => x.PositionIdx == (request.PositionSide == null ? PositionIdx.OneWayMode : request.PositionSide == SharedPositionSide.Short ? PositionIdx.SellHedgeMode : PositionIdx.BuyHedgeMode));

            return HttpResult.Ok(result, new SharedLeverage(position?.Leverage ?? 0)
            {
                Side = request.PositionSide
            });
        }

        public SetLeverageOptions SetLeverageOptions { get; } = new SetLeverageOptions(_exchangeName);
        public async Task<HttpResult<SharedLeverage>> SetLeverageAsync(SetLeverageRequest request, CancellationToken ct)
        {
            var validationError = SetLeverageOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedLeverage>(Exchange, validationError);

            var category = (request.Symbol!.TradingMode == TradingMode.PerpetualLinear || request.Symbol!.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var result = await _api.Account.SetLeverageAsync(
                category,
                symbol: request.Symbol!.GetSymbol(FormatSymbol),
                request.Leverage,
                request.Leverage,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedLeverage>(result);

            return HttpResult.Ok(result, new SharedLeverage(request.Leverage)
            {
                Side = request.Side
            });
        }
        #endregion
    }
}
