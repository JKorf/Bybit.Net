using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using System.Collections.Generic;

namespace Bybit.Net.Converters
{
    internal class OrderSideConverter : BaseConverter<OrderSide>
    {
        public OrderSideConverter() : this(true) { }
        public OrderSideConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<OrderSide, string>> Mapping => new List<KeyValuePair<OrderSide, string>>
        {
            new KeyValuePair<OrderSide, string>(OrderSide.Buy, "Buy"),
            new KeyValuePair<OrderSide, string>(OrderSide.Buy, "BUY"),
            new KeyValuePair<OrderSide, string>(OrderSide.Sell, "Sell"),
            new KeyValuePair<OrderSide, string>(OrderSide.Sell, "SELL")
        };
    }
}
