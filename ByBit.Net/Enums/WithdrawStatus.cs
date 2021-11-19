namespace Bybit.Net.Enums
{
    /// <summary>
    /// Withdrawal status
    /// </summary>
    public enum WithdrawStatus
    {
        /// <summary>
        /// To be confirmed
        /// </summary>
        ToBeConfirmed,
        /// <summary>
        /// Under review
        /// </summary>
        UnderReview,
        /// <summary>
        /// Pending
        /// </summary>
        Pending,
        /// <summary>
        /// Success
        /// </summary>
        Success,
        /// <summary>
        /// Canceled by used
        /// </summary>
        CanceledByUser,
        /// <summary>
        /// Rejected
        /// </summary>
        Rejected,
        /// <summary>
        /// Expired
        /// </summary>
        Expired
    }
}
