# Usage examples

Snippets are independent. Those using `client` assume a reused `BybitRestClient`, configured with credentials for private calls. Trading snippets submit real orders when executed; see [operational considerations](safety.md).

## Imports

```csharp
using System;
using System.Linq;
using System.Threading.Tasks;
using Bybit.Net;
using Bybit.Net.Clients;
using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients;
using CryptoExchange.Net.SharedApis;
using Microsoft.Extensions.DependencyInjection;
```

## Public spot ticker and results

```csharp
using var client = new BybitRestClient();
var result = await client.V5Api.ExchangeData.GetSpotTickersAsync("ETHUSDT");
if (!result.Success)
{
    Console.WriteLine(result.Error);
    return;
}
Console.WriteLine(result.Data.List.FirstOrDefault()?.LastPrice);
```

## Category-aware derivatives data

```csharp
var result = await client.V5Api.ExchangeData.GetLinearInverseTickersAsync(
    Category.Linear, symbol: "ETHUSDT");
if (!result.Success)
{
    Console.WriteLine(result.Error);
    return;
}
Console.WriteLine(result.Data.List.FirstOrDefault()?.MarkPrice);
```

## Authentication and account balances

```csharp
using var client = new BybitRestClient(options =>
{
    options.ApiCredentials = new BybitCredentials("API_KEY", "API_SECRET");
});
var balances = await client.V5Api.Account.GetBalancesAsync(AccountType.Unified, "USDT");
if (!balances.Success)
{
    Console.WriteLine(balances.Error);
    return;
}
foreach (var account in balances.Data.List)
    foreach (var asset in account.Assets)
        Console.WriteLine($"{asset.Asset}: wallet={asset.WalletBalance}");
```

## Linear limit order and cancellation

The position index below assumes one-way mode. Select values that match the intended market, account mode, and trade.

```csharp
var order = await client.V5Api.Trading.PlaceOrderAsync(
    Category.Linear, "ETHUSDT", OrderSide.Buy, NewOrderType.Limit,
    quantity: 0.01m, price: 1000m,
    timeInForce: TimeInForce.GoodTillCanceled,
    positionIdx: PositionIdx.OneWayMode);
if (!order.Success)
{
    Console.WriteLine(order.Error);
    return;
}
var cancel = await client.V5Api.Trading.CancelOrderAsync(
    Category.Linear, "ETHUSDT", orderId: order.Data.OrderId);
if (!cancel.Success)
    Console.WriteLine(cancel.Error);
```

## Positions

```csharp
var positions = await client.V5Api.Trading.GetPositionsAsync(Category.Linear, symbol: "ETHUSDT");
if (!positions.Success)
{
    Console.WriteLine(positions.Error);
    return;
}
Console.WriteLine($"Position rows: {positions.Data.List.Length}");
```

## Subscription lifecycle

```csharp
using var socketClient = new BybitSocketClient();
var subscription = await socketClient.V5SpotApi.SubscribeToTickerUpdatesAsync(
    "ETHUSDT", update => Console.WriteLine(update.Data.LastPrice));
if (!subscription.Success)
{
    Console.WriteLine(subscription.Error);
    return;
}
try
{
    await Task.Delay(TimeSpan.FromSeconds(30));
}
finally
{
    await socketClient.UnsubscribeAsync(subscription.Data);
}
```

Private order, position, execution, and wallet subscriptions use `V5PrivateApi` with credentials configured on the socket client; keep the same result checks and cleanup.

## WebSocket order query

This is an authenticated order submission and returns a query result rather than a subscription.

```csharp
using var socketClient = new BybitSocketClient(options =>
{
    options.ApiCredentials = new BybitCredentials("API_KEY", "API_SECRET");
});
var order = await socketClient.V5PrivateApi.PlaceOrderAsync(
    Category.Spot, "ETHUSDT", OrderSide.Buy, NewOrderType.Limit,
    quantity: 0.01m, price: 1000m);
if (!order.Success)
{
    Console.WriteLine(order.Error);
    return;
}
Console.WriteLine(order.Data.OrderId);
```

## Shared API V2

```csharp
IGetTickerRest ticker = client.V5Api.SharedApi;
var symbol = new SharedSymbol(TradingMode.Spot, "ETH", "USDT");
var result = await ticker.GetTickerAsync(new GetTickerRequest(symbol));
if (!result.Success)
{
    Console.WriteLine(result.Error);
    return;
}
Console.WriteLine(result.Data.LastPrice);
```

For shared socket orders use a capability from `V5PrivateApi.SharedApi`. Read [API surfaces](api-surfaces.md#shared-api-v2) for runtime selection, symbol catalogs, and quantity options.

## Dependency injection

```csharp
var services = new ServiceCollection();
services.AddBybit(options =>
{
    options.ApiCredentials = new BybitCredentials("API_KEY", "API_SECRET");
    options.Rest.ReceiveWindow = TimeSpan.FromSeconds(5);
});
using var provider = services.BuildServiceProvider();
var client = provider.GetRequiredService<IBybitRestClient>();
var shared = provider.GetRequiredService<IBybitSharedApiClient>();
```

## Complete examples (checkout-only)

The documentation test compiles these programs without executing exchange calls. Running them contacts Bybit; review the operations and live-order configuration first.

- [V5 market and account](../../../../Examples/ai-friendly/01-v5-market-and-account.cs)
- [V5 trading](../../../../Examples/ai-friendly/02-v5-trading.cs)
- [WebSockets](../../../../Examples/ai-friendly/03-websocket.cs)
- [Shared API](../../../../Examples/ai-friendly/04-shared-client.cs)
- [Error handling](../../../../Examples/ai-friendly/05-error-handling.cs)
