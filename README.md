# Bybit.Net
[![.NET](https://github.com/JKorf/Bybit.Net/actions/workflows/dotnet.yml/badge.svg)](https://github.com/JKorf/Bybit.Net/actions/workflows/dotnet.yml) ![Nuget version](https://img.shields.io/nuget/v/Bybit.net.svg)  ![Nuget downloads](https://img.shields.io/nuget/dt/Bybit.Net.svg)
 
Bybit.Net is a wrapper around the Bybit API as described on [Bybit](https://bybit-exchange.github.io/docs/spot/#t-introduction), including all features the API provides using clear and readable objects, both for the REST  as the websocket API's.

**If you think something is broken, something is missing or have any questions, please open an [Issue](https://github.com/JKorf/Bybit.Net/issues)**

[Documentation](https://jkorf.github.io/Bybit.Net/)

## Support the project
I develop and maintain this package on my own for free in my spare time, any support is greatly appreciated.

### Referral link
Sign up using the following referral link to pay a small percentage of the trading fees you pay to support the project instead of paying them straight to Bybit. This doesn't cost you a thing!
[Link](https://partner.bybit.com/b/jkorf)

### Donate
Make a one time donation in a crypto currency of your choice. If you prefer to donate a currency not listed here please contact me.

**Btc**:  12KwZk3r2Y3JZ2uMULcjqqBvXmpDwjhhQS  
**Eth**:  0x069176ca1a4b1d6e0b7901a6bc0dbf3bb0bf5cc2  
**Nano**: xrb_1ocs3hbp561ef76eoctjwg85w5ugr8wgimkj8mfhoyqbx4s1pbc74zggw7gs  

### Sponsor
Alternatively, sponsor me on Github using [Github Sponsors](https://github.com/sponsors/JKorf). 

## Discord
A Discord server is available [here](https://discord.gg/MSpeEtSY8t). Feel free to join for discussion and/or questions around the CryptoExchange.Net and implementation libraries.

## Release notes
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

