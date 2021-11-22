using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using System.Collections.Generic;

namespace Bybit.Net.Converters
{
    internal class StopLossTakeProfitModeConverter : BaseConverter<StopLossTakeProfitMode>
    {
        public StopLossTakeProfitModeConverter() : this(true) { }
        public StopLossTakeProfitModeConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<StopLossTakeProfitMode, string>> Mapping => new List<KeyValuePair<StopLossTakeProfitMode, string>>
        {
            new KeyValuePair<StopLossTakeProfitMode, string>(StopLossTakeProfitMode.Full, "Full"),
            new KeyValuePair<StopLossTakeProfitMode, string>(StopLossTakeProfitMode.Partial, "Partial"),
        };
    }
}
