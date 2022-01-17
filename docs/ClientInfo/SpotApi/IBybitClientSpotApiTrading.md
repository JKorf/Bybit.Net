---
title: IBybitClientSpotApiTrading
has_children: false
parent: IBybitClientSpotApi
grand_parent: IBybitClient
---
*[generated documentation]*  
`BybitClient > SpotApi > Trading`  
*Bybit trading endpoints, placing and mananging orders.*
  

***

## CancelOrderAsync  

[https://bybit-exchange.github.io/docs/spot/#t-cancelactive](https://bybit-exchange.github.io/docs/spot/#t-cancelactive)  
<p>

*Cancel an active order. Either orderId or clientOrderId should be provided*  

```csharp  
var client = new BybitClient();  
var result = await client.SpotApi.Trading.CancelOrderAsync();  
```  

```csharp  
Task<WebCallResult<BybitSpotOrderPlaced>> CancelOrderAsync(long? orderId = default, string? clientOrderId = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|[Optional] `orderId`|The order id|
|[Optional] `clientOrderId`|The client order id|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## GetOpenOrdersAsync  

[https://bybit-exchange.github.io/docs/spot/#t-openorders](https://bybit-exchange.github.io/docs/spot/#t-openorders)  
<p>

*Get open orders*  

```csharp  
var client = new BybitClient();  
var result = await client.SpotApi.Trading.GetOpenOrdersAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitSpotOrder>>> GetOpenOrdersAsync(string? symbol = default, long? orderId = default, int? limit = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|[Optional] `symbol`|The symbol|
|[Optional] `orderId`|Filter by order id, will only return orders with an orderId smaller than this|
|[Optional] `limit`|Max amount of results|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## GetOrderAsync  

[https://bybit-exchange.github.io/docs/spot/#t-getactive](https://bybit-exchange.github.io/docs/spot/#t-getactive)  
<p>

*Get order, either orderId or clientOrderId should be provided*  

```csharp  
var client = new BybitClient();  
var result = await client.SpotApi.Trading.GetOrderAsync();  
```  

```csharp  
Task<WebCallResult<BybitSpotOrder>> GetOrderAsync(long? orderId = default, string? clientOrderId = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|[Optional] `orderId`|The id of the order|
|[Optional] `clientOrderId`|The client order id|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## GetOrdersAsync  

[https://bybit-exchange.github.io/docs/spot/#t-orderhistory](https://bybit-exchange.github.io/docs/spot/#t-orderhistory)  
<p>

*Get orders*  

```csharp  
var client = new BybitClient();  
var result = await client.SpotApi.Trading.GetOrdersAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitSpotOrder>>> GetOrdersAsync(string? symbol = default, long? orderId = default, int? limit = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|[Optional] `symbol`|Filter by symbol|
|[Optional] `orderId`|Filter by order id, will only return orders with an orderId smaller than this|
|[Optional] `limit`|Max amount of results|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## GetUserTradesAsync  

[https://bybit-exchange.github.io/docs/spot/#t-tradehistory](https://bybit-exchange.github.io/docs/spot/#t-tradehistory)  
<p>

*Get user trade history*  

```csharp  
var client = new BybitClient();  
var result = await client.SpotApi.Trading.GetUserTradesAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitSpotUserTrade>>> GetUserTradesAsync(string? symbol = default, long? fromId = default, long? toId = default, int? limit = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|[Optional] `symbol`|Filter by symbol|
|[Optional] `fromId`|Filter by start id|
|[Optional] `toId`|Filter by end id|
|[Optional] `limit`|Max amount of results|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## PlaceOrderAsync  

[https://bybit-exchange.github.io/docs/spot/#t-placeactive](https://bybit-exchange.github.io/docs/spot/#t-placeactive)  
<p>

*Place a new order*  

```csharp  
var client = new BybitClient();  
var result = await client.SpotApi.Trading.PlaceOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitSpotOrderPlaced>> PlaceOrderAsync(string symbol, OrderSide side, OrderType type, decimal quantity, decimal? price = default, TimeInForce? timeInForce = default, string? clientOrderId = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
| `symbol`|The symbol|
| `side`|Order side|
| `type`|Order type|
| `quantity`|Quantity of the order. Note that for market buy orders this is the quantity of quote asset, otherwise it's in base asset|
|[Optional] `price`|Price|
|[Optional] `timeInForce`|Time in force|
|[Optional] `clientOrderId`|Client order id|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>
