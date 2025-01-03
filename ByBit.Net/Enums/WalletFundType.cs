using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Wallet funding type
    /// </summary>
    public enum WalletFundType
    {
        /// <summary>
        /// Deposit
        /// </summary>
        [Map("Deposit")]
        Deposit,
        /// <summary>
        /// Withdrawal
        /// </summary>
        [Map("Withdrawal")]
        Withdrawal,
        /// <summary>
        /// Realized profit and loss
        /// </summary>
        [Map("RealisedPNL")]
        RealizedPnl,
        /// <summary>
        /// Commission
        /// </summary>
        [Map("Commission")]
        Commission,
        /// <summary>
        /// Refund
        /// </summary>
        [Map("Refund")]
        Refund,
        /// <summary>
        /// PRize
        /// </summary>
        [Map("Prize")]
        Prize,
        /// <summary>
        /// Exchange order withdraw
        /// </summary>
        [Map("ExchangeOrderWithdraw")]
        ExchangeOrderWithdraw,
        /// <summary>
        /// Exchange order deposit
        /// </summary>
        [Map("ExchangeOrderDeposit")]
        ExchangeOrderDeposit,
        /// <summary>
        /// Refund of handling fee bonus
        /// </summary>
        [Map("ReturnServiceCash")]
        ReturnServiceCash,
        /// <summary>
        /// Insurance account transfer
        /// </summary>
        [Map("Insurance")]
        Insurance,
        /// <summary>
        /// Mother-child account transfer
        /// </summary>
        [Map("SubMember")]
        SubMember,
        /// <summary>
        /// Coupon interest
        /// </summary>
        [Map("Coupon")]
        Coupon,
        /// <summary>
        /// Account transfer
        /// </summary>
        [Map("AccountTransfer")]
        AccountTransfer,
        /// <summary>
        /// Bash back
        /// </summary>
        [Map("CashBack")]
        Cashback
    }
}
