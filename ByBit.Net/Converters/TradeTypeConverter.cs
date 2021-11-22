using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using System.Collections.Generic;

namespace Bybit.Net.Converters
{
    internal class TradeTypeConverter : BaseConverter<TradeType>
    {
        public TradeTypeConverter() : this(true) { }
        public TradeTypeConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<TradeType, string>> Mapping => new List<KeyValuePair<TradeType, string>>
        {
            new KeyValuePair<TradeType, string>(TradeType.Trade, "Trade"),
            new KeyValuePair<TradeType, string>(TradeType.AdlTrade, "AdlTrade"),
            new KeyValuePair<TradeType, string>(TradeType.Funding, "Funding"),
            new KeyValuePair<TradeType, string>(TradeType.BustTrade, "BustTrade")
        };
    }
}
