---
title: IBybitClientUsdPerpetualApiTrading
has_children: false
parent: IBybitClientUsdPerpetualApi
grand_parent: IBybitClient
---
*[generated documentation]*  
`BybitClient > UsdPerpetualApi > Trading`  
*Bybit trading endpoints, placing and mananging orders.*
  

***

## CancelAllConditionalOrdersAsync  

[https://bybit-exchange.github.io/docs/linear/#t-cancelallcond](https://bybit-exchange.github.io/docs/linear/#t-cancelallcond)  
<p>

*Cancel all active conditional orders for a symbol*  

```csharp  
var client = new BybitClient();  
var result = await client.UsdPerpetualApi.Trading.CancelAllConditionalOrdersAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<string>>> CancelAllConditionalOrdersAsync(string symbol, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
| `symbol`|The symbol|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## CancelAllOrdersAsync  

[https://bybit-exchange.github.io/docs/linear/#t-cancelallactive](https://bybit-exchange.github.io/docs/linear/#t-cancelallactive)  
<p>

*Cancel all active orders for a symbol*  

```csharp  
var client = new BybitClient();  
var result = await client.UsdPerpetualApi.Trading.CancelAllOrdersAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<string>>> CancelAllOrdersAsync(string symbol, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
| `symbol`|The symbol|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## CancelConditionalOrderAsync  

[https://bybit-exchange.github.io/docs/linear/#t-cancelcond](https://bybit-exchange.github.io/docs/linear/#t-cancelcond)  
<p>

*Cancel a conditional order, either stopOrderId or clientOrderId should be provided*  

```csharp  
var client = new BybitClient();  
var result = await client.UsdPerpetualApi.Trading.CancelConditionalOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitStopOrderId>> CancelConditionalOrderAsync(string symbol, string? stopOrderId = default, string? clientOrderId = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
| `symbol`|The symbol|
|[Optional] `stopOrderId`|The id of the conditional order to cancel|
|[Optional] `clientOrderId`|The client order id of the conditional order to cancel|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## CancelOrderAsync  

[https://bybit-exchange.github.io/docs/linear/#t-cancelactive](https://bybit-exchange.github.io/docs/linear/#t-cancelactive)  
<p>

*Cancel an order, either orderId or clientOrderId should be provided*  

```csharp  
var client = new BybitClient();  
var result = await client.UsdPerpetualApi.Trading.CancelOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitOrderId>> CancelOrderAsync(string symbol, string? orderId = default, string? clientOrderId = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
| `symbol`|The symbol|
|[Optional] `orderId`|The id of the order to cancel|
|[Optional] `clientOrderId`|The client order id of the conditional order to cancel|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## GetConditionalOrdersAsync  

[https://bybit-exchange.github.io/docs/linear/#t-getcond](https://bybit-exchange.github.io/docs/linear/#t-getcond)  
<p>

*Get a list of conditional orders*  

```csharp  
var client = new BybitClient();  
var result = await client.UsdPerpetualApi.Trading.GetConditionalOrdersAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitCursorPage<IEnumerable<BybitConditionalOrderUsd>>>> GetConditionalOrdersAsync(string symbol, string? stopOrderId = default, string? clientOrderId = default, OrderStatus? status = default, SortOrder? order = default, int? pageSize = default, int? page = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
| `symbol`|The symbol|
|[Optional] `stopOrderId`|Filter by order id|
|[Optional] `clientOrderId`|Filter by client order id|
|[Optional] `status`|Filter by status|
|[Optional] `order`|Result order|
|[Optional] `pageSize`|Page size|
|[Optional] `page`|Page|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## GetOpenConditionalOrderRealTimeAsync  

[https://bybit-exchange.github.io/docs/linear/#t-querycond](https://bybit-exchange.github.io/docs/linear/#t-querycond)  
<p>

*Get conditional order information. Either stopOrderId or clientOrderId should be provided*  

```csharp  
var client = new BybitClient();  
var result = await client.UsdPerpetualApi.Trading.GetOpenConditionalOrderRealTimeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitConditionalOrderUsd>> GetOpenConditionalOrderRealTimeAsync(string symbol, string? stopOrderId = default, string? clientOrderId = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
| `symbol`|The symbol|
|[Optional] `stopOrderId`|The order id|
|[Optional] `clientOrderId`|The client order id|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## GetOpenConditionalOrdersRealTimeAsync  

[https://bybit-exchange.github.io/docs/linear/#t-querycond](https://bybit-exchange.github.io/docs/linear/#t-querycond)  
<p>

*Get order information for up to 10 conditional orders*  

```csharp  
var client = new BybitClient();  
var result = await client.UsdPerpetualApi.Trading.GetOpenConditionalOrdersRealTimeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitConditionalOrder>>> GetOpenConditionalOrdersRealTimeAsync(string symbol, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
| `symbol`|The symbol|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## GetOpenOrderRealTimeAsync  

[https://bybit-exchange.github.io/docs/linear/#t-queryactive](https://bybit-exchange.github.io/docs/linear/#t-queryactive)  
<p>

*Get order information. Either orderId or clientOrderId should be provided*  

```csharp  
var client = new BybitClient();  
var result = await client.UsdPerpetualApi.Trading.GetOpenOrderRealTimeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitOrder>> GetOpenOrderRealTimeAsync(string symbol, string? orderId = default, string? clientOrderId = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
| `symbol`|The symbol|
|[Optional] `orderId`||
|[Optional] `clientOrderId`||
|[Optional] `receiveWindow`||
|[Optional] `ct`||

</p>

***

## GetOpenOrdersRealTimeAsync  

[https://bybit-exchange.github.io/docs/linear/#t-queryactive](https://bybit-exchange.github.io/docs/linear/#t-queryactive)  
<p>

*Get order information for up to 500 orders*  

```csharp  
var client = new BybitClient();  
var result = await client.UsdPerpetualApi.Trading.GetOpenOrdersRealTimeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitOrder>>> GetOpenOrdersRealTimeAsync(string symbol, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
| `symbol`|The symbol|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## GetOrdersAsync  

[https://bybit-exchange.github.io/docs/linear/#t-getactive](https://bybit-exchange.github.io/docs/linear/#t-getactive)  
<p>

*Get orders*  

```csharp  
var client = new BybitClient();  
var result = await client.UsdPerpetualApi.Trading.GetOrdersAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitCursorPage<IEnumerable<BybitOrder>>>> GetOrdersAsync(string symbol, string? orderId = default, string? clientOrderId = default, OrderStatus? status = default, SortOrder? order = default, int? pageSize = default, int? page = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
| `symbol`|The symbol|
|[Optional] `orderId`|Filter by order id|
|[Optional] `clientOrderId`|Filter by client order id|
|[Optional] `status`|Filter by status|
|[Optional] `order`|The result order|
|[Optional] `pageSize`|The page size|
|[Optional] `page`|The page|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## GetUserTradesAsync  

[https://bybit-exchange.github.io/docs/linear/#t-usertraderecords](https://bybit-exchange.github.io/docs/linear/#t-usertraderecords)  
<p>

*Get executed user trades*  

```csharp  
var client = new BybitClient();  
var result = await client.UsdPerpetualApi.Trading.GetUserTradesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitUserTrade>>> GetUserTradesAsync(string symbol, DateTime? startTime = default, DateTime? endTime = default, int? page = default, int? pageSize = default, TradeType? type = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
| `symbol`|The symbol|
|[Optional] `startTime`|Filter by start time|
|[Optional] `endTime`|Filter by end time|
|[Optional] `page`|Page|
|[Optional] `pageSize`|Page size|
|[Optional] `type`|Filter by type|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## ModifyConditionalOrderAsync  

[https://bybit-exchange.github.io/docs/linear/#t-replacecond](https://bybit-exchange.github.io/docs/linear/#t-replacecond)  
<p>

*Change an exising order. Either stopOrderId or clientOrderId should be provided*  

```csharp  
var client = new BybitClient();  
var result = await client.UsdPerpetualApi.Trading.ModifyConditionalOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitStopOrderId>> ModifyConditionalOrderAsync(string symbol, string? stopOrderId = default, string? clientOrderId = default, decimal? newPrice = default, decimal? newTriggerPrice = default, decimal? newQuantity = default, decimal? takeProfitPrice = default, decimal? stopLossPrice = default, TriggerType? takeProfitTriggerType = default, TriggerType? stopLossTriggerType = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
| `symbol`|The symbol|
|[Optional] `stopOrderId`|Stop order id|
|[Optional] `clientOrderId`|Client order id|
|[Optional] `newPrice`|New price to set|
|[Optional] `newTriggerPrice`|New trigger price to set|
|[Optional] `newQuantity`|New quantity to set|
|[Optional] `takeProfitPrice`|New take profit price|
|[Optional] `stopLossPrice`|New stop loss price|
|[Optional] `takeProfitTriggerType`|New take profit trigger type|
|[Optional] `stopLossTriggerType`|New stop loss profit price|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## ModifyOrderAsync  

[https://bybit-exchange.github.io/docs/linear/#t-replaceactive](https://bybit-exchange.github.io/docs/linear/#t-replaceactive)  
<p>

*Change an exising order. Either orderId or clientOrderId should be provided*  

```csharp  
var client = new BybitClient();  
var result = await client.UsdPerpetualApi.Trading.ModifyOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitOrderId>> ModifyOrderAsync(string symbol, string? orderId = default, string? clientOrderId = default, decimal? newPrice = default, decimal? newQuantity = default, decimal? takeProfitPrice = default, decimal? stopLossPrice = default, TriggerType? takeProfitTriggerType = default, TriggerType? stopLossTriggerType = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
| `symbol`|The symbol|
|[Optional] `orderId`|Stop order id|
|[Optional] `clientOrderId`|Client order id|
|[Optional] `newPrice`|New price to set|
|[Optional] `newQuantity`|New quantity to set|
|[Optional] `takeProfitPrice`|New take profit price|
|[Optional] `stopLossPrice`|New stop loss price|
|[Optional] `takeProfitTriggerType`|New take profit trigger type|
|[Optional] `stopLossTriggerType`|New stop loss profit price|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## PlaceConditionalOrderAsync  

[https://bybit-exchange.github.io/docs/linear/#t-placecond](https://bybit-exchange.github.io/docs/linear/#t-placecond)  
<p>

*Place a new conditional order*  

```csharp  
var client = new BybitClient();  
var result = await client.UsdPerpetualApi.Trading.PlaceConditionalOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitConditionalOrderUsd>> PlaceConditionalOrderAsync(string symbol, OrderSide side, OrderType type, decimal quantity, decimal basePrice, decimal triggerPrice, TimeInForce timeInForce, bool closeOnTrigger, bool reduceOnly, decimal? price = default, TriggerType? triggerType = default, string? clientOrderId = default, decimal? takeProfitPrice = default, decimal? stopLossPrice = default, TriggerType? takeProfitTriggerType = default, TriggerType? stopLossTriggerType = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
| `symbol`|The symbol|
| `side`|Order side|
| `type`|Order type|
| `quantity`|Quantity|
| `basePrice`|It will be used to compare with the value of trigger price, to decide whether your conditional order will be triggered by crossing trigger price from upper side or lower side. Mainly used to identify the expected direction of the current conditional order.|
| `triggerPrice`|Trigger price|
| `timeInForce`|Time in force|
| `closeOnTrigger`|For a closing order. It can only reduce your position, not increase it. If the account has insufficient available balance when the closing order is triggered, then other active orders of similar contracts will be cancelled or reduced. It can be used to ensure your stop loss reduces your position regardless of current available margin.|
| `reduceOnly`|True means your position can only reduce in size if this order is triggered. When reduce_only is true, take profit/stop loss cannot be set|
|[Optional] `price`|Price|
|[Optional] `triggerType`|Trigger type|
|[Optional] `clientOrderId`|Client order id|
|[Optional] `takeProfitPrice`|Take profit price, only take effect upon opening the position|
|[Optional] `stopLossPrice`|Stop loss price, only take effect upon opening the position|
|[Optional] `takeProfitTriggerType`|Take profit trigger price type, default: LastPrice|
|[Optional] `stopLossTriggerType`|Stop loss trigger price type, default: LastPrice|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## PlaceOrderAsync  

[https://bybit-exchange.github.io/docs/linear/#t-placeactive](https://bybit-exchange.github.io/docs/linear/#t-placeactive)  
<p>

*Place a new order*  

```csharp  
var client = new BybitClient();  
var result = await client.UsdPerpetualApi.Trading.PlaceOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitOrder>> PlaceOrderAsync(string symbol, OrderSide side, OrderType type, decimal quantity, TimeInForce timeInForce, bool reduceOnly, bool closeOnTrigger, decimal? price = default, string? clientOrderId = default, decimal? takeProfitPrice = default, decimal? stopLossPrice = default, TriggerType? takeProfitTriggerType = default, TriggerType? stopLossTriggerType = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
| `symbol`|The symbol|
| `side`|Order side|
| `type`|Order type|
| `quantity`|Quantity|
| `timeInForce`|Time in force|
| `reduceOnly`|True means your position can only reduce in size if this order is triggered|
| `closeOnTrigger`|For a closing order. It can only reduce your position, not increase it. If the account has insufficient available balance when the closing order is triggered, then other active orders of similar contracts will be cancelled or reduced. It can be used to ensure your stop loss reduces your position regardless of current available margin.|
|[Optional] `price`|Price|
|[Optional] `clientOrderId`|Client order id|
|[Optional] `takeProfitPrice`|Take profit price, only take effect upon opening the position|
|[Optional] `stopLossPrice`|Stop loss price, only take effect upon opening the position|
|[Optional] `takeProfitTriggerType`|Take profit trigger price type, default: LastPrice|
|[Optional] `stopLossTriggerType`|Stop loss trigger price type, default: LastPrice|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>
