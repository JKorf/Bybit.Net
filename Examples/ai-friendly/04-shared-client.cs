// 04-shared-client.cs
//
// Demonstrates: accessing CryptoExchange.Net shared clients from Bybit.Net while
// keeping native Bybit V5 endpoints available.
//
// Setup: dotnet add package Bybit.Net

using Bybit.Net.Clients;
using Bybit.Net.Enums;

var restClient = new BybitRestClient();

var sharedRest = restClient.V5Api.SharedClient;
Console.WriteLine($"Shared exchange: {sharedRest.Exchange}");
Console.WriteLine($"Supported trading modes: {string.Join(", ", sharedRest.SupportedTradingModes)}");

var sharedInfo = sharedRest.Discover();
var supportedFeatures = sharedInfo.Features
    .Where(x => x.Supported)
    .Select(x => x.EndpointName);
Console.WriteLine($"{sharedInfo.Exchange} {sharedInfo.TypeName}: {string.Join(", ", supportedFeatures)}");

var socketClient = new BybitSocketClient();
Console.WriteLine($"Spot socket shared exchange: {socketClient.V5SpotApi.SharedClient.Exchange}");
Console.WriteLine($"Linear socket shared exchange: {socketClient.V5LinearApi.SharedClient.Exchange}");

// Native endpoints are still best when you need Bybit-specific V5 arguments,
// models, and fields such as Category, PositionIdx, account type, or spread data.
var nativeTicker = await restClient.V5Api.ExchangeData.GetLinearInverseTickersAsync(
    Category.Linear,
    symbol: "ETHUSDT");

if (nativeTicker.Success)
{
    var ticker = nativeTicker.Data.List.FirstOrDefault();
    Console.WriteLine($"Native Bybit linear ticker: {ticker?.Symbol} last={ticker?.LastPrice}");
}
