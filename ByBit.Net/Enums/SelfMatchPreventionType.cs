using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Self match prevention type
    /// </summary>
    public enum SelfMatchPreventionType
    {
        /// <summary>
        /// None
        /// </summary>
        [Map("None")]
        None,
        /// <summary>
        /// Cancel maker
        /// </summary>
        [Map("CancelMaker")]
        CancelMaker,
        /// <summary>
        /// Cancel taker
        /// </summary>
        [Map("CancelTaker")]
        CancelTaker,
        /// <summary>
        /// Cancel both
        /// </summary>
        [Map("CancelBoth")]
        CancelBoth
    }
}
