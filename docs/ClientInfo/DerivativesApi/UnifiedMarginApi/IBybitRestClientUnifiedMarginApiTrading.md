---
title: IBybitRestClientUnifiedMarginApiTrading
has_children: false
parent: IBybitRestClientDerivativesApi\UnifiedMarginApi
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BybitRestClient > DerivativesApi\UnifiedMarginApi > UnifiedMarginApiTrading`  
*Bybit trading endpoints, placing and managing orders.*
  

***

## CancelAllOrdersAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_cancelallorders](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_cancelallorders)  
<p>

*Cancel all active orders for a symbol*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\UnifiedMarginApi.UnifiedMarginApiTrading.CancelAllOrdersAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitUnifiedMarginCancelledOrder>>> CancelAllOrdersAsync(Category category, string? baseAsset = default, string? settleAsset = default, string? symbol = default, OrderFilter? orderFilter = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Type of derivatives product: linear or option|
|_[Optional]_ baseAsset|Base Coin|
|_[Optional]_ settleAsset|Settle Coin. It's invalid for option|
|_[Optional]_ symbol|The symbol|
|_[Optional]_ orderFilter|Conditional order or active order|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## CancelOrderAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_cancelorder](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_cancelorder)  
<p>

*Cancel an order, either orderId or clientOrderId should be provided*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\UnifiedMarginApi.UnifiedMarginApiTrading.CancelOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitDerivativesOrderId>> CancelOrderAsync(Category category, string symbol, string? orderId = default, string? clientOrderId = default, OrderFilter? orderFilter = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Type of derivatives product: linear or option|
|symbol|The symbol|
|_[Optional]_ orderId|The id of the order to cancel|
|_[Optional]_ clientOrderId|The client order id of the conditional order to cancel|
|_[Optional]_ orderFilter|Conditional order or active order|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOpenOrdersRealTimeAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_queryorderrealtime](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_queryorderrealtime)  
<p>

*Get orders*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\UnifiedMarginApi.UnifiedMarginApiTrading.GetOpenOrdersRealTimeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitDerivativesCursorPage<IEnumerable<BybitUnifiedMarginOrder>>>> GetOpenOrdersRealTimeAsync(Category category, string? symbol = default, string? baseAsset = default, string? orderId = default, string? clientOrderId = default, OrderFilter? orderFilter = default, SearchDirection? direction = default, int? limit = default, string? cursor = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category||
|_[Optional]_ symbol|The symbol|
|_[Optional]_ baseAsset|Base coin. When category=option. If not passed, BTC by default.|
|_[Optional]_ orderId|Filter by order id|
|_[Optional]_ clientOrderId|Filter by client order id|
|_[Optional]_ orderFilter|Conditional order or active order|
|_[Optional]_ direction|Search direction|
|_[Optional]_ limit|Data quantity per page: Max data value per page is 50, and default value at 20|
|_[Optional]_ cursor|API pass-through|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOrdersAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_getorder](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_getorder)  
<p>

*Get orders*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\UnifiedMarginApi.UnifiedMarginApiTrading.GetOrdersAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitDerivativesCursorPage<IEnumerable<BybitUnifiedMarginOrder>>>> GetOrdersAsync(Category category, string? symbol = default, string? baseAsset = default, string? orderId = default, string? clientOrderId = default, OrderStatus? status = default, OrderFilter? orderFilter = default, SearchDirection? direction = default, int? limit = default, string? cursor = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category||
|_[Optional]_ symbol|The symbol|
|_[Optional]_ baseAsset||
|_[Optional]_ orderId|Filter by order id|
|_[Optional]_ clientOrderId|Filter by client order id|
|_[Optional]_ status|Filter by status|
|_[Optional]_ orderFilter|Conditional order or active order|
|_[Optional]_ direction|Search direction|
|_[Optional]_ limit|Data quantity per page: Max data value per page is 50, and default value at 20|
|_[Optional]_ cursor|API pass-through|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## PlaceOrderAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_placeorder](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_placeorder)  
<p>

*Place a new order*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\UnifiedMarginApi.UnifiedMarginApiTrading.PlaceOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitDerivativesOrderId>> PlaceOrderAsync(Category category, string symbol, OrderSide side, OrderType type, decimal quantity, TimeInForce timeInForce, decimal? price = default, decimal? basePrice = default, decimal? triggerPrice = default, PositionMode? positionMode = default, TriggerType? triggerType = default, decimal? iv = default, string? clientOrderId = default, decimal? takeProfitPrice = default, decimal? stopLossPrice = default, TriggerType? takeProfitTriggerType = default, TriggerType? stopLossTriggerType = default, bool? reduceOnly = default, bool? closeOnTrigger = default, bool? marketMakerProtection = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Type of derivatives product: linear or option.|
|symbol|The symbol|
|side|Order side|
|type|Order type|
|quantity|Quantity|
|timeInForce|Time in force|
|_[Optional]_ price|c|
|_[Optional]_ basePrice|It will be used to compare with the value of triggerPrice, to decide whether your conditional order will be triggered by crossing trigger price from upper side or lower side. Mainly used to identify the expected direction of the current conditional order.|
|_[Optional]_ triggerPrice|Trigger price. If you're expecting the price to rise to trigger your conditional order, make sure triggerPrice more max(market price, basePrice) else, triggerPrice less min (market price, basePrice)|
|_[Optional]_ positionMode|Position mode|
|_[Optional]_ triggerType|Trigger price type: Market price/Mark price|
|_[Optional]_ iv|Implied volatility, for options only; parameters are passed according to the real value; for example, for 10%, 0.1 is passed|
|_[Optional]_ clientOrderId|Client order id|
|_[Optional]_ takeProfitPrice|Take profit price, only take effect upon opening the position|
|_[Optional]_ stopLossPrice|Stop loss price, only take effect upon opening the position|
|_[Optional]_ takeProfitTriggerType|Take profit trigger price type, default: LastPrice|
|_[Optional]_ stopLossTriggerType|Stop loss trigger price type, default: LastPrice|
|_[Optional]_ reduceOnly|True means your position can only reduce in size if this order is triggered|
|_[Optional]_ closeOnTrigger|For a closing order. It can only reduce your position, not increase it. If the account has insufficient available balance when the closing order is triggered, then other active orders of similar contracts will be cancelled or reduced. It can be used to ensure your stop loss reduces your position regardless of current available margin.|
|_[Optional]_ marketMakerProtection|Market maker protection, "true" means this order is a market maker protection order.|
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
var result = await client.DerivativesApi\UnifiedMarginApi.UnifiedMarginApiTrading.ReplaceOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitDerivativesOrderId>> ReplaceOrderAsync(Category category, string symbol, string? orderId = default, string? clientOrderId = default, OrderFilter? orderFilter = default, decimal? iv = default, decimal? triggerPrice = default, decimal? quantity = default, decimal? price = default, decimal? takeProfitPrice = default, decimal? stopLossPrice = default, TriggerType? takeProfitTriggerType = default, TriggerType? stopLossTriggerType = default, TriggerType? triggerType = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Type of derivatives product: linear or option.|
|symbol|The symbol|
|_[Optional]_ orderId|Order ID. Required if not passing orderLinkId|
|_[Optional]_ clientOrderId|Client order id|
|_[Optional]_ orderFilter|Conditional order or active order|
|_[Optional]_ iv|Implied volatility, for options only; parameters are passed according to the real value; for example, for 10%, 0.1 is passed|
|_[Optional]_ triggerPrice|Trigger price|
|_[Optional]_ quantity|Quantity|
|_[Optional]_ price|Quantity|
|_[Optional]_ takeProfitPrice|Take profit price, only take effect upon opening the position|
|_[Optional]_ stopLossPrice|Stop loss price, only take effect upon opening the position|
|_[Optional]_ takeProfitTriggerType|Take profit trigger price type, default: LastPrice|
|_[Optional]_ stopLossTriggerType|Stop loss trigger price type, default: LastPrice>|
|_[Optional]_ triggerType|Trigger price type: Market price/Mark price|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>
