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
        /// Airdrop
        /// </summary>
        [Map("AIRDROP")]
        Airdrop,
        /// <summary>
        /// Bonus
        /// </summary>
        [Map("BONUS")]
        Bonus,
        /// <summary>
        /// Bonus expired
        /// </summary>
        [Map("BONUS_RECOLLECT")]
        BonusRecollect,
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
        /// </summary>
        [Map("BORROWED_AMOUNT_INS_LOAN")]
        BorrowedAmountInsLoan,
        /// <summary>
        /// </summary>
        [Map("PRINCIPLE_REPAYMENT_INS_LOAN")]
        PrincipleRepaymentInsLoan,
        /// <summary>
        /// </summary>
        [Map("INTEREST_REPAYMENT_INS_LOAN")]
        InterestRepaymentInsLoan,
        /// <summary>
        /// </summary>
        [Map("AUTO_SOLD_COLLATERAL_INS_LOAN")]
        AutoSoldCollateralInsLoan,
        /// <summary>
        /// </summary>
        [Map("AUTO_BUY_LIABILITY_INS_LOAN")]
        AutoBuyLiabilityInsLoan,
        /// <summary>
        /// </summary>
        [Map("AUTO_PRINCIPLE_REPAYMENT_INS_LOAN")]
        AutoPrincipleRepaymentInsLoan,
        /// <summary>
        /// </summary>
        [Map("AUTO_INTEREST_REPAYMENT_INS_LOAN")]
        AutoInterestRepaymentInsLoan,
        /// <summary>
        /// </summary>
        [Map("TRANSFER_IN_INS_LOAN")]
        TransferInInsLoan,
        /// <summary>
        /// </summary>
        [Map("TRANSFER_OUT_INS_LOAN")]
        TransferOutInsLoan,
        /// <summary>
        /// </summary>
        [Map("SPOT_REPAYMENT_SELL")]
        SpotRepaymentSell,
        /// <summary>
        /// </summary>
        [Map("SPOT_REPAYMENT_BUY")]
        SpotRepaymentBuy,
        /// <summary>
        /// </summary>
        [Map("TOKENS_SUBSCRIPTION")]
        TokensSubscription,
        /// <summary>
        /// </summary>
        [Map("TOKENS_REDEMPTION")]
        TokensRedemption,
        /// <summary>
        /// </summary>
        [Map("AUTO_DEDUCTION")]
        AutoDeduction,
        /// <summary>
        /// </summary>
        [Map("FLEXIBLE_STAKING_SUBSCRIPTION")]
        FlexibleStakingSubscription,
        /// <summary>
        /// </summary>
        [Map("FLEXIBLE_STAKING_REDEMPTION")]
        FlexibleStakingRedemption,
        /// <summary>
        /// </summary>
        [Map("FIXED_STAKING_SUBSCRIPTION")]
        FixedStakingSubscription
    }
}
