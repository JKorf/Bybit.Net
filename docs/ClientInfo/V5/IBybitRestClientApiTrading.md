---
title: IBybitRestClientApiTrading
has_children: false
parent: IBybitRestClientV5
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BybitRestClient > V5 > ApiTrading`  
*Bybit trading endpoints, placing and managing orders.*
  

***

## CancelAllOrderAsync  

[https://bybit-exchange.github.io/docs/v5/order/cancel-all](https://bybit-exchange.github.io/docs/v5/order/cancel-all)  
<p>

*Cancel all orders*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiTrading.CancelAllOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitOrderId>>> CancelAllOrderAsync(Category category, string? symbol = default, string? baseAsset = default, string? settleAsset = default, OrderFilter? orderFilter = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|_[Optional]_ symbol|Filter by symbol|
|_[Optional]_ baseAsset|Filter by base asset|
|_[Optional]_ settleAsset|Filter by settle asset|
|_[Optional]_ orderFilter|Order filter|
|_[Optional]_ ct|Cancellation token|

</p>

***

## CancelMultipleOrdersAsync  

[]()  
<p>

**  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiTrading.CancelMultipleOrdersAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitBatchResult<BybitBatchOrderId>>>> CancelMultipleOrdersAsync(Category category, IEnumerable<BybitCancelOrderRequest> orderRequests, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category||
|orderRequests||
|_[Optional]_ ct||

</p>

***

## CancelOrderAsync  

[https://bybit-exchange.github.io/docs/v5/order/cancel-order](https://bybit-exchange.github.io/docs/v5/order/cancel-order)  
<p>

*Cancel order*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiTrading.CancelOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitOrderId>> CancelOrderAsync(Category category, string symbol, string? orderId = default, string? clientOrderId = default, OrderFilter? orderFilter = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|symbol|Symbol|
|_[Optional]_ orderId|Cancel by order id|
|_[Optional]_ clientOrderId|Cancel by client order id|
|_[Optional]_ orderFilter|Order filter|
|_[Optional]_ ct|Cancellation token|

</p>

***

## EditMultipleOrdersAsync  

[]()  
<p>

**  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiTrading.EditMultipleOrdersAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitBatchResult<BybitBatchOrderId>>>> EditMultipleOrdersAsync(Category category, IEnumerable<BybitEditOrderRequest> orderRequests, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category||
|orderRequests||
|_[Optional]_ ct||

</p>

***

## EditOrderAsync  

[https://bybit-exchange.github.io/docs/v5/order/amend-order](https://bybit-exchange.github.io/docs/v5/order/amend-order)  
<p>

*Edit an order*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiTrading.EditOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitOrderId>> EditOrderAsync(Category category, string symbol, string? orderId = default, string? clientOrderId = default, decimal? quantity = default, decimal? price = default, decimal? triggerPrice = default, TriggerType? triggerBy = default, decimal? orderIv = default, decimal? takeProfit = default, decimal? stopLoss = default, TriggerType? takeProfitTriggerBy = default, TriggerType? stopLossTriggerBy = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|symbol|Symbol|
|_[Optional]_ orderId|Order id of the order to edit|
|_[Optional]_ clientOrderId|Client order id of the order to edit|
|_[Optional]_ quantity|New quantity|
|_[Optional]_ price|New price|
|_[Optional]_ triggerPrice|New trigger price|
|_[Optional]_ triggerBy|New trigger |
|_[Optional]_ orderIv|New order Iv|
|_[Optional]_ takeProfit|New take profit price|
|_[Optional]_ stopLoss|New stop loss price|
|_[Optional]_ takeProfitTriggerBy|New take profit trigger|
|_[Optional]_ stopLossTriggerBy|New stop profit trigger|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetAssetExchangeHistoryAsync  

[https://bybit-exchange.github.io/docs/v5/asset/exchange](https://bybit-exchange.github.io/docs/v5/asset/exchange)  
<p>

*Get asset exchange history*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiTrading.GetAssetExchangeHistoryAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitAssetExchange>>> GetAssetExchangeHistoryAsync(string? fromAsset = default, string? toAsset = default, int? limit = default, string? cursor = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ fromAsset|Filter by from asset|
|_[Optional]_ toAsset|Filter by to asset|
|_[Optional]_ limit|Number of results per page|
|_[Optional]_ cursor|Pagination cursor|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetBorrowQuotaAsync  

[https://bybit-exchange.github.io/docs/v5/order/spot-borrow-quota](https://bybit-exchange.github.io/docs/v5/order/spot-borrow-quota)  
<p>

*Get spot borrow quota*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiTrading.GetBorrowQuotaAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitBorrowQuota>> GetBorrowQuotaAsync(Category category, string symbol, OrderSide side, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|symbol|Symbol|
|side|Side|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetClosedProfitLossAsync  

[https://bybit-exchange.github.io/docs/v5/position/close-pnl](https://bybit-exchange.github.io/docs/v5/position/close-pnl)  
<p>

*Get closed profit and loss*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiTrading.GetClosedProfitLossAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitClosedPnl>>> GetClosedProfitLossAsync(Category category, string? symbol = default, DateTime? startTime = default, DateTime? endTime = default, int? limit = default, string? cursor = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|_[Optional]_ symbol|Filter by symbol|
|_[Optional]_ startTime|Filter by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ limit|Number of results per page|
|_[Optional]_ cursor|Pagination cursor|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetDeliveryHistoryAsync  

[https://bybit-exchange.github.io/docs/v5/asset/delivery](https://bybit-exchange.github.io/docs/v5/asset/delivery)  
<p>

*Get delivery history*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiTrading.GetDeliveryHistoryAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitDeliveryRecord>>> GetDeliveryHistoryAsync(Category category, string? symbol = default, DateTime? expiryDate = default, int? limit = default, string? cursor = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|_[Optional]_ symbol|Filter by symbol|
|_[Optional]_ expiryDate|Filter by expiry date|
|_[Optional]_ limit|Number of results per page|
|_[Optional]_ cursor|Pagination cursor|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOrderHistoryAsync  

[https://bybit-exchange.github.io/docs/v5/order/order-list](https://bybit-exchange.github.io/docs/v5/order/order-list)  
<p>

*Get order history*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiTrading.GetOrderHistoryAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitOrder>>> GetOrderHistoryAsync(Category category, string? symbol = default, string? baseAsset = default, string? orderId = default, string? clientOrderId = default, Enums.V5.OrderStatus? status = default, OrderFilter? orderFilter = default, DateTime? startTime = default, DateTime? endTime = default, int? limit = default, string? cursor = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|_[Optional]_ symbol|Filter by symbol|
|_[Optional]_ baseAsset|Filter by base asset|
|_[Optional]_ orderId|Filter by order id|
|_[Optional]_ clientOrderId|Filter by client order id|
|_[Optional]_ status|Filter by status|
|_[Optional]_ orderFilter|Order filter|
|_[Optional]_ startTime|Filter by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ limit|Number of results per page|
|_[Optional]_ cursor|Pagination cursor|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOrdersAsync  

[https://bybit-exchange.github.io/docs/v5/order/open-order](https://bybit-exchange.github.io/docs/v5/order/open-order)  
<p>

*Get real-time open orders*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiTrading.GetOrdersAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitOrder>>> GetOrdersAsync(Category category, string? symbol = default, string? baseAsset = default, string? settleAsset = default, string? orderId = default, string? clientOrderId = default, int? openOnly = default, OrderFilter? orderFilter = default, int? limit = default, string? cursor = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|_[Optional]_ symbol|Filter by symbol|
|_[Optional]_ baseAsset|Filter by base asset|
|_[Optional]_ settleAsset|Filter by settle asset|
|_[Optional]_ orderId|Filter by order id|
|_[Optional]_ clientOrderId|Filter by client order id|
|_[Optional]_ openOnly|Open only|
|_[Optional]_ orderFilter|Order filter|
|_[Optional]_ limit|Number of results per page|
|_[Optional]_ cursor|Pagination cursor|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetPositionsAsync  

[https://bybit-exchange.github.io/docs/v5/position](https://bybit-exchange.github.io/docs/v5/position)  
<p>

*Get positions*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiTrading.GetPositionsAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitPosition>>> GetPositionsAsync(Category category, string? symbol = default, string? baseAsset = default, string? settleAsset = default, int? limit = default, string? cursor = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|_[Optional]_ symbol|Filter by symbol|
|_[Optional]_ baseAsset|Filter by base asset|
|_[Optional]_ settleAsset|Filter by settle asset|
|_[Optional]_ limit|Number of results per page|
|_[Optional]_ cursor|Pagination cursor|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetSettlementHistoryAsync  

[https://bybit-exchange.github.io/docs/v5/asset/settlement](https://bybit-exchange.github.io/docs/v5/asset/settlement)  
<p>

*Get settlement history*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiTrading.GetSettlementHistoryAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitSettlementRecord>>> GetSettlementHistoryAsync(Category category, string? symbol = default, int? limit = default, string? cursor = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|_[Optional]_ symbol|Filter by symbol|
|_[Optional]_ limit|Number of results per page|
|_[Optional]_ cursor|Pagination cursor|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetUserTradesAsync  

[https://bybit-exchange.github.io/docs/v5/position/execution](https://bybit-exchange.github.io/docs/v5/position/execution)  
<p>

*Get user trade history*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiTrading.GetUserTradesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitUserTrade>>> GetUserTradesAsync(Category category, string? symbol = default, string? baseAsset = default, string? orderId = default, string? clientOrderId = default, DateTime? startTime = default, DateTime? endTime = default, TradeType? tradeType = default, int? limit = default, string? cursor = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|_[Optional]_ symbol|Filter by symbol|
|_[Optional]_ baseAsset|Filter by base asset|
|_[Optional]_ orderId|Filter by order id|
|_[Optional]_ clientOrderId|Filter by client order id|
|_[Optional]_ startTime|Filter by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ tradeType|Filter by trade type|
|_[Optional]_ limit|Number of results per page|
|_[Optional]_ cursor|Pagination cursor|
|_[Optional]_ ct|Cancellation token|

</p>

***

## PlaceMultipleOrdersAsync  

[]()  
<p>

**  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiTrading.PlaceMultipleOrdersAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitBatchResult<BybitBatchOrderId>>>> PlaceMultipleOrdersAsync(Category category, IEnumerable<BybitPlaceOrderRequest> orderRequests, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category||
|orderRequests||
|_[Optional]_ ct||

</p>

***

## PlaceOrderAsync  

[https://bybit-exchange.github.io/docs/v5/order/create-order](https://bybit-exchange.github.io/docs/v5/order/create-order)  
<p>

*Place an order*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiTrading.PlaceOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitOrderId>> PlaceOrderAsync(Category category, string symbol, OrderSide side, NewOrderType type, decimal quantity, decimal? price = default, bool? isLeverage = default, TriggerDirection? triggerDirection = default, OrderFilter? orderFilter = default, decimal? triggerPrice = default, TriggerType? triggerBy = default, decimal? orderIv = default, TimeInForce? timeInForce = default, PositionIdx? positionIdx = default, string? clientOrderId = default, OrderType? takeProfitOrderType = default, decimal? takeProfit = default, decimal? takeProfitLimitPrice = default, OrderType? stopLossOrderType = default, decimal? stopLoss = default, decimal? stopLossLimitPrice = default, TriggerType? takeProfitTriggerBy = default, TriggerType? stopLossTriggerBy = default, bool? reduceOnly = default, bool? closeOnTrigger = default, bool? marketMakerProtection = default, StopLossTakeProfitMode? stopLossTakeProfitMode = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|symbol|Symbol|
|side|Order side|
|type|Order type|
|quantity|Quantity|
|_[Optional]_ price|Price|
|_[Optional]_ isLeverage|Is leverage|
|_[Optional]_ triggerDirection|Conditional order diraction|
|_[Optional]_ orderFilter|Order filter|
|_[Optional]_ triggerPrice|Trigger price|
|_[Optional]_ triggerBy|Trigger by|
|_[Optional]_ orderIv|Order implied volatility|
|_[Optional]_ timeInForce|Time in force|
|_[Optional]_ positionIdx|Position idx|
|_[Optional]_ clientOrderId|Client order id|
|_[Optional]_ takeProfitOrderType||
|_[Optional]_ takeProfit|Take profit price|
|_[Optional]_ takeProfitLimitPrice||
|_[Optional]_ stopLossOrderType||
|_[Optional]_ stopLoss|Stop loss price|
|_[Optional]_ stopLossLimitPrice||
|_[Optional]_ takeProfitTriggerBy|Take profit trigger|
|_[Optional]_ stopLossTriggerBy|Stop loss trigger|
|_[Optional]_ reduceOnly|Is reduce only|
|_[Optional]_ closeOnTrigger|Close on trigger|
|_[Optional]_ marketMakerProtection|Market maker protection|
|_[Optional]_ stopLossTakeProfitMode|StopLoss / TakeProfit mode|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetDisconnectCancelAllAsync  

[https://bybit-exchange.github.io/docs/v5/order/dcp](https://bybit-exchange.github.io/docs/v5/order/dcp)  
<p>

*Set cancel all timeout on websocket disconnect*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiTrading.SetDisconnectCancelAllAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitBorrowQuota>> SetDisconnectCancelAllAsync(int windowSeconds, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|windowSeconds|Time after which to cancel all orders|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetTradingStopAsync  

[https://bybit-exchange.github.io/docs/v5/position/trading-stop](https://bybit-exchange.github.io/docs/v5/position/trading-stop)  
<p>

*Set trading stop parameters*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiTrading.SetTradingStopAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> SetTradingStopAsync(Category category, string symbol, PositionIdx positionIdx, decimal? takeProfit = default, decimal? stopLoss = default, decimal? trailingStop = default, TriggerType? takeProfitTrigger = default, TriggerType? stopLossTrigger = default, decimal? activePrice = default, decimal? takeProfitQuantity = default, decimal? stopLossQuantity = default, StopLossTakeProfitMode? stopLossTakeProfitMode = default, decimal? takeProfitLimitPrice = default, decimal? stopLossLimitPrice = default, OrderType? takeProfitOrderType = default, OrderType? stopLossOrderType = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|symbol|Symbol|
|positionIdx|Position idx|
|_[Optional]_ takeProfit|Take profit price|
|_[Optional]_ stopLoss|Stop loss price|
|_[Optional]_ trailingStop|Trailing stop|
|_[Optional]_ takeProfitTrigger|Take profit trigger|
|_[Optional]_ stopLossTrigger|Stop loss trigger|
|_[Optional]_ activePrice|Active price|
|_[Optional]_ takeProfitQuantity|Take profit quantity|
|_[Optional]_ stopLossQuantity|Stop loss quantity|
|_[Optional]_ stopLossTakeProfitMode|StopLoss/TakeProfit mode|
|_[Optional]_ takeProfitLimitPrice|Take profit order limit price|
|_[Optional]_ stopLossLimitPrice|Stop loss order price|
|_[Optional]_ takeProfitOrderType|Take profit order type|
|_[Optional]_ stopLossOrderType|Stop loss order type|
|_[Optional]_ ct|Cancellation token|

</p>
