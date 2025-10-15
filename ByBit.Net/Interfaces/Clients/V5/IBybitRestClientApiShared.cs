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
}
