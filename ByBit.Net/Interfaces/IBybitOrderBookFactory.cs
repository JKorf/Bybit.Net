using Bybit.Net.Enums;
using Bybit.Net.Objects.Options;
using CryptoExchange.Net.Interfaces;
using System;

namespace Bybit.Net.Interfaces
{
    /// <summary>
    /// Bybit order book factory
    /// </summary>
    public interface IBybitOrderBookFactory
    {
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