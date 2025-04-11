using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Models.V5;
using Bybit.Net.Objects.Sockets;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bybit.Net.Converters
{
    [JsonSerializable(typeof(BybitExtResult<BybitList<BybitBatchOrderId>, BybitList<BybitBatchResult>>))]
    [JsonSerializable(typeof(BybitRequestQueryResponse<BybitList<BybitBatchOrderId>, BybitList<BybitBatchResult>>))]
    [JsonSerializable(typeof(BybitRequestQueryResponse<object>))]
    [JsonSerializable(typeof(BybitRequestQueryResponse<BybitOrderId>))]
    [JsonSerializable(typeof(BybitRequestQueryResponse<BybitList<BybitBatchOrderId>>))]
    [JsonSerializable(typeof(Dictionary<string, string[]>))]
    // End manual defined attributes

    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitBalance>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitBorrowHistory>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitCollateralInfo>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitGreeks>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitFeeRate>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitTransactionLog>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<string>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitTransfer>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitInternalDeposit>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitWithdrawal>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitSpotMarginBorrowRate>>))]
    [JsonSerializable(typeof(BybitResult<BybitList<BybitLiabilityRepayment>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitEarnProduct>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitEarnOrder>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitEarnStakedPosition>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitLoan>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitRepayment>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitLoanOrder>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitAdjustHistory>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitAnnouncement>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitKline>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitBasicKline>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitSpotSymbol>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitOptionSymbol>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitLinearInverseSymbol>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitSpotTicker>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitOptionTicker>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitLinearInverseTicker>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitFundingHistory>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitTradeHistory>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitOpenInterest>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitInsurance>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitRiskLimit>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitDeliveryPrice>>))]
    [JsonSerializable(typeof(BybitResult<BybitList<BybitLongShortRatio>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitSpotMarginCollateralRatio>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitOrder>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitOrderId>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitUserTrade>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitPosition>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitDeliveryRecord>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitSettlementRecord>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitClosedPnl>>))]
    [JsonSerializable(typeof(BybitResult<BybitResponse<BybitLeverageTokenHistory>>))]
    [JsonSerializable(typeof(BybitResult<BybitHistoricalVolatility[]>))]
    [JsonSerializable(typeof(BybitSpotSocketEvent<BybitOptionTrade[]>))]
    [JsonSerializable(typeof(BybitSpotSocketEvent<BybitKlineUpdate[]>))]
    [JsonSerializable(typeof(BybitSpotSocketEvent<BybitLiquidationUpdate[]>))]
    [JsonSerializable(typeof(BybitSpotSocketEvent<BybitTrade[]>))]
    [JsonSerializable(typeof(BybitSpotSocketEvent<BybitPositionUpdate[]>))]
    [JsonSerializable(typeof(BybitSpotSocketEvent<BybitUserTradeUpdate[]>))]
    [JsonSerializable(typeof(BybitSpotSocketEvent<BybitMinimalUserTradeUpdate[]>))]
    [JsonSerializable(typeof(BybitSpotSocketEvent<BybitOrderUpdate[]>))]
    [JsonSerializable(typeof(BybitSpotSocketEvent<BybitBalance[]>))]
    [JsonSerializable(typeof(BybitSpotSocketEvent<BybitGreeks[]>))]
    [JsonSerializable(typeof(BybitResult<BybitResult>))]
    [JsonSerializable(typeof(BybitResult<BybitTakeProfitStopLossMode>))]
    [JsonSerializable(typeof(BybitResult<BybitSetRiskLimit>))]
    [JsonSerializable(typeof(BybitResult<BybitAccountInfo>))]
    [JsonSerializable(typeof(BybitResult<BybitSetMarginModeResult>))]
    [JsonSerializable(typeof(BybitResult<BybitAssetInfoWrapper>))]
    [JsonSerializable(typeof(BybitResult<BybitAllAssetBalances>))]
    [JsonSerializable(typeof(BybitResult<BybitSingleAssetBalance>))]
    [JsonSerializable(typeof(BybitResult<BybitTransferId>))]
    [JsonSerializable(typeof(BybitResult<BybitAllowedDepositInfoResponse>))]
    [JsonSerializable(typeof(BybitResult<BybitOperationResult>))]
    [JsonSerializable(typeof(BybitResult<BybitDeposits>))]
    [JsonSerializable(typeof(BybitResult<BybitDepositAddress>))]
    [JsonSerializable(typeof(BybitResult<BybitUserAssetInfos>))]
    [JsonSerializable(typeof(BybitResult<BybitDelayedWithdrawal>))]
    [JsonSerializable(typeof(BybitResult<BybitId>))]
    [JsonSerializable(typeof(BybitResult<BybitApiKeyInfo>))]
    [JsonSerializable(typeof(BybitResult<BybitAccountTypeInfoWrapper>))]
    [JsonSerializable(typeof(BybitResult<BybitPosition>))]
    [JsonSerializable(typeof(BybitResult<BybitSpotMarginLeverageStatus>))]
    [JsonSerializable(typeof(BybitResult<BybitSpotMarginStatus>))]
    [JsonSerializable(typeof(BybitResult<BybitSpotMarginVipMarginData>))]
    [JsonSerializable(typeof(BybitResult<BybitBrokerAccountInfo>))]
    [JsonSerializable(typeof(BybitResult<BybitBrokerEarnings>))]
    [JsonSerializable(typeof(BybitResult<BybitConvertAssetWrapper>))]
    [JsonSerializable(typeof(BybitResult<BybitConvertQuote>))]
    [JsonSerializable(typeof(BybitResult<BybitConvertTransactionResult>))]
    [JsonSerializable(typeof(BybitResult<BybitConvertTransactionWrapper>))]
    [JsonSerializable(typeof(BybitResult<BybitConvertTransactionListWrapper>))]
    [JsonSerializable(typeof(BybitResult<BybitTransferable>))]
    [JsonSerializable(typeof(BybitResult<BybitOrderId>))]
    [JsonSerializable(typeof(BybitResult<BybitCollateralAssets>))]
    [JsonSerializable(typeof(BybitResult<BybitBorrowAssetWrapper>))]
    [JsonSerializable(typeof(BybitResult<BybitBorrowLimits>))]
    [JsonSerializable(typeof(BybitResult<BybitRepayId>))]
    [JsonSerializable(typeof(BybitResult<BybitMaxCollateral>))]
    [JsonSerializable(typeof(BybitResult<BybitAdjustId>))]
    [JsonSerializable(typeof(BybitResult<BybitTime>))]
    [JsonSerializable(typeof(BybitResult<BybitOrderbook>))]
    [JsonSerializable(typeof(BybitResult<BybitLeverageTokenWrapper>))]
    [JsonSerializable(typeof(BybitResult<BybitLeverageTokenMarket>))]
    [JsonSerializable(typeof(BybitResult<BybitSubAccount>))]
    [JsonSerializable(typeof(BybitResult<BybitSubAccountWrapper>))]
    [JsonSerializable(typeof(BybitResult<BybitBorrowQuota>))]
    [JsonSerializable(typeof(BybitResult<BybitDcpStatusWrapper>))]
    [JsonSerializable(typeof(BybitResult<BybitAssetExchageWrapper>))]
    [JsonSerializable(typeof(BybitResult<BybitLeverageTokenPurchase>))]
    [JsonSerializable(typeof(BybitResult<BybitLeverageTokenRedemption>))]
    [JsonSerializable(typeof(BybitSpotSocketEvent<BybitOptionTickerUpdate>))]
    [JsonSerializable(typeof(BybitSpotSocketEvent<BybitOrderbook>))]
    [JsonSerializable(typeof(BybitSpotSocketEvent<BybitLiquidation>))]
    [JsonSerializable(typeof(BybitSpotSocketEvent<BybitLinearTickerUpdate>))]
    [JsonSerializable(typeof(BybitSpotSocketEvent<object>))]
    [JsonSerializable(typeof(BybitSpotSocketEvent<BybitSpotTickerUpdate>))]
    [JsonSerializable(typeof(BybitSpotSocketEvent<BybitLeveragedTokenTicker>))]
    [JsonSerializable(typeof(BybitSpotSocketEvent<BybitLeveragedTokenNav>))]
    [JsonSerializable(typeof(IDictionary<string, object>))]
    [JsonSerializable(typeof(BybitBatchResult<BybitBatchOrderId>))]
    [JsonSerializable(typeof(BybitAccountInfo[]))]
    [JsonSerializable(typeof(BybitAccountTypeInfoWrapper[]))]
    [JsonSerializable(typeof(BybitAccountTypeInfo[]))]
    [JsonSerializable(typeof(BybitAdjustHistory[]))]
    [JsonSerializable(typeof(BybitAdjustId[]))]
    [JsonSerializable(typeof(BybitAllowedDepositInfoResponse[]))]
    [JsonSerializable(typeof(BybitAllowedDepositInfo[]))]
    [JsonSerializable(typeof(BybitAnnouncement[]))]
    [JsonSerializable(typeof(BybitApiKeyInfo[]))]
    [JsonSerializable(typeof(BybitPermissions[]))]
    [JsonSerializable(typeof(BybitAllAssetBalances[]))]
    [JsonSerializable(typeof(BybitSingleAssetBalance[]))]
    [JsonSerializable(typeof(BybitAssetAccountBalance[]))]
    [JsonSerializable(typeof(BybitAssetExchageWrapper[]))]
    [JsonSerializable(typeof(BybitAssetExchange[]))]
    [JsonSerializable(typeof(BybitAssetInfoWrapper[]))]
    [JsonSerializable(typeof(BybitAccountAssetInfo[]))]
    [JsonSerializable(typeof(BybitAssetInfo[]))]
    [JsonSerializable(typeof(BybitAssetBalance[]))]
    [JsonSerializable(typeof(BybitBasicKline[]))]
    [JsonSerializable(typeof(BybitBatchOrderId[]))]
    [JsonSerializable(typeof(BybitBatchResult[]))]
    [JsonSerializable(typeof(BybitBorrowAssetWrapper[]))]
    [JsonSerializable(typeof(BybitBorrowAsset[]))]
    [JsonSerializable(typeof(BybitBorrowAssetInfo[]))]
    [JsonSerializable(typeof(BybitBorrowHistory[]))]
    [JsonSerializable(typeof(BybitBorrowLimits[]))]
    [JsonSerializable(typeof(BybitBorrowQuota[]))]
    [JsonSerializable(typeof(BybitBrokerAccountInfo[]))]
    [JsonSerializable(typeof(BybitBrokerRebateRate[]))]
    [JsonSerializable(typeof(BybitBrokerEarnings[]))]
    [JsonSerializable(typeof(BybitTotalEarnings[]))]
    [JsonSerializable(typeof(BybitBrokerEarning[]))]
    [JsonSerializable(typeof(BybitEarningDetails[]))]
    [JsonSerializable(typeof(BybitCancelOrderRequest[]))]
    [JsonSerializable(typeof(BybitSocketCancelOrderRequest[]))]
    [JsonSerializable(typeof(BybitClosedPnl[]))]
    [JsonSerializable(typeof(BybitCollateralAssets[]))]
    [JsonSerializable(typeof(BybitCollateralAsset[]))]
    [JsonSerializable(typeof(BybitCollateralAssetInfo[]))]
    [JsonSerializable(typeof(BybitCollateralInfo[]))]
    [JsonSerializable(typeof(BybitConvertAssetWrapper[]))]
    [JsonSerializable(typeof(BybitConvertAsset[]))]
    [JsonSerializable(typeof(BybitConvertQuote[]))]
    [JsonSerializable(typeof(BybitConvertTransactionWrapper[]))]
    [JsonSerializable(typeof(BybitConvertTransactionListWrapper[]))]
    [JsonSerializable(typeof(BybitConvertTransaction[]))]
    [JsonSerializable(typeof(BybitConvertTransactionResult[]))]
    [JsonSerializable(typeof(BybitDcpStatusWrapper[]))]
    [JsonSerializable(typeof(BybitDcpStatus[]))]
    [JsonSerializable(typeof(BybitDelayedWithdrawal[]))]
    [JsonSerializable(typeof(BybitDelayedWithdrawalQuantities[]))]
    [JsonSerializable(typeof(BybitDelayedWithdrawalQuantity[]))]
    [JsonSerializable(typeof(BybitDeliveryPrice[]))]
    [JsonSerializable(typeof(BybitDeliveryRecord[]))]
    [JsonSerializable(typeof(BybitDeposits[]))]
    [JsonSerializable(typeof(BybitDeposit[]))]
    [JsonSerializable(typeof(BybitDepositAddress[]))]
    [JsonSerializable(typeof(BybitDepositChainAddress[]))]
    [JsonSerializable(typeof(BybitEarnOrder[]))]
    [JsonSerializable(typeof(BybitEarnProduct[]))]
    [JsonSerializable(typeof(BybitEarnStakedPosition[]))]
    [JsonSerializable(typeof(BybitEditOrderRequest[]))]
    [JsonSerializable(typeof(BybitSocketEditOrderRequest[]))]
    [JsonSerializable(typeof(BybitFeeRate[]))]
    [JsonSerializable(typeof(BybitFundingHistory[]))]
    [JsonSerializable(typeof(BybitId[]))]
    [JsonSerializable(typeof(BybitInsurance[]))]
    [JsonSerializable(typeof(BybitInternalDeposit[]))]
    [JsonSerializable(typeof(BybitKline[]))]
    [JsonSerializable(typeof(BybitLeveragedTokenNav[]))]
    [JsonSerializable(typeof(BybitLeveragedTokenTicker[]))]
    [JsonSerializable(typeof(BybitLeverageTokenWrapper[]))]
    [JsonSerializable(typeof(BybitLeverageToken[]))]
    [JsonSerializable(typeof(BybitLeverageTokenHistory[]))]
    [JsonSerializable(typeof(BybitLeverageTokenMarket[]))]
    [JsonSerializable(typeof(BybitLeverageTokenRecord[]))]
    [JsonSerializable(typeof(BybitLeverageTokenPurchase[]))]
    [JsonSerializable(typeof(BybitLeverageTokenRedemption[]))]
    [JsonSerializable(typeof(BybitLiabilityRepayment[]))]
    [JsonSerializable(typeof(BybitLinearInverseSymbol[]))]
    [JsonSerializable(typeof(BybitRiskParameters[]))]
    [JsonSerializable(typeof(BybitPrelistingInfo[]))]
    [JsonSerializable(typeof(BybitPrelistingFees[]))]
    [JsonSerializable(typeof(BybitPrelistingPhase[]))]
    [JsonSerializable(typeof(BybitLinearInverseLeveragefilter[]))]
    [JsonSerializable(typeof(BybitLinearInverseLotSizeFilter[]))]
    [JsonSerializable(typeof(BybitLinearInversePriceFilter[]))]
    [JsonSerializable(typeof(BybitLinearInverseTicker[]))]
    [JsonSerializable(typeof(BybitLinearTickerUpdate[]))]
    [JsonSerializable(typeof(BybitLiquidation[]))]
    [JsonSerializable(typeof(BybitLoan[]))]
    [JsonSerializable(typeof(BybitLoanOrder[]))]
    [JsonSerializable(typeof(BybitLongShortRatio[]))]
    [JsonSerializable(typeof(BybitMaxCollateral[]))]
    [JsonSerializable(typeof(BybitOpenInterest[]))]
    [JsonSerializable(typeof(BybitOperationResult[]))]
    [JsonSerializable(typeof(BybitOptionSymbol[]))]
    [JsonSerializable(typeof(BybitOptionLotSizeFilter[]))]
    [JsonSerializable(typeof(BybitOptionPriceFilter[]))]
    [JsonSerializable(typeof(BybitOptionTicker[]))]
    [JsonSerializable(typeof(BybitOptionTickerUpdate[]))]
    [JsonSerializable(typeof(BybitOrder[]))]
    [JsonSerializable(typeof(BybitOrderbook[]))]
    [JsonSerializable(typeof(BybitOrderbookEntry[]))]
    [JsonSerializable(typeof(BybitOrderId[]))]
    [JsonSerializable(typeof(BybitPlaceOrderRequest[]))]
    [JsonSerializable(typeof(BybitSocketPlaceOrderRequest[]))]
    [JsonSerializable(typeof(BybitPosition[]))]
    [JsonSerializable(typeof(BybitRepayId[]))]
    [JsonSerializable(typeof(BybitRepayment[]))]
    [JsonSerializable(typeof(BybitBaseResponse[]))]
    [JsonSerializable(typeof(BybitRiskLimit[]))]
    [JsonSerializable(typeof(BybitSetCollateralAssetRequest[]))]
    [JsonSerializable(typeof(BybitSetMarginModeResult[]))]
    [JsonSerializable(typeof(BybitReason[]))]
    [JsonSerializable(typeof(BybitSetRiskLimit[]))]
    [JsonSerializable(typeof(BybitSettlementRecord[]))]
    [JsonSerializable(typeof(BybitSpotMarginBorrowRate[]))]
    [JsonSerializable(typeof(BybitSpotMarginCollateralRatio[]))]
    [JsonSerializable(typeof(BybitSpotMarginCollateralRatioTier[]))]
    [JsonSerializable(typeof(BybitSpotMarginLeverageStatus[]))]
    [JsonSerializable(typeof(BybitSpotMarginStatus[]))]
    [JsonSerializable(typeof(BybitSpotMarginVipMarginData[]))]
    [JsonSerializable(typeof(BybitSpotMarginVipMarginList[]))]
    [JsonSerializable(typeof(BybitSpotMarginVipMarginItem[]))]
    [JsonSerializable(typeof(BybitSpotSymbol[]))]
    [JsonSerializable(typeof(BybitPriceLimit[]))]
    [JsonSerializable(typeof(BybitSpotLotSizeFilter[]))]
    [JsonSerializable(typeof(BybitSpotPriceFilter[]))]
    [JsonSerializable(typeof(BybitSpotTicker[]))]
    [JsonSerializable(typeof(BybitSpotTickerUpdate[]))]
    [JsonSerializable(typeof(BybitSubAccountWrapper[]))]
    [JsonSerializable(typeof(BybitSubAccount[]))]
    [JsonSerializable(typeof(BybitTakeProfitStopLossMode[]))]
    [JsonSerializable(typeof(BybitTime[]))]
    [JsonSerializable(typeof(BybitTradeHistory[]))]
    [JsonSerializable(typeof(BybitTransactionLog[]))]
    [JsonSerializable(typeof(BybitTransfer[]))]
    [JsonSerializable(typeof(BybitTransferable[]))]
    [JsonSerializable(typeof(BybitTransferId[]))]
    [JsonSerializable(typeof(BybitUserAssetInfos[]))]
    [JsonSerializable(typeof(BybitUserAssetInfo[]))]
    [JsonSerializable(typeof(BybitAssetNetworkInfo[]))]
    [JsonSerializable(typeof(BybitUserTrade[]))]
    [JsonSerializable(typeof(BybitWithdrawal[]))]
    [JsonSerializable(typeof(BybitOptionsQueryResponse))]
    [JsonSerializable(typeof(BybitRequestMessage))]
    [JsonSerializable(typeof(BybitPong))]
    [JsonSerializable(typeof(BybitQueryResponse))]
    [JsonSerializable(typeof(BybitRequestQueryMessage))]
    [JsonSerializable(typeof(int?))]
    [JsonSerializable(typeof(int))]
    [JsonSerializable(typeof(long?))]
    [JsonSerializable(typeof(long))]
    [JsonSerializable(typeof(decimal?))]
    [JsonSerializable(typeof(decimal))]
    [JsonSerializable(typeof(DateTime))]
    [JsonSerializable(typeof(DateTime?))]
    internal partial class BybitSourceGenerationContext : JsonSerializerContext
    {
    }
}
