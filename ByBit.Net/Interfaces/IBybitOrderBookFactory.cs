using Bybit.Net.Enums;
using Bybit.Net.Objects.Options;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.SharedApis;
using System;

namespace Bybit.Net.Interfaces
{
    /// <summary>
    /// Bybit order book factory
    /// </summary>
    public interface IBybitOrderBookFactory
    {
        /// <summary>
        /// Spot order book factory methods
        /// </summary>
        public IOrderBookFactory<BybitOrderBookOptions> Spot { get; }

        /// <summary>
        /// Options order book factory methods
        /// </summary>
        public IOrderBookFactory<BybitOrderBookOptions> Options { get; }

        /// <summary>
        /// Linear/Inverse order book factory methods
        /// </summary>
        public IOrderBookFactory<BybitOrderBookOptions> LinearInverse { get; }

        /// <summary>
        /// Create a SymbolOrderBook for the symbol
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="options">Book options</param>
        /// <returns></returns>
        ISymbolOrderBook Create(SharedSymbol symbol, Action<BybitOrderBookOptions>? options = null);

        /// <summary>
        /// Create a SymbolOrderBook specifying the category
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="category">The symbol category</param>
        /// <param name="options">Order book options</param>
        /// <returns></returns>
        ISymbolOrderBook Create(string symbol, Category category, Action<BybitOrderBookOptions>? options = null);

        /// <summary>
        /// Create a SymbolOrderBook for a Linear/Inverse symbol
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="options">Order book options</param>
        /// <returns></returns>
        ISymbolOrderBook CreateLinearInverse(string symbol, Action<BybitOrderBookOptions>? options = null);

        /// <summary>
        /// Create a SymbolOrderBook for an Option symbol
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="options">Order book options</param>
        /// <returns></returns>
        ISymbolOrderBook CreateOption(string symbol, Action<BybitOrderBookOptions>? options = null);
        
        /// <summary>
        /// Create a SymbolOrderBook for a Spot symbol
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="options">Order book options</param>
        /// <returns></returns>
        ISymbolOrderBook CreateSpot(string symbol, Action<BybitOrderBookOptions>? options = null);
    }
}