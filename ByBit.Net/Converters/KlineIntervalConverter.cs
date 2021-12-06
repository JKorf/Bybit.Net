using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using System.Collections.Generic;

namespace Bybit.Net.Converters
{
    internal class KlineIntervalConverter : BaseConverter<KlineInterval>
    {
        public KlineIntervalConverter() : this(true) { }
        public KlineIntervalConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<KlineInterval, string>> Mapping => new List<KeyValuePair<KlineInterval, string>>
        {
            new KeyValuePair<KlineInterval, string>(KlineInterval.OneMinute, "1"),
            new KeyValuePair<KlineInterval, string>(KlineInterval.ThreeMinutes, "3"),
            new KeyValuePair<KlineInterval, string>(KlineInterval.FiveMinutes, "5"),
            new KeyValuePair<KlineInterval, string>(KlineInterval.FifteenMinutes, "15"),
            new KeyValuePair<KlineInterval, string>(KlineInterval.ThirtyMinutes, "30"),
            new KeyValuePair<KlineInterval, string>(KlineInterval.OneHour, "60"),
            new KeyValuePair<KlineInterval, string>(KlineInterval.TwoHours, "120"),
            new KeyValuePair<KlineInterval, string>(KlineInterval.FourHours, "240"),
            new KeyValuePair<KlineInterval, string>(KlineInterval.SixHours, "360"),
            new KeyValuePair<KlineInterval, string>(KlineInterval.TwelveHours, "720"),
            new KeyValuePair<KlineInterval, string>(KlineInterval.OneDay, "D"),
            new KeyValuePair<KlineInterval, string>(KlineInterval.OneWeek, "W"),
            new KeyValuePair<KlineInterval, string>(KlineInterval.OneMonth, "M"),
        };
    }
}
