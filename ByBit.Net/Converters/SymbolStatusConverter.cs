using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using System.Collections.Generic;

namespace Bybit.Net.Converters
{
    internal class SymbolStatusConverter : BaseConverter<SymbolStatus>
    {
        public SymbolStatusConverter() : this(true) { }
        public SymbolStatusConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<SymbolStatus, string>> Mapping => new List<KeyValuePair<SymbolStatus, string>>
        {
            new KeyValuePair<SymbolStatus, string>(SymbolStatus.Trading, "Trading"),
            new KeyValuePair<SymbolStatus, string>(SymbolStatus.Settling, "Settling"),
            new KeyValuePair<SymbolStatus, string>(SymbolStatus.Closed, "Closed")
        };
    }
}
