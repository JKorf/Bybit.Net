﻿using CryptoExchange.Net.Attributes;

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
        /// Auto deleveraging
        /// </summary>
        [Map("ADL")]
        Adl,
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
        /// Currency sell
        /// </summary>
        [Map("CURRENCY_SELL")]
        CurrencySell,
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
        FixedStakingSubscription,
        /// <summary>
        /// </summary>
        [Map("PREMARKET_TRANSFER_OUT")]
        PreMarketTransferOut,
        /// <summary>
        /// </summary>
        [Map("PREMARKET_DELIVERY_SELL_NEW_COIN")]
        PreMarketDeliverySellNewAsset,
        /// <summary>
        /// </summary>
        [Map("PREMARKET_DELIVERY_BUY_NEW_COIN")]
        PreMarketDeliveryBuyNewAsset,
        /// <summary>
        /// </summary>
        [Map("PREMARKET_DELIVERY_PLEDGE_PAY_SELLER")]
        PreMarketDeliveryPledgePaySeller,
        /// <summary>
        /// </summary>
        [Map("PREMARKET_DELIVERY_PLEDGE_BACK")]
        PreMarketDeliveryPledgeBack,
        /// <summary>
        /// </summary>
        [Map("PREMARKET_ROLLBACK_PLEDGE_BACK")]
        PreMarketRollbackPledgeBack,
        /// <summary>
        /// </summary>
        [Map("PREMARKET_ROLLBACK_PLEDGE_PENALTY_TO_BUYER")]
        PreMarketRollbackPledgePenaltyToBuyer,
        /// <summary>
        /// </summary>
        [Map("CUSTODY_NETWORK_FEE")]
        CustodyNetworkFee,
        /// <summary>
        /// </summary>
        [Map("CUSTODY_SETTLE_FEE")]
        CustodySettleFee,
        /// <summary>
        /// </summary>
        [Map("CUSTODY_LOCK")]
        CustodyLock,
        /// <summary>
        /// </summary>
        [Map("CUSTODY_UNLOCK")]
        CustodyUnlock,
        /// <summary>
        /// </summary>
        [Map("CUSTODY_UNLOCK_REFUND")]
        CustodyUnlockRefund,
        /// <summary>
        /// </summary>
        [Map("LOANS_BORROW_FUNDS")]
        LoansBorrowFunds,
        /// <summary>
        /// </summary>
        [Map("LOANS_ASSET_REDEMPTION")]
        LoansAssetRedemption,
    }
}
