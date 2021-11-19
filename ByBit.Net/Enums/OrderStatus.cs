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
        Rejected,
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
        /// Canceled
        /// </summary>
        Canceled,
        /// <summary>
        /// Pending cancel
        /// </summary>
        PendingCancel
    }
}
