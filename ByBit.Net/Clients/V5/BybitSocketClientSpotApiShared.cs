﻿using Binance.Net.Interfaces.Clients.SpotApi;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis.Interfaces.Socket;
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

        async Task<CallResult<UpdateSubscription>> ITickerSocketClient.SubscribeToTickerUpdatesAsync(TickerSubscribeRequest request, Action<DataEvent<SharedTicker>> handler, CancellationToken ct)
        {
            var symbol = FormatSymbol(request.BaseAsset, request.QuoteAsset, request.ApiType);
            var result = await SubscribeToTickerUpdatesAsync(symbol, update => handler(update.As(new SharedTicker(update.Data.Symbol, update.Data.HighPrice24h, update.Data.LastPrice, update.Data.LowPrice24h))), ct).ConfigureAwait(false);

            return result;
        }

        async Task<CallResult<UpdateSubscription>> ITradeSocketClient.SubscribeToTradeUpdatesAsync(TradeSubscribeRequest request, Action<DataEvent<IEnumerable<SharedTrade>>> handler, CancellationToken ct)
        {
            var symbol = FormatSymbol(request.BaseAsset, request.QuoteAsset, request.ApiType);
            var result = await SubscribeToTradeUpdatesAsync(symbol, update => handler(update.As(update.Data.Select(x => new SharedTrade(x.Quantity, x.Price, x.Timestamp)))), ct).ConfigureAwait(false);

            return result;
        }

        async Task<CallResult<UpdateSubscription>> IBookTickerSocketClient.SubscribeToBookTickerUpdatesAsync(BookTickerSubscribeRequest request, Action<DataEvent<SharedBookTicker>> handler, CancellationToken ct)
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

            return result;
        }

    }
}
