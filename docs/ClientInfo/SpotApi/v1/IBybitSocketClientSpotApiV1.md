---
title: IBybitSocketClientSpotApiV1
has_children: false
parent: IBybitSocketClientSpotApi\v1
grand_parent: Socket API documentation
---
*[generated documentation]*  
`BybitSocketClient > SpotApi\v1 > SpotApiV1`  
*[DEPRECATED, WILL STOP WORKING ON 16 OCTOBER, USE V5 API INSTEAD] Bybit spot streams*
  

***

## SubscribeToKlineUpdatesAsync  

[https://bybit-exchange.github.io/docs/spot/v1/#t-websocketkline](https://bybit-exchange.github.io/docs/spot/v1/#t-websocketkline)  
<p>

*Subscribe to kline updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.SpotApi\v1.SpotApiV1.SubscribeToKlineUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, KlineInterval interval, Action<DataEvent<BybitSpotKlineUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|interval|Interval of the kline data|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToLeverageTokenUpdatesAsync  

[https://bybit-exchange.github.io/docs/spot/v1/#t-websocketltnetvalue](https://bybit-exchange.github.io/docs/spot/v1/#t-websocketltnetvalue)  
<p>

*Subscribe to leverage token net value updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.SpotApi\v1.SpotApiV1.SubscribeToLeverageTokenUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToLeverageTokenUpdatesAsync(string symbol, Action<DataEvent<BybitSpotLeverageUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToOrderBookDiffUpdatesAsync  

[https://bybit-exchange.github.io/docs/spot/v1/#t-websocketdiffdepth](https://bybit-exchange.github.io/docs/spot/v1/#t-websocketdiffdepth)  
<p>

*Subscribe to diff of order book updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.SpotApi\v1.SpotApiV1.SubscribeToOrderBookDiffUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToOrderBookDiffUpdatesAsync(string symbol, Action<DataEvent<BybitSpotOrderBookUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToOrderBookMergedUpdatesAsync  

[https://bybit-exchange.github.io/docs/spot/v1/#t-websocketmergeddepth](https://bybit-exchange.github.io/docs/spot/v1/#t-websocketmergeddepth)  
<p>

*Subscribe to aggregated order book updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.SpotApi\v1.SpotApiV1.SubscribeToOrderBookMergedUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToOrderBookMergedUpdatesAsync(string symbol, int dumpScale, Action<DataEvent<BybitSpotOrderBookUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|dumpScale|It refers to the number of decimal places, eg 1 for 50000.5 or 0 for 50000|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToOrderBookUpdatesAsync  

[https://bybit-exchange.github.io/docs/spot/v1/#t-websocketdepth](https://bybit-exchange.github.io/docs/spot/v1/#t-websocketdepth)  
<p>

*Subscribe to order book updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.SpotApi\v1.SpotApiV1.SubscribeToOrderBookUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, Action<DataEvent<BybitSpotOrderBookUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToTickerUpdatesAsync  

[https://bybit-exchange.github.io/docs/spot/v1/#t-websocketrealtimes](https://bybit-exchange.github.io/docs/spot/v1/#t-websocketrealtimes)  
<p>

*Subscribe to ticker updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.SpotApi\v1.SpotApiV1.SubscribeToTickerUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BybitSpotTickerUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToTradeUpdatesAsync  

[https://bybit-exchange.github.io/docs/spot/v1/#t-websockettrade](https://bybit-exchange.github.io/docs/spot/v1/#t-websockettrade)  
<p>

*Subscribe to public trade updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.SpotApi\v1.SpotApiV1.SubscribeToTradeUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<BybitSpotTradeUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>
