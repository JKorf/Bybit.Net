// 04-shared-client.cs
//
// Demonstrates: accessing CryptoExchange.Net Shared API V2 capabilities from Bybit.Net while
// keeping native Bybit V5 endpoints available.
//
// Setup: dotnet add package Bybit.Net

using Bybit.Net.Clients;
using Bybit.Net.Enums;
using CryptoExchange.Net.SharedApis;

using var restClient = new BybitRestClient();

var sharedRest = restClient.V5Api.SharedApi;
Console.WriteLine($"Shared exchange: {sharedRest.Exchange}");

var sharedInfo = sharedRest.Discover();
var supportedFeatures = sharedInfo.Features
    .Where(x => x.Supported)
    .Select(x => x.EndpointName);
Console.WriteLine($"{sharedInfo.Exchange} {sharedInfo.TypeName}: {string.Join(", ", supportedFeatures)}");

using var socketClient = new BybitSocketClient();
Console.WriteLine($"Spot socket shared exchange: {socketClient.V5SpotApi.SharedApi.Exchange}");
Console.WriteLine($"Linear socket shared exchange: {socketClient.V5LinearApi.SharedApi.Exchange}");

// Query using the narrow V2 capability and populate the normalized spot catalog.
IGetSpotSymbolsRest symbolsClient = sharedRest;
var symbols = await symbolsClient.GetSpotSymbolsAsync(new GetSymbolsRequest());
if (!symbols.Success)
{
    Console.WriteLine(symbols.Error);
    return;
}
foreach (var symbol in symbols.Data.Take(5))
    Console.WriteLine($"{symbol.Name}: {symbol.BaseAsset}/{symbol.QuoteAsset}");
var catalog = symbolsClient.SpotSymbolCatalog;

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
