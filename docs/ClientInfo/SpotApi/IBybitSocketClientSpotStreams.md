---
title: IBybitSocketClientSpotStreams
has_children: true
parent: IBybitSocketClient
---
*[generated documentation]*  
`BybitSocketClient > SpotStreams`  
*Bybit spot streams*
  

***

## SubscribeToAccountUpdatesAsync  

[https://bybit-exchange.github.io/docs/spot/#t-privatetopics](https://bybit-exchange.github.io/docs/spot/#t-privatetopics)  
<p>

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToAccountUpdatesAsync(Action<DataEvent<BybitSpotAccountUpdate>> accountUpdateHandler, Action<DataEvent<BybitSpotOrderUpdate>> orderUpdateHandler, Action<DataEvent<BybitSpotUserTradeUpdate>> tradeUpdateHandler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`accountUpdateHandler`|Account(balance) update handler|
|`orderUpdateHandler`|Order update handler|
|`tradeUpdateHandler`|User trade update handler|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to account data updates*  

</p>

***

## SubscribeToBookPriceUpdatesAsync  

[https://bybit-exchange.github.io/docs/spot/#t-websocketv2bookticker](https://bybit-exchange.github.io/docs/spot/#t-websocketv2bookticker)  
<p>

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToBookPriceUpdatesAsync(string symbol, Action<DataEvent<BybitSpotBookPrice>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`handler`|Data handler|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to book price updates*  

</p>

***

## SubscribeToKlineUpdatesAsync  

[https://bybit-exchange.github.io/docs/spot/#t-websocketv2kline](https://bybit-exchange.github.io/docs/spot/#t-websocketv2kline)  
<p>

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, KlineInterval interval, Action<DataEvent<BybitSpotKlineUpdate>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`interval`|Interval of the kline data|
|`handler`|Data handler|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to kline updates*  

</p>

***

## SubscribeToOrderBookUpdatesAsync  

[https://bybit-exchange.github.io/docs/spot/#t-websocketv2depth](https://bybit-exchange.github.io/docs/spot/#t-websocketv2depth)  
<p>

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, Action<DataEvent<BybitSpotOrderBookUpdate>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`handler`|Data handler|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to order book updates*  

</p>

***

## SubscribeToTickerUpdatesAsync  

[https://bybit-exchange.github.io/docs/spot/#t-websocketv2realtimes](https://bybit-exchange.github.io/docs/spot/#t-websocketv2realtimes)  
<p>

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BybitSpotTickerUpdate>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`handler`|Data handler|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to ticker updates*  

</p>

***

## SubscribeToTradeUpdatesAsync  

[https://bybit-exchange.github.io/docs/spot/#t-websocketv2trade](https://bybit-exchange.github.io/docs/spot/#t-websocketv2trade)  
<p>

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<BybitSpotTradeUpdate>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`handler`|Data handler|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to public trade updates*  

</p>
