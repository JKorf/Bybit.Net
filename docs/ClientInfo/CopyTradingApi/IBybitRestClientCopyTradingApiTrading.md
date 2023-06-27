---
title: IBybitRestClientCopyTradingApiTrading
has_children: false
parent: IBybitRestClientCopyTradingApi
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BybitRestClient > CopyTradingApi > Trading`  
*Bybit trading endpoints, placing and managing positions.*
  

***

## CancelOrderAsync  

[https://bybit-exchange.github.io/docs/copy_trading/#t-ct_cancel_order](https://bybit-exchange.github.io/docs/copy_trading/#t-ct_cancel_order)  
<p>

*Cancel an active order*  

```csharp  
var client = new BybitRestClient();  
var result = await client.CopyTradingApi.Trading.CancelOrderAsync();  
```  

```csharp  
Task<WebCallResult<BybitCopyTradingId>> CancelOrderAsync(string? orderId = default, string? clientOrderId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ orderId|Cancel by order id|
|_[Optional]_ clientOrderId|Cancel by client order id|
|_[Optional]_ ct|Cancellation token|

</p>

***

## CloseOrderAsync  

[https://bybit-exchange.github.io/docs/copy_trading/#t-ct_close_order](https://bybit-exchange.github.io/docs/copy_trading/#t-ct_close_order)  
<p>

*Close an order*  

```csharp  
var client = new BybitRestClient();  
var result = await client.CopyTradingApi.Trading.CloseOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitCopyTradingId>> CloseOrderAsync(string symbol, string? clientOrderId = default, string? parentOrderId = default, string? parentClientOrderId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|_[Optional]_ clientOrderId|Client order id|
|_[Optional]_ parentOrderId|Required if not passing parentClientOrderId|
|_[Optional]_ parentClientOrderId|Required if not passing parentOrderId|
|_[Optional]_ ct|Cancellation token|

</p>

***

## ClosePositionAsync  

[https://bybit-exchange.github.io/docs/copy_trading/#t-ct_positon_close](https://bybit-exchange.github.io/docs/copy_trading/#t-ct_positon_close)  
<p>

*Close a position*  

```csharp  
var client = new BybitRestClient();  
var result = await client.CopyTradingApi.Trading.ClosePositionAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> ClosePositionAsync(string symbol, PositionMode positionMode, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|positionMode|Position mode|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOrdersAsync  

[https://bybit-exchange.github.io/docs/copy_trading/#t-ct_order_list](https://bybit-exchange.github.io/docs/copy_trading/#t-ct_order_list)  
<p>

*Get orders*  

```csharp  
var client = new BybitRestClient();  
var result = await client.CopyTradingApi.Trading.GetOrdersAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitCopyTradingOrder>>> GetOrdersAsync(string? symbol = default, string? orderId = default, string? clientOrderId = default, string? copyTradeOrderType = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ symbol|Filter by symbol|
|_[Optional]_ orderId|Filter by order id|
|_[Optional]_ clientOrderId|Filter by client order id|
|_[Optional]_ copyTradeOrderType|Filter by copy order type|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetPositionsAsync  

[https://bybit-exchange.github.io/docs/copy_trading/#t-ct_wallet_transfer](https://bybit-exchange.github.io/docs/copy_trading/#t-ct_wallet_transfer)  
<p>

*Get your positions*  

```csharp  
var client = new BybitRestClient();  
var result = await client.CopyTradingApi.Trading.GetPositionsAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitCopyTradingPosition>>> GetPositionsAsync(string? symbol = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ symbol|Filter by symbol|
|_[Optional]_ ct|Cancellation token|

</p>

***

## PlaceOrderAsync  

[https://bybit-exchange.github.io/docs/copy_trading/#t-ct_create_order](https://bybit-exchange.github.io/docs/copy_trading/#t-ct_create_order)  
<p>

*Place an order*  

```csharp  
var client = new BybitRestClient();  
var result = await client.CopyTradingApi.Trading.PlaceOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitCopyTradingId>> PlaceOrderAsync(string symbol, OrderSide side, OrderType type, decimal quantity, decimal? price = default, decimal? takeProfitPrice = default, decimal? stopLossPrice = default, TriggerType? takeProfitTriggerType = default, TriggerType? stopLossTriggerType = default, string? clientOrderId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|side|Order side|
|type|Order type|
|quantity|Quantity|
|_[Optional]_ price|Price|
|_[Optional]_ takeProfitPrice|Take profit price|
|_[Optional]_ stopLossPrice|Stop loss price|
|_[Optional]_ takeProfitTriggerType|Type of take-profit activation price|
|_[Optional]_ stopLossTriggerType|Type of stop-loss activation price|
|_[Optional]_ clientOrderId|Optional user defined id|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetLeverageAsync  

[https://bybit-exchange.github.io/docs/copy_trading/#t-ct_set_leverage](https://bybit-exchange.github.io/docs/copy_trading/#t-ct_set_leverage)  
<p>

*Set leverage*  

```csharp  
var client = new BybitRestClient();  
var result = await client.CopyTradingApi.Trading.SetLeverageAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> SetLeverageAsync(string symbol, decimal buyLeverage, decimal sellLeverage, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|buyLeverage|Buy leverage|
|sellLeverage|Sell leverage|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetTradingStopAsync  

[https://bybit-exchange.github.io/docs/copy-trade/trade/trading-stop](https://bybit-exchange.github.io/docs/copy-trade/trade/trading-stop)  
<p>

*Set trading stop parameters for an existing order*  

```csharp  
var client = new BybitRestClient();  
var result = await client.CopyTradingApi.Trading.SetTradingStopAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> SetTradingStopAsync(string symbol, string parentOrderId, decimal? takeProfitPrice = default, decimal? stopLossPrice = default, TriggerType? takeProfitTriggerType = default, TriggerType? stopLossTriggerType = default, string? parentClientOrderId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|parentOrderId|The parent order id|
|_[Optional]_ takeProfitPrice|New take profit price|
|_[Optional]_ stopLossPrice|New stop loss price|
|_[Optional]_ takeProfitTriggerType|New take profit trigger type|
|_[Optional]_ stopLossTriggerType|New stop loss trigger type|
|_[Optional]_ parentClientOrderId|Parent client order id|
|_[Optional]_ ct|Cancellation token|

</p>
