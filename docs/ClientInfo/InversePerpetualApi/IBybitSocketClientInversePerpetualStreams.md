---
title: IBybitSocketClientInversePerpetualStreams
has_children: true
parent: IBybitSocketClient
---
*[generated documentation]*  
`BybitSocketClient > InversePerpetualStreams`  
*Bybit inverse perpetual streams*
  

***

## SubscribeToBalanceUpdatesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-websocketwallet](https://bybit-exchange.github.io/docs/inverse/#t-websocketwallet)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualStreams.SubscribeToBalanceUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(Action<DataEvent<IEnumerable<BybitBalanceUpdate>>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`handler`|The event handler for the received data|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to user balance updates*  

</p>

***

## SubscribeToInsurancesUpdatesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-websocketinsurance](https://bybit-exchange.github.io/docs/inverse/#t-websocketinsurance)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualStreams.SubscribeToInsurancesUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToInsurancesUpdatesAsync(Action<DataEvent<IEnumerable<BybitInsuranceUpdate>>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`handler`|The event handler for the received data|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to insurance fund updates*  

</p>

***

## SubscribeToInsuranceUpdatesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-websocketinsurance](https://bybit-exchange.github.io/docs/inverse/#t-websocketinsurance)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualStreams.SubscribeToInsuranceUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToInsuranceUpdatesAsync(string symbol, Action<DataEvent<IEnumerable<BybitInsuranceUpdate>>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol to receive updates for|
|`handler`|The event handler for the received data|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to insurance fund updates*  

</p>

***

## SubscribeToInsuranceUpdatesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-websocketinsurance](https://bybit-exchange.github.io/docs/inverse/#t-websocketinsurance)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualStreams.SubscribeToInsuranceUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToInsuranceUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BybitInsuranceUpdate>>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbols`|The symbols to receive updates for|
|`handler`|The event handler for the received data|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to insurance fund updates*  

</p>

***

## SubscribeToKlinesUpdatesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-websocketklinev2](https://bybit-exchange.github.io/docs/inverse/#t-websocketklinev2)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualStreams.SubscribeToKlinesUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToKlinesUpdatesAsync(KlineInterval interval, Action<DataEvent<IEnumerable<BybitKlineUpdate>>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`interval`|The interval of the klines|
|`handler`|The event handler for the received data|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to kline (candlestick) updates*  

</p>

***

## SubscribeToKlineUpdatesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-websocketklinev2](https://bybit-exchange.github.io/docs/inverse/#t-websocketklinev2)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualStreams.SubscribeToKlineUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, KlineInterval interval, Action<DataEvent<IEnumerable<BybitKlineUpdate>>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol to receive updates for|
|`interval`|The interval of the klines|
|`handler`|The event handler for the received data|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to kline (candlestick) updates*  

</p>

***

## SubscribeToKlineUpdatesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-websocketklinev2](https://bybit-exchange.github.io/docs/inverse/#t-websocketklinev2)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualStreams.SubscribeToKlineUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(IEnumerable<string> symbols, KlineInterval interval, Action<DataEvent<IEnumerable<BybitKlineUpdate>>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbols`|The symbols to receive updates for|
|`interval`|The interval of the klines|
|`handler`|The event handler for the received data|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to kline (candlestick) updates*  

</p>

***

## SubscribeToLiquidationsUpdatesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-websocketliquidation](https://bybit-exchange.github.io/docs/inverse/#t-websocketliquidation)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualStreams.SubscribeToLiquidationsUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToLiquidationsUpdatesAsync(Action<DataEvent<BybitLiquidationUpdate>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`handler`|The event handler for the received data|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to liquidation order updates*  

</p>

***

## SubscribeToLiquidationUpdatesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-websocketliquidation](https://bybit-exchange.github.io/docs/inverse/#t-websocketliquidation)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualStreams.SubscribeToLiquidationUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(string symbol, Action<DataEvent<BybitLiquidationUpdate>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol to receive updates for|
|`handler`|The event handler for the received data|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to liquidation order updates*  

</p>

***

## SubscribeToLiquidationUpdatesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-websocketliquidation](https://bybit-exchange.github.io/docs/inverse/#t-websocketliquidation)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualStreams.SubscribeToLiquidationUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitLiquidationUpdate>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbols`|The symbols to receive updates for|
|`handler`|The event handler for the received data|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to liquidation order updates*  

</p>

***

## SubscribeToOrderBooksUpdatesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-websocketorderbook25](https://bybit-exchange.github.io/docs/inverse/#t-websocketorderbook25)  
[https://bybit-exchange.github.io/docs/inverse/#t-websocketorderbook200](https://bybit-exchange.github.io/docs/inverse/#t-websocketorderbook200)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualStreams.SubscribeToOrderBooksUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToOrderBooksUpdatesAsync(int limit, Action<DataEvent<IEnumerable<BybitOrderBookEntry>>> snapshotHandler, Action<DataEvent<BybitDeltaUpdate<BybitOrderBookEntry>>> updateHandler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`limit`|The amount of rows to receive updates for. Either 25 or 200.|
|`snapshotHandler`|The event handler for the initial snapshot data|
|`updateHandler`|The event handler for the update messages|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to orderbook updates*  

</p>

***

## SubscribeToOrderBookUpdatesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-websocketorderbook25](https://bybit-exchange.github.io/docs/inverse/#t-websocketorderbook25)  
[https://bybit-exchange.github.io/docs/inverse/#t-websocketorderbook200](https://bybit-exchange.github.io/docs/inverse/#t-websocketorderbook200)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualStreams.SubscribeToOrderBookUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, int limit, Action<DataEvent<IEnumerable<BybitOrderBookEntry>>> snapshotHandler, Action<DataEvent<BybitDeltaUpdate<BybitOrderBookEntry>>> updateHandler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol to receive updates for|
|`limit`|The amount of rows to receive updates for. Either 25 or 200.|
|`snapshotHandler`|The event handler for the initial snapshot data|
|`updateHandler`|The event handler for the update messages|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to orderbook updates*  

</p>

***

## SubscribeToOrderBookUpdatesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-websocketorderbook25](https://bybit-exchange.github.io/docs/inverse/#t-websocketorderbook25)  
[https://bybit-exchange.github.io/docs/inverse/#t-websocketorderbook200](https://bybit-exchange.github.io/docs/inverse/#t-websocketorderbook200)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualStreams.SubscribeToOrderBookUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(IEnumerable<string> symbols, int limit, Action<DataEvent<IEnumerable<BybitOrderBookEntry>>> snapshotHandler, Action<DataEvent<BybitDeltaUpdate<BybitOrderBookEntry>>> updateHandler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbols`|The symbols to receive updates for|
|`limit`|The amount of rows to receive updates for. Either 25 or 200.|
|`snapshotHandler`|The event handler for the initial snapshot data|
|`updateHandler`|The event handler for the update messages|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to orderbook updates*  

</p>

***

## SubscribeToOrderUpdatesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-websocketorder](https://bybit-exchange.github.io/docs/inverse/#t-websocketorder)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualStreams.SubscribeToOrderUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<IEnumerable<BybitOrderUpdate>>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`handler`|The event handler for the received data|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to user order updates*  

</p>

***

## SubscribeToPositionUpdatesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-websocketposition](https://bybit-exchange.github.io/docs/inverse/#t-websocketposition)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualStreams.SubscribeToPositionUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(Action<DataEvent<IEnumerable<BybitPositionUpdate>>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`handler`|The event handler for the received data|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to user position updates*  

</p>

***

## SubscribeToStopOrderUpdatesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-websocketstoporder](https://bybit-exchange.github.io/docs/inverse/#t-websocketstoporder)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualStreams.SubscribeToStopOrderUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToStopOrderUpdatesAsync(Action<DataEvent<IEnumerable<BybitStopOrderUpdate>>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`handler`|The event handler for the received data|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to user stop order updates*  

</p>

***

## SubscribeToTickersUpdatesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-websocketinstrumentinfo](https://bybit-exchange.github.io/docs/inverse/#t-websocketinstrumentinfo)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualStreams.SubscribeToTickersUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTickersUpdatesAsync(Action<DataEvent<BybitTickerUpdate>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`handler`|The event handler for the received data|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to ticker updates*  

</p>

***

## SubscribeToTickerUpdatesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-websocketinstrumentinfo](https://bybit-exchange.github.io/docs/inverse/#t-websocketinstrumentinfo)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualStreams.SubscribeToTickerUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BybitTickerUpdate>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol to receive updates for|
|`handler`|The event handler for the received data|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to ticker updates*  

</p>

***

## SubscribeToTickerUpdatesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-websocketinstrumentinfo](https://bybit-exchange.github.io/docs/inverse/#t-websocketinstrumentinfo)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualStreams.SubscribeToTickerUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitTickerUpdate>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbols`|The symbols to receive updates for|
|`handler`|The event handler for the received data|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to ticker updates*  

</p>

***

## SubscribeToTradesUpdatesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-websockettrade](https://bybit-exchange.github.io/docs/inverse/#t-websockettrade)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualStreams.SubscribeToTradesUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTradesUpdatesAsync(Action<DataEvent<IEnumerable<BybitTradeUpdate>>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`handler`|The event handler for the received data|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to public trade updates*  

</p>

***

## SubscribeToTradeUpdatesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-websockettrade](https://bybit-exchange.github.io/docs/inverse/#t-websockettrade)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualStreams.SubscribeToTradeUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<IEnumerable<BybitTradeUpdate>>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol to receive updates for|
|`handler`|The event handler for the received data|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to public trade updates*  

</p>

***

## SubscribeToTradeUpdatesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-websockettrade](https://bybit-exchange.github.io/docs/inverse/#t-websockettrade)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualStreams.SubscribeToTradeUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BybitTradeUpdate>>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbols`|The symbols to receive updates for|
|`handler`|The event handler for the received data|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to public trade updates*  

</p>

***

## SubscribeToUserTradeUpdatesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-websocketexecution](https://bybit-exchange.github.io/docs/inverse/#t-websocketexecution)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualStreams.SubscribeToUserTradeUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(Action<DataEvent<IEnumerable<BybitUserTradeUpdate>>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`handler`|The event handler for the received data|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to user trade updates*  

</p>
