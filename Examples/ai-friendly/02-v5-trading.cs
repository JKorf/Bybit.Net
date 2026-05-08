// 02-v5-trading.cs
//
// Demonstrates: Bybit V5 trading calls with category-aware order placement,
// open-order lookup, positions, and cancellation.
//
// Setup: dotnet add package Bybit.Net

using Bybit.Net;
using Bybit.Net.Clients;
using Bybit.Net.Enums;

var apiKey = Environment.GetEnvironmentVariable("BYBIT_API_KEY");
var apiSecret = Environment.GetEnvironmentVariable("BYBIT_API_SECRET");
if (string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(apiSecret))
{
    Console.WriteLine("Set BYBIT_API_KEY and BYBIT_API_SECRET to run authenticated trading calls.");
    return;
}

var restClient = new BybitRestClient(options =>
{
    options.ApiCredentials = new BybitCredentials(apiKey, apiSecret);
    options.ReceiveWindow = TimeSpan.FromSeconds(5);
});

var category = Category.Linear;
var symbol = "ETHUSDT";

// Inspect current state before placing anything. Bybit V5 trading methods use
// Category to select spot, linear, inverse, or option products.
var openOrders = await restClient.V5Api.Trading.GetOrdersAsync(
    category,
    symbol: symbol,
    limit: 20);

if (openOrders.Success)
    Console.WriteLine($"Open order count returned: {openOrders.Data.List.Length}");
else
    Console.WriteLine($"Open-order request failed: {openOrders.Error}");

var positions = await restClient.V5Api.Trading.GetPositionsAsync(category, symbol: symbol);
if (positions.Success)
    Console.WriteLine($"Position rows returned: {positions.Data.List.Length}");
else
    Console.WriteLine($"Position request failed: {positions.Error}");

// Keep the sample dry-run by default. Review account mode, category, quantity,
// price, and permissions before enabling live order placement.
var placeLiveOrder = string.Equals(
    Environment.GetEnvironmentVariable("BYBIT_EXAMPLE_PLACE_ORDER"),
    "true",
    StringComparison.OrdinalIgnoreCase);

if (!placeLiveOrder)
{
    Console.WriteLine("Dry run only. Set BYBIT_EXAMPLE_PLACE_ORDER=true to place the sample order.");
    return;
}

var order = await restClient.V5Api.Trading.PlaceOrderAsync(
    category,
    symbol,
    OrderSide.Buy,
    NewOrderType.Limit,
    quantity: 0.01m,
    price: 1000m,
    timeInForce: TimeInForce.GoodTillCanceled,
    positionIdx: PositionIdx.OneWayMode);

if (!order.Success)
{
    Console.WriteLine($"Order rejected: {order.Error}");
    return;
}

Console.WriteLine($"Placed order: {order.Data.OrderId}");

// Cancel by order id with the same category and symbol used to place the order.
var cancel = await restClient.V5Api.Trading.CancelOrderAsync(
    category,
    symbol,
    orderId: order.Data.OrderId);

Console.WriteLine(cancel.Success
    ? $"Canceled order: {cancel.Data.OrderId}"
    : $"Cancel failed: {cancel.Error}");
