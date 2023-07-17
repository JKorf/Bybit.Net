---
title: IBybitSocketClientPrivateApi
has_children: true
parent: IBybitSocketClientV5
grand_parent: Socket API documentation
---
*[generated documentation]*  
`BybitSocketClient > V5 > PrivateApi`  
*Bybit user data streams*
  

***

## SubscribeToGreekUpdatesAsync  

[https://bybit-exchange.github.io/docs/v5/websocket/private/greek](https://bybit-exchange.github.io/docs/v5/websocket/private/greek)  
<p>

*Subscribe to Greek updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.V5.PrivateApi.SubscribeToGreekUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToGreekUpdatesAsync(Action<DataEvent<IEnumerable<BybitGreeks>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token. Cancelling will cancel the subscription|

</p>

***

## SubscribeToOrderUpdatesAsync  

[https://bybit-exchange.github.io/docs/v5/websocket/private/order](https://bybit-exchange.github.io/docs/v5/websocket/private/order)  
<p>

*Subscribe to order updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.V5.PrivateApi.SubscribeToOrderUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<IEnumerable<BybitOrderUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token. Cancelling will cancel the subscription|

</p>

***

## SubscribeToPositionUpdatesAsync  

[https://bybit-exchange.github.io/docs/v5/websocket/private/position](https://bybit-exchange.github.io/docs/v5/websocket/private/position)  
<p>

*Subscribe to position updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.V5.PrivateApi.SubscribeToPositionUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(Action<DataEvent<IEnumerable<BybitPositionUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token. Cancelling will cancel the subscription|

</p>

***

## SubscribeToUserTradeUpdatesAsync  

[https://bybit-exchange.github.io/docs/v5/websocket/private/execution](https://bybit-exchange.github.io/docs/v5/websocket/private/execution)  
<p>

*Subscribe to trade updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.V5.PrivateApi.SubscribeToUserTradeUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(Action<DataEvent<IEnumerable<BybitUserTradeUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token. Cancelling will cancel the subscription|

</p>

***

## SubscribeToWalletUpdatesAsync  

[https://bybit-exchange.github.io/docs/v5/websocket/private/wallet](https://bybit-exchange.github.io/docs/v5/websocket/private/wallet)  
<p>

*Subscribe to wallet balance updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.V5.PrivateApi.SubscribeToWalletUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToWalletUpdatesAsync(Action<DataEvent<IEnumerable<BybitBalance>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|Data handler|
|_[Optional]_ ct|Cancellation token. Cancelling will cancel the subscription|

</p>
