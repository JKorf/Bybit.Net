using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using System.Collections.Generic;

namespace Bybit.Net.Converters
{
    internal class SortOrderConverter : BaseConverter<SortOrder>
    {
        public SortOrderConverter() : this(true) { }
        public SortOrderConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<SortOrder, string>> Mapping => new List<KeyValuePair<SortOrder, string>>
        {
            new KeyValuePair<SortOrder, string>(SortOrder.Ascending, "asc"),
            new KeyValuePair<SortOrder, string>(SortOrder.Descending, "desc")
        };
    }
}
