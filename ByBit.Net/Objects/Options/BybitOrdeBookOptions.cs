using CryptoExchange.Net.Objects.Options;
using System;

namespace Bybit.Net.Objects.Options
{
    /// <summary>
    /// Options for the Bybit SymbolOrderBook
    /// </summary>
    public class BybitOrderBookOptions : OrderBookOptions
    {
        /// <summary>
        /// Default options for the Bybit SymbolOrderBook
        /// </summary>
        public static BybitOrderBookOptions Default { get; set; } = new BybitOrderBookOptions();

        /// <summary>
        /// After how much time we should consider the connection dropped if no data is received for this time after the initial subscriptions
        /// </summary>
        public TimeSpan? InitialDataTimeout { get; set; }
        /// <summary>
        /// The limit of entries in the order book, valid values depend on the category
        /// </summary>
        public int? Limit { get; set; }

        internal BybitOrderBookOptions Copy()
        {
            var options = Copy<BybitOrderBookOptions>();
            options.InitialDataTimeout = InitialDataTimeout;
            options.Limit = Limit;
            return options;
        }
    }
}
