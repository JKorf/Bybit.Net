using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using System.Collections.Generic;

namespace Bybit.Net.Converters
{
    internal class OrderTypeSpotConverter : BaseConverter<OrderType>
    {
        public OrderTypeSpotConverter() : this(true) { }
        public OrderTypeSpotConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<OrderType, string>> Mapping => new List<KeyValuePair<OrderType, string>>
        {
            new KeyValuePair<OrderType, string>(OrderType.Limit, "LIMIT"),
            new KeyValuePair<OrderType, string>(OrderType.Limit, "LIMIT_OF_QUOTE"),
            new KeyValuePair<OrderType, string>(OrderType.Limit, "LIMIT_OF_BASE"),
            new KeyValuePair<OrderType, string>(OrderType.Market, "MARKET"),
            new KeyValuePair<OrderType, string>(OrderType.Market, "MARKET_OF_QUOTE"),
            new KeyValuePair<OrderType, string>(OrderType.Market, "MARKET_OF_BASE"),
            new KeyValuePair<OrderType, string>(OrderType.LimitMaker, "LIMIT_MAKER")
        };
    }
}
