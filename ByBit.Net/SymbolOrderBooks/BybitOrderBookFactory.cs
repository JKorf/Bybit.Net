using Bybit.Net.Enums;
using Bybit.Net.Interfaces;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects.Options;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.OrderBook;
using CryptoExchange.Net.SharedApis;
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

            Spot = new OrderBookFactory<BybitOrderBookOptions>(
                CreateSpot,
                (sharedSymbol, options) => CreateSpot(BybitExchange.FormatSymbol(sharedSymbol.BaseAsset, sharedSymbol.QuoteAsset, sharedSymbol.TradingMode, sharedSymbol.DeliverTime), options));
            Options = new OrderBookFactory<BybitOrderBookOptions>(
                CreateOption,
                (sharedSymbol, options) => CreateOption(BybitExchange.FormatSymbol(sharedSymbol.BaseAsset, sharedSymbol.QuoteAsset, sharedSymbol.TradingMode, sharedSymbol.DeliverTime), options));
            LinearInverse = new OrderBookFactory<BybitOrderBookOptions>(
                CreateLinearInverse, 
                (sharedSymbol, options) => CreateLinearInverse(BybitExchange.FormatSymbol(sharedSymbol.BaseAsset, sharedSymbol.QuoteAsset, sharedSymbol.TradingMode, sharedSymbol.DeliverTime), options));
        }

        /// <inheritdoc />
        public ISymbolOrderBook Create(SharedSymbol symbol, Action<BybitOrderBookOptions>? options = null)
        {
            var symbolName = symbol.GetSymbol(BybitExchange.FormatSymbol);
            if (symbol.TradingMode == TradingMode.Spot)
                return CreateSpot(symbolName, options);

            return CreateLinearInverse(symbolName, options);
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
