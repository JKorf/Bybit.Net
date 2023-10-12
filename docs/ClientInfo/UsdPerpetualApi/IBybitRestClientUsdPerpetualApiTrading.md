---
title: IBybitRestClientUsdPerpetualApiTrading
has_children: false
parent: IBybitRestClientUsdPerpetualApi
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BybitRestClient > UsdPerpetualApi > Trading`  
*[DEPRECATED, WILL STOP WORKING ON 30 OCTOBER, USE V5 API INSTEAD] Bybit trading endpoints, placing and managing orders.*
  

***

## CancelAllConditionalOrdersAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-cancelallcond](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-cancelallcond)  
<p>

*Cancel all active conditional orders for a symbol*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Trading.CancelAllConditionalOrdersAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<string>>> CancelAllConditionalOrdersAsync(string symbol, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## CancelAllOrdersAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-cancelallactive](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-cancelallactive)  
<p>

*Cancel all active orders for a symbol*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Trading.CancelAllOrdersAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<string>>> CancelAllOrdersAsync(string symbol, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## CancelConditionalOrderAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-cancelcond](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-cancelcond)  
<p>

*Cancel a conditional order, either stopOrderId or clientOrderId should be provided*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Trading.CancelConditionalOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitStopOrderId>> CancelConditionalOrderAsync(string symbol, string? stopOrderId = default, string? clientOrderId = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ stopOrderId|The id of the conditional order to cancel|
|_[Optional]_ clientOrderId|The client order id of the conditional order to cancel|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## CancelOrderAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-cancelactive](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-cancelactive)  
<p>

*Cancel an order, either orderId or clientOrderId should be provided*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Trading.CancelOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitOrderId>> CancelOrderAsync(string symbol, string? orderId = default, string? clientOrderId = default, long? receiveWindow = default, CancellationToken ct = default);  
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

## GetConditionalOrdersAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-getcond](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-getcond)  
<p>

*Get a list of conditional orders*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Trading.GetConditionalOrdersAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitCursorPage<IEnumerable<BybitConditionalOrderUsd>>>> GetConditionalOrdersAsync(string symbol, string? stopOrderId = default, string? clientOrderId = default, OrderStatus? status = default, SortOrder? order = default, int? pageSize = default, int? page = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ stopOrderId|Filter by order id|
|_[Optional]_ clientOrderId|Filter by client order id|
|_[Optional]_ status|Filter by status|
|_[Optional]_ order|Result order|
|_[Optional]_ pageSize|Page size|
|_[Optional]_ page|Page|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOpenConditionalOrderRealTimeAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-querycond](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-querycond)  
<p>

*Get conditional order information. Either stopOrderId or clientOrderId should be provided*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Trading.GetOpenConditionalOrderRealTimeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitConditionalOrderUsd>> GetOpenConditionalOrderRealTimeAsync(string symbol, string? stopOrderId = default, string? clientOrderId = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ stopOrderId|The order id|
|_[Optional]_ clientOrderId|The client order id|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOpenConditionalOrdersRealTimeAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-querycond](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-querycond)  
<p>

*Get order information for up to 10 conditional orders*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Trading.GetOpenConditionalOrdersRealTimeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitConditionalOrderUsd>>> GetOpenConditionalOrdersRealTimeAsync(string symbol, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOpenOrderRealTimeAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-queryactive](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-queryactive)  
<p>

*Get order information. Either orderId or clientOrderId should be provided*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Trading.GetOpenOrderRealTimeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitUsdPerpetualOrder>> GetOpenOrderRealTimeAsync(string symbol, string? orderId = default, string? clientOrderId = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ orderId||
|_[Optional]_ clientOrderId||
|_[Optional]_ receiveWindow||
|_[Optional]_ ct||

</p>

***

## GetOpenOrdersRealTimeAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-queryactive](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-queryactive)  
<p>

*Get order information for up to 500 orders*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Trading.GetOpenOrdersRealTimeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitUsdPerpetualOrder>>> GetOpenOrdersRealTimeAsync(string symbol, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOrdersAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-getactive](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-getactive)  
<p>

*Get orders*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Trading.GetOrdersAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitCursorPage<IEnumerable<BybitUsdPerpetualOrder>>>> GetOrdersAsync(string symbol, string? orderId = default, string? clientOrderId = default, OrderStatus? status = default, SortOrder? order = default, int? pageSize = default, int? page = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ orderId|Filter by order id|
|_[Optional]_ clientOrderId|Filter by client order id|
|_[Optional]_ status|Filter by status|
|_[Optional]_ order|The result order|
|_[Optional]_ pageSize|The page size|
|_[Optional]_ page|The page|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetUserTradesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-usertraderecords](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-usertraderecords)  
<p>

*Get executed user trades*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Trading.GetUserTradesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitPage<IEnumerable<BybitUserTrade>>>> GetUserTradesAsync(string symbol, DateTime? startTime = default, DateTime? endTime = default, int? page = default, int? pageSize = default, TradeType? type = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ startTime|Filter by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ page|Page|
|_[Optional]_ pageSize|Page size|
|_[Optional]_ type|Filter by type|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## ModifyConditionalOrderAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-replacecond](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-replacecond)  
<p>

*Change an exising order. Either stopOrderId or clientOrderId should be provided*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Trading.ModifyConditionalOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitStopOrderId>> ModifyConditionalOrderAsync(string symbol, string? stopOrderId = default, string? clientOrderId = default, decimal? newPrice = default, decimal? newTriggerPrice = default, decimal? newQuantity = default, decimal? takeProfitPrice = default, decimal? stopLossPrice = default, TriggerType? takeProfitTriggerType = default, TriggerType? stopLossTriggerType = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ stopOrderId|Stop order id|
|_[Optional]_ clientOrderId|Client order id|
|_[Optional]_ newPrice|New price to set|
|_[Optional]_ newTriggerPrice|New trigger price to set|
|_[Optional]_ newQuantity|New quantity to set|
|_[Optional]_ takeProfitPrice|New take profit price|
|_[Optional]_ stopLossPrice|New stop loss price|
|_[Optional]_ takeProfitTriggerType|New take profit trigger type|
|_[Optional]_ stopLossTriggerType|New stop loss profit price|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## ModifyOrderAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-replaceactive](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-replaceactive)  
<p>

*Change an exising order. Either orderId or clientOrderId should be provided*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Trading.ModifyOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitOrderId>> ModifyOrderAsync(string symbol, string? orderId = default, string? clientOrderId = default, decimal? newPrice = default, decimal? newQuantity = default, decimal? takeProfitPrice = default, decimal? stopLossPrice = default, TriggerType? takeProfitTriggerType = default, TriggerType? stopLossTriggerType = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ orderId|Stop order id|
|_[Optional]_ clientOrderId|Client order id|
|_[Optional]_ newPrice|New price to set|
|_[Optional]_ newQuantity|New quantity to set|
|_[Optional]_ takeProfitPrice|New take profit price|
|_[Optional]_ stopLossPrice|New stop loss price|
|_[Optional]_ takeProfitTriggerType|New take profit trigger type|
|_[Optional]_ stopLossTriggerType|New stop loss profit price|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## PlaceConditionalOrderAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-placecond](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-placecond)  
<p>

*Place a new conditional order*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Trading.PlaceConditionalOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitConditionalOrderUsd>> PlaceConditionalOrderAsync(string symbol, OrderSide side, OrderType type, decimal quantity, decimal basePrice, decimal triggerPrice, TimeInForce timeInForce, bool closeOnTrigger, bool reduceOnly, decimal? price = default, TriggerType? triggerType = default, string? clientOrderId = default, decimal? takeProfitPrice = default, decimal? stopLossPrice = default, TriggerType? takeProfitTriggerType = default, TriggerType? stopLossTriggerType = default, PositionMode? positionMode = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|side|Order side|
|type|Order type|
|quantity|Quantity|
|basePrice|It will be used to compare with the value of trigger price, to decide whether your conditional order will be triggered by crossing trigger price from upper side or lower side. Mainly used to identify the expected direction of the current conditional order.|
|triggerPrice|Trigger price|
|timeInForce|Time in force|
|closeOnTrigger|For a closing order. It can only reduce your position, not increase it. If the account has insufficient available balance when the closing order is triggered, then other active orders of similar contracts will be cancelled or reduced. It can be used to ensure your stop loss reduces your position regardless of current available margin.|
|reduceOnly|True means your position can only reduce in size if this order is triggered. When reduce_only is true, take profit/stop loss cannot be set|
|_[Optional]_ price|Price|
|_[Optional]_ triggerType|Trigger type|
|_[Optional]_ clientOrderId|Client order id|
|_[Optional]_ takeProfitPrice|Take profit price, only take effect upon opening the position|
|_[Optional]_ stopLossPrice|Stop loss price, only take effect upon opening the position|
|_[Optional]_ takeProfitTriggerType|Take profit trigger price type, default: LastPrice|
|_[Optional]_ stopLossTriggerType|Stop loss trigger price type, default: LastPrice|
|_[Optional]_ positionMode|Position mode|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## PlaceOrderAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-placeactive](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-placeactive)  
<p>

*Place a new order*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Trading.PlaceOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitUsdPerpetualOrder>> PlaceOrderAsync(string symbol, OrderSide side, OrderType type, decimal quantity, TimeInForce timeInForce, bool reduceOnly, bool closeOnTrigger, decimal? price = default, string? clientOrderId = default, decimal? takeProfitPrice = default, decimal? stopLossPrice = default, TriggerType? takeProfitTriggerType = default, TriggerType? stopLossTriggerType = default, PositionMode? positionMode = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|side|Order side|
|type|Order type|
|quantity|Quantity|
|timeInForce|Time in force|
|reduceOnly|True means your position can only reduce in size if this order is triggered|
|closeOnTrigger|For a closing order. It can only reduce your position, not increase it. If the account has insufficient available balance when the closing order is triggered, then other active orders of similar contracts will be cancelled or reduced. It can be used to ensure your stop loss reduces your position regardless of current available margin.|
|_[Optional]_ price|Price|
|_[Optional]_ clientOrderId|Client order id|
|_[Optional]_ takeProfitPrice|Take profit price, only take effect upon opening the position|
|_[Optional]_ stopLossPrice|Stop loss price, only take effect upon opening the position|
|_[Optional]_ takeProfitTriggerType|Take profit trigger price type, default: LastPrice|
|_[Optional]_ stopLossTriggerType|Stop loss trigger price type, default: LastPrice|
|_[Optional]_ positionMode|Position mode|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetTradingStopAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-tradingstop](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-tradingstop)  
<p>

*Set take profit, stop loss, and trailing stop for your open position*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Trading.SetTradingStopAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> SetTradingStopAsync(string symbol, PositionSide side, decimal? takeProfitPrice = default, decimal? stopLossPrice = default, decimal? trailingStopPrice = default, TriggerType? takeProfitTriggerType = default, TriggerType? stopLossTriggerType = default, decimal? takeProfitQuantity = default, decimal? stopLossQuantity = default, PositionMode? positionMode = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|side|The position side|
|_[Optional]_ takeProfitPrice|The new take profit price. Setting it to null will not change the value, setting it to 0 will remove the current TakeProfit|
|_[Optional]_ stopLossPrice|The new stop loss price. Setting it to null will not change the value, setting it to 0 will remove the current StopLoss|
|_[Optional]_ trailingStopPrice|Setting it to null will not change the value, setting it to 0 will remove the current TrailingStop|
|_[Optional]_ takeProfitTriggerType|Take profit trigger type, defaults to LastPrice|
|_[Optional]_ stopLossTriggerType|Stop loss trigger type, defaults to LastPrice|
|_[Optional]_ takeProfitQuantity|Take profit quantity when in Partial mode|
|_[Optional]_ stopLossQuantity|Stop loss quantity when in Partial mode|
|_[Optional]_ positionMode|Position mode|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>
