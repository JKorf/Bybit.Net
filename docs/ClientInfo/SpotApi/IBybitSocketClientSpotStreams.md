---
title: IBybitSocketClientSpotStreams
has_children: true
parent: IBybitClientSpotApi
grand_parent: IBybitClient
---
*[generated documentation]*  
`BybitClient > SpotApi > SpotStreams`
*Bybit spot streams*
  

***

<details>
<summary>
<b>SubscribeToAccountUpdatesAsync</b>  

[https://bybit-exchange.github.io/docs/spot/#t-privatetopics](https://bybit-exchange.github.io/docs/spot/#t-privatetopics)  
</summary>
<p>

```C#  
Task<CallResult<UpdateSubscription>> SubscribeToAccountUpdatesAsync(Action<DataEvent<BybitSpotAccountUpdate>> accountUpdateHandler, Action<DataEvent<BybitSpotOrderUpdate>> orderUpdateHandler, Action<DataEvent<BybitSpotUserTradeUpdate>> tradeUpdateHandler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`accountUpdateHandler`|Account(balance) update handler|
|`orderUpdateHandler`|Order update handler|
|`tradeUpdateHandler`|User trade update handler|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to account data updates*  

</p>
</details>

***

<details>
<summary>
<b>SubscribeToBookPriceUpdatesAsync</b>  

[https://bybit-exchange.github.io/docs/spot/#t-websocketv2bookticker](https://bybit-exchange.github.io/docs/spot/#t-websocketv2bookticker)  
</summary>
<p>

```C#  
Task<CallResult<UpdateSubscription>> SubscribeToBookPriceUpdatesAsync(string symbol, Action<DataEvent<BybitSpotBookPrice>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`handler`|Data handler|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to book price updates*  

</p>
</details>

***

<details>
<summary>
<b>SubscribeToKlineUpdatesAsync</b>  

[https://bybit-exchange.github.io/docs/spot/#t-websocketv2kline](https://bybit-exchange.github.io/docs/spot/#t-websocketv2kline)  
</summary>
<p>

```C#  
Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, KlineInterval interval, Action<DataEvent<BybitSpotKlineUpdate>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`interval`|Interval of the kline data|
|`handler`|Data handler|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to kline updates*  

</p>
</details>

***

<details>
<summary>
<b>SubscribeToOrderBookUpdatesAsync</b>  

[https://bybit-exchange.github.io/docs/spot/#t-websocketv2depth](https://bybit-exchange.github.io/docs/spot/#t-websocketv2depth)  
</summary>
<p>

```C#  
Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, Action<DataEvent<BybitSpotOrderBookUpdate>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`handler`|Data handler|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to order book updates*  

</p>
</details>

***

<details>
<summary>
<b>SubscribeToTickerUpdatesAsync</b>  

[https://bybit-exchange.github.io/docs/spot/#t-websocketv2realtimes](https://bybit-exchange.github.io/docs/spot/#t-websocketv2realtimes)  
</summary>
<p>

```C#  
Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BybitSpotTickerUpdate>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`handler`|Data handler|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to ticker updates*  

</p>
</details>

***

<details>
<summary>
<b>SubscribeToTradeUpdatesAsync</b>  

[https://bybit-exchange.github.io/docs/spot/#t-websocketv2trade](https://bybit-exchange.github.io/docs/spot/#t-websocketv2trade)  
</summary>
<p>

```C#  
Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<BybitSpotTradeUpdate>> handler, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`handler`|Data handler|
|`ct`|Cancellation token for closing this subscription|

*Subscribe to public trade updates*  

</p>
</details>
