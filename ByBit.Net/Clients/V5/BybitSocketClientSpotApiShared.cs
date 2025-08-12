using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.V5;
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
    internal partial class BybitSocketClientSpotApi : IBybitSocketClientSpotApiShared
    {
        private const string _topicId = "BybitSpot";

        public string Exchange => BybitExchange.ExchangeName;
        public TradingMode[] SupportedTradingModes { get; } = new[] { TradingMode.Spot };

        public void SetDefaultExchangeParameter(string key, object value) => ExchangeParameters.SetStaticParameter(Exchange, key, value);
        public void ResetDefaultExchangeParameters() => ExchangeParameters.ResetStaticParameters();

        #region Ticker client
        EndpointOptions<SubscribeTickerRequest> ITickerSocketClient.SubscribeTickerOptions { get; } = new EndpointOptions<SubscribeTickerRequest>(false)
        {
            SupportsMultipleSymbols = true,
            MaxSymbolCount = 10
        };
        async Task<ExchangeResult<UpdateSubscription>> ITickerSocketClient.SubscribeToTickerUpdatesAsync(SubscribeTickerRequest request, Action<ExchangeEvent<SharedSpotTicker>> handler, CancellationToken ct)
        {
            var validationError = ((ITickerSocketClient)this).SubscribeTickerOptions.ValidateRequest(Exchange, request, request.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeResult<UpdateSubscription>(Exchange, validationError);

            var symbols = request.Symbols?.Length > 0 ? request.Symbols.Select(x => x.GetSymbol(FormatSymbol)) : [request.Symbol!.GetSymbol(FormatSymbol)];
            var result = await SubscribeToTickerUpdatesAsync(symbols, update =>
            {
                handler(update.AsExchangeEvent(Exchange, new SharedSpotTicker(ExchangeSymbolCache.ParseSymbol(_topicId, update.Data.Symbol), update.Data.Symbol, update.Data.LastPrice, update.Data.HighPrice24h, update.Data.LowPrice24h, update.Data.Volume24h, update.Data.PricePercentage24h * 100)
                {
                    QuoteVolume = update.Data.Turnover24h
                }));
            }, ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }
        #endregion

        #region Trade client

        EndpointOptions<SubscribeTradeRequest> ITradeSocketClient.SubscribeTradeOptions { get; } = new EndpointOptions<SubscribeTradeRequest>(false)
        {
            MaxSymbolCount = 10,
            SupportsMultipleSymbols = true
        };
        async Task<ExchangeResult<UpdateSubscription>> ITradeSocketClient.SubscribeToTradeUpdatesAsync(SubscribeTradeRequest request, Action<ExchangeEvent<SharedTrade[]>> handler, CancellationToken ct)
        {
            var validationError = ((ITradeSocketClient)this).SubscribeTradeOptions.ValidateRequest(Exchange, request, request.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeResult<UpdateSubscription>(Exchange, validationError);

            var symbols = request.Symbols?.Length > 0 ? request.Symbols.Select(x => x.GetSymbol(FormatSymbol)) : [request.Symbol!.GetSymbol(FormatSymbol)];
            var result = await SubscribeToTradeUpdatesAsync(symbols, update => handler(update.AsExchangeEvent(Exchange, update.Data.Select(x => new SharedTrade(x.Quantity, x.Price, x.Timestamp)
            {
                Side = x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell
            }).ToArray())), ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }
        #endregion

        #region Book Ticker client

        EndpointOptions<SubscribeBookTickerRequest> IBookTickerSocketClient.SubscribeBookTickerOptions { get; } = new EndpointOptions<SubscribeBookTickerRequest>(false);
        async Task<ExchangeResult<UpdateSubscription>> IBookTickerSocketClient.SubscribeToBookTickerUpdatesAsync(SubscribeBookTickerRequest request, Action<ExchangeEvent<SharedBookTicker>> handler, CancellationToken ct)
        {
            var validationError = ((IBookTickerSocketClient)this).SubscribeBookTickerOptions.ValidateRequest(Exchange, request, request.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeResult<UpdateSubscription>(Exchange, validationError);

            decimal bestAskPrice = 0, bestAskQuantity = 0, bestBidPrice = 0, bestBidQuantity = 0;
            var symbol = request.Symbol!.GetSymbol(FormatSymbol);
            var result = await SubscribeToOrderbookUpdatesAsync(symbol, 1, update =>
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

                handler(update.AsExchangeEvent(Exchange, new SharedBookTicker(ExchangeSymbolCache.ParseSymbol(_topicId, symbol), symbol, bestAskPrice, bestAskQuantity, bestBidPrice, bestBidQuantity)));
            }, ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }
        #endregion

        #region Kline client
        SubscribeKlineOptions IKlineSocketClient.SubscribeKlineOptions { get; } = new SubscribeKlineOptions(false,
            SharedKlineInterval.OneMinute,
            SharedKlineInterval.ThreeMinutes,
            SharedKlineInterval.FiveMinutes,
            SharedKlineInterval.FifteenMinutes,
            SharedKlineInterval.ThirtyMinutes,
            SharedKlineInterval.OneHour,
            SharedKlineInterval.TwoHours,
            SharedKlineInterval.FourHours,
            SharedKlineInterval.SixHours,
            SharedKlineInterval.TwelveHours,
            SharedKlineInterval.OneDay,
            SharedKlineInterval.OneWeek,
            SharedKlineInterval.OneMonth)
        {
            SupportsMultipleSymbols = true,
            MaxSymbolCount = 10
        };
        async Task<ExchangeResult<UpdateSubscription>> IKlineSocketClient.SubscribeToKlineUpdatesAsync(SubscribeKlineRequest request, Action<ExchangeEvent<SharedKline>> handler, CancellationToken ct)
        {
            var interval = (KlineInterval)request.Interval;
            if (!Enum.IsDefined(typeof(KlineInterval), interval))
                return new ExchangeResult<UpdateSubscription>(Exchange, ArgumentError.Invalid(nameof(GetKlinesRequest.Interval), "Interval not supported"));

            var validationError = ((IKlineSocketClient)this).SubscribeKlineOptions.ValidateRequest(Exchange, request, request.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeResult<UpdateSubscription>(Exchange, validationError);

            var symbols = request.Symbols?.Length > 0 ? request.Symbols.Select(x => x.GetSymbol(FormatSymbol)) : [request.Symbol!.GetSymbol(FormatSymbol)];
            var result = await SubscribeToKlineUpdatesAsync(symbols, interval, update =>
            {
                foreach(var item in update.Data)
                    handler(update.AsExchangeEvent(Exchange, new SharedKline(item.StartTime, item.ClosePrice, item.HighPrice, item.LowPrice, item.OpenPrice, item.Volume)));
            }, ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }
        #endregion
    }
}
