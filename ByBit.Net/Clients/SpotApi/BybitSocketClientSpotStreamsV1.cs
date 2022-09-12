using Bybit.Net.Objects.Internal.Socket;
using Bybit.Net.Objects;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
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
using Bybit.Net.Objects.Models.Spot;
using Bybit.Net.Interfaces.Clients.SpotApi;

namespace Bybit.Net.Clients.SpotApi
{
    /// <inheritdoc cref="IBybitSocketClientSpotStreamsV2" />
    public class BybitSocketClientSpotStreamsV1 : BybitBaseSocketClientSpotStreams, IBybitSocketClientSpotStreamsV1
    {
        internal BybitSocketClientSpotStreamsV1(Log log, BybitSocketClient baseClient, BybitSocketClientOptions options)
            : base(log, baseClient, options, options.SpotStreamsV1Options)
        {
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<BybitSpotTradeUpdate>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalDataArray = data.Data["data"];
                if (internalDataArray == null)
                    return;

                var internalData = internalDataArray.First;
                if (internalData == null)
                {
                    return;
                }

                var desResult = _baseClient.DeserializeInternal<BybitSpotTradeUpdate>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotTradeUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, data.Data["symbol"]?.ToString()));
            });
            return await _baseClient.SubscribeInternalAsync(this,
                new BybitSpotRequestMessageV1()
                {
                    Operation = "trade",
                    Event = "sub",
                    Symbol = symbol
                },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, Action<DataEvent<BybitSpotOrderBookUpdate>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalDataArray = data.Data["data"];
                if (internalDataArray == null)
                    return;

                var internalData = internalDataArray.First;
                if (internalData == null)
                {
                    return;
                }

                var desResult = _baseClient.DeserializeInternal<BybitSpotOrderBookUpdate>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotOrderBookUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, data.Data["symbol"]?.ToString()));
            });
            return await _baseClient.SubscribeInternalAsync(this,
                new BybitSpotRequestMessageV1()
                {
                    Operation = "depth",
                    Event = "sub",
                    Symbol = symbol
                },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, KlineInterval interval, Action<DataEvent<BybitSpotKlineUpdate>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalDataArray = data.Data["data"];
                if (internalDataArray == null)
                    return;

                var internalData = internalDataArray.First;
                if (internalData == null)
                {
                    return;
                }

                var desResult = _baseClient.DeserializeInternal<BybitSpotKlineUpdate>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotKlineUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, data.Data["symbol"]?.ToString()));
            });
            return await _baseClient.SubscribeInternalAsync(this,
                new BybitSpotRequestMessageV1()
                {
                    Operation = $"kline_{KlineIntervalSpotConverter.ToString(interval)}",
                    Event = "sub",
                    Symbol = symbol
                },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BybitSpotTickerUpdate>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalDataArray = data.Data["data"];
                if (internalDataArray == null)
                    return;

                var internalData = internalDataArray.First;

                if (internalData == null)
                {
                    return;
                }

                var desResult = _baseClient.DeserializeInternal<BybitSpotTickerUpdate>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotTickerUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, data.Data["symbol"]?.ToString()));
            });
            return await _baseClient.SubscribeInternalAsync(this,
                new BybitSpotRequestMessageV1()
                {
                    Operation = "realtimes",
                    Event = "sub",
                    Symbol = symbol
                },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderBookMergedUpdatesAsync(string symbol, int dumpScale, Action<DataEvent<BybitSpotOrderBookUpdate>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalDataArray = data.Data["data"];
                if (internalDataArray == null)
                    return;

                var internalData = internalDataArray.First;
                if (internalData == null)
                {
                    return;
                }

                var desResult = _baseClient.DeserializeInternal<BybitSpotOrderBookUpdate>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotOrderBookUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, data.Data["symbol"]?.ToString()));
            });
            return await _baseClient.SubscribeInternalAsync(this,
                new BybitSpotRequestMessageV1()
                {
                    Operation = "mergedDepth",
                    Event = "sub",
                    Symbol = symbol,
                    Parameters = new Dictionary<string, object>
                    {
                        { "dumpScale", dumpScale }
                    }
                },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderBookDiffUpdatesAsync(string symbol, Action<DataEvent<BybitSpotOrderBookUpdate>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalDataArray = data.Data["data"];
                if (internalDataArray == null)
                    return;

                var internalData = internalDataArray.First;
                if (internalData == null)
                {
                    return;
                }

                var desResult = _baseClient.DeserializeInternal<BybitSpotOrderBookUpdate>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotOrderBookUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, data.Data["symbol"]?.ToString()));
            });
            return await _baseClient.SubscribeInternalAsync(this,
                new BybitSpotRequestMessageV1()
                {
                    Operation = "diffDepth",
                    Event = "sub",
                    Symbol = symbol
                },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToLeverageTokenUpdatesAsync(string symbol, Action<DataEvent<BybitSpotLeverageUpdate>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalDataArray = data.Data["data"];
                if (internalDataArray == null)
                    return;

                var internalData = internalDataArray.First;
                if (internalData == null)
                {
                    return;
                }

                var desResult = _baseClient.DeserializeInternal<BybitSpotLeverageUpdate>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotLeverageUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, data.Data["symbol"]?.ToString()));
            });
            return await _baseClient.SubscribeInternalAsync(this,
                new BybitSpotRequestMessageV1()
                {
                    Operation = "lt",
                    Event = "sub",
                    Symbol = "$\"{symbol}NAV\""
                },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }
    }
}
