using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using System.Collections.Generic;

namespace Bybit.Net.Converters
{
    internal class TriggerTypeConverter : BaseConverter<TriggerType>
    {
        public TriggerTypeConverter() : this(true) { }
        public TriggerTypeConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<TriggerType, string>> Mapping => new List<KeyValuePair<TriggerType, string>>
        {
            new KeyValuePair<TriggerType, string>(TriggerType.LastPrice, "LastPrice"),
            new KeyValuePair<TriggerType, string>(TriggerType.MarkPrice, "MarkPrice"),
            new KeyValuePair<TriggerType, string>(TriggerType.IndexPrice, "IndexPrice"),
            new KeyValuePair<TriggerType, string>(TriggerType.Unknown, "UNKNOWN"),
            new KeyValuePair<TriggerType, string>(TriggerType.Unknown, "0"),
        };
    }
}
