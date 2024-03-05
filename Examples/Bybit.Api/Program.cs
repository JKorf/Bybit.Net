using Bybit.Net.Interfaces.Clients;
using CryptoExchange.Net.Authentication;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add the Bybit services
builder.Services.AddBybit();

// OR to provide API credentials for accessing private endpoints, or setting other options:
/*
builder.Services.AddBybit(restOptions =>
{
    restOptions.ApiCredentials = new ApiCredentials("<APIKEY>", "<APISECRET>");
    restOptions.RequestTimeout = TimeSpan.FromSeconds(5);
}, socketOptions =>
{
    socketOptions.ApiCredentials = new ApiCredentials("<APIKEY>", "<APISECRET>");
});
*/

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

// Map the endpoints and inject the bybit rest client
app.MapGet("/{Symbol}", async ([FromServices] IBybitRestClient client, string symbol) =>
{
    var result = await client.V5Api.ExchangeData.GetSpotTickersAsync(symbol);
    return (object)(result.Success ? result.Data : result.Error!);
})
.WithOpenApi();

app.MapGet("/Balances", async ([FromServices] IBybitRestClient client) =>
{
    var result = await client.V5Api.Account.GetBalancesAsync(Bybit.Net.Enums.AccountType.Spot);
    return (object)(result.Success ? result.Data : result.Error!);
})
.WithOpenApi();

app.Run();