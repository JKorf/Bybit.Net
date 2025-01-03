using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Stop order status
    /// </summary>
    public enum StopOrderStatus
    {
        /// <summary>
        /// Order has been triggered and the new active order has been successfully placed. Is the final state of a successful conditional order
        /// </summary>
        [Map("Active")]
        Active,
        /// <summary>
        /// Order yet to be triggered
        /// </summary>
        [Map("Untriggered")]
        Untriggered,
        /// <summary>
        /// Order has been triggered by last traded price
        /// </summary>
        [Map("Triggered")]
        Triggered,
        /// <summary>
        /// Order has been canceled successfully
        /// </summary>
        [Map("Cancelled")]
        Canceled,
        /// <summary>
        /// Order has been triggered but failed to be placed (e.g. due to insufficient margin)
        /// </summary>
        [Map("Rejected")]
        Rejected,
        /// <summary>
        /// Order has been canceled by the user before being triggered
        /// </summary>
        [Map("Deactivated")]
        Deactivated,
        /// <summary>
        /// Created
        /// </summary>
        [Map("Created")]
        Created,
        /// <summary>
        /// New
        /// </summary>
        [Map("New")]
        New,
        /// <summary>
        /// Partially filled
        /// </summary>
        [Map("PartiallyFilled")]
        PartiallyFilled,
        /// <summary>
        /// Fully filled
        /// </summary>
        [Map("Filled")]
        Filled,
        /// <summary>
        /// Pending cancel
        /// </summary>
        [Map("PendingCancel")]
        PendingCancel
    }
}
