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
        #region Book Ticker client

        public SubscribeBookTickerOptions SubscribeBookTickerOptions { get; } = new SubscribeBookTickerOptions(_exchangeName, false);
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToBookTickerUpdatesAsync(SubscribeBookTickerRequest request, Action<DataEvent<SharedBookTicker>> handler, CancellationToken ct)
        {
            var validationError = SubscribeBookTickerOptions.ValidateRequest(request, this);
            if (validationError != null)
                return WebSocketResult.Fail<UpdateSubscription>(_exchangeName, validationError);

            decimal bestAskPrice = 0, bestAskQuantity = 0, bestBidPrice = 0, bestBidQuantity = 0;
            var symbol = request.Symbol!.GetSymbol(FormatSymbol);
            var result = await _api.SubscribeToOrderbookUpdatesAsync(symbol, 1, update =>
            {
                var bestAsk = update.Data.Asks.FirstOrDefault(f => f.Quantity != 0);
                var bestBid = update.Data.Bids.FirstOrDefault(f => f.Quantity != 0);
                if (bestAsk != null)
                {
                    bestAskPrice = bestAsk.Price;
                    bestAskQuantity = bestAsk.Quantity;
                }
                if (bestBid != null)
                {
                    bestBidPrice = bestBid.Price;
                    bestBidQuantity = bestBid.Quantity;
                }

                handler(update.ToType(
                    new SharedBookTicker(
                        ExchangeSymbolCache.ParseSymbol(_topicId, _api.EnvironmentName, null, symbol), 
                        symbol, 
                        bestAskPrice,
                        new SharedOrderQuantity(bestAskQuantity),
                        bestBidPrice, 
                        new SharedOrderQuantity(bestBidQuantity))));
            }, ct).ConfigureAwait(false);

            return result;
        }
        #endregion
    }
}
