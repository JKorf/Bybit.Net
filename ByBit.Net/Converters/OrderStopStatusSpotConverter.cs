using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using System.Collections.Generic;

namespace Bybit.Net.Converters
{
    /// <summary>
    /// Converter for SLTP order statuses
    /// </summary>
    internal class OrderStopStatusSpotConverter : BaseConverter<OrderStatus>
    {
        public OrderStopStatusSpotConverter() : this(true) { }
        public OrderStopStatusSpotConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<OrderStatus, string>> Mapping => new List<KeyValuePair<OrderStatus, string>>
        {
            new KeyValuePair<OrderStatus, string>(OrderStatus.New, "ORDER_NEW"),
            new KeyValuePair<OrderStatus, string>(OrderStatus.Canceled, "ORDER_CANCELED"),
            new KeyValuePair<OrderStatus, string>(OrderStatus.Filled, "ORDER_FILLED"),
            new KeyValuePair<OrderStatus, string>(OrderStatus.Rejected, " ORDER_FAILED"),
        };
    }
}
