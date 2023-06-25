---
title: Examples
nav_order: 3
---

## Basic operations
Make sure to read the [CryptoExchange.Net wiki](https://jkorf.github.io/CryptoExchange.Net/Clients.html#processing-request-responses) on processing responses.

<Details>
<Summary>
<b>Spot API</b>

</Summary>
<BlockQuote>

### Get market data
```csharp
// Getting info on all symbols
var symbolData = await bybitClient.SpotApi.ExchangeData.GetSymbolsAsync();

// Getting tickers for all symbols
var tickerData = await bybitClient.SpotApi.ExchangeData.GetTickersAsync();

// Getting the order book of a symbol
var orderBookData = await bybitClient.SpotApi.ExchangeData.GetOrderBookAsync("BTCUSDT");

// Getting recent trades of a symbol
var tradeHistoryData = await bybitClient.SpotApi.ExchangeData.GetTradeHistoryAsync("BTC-USDT");
```

### Requesting balances
```csharp
var accountData = await bybitClient.SpotApi.Account.GetBalancesAsync();
```
### Placing order
```csharp
// Placing a buy limit order for 0.001 BTC at a price of 50000USDT each
var orderData = await bybitClient.SpotApi.Trading.PlaceOrderAsync(
                "BTCUSDT",
                OrderSide.Buy,
                OrderType.Limit,
                0.001m,
                50000,
                timeInForce: TimeInForce.GoodTillCanceled);
                                                    
// Placing a buy market order, spending 50 USDT. When placing a Buy Market order the quantity is quote asset. Any other time it's in base asset.
var orderData = await bybitClient.SpotApi.Trading.PlaceOrderAsync(
                "BTCUSDT",
                OrderSide.Buy,
                OrderType.Market,
                50);
```

### Requesting a specific order
```csharp
// Request info on order with id `1234`
var orderData = await bybitClient.SpotApi.Trading.GetOrderAsync(1234);
```

### Requesting order history
```csharp
// Get all orders conform the parameters
 var ordersData = await bybitClient.SpotApi.Trading.GetOrdersAsync();
```

### Cancel order
```csharp
// Cancel order with id `1234`
var orderData = await bybitClient.SpotApi.Trading.CancelOrderAsync(1234);
```

### Get user trades
```csharp
var userTradesResult = await bybitClient.SpotApi.Trading.GetUserTradesAsync();
```

### Subscribing to market data updates
```csharp
var subscribeResult = await bybitSocketClient.SpotApi.SubscribeToTickerUpdatesAsync("BTCUSDT", data =>
{
    // Handle ticker data
});
```

### Subscribing to order updates
```csharp
await bybitSocketClient.SpotApi.SubscribeToAccountUpdatesAsync(
    accountUpdate =>
    {
        // Handle balance or permissions update
    },
    orderUpdate =>
    {
        // Handle order update
    },
    tradeUpdate =>
    {
        // Handle trade update
    });
```

</BlockQuote>
</Details>

<Details>
<Summary>
<b>Usd perpetual API</b>

</Summary>
<BlockQuote>

### Get market data
```csharp
 // Getting info on all symbols
var symbolData = await bybitClient.UsdPerpetualApi.ExchangeData.GetSymbolsAsync();

// Getting the order book of a symbol
var orderBookData = await bybitClient.UsdPerpetualApi.ExchangeData.GetOrderBookAsync("BTCUSDT");

// Getting recent trades of a symbol
var tradeHistoryData = await bybitClient.UsdPerpetualApi.ExchangeData.GetTradeHistoryAsync("BTCUSDT");
```

### Requesting positions
```csharp
// Getting your current positions
var positionResultData = await bybitClient.UsdPerpetualApi.Account.GetPositionsAsync();
```

### Placing order
```csharp
// Placing a Limit Sell order for 0.01 BTC at a price of 50000USDT each
var positionResultData = await bybitClient.UsdPerpetualApi.Trading.PlaceOrderAsync(
                "BTCUSDT",
                OrderSide.Sell,
                OrderType.Limit,
                0.01m,
                TimeInForce.GoodTillCanceled,
                false,
                false,
                50000);
```

### Requesting a specific order
```csharp
// Get info on an order id 1234 on symbol BTCUSDT
var orderResult = await bybitClient.UsdPerpetualApi.Trading.GetOpenOrderRealTimeAsync("BTCUSDT", "1234");

```

### Requesting order history
```csharp
// Get all orders for the account. Can apply filters as parameters
var orderResult = await bybitClient.UsdPerpetualApi.Trading.GetOrdersAsync("BTCUSDT");
```

### Cancel order
```csharp
// Cancel order with id 1234 on symbol BTCUSDT
var orderResult = await bybitClient.UsdPerpetualApi.Trading.CancelOrderAsync("BTCUSDT", "1234");

```

### Get user trades
```csharp
var userTradesResult = await bybitClient.UsdPerpetualApi.Trading.GetUserTradesAsync("BTCUSDT");
```

### Subscribing to position updates
```csharp
await bybitSocketClient.UsdPerpetualApi.SubscribeToPositionUpdatesAsync(
    data =>
    {
        // Handle position update
    });
```

</BlockQuote>
</Details>

<Details>
<Summary>
<b>Inverse futures API</b>

</Summary>
<BlockQuote>

### Get market data
```csharp
 // Getting info on all symbols
var symbolData = await bybitClient.InverseFuturesApi.ExchangeData.GetSymbolsAsync();

// Getting the order book of a symbol
var orderBookData = await bybitClient.InverseFuturesApi.ExchangeData.GetOrderBookAsync("BTCUSDT");

// Getting recent trades of a symbol
var tradeHistoryData = await bybitClient.InverseFuturesApi.ExchangeData.GetTradeHistoryAsync("BTCUSDT");
```

### Requesting positions
```csharp
// Getting your current positions
var positionResultData = await bybitClient.InverseFuturesApi.Account.GetPositionsAsync();
```

### Placing order
```csharp
// Placing a Market buy order for 10 USDT
var positionResultData = await bybitClient.InverseFuturesApi.Trading.PlaceOrderAsync(
                "BTCUSDM21",
                OrderSide.Buy,
                OrderType.Market,
                PositionMode.BothSideBuy,
                10,
                TimeInForce.GoodTillCanceled);
```

### Requesting a specific order
```csharp
// Get info on an order id 1234 on symbol BTCUSDM21
var orderResult = await bybitClient.InverseFuturesApi.Trading.GetOpenOrderRealTimeAsync("BTCUSDM21", "1234");

```

### Requesting order history
```csharp
// Get all orders for the account. Can apply filters as parameters
var orderResult = await bybitClient.InverseFuturesApi.Trading.GetOrdersAsync("BTCUSDM21");
```

### Cancel order
```csharp
// Cancel order with id 1234 on symbol BTCUSDM21
var orderResult = await bybitClient.InverseFuturesApi.Trading.CancelOrderAsync("BTCUSDM21", "1234");

```

### Get user trades
```csharp
var userTradesResult = await bybitClient.InverseFuturesApi.Trading.GetUserTradesAsync("BTCUSDM21");
```

### Streams
The InverseFutures API has no specific streams. The InverseFutures and InversePerpetual streams are equal and available to use via the InversePerpetualsStreams property.

</BlockQuote>
</Details>

<Details>
<Summary>
<b>Inverse perpetual API</b>

</Summary>
<BlockQuote>

### Get market data
```csharp
 // Getting info on all symbols
var symbolData = await bybitClient.InversePerpetualApi.ExchangeData.GetSymbolsAsync();

// Getting the order book of a symbol
var orderBookData = await bybitClient.InversePerpetualApi.ExchangeData.GetOrderBookAsync("BTCUSD");

// Getting recent trades of a symbol
var tradeHistoryData = await bybitClient.InversePerpetualApi.ExchangeData.GetTradeHistoryAsync("BTCUSD");
```

### Requesting positions
```csharp
// Getting your current positions
var positionResultData = await bybitClient.InversePerpetualApi.Account.GetPositionsAsync();
```

### Placing order
```csharp
// Placing a Market buy order for 10 USDT
var positionResultData = await bybitClient.InversePerpetualApi.Trading.PlaceOrderAsync(
                "BTCUSD",
                OrderSide.Buy,
                OrderType.Market,
                10,
                TimeInForce.GoodTillCanceled);
```

### Requesting a specific order
```csharp
// Get info on an order id 1234 on symbol BTCUSD
var orderResult = await bybitClient.InversePerpetualApi.Trading.GetOpenOrderRealTimeAsync("BTCUSD", "1234");

```

### Requesting order history
```csharp
// Get all orders for the account. Can apply filters as parameters
var orderResult = await bybitClient.InversePerpetualApi.Trading.GetOrdersAsync("BTCUSD");
```

### Cancel order
```csharp
// Cancel order with id 1234 on symbol BTCUSD
var orderResult = await bybitClient.InversePerpetualApi.Trading.CancelOrderAsync("BTCUSD", "1234");

```

### Get user trades
```csharp
var userTradesResult = await bybitClient.InversePerpetualApi.Trading.GetUserTradesAsync("BTCUSD");
```

### Subscribing to position updates
```csharp
await bybitSocketClient.InversePerpetualApi.SubscribeToPositionUpdatesAsync(
    data =>
    {
        // Handle position update
    });
```

</BlockQuote>
</Details>
