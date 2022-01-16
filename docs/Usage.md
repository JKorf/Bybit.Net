## Creating client
There are 2 clients available to interact with the Bybit API, the `BybitClient` and `BybitSocketClient`.

*Create a new rest client*
````C#
var bybitClient = new BybitClient(new BybitClientOptions()
{
	// Set options here for this client
});
````

*Create a new socket client*
````C#
var bybitSocketClient = new BybitSocketClient(new BybitSocketClientOptions()
{
	// Set options here for this client
});
````

Different options are available to set on the clients, see this example
````C#
var bybitClient = new BybitClient(new BybitClientOptions()
{
	ApiCredentials = new ApiCredentials("API-KEY", "API-SECRET"),
	LogLevel = LogLevel.Trace,
	RequestTimeout = TimeSpan.FromSeconds(60),
	InverseFuturesApiOptions = new RestApiClientOptions
	{
		ApiCredentials = new ApiCredentials("FUTURES-API-KEY", "FUTURES-API-SECRET"),
		AutoTimestamp = false
	}
});
````
Alternatively, options can be provided before creating clients by using `SetDefaultOptions`:
````C#
BybitClient.SetDefaultOptions(new BybitClientOptions{
	// Set options here for all new clients
});
var bybitClient = new BybitClient();
````
More info on the specific options can be found on the [CryptoExchange.Net wiki](https://github.com/JKorf/CryptoExchange.Net/wiki/Options)

### Dependency injection
See [CryptoExchange.Net wiki](https://github.com/JKorf/CryptoExchange.Net/wiki/Clients#dependency-injection)

## Usage
Make sure to read the [CryptoExchange.Net wiki](https://github.com/JKorf/CryptoExchange.Net/wiki/Clients#processing-request-responses) on processing responses.

<Details>
<Summary>
<b>Spot API</b>

</Summary>
<BlockQuote>

#### Get market data
````C#
// Getting info on all symbols
var symbolData = await bybitClient.SpotApi.ExchangeData.GetSymbolsAsync();

// Getting tickers for all symbols
var tickerData = await bybitClient.SpotApi.ExchangeData.GetTickersAsync();

// Getting the order book of a symbol
var orderBookData = await bybitClient.SpotApi.ExchangeData.GetOrderBookAsync("BTCUSDT");

// Getting recent trades of a symbol
var tradeHistoryData = await bybitClient.SpotApi.ExchangeData.GetTradeHistoryAsync("BTC-USDT");
````

#### Requesting balances
````C#
var accountData = await bybitClient.SpotApi.Account.GetBalancesAsync();
````
#### Placing order
````C#
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
````

#### Requesting a specific order
````C#
// Request info on order with id `1234`
var orderData = await bybitClient.SpotApi.Trading.GetOrderAsync(1234);
````

#### Requesting order history
````C#
// Get all orders conform the parameters
 var ordersData = await bybitClient.SpotApi.Trading.GetOrdersAsync();
````

#### Cancel order
````C#
// Cancel order with id `1234`
var orderData = await bybitClient.SpotApi.Trading.CancelOrderAsync(1234);
````

#### Get user trades
````C#
var userTradesResult = await bybitClient.SpotApi.Trading.GetUserTradesAsync();
````

#### Subscribing to market data updates
````C#
var subscribeResult = await bybitSocketClient.SpotStreams.SubscribeToTickerUpdatesAsync("BTCUSDT", data =>
{
	// Handle ticker data
});
````

#### Subscribing to order updates
````C#
await bybitSocketClient.SpotStreams.SubscribeToAccountUpdatesAsync(
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
````

</BlockQuote>
</Details>

<Details>
<Summary>
<b>Usd perpetual API</b>

</Summary>
<BlockQuote>

#### Get market data
````C#
 // Getting info on all symbols
var symbolData = await bybitClient.UsdPerpetualApi.ExchangeData.GetSymbolsAsync();

// Getting the order book of a symbol
var orderBookData = await bybitClient.UsdPerpetualApi.ExchangeData.GetOrderBookAsync("BTCUSDT");

// Getting recent trades of a symbol
var tradeHistoryData = await bybitClient.UsdPerpetualApi.ExchangeData.GetTradeHistoryAsync("BTCUSDT");
````

#### Requesting positions
````C#
// Getting your current positions
var positionResultData = await bybitClient.UsdPerpetualApi.Account.GetPositionsAsync();
````

#### Placing order
````C#
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
````

#### Requesting a specific order
````C#
// Get info on an order id 1234 on symbol BTCUSDT
var orderResult = await bybitClient.UsdPerpetualApi.Trading.GetOpenOrderRealTimeAsync("BTCUSDT", "1234");

````

#### Requesting order history
````C#
// Get all orders for the account. Can apply filters as parameters
var orderResult = await bybitClient.UsdPerpetualApi.Trading.GetOrdersAsync("BTCUSDT");
````

#### Cancel order
````C#
// Cancel order with id 1234 on symbol BTCUSDT
var orderResult = await bybitClient.UsdPerpetualApi.Trading.CancelOrderAsync("BTCUSDT", "1234");

````

#### Get user trades
````C#
var userTradesResult = await bybitClient.UsdPerpetualApi.Trading.GetUserTradesAsync("BTCUSDT");
````

#### Subscribing to position updates
````C#
await bybitSocketClient.UsdPerpetualStreams.SubscribeToPositionUpdatesAsync(
	data =>
	{
		// Handle position update
	});
````

</BlockQuote>
</Details>

<Details>
<Summary>
<b>Inverse futures API</b>

</Summary>
<BlockQuote>

#### Get market data
````C#
 // Getting info on all symbols
var symbolData = await bybitClient.InverseFuturesApi.ExchangeData.GetSymbolsAsync();

// Getting the order book of a symbol
var orderBookData = await bybitClient.InverseFuturesApi.ExchangeData.GetOrderBookAsync("BTCUSDT");

// Getting recent trades of a symbol
var tradeHistoryData = await bybitClient.InverseFuturesApi.ExchangeData.GetTradeHistoryAsync("BTCUSDT");
````

#### Requesting positions
````C#
// Getting your current positions
var positionResultData = await bybitClient.InverseFuturesApi.Account.GetPositionsAsync();
````

#### Placing order
````C#
// Placing a Market buy order for 10 USDT
var positionResultData = await bybitClient.InverseFuturesApi.Trading.PlaceOrderAsync(
                "BTCUSDM21",
                OrderSide.Buy,
                OrderType.Market,
                PositionMode.BothSideBuy,
                10,
                TimeInForce.GoodTillCanceled);
````

#### Requesting a specific order
````C#
// Get info on an order id 1234 on symbol BTCUSDM21
var orderResult = await bybitClient.InverseFuturesApi.Trading.GetOpenOrderRealTimeAsync("BTCUSDM21", "1234");

````

#### Requesting order history
````C#
// Get all orders for the account. Can apply filters as parameters
var orderResult = await bybitClient.InverseFuturesApi.Trading.GetOrdersAsync("BTCUSDM21");
````

#### Cancel order
````C#
// Cancel order with id 1234 on symbol BTCUSDM21
var orderResult = await bybitClient.InverseFuturesApi.Trading.CancelOrderAsync("BTCUSDM21", "1234");

````

#### Get user trades
````C#
var userTradesResult = await bybitClient.InverseFuturesApi.Trading.GetUserTradesAsync("BTCUSDM21");
````

#### Streams
The InverseFutures API has no specific streams. The InverseFutures and InversePerpetual streams are equal and available to use via the InversePerpetualsStreams property.

</BlockQuote>
</Details>

<Details>
<Summary>
<b>Inverse perpetual API</b>

</Summary>
<BlockQuote>

#### Get market data
````C#
 // Getting info on all symbols
var symbolData = await bybitClient.InversePerpetualApi.ExchangeData.GetSymbolsAsync();

// Getting the order book of a symbol
var orderBookData = await bybitClient.InversePerpetualApi.ExchangeData.GetOrderBookAsync("BTCUSD");

// Getting recent trades of a symbol
var tradeHistoryData = await bybitClient.InversePerpetualApi.ExchangeData.GetTradeHistoryAsync("BTCUSD");
````

#### Requesting positions
````C#
// Getting your current positions
var positionResultData = await bybitClient.InversePerpetualApi.Account.GetPositionsAsync();
````

#### Placing order
````C#
// Placing a Market buy order for 10 USDT
var positionResultData = await bybitClient.InversePerpetualApi.Trading.PlaceOrderAsync(
                "BTCUSD",
                OrderSide.Buy,
                OrderType.Market,
                10,
                TimeInForce.GoodTillCanceled);
````

#### Requesting a specific order
````C#
// Get info on an order id 1234 on symbol BTCUSD
var orderResult = await bybitClient.InversePerpetualApi.Trading.GetOpenOrderRealTimeAsync("BTCUSD", "1234");

````

#### Requesting order history
````C#
// Get all orders for the account. Can apply filters as parameters
var orderResult = await bybitClient.InversePerpetualApi.Trading.GetOrdersAsync("BTCUSD");
````

#### Cancel order
````C#
// Cancel order with id 1234 on symbol BTCUSD
var orderResult = await bybitClient.InversePerpetualApi.Trading.CancelOrderAsync("BTCUSD", "1234");

````

#### Get user trades
````C#
var userTradesResult = await bybitClient.InversePerpetualApi.Trading.GetUserTradesAsync("BTCUSD");
````

#### Streams

#### Subscribing to position updates
````C#
await bybitSocketClient.InversePerpetualStreams.SubscribeToPositionUpdatesAsync(
	data =>
	{
		// Handle position update
	});
````

</BlockQuote>
</Details>

