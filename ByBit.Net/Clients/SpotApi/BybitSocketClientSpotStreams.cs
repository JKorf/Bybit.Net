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

namespace Bybit.Net.Clients.Socket
{
    /// <inheritdoc cref="IBybitSocketClientSpotStreams" />
    public class BybitSocketClientSpotStreams : SocketApiClient, IBybitSocketClientSpotStreams
    {
        private readonly Log _log;
        private readonly BybitSocketClient _baseClient;
        private readonly BybitSocketClientOptions _options;
               
        internal BybitSocketClientSpotStreams(Log log, BybitSocketClient baseClient, BybitSocketClientOptions options)
            : base(options, options.SpotStreamsOptions)
        {
            _log = log;
            _options = options;
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new BybitAuthenticationProvider(credentials);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<BybitSpotTradeUpdate>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = _baseClient.DeserializeInternal<BybitSpotTradeUpdate>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotTradeUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, data.Data["params"]?["symbol"]?.ToString()));
            });
            return await _baseClient.SubscribeInternalAsync(this,
                new BybitSpotRequestMessage() 
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

                var desResult = _baseClient.DeserializeInternal<BybitSpotOrderBookUpdate>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotOrderBookUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, data.Data["params"]?["symbol"]?.ToString()));
            });
            return await _baseClient.SubscribeInternalAsync(this,
                new BybitSpotRequestMessage()
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

                var desResult = _baseClient.DeserializeInternal<BybitSpotKlineUpdate>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotKlineUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, data.Data["params"]?["symbol"]?.ToString()));
            });
            return await _baseClient.SubscribeInternalAsync(this,
                new BybitSpotRequestMessage()
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
        public async Task<CallResult<UpdateSubscription>> SubscribeToBookPriceUpdatesAsync(string symbol, Action<DataEvent<BybitSpotBookPrice>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = _baseClient.DeserializeInternal<BybitSpotBookPrice>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotBookPrice)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, data.Data["params"]?["symbol"]?.ToString()));
            });
            return await _baseClient.SubscribeInternalAsync(this,
                new BybitSpotRequestMessage()
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

                var desResult = _baseClient.DeserializeInternal<BybitSpotTickerUpdate>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotTickerUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, data.Data["params"]?["symbol"]?.ToString()));
            });
            return await _baseClient.SubscribeInternalAsync(this,
                new BybitSpotRequestMessage()
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
            Action<DataEvent<BybitSpotUserTradeUpdate>> tradeUpdateHandler,
            CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var jArray = (JArray)data.Data;
                foreach(var item in jArray)
                {
                    var topic = item["e"]?.ToString();
                    if(topic == "outboundAccountInfo")
                    {
                        var desResult = _baseClient.DeserializeInternal<BybitSpotAccountUpdate>(item);
                        if (!desResult)
                        {
                            _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotAccountUpdate)} object: " + desResult.Error);
                            return;
                        }

                        accountUpdateHandler(data.As(desResult.Data));
                    }
                    else if (topic == "executionReport")
                    {
                        var desResult = _baseClient.DeserializeInternal<BybitSpotOrderUpdate>(item);
                        if (!desResult)
                        {
                            _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotOrderUpdate)} object: " + desResult.Error);
                            return;
                        }

                        orderUpdateHandler(data.As(desResult.Data));
                    }
                    else if(topic == "ticketInfo")
                    {
                        var desResult = _baseClient.DeserializeInternal<BybitSpotUserTradeUpdate>(item);
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
            return await _baseClient.SubscribeInternalAsync(
                this, 
                _options.SpotStreamsOptions.BaseAddressAuthenticated, 
                null,
                "AccountInfo", true, internalHandler, ct).ConfigureAwait(false);
        }
    }
}
