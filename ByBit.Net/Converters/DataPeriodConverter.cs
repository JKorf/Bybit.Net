using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using System.Collections.Generic;

namespace Bybit.Net.Converters
{
    internal class DataPeriodConverter : BaseConverter<DataPeriod>
    {
        public DataPeriodConverter() : this(true) { }
        public DataPeriodConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<DataPeriod, string>> Mapping => new List<KeyValuePair<DataPeriod, string>>
        {
            new KeyValuePair<DataPeriod, string>(DataPeriod.FiveMinutes, "5min"),
            new KeyValuePair<DataPeriod, string>(DataPeriod.FifteenMinutes, "15min"),
            new KeyValuePair<DataPeriod, string>(DataPeriod.ThirtyMinutes, "30min"),
            new KeyValuePair<DataPeriod, string>(DataPeriod.OneHour, "1h"),
            new KeyValuePair<DataPeriod, string>(DataPeriod.FourHours, "4h"),
            new KeyValuePair<DataPeriod, string>(DataPeriod.OneDay, "1d"),
        };
    }
}
