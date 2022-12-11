---
title: Getting started
nav_order: 2
---


## Creating client
There are 2 clients available to interact with the Bybit API, the `BybitClient` and `BybitSocketClient`.

*Create a new rest client*
```csharp
var bybitClient = new BybitClient(new BybitClientOptions()
{
	// Set options here for this client
});
```

*Create a new socket client*
```csharp
var bybitSocketClient = new BybitSocketClient(new BybitSocketClientOptions()
{
	// Set options here for this client
});
```

Different options are available to set on the clients, see this example
```csharp
var bybitClient = new BybitClient(new BybitClientOptions()
{
	ApiCredentials = new ApiCredentials("API-KEY", "API-SECRET"),
	LogLevel = LogLevel.Trace,
	InverseFuturesApiOptions = new RestApiClientOptions
	{
		ApiCredentials = new ApiCredentials("FUTURES-API-KEY", "FUTURES-API-SECRET"),
		AutoTimestamp = false,
		RequestTimeout = TimeSpan.FromSeconds(60)
	}
});
```
Alternatively, options can be provided before creating clients by using `SetDefaultOptions`:
```csharp
BybitClient.SetDefaultOptions(new BybitClientOptions{
	// Set options here for all new clients
});
var bybitClient = new BybitClient();
```
More info on the specific options can be found in the [CryptoExchange.Net documentation](https://jkorf.github.io/CryptoExchange.Net/Options.html)

These clients can be used to communicate with the Bybit exchange. See [Examples](Examples.html) for examples on basic operations

### Dependency injection
See the [CryptoExchange.Net documentation](https://jkorf.github.io/CryptoExchange.Net/Clients.html#dependency-injection)


