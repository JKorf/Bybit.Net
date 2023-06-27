---
title: IBybitSocketClientCopyTradingApi
has_children: true
parent: Socket API documentation
---
*[generated documentation]*  
`BybitSocketClient > CopyTradingApi`  
*Bybit copy trading streams*
  

***

## SubscribeToBalanceUpdatesAsync  

[https://bybit-exchange.github.io/docs/copy_trading/#t-websocketwallet](https://bybit-exchange.github.io/docs/copy_trading/#t-websocketwallet)  
<p>

*Subscribe to user balance updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.CopyTradingApi.SubscribeToBalanceUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(Action<DataEvent<BybitCopyTradingBalanceUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToOrderUpdatesAsync  

[https://bybit-exchange.github.io/docs/copy_trading/#t-websocketorder](https://bybit-exchange.github.io/docs/copy_trading/#t-websocketorder)  
<p>

*Subscribe to user order updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.CopyTradingApi.SubscribeToOrderUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<IEnumerable<BybitCopyTradingOrderUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToPositionUpdatesAsync  

[https://bybit-exchange.github.io/docs/copy_trading/#t-websocketposition](https://bybit-exchange.github.io/docs/copy_trading/#t-websocketposition)  
<p>

*Subscribe to user position updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.CopyTradingApi.SubscribeToPositionUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(Action<DataEvent<IEnumerable<BybitCopyTradingPositionUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToUserTradeUpdatesAsync  

[https://bybit-exchange.github.io/docs/copy_trading/#t-websocketexecution](https://bybit-exchange.github.io/docs/copy_trading/#t-websocketexecution)  
<p>

*Subscribe to user trade updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.CopyTradingApi.SubscribeToUserTradeUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(Action<DataEvent<IEnumerable<BybitCopyTradingUserTradeUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>
