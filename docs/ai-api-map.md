# Bybit.Net AI API Map

This map helps AI assistants generate Bybit.Net code that matches the current project API shape. Prefer the V5 API versions unless a user explicitly asks for older or legacy behavior.

## Package and Clients

```csharp
using Bybit.Net;
using Bybit.Net.Clients;
using Bybit.Net.Enums;

var restClient = new BybitRestClient();
var socketClient = new BybitSocketClient();
```

Authenticated clients:

```csharp
var restClient = new BybitRestClient(options =>
{
    options.ApiCredentials = new BybitCredentials("API_KEY", "API_SECRET");
});

var socketClient = new BybitSocketClient(options =>
{
    options.ApiCredentials = new BybitCredentials("API_KEY", "API_SECRET");
});
```

## REST Root

Bybit.Net uses a single V5 REST root:

```csharp
restClient.V5Api
```

Do not generate Binance-style `SpotApi`, `UsdFuturesApi`, `CoinFuturesApi`, or `GeneralApi` roots for Bybit.Net.

## REST Groups

| Group | Purpose | Common methods |
|---|---|---|
| `V5Api.ExchangeData` | Public and mostly unauthenticated market data | `GetSpotTickersAsync`, `GetLinearInverseTickersAsync`, `GetKlinesAsync`, `GetOrderbookAsync`, `GetTradeHistoryAsync`, `GetFundingRateHistoryAsync`, `GetOpenInterestAsync` |
| `V5Api.Account` | Balances, assets, deposits, withdrawals, transfers, account settings | `GetBalancesAsync`, `GetAllAssetBalancesAsync`, `GetAssetBalanceAsync`, `GetApiKeyInfoAsync`, `GetFeeRatesAsync`, `CreateInternalTransferAsync`, `CreateUniversalTransferAsync` |
| `V5Api.Trading` | Orders, positions, executions, spread trading | `PlaceOrderAsync`, `EditOrderAsync`, `CancelOrderAsync`, `CancelAllOrderAsync`, `GetOrdersAsync`, `GetOrderHistoryAsync`, `GetPositionsAsync`, `GetUserTradesAsync` |
| `V5Api.SubAccount` | Sub-account management | Use for sub-account operations when requested |
| `V5Api.CryptoLoan` | Crypto loan endpoints | Use for loan orders and loan history when requested |
| `V5Api.Earn` | Earn endpoints | Use for savings/earn products when requested |
| `V5Api.SharedClient` | CryptoExchange.Net shared REST client | Use for exchange-agnostic code |

## Market Data Patterns

Spot ticker:

```csharp
var ticker = await restClient.V5Api.ExchangeData.GetSpotTickersAsync("ETHUSDT");
if (!ticker.Success) { return; }

var first = ticker.Data.List.First();
Console.WriteLine(first.LastPrice);
```

Linear derivative ticker:

```csharp
var ticker = await restClient.V5Api.ExchangeData.GetLinearInverseTickersAsync(
    Category.Linear,
    symbol: "ETHUSDT");
```

Klines:

```csharp
var klines = await restClient.V5Api.ExchangeData.GetKlinesAsync(
    Category.Linear,
    "ETHUSDT",
    KlineInterval.OneMinute,
    limit: 100);
```

Order book:

```csharp
var orderBook = await restClient.V5Api.ExchangeData.GetOrderbookAsync(
    Category.Linear,
    "ETHUSDT",
    limit: 25);
```

## Account Patterns

Wallet balance:

```csharp
var balances = await restClient.V5Api.Account.GetBalancesAsync(AccountType.Unified, "USDT");
if (!balances.Success) { return; }

foreach (var account in balances.Data.List)
{
    foreach (var asset in account.Assets)
        Console.WriteLine($"{asset.Asset}: {asset.WalletBalance}");
}
```

Asset balance:

```csharp
var assetBalance = await restClient.V5Api.Account.GetAssetBalanceAsync(
    AccountType.Fund,
    "USDT");
```

Fee rates:

```csharp
var fees = await restClient.V5Api.Account.GetFeeRatesAsync(Category.Linear, symbol: "ETHUSDT");
```

## Trading Patterns

Place a linear limit order:

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

Place a spot order:

```csharp
var order = await restClient.V5Api.Trading.PlaceOrderAsync(
    Category.Spot,
    "ETHUSDT",
    OrderSide.Buy,
    NewOrderType.Limit,
    quantity: 0.01m,
    price: 2000m,
    timeInForce: TimeInForce.GoodTillCanceled);
```

Open orders:

```csharp
var orders = await restClient.V5Api.Trading.GetOrdersAsync(
    Category.Linear,
    symbol: "ETHUSDT",
    limit: 20);
```

Positions:

```csharp
var positions = await restClient.V5Api.Trading.GetPositionsAsync(
    Category.Linear,
    symbol: "ETHUSDT");
```

Cancel an order:

```csharp
var cancel = await restClient.V5Api.Trading.CancelOrderAsync(
    Category.Linear,
    "ETHUSDT",
    orderId: "ORDER_ID");
```

## Product Categories

| Product | Use |
|---|---|
| Spot | `Category.Spot` |
| USDT/USDC linear perpetual/futures | `Category.Linear` |
| Inverse perpetual/futures | `Category.Inverse` |
| USDC options | `Category.Option` |

## WebSocket Roots

| Root | Purpose |
|---|---|
| `socketClient.V5SpotApi` | Spot public streams |
| `socketClient.V5LinearApi` | Linear derivatives public streams |
| `socketClient.V5InverseApi` | Inverse derivatives public streams |
| `socketClient.V5OptionsApi` | Options public streams |
| `socketClient.V5SpreadApi` | Spread public streams |
| `socketClient.V5PrivateApi` | Private account/order/position/trade/wallet streams and WebSocket trading |

## WebSocket Patterns

Spot ticker:

```csharp
var sub = await socketClient.V5SpotApi.SubscribeToTickerUpdatesAsync(
    "ETHUSDT",
    update => Console.WriteLine(update.Data.LastPrice));
```

Linear ticker:

```csharp
var sub = await socketClient.V5LinearApi.SubscribeToTickerUpdatesAsync(
    "ETHUSDT",
    update => Console.WriteLine(update.Data.MarkPrice));
```

Private order updates:

```csharp
var sub = await socketClient.V5PrivateApi.SubscribeToOrderUpdatesAsync(
    update => Console.WriteLine(update.Data.Length));
```

Always check subscription result and unsubscribe:

```csharp
if (!sub.Success) { return; }
await socketClient.UnsubscribeAsync(sub.Data);
```

## Result Model

REST:

```csharp
HttpResult<T>
```

WebSocket:

```csharp
WebSocketResult<T>
```

Pattern:

```csharp
if (!result.Success)
{
    Console.WriteLine(result.Error);
    return;
}

var data = result.Data;
```

## Common AI Mistakes to Prevent

- Using raw Bybit endpoint URLs and hand-written signing.
- Generating old or nonexistent client roots such as `restClient.SpotApi`.
- Forgetting V5 `Category` arguments.
- Using passphrase credentials.
- Reading `.Data` without checking `.Success`.
- Using symbol formats from other exchanges.
- Creating a new client for each request.
- Blocking with `.Result` or `.Wait()`.
- Forgetting WebSocket teardown.

## Source References

- `Bybit.Net/Interfaces/Clients/V5/IBybitRestClientApi.cs`
- `Bybit.Net/Interfaces/Clients/V5/IBybitRestClientApiExchangeData.cs`
- `Bybit.Net/Interfaces/Clients/V5/IBybitRestClientApiAccount.cs`
- `Bybit.Net/Interfaces/Clients/V5/IBybitRestClientApiTrading.cs`
- `Bybit.Net/Interfaces/Clients/V5/IBybitSocketClientSpotApi.cs`
- `Bybit.Net/Interfaces/Clients/V5/IBybitSocketClientLinearApi.cs`
- `Bybit.Net/Interfaces/Clients/V5/IBybitSocketClientPrivateApi.cs`
- `Examples/ai-friendly/`
