// 01-v5-market-and-account.cs
//
// Demonstrates: Bybit V5 REST setup, public market data, and credential-gated
// wallet balance access.
//
// Setup: dotnet add package Bybit.Net

using Bybit.Net;
using Bybit.Net.Clients;
using Bybit.Net.Enums;

var symbol = "ETHUSDT";

// Public REST clients do not need credentials.
var publicClient = new BybitRestClient();

var spotTicker = await publicClient.V5Api.ExchangeData.GetSpotTickersAsync(symbol);
if (!spotTicker.Success)
{
    Console.WriteLine($"Spot ticker request failed: {spotTicker.Error}");
    return;
}

var firstSpotTicker = spotTicker.Data.List.FirstOrDefault();
if (firstSpotTicker is not null)
    Console.WriteLine($"{firstSpotTicker.Symbol} spot last price: {firstSpotTicker.LastPrice}");

// Many V5 market endpoints need a product category. ETHUSDT is a common linear
// derivatives symbol, so use Category.Linear here.
var klines = await publicClient.V5Api.ExchangeData.GetKlinesAsync(
    Category.Linear,
    symbol,
    KlineInterval.OneMinute,
    limit: 5);

if (klines.Success)
{
    foreach (var candle in klines.Data.List)
        Console.WriteLine($"{candle.StartTime:u} close={candle.ClosePrice} volume={candle.Volume}");
}
else
{
    Console.WriteLine($"Kline request failed: {klines.Error}");
}

var orderBook = await publicClient.V5Api.ExchangeData.GetOrderbookAsync(
    Category.Linear,
    symbol,
    limit: 25);

if (orderBook.Success)
{
    var bestBid = orderBook.Data.Bids.FirstOrDefault();
    var bestAsk = orderBook.Data.Asks.FirstOrDefault();
    Console.WriteLine($"Best bid: {bestBid?.Price}, best ask: {bestAsk?.Price}");
}

// Private calls require credentials. Keep examples safe by reading from
// environment variables and skipping the call if they are not present.
var apiKey = Environment.GetEnvironmentVariable("BYBIT_API_KEY");
var apiSecret = Environment.GetEnvironmentVariable("BYBIT_API_SECRET");
if (string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(apiSecret))
{
    Console.WriteLine("Skipping private balance request; BYBIT_API_KEY and BYBIT_API_SECRET are not set.");
    return;
}

var privateClient = new BybitRestClient(options =>
{
    options.ApiCredentials = new BybitCredentials(apiKey, apiSecret);
});

// Unified accounts are the most common Bybit V5 account type. Use AccountType.Spot
// or AccountType.Fund when you specifically need those account buckets.
var balances = await privateClient.V5Api.Account.GetBalancesAsync(AccountType.Unified, "USDT");
if (!balances.Success)
{
    Console.WriteLine($"Balance request failed: {balances.Error}");
    return;
}

foreach (var account in balances.Data.List)
{
    foreach (var asset in account.Assets)
        Console.WriteLine($"{asset.Asset}: wallet={asset.WalletBalance}, free={asset.Free}");
}
