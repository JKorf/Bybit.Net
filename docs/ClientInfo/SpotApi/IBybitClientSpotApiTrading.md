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

```C#  
Task<WebCallResult<BybitSpotOrderPlaced>> CancelOrderAsync([Optional] long? orderId, [Optional] string? clientOrderId, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`orderId`|The order id|
|`clientOrderId`|The client order id|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Cancel an active order. Either orderId or clientOrderId should be provided*  

</p>

***

## GetOpenOrdersAsync  

[https://bybit-exchange.github.io/docs/spot/#t-openorders](https://bybit-exchange.github.io/docs/spot/#t-openorders)  
<p>

```C#  
Task<WebCallResult<IEnumerable<BybitSpotOrder>>> GetOpenOrdersAsync([Optional] string? symbol, [Optional] long? orderId, [Optional] int? limit, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`orderId`|Filter by order id, will only return orders with an orderId smaller than this|
|`limit`|Max amount of results|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get open orders*  

</p>

***

## GetOrderAsync  

[https://bybit-exchange.github.io/docs/spot/#t-getactive](https://bybit-exchange.github.io/docs/spot/#t-getactive)  
<p>

```C#  
Task<WebCallResult<BybitSpotOrder>> GetOrderAsync([Optional] long? orderId, [Optional] string? clientOrderId, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`orderId`|The id of the order|
|`clientOrderId`|The client order id|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get order, either orderId or clientOrderId should be provided*  

</p>

***

## GetOrdersAsync  

[https://bybit-exchange.github.io/docs/spot/#t-orderhistory](https://bybit-exchange.github.io/docs/spot/#t-orderhistory)  
<p>

```C#  
Task<WebCallResult<IEnumerable<BybitSpotOrder>>> GetOrdersAsync([Optional] string? symbol, [Optional] long? orderId, [Optional] int? limit, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|Filter by symbol|
|`orderId`|Filter by order id, will only return orders with an orderId smaller than this|
|`limit`|Max amount of results|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get orders*  

</p>

***

## GetUserTradesAsync  

[https://bybit-exchange.github.io/docs/spot/#t-tradehistory](https://bybit-exchange.github.io/docs/spot/#t-tradehistory)  
<p>

```C#  
Task<WebCallResult<IEnumerable<BybitSpotUserTrade>>> GetUserTradesAsync([Optional] string? symbol, [Optional] long? fromId, [Optional] long? toId, [Optional] int? limit, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|Filter by symbol|
|`fromId`|Filter by start id|
|`toId`|Filter by end id|
|`limit`|Max amount of results|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get user trade history*  

</p>

***

## PlaceOrderAsync  

[https://bybit-exchange.github.io/docs/spot/#t-placeactive](https://bybit-exchange.github.io/docs/spot/#t-placeactive)  
<p>

```C#  
Task<WebCallResult<BybitSpotOrderPlaced>> PlaceOrderAsync(string symbol, OrderSide side, OrderType type, decimal quantity, [Optional] decimal? price, [Optional] TimeInForce? timeInForce, [Optional] string? clientOrderId, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`side`|Order side|
|`type`|Order type|
|`quantity`|Quantity of the order. Note that for market buy orders this is the quantity of quote asset, otherwise it's in base asset|
|`price`|Price|
|`timeInForce`|Time in force|
|`clientOrderId`|Client order id|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Place a new order*  

</p>
