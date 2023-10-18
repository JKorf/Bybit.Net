using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Account mode
    /// </summary>
    public enum AccountMode
    {
        /// <summary>
        /// Classic
        /// </summary>
        [Map("1")]
        Classic,
        /// <summary>
        /// UMA
        /// </summary>
        [Map("2")]
        UniversalMarginAccount,
        /// <summary>
        /// UTA
        /// </summary>
        [Map("3")]
        UniversalTransferAccount
    }
}
