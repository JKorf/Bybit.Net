using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Transaction log type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<TransactionLogType>))]
    public enum TransactionLogType
    {
        /// <summary>
        /// ["<c>TRANSFER_IN</c>"] Transfer in
        /// </summary>
        [Map("TRANSFER_IN")]
        TransferIn,
        /// <summary>
        /// ["<c>TRANSFER_OUT</c>"] Transfer out
        /// </summary>
        [Map("TRANSFER_OUT")]
        TransferOut,
        /// <summary>
        /// ["<c>TRADE</c>"] Trade
        /// </summary>
        [Map("TRADE")]
        Trade,
        /// <summary>
        /// ["<c>SETTLEMENT</c>"] Settlement
        /// </summary>
        [Map("SETTLEMENT")]
        Settlement,
        /// <summary>
        /// ["<c>DELIVERY</c>"] Delivery
        /// </summary>
        [Map("DELIVERY")]
        Delivery,
        /// <summary>
        /// ["<c>LIQUIDATION</c>"] Liquidation
        /// </summary>
        [Map("LIQUIDATION")]
        Liquidation,
        /// <summary>
        /// ["<c>ADL</c>"] Auto deleveraging
        /// </summary>
        [Map("ADL")]
        Adl,
        /// <summary>
        /// ["<c>AIRDROP</c>"] Airdrop
        /// </summary>
        [Map("AIRDROP")]
        Airdrop,
        /// <summary>
        /// ["<c>BONUS</c>"] Bonus
        /// </summary>
        [Map("BONUS")]
        Bonus,
        /// <summary>
        /// ["<c>BONUS_RECOLLECT</c>"] Bonus expired
        /// </summary>
        [Map("BONUS_RECOLLECT")]
        BonusRecollect,
        /// <summary>
        /// ["<c>FEE_REFUND</c>"] Fee refund
        /// </summary>
        [Map("FEE_REFUND")]
        FeeRefund,
        /// <summary>
        /// ["<c>INTEREST</c>"] Interest
        /// </summary>
        [Map("INTEREST")]
        Interest,
        /// <summary>
        /// ["<c>CURRENCY_BUY</c>"] Currency buy
        /// </summary>
        [Map("CURRENCY_BUY")]
        CurrencyBuy,
        /// <summary>
        /// ["<c>CURRENCY_SELL</c>"] Currency sell
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
        /// <summary>
        /// </summary>
        [Map("LOANS_PLEDGE_ASSET")]
        LoansPledgeAsset,
        /// <summary>
        /// </summary>
        [Map("FLEXIBLE_STAKING_REFUND")]
        FlexibleStakingRefund,
        /// <summary>
        /// </summary>
        [Map("FIXED_STAKING_REFUND")]
        FixedStakingRefund,
        /// <summary>
        /// </summary>
        [Map("BONUS_TRANSFER_IN")]
        BonusTransferIn,
        /// <summary>
        /// </summary>
        [Map("BONUS_TRANSFER_OUT")]
        BonusTransferOut,
        /// <summary>
        /// </summary>
        [Map("PEF_TRANSFER_IN")]
        PefTransferIn,
        /// <summary>
        /// </summary>
        [Map("PEF_TRANSFER_OUT")]
        PefTransferOut,
        /// <summary>
        /// </summary>
        [Map("PEF_PROFIT_SHARE")]
        PefProfitShare,
        /// <summary>
        /// </summary>
        [Map("ONCHAINEARN_SUBSCRIPTION")]
        OnChainEarnTransferOut,
        /// <summary>
        /// </summary>
        [Map("ONCHAINEARN_REDEMPTION")]
        OnChainEarnTransferIn,
        /// <summary>
        /// </summary>
        [Map("ONCHAINEARN_REFUND")]
        OnChainEarnRefund,
        /// <summary>
        /// </summary>
        [Map("STRUCTURE_PRODUCT_SUBSCRIPTION")]
        StructureProductTransferOut,
        /// <summary>
        /// </summary>
        [Map("STRUCTURE_PRODUCT_REFUND")]
        StructureProductTransferIn,
        /// <summary>
        /// </summary>
        [Map("CLASSIC_WEALTH_MANAGEMENT_SUBSCRIPTION")]
        ClassicWealthManagementTransferIn,
        /// <summary>
        /// </summary>
        [Map("PREMIMUM_WEALTH_MANAGEMENT_SUBSCRIPTION")]
        PremiumWealthManagementTransferIn,
        /// <summary>
        /// </summary>
        [Map("PREMIMUM_WEALTH_MANAGEMENT_REFUND")]
        PremiumWealthManagementRefund,
        /// <summary>
        /// </summary>
        [Map("LIQUIDITY_MINING_SUBSCRIPTION")]
        LiquidityMiningTransferOut,
        /// <summary>
        /// </summary>
        [Map("LIQUIDITY_MINING_REFUND")]
        LiquidityMiningRefund,
        /// <summary>
        /// </summary>
        [Map("PWM_SUBSCRIPTION")]
        PwmTransferOut,
        /// <summary>
        /// </summary>
        [Map("PWM_REFUND")]
        PwmRefund,
        /// <summary>
        /// </summary>
        [Map("DEFI_INVESTMENT_SUBSCRIPTION")]
        DefiInvestmentTransferOut,
        /// <summary>
        /// </summary>
        [Map("DEFI_INVESTMENT_REFUND")]
        DefiInvestmentRefund,
        /// <summary>
        /// </summary>
        [Map("DEFI_INVESTMENT_REDEMPTION")]
        DefiInvestmentTransferIn,
        /// <summary>
        /// </summary>
        [Map("DIVIDEND_SETTLEMENT")]
        DividendSettlement,
    }
}
