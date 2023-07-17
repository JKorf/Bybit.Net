---
title: IBybitSocketClientDerivativesPublicApi
has_children: true
parent: IBybitSocketClientDerivativesApi
grand_parent: Socket API documentation
---
*[generated documentation]*  
`BybitSocketClient > DerivativesApi > DerivativesPublicApi`  
*Bybit public Derivatives streams*
  

***

## SubscribeToKlinesUpdatesAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketkline](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketkline)  
<p>

*Subscribe to kline (candlestick) updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.DerivativesApi.DerivativesPublicApi.SubscribeToKlinesUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToKlinesUpdatesAsync(StreamDerivativesCategory category, IEnumerable<string> symbols, KlineInterval interval, Action<DataEvent<IEnumerable<BybitDerivativesKlineUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Asset category|
|symbols|List of symbols to receive updates for|
|interval|The interval of the klines|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToKlineUpdatesAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketkline](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketkline)  
<p>

*Subscribe to kline (candlestick) updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.DerivativesApi.DerivativesPublicApi.SubscribeToKlineUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(StreamDerivativesCategory category, string symbol, KlineInterval interval, Action<DataEvent<IEnumerable<BybitDerivativesKlineUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Asset category|
|symbol|The symbol to receive updates for|
|interval|The interval of the klines|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToOrderBooksUpdatesAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketorderbookdepth](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketorderbookdepth)  
<p>

*Subscribe to orderbook updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.DerivativesApi.DerivativesPublicApi.SubscribeToOrderBooksUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToOrderBooksUpdatesAsync(StreamDerivativesCategory category, IEnumerable<string> symbols, int limit, Action<DataEvent<BybitDerivativesOrderBookEntry>> snapshotHandler, Action<DataEvent<BybitDerivativesOrderBookEntry>> deltaHandler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Asset category|
|symbols|List of symbols to receive updates for|
|limit|The amount of rows to receive updates for. Either 1, 25, 50, 100, 200.|
|snapshotHandler|The event handler for the snapshot messages|
|deltaHandler|The event handler for the update messages|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToOrderBookUpdatesAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketorderbookdepth](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketorderbookdepth)  
<p>

*Subscribe to orderbook updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.DerivativesApi.DerivativesPublicApi.SubscribeToOrderBookUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(StreamDerivativesCategory category, string symbol, int limit, Action<DataEvent<BybitDerivativesOrderBookEntry>> snapshotHandler, Action<DataEvent<BybitDerivativesOrderBookEntry>> deltaHandler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Asset category|
|symbol|The symbol to receive updates for|
|limit|The amount of rows to receive updates for. Either 1, 25, 50, 100, 200.|
|snapshotHandler|The event handler for the snapshot messages|
|deltaHandler|The event handler for the update messages|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToTickersUpdatesAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketticker_v3](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketticker_v3)  
<p>

*Subscribe to ticker updates. Note that for a symbol the first update is a snapshot, containing all info. After that only partial updates are given for*  
*properties which have changed. If a property in the update is `null` it isn't changed and should be ignored.*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.DerivativesApi.DerivativesPublicApi.SubscribeToTickersUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTickersUpdatesAsync(StreamDerivativesCategory category, IEnumerable<string> symbols, Action<DataEvent<BybitDerivativesTicker>> snapshotHandler, Action<DataEvent<BybitDerivativesTickerUpdate>> updateHandler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Asset category|
|symbols|List of symbols to receive updates for|
|snapshotHandler| Snapshot handler|
|updateHandler| Update handler|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToTickerUpdatesAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketticker_v3](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketticker_v3)  
<p>

*Subscribe to ticker updates. Note that for a symbol the first update is a snapshot, containing all info. After that only partial updates are given for*  
*properties which have changed. If a property in the update is `null` it isn't changed and should be ignored.*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.DerivativesApi.DerivativesPublicApi.SubscribeToTickerUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(StreamDerivativesCategory category, string symbol, Action<DataEvent<BybitDerivativesTicker>> snapshotHandler, Action<DataEvent<BybitDerivativesTickerUpdate>> updateHandler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Asset category|
|symbol|The symbol to receive updates for|
|snapshotHandler| Snapshot handler|
|updateHandler| Update handler|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToTradesUpdatesAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websockettrade](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websockettrade)  
<p>

*Subscribe to public trade updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.DerivativesApi.DerivativesPublicApi.SubscribeToTradesUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTradesUpdatesAsync(StreamDerivativesCategory category, IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BybitDerivativesTradeUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Asset category|
|symbols|List of symbols to receive updates for|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToTradeUpdatesAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websockettrade](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websockettrade)  
<p>

*Subscribe to public trade updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.DerivativesApi.DerivativesPublicApi.SubscribeToTradeUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(StreamDerivativesCategory category, string symbol, Action<DataEvent<IEnumerable<BybitDerivativesTradeUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Asset category|
|symbol|The symbol to receive updates for|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>
