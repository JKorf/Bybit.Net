using NUnit.Framework;
using System.Threading.Tasks;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Testing;
using System.Collections.Generic;
using Bybit.Net.Clients;
using System.Linq;
using Bybit.Net.Objects.Models.V5;
using Bybit.Net.Enums;
using System.Drawing;
using System;

namespace Bybit.Net.UnitTests
{
    [TestFixture]
    public class RestRequestTests
    {
        [Test]
        public async Task ValidateSpotAccountCalls()
        {
            var client = new BybitRestClient(opts =>
            {
                opts.AutoTimestamp = false;
                opts.ApiCredentials = new ApiCredentials("123", "456");
            });
            var tester = new RestRequestValidator<BybitRestClient>(client, "Endpoints/V5Api/Account", "https://api.bybit.com", IsAuthenticated, "result");
            await tester.ValidateAsync(client => client.V5Api.Account.SetLeverageAsync(Enums.Category.Option, "ETHUSDT", 1, 1), "SetLeverage");
            await tester.ValidateAsync(client => client.V5Api.Account.SetCollateralAssetAsync("ETH", true), "SetCollateralAsset");
            await tester.ValidateAsync(client => client.V5Api.Account.SetMultipleCollateralAssetsAsync(new[] { new BybitSetCollateralAssetRequest { Asset = "ETH", UseForCollateral = true} }), "SetMultipleCollateralAssets");
            await tester.ValidateAsync(client => client.V5Api.Account.SwitchCrossIsolatedMarginAsync(Enums.Category.Option, "ETHUSDT", Enums.TradeMode.Isolated, 1, 1), "SwitchCrossIsolatedMargin");
            await tester.ValidateAsync(client => client.V5Api.Account.SetTakeProfitStopLossModeAsync(Enums.Category.Option, "ETHUSDT", Enums.StopLossTakeProfitMode.Full), "SetTakeProfitStopLossMode");
            await tester.ValidateAsync(client => client.V5Api.Account.SwitchPositionModeAsync(Enums.Category.Option, PositionMode.MergedSingle), "SwitchPositionMode");
            await tester.ValidateAsync(client => client.V5Api.Account.SetRiskLimitAsync(Enums.Category.Option, "ETHUSDT", 1), "SetRiskLimit");
            await tester.ValidateAsync(client => client.V5Api.Account.SetAutoAddMarginAsync(Enums.Category.Option, "ETHUSDT", true), "SetAutoAddMargin");
            await tester.ValidateAsync(client => client.V5Api.Account.GetBalancesAsync(Enums.AccountType.Option), "GetBalances");
            await tester.ValidateAsync(client => client.V5Api.Account.GetBorrowHistoryAsync("ETH"), "GetBorrowHistory");
            await tester.ValidateAsync(client => client.V5Api.Account.GetCollateralInfoAsync("ETH"), "GetCollateralInfo", ignoreProperties: new List<string> { "freeBorrowingAmount" });
            await tester.ValidateAsync(client => client.V5Api.Account.GetAssetGreeksAsync("ETH"), "GetAssetGreeks");
            await tester.ValidateAsync(client => client.V5Api.Account.GetFeeRateAsync(Enums.Category.Inverse), "GetFeeRate");
            await tester.ValidateAsync(client => client.V5Api.Account.GetMarginAccountInfoAsync(), "GetMarginAccountInfo", ignoreProperties: new List<string> { "spotHedgingStatus" });
            await tester.ValidateAsync(client => client.V5Api.Account.GetTransactionHistoryAsync(), "GetTransactionHistory");
            //await tester.ValidateAsync(client => client.V5Api.Account.SetMarginModeAsync(Enums.MarginMode.PortfolioMargin), "SetMarginMode");
            await tester.ValidateAsync(client => client.V5Api.Account.GetAssetInfoAsync(), "GetAssetInfo", ignoreProperties: new List<string> { "chainDeposit", "chainWithdraw" });
            await tester.ValidateAsync(client => client.V5Api.Account.GetWithdrawalsAsync(), "GetWithdrawals", skipResponseValidation: true);
            await tester.ValidateAsync(client => client.V5Api.Account.GetDelayedWithdrawQuantityAsync("ETH"), "GetDelayedWithdrawQuantity");
            await tester.ValidateAsync(client => client.V5Api.Account.WithdrawAsync("ETH", "ERC20", "123", 1, WithdrawAccountType.Fund), "Withdraw");
            await tester.ValidateAsync(client => client.V5Api.Account.CancelWithdrawalAsync("123"), "CancelWithdrawal");
            await tester.ValidateAsync(client => client.V5Api.Account.GetApiKeyInfoAsync(), "GetApiKeyInfo");
            await tester.ValidateAsync(client => client.V5Api.Account.EditApiKeyAsync(), "EditApiKey");
            await tester.ValidateAsync(client => client.V5Api.Account.DeleteApiKeyAsync(), "DeleteApiKey");
            await tester.ValidateAsync(client => client.V5Api.Account.GetAccountTypesAsync(), "GetAccountTypes", "result.accounts");
            await tester.ValidateAsync(client => client.V5Api.Account.AddOrReduceMarginAsync(Enums.Category.Option, "ETHUSDT", 1), "AddOrReduceMargin");
            await tester.ValidateAsync(client => client.V5Api.Account.SetSpotMarginLeverageAsync(1), "SetSpotMarginLeverage");
            await tester.ValidateAsync(client => client.V5Api.Account.GetSpotMarginStatusAndLeverageAsync(), "GetSpotMarginStatusAndLeverage", ignoreProperties: new List<string> { "spotMarginMode" });
            await tester.ValidateAsync(client => client.V5Api.Account.SetSpotMarginTradeModeAsync(true), "SetSpotMarginTradeMode");
            await tester.ValidateAsync(client => client.V5Api.Account.GetSpotMarginDataAsync(), "GetSpotMarginData", "result.vipCoinList");
            await tester.ValidateAsync(client => client.V5Api.Account.GetSpotMarginInterestRateHistoryAsync("ETH"), "GetSpotMarginInterestRateHistory", "result.list");
            await tester.ValidateAsync(client => client.V5Api.Account.GetBrokerAccountInfoAsync(), "GetBrokerAccountInfo");
            await tester.ValidateAsync(client => client.V5Api.Account.GetBrokerEarningsAsync(), "GetBrokerEarnings");
            await tester.ValidateAsync(client => client.V5Api.Account.SetSpotHedgingModeAsync(true), "SetSpotHedgingMode");
            await tester.ValidateAsync(client => client.V5Api.Account.RepayLiabilitiesAsync(), "RepayLiabilities", "result.list");
            await tester.ValidateAsync(client => client.V5Api.Account.GetConvertAssetsAsync(Enums.ConvertAccountType.ConvertFunding), "GetConvertAssets", "result.coins", ignoreProperties: new List<string> { "timePeriod", "singleToMinLimit", "singleToMaxLimit", "dailyFromMinLimit", "dailyFromMaxLimit", "dailyToMinLimit", "dailyToMaxLimit" });
            await tester.ValidateAsync(client => client.V5Api.Account.GetConvertQuoteAsync(Enums.ConvertAccountType.ConvertFunding, "ETH", "BTC", 1), "GetConvertQuote", "result");
            await tester.ValidateAsync(client => client.V5Api.Account.ConvertConfirmQuoteAsync("123"), "ConvertConfirmQuote", "result");
            await tester.ValidateAsync(client => client.V5Api.Account.GetConvertStatusAsync(Enums.ConvertAccountType.ConvertFunding, "123"), "GetConvertStatus", "result.result", ignoreProperties: new List<string> { "extInfo" });
            await tester.ValidateAsync(client => client.V5Api.Account.GetConvertHistoryAsync(Enums.ConvertAccountType.ConvertFunding), "GetConvertHistory", "result.list", ignoreProperties: new List<string> { "extInfo" });
            await tester.ValidateAsync(client => client.V5Api.Account.SetPriceLimitBehaviorAsync(Category.Spot, false), "SetPriceLimitBehavior");
            await tester.ValidateAsync(client => client.V5Api.Account.GetWithdrawAddressListAsync(), "GetWithdrawAddressList");
        }

        [Test]
        public async Task ValidateSpotExchangeDataCalls()
        {
            var client = new BybitRestClient(opts =>
            {
                opts.AutoTimestamp = false;
                opts.ApiCredentials = new ApiCredentials("123", "456");
            });
            var tester = new RestRequestValidator<BybitRestClient>(client, "Endpoints/V5Api/ExchangeData", "https://api.bybit.com", IsAuthenticated, "result");
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetAnnouncementsAsync("en-Us"), "GetAnnouncements");
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetKlinesAsync(Enums.Category.Spot, "ETHUSDT", Enums.KlineInterval.OneDay), "GetKlines");
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetMarkPriceKlinesAsync(Enums.Category.Spot, "ETHUSDT", Enums.KlineInterval.OneDay), "GetMarkPriceKlines");
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetIndexPriceKlinesAsync(Enums.Category.Spot, "ETHUSDT", Enums.KlineInterval.OneDay), "GetIndexPriceKlines");
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetPremiumIndexPriceKlinesAsync(Enums.Category.Spot, "ETHUSDT", Enums.KlineInterval.OneDay), "GetPremiumIndexPriceKlines");
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetSpotSymbolsAsync(), "GetSpotSymbols");
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetOptionSymbolsAsync(), "GetOptionSymbols");
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetLinearInverseSymbolsAsync(Enums.Category.Inverse), "GetLinearInverseSymbols", ignoreProperties: new List<string> { "postOnlyMaxOrderQty" });
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetLinearInverseSymbolsAsync(Enums.Category.Inverse), "GetLinearInverseSymbolsPreListing", ignoreProperties: new List<string> { "postOnlyMaxOrderQty", "endTime" });
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetOrderbookAsync(Enums.Category.Spot, "ETHUSDT"), "GetOrderbook");
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetSpotTickersAsync("ETHUSDT"), "GetSpotTickers");
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetOptionTickersAsync("ETHUSDT"), "GetOptionTickers");
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetLinearInverseTickersAsync(Enums.Category.Inverse, "ETHUSDT"), "GetLinearInverseTickers");
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetFundingRateHistoryAsync(Enums.Category.Inverse, "ETHUSDT"), "GetFundingRateHistory");
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetTradeHistoryAsync(Enums.Category.Inverse, "ETHUSDT"), "GetTradeHistory");
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetOpenInterestAsync(Enums.Category.Inverse, "ETHUSDT", Enums.OpenInterestInterval.OneDay), "GetOpenInterest");
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetHistoricalVolatilityAsync("ETHUSDT"), "GetHistoricalVolatility");
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetInsuranceAsync(), "GetInsurance");
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetRiskLimitAsync(Enums.Category.Inverse), "GetRiskLimit");
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetDeliveryPriceAsync(Enums.Category.Inverse), "GetDeliveryPrice");
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetLeverageTokensAsync(), "GetLeverageTokens", nestedJsonProperty: "result.list");
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetLeverageTokenMarketAsync("ETHUSDT"), "GetLeverageTokenMarket");
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetLongShortRatioAsync(Enums.Category.Option, "ETHUSDT", Enums.DataPeriod.OneDay), "GetLongShortRatio", nestedJsonProperty: "result.list");
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetSpreadSymbolsAsync(), "GetSpreadSymbols", nestedJsonProperty: "result.list");
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetSpreadOrderBookAsync("123"), "GetSpreadOrderBook", nestedJsonProperty: "result", ignoreProperties: ["cts"]);
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetSpreadTickersAsync("123"), "GetSpreadTickers", nestedJsonProperty: "result.list", useSingleArrayItem: true);
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetSpreadRecentTradesAsync("123"), "GetSpreadRecentTrades", nestedJsonProperty: "result.list");
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetOrderPriceLimitAsync("123"), "GetOrderPriceLimit", nestedJsonProperty: "result");
            await tester.ValidateAsync(client => client.V5Api.ExchangeData.GetSystemStatusAsync(), "GetSystemStatus", nestedJsonProperty: "result.list");
        }

        [Test]
        public async Task ValidateSpotTradingCalls()
        {
            var client = new BybitRestClient(opts =>
            {
                opts.AutoTimestamp = false;
                opts.ApiCredentials = new ApiCredentials("123", "456");
            });
            var tester = new RestRequestValidator<BybitRestClient>(client, "Endpoints/V5Api/Trading", "https://api.bybit.com", IsAuthenticated, "result");
            await tester.ValidateAsync(client => client.V5Api.Trading.PlaceOrderAsync(Enums.Category.Option, "ETHUSDT", Enums.OrderSide.Buy, Enums.NewOrderType.Market, 1), "PlaceOrder");
            await tester.ValidateAsync(client => client.V5Api.Trading.PlaceMultipleOrdersAsync(Enums.Category.Option, new[] { new BybitPlaceOrderRequest() }), "PlaceMultipleOrders", skipResponseValidation: true);
            await tester.ValidateAsync(client => client.V5Api.Trading.EditOrderAsync(Enums.Category.Option, "ETHUSDT"), "EditOrder");
            await tester.ValidateAsync(client => client.V5Api.Trading.EditMultipleOrdersAsync(Enums.Category.Option, new[] { new BybitEditOrderRequest() }), "EditMultipleOrders", skipResponseValidation: true);
            await tester.ValidateAsync(client => client.V5Api.Trading.CancelOrderAsync(Enums.Category.Option, "ETHUSDT", "234"), "CancelOrder");
            await tester.ValidateAsync(client => client.V5Api.Trading.CancelMultipleOrdersAsync(Enums.Category.Option, new[] { new BybitCancelOrderRequest() }), "CancelMultipleOrders", skipResponseValidation: true);
            await tester.ValidateAsync(client => client.V5Api.Trading.GetOrdersAsync(Enums.Category.Option, "ETHUSDT"), "GetOrders");
            await tester.ValidateAsync(client => client.V5Api.Trading.CancelAllOrderAsync(Enums.Category.Option, "ETHUSDT"), "CancelAllOrder", ignoreProperties: new List<string> { "success" });
            await tester.ValidateAsync(client => client.V5Api.Trading.GetOrderHistoryAsync(Enums.Category.Option, "ETHUSDT"), "GetOrderHistory");
            await tester.ValidateAsync(client => client.V5Api.Trading.GetBorrowQuotaAsync("ETHUSDT", Enums.OrderSide.Buy), "GetBorrowQuota");
            await tester.ValidateAsync(client => client.V5Api.Trading.SetDisconnectCancelAllAsync(10), "SetDisconnectCancelAll");
            await tester.ValidateAsync(client => client.V5Api.Trading.GetUserTradesAsync(Enums.Category.Option), "GetUserTrades");
            await tester.ValidateAsync(client => client.V5Api.Trading.GetPositionsAsync(Enums.Category.Option), "GetPositions", ignoreProperties: new List<string> { "mmrSysUpdateTime" });
            await tester.ValidateAsync(client => client.V5Api.Trading.GetAssetExchangeHistoryAsync(), "GetAssetExchangeHistory", "result.orderBody");
            await tester.ValidateAsync(client => client.V5Api.Trading.GetDeliveryHistoryAsync(Enums.Category.Option), "GetDeliveryHistory");
            await tester.ValidateAsync(client => client.V5Api.Trading.GetSettlementHistoryAsync(Enums.Category.Option), "GetSettlementHistory");
            await tester.ValidateAsync(client => client.V5Api.Trading.GetClosedProfitLossAsync(Enums.Category.Option), "GetClosedProfitLoss");
            await tester.ValidateAsync(client => client.V5Api.Trading.SetTradingStopAsync(Enums.Category.Option, "ETHUSDT", PositionIdx.OneWayMode, 1), "SetTradingStop");
            await tester.ValidateAsync(client => client.V5Api.Trading.PurchaseLeverageTokenAsync("123", 1), "PurchaseLeverageToken");
            await tester.ValidateAsync(client => client.V5Api.Trading.RedeemLeverageTokenAsync("123", 1), "RedeemLeverageToken", ignoreProperties: new List<string> { "quantity" });
            await tester.ValidateAsync(client => client.V5Api.Trading.GetLeverageTokenOrderHistoryAsync("123"), "GetLeverageTokenOrderHistory", "result.list");
            await tester.ValidateAsync(client => client.V5Api.Trading.PlaceSpreadOrderAsync("123", OrderSide.Buy, NewOrderType.Market, 0.1m, TimeInForce.FillOrKill), "PlaceSpreadOrder", nestedJsonProperty: "result");
            await tester.ValidateAsync(client => client.V5Api.Trading.EditSpreadOrderAsync("123"), "EditSpreadOrder", nestedJsonProperty: "result");
            await tester.ValidateAsync(client => client.V5Api.Trading.CancelSpreadOrderAsync("123"), "CancelSpreadOrder", nestedJsonProperty: "result");
            await tester.ValidateAsync(client => client.V5Api.Trading.CancelAllSpreadOrdersAsync(), "CancelAllSpreadOrders", nestedJsonProperty: "result.list");
            await tester.ValidateAsync(client => client.V5Api.Trading.GetOpenSpreadOrdersAsync(), "GetOpenSpreadOrders", nestedJsonProperty: "result");
            await tester.ValidateAsync(client => client.V5Api.Trading.GetClosedSpreadOrdersAsync(), "GetClosedSpreadOrders", nestedJsonProperty: "result");
            await tester.ValidateAsync(client => client.V5Api.Trading.GetSpreadUserTradesAsync(), "GetSpreadUserTrades", nestedJsonProperty: "result");
            await tester.ValidateAsync(client => client.V5Api.Trading.PreCheckOrderAsync(Category.Inverse, "ETHUSDT", OrderSide.Buy, NewOrderType.Market, 1), "PreCheckOrder", nestedJsonProperty: "result");
        }

        [Test]
        public async Task ValidateCryptoLoanCalls()
        {
            var client = new BybitRestClient(opts =>
            {
                opts.AutoTimestamp = false;
                opts.ApiCredentials = new ApiCredentials("123", "456");
            });
            var tester = new RestRequestValidator<BybitRestClient>(client, "Endpoints/V5Api/CryptoLoan", "https://api.bybit.com", IsAuthenticated, "result");
            await tester.ValidateAsync(client => client.V5Api.CryptoLoan.GetBorrowableAssetsAsync(AccountLevel.Vip5, "123"), "GetBorrowableAssets", nestedJsonProperty: "result.vipCoinList");
            await tester.ValidateAsync(client => client.V5Api.CryptoLoan.GetLimitsAsync("123", "123"), "GetLimits", nestedJsonProperty: "result");
            await tester.ValidateAsync(client => client.V5Api.CryptoLoan.BorrowAsync("123", "123"), "Borrow", nestedJsonProperty: "result");
            await tester.ValidateAsync(client => client.V5Api.CryptoLoan.RepayAsync("123", 0.1m), "Repay", nestedJsonProperty: "result");
            await tester.ValidateAsync(client => client.V5Api.CryptoLoan.GetOpenLoansAsync(), "GetOpenLoans", nestedJsonProperty: "result");
            await tester.ValidateAsync(client => client.V5Api.CryptoLoan.GetOpenLoansAsync(), "GetOpenLoans2", nestedJsonProperty: "result");
            await tester.ValidateAsync(client => client.V5Api.CryptoLoan.GetRepayHistoryAsync(), "GetRepayHistory", nestedJsonProperty: "result");
            await tester.ValidateAsync(client => client.V5Api.CryptoLoan.GetCompletedLoanOrdersAsync(), "GetCompletedLoanOrders", nestedJsonProperty: "result");
            await tester.ValidateAsync(client => client.V5Api.CryptoLoan.GetMaxCollateralAsync("123"), "GetMaxCollateral", nestedJsonProperty: "result");
            await tester.ValidateAsync(client => client.V5Api.CryptoLoan.AdjustCollateralAsync("123", 0.1m, AdjustDirection.Add), "AdjustCollateral", nestedJsonProperty: "result");
            await tester.ValidateAsync(client => client.V5Api.CryptoLoan.GetCollateralAdjustHistoryAsync(), "GetCollateralAdjustHistory", nestedJsonProperty: "result");
        }

        [Test]
        public async Task ValidateEarnCalls()
        {
            var client = new BybitRestClient(opts =>
            {
                opts.AutoTimestamp = false;
                opts.ApiCredentials = new ApiCredentials("123", "456");
            });
            var tester = new RestRequestValidator<BybitRestClient>(client, "Endpoints/V5Api/Earn", "https://api.bybit.com", IsAuthenticated, "result");
            await tester.ValidateAsync(client => client.V5Api.Earn.GetProductInfoAsync(EarnCategory.FlexibleSaving, "123"), "GetProductInfo", nestedJsonProperty: "result");
            await tester.ValidateAsync(client => client.V5Api.Earn.PlaceOrderAsync(EarnCategory.FlexibleSaving, "123", AccountType.Fund, "123", EarnOrderType.Stake, 0.1m), "PlaceOrder", nestedJsonProperty: "result");
            await tester.ValidateAsync(client => client.V5Api.Earn.GetOrderHistoryAsync(EarnCategory.FlexibleSaving, "123"), "GetOrderHistory", nestedJsonProperty: "result");
            await tester.ValidateAsync(client => client.V5Api.Earn.GetStakedPositionsAsync(EarnCategory.FlexibleSaving), "GetStakedPositions", nestedJsonProperty: "result");
        }

        private bool IsAuthenticated(WebCallResult result)
        {
            return result.RequestHeaders.Any(r => r.Key == "X-BAPI-SIGN");
        }
    }
}
