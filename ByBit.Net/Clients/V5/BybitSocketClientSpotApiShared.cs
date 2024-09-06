using Bybit.Net.Interfaces.Clients.V5;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis.Interfaces.Socket;
using CryptoExchange.Net.SharedApis.Models;
using CryptoExchange.Net.SharedApis.Models.Socket;
using CryptoExchange.Net.SharedApis.RequestModels;
using CryptoExchange.Net.SharedApis.ResponseModels;
using CryptoExchange.Net.SharedApis.SubscribeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.V5
{
    internal partial class BybitSocketClientSpotApi : IBybitSocketClientSpotApiShared
    {
        public string Exchange => BybitExchange.ExchangeName;
        public ApiType[] SupportedApiTypes { get; } = new[] { ApiType.Spot };

        async Task<ExchangeResult<UpdateSubscription>> ITickerSocketClient.SubscribeToSpotTickerUpdatesAsync(SubscribeTickerRequest request, Action<DataEvent<SharedSpotTicker>> handler, CancellationToken ct)
        {
            var symbol = FormatSymbol(request.BaseAsset, request.QuoteAsset, request.ApiType);
            var result = await SubscribeToTickerUpdatesAsync(symbol, update => handler(update.As(new SharedSpotTicker(update.Data.Symbol, update.Data.HighPrice24h, update.Data.LastPrice, update.Data.LowPrice24h, update.Data.Volume24h))), ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }

        async Task<ExchangeResult<UpdateSubscription>> ITradeSocketClient.SubscribeToTradeUpdatesAsync(SubscribeTradeRequest request, Action<DataEvent<IEnumerable<SharedTrade>>> handler, CancellationToken ct)
        {
            var symbol = FormatSymbol(request.BaseAsset, request.QuoteAsset, request.ApiType);
            var result = await SubscribeToTradeUpdatesAsync(symbol, update => handler(update.As(update.Data.Select(x => new SharedTrade(x.Quantity, x.Price, x.Timestamp)))), ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }

        async Task<ExchangeResult<UpdateSubscription>> IBookTickerSocketClient.SubscribeToBookTickerUpdatesAsync(SubscribeBookTickerRequest request, Action<DataEvent<SharedBookTicker>> handler, CancellationToken ct)
        {
            decimal bestAskPrice = 0, bestAskQuantity = 0, bestBidPrice = 0, bestBidQuantity = 0;
            var symbol = FormatSymbol(request.BaseAsset, request.QuoteAsset, request.ApiType);
            var result = await SubscribeToOrderbookUpdatesAsync(symbol, 1, update => 
            {
                var bestAsk = update.Data.Asks.FirstOrDefault(f => f.Quantity != 0);
                var bestBid = update.Data.Bids.FirstOrDefault(f => f.Quantity != 0);
                if (update.Data.Asks.Any())
                {
                    bestAskPrice = bestAsk.Price;
                    bestAskQuantity = bestAsk.Quantity;
                }
                if (update.Data.Bids.Any())
                {
                    bestBidPrice = bestBid.Price;
                    bestBidQuantity = bestBid.Quantity;
                }

                handler(update.As(new SharedBookTicker(bestAskPrice, bestAskQuantity, bestBidPrice, bestBidQuantity)));
            }, ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }

    }
}
