using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Transaction log type
    /// </summary>
    public enum TransactionLogType
    {
        /// <summary>
        /// Transfer in
        /// </summary>
        [Map("TRANSFER_IN")]
        TransferIn,
        /// <summary>
        /// Transfer out
        /// </summary>
        [Map("TRANSFER_OUT")]
        TransferOut,
        /// <summary>
        /// Trade
        /// </summary>
        [Map("TRADE")]
        Trade,
        /// <summary>
        /// Settlement
        /// </summary>
        [Map("SETTLEMENT")]
        Settlement,
        /// <summary>
        /// Delivery
        /// </summary>
        [Map("DELIVERY")]
        Delivery,
        /// <summary>
        /// Liquidation
        /// </summary>
        [Map("LIQUIDATION")]
        Liquidation,
        /// <summary>
        /// Bonus
        /// </summary>
        [Map("BONUS")]
        Bonus,
        /// <summary>
        /// Fee refund
        /// </summary>
        [Map("FEE_REFUND")]
        FeeRefund,
        /// <summary>
        /// Interest
        /// </summary>
        [Map("INTEREST")]
        Interest,
        /// <summary>
        /// Currency buy
        /// </summary>
        [Map("CURRENCY_BUY")]
        CurrencyBuy,
        /// <summary>
        /// Currency sell
        /// </summary>
        [Map("CURRENCY_SELL")]
        CurrencySell
    }
}
