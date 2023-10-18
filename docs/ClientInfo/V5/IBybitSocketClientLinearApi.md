---
title: IBybitSocketClientLinearApi
has_children: true
parent: IBybitSocketClientV5
grand_parent: Socket API documentation
---
*[generated documentation]*  
`BybitSocketClient > V5 > LinearApi`  
*Bybit linear data streams*
  

***

## SubscribeToLiquidationUpdatesAsync  

[https://bybit-exchange.github.io/docs/v5/websocket/public/liquidation](https://bybit-exchange.github.io/docs/v5/websocket/public/liquidation)  
<p>

*Subscribe to liquidation updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.V5.LinearApi.SubscribeToLiquidationUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitLiquidation>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbols|The symbols to subscribe|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token. Cancelling will cancel the subscription|

</p>

***

## SubscribeToLiquidationUpdatesAsync  

[https://bybit-exchange.github.io/docs/v5/websocket/public/liquidation](https://bybit-exchange.github.io/docs/v5/websocket/public/liquidation)  
<p>

*Subscribe to liquidation updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.V5.LinearApi.SubscribeToLiquidationUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(string symbol, Action<DataEvent<BybitLiquidation>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol to subscribe|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token. Cancelling will cancel the subscription|

</p>

***

## SubscribeToTickerUpdatesAsync  

[https://bybit-exchange.github.io/docs/v5/websocket/public/ticker](https://bybit-exchange.github.io/docs/v5/websocket/public/ticker)  
<p>

*Subscribe to ticker updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.V5.LinearApi.SubscribeToTickerUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitLinearTickerUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbols|The symbols to subscribe|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token. Cancelling will cancel the subscription|

</p>

***

## SubscribeToTickerUpdatesAsync  

[https://bybit-exchange.github.io/docs/v5/websocket/public/ticker](https://bybit-exchange.github.io/docs/v5/websocket/public/ticker)  
<p>

*Subscribe to ticker updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.V5.LinearApi.SubscribeToTickerUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BybitLinearTickerUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol to subscribe|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token. Cancelling will cancel the subscription|

</p>
