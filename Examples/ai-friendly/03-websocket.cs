// 03-websocket.cs
//
// Demonstrates: Bybit V5 WebSocket public streams, private streams, and
// subscription teardown.
//
// Setup: dotnet add package Bybit.Net

using Bybit.Net;
using Bybit.Net.Clients;

var socketClient = new BybitSocketClient();
var symbol = "ETHUSDT";

var spotTickerSubscription = await socketClient.V5SpotApi.SubscribeToTickerUpdatesAsync(
    symbol,
    update =>
    {
        Console.WriteLine($"Spot {update.Data.Symbol}: {update.Data.LastPrice}");
    });

if (!spotTickerSubscription.Success)
{
    Console.WriteLine($"Spot ticker subscription failed: {spotTickerSubscription.Error}");
    return;
}

var linearTickerSubscription = await socketClient.V5LinearApi.SubscribeToTickerUpdatesAsync(
    symbol,
    update =>
    {
        Console.WriteLine($"Linear {update.Data.Symbol}: mark={update.Data.MarkPrice}, last={update.Data.LastPrice}");
    });

if (!linearTickerSubscription.Success)
{
    Console.WriteLine($"Linear ticker subscription failed: {linearTickerSubscription.Error}");
    await socketClient.UnsubscribeAsync(spotTickerSubscription.Data);
    return;
}

// Private streams require credentials. Use a separate authenticated client so
// public examples still work without secrets.
var apiKey = Environment.GetEnvironmentVariable("BYBIT_API_KEY");
var apiSecret = Environment.GetEnvironmentVariable("BYBIT_API_SECRET");
BybitSocketClient? privateSocketClient = null;

if (!string.IsNullOrWhiteSpace(apiKey) && !string.IsNullOrWhiteSpace(apiSecret))
{
    privateSocketClient = new BybitSocketClient(options =>
    {
        options.ApiCredentials = new BybitCredentials(apiKey, apiSecret);
    });

    var orderUpdates = await privateSocketClient.V5PrivateApi.SubscribeToOrderUpdatesAsync(
        update => Console.WriteLine($"Private order updates received: {update.Data.Length}"));

    if (!orderUpdates.Success)
        Console.WriteLine($"Private order subscription failed: {orderUpdates.Error}");
}

Console.WriteLine("Subscriptions are active briefly for demonstration.");
await Task.Delay(TimeSpan.FromSeconds(10));

await socketClient.UnsubscribeAsync(spotTickerSubscription.Data);
await socketClient.UnsubscribeAsync(linearTickerSubscription.Data);

if (privateSocketClient is not null)
    await privateSocketClient.UnsubscribeAllAsync();

Console.WriteLine("Subscriptions stopped.");
