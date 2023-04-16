---
title: IBybitSocketClientSpotStreams
has_children: false
parent: IBybitSocketClientV5
grand_parent: Socket API documentation
---
*[generated documentation]*  
`BybitSocketClient > V5 > SpotStreams`  
*Bybit spot data streams*
  

***

## SubscribeToLeveragedTokenKlineUpdatesAsync  

[https://bybit-exchange.github.io/docs/v5/websocket/public/etp-kline](https://bybit-exchange.github.io/docs/v5/websocket/public/etp-kline)  
<p>

*Subscribe to leveraged token kline updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.V5.SpotStreams.SubscribeToLeveragedTokenKlineUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToLeveragedTokenKlineUpdatesAsync(IEnumerable<string> symbols, KlineInterval interval, Action<DataEvent<IEnumerable<BybitKlineUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbols|The symbols to subscribe|
|interval|Kline interval|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token. Cancelling will cancel the subscription|

</p>

***

## SubscribeToLeveragedTokenKlineUpdatesAsync  

[https://bybit-exchange.github.io/docs/v5/websocket/public/etp-kline](https://bybit-exchange.github.io/docs/v5/websocket/public/etp-kline)  
<p>

*Subscribe to leveraged token kline updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.V5.SpotStreams.SubscribeToLeveragedTokenKlineUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToLeveragedTokenKlineUpdatesAsync(string symbol, KlineInterval interval, Action<DataEvent<IEnumerable<BybitKlineUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol to subscribe|
|interval|Kline interval|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token. Cancelling will cancel the subscription|

</p>

***

## SubscribeToLeveragedTokenNavUpdatesAsync  

[https://bybit-exchange.github.io/docs/v5/websocket/public/etp-nav](https://bybit-exchange.github.io/docs/v5/websocket/public/etp-nav)  
<p>

*Subscribe to leveraged token NAV updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.V5.SpotStreams.SubscribeToLeveragedTokenNavUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToLeveragedTokenNavUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitLeveragedTokenNav>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbols|The symbols to subscribe|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token. Cancelling will cancel the subscription|

</p>

***

## SubscribeToLeveragedTokenNavUpdatesAsync  

[https://bybit-exchange.github.io/docs/v5/websocket/public/etp-nav](https://bybit-exchange.github.io/docs/v5/websocket/public/etp-nav)  
<p>

*Subscribe to leveraged token NAV updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.V5.SpotStreams.SubscribeToLeveragedTokenNavUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToLeveragedTokenNavUpdatesAsync(string symbol, Action<DataEvent<BybitLeveragedTokenNav>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol to subscribe|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token. Cancelling will cancel the subscription|

</p>

***

## SubscribeToLeveragedTokenTickerUpdatesAsync  

[https://bybit-exchange.github.io/docs/v5/websocket/public/etp-ticker](https://bybit-exchange.github.io/docs/v5/websocket/public/etp-ticker)  
<p>

*Subscribe to leveraged token ticker updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.V5.SpotStreams.SubscribeToLeveragedTokenTickerUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToLeveragedTokenTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitLeveragedTokenTicker>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbols|The symbols to subscribe|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token. Cancelling will cancel the subscription|

</p>

***

## SubscribeToLeveragedTokenTickerUpdatesAsync  

[https://bybit-exchange.github.io/docs/v5/websocket/public/etp-ticker](https://bybit-exchange.github.io/docs/v5/websocket/public/etp-ticker)  
<p>

*Subscribe to leveraged token ticker updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.V5.SpotStreams.SubscribeToLeveragedTokenTickerUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToLeveragedTokenTickerUpdatesAsync(string symbol, Action<DataEvent<BybitLeveragedTokenTicker>> handler, CancellationToken ct = default);  
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
var result = await client.V5.SpotStreams.SubscribeToTickerUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitSpotTickerUpdate>> handler, CancellationToken ct = default);  
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
var result = await client.V5.SpotStreams.SubscribeToTickerUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BybitSpotTickerUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol to subscribe|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token. Cancelling will cancel the subscription|

</p>
