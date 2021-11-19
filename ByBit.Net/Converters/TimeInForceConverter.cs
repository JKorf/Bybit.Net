using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using System.Collections.Generic;

namespace Bybit.Net.Converters
{
    internal class TimeInForceConverter : BaseConverter<TimeInForce>
    {
        public TimeInForceConverter() : this(true) { }
        public TimeInForceConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<TimeInForce, string>> Mapping => new List<KeyValuePair<TimeInForce, string>>
        {
            new KeyValuePair<TimeInForce, string>(TimeInForce.GoodTillCanceled, "GoodTillCancel"),
            new KeyValuePair<TimeInForce, string>(TimeInForce.ImmediateOrCancel, "ImmediateOrCancel"),
            new KeyValuePair<TimeInForce, string>(TimeInForce.FillOrKill, "FillOrKill"),
            new KeyValuePair<TimeInForce, string>(TimeInForce.PostOnly, "PostOnly")
        };
    }
}
