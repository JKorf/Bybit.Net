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
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="serviceProvider">Service provider for resolving logging and clients</param>
        public BybitTrackerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc />
        public IKlineTracker CreateKlineTracker(SharedSymbol symbol, SharedKlineInterval interval, int? limit = null, TimeSpan? period = null)
        {
            IKlineRestClient restClient;
            IKlineSocketClient socketClient;
            if (symbol.TradingMode == TradingMode.Spot)
            {
                restClient = _serviceProvider.GetRequiredService<IBybitRestClient>().V5Api.SharedClient;
                socketClient = _serviceProvider.GetRequiredService<IBybitSocketClient>().V5SpotApi.SharedClient;
            }
            else if (symbol.TradingMode.IsLinear())
            {
                restClient = _serviceProvider.GetRequiredService<IBybitRestClient>().V5Api.SharedClient;
                socketClient = _serviceProvider.GetRequiredService<IBybitSocketClient>().V5LinearApi.SharedClient;
            }
            else
            {
                restClient = _serviceProvider.GetRequiredService<IBybitRestClient>().V5Api.SharedClient;
                socketClient = _serviceProvider.GetRequiredService<IBybitSocketClient>().V5InverseApi.SharedClient;
            }

            return new KlineTracker(
                _serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger(restClient.Exchange),
                restClient,
                socketClient,
                symbol,
                interval,
                limit,
                period
                );
        }

        /// <inheritdoc />
        public ITradeTracker CreateTradeTracker(SharedSymbol symbol, int? limit = null, TimeSpan? period = null)
        {
            IRecentTradeRestClient? restClient = null;
            ITradeSocketClient socketClient;
            if (symbol.TradingMode == TradingMode.Spot)
            {
                restClient = _serviceProvider.GetRequiredService<IBybitRestClient>().V5Api.SharedClient;
                socketClient = _serviceProvider.GetRequiredService<IBybitSocketClient>().V5SpotApi.SharedClient;
            }
            else if (symbol.TradingMode.IsLinear())
            {
                restClient = _serviceProvider.GetRequiredService<IBybitRestClient>().V5Api.SharedClient;
                socketClient = _serviceProvider.GetRequiredService<IBybitSocketClient>().V5LinearApi.SharedClient;
            }
            else
            {
                restClient = _serviceProvider.GetRequiredService<IBybitRestClient>().V5Api.SharedClient;
                socketClient = _serviceProvider.GetRequiredService<IBybitSocketClient>().V5InverseApi.SharedClient;
            }

            return new TradeTracker(
                _serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger(socketClient.Exchange),
                restClient,
                socketClient,
                symbol,
                limit,
                period
                );
        }
    }
}
