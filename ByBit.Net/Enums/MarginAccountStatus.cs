
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Margin account status
    /// </summary>
    public enum MarginAccountStatus
    {
        /// <summary>
        /// Normal
        /// </summary>
        [Map("1")]
        Normal,
        /// <summary>
        /// Withdrawal/Transfer Restricted
        /// </summary>
        [Map("2")]
        WithdrawalTransferRestricted,
        /// <summary>
        /// Liquidation Alert Triggered
        /// </summary>
        [Map("3")]
        LiquidationAlert,
        /// <summary>
        /// Liquidated 
        /// </summary>
        [Map("4")]
        Liquidated,
        /// <summary>
        /// Negative Equity
        /// </summary>
        [Map("5")]
        NegativeEquity
    }
}
