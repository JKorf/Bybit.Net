using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using System.Collections.Generic;

namespace Bybit.Net.Converters
{
    internal class PositionSideConverter : BaseConverter<PositionSide>
    {
        public PositionSideConverter() : this(true) { }
        public PositionSideConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<PositionSide, string>> Mapping => new List<KeyValuePair<PositionSide, string>>
        {
            new KeyValuePair<PositionSide, string>(PositionSide.Buy, "Buy"),
            new KeyValuePair<PositionSide, string>(PositionSide.Sell, "Sell"),
            new KeyValuePair<PositionSide, string>(PositionSide.None, "None"),
        };
    }
}
