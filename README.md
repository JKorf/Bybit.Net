# ![.Bybit.Net](https://github.com/JKorf/Bybit.Net/blob/main/ByBit.Net/Icon/icon.png?raw=true) Bybit.Net

[![.NET](https://img.shields.io/github/actions/workflow/status/JKorf/Bybit.Net/dotnet.yml?style=for-the-badge)](https://github.com/JKorf/Bybit.Net/actions/workflows/dotnet.yml) ![License](https://img.shields.io/github/license/JKorf/Bitget.Net?style=for-the-badge)
 
Bybit.Net is a strongly typed client library for accessing the [Bybit REST and Websocket API](https://bybit-exchange.github.io/docs/spot/#t-introduction).
## Features
* Response data is mapped to descriptive models
* Input parameters and response values are mapped to discriptive enum values where possible
* Automatic websocket (re)connection management 
* Client side order book implementation
* Extensive logging
* Support for different environments (production, testnet, Hongkong, The Netherlands, Turkey, ..)
* Easy integration with other exchange client based on the CryptoExchange.Net base library

## Supported Frameworks
The library is targeting both `.NET Standard 2.0` and `.NET Standard 2.1` for optimal compatibility

|.NET implementation|Version Support|
|--|--|
|.NET Core|`2.0` and higher|
|.NET Framework|`4.6.1` and higher|
|Mono|`5.4` and higher|
|Xamarin.iOS|`10.14` and higher|
|Xamarin.Android|`8.0` and higher|
|UWP|`10.0.16299` and higher|
|Unity|`2018.1` and higher|

## Install the library

### NuGet 
[![NuGet version](https://img.shields.io/nuget/v/Bybit.net.svg?style=for-the-badge)](https://www.nuget.org/packages/Bybit.Net)  [![Nuget downloads](https://img.shields.io/nuget/dt/Bybit.Net.svg?style=for-the-badge)](https://www.nuget.org/packages/Bybit.Net)

	dotnet add package Bybit.Net
	
### GitHub packages
Bybit.Net is available on [GitHub packages](https://github.com/JKorf/Bybit.Net/pkgs/nuget/Bybit.Net). You'll need to add `https://nuget.pkg.github.com/JKorf/index.json` as a NuGet package source.

### Download release
[![GitHub Release](https://img.shields.io/github/v/release/JKorf/Bybit.Net?style=for-the-badge&label=GitHub)](https://github.com/JKorf/Bybit.Net/releases)

The NuGet package files are added along side the source with the latest GitHub release which can found [here](https://github.com/JKorf/Bybit.Net/releases).

## How to use
*REST Endpoints*  

```csharp
// Get the ETH/USDT ticker via rest request
var restClient = new BybitRestClient();
var tickerResult = await restClient.V5Api.ExchangeData.GetSpotTickersAsync("ETHUSDT");
var lastPrice = tickerResult.Data.List.First().LastPrice;
```
*Websocket streams*  

```csharp
// Subscribe to ETH/USDT ticker updates via the websocket API
var socketClient = new BybitSocketClient();
var tickerSubscriptionResult = socketClient.V5SpotApi.SubscribeToTickerUpdatesAsync("ETHUSDT", (update) =>
{
	var lastPrice = update.Data.LastPrice;
});
```

For information on the clients, dependency injection, response processing and more see the [Bybit.Net documentation](https://jkorf.github.io/Bybit.Net), [CryptoExchange.Net documentation](https://jkorf.github.io/CryptoExchange.Net), or have a look at the examples [here](https://github.com/JKorf/Bybit.Net/tree/main/Examples) or [here](https://github.com/JKorf/CryptoExchange.Net/tree/master/Examples).

## CryptoExchange.Net
Bybit.Net is based on the [CryptoExchange.Net](https://github.com/JKorf/CryptoExchange.Net) base library. Other exchange API implementations based on the CryptoExchange.Net base library are available and follow the same logic.

CryptoExchange.Net also allows for [easy access to different exchange API's](https://jkorf.github.io/CryptoExchange.Net#idocs_shared).

|Exchange|Repository|Nuget|
|--|--|--|
|Binance|[JKorf/Binance.Net](https://github.com/JKorf/Binance.Net)|[![Nuget version](https://img.shields.io/nuget/v/Binance.net.svg?style=flat-square)](https://www.nuget.org/packages/Binance.Net)|
|BingX|[JKorf/BingX.Net](https://github.com/JKorf/BingX.Net)|[![Nuget version](https://img.shields.io/nuget/v/JK.BingX.net.svg?style=flat-square)](https://www.nuget.org/packages/JK.BingX.Net)|
|Bitfinex|[JKorf/Bitfinex.Net](https://github.com/JKorf/Bitfinex.Net)|[![Nuget version](https://img.shields.io/nuget/v/Bitfinex.net.svg?style=flat-square)](https://www.nuget.org/packages/Bitfinex.Net)|
|Bitget|[JKorf/Bitget.Net](https://github.com/JKorf/Bitget.Net)|[![Nuget version](https://img.shields.io/nuget/v/JK.Bitget.net.svg?style=flat-square)](https://www.nuget.org/packages/JK.Bitget.Net)|
|BitMart|[JKorf/BitMart.Net](https://github.com/JKorf/BitMart.Net)|[![Nuget version](https://img.shields.io/nuget/v/BitMart.net.svg?style=flat-square)](https://www.nuget.org/packages/BitMart.Net)|
|Coinbase|[JKorf/Coinbase.Net](https://github.com/JKorf/Coinbase.Net)|[![Nuget version](https://img.shields.io/nuget/v/JKorf.Coinbase.Net.svg?style=flat-square)](https://www.nuget.org/packages/JKorf.Coinbase.Net)|
|CoinEx|[JKorf/CoinEx.Net](https://github.com/JKorf/CoinEx.Net)|[![Nuget version](https://img.shields.io/nuget/v/CoinEx.net.svg?style=flat-square)](https://www.nuget.org/packages/CoinEx.Net)|
|CoinGecko|[JKorf/CoinGecko.Net](https://github.com/JKorf/CoinGecko.Net)|[![Nuget version](https://img.shields.io/nuget/v/CoinGecko.net.svg?style=flat-square)](https://www.nuget.org/packages/CoinGecko.Net)|
|Crypto.com|[JKorf/CryptoCom.Net](https://github.com/JKorf/CryptoCom.Net)|[![Nuget version](https://img.shields.io/nuget/v/CryptoCom.net.svg?style=flat-square)](https://www.nuget.org/packages/CryptoCom.Net)|
|Gate.io|[JKorf/GateIo.Net](https://github.com/JKorf/GateIo.Net)|[![Nuget version](https://img.shields.io/nuget/v/GateIo.net.svg?style=flat-square)](https://www.nuget.org/packages/GateIo.Net)|
|HTX|[JKorf/HTX.Net](https://github.com/JKorf/HTX.Net)|[![Nuget version](https://img.shields.io/nuget/v/JKorf.HTX.Net.svg?style=flat-square)](https://www.nuget.org/packages/JKorf.HTX.Net)|
|Kraken|[JKorf/Kraken.Net](https://github.com/JKorf/Kraken.Net)|[![Nuget version](https://img.shields.io/nuget/v/KrakenExchange.net.svg?style=flat-square)](https://www.nuget.org/packages/KrakenExchange.Net)|
|Kucoin|[JKorf/Kucoin.Net](https://github.com/JKorf/Kucoin.Net)|[![Nuget version](https://img.shields.io/nuget/v/Kucoin.net.svg?style=flat-square)](https://www.nuget.org/packages/Kucoin.Net)|
|Mexc|[JKorf/Mexc.Net](https://github.com/JKorf/Mexc.Net)|[![Nuget version](https://img.shields.io/nuget/v/JK.Mexc.net.svg?style=flat-square)](https://www.nuget.org/packages/JK.Mexc.Net)|
|OKX|[JKorf/OKX.Net](https://github.com/JKorf/OKX.Net)|[![Nuget version](https://img.shields.io/nuget/v/JK.OKX.net.svg?style=flat-square)](https://www.nuget.org/packages/JK.OKX.Net)|
|WhiteBit|[JKorf/WhiteBit.Net](https://github.com/JKorf/WhiteBit.Net)|[![Nuget version](https://img.shields.io/nuget/v/WhiteBit.net.svg?style=flat-square)](https://www.nuget.org/packages/WhiteBit.Net)|

## Discord
[![Nuget version](https://img.shields.io/discord/847020490588422145?style=for-the-badge)](https://discord.gg/MSpeEtSY8t)  
A Discord server is available [here](https://discord.gg/MSpeEtSY8t). Feel free to join for discussion and/or questions around the CryptoExchange.Net and implementation libraries.

## Supported functionality

### V5 Api
|API|Supported|Location|
|--|--:|--|
|Market|✓|`restClient.V5Api.ExchangeData`|
|Trade|✓|`restClient.V5Api.Account` / `restClient.V5Api.Trading`|
|Position|✓|`restClient.V5Api.Account` / `restClient.V5Api.Trading`|
|Pre-Upgrade|X||
|Account|✓|`restClient.V5Api.Account`|
|Asset|✓|`restClient.V5Api.Account`|
|Spot Leverage Token|✓|`restClient.V5Api.ExchangeData` / `restClient.V5Api.Trading`|
|Spot Margin Trade (UTA)|✓|`restClient.V5Api.Account`|
|Institutional Loan|X||
|Broken|✓|`restClient.V5Api.Account`|
|Websocket Stream Public|✓|`socketClient.V5SpotApi` / `socketClient.V5LinearApi` / `socketClient.V5InverseApi` / `socketClient.V5OptionsApi`|
|Websocket Stream Private|✓|`socketClient.V5PrivateApi`|

### V3 Derivatives
|API|Supported|Location|
|--|--:|--|
|Rest Market|✓|`restClient.DerivativesApi.ExchangeData`|
|Rest Contract|✓|`restClient.DerivativesApi.Account` / `restClient.DerivativesApi.Trading`|
|Websocket Public|✓|`restClient.V5Api.DerivativesApi`|
|Websocket Private|✓|`restClient.V5Api.DerivativesApi`|

### V3 Spot
|API|Supported|Location|
|--|--:|--|
|Rest Market data|✓|`restClient.SpotV3Api.ExchangeData`|
|Rest Trade|✓|`restClient.SpotV3Api.Trading`|
|Rest Wallet Balance|✓|`restClient.SpotV3Api.Account`|
|Rest Leveraged Token|X||
|Rest Cross Margin Trade|✓|`restClient.SpotV3Api.Trading`|
|Rest Institutional Loan|X||
|Websocket Public|✓|`restClient.SpotV3Api`|
|Websocket Private|✓|`restClient.SpotV3Api`|

### V3 Account Asset
|API|Supported|Location|
|--|--:|--|
|*|X||

### V3 Tax
|API|Supported|Location|
|--|--:|--|
|*|X||

## Support the project
Any support is greatly appreciated.

### Donate
Make a one time donation in a crypto currency of your choice. If you prefer to donate a currency not listed here please contact me.

**Btc**:  bc1q277a5n54s2l2mzlu778ef7lpkwhjhyvghuv8qf  
**Eth**:  0xcb1b63aCF9fef2755eBf4a0506250074496Ad5b7   
**USDT (TRX)**  TKigKeJPXZYyMVDgMyXxMf17MWYia92Rjd 

### Sponsor
Alternatively, sponsor me on Github using [Github Sponsors](https://github.com/sponsors/JKorf). 

## Release notes
* Version 3.16.0 - 06 Nov 2024
    * Updated CryptoExchange.Net to version 8.2.0, see https://github.com/JKorf/CryptoExchange.Net/releases/tag/8.2.0
    * Added OtherBorrowAmount to restClient.V5Api.Account.GetCollateralInfoAsync response model
    * Added Kazakhstan environment urls
    * Added restClient.V5Api.Account.GetClassicContractTransactionHistoryAsync endpoint

* Version 3.15.0 - 28 Oct 2024
    * Updated CryptoExchange.Net to version 8.1.0, see https://github.com/JKorf/CryptoExchange.Net/releases/tag/8.1.0
    * Moved FormatSymbol to BybitExchange class
    * Added support Side setting on SharedTrade model
    * Added BybitTrackerFactory for creating trackers
    * Added overload to Create method on BybitOrderBookFactory support SharedSymbol parameter
    * Added websocket stream URI for Turkey users

* Version 3.14.3 - 14 Oct 2024
    * Updated CryptoExchange.Net to version 8.0.3, see https://github.com/JKorf/CryptoExchange.Net/releases/tag/8.0.3
    * Fixed TypeLoadException during initialization

* Version 3.14.2 - 14 Oct 2024
    * Fixed restClient.V5Api.Account.GetBalancesAsync deserialization in demo environment without any transactions
    * Added missing TrailingProfit value to StopOrderType Enum

* Version 3.14.1 - 08 Oct 2024
    * Added ClosedPnl property to BybitOrderUpdate model
    * Added Pnl property to BybitUserTradeUpdate model

* Version 3.14.0 - 27 Sep 2024
    * Updated CryptoExchange.Net to version 8.0.0, see https://github.com/JKorf/CryptoExchange.Net/releases/tag/8.0.0
    * Added Shared client interfaces implementation for V5 Rest and Socket clients
    * Updated Sourcelink package version
    * Marked ISpotClient references as deprecated

* Version 3.13.1 - 19 Aug 2024
    * Added addOrReduce parameter to V5Api.Account.RequestDemoFundsAsync endpoint
    * Added referer to V5Api.Account.GetConvertQuoteAsync endpoint

* Version 3.13.0 - 07 Aug 2024
    * Updated CryptoExchange.Net to version 7.11.0, see https://github.com/JKorf/CryptoExchange.Net/releases/tag/7.11.0
    * Updated XML code comments
    * Added IsMaker to socketClient.V5Api.SubscribeToMinimalUserTradeUpdatesAsync update model

* Version 3.12.0 - 27 Jul 2024
    * Updated CryptoExchange.Net to version 7.10.0, see https://github.com/JKorf/CryptoExchange.Net/releases/tag/7.10.0
    * Added V5Api.Account.GetSpotMarginInterestRateHistoryAsync endpoint

* Version 3.11.0 - 16 Jul 2024
    * Updated CryptoExchange.Net to version 7.9.0, see https://github.com/JKorf/CryptoExchange.Net/releases/tag/7.9.0
    * Updated internal classes to internal access modifier
    * Added V5Api.Account.GetConvertAssetsAsync
    * Added V5Api.Account.GetConvertQuoteAsync
    * Added V5Api.Account.ConvertConfirmQuoteAsync
    * Added V5Api.Account.GetConvertStatusAsync
    * Added V5Api.Account.GetConvertHistoryAsync
    * Added Convert property to V5Api.Account.GetBrokerAccountInfoAsync and GetBrokerEarningsAsync response models

* Version 3.10.3 - 02 Jul 2024
    * Updated CryptoExchange.Net to V7.8.0, see https://github.com/JKorf/CryptoExchange.Net/releases/tag/7.8.0
    * Added Turkey environment
    * Added prelisting properties to V5 linear/inverse tickers and symbols response models

* Version 3.10.2 - 26 Jun 2024
    * Fixed OrderBook model deserialization when updateId is too large for integer

* Version 3.10.1 - 25 Jun 2024
    * Updated CryptoExchange.Net to 7.7.2, see https://github.com/JKorf/CryptoExchange.Net/releases/tag/7.7.2
    * Fixed deserialization issue BybitPosition model

* Version 3.10.0 - 23 Jun 2024
    * Updated CryptoExchange.Net to version 7.7.0, see https://github.com/JKorf/CryptoExchange.Net/releases/tag/7.7.0
    * Added V5 websocket order placement API
    * Updated response models from classes to records
    * Added and updated DCP endpoints end subscription
    * Added dedicated connection configuration; a websocket connection can now be established before making the first request by calling `bybitSocketClient.V5PrivateApi.PrepareConnectionsAsync();`

* Version 3.9.0 - 11 Jun 2024
    * Added socketClient.V5PrivateApi.SubscribeToMinimalUserTradeUpdatesAsync private subscription
    * Updated CryptoExchange.Net to v7.6.0, see https://github.com/JKorf/CryptoExchange.Net?tab=readme-ov-file#release-notes for release notes

* Version 3.8.9 - 02 Jun 2024
    * Added missing StopLossTakeProfitMode enum value
    * Added Status property to V5Api.Account.CreateUniversalTransfer response model
    * Added cursor parameter to V5Api.ExchangeData.GetRiskLimitAsync

* Version 3.8.8 - 07 May 2024
    * Updated CryptoExchange.Net to v7.5.2, see https://github.com/JKorf/CryptoExchange.Net?tab=readme-ov-file#release-notes for release notes

* Version 3.8.7 - 06 May 2024
    * Split PurchaseLeverageTokenAsync and RedeemLeverageTokenAsync response models
    * Updated various response models
    * Fixed PurchaseLeverageTokenAsync, RedeemLeverageTokenAsync and GetLeverageTokenOrderHistoryAsync request path
    * Updated CryptoExchange.Net to v7.5.1, see https://github.com/JKorf/CryptoExchange.Net?tab=readme-ov-file#release-notes for release notes

* Version 3.8.6 - 01 May 2024
    * Updated CryptoExchange.Net to v7.5.0, see https://github.com/JKorf/CryptoExchange.Net?tab=readme-ov-file#release-notes for release notes

* Version 3.8.5 - 28 Apr 2024
    * Added V5Api.Account.RequestDemoFundsAsync endpoint
    * Added missing TransactionLogType enum values
    * Added Symbols to V5Api.ExchangeData.GetInsuranceAsync response model
    * Added BybitExchange static info class
    * Added BybitOrderBookFactory book creation method
    * Fixed BybitOrderBookFactory injection issue
    * Updated CryptoExchange.Net to v7.4.0, see https://github.com/JKorf/CryptoExchange.Net?tab=readme-ov-file#release-notes for release notes

* Version 3.8.4 - 26 Apr 2024
    * Fix deserialization issue in V5Api.ExchangeData.GetLinearInverseSymbolsAsync

* Version 3.8.3 - 23 Apr 2024
    * Updated V5Api.ExchangeData.GetServerTimeAsync to V5 endpoint
    * Fixed typo in InternalDepositStatus enum value
    * Updated CryptoExchange.Net to 7.3.3, see https://github.com/JKorf/CryptoExchange.Net?tab=readme-ov-file#release-notes for release notes

* Version 3.8.2 - 18 Apr 2024
    * Updated CryptoExchange.Net to 7.3.1, see https://github.com/JKorf/CryptoExchange.Net?tab=readme-ov-file#release-notes for release notes
    * Added MinNotionalValue to V5Api.ExchangeData.GetLinearInverseSymbolsAsync response model
    * Changed BestBid and BestAsk properties to be nullable in BybitLinearInverseTicker model

* Version 3.8.1 - 10 Apr 2024
    * Added ClientOrderId to BybitCancelOrderRequest model
    * Changed Quantity property in BybitEditOrderRequest model to be nullable

* Version 3.8.0 - 28 Mar 2024
    * Added HongKong and The Netherlands environments and API addresses
    * Added PublishTime to V5Api.ExchangeData.GetAnnouncementsAsync model
    * Updated websocket V5OptionsApi.SubscribeToTradeUpdatesAsync and rest V5Api.ExchangeData.GetTradeHistoryAsync models
    * Marked V5Api.Account.SetRiskLimitAsync as deprecated
    * Fixed V5Api.ExchangeData.GetLeverageTokensAsync deserialization issue
    * Fixed V5Api options websocket subscriptions

* Version 3.7.1 - 24 Mar 2024
	* Updated CryptoExchange.Net to 7.2.0, see https://github.com/JKorf/CryptoExchange.Net?tab=readme-ov-file#release-notes for release notes

* Version 3.7.0 - 16 Mar 2024
    * Updated CryptoExchange.Net to 7.1.0, see https://github.com/JKorf/CryptoExchange.Net?tab=readme-ov-file#release-notes for release notes
	
* Version 3.6.1 - 11 Mar 2024
    * Fixed V5Api websocket subscription missing initial snapshot updates

* Version 3.6.0 - 11 Mar 2024
    * Added V5Api.ExchangeData.GetLongShortRatioAsync endpoint
    * Added V5Api.Trading.ConfirmRiskLimitAsync endpoint
    * Added V5Api.Account.SetSpotHedgingModeAsync endpoint
    * Added V5Api.Account.RepayLiabilitiesAsync endpoint
    * Added TakeProfitStopLossMode parameter to V5Api.Trading.EditMultipleOrdersAsync endpoint
    * Added CloseOnTrigger parameter to V5Api.Trading.PlaceMultipleOrdersAsync endpoint
    * Added startTime/endTime parameters to V5Api.Trading.GetSettlementHistoryAsync and V5Api.Trading.GetDeliveryHistoryAsync endpoints
    * Updated BybitApiKeyInfo, BybitBorrowHistory, BybitBorrowQuota, BybitBalance, BybitPosition model
    * Updated StopOrderType, TradeType, TransactionLogType, WithdrawalStatus enum values
    * Fixed incorrect response model V5Api.Trading.SetDisconnectCancelAllAsync endpoint

* Version 3.5.2 - 28 Feb 2024
    * Fixed V5Api.Trading.GetPositionAsync model deserialization

* Version 3.5.1 - 27 Feb 2024
    * Updated V5 Linear/Inverse Symbol model
    * Fixed PositionIdx property in V5 order updates

* Version 3.5.0 - 26 Feb 2024
    * Fixed BybitSpotUserTradeV3 model mapping
    * Added Id to BybitTransactionLog model
    * Updated BybitPosition model
    * Updated Spot V3 and V5 order models
    * Removed deprecated endpoints and models

* Version 3.4.0 - 25 Feb 2024
    * Updated CryptoExchange.Net and implemented reworked websocket message handling. For release notes for the CryptoExchange.Net base library see: https://github.com/JKorf/CryptoExchange.Net?tab=readme-ov-file#release-notes
    * Fixed issue in DI registration causing http client to not be correctly injected
    * Combined update and snapshot handlers for orderbook updates in favor of the UpdateType in the DataEvent wrapper
    * Removed redundant BybitRestClient constructor overload
    * Removed deprecated socket APIs
    * Updated some namespaces

* Version 3.3.0 - 19 Jan 2024
    * Added V5Api.Account.GetBrokerEarningsAsync endpoint
    * Added V5Api.Account.GetBrokerAccountInfoAsync endpoint
    * Added V5Api.Account.GetInternalDepositsAsync endpoint
    * Added V5Api.Account.SetMultipleCollateralAssetsAsync endpoint
    * Added PricePercentageFilter to V5Api.ExchangeData.GetSpotSymbolsAsync model
    * Updated various endpoint parameters and models

* Version 3.2.7 - 16 Jan 2024
    * Added V5Api.Account.SetCollateralAssetAsync endpoint
    * Added marketUnit parameter to V5Api.Trading.PlaceOrderAsync endpoint
    * Updated BybitAccountInfo model

* Version 3.2.6 - 12 Dec 2023
    * Fixed V5 BybitOrderId model ClientOrderId deserialization
    * Added missing feeType parameter to V5 Account.WithdrawAsync endpoint

* Version 3.2.5 - 03 Dec 2023
    * Updated CryptoExchange.Net

* Version 3.2.4 - 02 Dec 2023
    * Added missing SelfMatchPreventType parameter to V5.Trading.PlaceOrderAsync
    * Fixed deserialization issue in V5 UserTrade subscription

* Version 3.2.3 - 28 Nov 2023
    * Added missing FeeAsset property order updates
    * Fixed UnifiedMarginStatus deserialization AccountInfo
    * Fixed ClientOrderId deserialization batch order results

* Version 3.2.2 - 30 Oct 2023
    * Fixed triggerDirection parameter serialization on V5 PlaceOrder endpoint
    * Fixed typo in BybitAccountTypeInfo model name

* Version 3.2.1 - 24 Oct 2023
    * Fix order parameter serialization
    * Updated CryptoExchange.Net

* Version 3.2.0 - 12 Oct 2023
    * Added V5 SubAccount endpoints
    * Added V5 ApiKey endpoints
    * Added LeverageToken endpoints
    * Added notice of deprecation to old endpoints
    * Updated Referer header

* Version 3.1.3 - 09 Oct 2023
    * Updated CryptoExchange.Net version
    * Fixed ReceiveWindow not respecting client option
    * Updated BoolConverter to shared CryptoExchange.Net implementation

* Version 3.1.2 - 29 Sep 2023
    * Added V5 Inverse websocket API
    * Fix V5 SubscribeToLiquidationUpdatesAsync
    * Fix V5Api.Account.GetCollateralInfoAsync deserialization

* Version 3.1.1 - 20 Sep 2023
    * Added ISpotClient/CommonSpotClient implementation
    * Added AddOrReduceMarginAsync endpoint
    * Added Spot Margin endpoints

* Version 3.1.0 - 05 Sep 2023
    * Added V5 Trading.PlaceMultipleOrdersAsync, V5 Trading.EditMultipleOrdersAsync and V5 Trading.CancelMultipleOrdersAsync endpoints
    * Fixed V5 Account.CreateUniversalTransferAsync parameter
    * Fixed V5 Account.GetWithdrawalsAsync deserialization

* Version 3.0.8 - 02 Sep 2023
    * Fixed V5.Account.GetAssetBalanceAsync deserialization
    * Added missing V5 Position model properties

* Version 3.0.7 - 25 Aug 2023
    * Updated CryptoExchange.Net

* Version 3.0.6 - 25 Aug 2023
    * Changed V5 API body content type from formdata to json

* Version 3.0.5 - 05 Aug 2023
    * Fixed default values V5 PlaceOrder parameters

* Version 3.0.4 - 02 Aug 2023
    * Removed incorrect checks for order id parameters in V5 trading endpoints
    * Added Start/Endtime to V5 order history
    * Added SL/TP parameters to V5 PlaceOrder endpoint
    * Added SL/TP parameters to contract PlaceOrder endpoint
    * Fixed nullability of position models

* Version 3.0.3 - 25 Jul 2023
    * Added missing MarginMode enum value
    * Fix for position V5 deserialization

* Version 3.0.2 - 23 Jul 2023
    * Fixed AveragePrice not set on V5 position update
    * Fixed multiple decimal field nullability
    * Fixed V5 spot symbol MarginTrading incorrect property name
    * Added missing tpslMode on V5 PlaceOrder
    * Fixed typo in Deactivated V5 order status mapping
    * Fixed incorrect filter types in V5 LinearInverse symbol model

* Version 3.0.1 - 11 Jul 2023
    * Fixed invalid V5 GetOrderHistory endpoint check
    * Fixed bool parameters V5 PlaceOrder
    * Removed Liquidation stream from V5 SpotApi

* Version 3.0.0 - 25 Jun 2023
    * Updated CryptoExchange.Net to version 6.0.0
    * Renamed BybitClient to BybitRestClient
    * Renamed **Streams to **Api on the BybitSocketClient
    * Updated endpoints to consistently use a base url without any path as basis to make switching environments/base urls clearer
    * Added IBybitOrderBookFactory and implementation for creating order books
    * Updated dependency injection register method (AddBybit)
    * Updated V5 socket API kline update topic to include the interval
    * Added CopyTrading SetTradingStopAsync endpoint
    * Fixed V5 GetMarginAccountInfoAsync endpoint

* Version 2.0.5 - 19 Jun 2023
    * Fixed V5 GetLinearInverseTickersAsync response model nullability
    * Added missing parameters V5 SetTradingStopAsync
    * Fixed incorrect V5 GetOrderAsync check

* Version 2.0.4 - 02 Jun 2023
    * Fixed deserialization error on V5 Inverse ticker model
    * Fixed V5 GetOrder incorrect validation check

* Version 2.0.3 - 22 May 2023
    * Fixed category parameter not being send on V5 GetFreeRateAsync
    * Fixed CreateTime deserialization on Spot V3 order model

* Version 2.0.2 - 14 May 2023
    * Fixed V5 GetTransactionHistory response model
    * Fixed V5 Account Withdraw incorrect parameter name
    * Fixed V5 Trading PlaceOrder incorrect position parameter

* Version 2.0.1 - 25 Apr 2023
    * Fixed V5.Account.CreateInternalTransfer endpoint

* Version 2.0.0 - 14 Apr 2023
    * Added V5 API implementation
    * Fixed contract PlaceOrder parameters

* Version 1.5.2 - 18 Mar 2023
    * Fixed SpotV3 GetBalances
    * Fixed SetPositionMode on contract API
    * Updated CryptoExchange.Net

* Version 1.5.1 - 14 Feb 2023
    * Updated CryptoExchange.Net

* Version 1.5.0 - 05 Feb 2023
    * Fixed error parsing for list results
    * Fixed V3 GetUserTradesAsync deserialization

* Version 1.4.0 - 29 Dec 2022
    * Added DerivativesV3 API
    * Fixed spot PlaceBorrowOrderAsync deserialization
    * Added missing properties BybitApiKeyInfo

* Version 1.3.1 - 12 Dec 2022
    * Added General.Transfer.GetAssetBalanceAsync endpoint
    * Spot V3 usability improvements
    * Fixed CopyTradeApi PlaceOrderAsync
    * Added missing spot order status mapping
    * Added interval to SubscribeToKlineUpdatesAsync topic

* Version 1.3.0 - 17 Nov 2022
    * Updated CryptoExchange.Net
    * Fixed SpotV3 GetUserTrades endpoint

* Version 1.2.3 - 28 Oct 2022
    * Fixed timestamping inconsistencies between different APIs

* Version 1.2.2 - 28 Oct 2022
    * Fixed SpotV3 API error parsing
    * Fixed CopyTrading API using wrong timestamp for synchronizing timestamps

* Version 1.2.1 - 15 Oct 2022
    * Added support for SL/TP updates via websocket in Spot API
    * Added support for switching PositionMode per asset
    * Fix for missing properties on order model
    * Fixed deserialization issue due to nullability on spot GetTickersAsync API

* Version 1.2.0 - 11 Oct 2022
    * Added support for all Spot API versions (rest V1 and V3, socket V1, V2 and V3)
    * Fix for Usd perpetual futures conditional order parsing
    * Upped the expiration time for websocket authentication

* Version 1.1.2 - 28 Sep 2022
    * Fixed SubscribeToTickerUpdatesAsync OpenInterest value parsing
    * Added missing ReduceOnly field to BybitConditionalOrder model
    * Fixed documentation links

* Version 1.1.1 - 19 Aug 2022
    * Added TakeProfitPrice, StopLossPrice and TriggerPrice to BybitConditionalOrder model
    * Fixed WithdrawalAsync quantity parameter being wrongly named
    * Fixed GetBorrowInterestAndQuotaAsync not being signed

* Version 1.1.0 - 31 Jul 2022
    * Added Deposit/Withdrawal endpoints
    * Added CopyTrading Api
    * Added UniversalTransfer endpoints

* Version 1.0.10 - 18 Jul 2022
    * Added cross-margin endpoints
    * Fixed websocket reconnect loop issue
    * Updated some spot API models
    * Updated CryptoExchange.Net

* Version 1.0.9 - 16 Jul 2022
    * Updated CryptoExchange.Net

* Version 1.0.8 - 10 Jul 2022
    * Fixed InversePerpetual stop order stream incorrect topic
    * Fixed rate limit deserialization
    * Fixed typo in FreeQuantity property in Usd Position model

* Version 1.0.7 - 10 Jul 2022
    * Added missing PartialStopLoss to StopOrderType
    * Fixed 1 month kline being serialized as 1 minute
    * Updated CryptoExchange.Net

* Version 1.0.6 - 12 Jun 2022
    * Added missing price properties on usdt perpetual conditional order model
    * Updated CryptoExchange.Net

* Version 1.0.5 - 24 May 2022
    * Updated CryptoExchange.Net

* Version 1.0.4 - 22 May 2022
    * Fixed socket subscription error feedback
    * Updated CryptoExchange.Net

* Version 1.0.3 - 11 May 2022
    * Fixed Usd perpetual real time endpoint urls
    * Fixed BybitUserTrades deserialization

* Version 1.0.2 - 08 May 2022
    * Removed unneeded receiveWindow parameter unauthenticated requests
    * Fixed receiveWindow parameter for futures apis
    * Added missing PositionMode property on USD futures position
    * Fixed incorrect stop_order topic for usd perpetual StopOrder subscription
    * Updated CryptoExchange.Net

* Version 1.0.1 - 01 May 2022
    * Updated CryptoExchange.Net which fixed an timing related issue in the websocket reconnection logic
    * Added seconds representation to KlineInterval enum
    * Fixed deserialization of orders with fee of null
    * Fixed SetLeverageAsync deserialization error on return null result
    * Added missing Asset property on socket Balance update

* Version 1.0.0 - 14 Apr 2022
    * Fixed Transfer API
    * Added missing SpotOrderTypes
    * Added Referer option in client options to set x-referer header
    * Updated CryptoExchange.Net

* Version 0.0.9 - 17 Mar 2022
    * Split USD Perpetual/Inverse API order models to properly map Base/QuoteQuantity properties

* Version 0.0.8 - 16 Mar 2022
    * Fixed Bids/Asks being reversed in spot order book updates (also impacted BybitSpotSymbolOrderBook)
    * Fixed swapped quantity properties on models

* Version 0.0.7 - 14 Mar 2022
    * Added CancelMultipleOrdersAsync Spot API endpoint
    * Fixed swapped QuoteQuantityFilled/BaseQuantityFilled order model properties
    * Fixed LimitMaker order type (de)serialization

* Version 0.0.6 - 10 Mar 2022
    * Updated CryptoExchange.Net

* Version 0.0.5 - 08 Mar 2022
    * Fixed typo in BybitBalanceUpdate model
    * Updated CryptoExchange.Net

* Version 0.0.4 - 01 Mar 2022
    * Updated CryptoExchange.Net improving the websocket reconnection robustness

* Version 0.0.3 - 27 Feb 2022
    * Updated CryptoExchange.Net to fix timestamping issue when request is ratelimiter

* Version 0.0.2 - 24 Feb 2022
    * Updated CryptoExchange.Net

* Version 0.0.1 - 18 Feb 2022
	* Initial release

