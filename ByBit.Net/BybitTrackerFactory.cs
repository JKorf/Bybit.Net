using Bybit.Net.Clients;
using Bybit.Net.Interfaces;
using Bybit.Net.Interfaces.Clients;
using CryptoExchange.Net;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.Trackers.Klines;
using CryptoExchange.Net.Trackers.Trades;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Bybit.Net
{
    /// <inheritdoc />
    public class BybitTrackerFactory : IBybitTrackerFactory
    {
        private readonly IServiceProvider? _serviceProvider;

        /// <summary>
        /// ctor
        /// </summary>
        public BybitTrackerFactory()
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="serviceProvider">Service provider for resolving logging and clients</param>
        public BybitTrackerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc />
        public bool CanCreateKlineTracker(SharedSymbol symbol, SharedKlineInterval interval)
        {
            var client = (_serviceProvider?.GetRequiredService<IBybitSocketClient>() ?? new BybitSocketClient());
            SubscribeKlineOptions klineOptions = symbol.TradingMode == TradingMode.Spot
                ? client.V5SpotApi.SharedClient.SubscribeKlineOptions
                : symbol.TradingMode.IsLinear() 
                    ? client.V5LinearApi.SharedClient.SubscribeKlineOptions
                        : client.V5InverseApi.SharedClient.SubscribeKlineOptions;
            return klineOptions.IsSupported(interval);
        }

        /// <inheritdoc />
        public bool CanCreateTradeTracker(SharedSymbol symbol) => true;

        /// <inheritdoc />
        public IKlineTracker CreateKlineTracker(SharedSymbol symbol, SharedKlineInterval interval, int? limit = null, TimeSpan? period = null)
        {
            var restClient = _serviceProvider?.GetRequiredService<IBybitRestClient>() ?? new BybitRestClient();
            var socketClient = _serviceProvider?.GetRequiredService<IBybitSocketClient>() ?? new BybitSocketClient();

            IKlineRestClient sharedRestClient;
            IKlineSocketClient sharedSocketClient;
            if (symbol.TradingMode == TradingMode.Spot)
            {
                sharedRestClient = restClient.V5Api.SharedClient;
                sharedSocketClient = socketClient.V5SpotApi.SharedClient;
            }
            else if (symbol.TradingMode.IsLinear())
            {
                sharedRestClient = restClient.V5Api.SharedClient;
                sharedSocketClient = socketClient.V5LinearApi.SharedClient;
            }
            else
            {
                sharedRestClient = restClient.V5Api.SharedClient;
                sharedSocketClient = socketClient.V5InverseApi.SharedClient;
            }

            return new KlineTracker(
                _serviceProvider?.GetRequiredService<ILoggerFactory>().CreateLogger(restClient.Exchange),
                sharedRestClient,
                sharedSocketClient,
                symbol,
                interval,
                limit,
                period
                );
        }

        /// <inheritdoc />
        public ITradeTracker CreateTradeTracker(SharedSymbol symbol, int? limit = null, TimeSpan? period = null)
        {
            var restClient = _serviceProvider?.GetRequiredService<IBybitRestClient>() ?? new BybitRestClient();
            var socketClient = _serviceProvider?.GetRequiredService<IBybitSocketClient>() ?? new BybitSocketClient();

            IRecentTradeRestClient? sharedRestClient = null;
            ITradeSocketClient sharedSocketClient;
            if (symbol.TradingMode == TradingMode.Spot)
            {
                sharedRestClient = restClient.V5Api.SharedClient;
                sharedSocketClient = socketClient.V5SpotApi.SharedClient;
            }
            else if (symbol.TradingMode.IsLinear())
            {
                sharedRestClient = restClient.V5Api.SharedClient;
                sharedSocketClient = socketClient.V5LinearApi.SharedClient;
            }
            else
            {
                sharedRestClient = restClient.V5Api.SharedClient;
                sharedSocketClient = socketClient.V5InverseApi.SharedClient;
            }

            return new TradeTracker(
                _serviceProvider?.GetRequiredService<ILoggerFactory>().CreateLogger(socketClient.Exchange),
                sharedRestClient,
                null,
                sharedSocketClient,
                symbol,
                limit,
                period
                );
        }
    }
}
