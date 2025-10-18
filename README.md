# ![.Bybit.Net](https://github.com/JKorf/Bybit.Net/blob/main/ByBit.Net/Icon/icon.png?raw=true) Bybit.Net

[![.NET](https://img.shields.io/github/actions/workflow/status/JKorf/Bybit.Net/dotnet.yml?style=for-the-badge)](https://github.com/JKorf/Bybit.Net/actions/workflows/dotnet.yml) ![License](https://img.shields.io/github/license/JKorf/Bitget.Net?style=for-the-badge)
 
Bybit.Net is a strongly typed client library for accessing the [Bybit REST and Websocket API](https://bybit-exchange.github.io/docs/spot/#t-introduction).
## Features
* Response data is mapped to descriptive models
* Input parameters and response values are mapped to discriptive enum values where possible
* Automatic websocket (re)connection management 
* Client side order book implementation
* Support for managing different accounts
* Extensive logging
* Support for different environments (production, testnet, Hongkong, The Netherlands, Turkey, ..)
* Easy integration with other exchange client based on the CryptoExchange.Net base library
* Native AOT support

## Supported Frameworks
The library is targeting both `.NET Standard 2.0` and `.NET Standard 2.1` for optimal compatibility, as well as dotnet 8.0 and 9.0 to use the latest framework features.

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

For information on the clients, dependency injection, response processing and more see the [Bybit.Net documentation](https://cryptoexchange.jkorf.dev?library=Bybit.Net), [CryptoExchange.Net documentation](https://jkorf.github.io/CryptoExchange.Net), or have a look at the examples [here](https://github.com/JKorf/Bybit.Net/tree/main/Examples) or [here](https://github.com/JKorf/CryptoExchange.Net/tree/master/Examples).

## CryptoExchange.Net
Bybit.Net is based on the [CryptoExchange.Net](https://github.com/JKorf/CryptoExchange.Net) base library. Other exchange API implementations based on the CryptoExchange.Net base library are available and follow the same logic.

CryptoExchange.Net also allows for [easy access to different exchange API's](https://cryptoexchange.jkorf.dev/client-libs/shared).

|Exchange|Repository|Nuget|
|--|--|--|
|Aster|[JKorf/Aster.Net](https://github.com/JKorf/Aster.Net)|[![Nuget version](https://img.shields.io/nuget/v/JKorf.Aster.net.svg?style=flat-square)](https://www.nuget.org/packages/JKorf.Aster.Net)|
|Binance|[JKorf/Binance.Net](https://github.com/JKorf/Binance.Net)|[![Nuget version](https://img.shields.io/nuget/v/Binance.net.svg?style=flat-square)](https://www.nuget.org/packages/Binance.Net)|
|BingX|[JKorf/BingX.Net](https://github.com/JKorf/BingX.Net)|[![Nuget version](https://img.shields.io/nuget/v/JK.BingX.net.svg?style=flat-square)](https://www.nuget.org/packages/JK.BingX.Net)|
|Bitfinex|[JKorf/Bitfinex.Net](https://github.com/JKorf/Bitfinex.Net)|[![Nuget version](https://img.shields.io/nuget/v/Bitfinex.net.svg?style=flat-square)](https://www.nuget.org/packages/Bitfinex.Net)|
|Bitget|[JKorf/Bitget.Net](https://github.com/JKorf/Bitget.Net)|[![Nuget version](https://img.shields.io/nuget/v/JK.Bitget.net.svg?style=flat-square)](https://www.nuget.org/packages/JK.Bitget.Net)|
|BitMart|[JKorf/BitMart.Net](https://github.com/JKorf/BitMart.Net)|[![Nuget version](https://img.shields.io/nuget/v/BitMart.net.svg?style=flat-square)](https://www.nuget.org/packages/BitMart.Net)|
|BitMEX|[JKorf/BitMEX.Net](https://github.com/JKorf/BitMEX.Net)|[![Nuget version](https://img.shields.io/nuget/v/JKorf.BitMEX.net.svg?style=flat-square)](https://www.nuget.org/packages/JKorf.BitMEX.Net)|
|BloFin|[JKorf/BloFin.Net](https://github.com/JKorf/BloFin.Net)|[![Nuget version](https://img.shields.io/nuget/v/BloFin.net.svg?style=flat-square)](https://www.nuget.org/packages/BloFin.Net)|
|Coinbase|[JKorf/Coinbase.Net](https://github.com/JKorf/Coinbase.Net)|[![Nuget version](https://img.shields.io/nuget/v/JKorf.Coinbase.Net.svg?style=flat-square)](https://www.nuget.org/packages/JKorf.Coinbase.Net)|
|CoinEx|[JKorf/CoinEx.Net](https://github.com/JKorf/CoinEx.Net)|[![Nuget version](https://img.shields.io/nuget/v/CoinEx.net.svg?style=flat-square)](https://www.nuget.org/packages/CoinEx.Net)|
|CoinGecko|[JKorf/CoinGecko.Net](https://github.com/JKorf/CoinGecko.Net)|[![Nuget version](https://img.shields.io/nuget/v/CoinGecko.net.svg?style=flat-square)](https://www.nuget.org/packages/CoinGecko.Net)|
|CoinW|[JKorf/CoinW.Net](https://github.com/JKorf/CoinW.Net)|[![Nuget version](https://img.shields.io/nuget/v/CoinW.net.svg?style=flat-square)](https://www.nuget.org/packages/CoinW.Net)|
|Crypto.com|[JKorf/CryptoCom.Net](https://github.com/JKorf/CryptoCom.Net)|[![Nuget version](https://img.shields.io/nuget/v/CryptoCom.net.svg?style=flat-square)](https://www.nuget.org/packages/CryptoCom.Net)|
|DeepCoin|[JKorf/DeepCoin.Net](https://github.com/JKorf/DeepCoin.Net)|[![Nuget version](https://img.shields.io/nuget/v/DeepCoin.net.svg?style=flat-square)](https://www.nuget.org/packages/DeepCoin.Net)|
|Gate.io|[JKorf/GateIo.Net](https://github.com/JKorf/GateIo.Net)|[![Nuget version](https://img.shields.io/nuget/v/GateIo.net.svg?style=flat-square)](https://www.nuget.org/packages/GateIo.Net)|
|HTX|[JKorf/HTX.Net](https://github.com/JKorf/HTX.Net)|[![Nuget version](https://img.shields.io/nuget/v/JKorf.HTX.Net.svg?style=flat-square)](https://www.nuget.org/packages/JKorf.HTX.Net)|
|HyperLiquid|[JKorf/HyperLiquid.Net](https://github.com/JKorf/HyperLiquid.Net)|[![Nuget version](https://img.shields.io/nuget/v/HyperLiquid.Net.svg?style=flat-square)](https://www.nuget.org/packages/HyperLiquid.Net)|
|Kraken|[JKorf/Kraken.Net](https://github.com/JKorf/Kraken.Net)|[![Nuget version](https://img.shields.io/nuget/v/KrakenExchange.net.svg?style=flat-square)](https://www.nuget.org/packages/KrakenExchange.Net)|
|Kucoin|[JKorf/Kucoin.Net](https://github.com/JKorf/Kucoin.Net)|[![Nuget version](https://img.shields.io/nuget/v/Kucoin.net.svg?style=flat-square)](https://www.nuget.org/packages/Kucoin.Net)|
|Mexc|[JKorf/Mexc.Net](https://github.com/JKorf/Mexc.Net)|[![Nuget version](https://img.shields.io/nuget/v/JK.Mexc.net.svg?style=flat-square)](https://www.nuget.org/packages/JK.Mexc.Net)|
|OKX|[JKorf/OKX.Net](https://github.com/JKorf/OKX.Net)|[![Nuget version](https://img.shields.io/nuget/v/JK.OKX.net.svg?style=flat-square)](https://www.nuget.org/packages/JK.OKX.Net)|
|Toobit|[JKorf/Toobit.Net](https://github.com/JKorf/Toobit.Net)|[![Nuget version](https://img.shields.io/nuget/v/Toobit.net.svg?style=flat-square)](https://www.nuget.org/packages/Toobit.Net)|
|WhiteBit|[JKorf/WhiteBit.Net](https://github.com/JKorf/WhiteBit.Net)|[![Nuget version](https://img.shields.io/nuget/v/WhiteBit.net.svg?style=flat-square)](https://www.nuget.org/packages/WhiteBit.Net)|
|XT|[JKorf/XT.Net](https://github.com/JKorf/XT.Net)|[![Nuget version](https://img.shields.io/nuget/v/XT.net.svg?style=flat-square)](https://www.nuget.org/packages/XT.Net)|

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

### Referal
If you do not yet have an account please consider using this referal link to sign up:  
[Link](https://partner.bybit.com/b/jkorf)

### Donate
Make a one time donation in a crypto currency of your choice. If you prefer to donate a currency not listed here please contact me.

**Btc**:  bc1q277a5n54s2l2mzlu778ef7lpkwhjhyvghuv8qf  
**Eth**:  0xcb1b63aCF9fef2755eBf4a0506250074496Ad5b7   
**USDT (TRX)**  TKigKeJPXZYyMVDgMyXxMf17MWYia92Rjd 

### Sponsor
Alternatively, sponsor me on Github using [Github Sponsors](https://github.com/sponsors/JKorf). 

## Release notes
* Version 5.10.1 - 18 Oct 2025
    * Fixed deserialization issue for decimal values using scientific exponent notation in certain models

* Version 5.10.0 - 16 Oct 2025
    * Updated CryptoExchange.Net version to 9.10.0, see https://github.com/JKorf/CryptoExchange.Net/releases/
    * Added ClientOrderId mapping on SharedUserTrade models
    * Added ITransferRestClient.TransferAsync implementation
    * Added symbolType parameter to restClient.V5Api.ExchangeData.GetLinearInverseSymbolsAsync endpoint
    * Added MaxMarketOrderQuantity and MaxLimitOrderQuantity properties to BybitSpotSymbol response model

* Version 5.9.0 - 30 Sep 2025
    * Updated CryptoExchange.Net version to 9.8.0, see https://github.com/JKorf/CryptoExchange.Net/releases/
    * Added ITrackerFactory to TrackerFactory implementation
    * Added ContractAddress mapping in Shared IAssetClient implementation
    * Added SpotBorrow property to BybitBalance model
    * Added restClient.V5Api.ExchangeData.GetRpiOrderbookAsync endpoint
    * Added FeeDetails property to BybitOrder response model
    * Added restClient.V5Api.ExchangeData.GetAdlAlertsAsync endpoint
    * Added socketClient.V5LinearApi.SubscribeToAdlAlertUpdatesAsync subscription
    * Added restClient.V5Api.ExchangeData.GetIndexPriceComponentsAsync endpoint
    * Added SymbolType property to GetSymbol response models

* Version 5.8.0 - 01 Sep 2025
    * Updated CryptoExchange.Net version to 9.7.0, see https://github.com/JKorf/CryptoExchange.Net/releases/
    * HTTP REST requests will now use HTTP version 2.0 by default
    * Added toAccountType parameter to restClient.V5Api.Earn.PlaceOrderAsync endpoint

* Version 5.7.0 - 25 Aug 2025
    * Updated CryptoExchange.Net version to 9.6.0, see https://github.com/JKorf/CryptoExchange.Net/releases/
    * Added ClearUserClients method to user client provider

* Version 5.6.1 - 21 Aug 2025
    * Added check for parsing Unauthorized response
    * Added websocket error mapping

* Version 5.6.0 - 20 Aug 2025
    * Updated CryptoExchange.Net to version 9.5.0, see https://github.com/JKorf/CryptoExchange.Net/releases/
    * Added improved error parsing
    * Added Sequence property for socketClient.V5SpotApi.SubscribeToTradeUpdatesAsync updates
    * Added Sequence property to restClient.V5Api.ExchangeData.GetTradeHistoryAsync response
    * Added MatchingEngineTimestamp to order book websocket updates and rest responses
    * Added Uta to restClient.V5Api.Account.GetDelayedWithdrawQuantityAsync response model
    * Updated restClient.V5Api.Account.WithdrawAsync accountType parameter type and is now mandatory
    * Updated rest request sending too prevent duplicate parameter serialization
    * Fixed socketClient.V5SpotApi.SubscribeToOrderbookUpdatesAsync update Timestamp property not being set

* Version 5.5.0 - 04 Aug 2025
    * Updated CryptoExchange.Net to version 9.4.0, see https://github.com/JKorf/CryptoExchange.Net/releases/
    * Added support for multi-symbol Shared socket subscriptions
    * Updated socket client connecting to live environment for public data when BybitEnvironment is set to DemoTrading
    * Fixed shared GetBalancesAsync and SubscribeToBalanceUpdatesAsync Available property not correct
    * Added restClient.V5Api.Account.SetPriceLimitBehaviorAsync endpoint

* Version 5.4.0 - 23 Jul 2025
    * Updated CryptoExchange.Net to version 9.3.0, see https://github.com/JKorf/CryptoExchange.Net/releases/
    * Updated websocket message matching
    * Added SubscribeToRpiOrderbookUpdatesAsync subscription

* Version 5.3.0 - 15 Jul 2025
    * Updated CryptoExchange.Net to version 9.2.0, see https://github.com/JKorf/CryptoExchange.Net/releases/
    * Added restClient.V5Api.ExchangeData.GetOrderPriceLimitAsync endpoint and socketClient SubscribeToPriceLimitUpdatesAsync subscriptions
    * Added OpenFee/CloseFee to restClient.V5Api.Trading.GetClosedProfitLossAsync response model
    * Added AverageEntryPrice property to restClient.V5Api.Trading.GetDeliveryHistoryAsync response model
    * Added FeeV2 and FeeAsset to BybitSpreadUserTrade model
    * Added FeeV2 to BybitUserTrade model
    * Added InitialMarginByMarkPrice and MaintenanceMarginByMarkPrice properties to BybitPosition model
    * Added Georgia environment
    * Added restClient.V5Api.ExchangeData.GetSystemStatusAsync endpoint
    * Added socketClient.V5SpotApi.SubscribeToSystemStatusUpdatesAsync subscription
    * Updated BybitBalance model with ByMarkPrice properties
    * Updated TransactionLogType enum values
    * Fixed issue in restClient.V5Api.Account.RequestDemoFundsAsync request signing
    * Fixed socketClient.V5PrivateApi.SubscribeToSpreadUserTradeUpdatesAsync update model

* Version 5.2.0 - 20 Jun 2025
    * Added restClient.V5Api.Trading.PreCheckOrderAsync endpoint
    * Added RequiredConfirmations property to BybitUserAssetInfo model
    * Added Id property to BybitDeposit model
    * Added id and transactionId parameters to restClient.V5Api.Account.GetDepositsAsync endpoint

* Version 5.1.0 - 02 Jun 2025
    * Updated CryptoExchange.Net to version 9.1.0, see https://github.com/JKorf/CryptoExchange.Net/releases/
    * Added (I)BybitUserClientProvider allowing for easy client management when handling multiple users
    * Added socketClient.V5LinearApi.SubscribeToInsurancePoolUpdatesAsync subscription
    * Added socketClient.V5InverseApi.SubscribeToInsurancePoolUpdatesAsync subscription
    * Added settleAsset parameter to restClient.V5Api.ExchangeData.GetDeliveryPriceAsync endpoint
    * Added restClient.V5Api.SubAccount.GetSubAccountDepositAddressAsync endpoint
    * Fixed serialization issues for Spread trading endpoints

* Version 5.0.0 - 13 May 2025
    * Updated CryptoExchange.Net to version 9.0.0, see https://github.com/JKorf/CryptoExchange.Net/releases/
    * Added support for Native AOT compilation
    * Added RateLimitUpdated event
    * Added SharedSymbol response property to all Shared interfaces response models returning a symbol name
    * Added GenerateClientOrderId method to V5 Shared client
    * Added OptionalExchangeParameters and Supported properties to EndpointOptions
    * Added support for Spread trading
    * Added IBookTickerRestClient implementation to V5Api Shared client
    * Added ISpotOrderClientIdClient implementation to V5Api Shared client
    * Added IFuturesOrderClientIdClient implementation to V5Api Shared client
    * Added ISpotTriggerOrderRestClient implementation to V5Api Shared client
    * Added IFuturesTriggerOrderRestClient implementation to V5Api Shared client
    * Added IFuturesTpSlRestClient implementation to V5Api Shared client
    * Added TriggerPrice, IsTriggerOrder to SharedSpotOrder model
    * Added TriggerPrice, IsTriggerOrder, StopLossPrice, TakeProfitPrice to SharedFuturesOrder model
    * Added MaxLongLeverage, MaxShortLeverage to SharedFuturesSymbol model
    * Added QuoteVolume property mapping to SharedSpotTicker model
    * Added OnChain value to EarnCategory Enum
    * Added All property to retrieve all available environment on BybitEnvironment
    * Added missing Unknown value to OrderType Enum
    * Added MaintenanceMarginDeduction property to BybitRiskLimit model
    * Added DisplayName to BybitLinearInverseSymbol and BybitOptionSymbol models
    * Refactored Shared clients quantity parameters and responses to use SharedQuantity
    * Updated all IEnumerable response and model types to array response types
    * Updated restClient.V5Api.Trading.PlaceMultipleOrdersAsync and socketClient.V5PrivateApi.PlaceMultipleOrdersAsync to return a list of CallResult models and an error if all orders fail to place
    * Removed Newtonsoft.Json dependency
    * Removed legacy ISpotClient implementation
    * Removed legacy AddBybit(restOptions, socketOptions) DI overload
    * Fixed incorrect DataTradeMode on certain Shared interface responses
    * Fixed OrderPrice returned as 0 instead of null in socket order updates
    * Fixed some list results being empty while there is data
    * Fixed error in V5 Shared SubscribeToBookTickerUpdatesAsync subscription
    * Fixed some typos

* Version 5.0.0-beta3 - 01 May 2025
    * Updated CryptoExchange.Net version to 9.0.0-beta5
    * Added property to retrieve all available API environments

* Version 5.0.0-beta2 - 23 Apr 2025
    * Updated CryptoExchange.Net to version 9.0.0-beta2
    * Added Shared spot ticker QuoteVolume mapping
    * Fixed incorrect DataTradeMode on responses

* Version 5.0.0-beta1 - 22 Apr 2025
    * Updated CryptoExchange.Net to version 9.0.0-beta1, see https://github.com/JKorf/CryptoExchange.Net/releases/
    * Added support for Native AOT compilation
    * Added RateLimitUpdated event
    * Added SharedSymbol response property to all Shared interfaces response models returning a symbol name
    * Added GenerateClientOrderId method to V5 Shared client
    * Added OptionalExchangeParameters and Supported properties to EndpointOptions
    * Added support for Spread trading
    * Added IBookTickerRestClient implementation to V5Api Shared client
    * Added ISpotOrderClientIdClient implementation to V5Api Shared client
    * Added IFuturesOrderClientIdClient implementation to V5Api Shared client
    * Added ISpotTriggerOrderRestClient implementation to V5Api Shared client
    * Added IFuturesTriggerOrderRestClient implementation to V5Api Shared client
    * Added IFuturesTpSlRestClient implementation to V5Api Shared client
    * Added TriggerPrice, IsTriggerOrder to SharedSpotOrder model
    * Added TriggerPrice, IsTriggerOrder, StopLossPrice, TakeProfitPrice to SharedFuturesOrder model
    * Added MaxLongLeverage, MaxShortLeverage to SharedFuturesSymbol model
    * Added OnChain value to EarnCategory enum
    * Refactored Shared clients quantity parameters and responses to use SharedQuantity
    * Updated all IEnumerable response and model types to array response types
    * Updated restClient.V5Api.Trading.PlaceMultipleOrdersAsync and socketClient.V5PrivateApi.PlaceMultipleOrdersAsync to return a list of CallResult models and an error if all orders fail to place
    * Removed Newtonsoft.Json dependency
    * Removed legacy ISpotClient implementation
    * Removed legacy AddBybit(restOptions, socketOptions) DI overload
    * Fixed error in V5 Shared SubscribeToBookTickerUpdatesAsync subscription
    * Fixed some typos

* Version 4.4.1 - 28 Mar 2025
    * Removed incorrect id parameters checks from some endpoints

* Version 4.4.0 - 24 Mar 2025
    * Added socketClient.V5PrivateApi.PlaceMultipleOrdersAsync, EditMultipleOrdersAsync and CancelMultipleOrdersAsync requests
    * Added SlippageTolerance support for orders

* Version 4.3.2 - 03 Mar 2025
    * Fix for restClient.V5Api.CryptoLoan.GetOpenLoansAsync deserialization

* Version 4.3.1 - 25 Feb 2025
    * Fixed restClient.V5Api.CryptoLoan.BorrowAsync parameter serialization

* Version 4.3.0 - 20 Feb 2025
    * Added Bybit Earn endpoints to restClient.V5Api.Earn
    * Added socket SubscribeToAllLiquidationUpdatesAsync subscription
    * Marked SubscribeToLiquidationUpdatesAsync as deprecated

* Version 4.2.0 - 19 Feb 2025
    * Added restClient.V5Api.ExchangeData.GetSpotMarginTieredCollateralRatioAsync endpoint
    * Added restClient.V5Api.Account.GetTransferableAsync multi-asset overload and updated response model
    * Added quoteAsset parameter to restClient.V5Api.ExchangeData.GetHistoricalVolatilityAsync endpoint
    * Added support for RPI (RetailPriceImprovement) orders and data
    * Fix for pagination in restClient.V5Api.SharedClient.GetKlinesAsync

* Version 4.1.0 - 11 Feb 2025
    * Updated CryptoExchange.Net to version 8.8.0, see https://github.com/JKorf/CryptoExchange.Net/releases/
    * Added support for more SharedKlineInterval values
    * Added setting of DataTime value on websocket DataEvent updates
    * Fix Mono runtime exception on rest client construction using DI

* Version 4.0.2 - 18 Jan 2025
    * Added DepositLimit, DepositType and FromAddress to restClient.V5Api.Account.GetDepositsAsync response model
    * Added DepositLimit and ContractAddress to restClient.V5Api.Account.GetDepositAddressAsync response model
    * Added ContractAddress to restClient.V5Api.Account.GetAssetInfoAsync response model
    * Added TradeId property to restClient.V5Api.Account.GetBrokerEarningsAsync response model
    * Updated restClient.V5Api.ExchangeData.GetSpotSymbolsAsync PricePercentageFilter response model to new x/y limit value properties
    * Fixed shared interfaces futures symbols request not returning full data set

* Version 4.0.1 - 09 Jan 2025
    * Fixed AveragePrice being null in BybitPosition and BybitPositionUpdate models

* Version 4.0.0 - 07 Jan 2025
    * Updated from Newtonsoft.Json to System.Text.Json
    * Added CryptoLoan endpoints
    * Added client side ratelimiting
    * Added Type property to XTExchange class
    * Updated CryptoExchange.Net version
    * Updated some namespaces
    * Removed deprecated V1/V2/V3 endpoints, models and enums

* Version 3.19.2 - 03 Jan 2025
    * Added RiskParameters properties to restClient.V5Api.ExchangeData.GetLinearInverseSymbolsAsync response model

* Version 3.19.1 - 23 Dec 2024
    * Fixed restClient.V5Api.SubAccount.EditSubAccountApiKeyAsync parameters not getting send

* Version 3.19.0 - 23 Dec 2024
    * Updated CryptoExchange.Net to version 8.5.0, see https://github.com/JKorf/CryptoExchange.Net/releases/
    * Added SetOptions methods on Rest and Socket clients
    * Added setting of DefaultProxyCredentials to CredentialCache.DefaultCredentials on the DI http client
    * Improved websocket disconnect detection

* Version 3.18.2 - 12 Dec 2024
    * Added restClient.V5Api.Account.GetTransferableAsync endpoint
    * Fixed socketClient.V5PrivateApi.CancelOrderAsync incorrect topic

* Version 3.18.1 - 03 Dec 2024
    * Updated CryptoExchange.Net to version 8.4.3, see https://github.com/JKorf/CryptoExchange.Net/releases/
    * Fixed orderbook creation via BybitOrderBookFactory

* Version 3.18.0 - 28 Nov 2024
    * Updated CryptoExchange.Net to version 8.4.0, see https://github.com/JKorf/CryptoExchange.Net/releases/tag/8.4.0
    * Added GetFeesAsync Shared REST client implementations
    * Added startTime/endTime params to restClient.V5Api.ExchangeData.GetLongShortRatioAsync endpoint
    * Added SpecialTreatmentLabel to restClient.V5Api.ExchangeData.GetSpotSymbolsAsync response model
    * Updated BybitOptions to LibraryOptions implementation
    * Updated test and analyzer package versions

* Version 3.17.0 - 19 Nov 2024
    * Updated CryptoExchange.Net to version 8.3.0
    * Added support for loading client settings from IConfiguration
    * Added DI registration method for configuring Rest and Socket options at the same time
    * Added DisplayName and ImageUrl properties to BybitExchange class
    * Updated client constructors to accept IOptions from DI
    * Updated UnifiedMarginStatus enum values
    * Removed redundant BybitSocketClient constructor

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

