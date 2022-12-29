using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using System.Collections.Generic;

namespace Bybit.Net.Converters
{
    internal class OrderStatusSpotConverter : BaseConverter<OrderStatus>
    {
        public OrderStatusSpotConverter() : this(true) { }
        public OrderStatusSpotConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<OrderStatus, string>> Mapping => new List<KeyValuePair<OrderStatus, string>>
        {
            new KeyValuePair<OrderStatus, string>(OrderStatus.Created, "CREATED"),
            new KeyValuePair<OrderStatus, string>(OrderStatus.Rejected, "REJECTED"),
            new KeyValuePair<OrderStatus, string>(OrderStatus.New, "NEW"),
            new KeyValuePair<OrderStatus, string>(OrderStatus.New, "PENDING_NEW"),
            new KeyValuePair<OrderStatus, string>(OrderStatus.PartiallyFilled, "PARTIALLY_FILLED"),
            new KeyValuePair<OrderStatus, string>(OrderStatus.Filled, "FILLED"),
            new KeyValuePair<OrderStatus, string>(OrderStatus.Canceled, "CANCELED"),
            new KeyValuePair<OrderStatus, string>(OrderStatus.PendingCancel, "PENDING_CANCEL"),
            new KeyValuePair<OrderStatus, string>(OrderStatus.PartiallyFilledCanceled, "PARTIALLY_FILLED_CANCELED"),
        };
    }
}