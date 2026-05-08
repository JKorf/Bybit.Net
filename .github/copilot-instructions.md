# Copilot Instructions for Bybit.Net

This repository is **Bybit.Net**, a strongly typed C#/.NET client library for the Bybit cryptocurrency exchange API. It is part of the CryptoExchange.Net ecosystem.

When generating code that consumes Bybit.Net, follow these conventions.

## Use Bybit.Net, not raw HTTP

Never generate raw `HttpClient` calls to Bybit REST or WebSocket endpoints. Always use `BybitRestClient` or `BybitSocketClient` so request signing, receive-window handling, rate limiting, response parsing, and reconnect behavior stay correct.

## Client setup

```csharp
using Bybit.Net;
using Bybit.Net.Clients;

var restClient = new BybitRestClient(options =>
{
    options.ApiCredentials = new BybitCredentials("API_KEY", "API_SECRET");
});
```

For public market data only, credentials are optional:

```csharp
var publicClient = new BybitRestClient();
```

## Result handling

REST methods return `WebCallResult<T>` and WebSocket subscription methods return `CallResult<UpdateSubscription>`. Always check `.Success` before reading `.Data`; inspect `.Error` on failure.

## V5 API structure

- `restClient.V5Api.ExchangeData` for symbols, tickers, klines, order books, trades, funding, open interest
- `restClient.V5Api.Account` for balances, assets, transfers, deposits, withdrawals, account settings
- `restClient.V5Api.Trading` for orders, order history, user trades, positions, spread trading
- `restClient.V5Api.SubAccount`, `CryptoLoan`, and `Earn` for specialized V5 endpoints
- `restClient.V5Api.SharedClient` for CryptoExchange.Net shared REST abstractions
- `socketClient.V5SpotApi`, `V5LinearApi`, `V5InverseApi`, `V5OptionsApi`, `V5SpreadApi`, `V5PrivateApi` for WebSocket streams

Use `Category.Spot`, `Category.Linear`, `Category.Inverse`, or `Category.Option` when a V5 REST method asks for a product category.

## Order placement

Use `restClient.V5Api.Trading.PlaceOrderAsync`. Pass the correct category and Bybit symbol format:

```csharp
var order = await restClient.V5Api.Trading.PlaceOrderAsync(
    Category.Linear,
    "ETHUSDT",
    OrderSide.Buy,
    NewOrderType.Limit,
    quantity: 0.1m,
    price: 2000m,
    timeInForce: TimeInForce.GoodTillCanceled,
    positionIdx: PositionIdx.OneWayMode);
```

## WebSocket pattern

Store the returned `UpdateSubscription` and unsubscribe on shutdown:

```csharp
var sub = await socketClient.V5SpotApi.SubscribeToTickerUpdatesAsync(
    "ETHUSDT",
    update => Console.WriteLine(update.Data.LastPrice));

if (!sub.Success) { return; }
await socketClient.UnsubscribeAsync(sub.Data);
```

## Cross-exchange

For exchange-agnostic code, use `CryptoExchange.Net.SharedApis` through `.SharedClient` properties, for example `new BybitRestClient().V5Api.SharedClient`.

## Avoid

- Legacy or non-existent client roots such as `SpotApi`, `UsdFuturesApi`, `GeneralApi`, or `socketClient.SpotApi`
- Raw Bybit URLs and hand-written signing
- Generic `ApiCredentials` when Bybit-specific credentials are expected
- API passphrases; Bybit HMAC credentials are key and secret
- Synchronous `.Result` / `.Wait()`
- Creating clients per request
- Reading `.Data` before checking `.Success`
- Non-Bybit symbol formats such as `ETH-USDT`, `ETH_USDT`, `ETH/USD`, or `tETHUSD`

## Reference

For detailed patterns and pitfalls see `CLAUDE.md`, `llms.txt`, `llms-full.txt`, and `docs/ai-api-map.md` in the repository root. Compilable examples live in `Examples/ai-friendly/`.
