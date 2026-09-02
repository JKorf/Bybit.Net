using CryptoExchange.Net.SharedApis;

namespace Bybit.Net.Interfaces.Clients
{
    /// <summary>
    /// Shared interface for rest API usage
    /// </summary>
    public interface IBybitRestClientApiShared :
        IAssetsRestClient,
        IBalanceRestClient,
        IDepositRestClient,
        IKlineRestClient,
        IOrderBookRestClient,
        IRecentTradeRestClient,
        ISpotOrderRestClient,
        ISpotSymbolRestClient,
        ISpotTickerRestClient,
        IWithdrawalRestClient,
        IWithdrawRestClient,
        IFuturesTickerRestClient,
        IFuturesSymbolRestClient,
        ILeverageRestClient,
        IMarkPriceKlineRestClient,
        IIndexPriceKlineRestClient,
        IOpenInterestRestClient,
        IFundingRateRestClient,
        IFuturesOrderRestClient,
        IPositionModeRestClient,
        IPositionHistoryRestClient,
        IFeeRestClient,
        ISpotOrderClientIdRestClient,
        IFuturesOrderClientIdRestClient,
        ISpotTriggerOrderRestClient,
        IFuturesTriggerOrderRestClient,
        IFuturesTpSlRestClient,
        IBookTickerRestClient,
        ITransferRestClient
    {
    }

    /// <summary>
    /// Shared API interface. Shared APIs provide a common,
    /// exchange-independent contract for accessing functionality across different
    /// exchange client libraries.
    /// </summary>
    public interface IBybitRestClientSharedApi :
        IGetAssetRest,
        IGetAllAssetsRest,
        IGetBalancesRest,
        IGetDepositAddressesRest,
        IGetDepositHistoryRest,
        IGetKlinesRest,
        IGetOrderBookRest,
        IGetRecentTradesRest,
        IPlaceSpotOrderRest,
        IGetSpotOrderRest,
        IGetOpenSpotOrdersRest,
        IGetClosedSpotOrdersRest,
        IGetSpotOrderTradesRest,
        IGetSpotUserTradeHistoryRest,
        ICancelSpotOrderRest,
        IGetSpotSymbolsRest,
        IGetSpotTickerRest,
        IGetAllSpotTickersRest,
        IGetWithdrawalHistoryRest,
        IWithdrawRest,
        IGetFuturesTickerRest,
        IGetAllFuturesTickersRest,
        IGetFuturesSymbolsRest,
        IGetLeverageRest,
        ISetLeverageRest,
        IGetMarkPriceKlinesRest,
        IGetIndexPriceKlinesRest,
        IGetOpenInterestRest,
        IGetFundingRateHistoryRest,
        IPlaceFuturesOrderRest,
        IGetFuturesOrderRest,
        IGetOpenFuturesOrdersRest,
        IGetClosedFuturesOrdersRest,
        IGetFuturesOrderTradesRest,
        IGetFuturesUserTradeHistoryRest,
        ICancelFuturesOrderRest,
        IGetPositionsRest,
        IClosePositionRest,
        IGetPositionHistoryRest,
        IGetPositionModeRest,
        ISetPositionModeRest,
        IGetFeesRest,
        IGetSpotOrderByClientOrderIdRest,
        ICancelSpotOrderByClientOrderIdRest,
        IGetFuturesOrderByClientOrderIdRest,
        ICancelFuturesOrderByClientOrderIdRest,
        IPlaceSpotTriggerOrderRest,
        IGetSpotTriggerOrderRest,
        ICancelSpotTriggerOrderRest,
        IPlaceFuturesTriggerOrderRest,
        IGetFuturesTriggerOrderRest,
        ICancelFuturesTriggerOrderRest,
        ISetFuturesTpSlRest,
        ICancelFuturesTpSlRest,
        IGetBookTickerRest,
        ITransferRest
    { }
}
