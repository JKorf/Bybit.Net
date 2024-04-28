using Bybit.Net.Enums;
using Bybit.Net.Interfaces;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects.Options;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.OrderBook;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Bybit.Net.SymbolOrderBooks
{
    /// <inheritdoc />
    public class BybitOrderBookFactory : IBybitOrderBookFactory
    {
        private readonly IServiceProvider _serviceProvider;

        /// <inheritdoc />
        public IOrderBookFactory<BybitOrderBookOptions> Spot { get; }

        /// <inheritdoc />
        public IOrderBookFactory<BybitOrderBookOptions> Options { get; }

        /// <inheritdoc />
        public IOrderBookFactory<BybitOrderBookOptions> LinearInverse { get; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="serviceProvider">Service provider for resolving logging and clients</param>
        public BybitOrderBookFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            Spot = new OrderBookFactory<BybitOrderBookOptions>((symbol, options) => CreateSpot(symbol, options), (baseAsset, quoteAsset, options) => CreateSpot(baseAsset + quoteAsset, options));
            Options = new OrderBookFactory<BybitOrderBookOptions>((symbol, options) => CreateOption(symbol, options), (baseAsset, quoteAsset, options) => CreateOption(baseAsset + quoteAsset, options));
            LinearInverse = new OrderBookFactory<BybitOrderBookOptions>((symbol, options) => CreateLinearInverse(symbol, options), (baseAsset, quoteAsset, options) => CreateLinearInverse(baseAsset + quoteAsset, options));
        }

        /// <inheritdoc />
        public ISymbolOrderBook CreateSpot(string symbol, Action<BybitOrderBookOptions>? options = null)
            => new BybitSymbolOrderBook(symbol,
                                        Enums.Category.Spot,
                                        options,
                                        _serviceProvider.GetRequiredService<ILoggerFactory>(),
                                        _serviceProvider.GetRequiredService<IBybitSocketClient>());

        /// <inheritdoc />
        public ISymbolOrderBook CreateOption(string symbol, Action<BybitOrderBookOptions>? options = null)
            => new BybitSymbolOrderBook(symbol,
                                        Enums.Category.Option,
                                        options,
                                        _serviceProvider.GetRequiredService<ILoggerFactory>(),
                                        _serviceProvider.GetRequiredService<IBybitSocketClient>());

        /// <inheritdoc />
        public ISymbolOrderBook CreateLinearInverse(string symbol, Action<BybitOrderBookOptions>? options = null)
            => new BybitSymbolOrderBook(symbol,
                                        Enums.Category.Linear,
                                        options,
                                        _serviceProvider.GetRequiredService<ILoggerFactory>(),
                                        _serviceProvider.GetRequiredService<IBybitSocketClient>());

        /// <inheritdoc />
        public ISymbolOrderBook Create(string symbol, Category category, Action<BybitOrderBookOptions>? options = null)
            => new BybitSymbolOrderBook(symbol,
                                        category,
                                        options,
                                        _serviceProvider.GetRequiredService<ILoggerFactory>(),
                                        _serviceProvider.GetRequiredService<IBybitSocketClient>());
    }
}
