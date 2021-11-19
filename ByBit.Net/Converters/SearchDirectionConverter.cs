using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using System.Collections.Generic;

namespace Bybit.Net.Converters
{
    internal class SearchDirectionConverter : BaseConverter<SearchDirection>
    {
        public SearchDirectionConverter() : this(true) { }
        public SearchDirectionConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<SearchDirection, string>> Mapping => new List<KeyValuePair<SearchDirection, string>>
        {
            new KeyValuePair<SearchDirection, string>(SearchDirection.Previous, "prev"),
            new KeyValuePair<SearchDirection, string>(SearchDirection.Next, "next")
        };
    }
}
