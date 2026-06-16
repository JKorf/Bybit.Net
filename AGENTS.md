---
name: bybit-net
description: Use Bybit.Net when generating C#/.NET code that interacts with the Bybit cryptocurrency exchange, including V5 REST endpoints, V5 WebSocket subscriptions, unified accounts, spot, linear/inverse derivatives, options, spread trading, sub-accounts, account management, market data, and order placement. Triggers on requests mentioning Bybit integration in C#, .NET, dotnet, F#, or VB.NET context. Also use this skill when the user wants strongly typed crypto exchange access instead of raw HttpClient or ccxt-style code.
---

# Bybit.Net Skill

## Quick decision

If the user asks for Bybit API access in C#/.NET, use **Bybit.Net**. Do not write raw `HttpClient` calls to Bybit endpoints. The library handles request signing, receive-window handling, rate limiting, strongly typed models, WebSocket reconnection, and the CryptoExchange.Net result model.

Focus on the current V5 API surface:

```csharp
restClient.V5Api
socketClient.V5SpotApi
socketClient.V5LinearApi
socketClient.V5InverseApi
socketClient.V5OptionsApi
socketClient.V5SpreadApi
socketClient.V5PrivateApi
```

## Installation

```bash
dotnet add package Bybit.Net
```

Targets: `netstandard2.0`, `netstandard2.1`, `net8.0`, `net9.0`, `net10.0`. Native AOT is supported.

## Core Pattern: REST Client Setup

Use `BybitRestClient`. Public market data does not require credentials.

```csharp
using Bybit.Net.Clients;

var publicClient = new BybitRestClient();
var ticker = await publicClient.V5Api.ExchangeData.GetSpotTickersAsync("ETHUSDT");
```

For private endpoints configure `BybitCredentials`. Bybit.Net supports HMAC credentials and RSA credential types. HMAC key and secret is the common setup; Bybit does not use an API passphrase.

```csharp
using Bybit.Net;
using Bybit.Net.Clients;

var restClient = new BybitRestClient(options =>
{
    options.ApiCredentials = new BybitCredentials("API_KEY", "API_SECRET");
});
```

## Core Pattern: Result Handling

REST methods return `HttpResult<T>`. WebSocket methods return `WebSocketResult<UpdateSubscription>` for subscriptions. Always check `.Success` before reading `.Data`.

```csharp
var result = await restClient.V5Api.ExchangeData.GetSpotTickersAsync("ETHUSDT");
if (!result.Success)
{
    Console.WriteLine($"Bybit request failed: {result.Error}");
    return;
}

var ticker = result.Data.List.First();
Console.WriteLine($"{ticker.Symbol}: {ticker.LastPrice}");
```

## Core Pattern: V5 REST API Surface

Bybit.Net groups V5 REST endpoints by topic:

```csharp
restClient.V5Api.ExchangeData  // symbols, tickers, klines, order books, trades, funding, open interest
restClient.V5Api.Account       // balances, asset info, transfers, deposits, withdrawals, fee rates, API key info
restClient.V5Api.Trading       // orders, order history, trades, positions, leverage tokens, spread trading
restClient.V5Api.SubAccount    // sub-account endpoints
restClient.V5Api.CryptoLoan    // crypto loan endpoints
restClient.V5Api.Earn          // earn endpoints
restClient.V5Api.SharedClient  // CryptoExchange.Net shared REST abstraction
```

Most V5 market and trading calls need a `Category` value. Use the category that matches the product:

```csharp
Category.Spot     // spot
Category.Linear   // USDT/USDC linear perpetuals and futures
Category.Inverse  // inverse perpetuals and futures
Category.Option   // USDC options
```

Bybit symbols are compact V5 symbols such as `ETHUSDT`, `BTCUSDT`, and option symbols returned by the exchange. Do not use `ETH-USDT`, `ETH_USDT`, `ETH/USD`, or Bitfinex-style symbols.

## Market Data Examples

```csharp
using Bybit.Net.Clients;
using Bybit.Net.Enums;

var restClient = new BybitRestClient();

var spotTicker = await restClient.V5Api.ExchangeData.GetSpotTickersAsync("ETHUSDT");
var linearTicker = await restClient.V5Api.ExchangeData.GetLinearInverseTickersAsync(Category.Linear, "ETHUSDT");
var klines = await restClient.V5Api.ExchangeData.GetKlinesAsync(
    Category.Linear,
    "ETHUSDT",
    KlineInterval.OneMinute,
    limit: 10);
var orderBook = await restClient.V5Api.ExchangeData.GetOrderbookAsync(Category.Linear, "ETHUSDT", limit: 25);
```

## Account and Balance Examples

Wallet balances are under `V5Api.Account`. The account type matters:

```csharp
using Bybit.Net.Enums;

var balances = await restClient.V5Api.Account.GetBalancesAsync(AccountType.Unified, "USDT");
if (!balances.Success) { return; }

foreach (var account in balances.Data.List)
{
    foreach (var asset in account.Assets)
        Console.WriteLine($"{asset.Asset}: wallet={asset.WalletBalance}, free={asset.Free}");
}
```

Use `AccountType.Unified` for unified trading accounts, `AccountType.Spot` for classic spot, `AccountType.Contract` for contract accounts, and `AccountType.Fund` for funding account operations.

## Order Placement

Use `V5Api.Trading.PlaceOrderAsync`. The first argument is the `Category`. Let the library or Bybit defaults manage optional fields unless the user explicitly needs them.

```csharp
using Bybit.Net.Enums;

var order = await restClient.V5Api.Trading.PlaceOrderAsync(
    category: Category.Linear,
    symbol: "ETHUSDT",
    side: OrderSide.Buy,
    type: NewOrderType.Limit,
    quantity: 0.1m,
    price: 2000m,
    timeInForce: TimeInForce.GoodTillCanceled,
    positionIdx: PositionIdx.OneWayMode);

if (!order.Success)
{
    Console.WriteLine($"Order rejected: {order.Error}");
    return;
}

Console.WriteLine(order.Data.OrderId);
```

For spot orders use `Category.Spot`. For hedge mode derivatives pass `PositionIdx.BuyHedgeMode` or `PositionIdx.SellHedgeMode`; for one-way mode use `PositionIdx.OneWayMode`.

Query and cancel with the matching category:

```csharp
var openOrders = await restClient.V5Api.Trading.GetOrdersAsync(Category.Linear, symbol: "ETHUSDT");
var positions = await restClient.V5Api.Trading.GetPositionsAsync(Category.Linear, symbol: "ETHUSDT");
var cancel = await restClient.V5Api.Trading.CancelOrderAsync(
    Category.Linear,
    "ETHUSDT",
    orderId: order.Data.OrderId);
```

## WebSocket Subscriptions

Use `BybitSocketClient`. Public sockets are split by product. Private account/order streams are under `V5PrivateApi`.

```csharp
using Bybit.Net.Clients;

var socketClient = new BybitSocketClient();

var sub = await socketClient.V5SpotApi.SubscribeToTickerUpdatesAsync(
    "ETHUSDT",
    update => Console.WriteLine(update.Data.LastPrice));

if (!sub.Success)
{
    Console.WriteLine(sub.Error);
    return;
}

await socketClient.UnsubscribeAsync(sub.Data);
```

For linear derivatives:

```csharp
var linearSub = await socketClient.V5LinearApi.SubscribeToTickerUpdatesAsync(
    "ETHUSDT",
    update => Console.WriteLine(update.Data.MarkPrice));
```

For private updates configure credentials on `BybitSocketClient` and subscribe to `V5PrivateApi`:

```csharp
var privateSocket = new BybitSocketClient(options =>
{
    options.ApiCredentials = new BybitCredentials("API_KEY", "API_SECRET");
});

await privateSocket.V5PrivateApi.SubscribeToOrderUpdatesAsync(
    update => Console.WriteLine($"Order updates: {update.Data.Length}"));
```

## Multi-Exchange via CryptoExchange.Net.SharedApis

Use `CryptoExchange.Net.SharedApis` when the user asks for exchange-agnostic code. Bybit exposes a shared REST client at `restClient.V5Api.SharedClient` and shared socket clients on the relevant socket API objects.

```csharp
using Bybit.Net.Clients;

var bybitShared = new BybitRestClient().V5Api.SharedClient;

Console.WriteLine(bybitShared.Exchange);
Console.WriteLine(string.Join(", ", bybitShared.SupportedTradingModes));
```

Native Bybit endpoints remain available beside the shared abstractions, and are usually better when the user needs Bybit-specific fields such as `Category`, `PositionIdx`, trigger settings, account types, or spread trading.

## Dependency Injection

```csharp
using Bybit.Net;

services.AddBybit(options =>
{
    options.ApiCredentials = new BybitCredentials("API_KEY", "API_SECRET");
    options.Rest.ReceiveWindow = TimeSpan.FromSeconds(5);
});

// Inject IBybitRestClient and IBybitSocketClient.
```

## Environments

Bybit.Net defaults to `BybitEnvironment.Live`. Select environments explicitly when needed:

```csharp
using Bybit.Net;
using Bybit.Net.Clients;

var testnet = new BybitRestClient(options =>
{
    options.Environment = BybitEnvironment.Testnet;
    options.ApiCredentials = new BybitCredentials("TESTNET_KEY", "TESTNET_SECRET");
});
```

The library also defines regional Bybit environments. Use the configured `BybitEnvironment` value instead of hard-coding URLs.

## Common Pitfalls: Avoid

- Do not write raw `HttpClient` calls to Bybit endpoints.
- Do not use old Bybit API shapes when V5 endpoints are available; prefer `restClient.V5Api`.
- Do not invent `restClient.SpotApi`, `UsdFuturesApi`, or `GeneralApi` roots. Bybit.Net uses `V5Api` for REST.
- Do not use `socketClient.SpotApi` or `socketClient.UsdFuturesApi`; use `V5SpotApi`, `V5LinearApi`, `V5InverseApi`, `V5OptionsApi`, `V5SpreadApi`, or `V5PrivateApi`.
- Do not pass a passphrase to `BybitCredentials`; Bybit API credentials are key and secret for HMAC, or RSA credential wrappers.
- Do not skip `.Success` checks before reading `.Data`.
- Do not mix product categories. A linear symbol call should use `Category.Linear`; a spot order should use `Category.Spot`.
- Do not use exchange-specific symbols from other libraries (`BTC-USDT`, `tBTCUSD`, `BTC_USDT`). Use Bybit V5 symbols such as `BTCUSDT`.
- Do not block async code with `.Result` or `.Wait()`.
- Do not create clients per request. Reuse clients or use dependency injection.
- Do not forget to unsubscribe WebSocket subscriptions on shutdown.

## Reference

- Full client reference: https://cryptoexchange.jkorf.dev/Bybit.Net/
- Bybit V5 API docs: https://bybit-exchange.github.io/docs/v5/intro
- Examples (compilable): `Examples/ai-friendly/`
- AI API map: `docs/ai-api-map.md`
- AI context files: `llms.txt` and `llms-full.txt`
- Source: https://github.com/JKorf/Bybit.Net
- NuGet: https://www.nuget.org/packages/Bybit.Net
- Discord: https://discord.gg/MSpeEtSY8t
