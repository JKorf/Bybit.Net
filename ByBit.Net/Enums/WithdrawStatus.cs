using CryptoExchange.Net.Attributes;

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
        [Map("ToBeConfirmed")]
        ToBeConfirmed,
        /// <summary>
        /// Under review
        /// </summary>
        [Map("UnderReview")]
        UnderReview,
        /// <summary>
        /// Pending
        /// </summary>
        [Map("Pending")]
        Pending,
        /// <summary>
        /// Success
        /// </summary>
        [Map("Success")]
        Success,
        /// <summary>
        /// Canceled by used
        /// </summary>
        [Map("CancelByUser")]
        CanceledByUser,
        /// <summary>
        /// Rejected
        /// </summary>
        [Map("Reject")]
        Rejected,
        /// <summary>
        /// Expired
        /// </summary>
        [Map("Expire")]
        Expired
    }
}
