using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using System.Collections.Generic;

namespace Bybit.Net.Converters
{
    internal class TickDirectionConverter : BaseConverter<TickDirection>
    {
        public TickDirectionConverter() : this(true) { }
        public TickDirectionConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<TickDirection, string>> Mapping => new List<KeyValuePair<TickDirection, string>>
        {
            new KeyValuePair<TickDirection, string>(TickDirection.PlusTick, "PlusTick"),
            new KeyValuePair<TickDirection, string>(TickDirection.MinusTick, "MinusTick"),
            new KeyValuePair<TickDirection, string>(TickDirection.ZeroPlusTick, "ZeroPlusTick"),
            new KeyValuePair<TickDirection, string>(TickDirection.ZeroMinusTick, "ZeroMinusTick"),
        };
    }
}
