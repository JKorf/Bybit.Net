using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Objects.Internal
{
    internal class BybitList<T>
    {
        public IEnumerable<T> List { get; set; } = Array.Empty<T>();
    }
}
