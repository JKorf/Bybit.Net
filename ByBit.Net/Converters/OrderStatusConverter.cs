using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using System.Collections.Generic;

namespace Bybit.Net.Converters
{
    internal class OrderStatusConverter : BaseConverter<OrderStatus>
    {
        public OrderStatusConverter() : this(true) { }
        public OrderStatusConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<OrderStatus, string>> Mapping => new List<KeyValuePair<OrderStatus, string>>
        {
            new KeyValuePair<OrderStatus, string>(OrderStatus.Created, "Created"),
            new KeyValuePair<OrderStatus, string>(OrderStatus.Rejected, "Rejected"),
            new KeyValuePair<OrderStatus, string>(OrderStatus.New, "New"),
            new KeyValuePair<OrderStatus, string>(OrderStatus.PartiallyFilled, "PartiallyFilled"),
            new KeyValuePair<OrderStatus, string>(OrderStatus.Filled, "Filled"),
            new KeyValuePair<OrderStatus, string>(OrderStatus.Canceled, "Cancelled"),
            new KeyValuePair<OrderStatus, string>(OrderStatus.PendingCancel, "PendingCancel"),
            new KeyValuePair<OrderStatus, string>(OrderStatus.UnTriggered, "UnTriggered")
        };
    }
}
