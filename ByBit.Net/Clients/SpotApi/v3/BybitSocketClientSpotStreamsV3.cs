using Bybit.Net.Objects.Internal.Socket;
using Bybit.Net.Objects;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Net.Logging;
using Bybit.Net.Objects.Models.Socket.Spot;
using Bybit.Net.Enums;
using Bybit.Net.Converters;
using Bybit.Net.Interfaces.Clients.SpotApi.v3;
using Bybit.Net.Objects.Models.Spot.v3;

namespace Bybit.Net.Clients.SpotApi.v3
{
    /// <inheritdoc cref="IBybitSocketClientSpotStreamsV3"/>
    public class BybitSocketClientSpotStreamsV3 : BybitBaseSocketClientSpotStreams, IBybitSocketClientSpotStreamsV3
    {
        internal BybitSocketClientSpotStreamsV3(Log log, BybitSocketClientOptions options)
            : base(log, options, options.SpotStreamsV3Options)
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
                new BybitSpotRequestMessageV3()
                {
                    ID = Guid.NewGuid().ToString(),
                    Operation = "subscribe",
                    Parameters = new[]
                    {
                        $"trade.{symbol}"
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
                new BybitSpotRequestMessageV3()
                {
                    ID = Guid.NewGuid().ToString(),
                    Operation = "subscribe",
                    Parameters = new[]
                    {
                        $"orderbook.40.{symbol}"
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

                var topic = data.Data["topic"]!.ToString();
                handler(data.As(desResult.Data, topic.Substring(topic.IndexOf('.') + 1)));
            });
            return await SubscribeAsync(
                new BybitSpotRequestMessageV3()
                {
                    ID = Guid.NewGuid().ToString(),
                    Operation = "subscribe",
                    Parameters = new[]
                    {
                        $"kline.{KlineIntervalSpotConverter.ToString(interval)}.{symbol}"
                    }
                },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToBookPriceUpdatesAsync(string symbol, Action<DataEvent<BybitSpotBookPriceV3>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = Deserialize<BybitSpotBookPriceV3>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotBookPriceV3)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, data.Data["params"]?["symbol"]?.ToString()));
            });
            return await SubscribeAsync(
                new BybitSpotRequestMessageV3()
                {
                    ID = Guid.NewGuid().ToString(),
                    Operation = "subscribe",
                    Parameters = new[]
                    {
                        $"bookticker.{symbol}"
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
                new BybitSpotRequestMessageV3()
                {
                    ID = Guid.NewGuid().ToString(),
                    Operation = "subscribe",
                    Parameters = new[]
                    {
                        $"tickers.{symbol}"
                    }
                },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToAccountUpdatesAsync(Action<DataEvent<BybitSpotAccountUpdate>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var jArray = (JArray)internalData;
                foreach (var item in jArray)
                {
                    var desResult = Deserialize<BybitSpotAccountUpdate>(item);
                    if (!desResult)
                    {
                        _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotAccountUpdate)} object: " + desResult.Error);
                        return;
                    }

                    handler(data.As(desResult.Data));
                }
            });

            return await SubscribeAsync(
                _options.SpotStreamsV3Options.BaseAddressAuthenticated,
                new BybitSpotRequestMessageV3()
                {
                    ID = Guid.NewGuid().ToString(),
                    Operation = "subscribe",
                    Parameters = new[]
                    {
                        "outboundAccountInfo"
                    }
                },
                null, true, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToUserOrdersUpdatesAsync(Action<DataEvent<BybitSpotOrderUpdate>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var jArray = (JArray)internalData;
                foreach (var item in jArray)
                {
                    var desResult = Deserialize<BybitSpotOrderUpdate>(item);
                    if (!desResult)
                    {
                        _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotOrderUpdate)} object: " + desResult.Error);
                        return;
                    }

                    handler(data.As(desResult.Data));
                }
            });

            return await SubscribeAsync(
                _options.SpotStreamsV3Options.BaseAddressAuthenticated,
                new BybitSpotRequestMessageV3()
                {
                    ID = Guid.NewGuid().ToString(),
                    Operation = "subscribe",
                    Parameters = new[]
                    {
                        "order"
                    }
                },
                null, true, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToUserStopOrdersUpdatesAsync(Action<DataEvent<BybitSpotStopOrderUpdate>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var jArray = (JArray)internalData;
                foreach (var item in jArray)
                {
                    var desResult = Deserialize<BybitSpotStopOrderUpdate>(item);
                    if (!desResult)
                    {
                        _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotStopOrderUpdate)} object: " + desResult.Error);
                        return;
                    }

                    handler(data.As(desResult.Data));
                }
            });

            return await SubscribeAsync(
                _options.SpotStreamsV3Options.BaseAddressAuthenticated,
                new BybitSpotRequestMessageV3()
                {
                    ID = Guid.NewGuid().ToString(),
                    Operation = "subscribe",
                    Parameters = new[]
                    {
                        "stopOrder"
                    }
                },
                null, true, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToUserTradesUpdatesAsync(Action<DataEvent<BybitSpotUserTradeUpdate>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var jArray = (JArray)internalData;
                foreach (var item in jArray)
                {
                    var desResult = Deserialize<BybitSpotUserTradeUpdate>(item);
                    if (!desResult)
                    {
                        _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotUserTradeUpdate)} object: " + desResult.Error);
                        return;
                    }

                    handler(data.As(desResult.Data));
                }
            });

            return await SubscribeAsync(
                _options.SpotStreamsV3Options.BaseAddressAuthenticated,
                new BybitSpotRequestMessageV3()
                {
                    ID = Guid.NewGuid().ToString(),
                    Operation = "subscribe",
                    Parameters = new[]
                    {
                        "ticketInfo"
                    }
                },
                null, true, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public override bool CheckAuth(JToken data, ref bool isSuccess)
        {
            var isAuthOperation = data["op"]?.ToString() == "auth";

            var auth = data["success"]?.ToString();
            isSuccess = isAuthOperation && auth == "True";
            return auth != null;
        }
    }
}
