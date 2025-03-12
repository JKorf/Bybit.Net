using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Order status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<OrderStatus>))]
    public enum OrderStatus
    {
        /// <summary>
        /// Created but not yet in matching engine
        /// </summary>
        [Map("Created")]
        Created,
        /// <summary>
        /// Placed successfully
        /// </summary>
        [Map("New")]
        New,
        /// <summary>
        /// Rejected
        /// </summary>
        [Map("Rejected")]
        Rejected,
        /// <summary>
        /// Partially filled
        /// </summary>
        [Map("PartiallyFilled")]
        PartiallyFilled,
        /// <summary>
        /// Partially filled and cancelled
        /// </summary>
        [Map("PartiallyFilledCanceled")]
        PartiallyFilledCanceled,
        /// <summary>
        /// Filled
        /// </summary>
        [Map("Filled")]
        Filled,
        /// <summary>
        /// Cancelled
        /// </summary>
        [Map("Cancelled")]
        Cancelled,
        /// <summary>
        /// Untriggered
        /// </summary>
        [Map("Untriggered")]
        Untriggered,
        /// <summary>
        /// Triggered
        /// </summary>
        [Map("Triggered")]
        Triggered,
        /// <summary>
        /// Deactivated
        /// </summary>
        [Map("Deactivated")]
        Deactivated,
        /// <summary>
        /// Order has been triggered and the new active order has been successfully placed. Is the final state of a successful conditional order
        /// </summary>
        [Map("Active")]
        Active
    }
}
