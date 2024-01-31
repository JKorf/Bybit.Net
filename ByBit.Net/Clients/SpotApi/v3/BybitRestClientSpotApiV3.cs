using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.SpotApi.v3;
using Bybit.Net.Objects.Options;
using CryptoExchange.Net.CommonObjects;
using CryptoExchange.Net.Interfaces.CommonClients;
using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;

namespace Bybit.Net.Clients.SpotApi.v3
{
    /// <inheritdoc cref="IBybitRestClientSpotApiV3" />
    public class BybitRestClientSpotApiV3 : BybitRestClientBaseSpotApi, IBybitRestClientSpotApiV3
    {
        /// <inheritdoc />
        public IBybitRestClientSpotApiAccountV3 Account { get; }
        /// <inheritdoc />
        public IBybitRestClientSpotApiExchangeDataV3 ExchangeData { get; }
        /// <inheritdoc />
        public IBybitRestClientSpotApiTradingV3 Trading { get; }

        #region ctor
        internal BybitRestClientSpotApiV3(ILogger logger, HttpClient? httpClient, BybitRestOptions options)
            : base(logger, httpClient, options.Environment.RestBaseAddress, options, options.SpotOptions)
        {
            if (!string.IsNullOrEmpty(options.Referer))
            {
                StandardRequestHeaders = new Dictionary<string, string>
                {
                    { "x-referer", options.Referer! }
                };
            }

            Account = new BybitRestClientSpotApiAccountV3(this);
            ExchangeData = new BybitRestClientSpotApiExchangeDataV3(this);
            Trading = new BybitRestClientSpotApiTradingV3(this);
        }
        #endregion

        #region Common interface

        /// <inheritdoc />
        public override async Task<WebCallResult<IEnumerable<Symbol>>> GetSymbolsAsync(CancellationToken ct)
        {
            var result = await ExchangeData.GetSymbolsAsync(ct: ct).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<Symbol>>(null);

              return result.As(result.Data.Select(r => new Symbol
              {
                  SourceObject = r,
                  Name = r.Name,
                  MinTradeQuantity = r.MinOrderQuantity,
                  PriceStep = r.PricePrecision,
                  QuantityStep = r.BasePrecision
              }));
        }

        /// <inheritdoc />
        public override async Task<WebCallResult<IEnumerable<Ticker>>> GetTickersAsync(CancellationToken ct)
        {
            var result = await ExchangeData.GetTickersAsync(ct: ct).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<Ticker>>(null);

            return result.As(result.Data.Select(r => new Ticker
            {
                SourceObject = r,
                Symbol = r.Symbol,
                HighPrice = r.HighPrice,
                LastPrice = r.LastPrice,
                LowPrice = r.LowPrice,
                Price24H = r.OpenPrice,
                Volume = r.Volume
            }));
        }

        /// <inheritdoc />
        public override async Task<WebCallResult<Ticker>> GetTickerAsync(string symbol, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentException(nameof(symbol) + " required for Bybit " + nameof(ISpotClient.GetTickerAsync), nameof(symbol));

            var result = await ExchangeData.GetTickerAsync(symbol, ct: ct).ConfigureAwait(false);
            if (!result)
                return result.As<Ticker>(null);

            return result.As(new Ticker
            {
                SourceObject = result.Data,
                Symbol = result.Data.Symbol,
                HighPrice = result.Data.HighPrice,
                LastPrice = result.Data.LastPrice,
                LowPrice = result.Data.LowPrice,
                Price24H = result.Data.OpenPrice,
                Volume = result.Data.Volume
            });
        }

        /// <inheritdoc />
        public override async Task<WebCallResult<IEnumerable<Kline>>> GetKlinesAsync(string symbol, TimeSpan timespan, DateTime? startTime, DateTime? endTime, int? limit, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentException(nameof(symbol) + " required for Bybit " + nameof(ISpotClient.GetKlinesAsync), nameof(symbol));

            var result = await ExchangeData.GetKlinesAsync(symbol, TimeSpanToInterval(timespan), startTime, endTime, limit, ct: ct).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<Kline>>(null);

            return result.As(result.Data.Select(r => new Kline
            {
                SourceObject = r,
                HighPrice = r.HighPrice,
                LowPrice = r.LowPrice,
                Volume = r.Volume,
                ClosePrice = r.ClosePrice,
                OpenPrice = r.OpenPrice,
                OpenTime = r.OpenTime
            }));
        }

        /// <inheritdoc />
        public override async Task<WebCallResult<OrderBook>> GetOrderBookAsync(string symbol, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentException(nameof(symbol) + " required for Bybit " + nameof(ISpotClient.GetOrderBookAsync), nameof(symbol));

            var result = await ExchangeData.GetOrderBookAsync(symbol, ct: ct).ConfigureAwait(false);
            if (!result)
                return result.As<OrderBook>(null);

            return result.As(new OrderBook
            {
                SourceObject = result.Data,
                Asks = result.Data.Asks.Select(a => new OrderBookEntry { Price = a.Price, Quantity = a.Quantity }),
                Bids = result.Data.Bids.Select(b => new OrderBookEntry { Price = b.Price, Quantity = b.Quantity })
            });
        }

        /// <inheritdoc />
        public override async Task<WebCallResult<IEnumerable<Trade>>> GetRecentTradesAsync(string symbol, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentException(nameof(symbol) + " required for Bybit " + nameof(ISpotClient.GetRecentTradesAsync), nameof(symbol));

            var result = await ExchangeData.GetTradeHistoryAsync(symbol).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<Trade>>(null);

            return result.As(result.Data.Select(r => new Trade
            {
                SourceObject = r,
                Price = r.Price,
                Quantity = r.Quantity,
                Symbol = symbol,
                Timestamp = r.TradeTime
            }));
        }

        /// <inheritdoc />
        public override async Task<WebCallResult<OrderId>> PlaceOrderAsync(string symbol, CommonOrderSide side, CommonOrderType type, decimal quantity, decimal? price, string? accountId, string? clientOrderId, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentException(nameof(symbol) + " required for Bybit " + nameof(ISpotClient.PlaceOrderAsync), nameof(symbol));

            var result = await Trading.PlaceOrderAsync(
                symbol,
                side == CommonOrderSide.Buy ? OrderSide.Buy : OrderSide.Sell,
                type == CommonOrderType.Limit ? OrderType.Limit : OrderType.Market,
                quantity,
                price,
                type == CommonOrderType.Limit ? TimeInForce.GoodTillCanceled : (TimeInForce?)null,
                clientOrderId: clientOrderId,
                ct: ct).ConfigureAwait(false);
            if (!result)
                return result.As<OrderId>(null);

            return result.As(new OrderId
            {
                SourceObject = result.Data,
                Id = result.Data.Id.ToString(CultureInfo.InvariantCulture)
            });
        }

        /// <inheritdoc />
        public override async Task<WebCallResult<Order>> GetOrderAsync(string orderId, string? symbol, CancellationToken ct)
        {
            if (!long.TryParse(orderId, out var id))
                throw new ArgumentException($"Invalid order id for Bybit {nameof(ISpotClient.GetOrderAsync)}", nameof(orderId));

            var result = await Trading.GetOrderAsync(id, ct: ct).ConfigureAwait(false);
            if (!result)
                return result.As<Order>(null);

            return result.As(new Order
            {
                SourceObject = result.Data,
                Id = result.Data.Id.ToString(CultureInfo.InvariantCulture),
                Price = result.Data.Price,
                Quantity = result.Data.Quantity,
                QuantityFilled = result.Data.QuantityFilled,
                Timestamp = result.Data.CreateTime,
                Symbol = result.Data.Symbol,
                Side = result.Data.Side == OrderSide.Buy ? CommonOrderSide.Buy : CommonOrderSide.Sell,
                Type = result.Data.Type == OrderType.Limit ? CommonOrderType.Limit : result.Data.Type == OrderType.Market ? CommonOrderType.Market : CommonOrderType.Other,
                Status = result.Data.Status == OrderStatus.Canceled ? CommonOrderStatus.Canceled : result.Data.Status == OrderStatus.Filled ? CommonOrderStatus.Filled : CommonOrderStatus.Active
            });
        }

        /// <inheritdoc />
        public override async Task<WebCallResult<IEnumerable<UserTrade>>> GetOrderTradesAsync(string orderId, string? symbol, CancellationToken ct)
        {
            if (!long.TryParse(orderId, out var id))
                throw new ArgumentException($"Invalid order id for Bybit {nameof(ISpotClient.GetOrderAsync)}", nameof(orderId));

            var result = await Trading.GetUserTradesAsync(fromId: id, toId: long.Parse(orderId), ct: ct).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<UserTrade>>(null);

            return result.As(result.Data.Select(r => new UserTrade
            {
                SourceObject = r,
                Id = r.Id.ToString(CultureInfo.InvariantCulture),
                OrderId = r.OrderId.ToString(CultureInfo.InvariantCulture),
                Symbol = r.Symbol,
                Fee = r.Fee,
                FeeAsset = r.FeeAsset,
                Price = r.Price,
                Quantity = r.Quantity,
                Timestamp = r.TradeTime
            }));
        }

        /// <inheritdoc />
        public override async Task<WebCallResult<IEnumerable<Order>>> GetOpenOrdersAsync(string? symbol, CancellationToken ct)
        {
            var result = await Trading.GetOpenOrdersAsync(symbol, ct: ct).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<Order>>(null);

            return result.As(result.Data.Select(r => new Order
            {
                SourceObject = r,
                Id = r.Id.ToString(CultureInfo.InvariantCulture),
                Price = r.Price,
                Quantity = r.Quantity,
                QuantityFilled = r.QuantityFilled,
                Timestamp = r.CreateTime,
                Symbol = r.Symbol,
                Side = r.Side == OrderSide.Buy ? CommonOrderSide.Buy : CommonOrderSide.Sell,
                Type = r.Type == OrderType.Limit ? CommonOrderType.Limit : r.Type == OrderType.Market ? CommonOrderType.Market : CommonOrderType.Other,
                Status = r.Status == OrderStatus.Canceled ? CommonOrderStatus.Canceled : r.Status == OrderStatus.Filled ? CommonOrderStatus.Filled : CommonOrderStatus.Active
            }));
        }

        /// <inheritdoc />
        public override async Task<WebCallResult<IEnumerable<Order>>> GetClosedOrdersAsync(string? symbol, CancellationToken ct)
        {
            var result = await Trading.GetOrdersAsync(symbol, ct: ct).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<Order>>(null);

            return result.As(result.Data.Select(r => new Order
            {
                SourceObject = r,
                Id = r.Id.ToString(CultureInfo.InvariantCulture),
                Price = r.Price,
                Quantity = r.Quantity,
                QuantityFilled = r.QuantityFilled,
                Timestamp = r.CreateTime,
                Symbol = r.Symbol,
                Side = r.Side == OrderSide.Buy ? CommonOrderSide.Buy : CommonOrderSide.Sell,
                Type = r.Type == OrderType.Limit ? CommonOrderType.Limit : r.Type == OrderType.Market ? CommonOrderType.Market : CommonOrderType.Other,
                Status = r.Status == OrderStatus.Canceled ? CommonOrderStatus.Canceled : r.Status == OrderStatus.Filled ? CommonOrderStatus.Filled : CommonOrderStatus.Active
            }));
        }

        /// <inheritdoc />
        public override async Task<WebCallResult<OrderId>> CancelOrderAsync(string orderId, string? symbol, CancellationToken ct)
        {
            if (!long.TryParse(orderId, out var id))
                throw new ArgumentException($"Invalid order id for Bybit {nameof(ISpotClient.GetOrderAsync)}", nameof(orderId));

            var result = await Trading.CancelOrderAsync(id, ct: ct).ConfigureAwait(false);
            if (!result)
                return result.As<OrderId>(null);

            return result.As(new OrderId { SourceObject = result.Data, Id = result.Data.Id.ToString(CultureInfo.InvariantCulture) });
        }

        /// <inheritdoc />
        public override async Task<WebCallResult<IEnumerable<Balance>>> GetBalancesAsync(string? accountId, CancellationToken ct)
        {
            var result = await Account.GetBalancesAsync(ct: ct).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<Balance>>(null);

            return result.As(result.Data.Select(r => new Balance
            {
                SourceObject = r,
                Asset = r.Asset,
                Available = r.Available,
                Total = r.Total
            }));
        }

        #endregion

        /// <inheritdoc />
        protected override Task<WebCallResult<DateTime>> GetServerTimestampAsync()
            => ExchangeData.GetServerTimeAsync();

    }
}
