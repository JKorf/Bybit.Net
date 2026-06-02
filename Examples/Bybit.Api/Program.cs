using Bybit.Net;
using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add the Bybit services
builder.Services.AddBybit();

// OR to provide API credentials for accessing private endpoints, or setting other options:
/*
builder.Services.AddBybit(options =>
{    
   options.ApiCredentials = new BybitCredentials("<APIKEY>", "<APISECRET>");
   options.Rest.RequestTimeout = TimeSpan.FromSeconds(5);
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
    if (!result.Success)
        return Results.Problem(result.Error?.Message, statusCode: 502);

    var ticker = result.Data.List.FirstOrDefault();
    return ticker == null
        ? Results.NotFound()
        : Results.Ok(ticker.LastPrice);
})
.WithOpenApi();

app.MapGet("/Balances", async ([FromServices] IBybitRestClient client) =>
{
    var result = await client.V5Api.Account.GetBalancesAsync(AccountType.Spot);
    return result.Success
        ? Results.Ok(result.Data)
        : Results.Problem(result.Error?.Message, statusCode: 502);
})
.WithOpenApi();

app.Run();
