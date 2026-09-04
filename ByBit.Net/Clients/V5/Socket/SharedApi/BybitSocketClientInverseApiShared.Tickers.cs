using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.V5;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.V5
{
    internal partial class BybitSocketClientInverseSharedApi
    {
        #region Subscribe Ticker
        async Task<WebSocketResult<UpdateSubscription>> ISubscribeTickerSocket.SubscribeToTickerUpdatesAsync(SubscribeTickerRequest request, Action<DataEvent<SharedTicker>> handler, CancellationToken ct)
            => await SubscribeToTickerUpdatesAsync(request, x => handler(x.ToType<SharedTicker>(x.Data)), ct).ConfigureAwait(false);

        public SubscribeTickerOptions SubscribeTickerOptions { get; } = new SubscribeTickerOptions(_exchangeName);
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(SubscribeTickerRequest request, Action<DataEvent<SharedSpotTicker>> handler, CancellationToken ct)
        {
            var validationError = SubscribeTickerOptions.ValidateRequest(request, this);
            if (validationError != null)
                return WebSocketResult.Fail<UpdateSubscription>(_exchangeName, validationError);

            var symbol = request.Symbol!.GetSymbol(FormatSymbol);

            decimal lastPrice = 0, high = 0, low = 0, vol = 0, change = 0, quoteVol = 0;
            var result = await _api.SubscribeToTickerUpdatesAsync(symbol, update =>
            {
                if (update.Data.LastPrice.HasValue)
                    lastPrice = update.Data.LastPrice.Value;
                if (update.Data.HighPrice24h.HasValue)
                    high = update.Data.HighPrice24h.Value;
                if (update.Data.LowPrice24h.HasValue)
                    low = update.Data.LowPrice24h.Value;
                if (update.Data.Volume24h.HasValue)
                    vol = update.Data.Volume24h.Value;
                if (update.Data.PricePercentage24h.HasValue)
                    vol = update.Data.PricePercentage24h.Value;
                if (update.Data.Turnover24h.HasValue)
                    quoteVol = update.Data.Turnover24h.Value;

                handler(update.ToType(
                    new SharedSpotTicker(
                        ExchangeSymbolCache.ParseSymbol(_topicId, _api.EnvironmentName, null, update.Data.Symbol),
                        update.Data.Symbol,
                        lastPrice,
                        high, 
                        low,
                        new SharedOrderQuantity(vol, quoteVol),
                        change)
                {
                }));
            }, ct).ConfigureAwait(false);

            return result;
        }
        #endregion
    }
}
