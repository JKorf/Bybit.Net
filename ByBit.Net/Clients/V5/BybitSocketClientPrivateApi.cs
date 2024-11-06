using Bybit.Net.Interfaces.Clients.V5;
using Bybit.Net.Enums;
using Bybit.Net.Enums.V5;
using Bybit.Net.Objects.Models.V5;
using Bybit.Net.Objects.Options;
using Bybit.Net.Objects.Sockets.Queries;
using Bybit.Net.Objects.Sockets.Subscriptions;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.MessageParsing;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Net.SharedApis;

namespace Bybit.Net.Clients.V5
{
    /// <inheritdoc cref="IBybitSocketClientPrivateApi" />
    internal partial class BybitSocketClientPrivateApi : SocketApiClient, IBybitSocketClientPrivateApi
    {
        private static readonly MessagePath _reqIdPath = MessagePath.Get().Property("req_id");
        private static readonly MessagePath _reqId2Path = MessagePath.Get().Property("reqId");
        private static readonly MessagePath _topicPath = MessagePath.Get().Property("topic");
        private static readonly MessagePath _opPath = MessagePath.Get().Property("op");
        private string _referer;

        internal BybitSocketClientPrivateApi(ILogger logger, BybitSocketOptions options)
            : base(logger, options.Environment.SocketBaseAddress, options, options.V5Options)
        {
            UnhandledMessageExpected = true;
            KeepAliveInterval = TimeSpan.Zero;

            _referer = !string.IsNullOrEmpty(options.Referer) ? options.Referer! : "Zx000356";

            RegisterPeriodicQuery("Heartbeat", options.V5Options.PingInterval, GetPingQuery, x => { });

            SetDedicatedConnection(BaseAddress.AppendPath("/v5/trade"), true);
        }

        private Query GetPingQuery(SocketConnection connection)
        {
            if (connection.ConnectionUri.AbsolutePath.EndsWith("private"))
            {
                return new BybitQuery("ping", null);
            }
            else
            {
                return new BybitPingQuery();
            }
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials) => new BybitAuthenticationProvider(credentials);

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
        {
            if (tradingMode == TradingMode.Spot)
                return baseAsset.ToUpperInvariant() + quoteAsset.ToUpperInvariant();

            if (tradingMode.IsLinear())
            {
                if (tradingMode.IsPerpetual())
                    return baseAsset.ToUpperInvariant() + quoteAsset.ToUpperInvariant();

                return baseAsset.ToUpperInvariant() + "-" + deliverTime!.Value.ToString("ddMMMyy").ToUpperInvariant();
            }

            return baseAsset.ToUpperInvariant() + quoteAsset.ToUpperInvariant() + (deliverTime == null ? string.Empty : (ExchangeHelpers.GetDeliveryMonthSymbol(deliverTime.Value) + deliverTime.Value.ToString("yy")));
        }

        public IBybitSocketClientPrivateApiShared SharedClient => this;

        /// <inheritdoc />
        protected override Task<Query?> GetAuthenticationRequestAsync(SocketConnection connection)
        {
            if (connection.ConnectionUri.AbsolutePath.EndsWith("private"))
            {
                // Auth subscription
                var expireTime = DateTimeConverter.ConvertToMilliseconds(DateTime.UtcNow.AddSeconds(30))!;
                var authProvider = (BybitAuthenticationProvider)AuthenticationProvider!;
                var key = authProvider.ApiKey;
                var sign = authProvider.Sign($"GET/realtime{expireTime}");

                return Task.FromResult<Query?>(new BybitQuery("auth", new object[]
                {
                key,
                expireTime,
                sign
                }));
            }
            else
            {
                // Trading
                var expireTime = DateTimeConverter.ConvertToMilliseconds(DateTime.UtcNow.AddSeconds(30))!;
                var authProvider = (BybitAuthenticationProvider)AuthenticationProvider!;
                var key = authProvider.ApiKey;
                var sign = authProvider.Sign($"GET/realtime{expireTime}");

                return Task.FromResult<Query?>(new BybitRequestQuery<object>("auth", null, new object[]
                {
                key,
                expireTime,
                sign
                }));
            }
        }

        /// <inheritdoc />
        public override string? GetListenerIdentifier(IMessageAccessor message)
        {
            var reqId = message.GetValue<string>(_reqIdPath);
            if (reqId != null)
                return reqId;

            var reqId2 = message.GetValue<string>(_reqId2Path);
            if (reqId2 != null)
                return reqId2;

            var op = message.GetValue<string>(_opPath);
            if (string.Equals(op, "pong"))
                return op;

            return message.GetValue<string>(_topicPath);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(Action<DataEvent<IEnumerable<BybitPositionUpdate>>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<IEnumerable<BybitPositionUpdate>>(_logger, new[] { "position" }, handler, true);
            return await SubscribeAsync(BaseAddress.AppendPath("/v5/private"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(Action<DataEvent<IEnumerable<BybitUserTradeUpdate>>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<IEnumerable<BybitUserTradeUpdate>>(_logger, new[] { "execution" }, handler, true);
            return await SubscribeAsync(BaseAddress.AppendPath("/v5/private"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToMinimalUserTradeUpdatesAsync(Action<DataEvent<IEnumerable<BybitMinimalUserTradeUpdate>>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<IEnumerable<BybitMinimalUserTradeUpdate>>(_logger, new[] { "execution.fast" }, handler, true);
            return await SubscribeAsync(BaseAddress.AppendPath("/v5/private"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<IEnumerable<BybitOrderUpdate>>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<IEnumerable<BybitOrderUpdate>>(_logger, new[] { "order" }, handler, true);
            return await SubscribeAsync(BaseAddress.AppendPath("/v5/private"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToWalletUpdatesAsync(Action<DataEvent<IEnumerable<BybitBalance>>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<IEnumerable<BybitBalance>>(_logger, new[] { "wallet" }, handler, true);
            return await SubscribeAsync(BaseAddress.AppendPath("/v5/private"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToGreekUpdatesAsync(Action<DataEvent<IEnumerable<BybitGreeks>>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<IEnumerable<BybitGreeks>>(_logger, new[] { "greeks" }, handler, true);
            return await SubscribeAsync(BaseAddress.AppendPath("/v5/private"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<BybitOrderId>> PlaceOrderAsync(Category category,
            string symbol,
            OrderSide side,
            NewOrderType type,
            decimal quantity,
            decimal? price = null,
            bool? isLeverage = null,
            TriggerDirection? triggerDirection = null,
            OrderFilter? orderFilter = null,
            decimal? triggerPrice = null,
            TriggerType? triggerBy = null,
            decimal? orderIv = null,
            TimeInForce? timeInForce = null,
            PositionIdx? positionIdx = null,
            string? clientOrderId = null,
            OrderType? takeProfitOrderType = null,
            decimal? takeProfit = null,
            decimal? takeProfitLimitPrice = null,
            OrderType? stopLossOrderType = null,
            decimal? stopLoss = null,
            decimal? stopLossLimitPrice = null,
            TriggerType? takeProfitTriggerBy = null,
            TriggerType? stopLossTriggerBy = null,
            bool? reduceOnly = null,
            bool? closeOnTrigger = null,
            bool? marketMakerProtection = null,
            StopLossTakeProfitMode? stopLossTakeProfitMode = null,
            SelfMatchPreventionType? selfMatchPreventionType = null,
            MarketUnit? marketUnit = null,
            CancellationToken ct = default)
        {
            var timestamp = DateTimeConverter.ConvertToMilliseconds(DateTime.UtcNow.AddMilliseconds(-1000)).Value.ToString(CultureInfo.InvariantCulture);
            var query = new BybitRequestQuery<BybitOrderId>(
                "order.create",
                new Dictionary<string, string>
                {
                    { "X-BAPI-TIMESTAMP", timestamp },
                    { "Referer", _referer }
                },
                new object[] { new BybitSocketPlaceOrderRequest
                {
                    Category = category,
                    ClientOrderId = clientOrderId,
                    CloseOnTrigger = closeOnTrigger,
                    MarketMakerProtection = marketMakerProtection,
                    MarketUnit = marketUnit,
                    OrderImpliedVolatility = orderIv,
                    OrderType = type,
                    PositionIdx = positionIdx,
                    Price = price,
                    Quantity = quantity,
                    ReduceOnly = reduceOnly,
                    Side = side,
                    StopLoss = stopLoss,
                    StopLossLimitPrice = stopLossLimitPrice,
                    StopLossOrderType = stopLossOrderType,
                    Symbol = symbol,
                    TakeProfit = takeProfit,
                    TakeProfitLimitPrice = takeProfitLimitPrice,
                    TakeProfitOrderType = takeProfitOrderType,
                    TakeProfitStopLossMode = stopLossTakeProfitMode,
                    TimeInForce = timeInForce,
                    TriggerBy = triggerBy,
                    TriggerDirection = triggerDirection,
                    TriggerPrice = triggerPrice,
                    StopLossTriggerBy = stopLossTriggerBy,
                    StpType = selfMatchPreventionType,
                    TakeProfitTriggerBy = takeProfitTriggerBy,
                    OrderFilter = orderFilter,
                    IsLeverage = isLeverage.HasValue ? (isLeverage == true ? 1 : 0) : null
                }
            });

            return await QueryAsync(BaseAddress.AppendPath("/v5/trade"), query, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<BybitOrderId>> EditOrderAsync(Category category,
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            decimal? quantity = null,
            decimal? price = null,
            decimal? triggerPrice = null,
            TriggerType? triggerBy = null,
            decimal? orderIv = null,
            decimal? takeProfit = null,
            decimal? stopLoss = null,
            TriggerType? takeProfitTriggerBy = null,
            TriggerType? stopLossTriggerBy = null,
            StopLossTakeProfitMode? stopLossTakeProfitMode = null,
            decimal? takeProfitLimitPrice = null,
            decimal? stopLossLimitPrice = null,
            CancellationToken ct = default)
        {
            var timestamp = DateTimeConverter.ConvertToMilliseconds(DateTime.UtcNow.AddMilliseconds(-1000)).Value.ToString(CultureInfo.InvariantCulture);
            var query = new BybitRequestQuery<BybitOrderId>(
                "order.amend",
                new Dictionary<string, string>
                {
                    { "X-BAPI-TIMESTAMP", timestamp },
                    { "Referer", _referer }
                },
                new object[] { new BybitSocketEditOrderRequest
                {
                    Category = category,
                    ClientOrderId = clientOrderId,
                    OrderImpliedVolatility = orderIv,
                    Price = price,
                    Quantity = quantity,
                    StopLoss = stopLoss,
                    StopLossLimitPrice = stopLossLimitPrice,
                    Symbol = symbol,
                    TakeProfit = takeProfit,
                    TakeProfitLimitPrice = takeProfitLimitPrice,
                    TakeProfitStopLossMode = stopLossTakeProfitMode,
                    TriggerBy = triggerBy,
                    TriggerPrice = triggerPrice,
                    OrderId = orderId,
                    StopLossTriggerBy = stopLossTriggerBy,
                    TakeProfitTriggerBy = takeProfitTriggerBy
                }
            });

            return await QueryAsync(BaseAddress.AppendPath("/v5/trade"), query, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<BybitOrderId>> CancelOrderAsync(Category category,
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            OrderFilter? orderFilter = null,
            CancellationToken ct = default)
        {
            var timestamp = DateTimeConverter.ConvertToMilliseconds(DateTime.UtcNow.AddMilliseconds(-1000)).Value.ToString(CultureInfo.InvariantCulture);
            var query = new BybitRequestQuery<BybitOrderId>(
                "order.amend",
                new Dictionary<string, string>
                {
                    { "X-BAPI-TIMESTAMP", timestamp },
                    { "Referer", _referer }
                },
                new object[] { new BybitSocketCancelOrderRequest
                {
                    Category = category,
                    ClientOrderId = clientOrderId,
                    OrderId = orderId,
                    OrderFilter = orderFilter,
                    Symbol = symbol
                }
            });

            return await QueryAsync(BaseAddress.AppendPath("/v5/trade"), query, ct).ConfigureAwait(false);
		}
		
        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToDisconnectCancelAllTopicAsync(ProductType productType, CancellationToken ct = default)
        {
            var product = productType == ProductType.Spot ? "spot" : productType == ProductType.Options ? "option" : "future";
            var subscription = new BybitSubscription<object>(_logger, new[] { "dcp." + product }, x => { }, true);
            return await SubscribeAsync(BaseAddress.AppendPath("/v5/private"), subscription, ct).ConfigureAwait(false);
        }
    }
}
