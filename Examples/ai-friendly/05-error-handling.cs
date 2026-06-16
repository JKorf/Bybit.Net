// 05-error-handling.cs
//
// Demonstrates: consistent Bybit.Net result handling for REST and WebSocket
// calls. All examples check Success before reading Data.
//
// Setup: dotnet add package Bybit.Net

using Bybit.Net.Clients;
using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;

var restClient = new BybitRestClient();

var orderBookResult = await restClient.V5Api.ExchangeData.GetOrderbookAsync(
    Category.Linear,
    "ETHUSDT",
    limit: 25);

if (!TryGetRestData(orderBookResult, out BybitOrderbook? orderBook))
    return;

var bestBid = orderBook.Bids.FirstOrDefault();
var bestAsk = orderBook.Asks.FirstOrDefault();
Console.WriteLine($"Best bid={bestBid?.Price}, best ask={bestAsk?.Price}");

var socketClient = new BybitSocketClient();
var subscriptionResult = await socketClient.V5LinearApi.SubscribeToTickerUpdatesAsync(
    "ETHUSDT",
    update => Console.WriteLine($"Linear ticker update: {update.Data.LastPrice}"));

if (!TryGetSocketData(subscriptionResult, out UpdateSubscription? subscription))
    return;

await Task.Delay(TimeSpan.FromSeconds(5));
await socketClient.UnsubscribeAsync(subscription);

static bool TryGetRestData<T>(HttpResult<T> result, out T data)
{
    if (result.Success)
    {
        data = result.Data;
        return true;
    }

    Console.WriteLine($"REST call failed. Code={result.Error?.Code}, Message={result.Error?.Message}");
    data = default!;
    return false;
}

static bool TryGetSocketData<T>(WebSocketResult<T> result, out T data)
{
    if (result.Success)
    {
        data = result.Data;
        return true;
    }

    Console.WriteLine($"Socket call failed. Code={result.Error?.Code}, Message={result.Error?.Message}");
    data = default!;
    return false;
}
