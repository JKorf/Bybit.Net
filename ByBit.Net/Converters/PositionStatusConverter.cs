using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using System.Collections.Generic;

namespace Bybit.Net.Converters
{
    internal class PositionStatusConverter : BaseConverter<PositionStatus>
    {
        public PositionStatusConverter() : this(true) { }
        public PositionStatusConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<PositionStatus, string>> Mapping => new List<KeyValuePair<PositionStatus, string>>
        {
            new KeyValuePair<PositionStatus, string>(PositionStatus.Normal, "Normal"),
            new KeyValuePair<PositionStatus, string>(PositionStatus.Liqidation, "Liq"),
            new KeyValuePair<PositionStatus, string>(PositionStatus.AutoDeleverage, "Adl")
        };
    }
}
