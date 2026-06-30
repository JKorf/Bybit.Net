# ![.Bybit.Net](https://github.com/JKorf/Bybit.Net/blob/main/ByBit.Net/Icon/icon.png?raw=true) Bybit.Net

[![.NET](https://img.shields.io/github/actions/workflow/status/JKorf/Bybit.Net/dotnet.yml?style=for-the-badge)](https://github.com/JKorf/Bybit.Net/actions/workflows/dotnet.yml) ![License](https://img.shields.io/github/license/JKorf/Bitget.Net?style=for-the-badge)
 ![Since](https://img.shields.io/badge/since-2021-brightgreen?style=for-the-badge)
 
Bybit.Net is a strongly typed client library for accessing the [Bybit REST and Websocket API](https://bybit-exchange.github.io/docs/spot/#t-introduction).
## Features
* Response data is mapped to descriptive models
* Input parameters and response values are mapped to discriptive enum values where possible
* High performance
* Automatic websocket (re)connection management 
* Client side order book implementation
* Support for managing different accounts
* Extensive logging
* Support for different environments (production, testnet, Hongkong, The Netherlands, Turkey, ..)
* Easy integration with other exchange client based on the CryptoExchange.Net base library
* Native AOT support

## Benchmark
Performance is a core focus. For a benchmark comparing Bybit.Net performance to CCXT and Bybit.Api, see [docs/bybit-net-benchmark.md](docs/bybit-net-benchmark.md).

## Supported Frameworks
The library is targeting both `.NET Standard 2.0` and `.NET Standard 2.1` for optimal compatibility, as well as the latest dotnet versions to use the latest framework features.

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
*Basic request:*
```csharp
// Get the ETH/USDT ticker via rest request
var restClient = new BybitRestClient();
var tickerResult = await restClient.V5Api.ExchangeData.GetSpotTickersAsync("ETHUSDT");
var lastPrice = tickerResult.Data.List.First().LastPrice;
```

*Place order:*
```csharp
var restClient = new BybitRestClient(opts => {
	opts.ApiCredentials = new BybitCredentials("APIKEY", "APISECRET");
});

// Place Limit order to go long for 0.1 ETH at 2000
var orderResult = await restClient.V5Api.Trading.PlaceOrderAsync(
    Category.Linear,
    "ETHUSDT",
    OrderSide.Buy,
    NewOrderType.Limit,
    0.1m,
    2000,
    positionIdx: PositionIdx.BuyHedgeMode);
```

*WebSocket subscription:*
```csharp
// Subscribe to ETH/USDT ticker updates via the websocket API
var socketClient = new BybitSocketClient();
var tickerSubscriptionResult = socketClient.V5SpotApi.SubscribeToTickerUpdatesAsync("ETHUSDT", (update) =>
{
	var lastPrice = update.Data.LastPrice;
});
```

For information on the clients, dependency injection, response processing and more see the [Bybit.Net documentation](https://cryptoexchange.jkorf.dev?library=Bybit.Net), [CryptoExchange.Net documentation](https://jkorf.github.io/CryptoExchange.Net), or have a look at the examples [here](https://github.com/JKorf/Bybit.Net/tree/main/Examples) or [here](https://github.com/JKorf/CryptoExchange.Net/tree/master/Examples).

## AI documentation
This repository includes AI-focused guidance for generating correct Bybit.Net code:

* [AGENTS.md](AGENTS.md) - skill-style instructions for Bybit.Net usage
* [llms.txt](llms.txt) - compact AI context
* [llms-full.txt](llms-full.txt) - detailed AI context and API map
* [docs/ai-api-map.md](docs/ai-api-map.md) - V5 API surface map
* [Examples/ai-friendly](Examples/ai-friendly) - compilable examples for assistants and quick onboarding

See [cryptoexchange-skills-hub](https://github.com/JKorf/cryptoexchange-skills-hub) for installable skills.

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
|Bitstamp|[JKorf/Bitstamp.Net](https://github.com/JKorf/Bitstamp.Net)|[![Nuget version](https://img.shields.io/nuget/v/Bitstamp.Net.svg?style=flat-square)](https://www.nuget.org/packages/Bitstamp.Net)|
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
|Lighter|[JKorf/Lighter.Net](https://github.com/JKorf/Lighter.Net)|[![Nuget version](https://img.shields.io/nuget/v/JKorf.Lighter.net.svg?style=flat-square)](https://www.nuget.org/packages/JKorf.Lighter.Net)|
|Mexc|[JKorf/Mexc.Net](https://github.com/JKorf/Mexc.Net)|[![Nuget version](https://img.shields.io/nuget/v/JK.Mexc.net.svg?style=flat-square)](https://www.nuget.org/packages/JK.Mexc.Net)|
|OKX|[JKorf/OKX.Net](https://github.com/JKorf/OKX.Net)|[![Nuget version](https://img.shields.io/nuget/v/JK.OKX.net.svg?style=flat-square)](https://www.nuget.org/packages/JK.OKX.Net)|
|Polymarket|[JKorf/Polymarket.Net](https://github.com/JKorf/Polymarket.Net)|[![Nuget version](https://img.shields.io/nuget/v/Polymarket.net.svg?style=flat-square)](https://www.nuget.org/packages/Polymarket.Net)|
|Toobit|[JKorf/Toobit.Net](https://github.com/JKorf/Toobit.Net)|[![Nuget version](https://img.shields.io/nuget/v/Toobit.net.svg?style=flat-square)](https://www.nuget.org/packages/Toobit.Net)|
|Upbit|[JKorf/Upbit.Net](https://github.com/JKorf/Upbit.Net)|[![Nuget version](https://img.shields.io/nuget/v/JKorf.Upbit.net.svg?style=flat-square)](https://www.nuget.org/packages/JKorf.Upbit.Net)|
|Weex|[JKorf/Weex.Net](https://github.com/JKorf/Weex.Net)|[![Nuget version](https://img.shields.io/nuget/v/Weex.net.svg?style=flat-square)](https://www.nuget.org/packages/Weex.Net)|
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
* Version 7.0.0 - 29 Jun 2026
    * Result types:
      * (Web)CallResult types are replaced by HttpResult, WebSocketResult and QueryResult with the same logic
      * WebSocketResult and QueryResult now return additional info for websocket operations
      * Updated result types to record type
      * Removed implicit result type conversion to bool, `if (result)` no longer works, instead use `if (result.Success)`
      * Fixed result object nullability hinting, for example Data might be null if Success isn't checked for true
    * Clients:
      * Added ToString overrides on base API types
      * Added Exchange property on BaseApiClient
      * Added ApiCredentials property on Api clients
      * Updated ILogger source from client name to topic specific client name
      * Removed logging from client creation
      * Fixed issue in SocketApiClient.GetSocketConnection causing requests to always wait the full max 10 seconds when there was a reconnecting socket
    * Shared APIs:
      * Added missing dedicated option types
      * Added Discover method on ISharedClient interface, returning info on supported capabilities and operations
      * Added ResetStaticExchangeParameters method on ExchangeParameters
      * Added Status property to SharedWithdrawal model
      * Added TradingModes property to SharedBalance model
      * Updated Shared ExchangeParameters parameter names to be case insensitive
      * Updated code comments
      * Replaced ExchangeResult with ExchangeCallResult type
      * Removed TradingMode from the response model, only maintained on models where it makes sense
    * Added async streaming on UserDataTracker items with StreamUpdatesAsync
    * Added cancellation token support to UserDataTracker starting
    * Added SupportedEnvironments property to PlatformInfo
    * Added Clear() method on UserClientProvider to clear all cached clients
    * Added setter to BybitExchange.RateLimiter to allow custom rate limit settings
    * Various small performance improvements
    * Fixed websocket connection attempts counting towards rate limit even when server could not be reached
    * Fixed restClient.V5Api.Account.GetFundingTransactionHistoryAsync endpoint timestamp serialization
