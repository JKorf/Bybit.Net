using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using System.Collections.Generic;
using System.Linq;

namespace Bybit.Net.Converters
{
    internal class KlineIntervalSpotConverter : BaseConverter<KlineInterval>
    {
        public KlineIntervalSpotConverter() : this(true) { }
        public KlineIntervalSpotConverter(bool quotes) : base(quotes) { }

        private static List<KeyValuePair<KlineInterval, string>> _mapping => new List<KeyValuePair<KlineInterval, string>>
        {
            new KeyValuePair<KlineInterval, string>(KlineInterval.OneMinute, "1m"),
            new KeyValuePair<KlineInterval, string>(KlineInterval.ThreeMinutes, "3m"),
            new KeyValuePair<KlineInterval, string>(KlineInterval.FiveMinutes, "5m"),
            new KeyValuePair<KlineInterval, string>(KlineInterval.FifteenMinutes, "15m"),
            new KeyValuePair<KlineInterval, string>(KlineInterval.ThirtyMinutes, "30m"),
            new KeyValuePair<KlineInterval, string>(KlineInterval.OneHour, "1h"),
            new KeyValuePair<KlineInterval, string>(KlineInterval.TwoHours, "2h"),
            new KeyValuePair<KlineInterval, string>(KlineInterval.FourHours, "4h"),
            new KeyValuePair<KlineInterval, string>(KlineInterval.SixHours, "6h"),
            new KeyValuePair<KlineInterval, string>(KlineInterval.TwelveHours, "12h"),
            new KeyValuePair<KlineInterval, string>(KlineInterval.OneDay, "1d"),
            new KeyValuePair<KlineInterval, string>(KlineInterval.OneWeek, "1w"),
            new KeyValuePair<KlineInterval, string>(KlineInterval.OneMonth, "1M"),
        };

        public static string ToString(KlineInterval interval)
        {
            return _mapping.First(x => x.Key == interval).Value;
        }

        protected override List<KeyValuePair<KlineInterval, string>> Mapping => new List<KeyValuePair<KlineInterval, string>>(_mapping);
    }
}
