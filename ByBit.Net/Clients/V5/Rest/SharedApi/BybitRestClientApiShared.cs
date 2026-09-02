using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.SharedApis;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Bybit.Net.Clients.V5
{
    internal partial class BybitRestClientSharedApi :
        SharedApiBase,
        IBybitRestClientApiShared,
        IBybitRestClientSharedApi
    {
        private readonly BybitRestClientApi _api;

        private const string _topicSpotId = "BybitSpot";
        private const string _topicFuturesId = "BybitFutures";

        private const string _exchangeName = "Bybit";
        public override SharedClientInfo Discover() => SharedUtils.GetClientInfo(BybitExchange.Metadata, this);

        private static HashSet<string> _exchangeSupportedFiat = ["USD", "EUR", "BRL", "PLN", "TRY", "AED", "GBP"];

        public BybitRestClientSharedApi(BybitRestClientApi api)
            : base(
                  SharedTransport.Rest,
                  api.Exchange,
                  [TradingMode.Spot, TradingMode.PerpetualLinear, TradingMode.DeliveryLinear, TradingMode.PerpetualInverse, TradingMode.DeliveryInverse],
                  () => api.Authenticated,
                  api.FormatSymbol)
        {
            _api = api;

            SetCapabilities(
                GetKlinesOptions,
                GetSpotSymbolsOptions,
                GetSpotTickerOptions,
                GetAllSpotTickersOptions,
                GetBookTickerOptions,
                GetRecentTradesOptions,
                GetBalancesOptions,
                PlaceSpotOrderOptions,
                GetSpotOrderOptions,
                GetOpenSpotOrdersOptions,
                GetClosedSpotOrdersOptions,
                GetSpotOrderTradesOptions,
                GetSpotUserTradeHistoryOptions,
                CancelSpotOrderOptions,
                GetSpotOrderByClientOrderIdOptions,
                CancelSpotOrderByClientOrderIdOptions,
                GetAssetOptions,
                GetAllAssetsOptions,
                GetDepositAddressesOptions,
                GetDepositHistoryOptions,
                GetOrderBookOptions,
                GetWithdrawalHistoryOptions,
                WithdrawOptions,
                GetFuturesTickerOptions,
                GetAllFuturesTickersOptions,
                GetFuturesSymbolsOptions,
                GetLeverageOptions,
                SetLeverageOptions,
                GetMarkPriceKlinesOptions,
                GetIndexPriceKlinesOptions,
                GetOpenInterestOptions,
                GetFundingRateHistoryOptions,
                PlaceFuturesOrderOptions,
                GetFuturesOrderOptions,
                GetOpenFuturesOrdersOptions,
                GetClosedFuturesOrdersOptions,
                GetFuturesOrderTradesOptions,
                GetFuturesUserTradeHistoryOptions,
                CancelFuturesOrderOptions,
                GetPositionsOptions,
                ClosePositionOptions,
                GetFuturesOrderByClientOrderIdOptions,
                CancelFuturesOrderByClientOrderIdOptions,
                GetPositionModeOptions,
                SetPositionModeOptions,
                GetPositionHistoryOptions,
                GetFeeOptions,
                PlaceSpotTriggerOrderOptions,
                GetSpotTriggerOrderOptions,
                CancelSpotTriggerOrderOptions,
                PlaceFuturesTriggerOrderOptions,
                GetFuturesTriggerOrderOptions,
                CancelFuturesTriggerOrderOptions,
                SetFuturesTpSlOptions,
                CancelFuturesTpSlOptions,
                TransferOptions
                );
        }
    }
}
