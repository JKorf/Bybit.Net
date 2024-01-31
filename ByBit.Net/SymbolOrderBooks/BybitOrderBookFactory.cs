using Bybit.Net.Enums;
using Bybit.Net.Interfaces;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects.Options;
using CryptoExchange.Net.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Bybit.Net.SymbolOrderBooks
{
    /// <inheritdoc />
    public class BybitOrderBookFactory : IBybitOrderBookFactory
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="serviceProvider">Service provider for resolving logging and clients</param>
        public BybitOrderBookFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc />
        public ISymbolOrderBook CreateSpot(string symbol, Action<BybitOrderBookOptions>? options = null)
            => new BybitSymbolOrderBook(symbol,
                                        Enums.Category.Spot,
                                        options,
                                        _serviceProvider.GetRequiredService<ILogger<BybitSymbolOrderBook>>(),
                                        _serviceProvider.GetRequiredService<IBybitSocketClient>());

        /// <inheritdoc />
        public ISymbolOrderBook CreateOption(string symbol, Action<BybitOrderBookOptions>? options = null)
            => new BybitSymbolOrderBook(symbol,
                                        Enums.Category.Option,
                                        options,
                                        _serviceProvider.GetRequiredService<ILogger<BybitSymbolOrderBook>>(),
                                        _serviceProvider.GetRequiredService<IBybitSocketClient>());

        /// <inheritdoc />
        public ISymbolOrderBook CreateLinearInverse(string symbol, Action<BybitOrderBookOptions>? options = null)
            => new BybitSymbolOrderBook(symbol,
                                        Enums.Category.Linear,
                                        options,
                                        _serviceProvider.GetRequiredService<ILogger<BybitSymbolOrderBook>>(),
                                        _serviceProvider.GetRequiredService<IBybitSocketClient>());

        /// <inheritdoc />
        public ISymbolOrderBook Create(string symbol, Category category, Action<BybitOrderBookOptions>? options = null)
            => new BybitSymbolOrderBook(symbol,
                                        category,
                                        options,
                                        _serviceProvider.GetRequiredService<ILogger<BybitSymbolOrderBook>>(),
                                        _serviceProvider.GetRequiredService<IBybitSocketClient>());
    }
}
