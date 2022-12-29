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
        Created,
        /// <summary>
        /// Rejected
        /// </summary>
        [Map("ORDER_FAILED")]
        Rejected,
        /// <summary>
        /// New
        /// </summary>
        [Map("ORDER_NEW")]
        New,
        /// <summary>
        /// Partially filled
        /// </summary>
        PartiallyFilled,
        /// <summary>
        /// Fully filled
        /// </summary>
        [Map("ORDER_FILLED")]
        Filled,
        /// <summary>
        /// Canceled
        /// </summary>
        [Map("ORDER_CANCELED")]
        Canceled,
        /// <summary>
        /// Pending cancel
        /// </summary>
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
