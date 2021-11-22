using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using System.Collections.Generic;

namespace Bybit.Net.Converters
{
    internal class StopOrderStatusConverter : BaseConverter<StopOrderStatus>
    {
        public StopOrderStatusConverter() : this(true) { }
        public StopOrderStatusConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<StopOrderStatus, string>> Mapping => new List<KeyValuePair<StopOrderStatus, string>>
        {
            new KeyValuePair<StopOrderStatus, string>(StopOrderStatus.Active, "Active"),
            new KeyValuePair<StopOrderStatus, string>(StopOrderStatus.Untriggered, "Untriggered"),
            new KeyValuePair<StopOrderStatus, string>(StopOrderStatus.Triggered, "Triggered"),
            new KeyValuePair<StopOrderStatus, string>(StopOrderStatus.Canceled, "Cancelled"),
            new KeyValuePair<StopOrderStatus, string>(StopOrderStatus.Rejected, "Rejected"),
            new KeyValuePair<StopOrderStatus, string>(StopOrderStatus.Deactivated, "Deactivated"),
        };
    }
}
