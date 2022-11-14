using Bybit.Net.Objects.Internal.Socket;
using Bybit.Net.Objects;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Net.Logging;
using Bybit.Net.Objects.Models.Socket.Spot;
using Bybit.Net.Enums;
using Bybit.Net.Converters;
using Bybit.Net.Interfaces.Clients.SpotApi.v2;
using Bybit.Net.Objects.Models.Spot.v1;

namespace Bybit.Net.Clients.SpotApi.v2
{
    /// <inheritdoc cref="IBybitSocketClientSpotStreamsV2"/>
    public class BybitSocketClientSpotStreamsV2 : BybitBaseSocketClientSpotStreams, IBybitSocketClientSpotStreamsV2
    {
        internal BybitSocketClientSpotStreamsV2(Log log, BybitSocketClientOptions options)
            : base(log, options, options.SpotStreamsV2Options)
        {
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<BybitSpotTradeUpdate>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = Deserialize<BybitSpotTradeUpdate>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotTradeUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, data.Data["params"]?["symbol"]?.ToString()));
            });
            return await SubscribeAsync(
                new BybitSpotRequestMessageV2()
                {
                    Operation = "trade",
                    Event = "sub",
                    Parameters = new Dictionary<string, object>
                    {
                        { "symbol", symbol }
                    }
                },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, Action<DataEvent<BybitSpotOrderBookUpdate>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = Deserialize<BybitSpotOrderBookUpdate>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotOrderBookUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, data.Data["params"]?["symbol"]?.ToString()));
            });
            return await SubscribeAsync(
                new BybitSpotRequestMessageV2()
                {
                    Operation = "depth",
                    Event = "sub",
                    Parameters = new Dictionary<string, object>
                    {
                        { "symbol", symbol }
                    }
                },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, KlineInterval interval, Action<DataEvent<BybitSpotKlineUpdate>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = Deserialize<BybitSpotKlineUpdate>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotKlineUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, data.Data["params"]?["symbol"]?.ToString()));
            });
            return await SubscribeAsync(
                new BybitSpotRequestMessageV2()
                {
                    Operation = "kline",
                    Event = "sub",
                    Parameters = new Dictionary<string, object>
                    {
                        { "symbol", symbol },
                        { "klineType", JsonConvert.SerializeObject(interval, new KlineIntervalSpotConverter(false)) }
                    }
                },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToBookPriceUpdatesAsync(string symbol, Action<DataEvent<BybitSpotBookPriceV1>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = Deserialize<BybitSpotBookPriceV1>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotBookPriceV1)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, data.Data["params"]?["symbol"]?.ToString()));
            });
            return await SubscribeAsync(
                new BybitSpotRequestMessageV2()
                {
                    Operation = "bookTicker",
                    Event = "sub",
                    Parameters = new Dictionary<string, object>
                    {
                        { "symbol", symbol }
                    }
                },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BybitSpotTickerUpdate>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = Deserialize<BybitSpotTickerUpdate>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotTickerUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, data.Data["params"]?["symbol"]?.ToString()));
            });
            return await SubscribeAsync(
                new BybitSpotRequestMessageV2()
                {
                    Operation = "realtimes",
                    Event = "sub",
                    Parameters = new Dictionary<string, object>
                    {
                        { "symbol", symbol }
                    }
                },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToAccountUpdatesAsync(
            Action<DataEvent<BybitSpotAccountUpdate>> accountUpdateHandler,
            Action<DataEvent<BybitSpotOrderUpdate>> orderUpdateHandler,
            Action<DataEvent<BybitSpotStopOrderUpdate>> stopOrderUpdateHandler,
            Action<DataEvent<BybitSpotUserTradeUpdate>> tradeUpdateHandler,
            CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var jArray = (JArray)data.Data;
                foreach (var item in jArray)
                {
                    var topic = item["e"]?.ToString();
                    if (topic == "outboundAccountInfo")
                    {
                        var desResult = Deserialize<BybitSpotAccountUpdate>(item);
                        if (!desResult)
                        {
                            _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotAccountUpdate)} object: " + desResult.Error);
                            return;
                        }

                        accountUpdateHandler(data.As(desResult.Data));
                    }
                    else if (topic == "executionReport")
                    {
                        var desResult = Deserialize<BybitSpotOrderUpdate>(item);
                        if (!desResult)
                        {
                            _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotOrderUpdate)} object: " + desResult.Error);
                            return;
                        }

                        orderUpdateHandler(data.As(desResult.Data));
                    }
                    else if (topic == "stop_executionReport")
                    {
                        var desResult = Deserialize<BybitSpotStopOrderUpdate>(item);
                        if (!desResult)
                        {
                            _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotStopOrderUpdate)} object: " + desResult.Error);
                            return;
                        }

                        stopOrderUpdateHandler(data.As(desResult.Data));
                    }
                    else if (topic == "ticketInfo")
                    {
                        var desResult = Deserialize<BybitSpotUserTradeUpdate>(item);
                        if (!desResult)
                        {
                            _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotUserTradeUpdate)} object: " + desResult.Error);
                            return;
                        }

                        tradeUpdateHandler(data.As(desResult.Data));
                    }
                    else
                    {
                        _log.Write(LogLevel.Warning, $"Unknown account update: " + topic);
                    }
                }
            });

            return await SubscribeAsync(
                _options.SpotStreamsV2Options.BaseAddressAuthenticated,
                null,
                "AccountInfo", true, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public override bool CheckAuth(JToken data, ref bool isSuccess)
        {
            var auth = data["auth"]?.ToString();
            isSuccess = auth == "success";
            return auth != null;
        }
    }
}
