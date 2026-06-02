using Bybit.Net;
using Bybit.Net.Clients;
using Bybit.Net.Enums;

const string spotSymbol = "BTCUSDT";
const string linearSymbol = "ETHUSDT";

// Replace with valid credentials or order placement will always fail
var apiKey = "KEY";
var apiSecret = "SECRET";

Console.WriteLine("Bybit.Net V5 order placement example");
Console.WriteLine();
Console.WriteLine("This example can place real orders when valid credentials are configured.");
Console.WriteLine();

var client = new BybitRestClient(options =>
{
    options.ApiCredentials = new BybitCredentials(apiKey, apiSecret);
    options.ReceiveWindow = TimeSpan.FromSeconds(5);
});

await PlaceSpotLimitOrderAsync(client);
Console.WriteLine();
await PlaceLinearReduceOnlyOrderExampleAsync(client);

static async Task PlaceSpotLimitOrderAsync(BybitRestClient client)
{
    Console.WriteLine($"Placing spot V5 limit buy order for {spotSymbol}...");

    var ticker = await client.V5Api.ExchangeData.GetSpotTickersAsync(spotSymbol);
    if (!ticker.Success)
    {
        Console.WriteLine($"Failed to get spot ticker: {ticker.Error}");
        return;
    }

    var lastPrice = ticker.Data.List.First().LastPrice;
    var safePrice = Math.Round(lastPrice * 0.95m, 2);

    var order = await client.V5Api.Trading.PlaceOrderAsync(
        category: Category.Spot,
        symbol: spotSymbol,
        side: OrderSide.Buy,
        type: NewOrderType.Limit,
        quantity: 0.001m,
        price: safePrice,
        timeInForce: TimeInForce.GoodTillCanceled);

    if (!order.Success)
    {
        Console.WriteLine($"Failed to place spot order: {order.Error}");
        return;
    }

    Console.WriteLine($"Placed spot order {order.Data.OrderId}");

    var orderStatus = await client.V5Api.Trading.GetOrdersAsync(Category.Spot, spotSymbol, orderId: order.Data.OrderId);
    if (orderStatus.Success)
    {
        var orderInfo = orderStatus.Data.List.FirstOrDefault();
        Console.WriteLine(orderInfo == null
            ? "Spot order was not returned by the open-order query."
            : $"Spot order status: {orderInfo.Status}, filled: {orderInfo.QuantityFilled}");
    }
    else
    {
        Console.WriteLine($"Failed to query spot order: {orderStatus.Error}");
    }

    var cancel = await client.V5Api.Trading.CancelOrderAsync(Category.Spot, spotSymbol, orderId: order.Data.OrderId);
    Console.WriteLine(cancel.Success
        ? $"Canceled spot order {cancel.Data.OrderId}"
        : $"Failed to cancel spot order: {cancel.Error}");
}

static async Task PlaceLinearReduceOnlyOrderExampleAsync(BybitRestClient client)
{
    Console.WriteLine($"Placing linear V5 reduce-only limit sell order for {linearSymbol}...");

    var ticker = await client.V5Api.ExchangeData.GetLinearInverseTickersAsync(Category.Linear, linearSymbol);
    if (!ticker.Success)
    {
        Console.WriteLine($"Failed to get linear ticker: {ticker.Error}");
        return;
    }

    var lastPrice = ticker.Data.List.First().LastPrice;
    var safePrice = Math.Round(lastPrice * 1.05m, 2);

    var order = await client.V5Api.Trading.PlaceOrderAsync(
        category: Category.Linear,
        symbol: linearSymbol,
        side: OrderSide.Sell,
        type: NewOrderType.Limit,
        quantity: 0.01m,
        price: safePrice,
        timeInForce: TimeInForce.GoodTillCanceled,
        positionIdx: PositionIdx.OneWayMode,
        reduceOnly: true);

    if (!order.Success)
    {
        Console.WriteLine($"Failed to place linear order: {order.Error}");
        return;
    }

    Console.WriteLine($"Placed linear order {order.Data.OrderId}");

    var orderStatus = await client.V5Api.Trading.GetOrdersAsync(Category.Linear, linearSymbol, orderId: order.Data.OrderId);
    if (orderStatus.Success)
    {
        var orderInfo = orderStatus.Data.List.FirstOrDefault();
        Console.WriteLine(orderInfo == null
            ? "Linear order was not returned by the open-order query."
            : $"Linear order status: {orderInfo.Status}, executed: {orderInfo.QuantityFilled}");
    }
    else
    {
        Console.WriteLine($"Failed to query linear order: {orderStatus.Error}");
    }

    var cancel = await client.V5Api.Trading.CancelOrderAsync(Category.Linear, linearSymbol, orderId: order.Data.OrderId);
    Console.WriteLine(cancel.Success
        ? $"Canceled linear order {cancel.Data.OrderId}"
        : $"Failed to cancel linear order: {cancel.Error}");
}
