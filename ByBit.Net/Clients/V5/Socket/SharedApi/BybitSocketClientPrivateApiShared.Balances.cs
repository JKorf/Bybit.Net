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
        #region Subscribe Balances
        public SubscribeBalanceOptions SubscribeBalanceOptions { get; } = new SubscribeBalanceOptions(_exchangeName, false);
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(SubscribeBalancesRequest request, Action<DataEvent<SharedBalance[]>> handler, CancellationToken ct)
        {
            var validationError = SubscribeBalanceOptions.ValidateRequest(request, this);
            if (validationError != null)
                return WebSocketResult.Fail<UpdateSubscription>(_exchangeName, validationError);

            var result = await _api.SubscribeToWalletUpdatesAsync(
                update => handler(update.ToType<SharedBalance[]>(update.Data.SelectMany(x => x.Assets.Select(x => 
                    new SharedBalance(
                        SupportedTradingModes, 
                        x.Asset, 
                        (x.WalletBalance ?? 0) - (x.Locked ?? 0),
                        x.WalletBalance ?? 0))).ToArray())),
                ct: ct).ConfigureAwait(false);

            return result;
        }
        #endregion
    }
}
