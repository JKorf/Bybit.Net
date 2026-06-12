using Bybit.Net.Clients.MessageHandlers;
using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.V5;
using Bybit.Net.Objects.Models.V5;
using Bybit.Net.Objects.Options;
using Bybit.Net.Objects.Sockets;
using Bybit.Net.Objects.Sockets.Queries;
using Bybit.Net.Objects.Sockets.Subscriptions;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.MessageParsing;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using CryptoExchange.Net.Sockets.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.V5
{
    /// <inheritdoc cref="IBybitSocketClientPrivateApi" />
    internal partial class BybitSocketClientPrivateApi : SocketApiClient<BybitEnvironment, BybitAuthenticationProvider, BybitCredentials>, IBybitSocketClientPrivateApi
    {
        protected override ErrorMapping ErrorMapping => BybitErrors.WebsocketErrors;

        public new BybitSocketOptions ClientOptions => (BybitSocketOptions)base.ClientOptions;

        internal BybitSocketClientPrivateApi(ILogger logger, BybitSocketOptions options)
            : base(logger, BybitExchange.Metadata.Id, options.Environment.SocketBaseAddress, options, options.V5Options)
        {
            KeepAliveInterval = TimeSpan.Zero;

            _clientName = "BybitSocketClientApi";

            RegisterPeriodicQuery(
                "Heartbeat",
                options.V5Options.PingInterval,
                GetPingQuery,
                (connection, result) =>
                {
                    if (result.Error?.ErrorType == ErrorType.Timeout)
                    {
                        // Ping timeout, reconnect
                        _logger.LogWarning("[Sckt {SocketId}] Ping response timeout, reconnecting", connection.SocketId);
                        _ = connection.TriggerReconnectAsync();
                    }
                });

            SetDedicatedConnection(BaseAddress.AppendPath("/v5/trade"), true);
        }

        protected override IMessageSerializer CreateSerializer() => new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(BybitExchange._serializerContext));
        public override ISocketMessageHandler CreateMessageConverter(WebSocketMessageType messageType) => new BybitSocketMessageHandler3();

        private Query GetPingQuery(ISocketConnection connection)
        {
            if (connection.ConnectionUri.AbsolutePath.EndsWith("private"))
            {
                return new BybitQuery(this, "ping", null) { RequestTimeout = TimeSpan.FromSeconds(5) };
            }
            else
            {
                return new BybitPingQuery();
            }
        }

        /// <inheritdoc />
        protected override BybitAuthenticationProvider CreateAuthenticationProvider(BybitCredentials credentials)
            => new BybitAuthenticationProvider(credentials);

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
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(Action<DataEvent<BybitPositionUpdate[]>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, BybitSpotSocketEvent<BybitPositionUpdate[]>>((receiveTime, originalData, data) =>
            {
                UpdateTimeOffset(data.Timestamp);

                handler(
                    new DataEvent<BybitPositionUpdate[]>(BybitExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(string.Equals(data.Type, "snapshot", StringComparison.Ordinal) ? SocketUpdateType.Snapshot : SocketUpdateType.Update)
                        .WithStreamId(data.Topic)
                        .WithSymbol(data.Data.First().Symbol)
                        .WithDataTimestamp(data.Timestamp, GetTimeOffset())
                    );
            });

            var subscription = new BybitSubscription<BybitPositionUpdate[]>(_logger, this, new[] { "position" }, internalHandler, true);
            return await SubscribeAsync(BaseAddress.AppendPath("/v5/private"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(Action<DataEvent<BybitUserTradeUpdate[]>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, BybitSpotSocketEvent<BybitUserTradeUpdate[]>>((receiveTime, originalData, data) =>
            {
                UpdateTimeOffset(data.Timestamp);

                handler(
                    new DataEvent<BybitUserTradeUpdate[]>(BybitExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(string.Equals(data.Type, "snapshot", StringComparison.Ordinal) ? SocketUpdateType.Snapshot : SocketUpdateType.Update)
                        .WithStreamId(data.Topic)
                        .WithSymbol(data.Data.First().Symbol)
                        .WithDataTimestamp(data.Timestamp, GetTimeOffset())
                    );
            });

            var subscription = new BybitSubscription<BybitUserTradeUpdate[]>(_logger, this, new[] { "execution" }, internalHandler, true);
            return await SubscribeAsync(BaseAddress.AppendPath("/v5/private"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToSpreadUserTradeUpdatesAsync(Action<DataEvent<BybitSpreadUserTradeUpdate[]>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, BybitSpotSocketEvent<BybitSpreadUserTradeUpdate[]>>((receiveTime, originalData, data) =>
            {
                UpdateTimeOffset(data.Timestamp);

                handler(
                    new DataEvent<BybitSpreadUserTradeUpdate[]>(BybitExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(string.Equals(data.Type, "snapshot", StringComparison.Ordinal) ? SocketUpdateType.Snapshot : SocketUpdateType.Update)
                        .WithStreamId(data.Topic)
                        .WithSymbol(data.Data.First().Symbol)
                        .WithDataTimestamp(data.Timestamp, GetTimeOffset())
                    );
            });

            var subscription = new BybitSubscription<BybitSpreadUserTradeUpdate[]>(_logger, this, new[] { "spread.execution" }, internalHandler, true);
            return await SubscribeAsync(BaseAddress.AppendPath("/v5/private"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToMinimalUserTradeUpdatesAsync(Action<DataEvent<BybitMinimalUserTradeUpdate[]>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, BybitSpotSocketEvent<BybitMinimalUserTradeUpdate[]>>((receiveTime, originalData, data) =>
            {
                UpdateTimeOffset(data.Timestamp);

                handler(
                    new DataEvent<BybitMinimalUserTradeUpdate[]>(BybitExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(string.Equals(data.Type, "snapshot", StringComparison.Ordinal) ? SocketUpdateType.Snapshot : SocketUpdateType.Update)
                        .WithStreamId(data.Topic)
                        .WithSymbol(data.Data.First().Symbol)
                        .WithDataTimestamp(data.Timestamp, GetTimeOffset())
                    );
            });

            var subscription = new BybitSubscription<BybitMinimalUserTradeUpdate[]>(_logger, this, new[] { "execution.fast" }, internalHandler, true);
            return await SubscribeAsync(BaseAddress.AppendPath("/v5/private"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<BybitOrderUpdate[]>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, BybitSpotSocketEvent<BybitOrderUpdate[]>>((receiveTime, originalData, data) =>
            {
                UpdateTimeOffset(data.Timestamp);

                handler(
                    new DataEvent<BybitOrderUpdate[]>(BybitExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(string.Equals(data.Type, "snapshot", StringComparison.Ordinal) ? SocketUpdateType.Snapshot : SocketUpdateType.Update)
                        .WithStreamId(data.Topic)
                        .WithSymbol(data.Data.First().Symbol)
                        .WithDataTimestamp(data.Timestamp, GetTimeOffset())
                    );
            });

            var subscription = new BybitSubscription<BybitOrderUpdate[]>(_logger, this, new[] { "order" }, internalHandler, true);
            return await SubscribeAsync(BaseAddress.AppendPath("/v5/private"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToSpreadOrderUpdatesAsync(Action<DataEvent<BybitOrderUpdate[]>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, BybitSpotSocketEvent<BybitOrderUpdate[]>>((receiveTime, originalData, data) =>
            {
                UpdateTimeOffset(data.Timestamp);

                handler(
                    new DataEvent<BybitOrderUpdate[]>(BybitExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(string.Equals(data.Type, "snapshot", StringComparison.Ordinal) ? SocketUpdateType.Snapshot : SocketUpdateType.Update)
                        .WithStreamId(data.Topic)
                        .WithSymbol(data.Data.First().Symbol)
                        .WithDataTimestamp(data.Timestamp, GetTimeOffset())
                    );
            });

            var subscription = new BybitSubscription<BybitOrderUpdate[]>(_logger, this, new[] { "spread.order" }, internalHandler, true);
            return await SubscribeAsync(BaseAddress.AppendPath("/v5/private"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToWalletUpdatesAsync(Action<DataEvent<BybitBalance[]>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, BybitSpotSocketEvent<BybitBalance[]>>((receiveTime, originalData, data) =>
            {
                UpdateTimeOffset(data.Timestamp);

                handler(
                    new DataEvent<BybitBalance[]>(BybitExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(string.Equals(data.Type, "snapshot", StringComparison.Ordinal) ? SocketUpdateType.Snapshot : SocketUpdateType.Update)
                        .WithStreamId(data.Topic)
                        .WithDataTimestamp(data.Timestamp, GetTimeOffset())
                    );
            });

            var subscription = new BybitSubscription<BybitBalance[]>(_logger, this, new[] { "wallet" }, internalHandler, true);
            return await SubscribeAsync(BaseAddress.AppendPath("/v5/private"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToGreekUpdatesAsync(Action<DataEvent<BybitGreeks[]>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, BybitSpotSocketEvent<BybitGreeks[]>>((receiveTime, originalData, data) =>
            {
                UpdateTimeOffset(data.Timestamp);

                handler(
                    new DataEvent<BybitGreeks[]>(BybitExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(string.Equals(data.Type, "snapshot", StringComparison.Ordinal) ? SocketUpdateType.Snapshot : SocketUpdateType.Update)
                        .WithStreamId(data.Topic)
                        .WithDataTimestamp(data.Timestamp, GetTimeOffset())
                    );
            });

            var subscription = new BybitSubscription<BybitGreeks[]>(_logger, this, new[] { "greeks" }, internalHandler, true);
            return await SubscribeAsync(BaseAddress.AppendPath("/v5/private"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToDisconnectCancelAllTopicAsync(ProductType productType, CancellationToken ct = default)
        {
            var product = productType == ProductType.Spot ? "spot" : productType == ProductType.Options ? "option" : "future";
            var subscription = new BybitSubscription<object>(_logger, this, new[] { "dcp." + product }, (time, data, x) => { }, true);
            return await SubscribeAsync(BaseAddress.AppendPath("/v5/private"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<QueryResult<BybitOrderId>> PlaceOrderAsync(Category category,
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
                this, 
                "order.create",
                new Dictionary<string, string>
                {
                    { "X-BAPI-TIMESTAMP", timestamp },
                    { "Referer", LibraryHelpers.GetClientReference(() => ClientOptions.Referer, Exchange) }
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
        public async Task<QueryResult<BybitOrderId>> EditOrderAsync(Category category,
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
                this, 
                "order.amend",
                new Dictionary<string, string>
                {
                    { "X-BAPI-TIMESTAMP", timestamp },
                    { "Referer", LibraryHelpers.GetClientReference(() => ClientOptions.Referer, Exchange) }
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
        public async Task<QueryResult<BybitOrderId>> CancelOrderAsync(Category category,
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            OrderFilter? orderFilter = null,
            CancellationToken ct = default)
        {
            var timestamp = DateTimeConverter.ConvertToMilliseconds(DateTime.UtcNow.AddMilliseconds(-1000)).Value.ToString(CultureInfo.InvariantCulture);
            var query = new BybitRequestQuery<BybitOrderId>(
                this, 
                "order.cancel",
                new Dictionary<string, string>
                {
                    { "X-BAPI-TIMESTAMP", timestamp },
                    { "Referer", LibraryHelpers.GetClientReference(() => ClientOptions.Referer, Exchange) }
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
        public async Task<QueryResult<CallResult<BybitBatchOrderId>[]>> PlaceMultipleOrdersAsync(
            Category category,
            IEnumerable<BybitPlaceOrderRequest> orderRequests,
            CancellationToken ct = default)
        {
            var timestamp = DateTimeConverter.ConvertToMilliseconds(DateTime.UtcNow.AddMilliseconds(-1000)).Value.ToString(CultureInfo.InvariantCulture);

            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "request", orderRequests.ToArray() }
            };

            var query = new BybitBatchOrderRequestQuery(
                this, 
                "order.create-batch",
                new Dictionary<string, string>
                {
                    { "X-BAPI-TIMESTAMP", timestamp },
                    { "Referer", LibraryHelpers.GetClientReference(() => ClientOptions.Referer, Exchange) }
                },
                parameters
            );

            var resultData = await QueryAsync(BaseAddress.AppendPath("/v5/trade"), query, ct).ConfigureAwait(false);
            if (!resultData.Success)
                return QueryResult.Fail<CallResult<BybitBatchOrderId>[]>(resultData);

            var result = new List<CallResult<BybitBatchOrderId>>();
            foreach (var item in resultData.Data!)
            {
                if (item.Code != 0)
                    result.Add(CallResult<BybitBatchOrderId>.Fail(new ServerError(item.Code, GetErrorInfo(item.Code, item.Message!))));
                else
                    result.Add(CallResult<BybitBatchOrderId>.Ok(item.Data!));
            }

            if (result.All(x => !x.Success))
                return QueryResult.Fail<CallResult<BybitBatchOrderId>[]>(resultData, new ServerError(new ErrorInfo(ErrorType.AllOrdersFailed, "All orders failed")), result.ToArray());

            return QueryResult.Ok(resultData, result.ToArray());
        }

        /// <inheritdoc />
        public async Task<QueryResult<BybitBatchResult<BybitBatchOrderId>[]>> EditMultipleOrdersAsync(
            Category category,
            IEnumerable<BybitEditOrderRequest> orderRequests,
            CancellationToken ct = default)
        {
            var timestamp = DateTimeConverter.ConvertToMilliseconds(DateTime.UtcNow.AddMilliseconds(-1000)).Value.ToString(CultureInfo.InvariantCulture);

            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "request", orderRequests.ToArray() }
            };

            var query = new BybitBatchOrderRequestQuery(
                this, 
                "order.amend-batch",
                new Dictionary<string, string>
                {
                    { "X-BAPI-TIMESTAMP", timestamp },
                    { "Referer", LibraryHelpers.GetClientReference(() => ClientOptions.Referer, Exchange) }
                },
                parameters
            );

            return await QueryAsync(BaseAddress.AppendPath("/v5/trade"), query, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<QueryResult<BybitBatchResult<BybitBatchOrderId>[]>> CancelMultipleOrdersAsync(
            Category category,
            IEnumerable<BybitCancelOrderRequest> orderRequests,
            CancellationToken ct = default)
        {
            var timestamp = DateTimeConverter.ConvertToMilliseconds(DateTime.UtcNow.AddMilliseconds(-1000)).Value.ToString(CultureInfo.InvariantCulture);

            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "request", orderRequests.ToArray() }
            };

            var query = new BybitBatchOrderRequestQuery(
                this, 
                "order.cancel-batch",
                new Dictionary<string, string>
                {
                    { "X-BAPI-TIMESTAMP", timestamp },
                    { "Referer", LibraryHelpers.GetClientReference(() => ClientOptions.Referer, Exchange) }
                },
                parameters
            );

            return await QueryAsync(BaseAddress.AppendPath("/v5/trade"), query, ct).ConfigureAwait(false);
        }
    }
}
