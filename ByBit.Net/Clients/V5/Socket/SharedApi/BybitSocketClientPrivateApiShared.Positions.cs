using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.V5;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.V5
{
    internal partial class BybitSocketClientPrivateSharedApi
    {
        #region Position client
        public SubscribePositionOptions SubscribePositionOptions { get; } = new SubscribePositionOptions(_exchangeName, true);
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(SubscribePositionRequest request, Action<DataEvent<SharedPosition[]>> handler, CancellationToken ct)
        {
            var validationError = SubscribePositionOptions.ValidateRequest(request, this);
            if (validationError != null)
                return WebSocketResult.Fail<UpdateSubscription>(_exchangeName, validationError);

            var result = await _api.SubscribeToPositionUpdatesAsync(
                update => handler(update.ToType(update.Data.Select(x =>
                    new SharedPosition(
                        ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, x.Symbol),
                        x.Symbol,
                        new SharedOrderQuantity(x.Quantity), 
                        x.UpdateTime)
                    {
                        AverageOpenPrice = x.AveragePrice,
                        PositionMode = x.PositionIdx == PositionIdx.OneWayMode ? SharedPositionMode.OneWay : SharedPositionMode.HedgeMode,
                        PositionSide = x.PositionIdx == Enums.PositionIdx.OneWayMode ? (x.Side == Enums.PositionSide.Sell ? SharedPositionSide.Short : SharedPositionSide.Long) : x.PositionIdx == Enums.PositionIdx.BuyHedgeMode ? SharedPositionSide.Long : SharedPositionSide.Short,
                        LiquidationPrice = x.LiquidationPrice,
                        Leverage = x.Leverage,
                        UnrealizedPnl = x.UnrealizedPnl,
                        StopLossPrice = x.StopLoss,
                        TakeProfitPrice = x.TakeProfit
                    }).ToArray())),
                ct: ct).ConfigureAwait(false);

            return result;
        }

        #endregion
    }
}
