using Bybit.Net.Enums;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Internal
{
    internal class BybitList<T>
    {
        public IEnumerable<T> List { get; set; } = Array.Empty<T>();
    }

    internal class BybitCategoryList<T> : BybitList<T>
    {
        /// <summary>
        /// Category
        /// </summary>
        public Category Category { get; set; }
    }

    internal class BybitSymbolCategoryList<T> : BybitCategoryList<T>
    {
        /// <summary>
        /// Name of the trading pair
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
    }
}
