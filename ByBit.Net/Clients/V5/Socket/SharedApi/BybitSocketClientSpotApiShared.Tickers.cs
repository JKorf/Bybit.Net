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
    internal partial class BybitSocketClientSpotSharedApi
    {
        #region Ticker client
        async Task<WebSocketResult<UpdateSubscription>> ISubscribeTickerSocket.SubscribeToTickerUpdatesAsync(SubscribeTickerRequest request, Action<DataEvent<SharedTicker>> handler, CancellationToken ct)
            => await SubscribeToTickerUpdatesAsync(request, x => handler(x.ToType<SharedTicker>(x.Data)), ct).ConfigureAwait(false);

        public SubscribeTickerOptions SubscribeTickerOptions { get; } = new SubscribeTickerOptions(_exchangeName)
        {
            SupportsMultipleSymbols = true,
            MaxSymbolCount = 10
        };
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(SubscribeTickerRequest request, Action<DataEvent<SharedSpotTicker>> handler, CancellationToken ct)
        {
            var validationError = SubscribeTickerOptions.ValidateRequest(request, this);
            if (validationError != null)
                return WebSocketResult.Fail<UpdateSubscription>(_exchangeName, validationError);

            var symbols = request.Symbols?.Length > 0 ? request.Symbols.Select(x => x.GetSymbol(FormatSymbol)) : [request.Symbol!.GetSymbol(FormatSymbol)];
            var result = await _api.SubscribeToTickerUpdatesAsync(symbols, update =>
            {
                handler(update.ToType(
                    new SharedSpotTicker(
                        ExchangeSymbolCache.ParseSymbol(_topicId, _api.EnvironmentName, null, update.Data.Symbol),
                        update.Data.Symbol, 
                        update.Data.LastPrice, 
                        update.Data.HighPrice24h,
                        update.Data.LowPrice24h,
                        new SharedOrderQuantity(update.Data.Volume24h, update.Data.Turnover24h),
                        update.Data.PricePercentage24h * 100)
                {
                }));
            }, ct).ConfigureAwait(false);

            return result;
        }
        #endregion
    }
}
