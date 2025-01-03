using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Order status
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// Created
        /// </summary>
        [Map("CREATED", "Created")]
        Created,
        /// <summary>
        /// Rejected
        /// </summary>
        [Map("ORDER_FAILED", "REJECTED", "Rejected")]
        Rejected,
        /// <summary>
        /// New
        /// </summary>
        [Map("ORDER_NEW", "PENDING_NEW", "New")]
        New,
        /// <summary>
        /// Partially filled
        /// </summary>
        [Map("PARTIALLY_FILLED", "PartiallyFilled")]
        PartiallyFilled,
        /// <summary>
        /// Fully filled
        /// </summary>
        [Map("ORDER_FILLED", "FILLED", "Filled")]
        Filled,
        /// <summary>
        /// Canceled
        /// </summary>
        [Map("ORDER_CANCELED", "CANCELED", "Cancelled")]
        Canceled,
        /// <summary>
        /// Pending cancel
        /// </summary>
        [Map("PENDING_CANCEL", "PendingCancel")]
        PendingCancel,
        /// <summary>
        /// Market order was filled to near qty and the remaining USDT retrurned back 
        /// </summary>
        [Map("PARTIALLY_FILLED_CANCELED")]
        PartiallyFilledCanceled,
        /// <summary>
        /// Untriggered
        /// </summary>
        [Map("UnTriggered")]
        UnTriggered
    }
}
