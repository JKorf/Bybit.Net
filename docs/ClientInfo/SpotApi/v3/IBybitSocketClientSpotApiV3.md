---
title: IBybitSocketClientSpotApiV3
has_children: false
parent: IBybitSocketClientSpotApi\v3
grand_parent: Socket API documentation
---
*[generated documentation]*  
`BybitSocketClient > SpotApi\v3 > SpotApiV3`  
*Bybit spot streams*
  

***

## SubscribeToAccountUpdatesAsync  

[https://bybit-exchange.github.io/docs/spot/#t-privatetopics](https://bybit-exchange.github.io/docs/spot/#t-privatetopics)  
<p>

*Subscribe to account balances update*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.SpotApi\v3.SpotApiV3.SubscribeToAccountUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToAccountUpdatesAsync(Action<DataEvent<BybitSpotAccountUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToBookPriceUpdatesAsync  

[https://bybit-exchange.github.io/docs/spot/#t-websocketv2bookticker](https://bybit-exchange.github.io/docs/spot/#t-websocketv2bookticker)  
<p>

*Subscribe to book price updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.SpotApi\v3.SpotApiV3.SubscribeToBookPriceUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToBookPriceUpdatesAsync(string symbol, Action<DataEvent<BybitSpotBookPriceV3>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToKlineUpdatesAsync  

[https://bybit-exchange.github.io/docs/spot/#t-websocketv2kline](https://bybit-exchange.github.io/docs/spot/#t-websocketv2kline)  
<p>

*Subscribe to kline updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.SpotApi\v3.SpotApiV3.SubscribeToKlineUpdatesAsync(/* parameters */);  
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

## SubscribeToOrderBookUpdatesAsync  

[https://bybit-exchange.github.io/docs/spot/v3/#t-websocketdepth](https://bybit-exchange.github.io/docs/spot/v3/#t-websocketdepth)  
<p>

*Subscribe to order book updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.SpotApi\v3.SpotApiV3.SubscribeToOrderBookUpdatesAsync(/* parameters */);  
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

[https://bybit-exchange.github.io/docs/spot/#t-websocketv2realtimes](https://bybit-exchange.github.io/docs/spot/#t-websocketv2realtimes)  
<p>

*Subscribe to ticker updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.SpotApi\v3.SpotApiV3.SubscribeToTickerUpdatesAsync(/* parameters */);  
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

[https://bybit-exchange.github.io/docs/spot/v3/#t-websockettrade](https://bybit-exchange.github.io/docs/spot/v3/#t-websockettrade)  
<p>

*Subscribe to public trade updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.SpotApi\v3.SpotApiV3.SubscribeToTradeUpdatesAsync(/* parameters */);  
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

***

## SubscribeToUserOrdersUpdatesAsync  

<p>

*Subscribe to orders updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.SpotApi\v3.SpotApiV3.SubscribeToUserOrdersUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToUserOrdersUpdatesAsync(Action<DataEvent<BybitSpotOrderUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToUserStopOrdersUpdatesAsync  

[https://bybit-exchange.github.io/docs/spot/v3/#t-websocketspotstoporder](https://bybit-exchange.github.io/docs/spot/v3/#t-websocketspotstoporder)  
<p>

*Subscribe to SL/TP orders updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.SpotApi\v3.SpotApiV3.SubscribeToUserStopOrdersUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToUserStopOrdersUpdatesAsync(Action<DataEvent<BybitSpotStopOrderUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToUserTradesUpdatesAsync  

<p>

*Susbcribe to user trade updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.SpotApi\v3.SpotApiV3.SubscribeToUserTradesUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToUserTradesUpdatesAsync(Action<DataEvent<BybitSpotUserTradeUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>
