using CryptoExchange.Net.SharedApis.Interfaces.Rest;
using CryptoExchange.Net.SharedApis.Interfaces.Rest.Futures;
using CryptoExchange.Net.SharedApis.Interfaces.Rest.Spot;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Interfaces.Clients
{
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
        IPositionHistoryRestClient
    {
    }
}
