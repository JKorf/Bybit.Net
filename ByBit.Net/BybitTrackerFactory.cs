using Bybit.Net.Clients;
using Bybit.Net.Interfaces;
using Bybit.Net.Interfaces.Clients;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.Trackers.Klines;
using CryptoExchange.Net.Trackers.Trades;
using CryptoExchange.Net.Trackers.UserData;
using CryptoExchange.Net.Trackers.UserData.Interfaces;
using CryptoExchange.Net.Trackers.UserData.Objects;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
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

        /// <inheritdoc />
        public IUserSpotDataTracker CreateUserSpotDataTracker(SpotUserDataTrackerConfig? config = null)
        {
            var restClient = _serviceProvider?.GetRequiredService<IBybitRestClient>() ?? new BybitRestClient();
            var socketClient = _serviceProvider?.GetRequiredService<IBybitSocketClient>() ?? new BybitSocketClient();
            return new BybitUserSpotDataTracker(
                _serviceProvider?.GetRequiredService<ILogger<BybitUserSpotDataTracker>>() ?? new NullLogger<BybitUserSpotDataTracker>(),
                restClient,
                socketClient,
                null,
                config
                );
        }

        /// <inheritdoc />
        public IUserSpotDataTracker CreateUserSpotDataTracker(string userIdentifier, ApiCredentials credentials, SpotUserDataTrackerConfig? config = null, BybitEnvironment? environment = null)
        {
            var clientProvider = _serviceProvider?.GetRequiredService<IBybitUserClientProvider>() ?? new BybitUserClientProvider();
            var restClient = clientProvider.GetRestClient(userIdentifier, credentials, environment);
            var socketClient = clientProvider.GetSocketClient(userIdentifier, credentials, environment);
            return new BybitUserSpotDataTracker(
                _serviceProvider?.GetRequiredService<ILogger<BybitUserSpotDataTracker>>() ?? new NullLogger<BybitUserSpotDataTracker>(),
                restClient,
                socketClient,
                userIdentifier,
                config
                );
        }

        /// <inheritdoc />
        public IUserFuturesDataTracker CreateUserFuturesDataTracker(FuturesUserDataTrackerConfig? config = null)
        {
            var restClient = _serviceProvider?.GetRequiredService<IBybitRestClient>() ?? new BybitRestClient();
            var socketClient = _serviceProvider?.GetRequiredService<IBybitSocketClient>() ?? new BybitSocketClient();
            return new BybitUserFuturesDataTracker(
                _serviceProvider?.GetRequiredService<ILogger<BybitUserFuturesDataTracker>>() ?? new NullLogger<BybitUserFuturesDataTracker>(),
                restClient,
                socketClient,
                null,
                config
                );
        }

        /// <inheritdoc />
        public IUserFuturesDataTracker CreateUserFuturesDataTracker(string userIdentifier, ApiCredentials credentials, FuturesUserDataTrackerConfig? config = null, BybitEnvironment? environment = null)
        {
            var clientProvider = _serviceProvider?.GetRequiredService<IBybitUserClientProvider>() ?? new BybitUserClientProvider();
            var restClient = clientProvider.GetRestClient(userIdentifier, credentials, environment);
            var socketClient = clientProvider.GetSocketClient(userIdentifier, credentials, environment);
            return new BybitUserFuturesDataTracker(
                _serviceProvider?.GetRequiredService<ILogger<BybitUserFuturesDataTracker>>() ?? new NullLogger<BybitUserFuturesDataTracker>(),
                restClient,
                socketClient,
                userIdentifier,
                config
                );
        }

    }
}
