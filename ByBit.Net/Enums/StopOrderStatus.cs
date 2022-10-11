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
        Active,
        /// <summary>
        /// Order yet to be triggered
        /// </summary>
        Untriggered,
        /// <summary>
        /// Order has been triggered by last traded price
        /// </summary>
        Triggered,
        /// <summary>
        /// Order has been canceled successfully
        /// </summary>
        Canceled,
        /// <summary>
        /// Order has been triggered but failed to be placed (e.g. due to insufficient margin)
        /// </summary>
        Rejected,
        /// <summary>
        /// Order has been canceled by the user before being triggered
        /// </summary>
        Deactivated,
        /// <summary>
        /// Created
        /// </summary>
        Created,
        /// <summary>
        /// New
        /// </summary>
        New,
        /// <summary>
        /// Partially filled
        /// </summary>
        PartiallyFilled,
        /// <summary>
        /// Fully filled
        /// </summary>
        Filled,
        /// <summary>
        /// Pending cancel
        /// </summary>
        PendingCancel
    }
}
