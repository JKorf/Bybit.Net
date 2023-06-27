---
title: IBybitSocketClientContractApi
has_children: true
parent: IBybitSocketClientDerivativesApi\ContractApi
grand_parent: Socket API documentation
---
*[generated documentation]*  
`BybitSocketClient > DerivativesApi\ContractApi > ContractApi`  
*Bybit Contract streams*
  

***

## SubscribeToBalanceUpdatesAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-websocketwallet](https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-websocketwallet)  
<p>

*Subscribe to user balance updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.DerivativesApi\ContractApi.ContractApi.SubscribeToBalanceUpdatesAsync(/* parameters */);  
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
var result = await client.DerivativesApi\ContractApi.ContractApi.SubscribeToOrderUpdatesAsync(/* parameters */);  
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
var result = await client.DerivativesApi\ContractApi.ContractApi.SubscribeToPositionUpdatesAsync(/* parameters */);  
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
var result = await client.DerivativesApi\ContractApi.ContractApi.SubscribeToUserTradeUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(Action<DataEvent<IEnumerable<BybitContractUserTradeUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>
