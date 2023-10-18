---
title: IBybitSocketClientInversePerpetualApi
has_children: true
parent: Socket API documentation
---
*[generated documentation]*  
`BybitSocketClient > InversePerpetualApi`  
*[DEPRECATED, WILL STOP WORKING ON 16/30 OCTOBER, USE V5 API INSTEAD] Bybit inverse perpetual streams*
  

***

## SubscribeToBalanceUpdatesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketwallet](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketwallet)  
<p>

*Subscribe to user balance updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.InversePerpetualApi.SubscribeToBalanceUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(Action<DataEvent<IEnumerable<BybitBalanceUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToInsurancesUpdatesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketinsurance](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketinsurance)  
<p>

*Subscribe to insurance fund updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.InversePerpetualApi.SubscribeToInsurancesUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToInsurancesUpdatesAsync(Action<DataEvent<IEnumerable<BybitInsuranceUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToInsuranceUpdatesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketinsurance](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketinsurance)  
<p>

*Subscribe to insurance fund updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.InversePerpetualApi.SubscribeToInsuranceUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToInsuranceUpdatesAsync(string symbol, Action<DataEvent<IEnumerable<BybitInsuranceUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol to receive updates for|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToInsuranceUpdatesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketinsurance](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketinsurance)  
<p>

*Subscribe to insurance fund updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.InversePerpetualApi.SubscribeToInsuranceUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToInsuranceUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BybitInsuranceUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbols|The symbols to receive updates for|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToKlinesUpdatesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketklinev2](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketklinev2)  
<p>

*Subscribe to kline (candlestick) updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.InversePerpetualApi.SubscribeToKlinesUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToKlinesUpdatesAsync(KlineInterval interval, Action<DataEvent<IEnumerable<BybitKlineUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|interval|The interval of the klines|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToKlineUpdatesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketklinev2](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketklinev2)  
<p>

*Subscribe to kline (candlestick) updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.InversePerpetualApi.SubscribeToKlineUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, KlineInterval interval, Action<DataEvent<IEnumerable<BybitKlineUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol to receive updates for|
|interval|The interval of the klines|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToKlineUpdatesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketklinev2](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketklinev2)  
<p>

*Subscribe to kline (candlestick) updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.InversePerpetualApi.SubscribeToKlineUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(IEnumerable<string> symbols, KlineInterval interval, Action<DataEvent<IEnumerable<BybitKlineUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbols|The symbols to receive updates for|
|interval|The interval of the klines|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToLiquidationsUpdatesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketliquidation](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketliquidation)  
<p>

*Subscribe to liquidation order updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.InversePerpetualApi.SubscribeToLiquidationsUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToLiquidationsUpdatesAsync(Action<DataEvent<BybitLiquidationUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToLiquidationUpdatesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketliquidation](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketliquidation)  
<p>

*Subscribe to liquidation order updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.InversePerpetualApi.SubscribeToLiquidationUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(string symbol, Action<DataEvent<BybitLiquidationUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol to receive updates for|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToLiquidationUpdatesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketliquidation](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketliquidation)  
<p>

*Subscribe to liquidation order updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.InversePerpetualApi.SubscribeToLiquidationUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitLiquidationUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbols|The symbols to receive updates for|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToOrderBooksUpdatesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketorderbook25](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketorderbook25)  
[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketorderbook200](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketorderbook200)  
<p>

*Subscribe to orderbook updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.InversePerpetualApi.SubscribeToOrderBooksUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToOrderBooksUpdatesAsync(int limit, Action<DataEvent<IEnumerable<BybitOrderBookEntry>>> snapshotHandler, Action<DataEvent<BybitDeltaUpdate<BybitOrderBookEntry>>> updateHandler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|limit|The amount of rows to receive updates for. Either 25 or 200.|
|snapshotHandler|The event handler for the initial snapshot data|
|updateHandler|The event handler for the update messages|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToOrderBookUpdatesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketorderbook25](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketorderbook25)  
[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketorderbook200](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketorderbook200)  
<p>

*Subscribe to orderbook updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.InversePerpetualApi.SubscribeToOrderBookUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, int limit, Action<DataEvent<IEnumerable<BybitOrderBookEntry>>> snapshotHandler, Action<DataEvent<BybitDeltaUpdate<BybitOrderBookEntry>>> updateHandler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol to receive updates for|
|limit|The amount of rows to receive updates for. Either 25 or 200.|
|snapshotHandler|The event handler for the initial snapshot data|
|updateHandler|The event handler for the update messages|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToOrderBookUpdatesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketorderbook25](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketorderbook25)  
[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketorderbook200](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketorderbook200)  
<p>

*Subscribe to orderbook updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.InversePerpetualApi.SubscribeToOrderBookUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(IEnumerable<string> symbols, int limit, Action<DataEvent<IEnumerable<BybitOrderBookEntry>>> snapshotHandler, Action<DataEvent<BybitDeltaUpdate<BybitOrderBookEntry>>> updateHandler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbols|The symbols to receive updates for|
|limit|The amount of rows to receive updates for. Either 25 or 200.|
|snapshotHandler|The event handler for the initial snapshot data|
|updateHandler|The event handler for the update messages|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToOrderUpdatesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketorder](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketorder)  
<p>

*Subscribe to user order updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.InversePerpetualApi.SubscribeToOrderUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<IEnumerable<BybitInverseOrderUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToPositionUpdatesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketposition](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketposition)  
<p>

*Subscribe to user position updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.InversePerpetualApi.SubscribeToPositionUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(Action<DataEvent<IEnumerable<BybitPositionUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToStopOrderUpdatesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketstoporder](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketstoporder)  
<p>

*Subscribe to user stop order updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.InversePerpetualApi.SubscribeToStopOrderUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToStopOrderUpdatesAsync(Action<DataEvent<IEnumerable<BybitStopOrderUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToTickersUpdatesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketinstrumentinfo](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketinstrumentinfo)  
<p>

*Subscribe to ticker updates. Note that for a symbol the first update is a snapshot, containing all info. After that only partial updates are given for*  
*properties which have changed. If a property in the update is `null` it isn't changed and should be ignored.*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.InversePerpetualApi.SubscribeToTickersUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTickersUpdatesAsync(Action<DataEvent<BybitTickerUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToTickerUpdatesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketinstrumentinfo](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketinstrumentinfo)  
<p>

*Subscribe to ticker updates. Note that for a symbol the first update is a snapshot, containing all info. After that only partial updates are given for*  
*properties which have changed. If a property in the update is `null` it isn't changed and should be ignored.*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.InversePerpetualApi.SubscribeToTickerUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BybitTickerUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol to receive updates for|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToTickerUpdatesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketinstrumentinfo](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketinstrumentinfo)  
<p>

*Subscribe to ticker updates. Note that for a symbol the first update is a snapshot, containing all info. After that only partial updates are given for*  
*properties which have changed. If a property in the update is `null` it isn't changed and should be ignored.*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.InversePerpetualApi.SubscribeToTickerUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitTickerUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbols|The symbols to receive updates for|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToTradesUpdatesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websockettrade](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websockettrade)  
<p>

*Subscribe to public trade updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.InversePerpetualApi.SubscribeToTradesUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTradesUpdatesAsync(Action<DataEvent<IEnumerable<BybitTradeUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToTradeUpdatesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websockettrade](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websockettrade)  
<p>

*Subscribe to public trade updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.InversePerpetualApi.SubscribeToTradeUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<IEnumerable<BybitTradeUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol to receive updates for|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToTradeUpdatesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websockettrade](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websockettrade)  
<p>

*Subscribe to public trade updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.InversePerpetualApi.SubscribeToTradeUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BybitTradeUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbols|The symbols to receive updates for|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToUserTradeUpdatesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketexecution](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-websocketexecution)  
<p>

*Subscribe to user trade updates*  

```csharp  
var client = new BybitSocketClient();  
var result = await client.InversePerpetualApi.SubscribeToUserTradeUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(Action<DataEvent<IEnumerable<BybitUserTradeUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|The event handler for the received data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>
