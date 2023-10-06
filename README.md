# Bybit.Net
[![.NET](https://github.com/JKorf/Bybit.Net/actions/workflows/dotnet.yml/badge.svg)](https://github.com/JKorf/Bybit.Net/actions/workflows/dotnet.yml) []![Nuget version](https://img.shields.io/nuget/v/Bybit.net.svg)(https://www.nuget.org/packages/Bybit.Net)  [![Nuget downloads](https://img.shields.io/nuget/dt/Bybit.Net.svg)](https://www.nuget.org/packages/Bybit.Net)
 
Bybit.Net is a wrapper around the Bybit API as described on [Bybit](https://bybit-exchange.github.io/docs/spot/#t-introduction), including all features the API provides using clear and readable objects, both for the REST  as the websocket API's.

**If you think something is broken, something is missing or have any questions, please open an [Issue](https://github.com/JKorf/Bybit.Net/issues)**

[Documentation](https://jkorf.github.io/Bybit.Net/)

## Installation
`dotnet add package Bybit.Net`

## Support the project
I develop and maintain this package on my own for free in my spare time, any support is greatly appreciated.

### Referral link
Sign up using the following referral link to pay a small percentage of the trading fees you pay to support the project instead of paying them straight to Bybit. This doesn't cost you a thing!
[Link](https://partner.bybit.com/b/jkorf)

### Donate
Make a one time donation in a crypto currency of your choice. If you prefer to donate a currency not listed here please contact me.

**Btc**:  bc1qz0jv0my7fc60rxeupr23e75x95qmlq6489n8gh  
**Eth**:  0x8E21C4d955975cB645589745ac0c46ECA8FAE504  

### Sponsor
Alternatively, sponsor me on Github using [Github Sponsors](https://github.com/sponsors/JKorf). 

## Discord
A Discord server is available [here](https://discord.gg/MSpeEtSY8t). Feel free to join for discussion and/or questions around the CryptoExchange.Net and implementation libraries.

## Release notes
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

