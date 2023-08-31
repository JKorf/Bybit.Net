---
title: IBybitRestClientContractApiTrading
has_children: false
parent: IBybitRestClientDerivativesApi\ContractApi
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BybitRestClient > DerivativesApi\ContractApi > ContractApiTrading`  
*Bybit trading endpoints, placing and managing orders.*
  

***

## CancelAllOrdersAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-contract_cancelallorders](https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-contract_cancelallorders)  
<p>

*Cancel all orders that are unfilled or partially filled. Fully filled orders cannot be cancelled.*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\ContractApi.ContractApiTrading.CancelAllOrdersAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitDerivativesOrderId>>> CancelAllOrdersAsync(string? symbol = default, string? settleAsset = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ symbol|The symbol|
|_[Optional]_ settleAsset|Cancel orders by settle coin|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## CancelOrderAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-contract_cancelorder](https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-contract_cancelorder)  
<p>

*Cancel an order, either orderId or clientOrderId should be provided*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\ContractApi.ContractApiTrading.CancelOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitDerivativesOrderId>> CancelOrderAsync(string symbol, string? orderId = default, string? clientOrderId = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ orderId|The id of the order to cancel|
|_[Optional]_ clientOrderId|The client order id of the conditional order to cancel|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOpenOrdersRealTimeAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-contract_getrealtimeorder](https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-contract_getrealtimeorder)  
<p>

*Query real-time order information*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\ContractApi.ContractApiTrading.GetOpenOrdersRealTimeAsync();  
```  

```csharp  
Task<WebCallResult<BybitCursorPage<IEnumerable<BybitContractOrder>>>> GetOpenOrdersRealTimeAsync(string? symbol = default, string? orderId = default, string? clientOrderId = default, string? settleAsset = default, OrderFilter? orderFilter = default, int? limit = default, string? cursor = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ symbol|The symbol|
|_[Optional]_ orderId|Filter by order id|
|_[Optional]_ clientOrderId|Filter by client order id|
|_[Optional]_ settleAsset|Settle coin. Either symbol or settleCoin is required. If both are passed, symbol is used first.|
|_[Optional]_ orderFilter|Conditional order or active order|
|_[Optional]_ limit| Limit for data size per page, max size is 200. Default as showing 50 pieces of data per page. |
|_[Optional]_ cursor| Page turning mark |
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOrdersAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-contract_getorder](https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-contract_getorder)  
<p>

*Get orders*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\ContractApi.ContractApiTrading.GetOrdersAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitCursorPage<IEnumerable<BybitContractOrder>>>> GetOrdersAsync(string symbol, string? orderId = default, string? clientOrderId = default, OrderStatus? status = default, OrderFilter? orderFilter = default, int? limit = default, string? cursor = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ orderId|Filter by order id|
|_[Optional]_ clientOrderId|Filter by client order id|
|_[Optional]_ status|Filter by status|
|_[Optional]_ orderFilter|Conditional order or active order|
|_[Optional]_ limit| Limit for data size per page, max size is 200. Default as showing 50 pieces of data per page. |
|_[Optional]_ cursor| Page turning mark |
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## PlaceOrderAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-dv_placeorder](https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-dv_placeorder)  
<p>

*Place a new order*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\ContractApi.ContractApiTrading.PlaceOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitDerivativesOrderId>> PlaceOrderAsync(string symbol, OrderSide side, OrderType type, decimal quantity, TimeInForce timeInForce, bool? reduceOnly = default, bool? closeOnTrigger = default, decimal? price = default, string? clientOrderId = default, decimal? takeProfitPrice = default, decimal? stopLossPrice = default, TriggerType? takeProfitTriggerType = default, TriggerType? stopLossTriggerType = default, PositionMode? positionMode = default, StopLossTakeProfitMode? stopLossTakeProfitMode = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|side|Order side|
|type|Order type|
|quantity|Quantity|
|timeInForce|Time in force|
|_[Optional]_ reduceOnly|True means your position can only reduce in size if this order is triggered|
|_[Optional]_ closeOnTrigger|For a closing order. It can only reduce your position, not increase it. If the account has insufficient available balance when the closing order is triggered, then other active orders of similar contracts will be cancelled or reduced. It can be used to ensure your stop loss reduces your position regardless of current available margin.|
|_[Optional]_ price|Price|
|_[Optional]_ clientOrderId|Client order id|
|_[Optional]_ takeProfitPrice|Take profit price, only take effect upon opening the position|
|_[Optional]_ stopLossPrice|Stop loss price, only take effect upon opening the position|
|_[Optional]_ takeProfitTriggerType|Take profit trigger price type, default: LastPrice|
|_[Optional]_ stopLossTriggerType|Stop loss trigger price type, default: LastPrice|
|_[Optional]_ positionMode|Position mode|
|_[Optional]_ stopLossTakeProfitMode|StopLoss / TakeProfit mode|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## ReplaceOrderAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_replaceorder](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_replaceorder)  
<p>

*Change an exising order. Either orderId or clientOrderId should be provided*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\ContractApi.ContractApiTrading.ReplaceOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitDerivativesOrderId>> ReplaceOrderAsync(string symbol, string? orderId = default, string? clientOrderId = default, decimal? quantity = default, decimal? price = default, decimal? triggerPrice = default, decimal? takeProfitPrice = default, decimal? stopLossPrice = default, TriggerType? takeProfitTriggerType = default, TriggerType? stopLossTriggerType = default, TriggerType? triggerType = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ orderId|Order ID. Required if not passing orderLinkId|
|_[Optional]_ clientOrderId|Client order id|
|_[Optional]_ quantity|Quantity|
|_[Optional]_ price|Quantity|
|_[Optional]_ triggerPrice|Trigger price|
|_[Optional]_ takeProfitPrice|Take profit price, only take effect upon opening the position|
|_[Optional]_ stopLossPrice|Stop loss price, only take effect upon opening the position|
|_[Optional]_ takeProfitTriggerType|Take profit trigger price type, default: LastPrice|
|_[Optional]_ stopLossTriggerType|Stop loss trigger price type, default: LastPrice>|
|_[Optional]_ triggerType|Trigger price type: Market price/Mark price|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetTradingStop  

<p>

*Set take profit, stop loss, and trailing stop for your open position. If using partial mode, TP/SL/TS orders will not close your entire position.*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\ContractApi.ContractApiTrading.SetTradingStop(/* parameters */);  
```  

```csharp  
Task<WebCallResult> SetTradingStop(string symbol, decimal? takeProfitPrice = default, decimal? stopLossPrice = default, decimal? activePrice = default, decimal? trailingStop = default, TriggerType? takeProfitTriggerType = default, TriggerType? stopLossTriggerType = default, decimal? stopLossSize = default, decimal? takeProfitSize = default, PositionMode? positionMode = default, StopLossTakeProfitMode? stopLossTakeProfitMode = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|_[Optional]_ takeProfitPrice|Cannot be less than 0, 0 means cancel TP|
|_[Optional]_ stopLossPrice|Cannot be less than 0, 0 means cancel SL|
|_[Optional]_ activePrice|Trailing stop trigger price. Trailing stop will only be triggered when this price is touched |
|_[Optional]_ trailingStop|Cannot be less than 0, 0 means cancel TS|
|_[Optional]_ takeProfitTriggerType|Take profit trigger price type|
|_[Optional]_ stopLossTriggerType|Stop loss trigger price type|
|_[Optional]_ stopLossSize|Stop loss quantity|
|_[Optional]_ takeProfitSize|Take profit quantity|
|_[Optional]_ positionMode|Position mode|
|_[Optional]_ stopLossTakeProfitMode|StopLoss / TakeProfit mode|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>
