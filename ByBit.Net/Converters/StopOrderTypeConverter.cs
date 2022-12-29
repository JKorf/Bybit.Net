using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using System.Collections.Generic;

namespace Bybit.Net.Converters
{
    internal class StopOrderTypeConverter : BaseConverter<StopOrderType>
    {
        public StopOrderTypeConverter() : this(true) { }
        public StopOrderTypeConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<StopOrderType, string>> Mapping => new List<KeyValuePair<StopOrderType, string>>
        {
            new KeyValuePair<StopOrderType, string>(StopOrderType.TakeProfit, "TakeProfit"),
            new KeyValuePair<StopOrderType, string>(StopOrderType.StopLoss, "StopLoss"),
            new KeyValuePair<StopOrderType, string>(StopOrderType.TrailingStop, "TrailingStop"),
            new KeyValuePair<StopOrderType, string>(StopOrderType.Stop, "Stop"),
            new KeyValuePair<StopOrderType, string>(StopOrderType.PartialStopLoss, "PartialStopLoss"),
            new KeyValuePair<StopOrderType, string>(StopOrderType.Unknown, "Unknown"),
        };
    }
}
