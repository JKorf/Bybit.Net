---
title: IBybitSocketClientBaseApi
has_children: true
parent: IBybitSocketClientV5
grand_parent: Socket API documentation
---
*[generated documentation]*  
`BybitSocketClient > V5 > BaseApi`  
*Bybit streaming data subscriptions*
  

***

## SubscribeToKlineUpdatesAsync  

[https://bybit-exchange.github.io/docs/v5/websocket/public/kline](https://bybit-exchange.github.io/docs/v5/websocket/public/kline)  
<p>

*Subscribe to kline updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.V5.BaseApi.SubscribeToKlineUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(IEnumerable<string> symbols, KlineInterval interval, Action<DataEvent<IEnumerable<BybitKlineUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbols|The symbols to subscribe|
|interval|Kline interval|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token. Cancelling will cancel the subscription|

</p>

***

## SubscribeToKlineUpdatesAsync  

[https://bybit-exchange.github.io/docs/v5/websocket/public/kline](https://bybit-exchange.github.io/docs/v5/websocket/public/kline)  
<p>

*Subscribe to kline updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.V5.BaseApi.SubscribeToKlineUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, KlineInterval interval, Action<DataEvent<IEnumerable<BybitKlineUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol to subscribe|
|interval|Kline interval|
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
var result = await client.V5.BaseApi.SubscribeToLiquidationUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BybitLiquidation>>> handler, CancellationToken ct = default);  
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
var result = await client.V5.BaseApi.SubscribeToLiquidationUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(string symbol, Action<DataEvent<IEnumerable<BybitLiquidation>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol to subscribe|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token. Cancelling will cancel the subscription|

</p>

***

## SubscribeToOrderbookUpdatesAsync  

[https://bybit-exchange.github.io/docs/v5/websocket/public/orderbook](https://bybit-exchange.github.io/docs/v5/websocket/public/orderbook)  
<p>

*Subscribe to order book updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.V5.BaseApi.SubscribeToOrderbookUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToOrderbookUpdatesAsync(IEnumerable<string> symbols, int depth, Action<DataEvent<BybitOrderbook>> snapshotHandler, Action<DataEvent<BybitOrderbook>> updateHandler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbols|The symbols to subscribe|
|depth|The order book depth|
|snapshotHandler|Handler for a snapshot update. Snapshot updates contain the full order book|
|updateHandler|Handler for updates. These will only contain the changed entries|
|_[Optional]_ ct|Cancellation token. Cancelling will cancel the subscription|

</p>

***

## SubscribeToOrderbookUpdatesAsync  

[https://bybit-exchange.github.io/docs/v5/websocket/public/orderbook](https://bybit-exchange.github.io/docs/v5/websocket/public/orderbook)  
<p>

*Subscribe to order book updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.V5.BaseApi.SubscribeToOrderbookUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToOrderbookUpdatesAsync(string symbol, int depth, Action<DataEvent<BybitOrderbook>> snapshotHandler, Action<DataEvent<BybitOrderbook>> updateHandler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol to subscribe|
|depth|The order book depth|
|snapshotHandler|Handler for a snapshot update. Snapshot updates contain the full order book|
|updateHandler|Handler for updates. These will only contain the changed entries|
|_[Optional]_ ct|Cancellation token. Cancelling will cancel the subscription|

</p>

***

## SubscribeToTradeUpdatesAsync  

[https://bybit-exchange.github.io/docs/v5/websocket/public/trade](https://bybit-exchange.github.io/docs/v5/websocket/public/trade)  
<p>

*Subscribe to public trade updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.V5.BaseApi.SubscribeToTradeUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BybitTrade>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbols|The symbols to subscribe|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token. Cancelling will cancel the subscription|

</p>

***

## SubscribeToTradeUpdatesAsync  

[https://bybit-exchange.github.io/docs/v5/websocket/public/trade](https://bybit-exchange.github.io/docs/v5/websocket/public/trade)  
<p>

*Subscribe to public trade updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.V5.BaseApi.SubscribeToTradeUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<IEnumerable<BybitTrade>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol to subscribe|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token. Cancelling will cancel the subscription|

</p>
