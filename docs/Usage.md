---
title: Getting started
nav_order: 2
---

## Creating client
There are 2 clients available to interact with the Bybit API, the `BybitRestClient` and `BybitSocketClient`. They can be created manually on the fly or be added to the dotnet DI using the `AddBybit` extension method.

*Create a new rest client*
```csharp
var bybitRestClient = new BybitRestClient(options =>
{
    // Set options here for this client
});

var bybitSocketClient = new BybitSocketClient(options =
{
    // Set options here for this client
});
```

*Using dotnet dependency inject*
```csharp
services.AddBybit(
    restOptions => {
        // set options for the rest client
    },
    socketClientOptions => {
        // set options for the socket client
    }); 
    
// IBybitRestClient, IBybitSocketClient and IBybitOrderBookFactory are now available for injecting
```

Different options are available to set on the clients, see this example
```csharp
var bybitRestClient = new BybitRestClient(options =>
{
    options.ApiCredentials = new ApiCredentials("API-KEY", "API-SECRET");
    // override options just for the InverseFuturesOptions api
    options.InverseFuturesOptions.ApiCredentials = new ApiCredentials("FUTURES-API-KEY", "FUTURES-API-SECRET");
    options.InverseFuturesOptions.RequestTimeout  = TimeSpan.FromSeconds(60);
});
```
Alternatively, options can be provided before creating clients by using `SetDefaultOptions` or during the registration in the DI container: 
```csharp
BybitRestClient.SetDefaultOptions(options => {
    // Set options here for all new clients
});
var bybitClient = new BybitRestClient();
```
More info on the specific options can be found in the [CryptoExchange.Net documentation](https://jkorf.github.io/CryptoExchange.Net/Options.html)

These clients can be used to communicate with the Bybit exchange. See [Examples](Examples.html) for examples on basic operations

### Dependency injection
See [CryptoExchange.Net documentation](https://jkorf.github.io/CryptoExchange.Net/Dependency%20Injection.html)


