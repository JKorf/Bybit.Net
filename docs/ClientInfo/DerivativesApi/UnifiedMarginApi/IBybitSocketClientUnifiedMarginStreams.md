---
title: IBybitSocketClientUnifiedMarginStreams
has_children: false
parent: IBybitSocketClientDerivativesStreams\UnifiedMarginStreams
grand_parent: Socket API documentation
---
*[generated documentation]*  
`BybitSocketClient > DerivativesStreams\UnifiedMarginStreams > UnifiedMarginStreams`  
*Bybit Unified margin streams*
  

***

## SubscribeToBalanceUpdatesAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketwallet](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketwallet)  
<p>

*Subscribe to user balance updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.DerivativesStreams\UnifiedMarginStreams.UnifiedMarginStreams.SubscribeToBalanceUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(Action<DataEvent<BybitUnifiedMarginBalance>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToGreeksUpdatesAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-greeksoption](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-greeksoption)  
<p>

*Subscribe to greeks update*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.DerivativesStreams\UnifiedMarginStreams.UnifiedMarginStreams.SubscribeToGreeksUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToGreeksUpdatesAsync(Action<DataEvent<IEnumerable<BybitGreeksUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToOrderUpdatesAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketorder](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketorder)  
<p>

*Subscribe to user order updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.DerivativesStreams\UnifiedMarginStreams.UnifiedMarginStreams.SubscribeToOrderUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<IEnumerable<BybitUnifiedMarginOrderUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToPositionUpdatesAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketposition](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketposition)  
<p>

*Subscribe to user position updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.DerivativesStreams\UnifiedMarginStreams.UnifiedMarginStreams.SubscribeToPositionUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(Action<DataEvent<IEnumerable<BybitUnifiedMarginPositionUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToUserTradeUpdatesAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketexecution](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketexecution)  
<p>

*Subscribe to user trade updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.DerivativesStreams\UnifiedMarginStreams.UnifiedMarginStreams.SubscribeToUserTradeUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(Action<DataEvent<IEnumerable<BybitDerivativesUserTradeUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>
