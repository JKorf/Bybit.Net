using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using System.Collections.Generic;

namespace Bybit.Net.Converters
{
    internal class TimeInForceSpotConverter : BaseConverter<TimeInForce>
    {
        public TimeInForceSpotConverter() : this(true) { }
        public TimeInForceSpotConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<TimeInForce, string>> Mapping => new List<KeyValuePair<TimeInForce, string>>
        {
            new KeyValuePair<TimeInForce, string>(TimeInForce.GoodTillCanceled, "GTC"),
            new KeyValuePair<TimeInForce, string>(TimeInForce.ImmediateOrCancel, "IOC"),
            new KeyValuePair<TimeInForce, string>(TimeInForce.FillOrKill, "FOK")
        };
    }
}
