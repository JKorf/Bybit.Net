---
title: IBybitSocketClientContractStreams
has_children: false
parent: IBybitSocketClientDerivativesStreams\ContractStreams
grand_parent: Socket API documentation
---
*[generated documentation]*  
`BybitSocketClient > DerivativesStreams\ContractStreams > ContractStreams`  
*Bybit Contract streams*
  

***

## SubscribeToBalanceUpdatesAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-websocketwallet](https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-websocketwallet)  
<p>

*Subscribe to user balance updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.DerivativesStreams\ContractStreams.ContractStreams.SubscribeToBalanceUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(Action<DataEvent<IEnumerable<BybitContractBalanceUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToOrderUpdatesAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-websocketorder](https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-websocketorder)  
<p>

*Subscribe to user order updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.DerivativesStreams\ContractStreams.ContractStreams.SubscribeToOrderUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<IEnumerable<BybitContractOrderUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToPositionUpdatesAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-websocketposition](https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-websocketposition)  
<p>

*Subscribe to user position updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.DerivativesStreams\ContractStreams.ContractStreams.SubscribeToPositionUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(Action<DataEvent<IEnumerable<BybitContractPositionUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToUserTradeUpdatesAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-websocketexecution](https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-websocketexecution)  
<p>

*Subscribe to user trade updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.DerivativesStreams\ContractStreams.ContractStreams.SubscribeToUserTradeUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(Action<DataEvent<IEnumerable<BybitContractUserTradeUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>
