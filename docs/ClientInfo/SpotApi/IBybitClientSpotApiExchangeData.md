---
title: IBybitClientSpotApiExchangeData
parent: IBybitClientSpotApi
---
*[generated documentation]*  
`BybitClient > SpotApi > ExchangeData`
*Bybit exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.*
  

***

<details>
<summary>
<b>GetBookPriceAsync</b>  

[https://bybit-exchange.github.io/docs/spot/#t-bestbidask](https://bybit-exchange.github.io/docs/spot/#t-bestbidask)  
</summary>
<p>

```C#  
Task<WebCallResult<BybitSpotBookPrice>> GetBookPriceAsync(string symbol, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get the best ask/bid price for a symbol*  

</p>
</details>

***

<details>
<summary>
<b>GetBookPricesAsync</b>  

[https://bybit-exchange.github.io/docs/spot/#t-bestbidask](https://bybit-exchange.github.io/docs/spot/#t-bestbidask)  
</summary>
<p>

```C#  
Task<WebCallResult<IEnumerable<BybitSpotBookPrice>>> GetBookPricesAsync([Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get the best ask/bid prices for all symbols*  

</p>
</details>

***

<details>
<summary>
<b>GetKlinesAsync</b>  

[https://bybit-exchange.github.io/docs/spot/#t-querykline](https://bybit-exchange.github.io/docs/spot/#t-querykline)  
</summary>
<p>

```C#  
Task<WebCallResult<IEnumerable<BybitSpotKline>>> GetKlinesAsync(string symbol, KlineInterval interval, [Optional] DateTime? startTime, [Optional] DateTime? endTime, [Optional] int? limit, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|Symbol of the klines|
|`interval`|Interval of the kline data|
|`startTime`|Start time of the data|
|`endTime`|End time of the data|
|`limit`|Max amount of candles|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get price klines*  

</p>
</details>

***

<details>
<summary>
<b>GetMergedOrderBookAsync</b>  

[https://bybit-exchange.github.io/docs/spot/#t-mergedorderbook](https://bybit-exchange.github.io/docs/spot/#t-mergedorderbook)  
</summary>
<p>

```C#  
Task<WebCallResult<BybitSpotOrderBook>> GetMergedOrderBookAsync(string symbol, [Optional] int? scale, [Optional] int? limit, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`scale`|The scale of the order book. 1 means 1 digit|
|`limit`|The amount of rows|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get merged order book based on the scale*  

</p>
</details>

***

<details>
<summary>
<b>GetOrderBookAsync</b>  

[https://bybit-exchange.github.io/docs/spot/#t-orderbook](https://bybit-exchange.github.io/docs/spot/#t-orderbook)  
</summary>
<p>

```C#  
Task<WebCallResult<BybitSpotOrderBook>> GetOrderBookAsync(string symbol, [Optional] int? limit, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`limit`|The number of rows|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get the current order book for a symbol*  

</p>
</details>

***

<details>
<summary>
<b>GetPriceAsync</b>  

[https://bybit-exchange.github.io/docs/spot/#t-lasttradedprice](https://bybit-exchange.github.io/docs/spot/#t-lasttradedprice)  
</summary>
<p>

```C#  
Task<WebCallResult<BybitSpotPrice>> GetPriceAsync(string symbol, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get the last trade price of a symbol*  

</p>
</details>

***

<details>
<summary>
<b>GetPricesAsync</b>  

[https://bybit-exchange.github.io/docs/spot/#t-lasttradedprice](https://bybit-exchange.github.io/docs/spot/#t-lasttradedprice)  
</summary>
<p>

```C#  
Task<WebCallResult<IEnumerable<BybitSpotPrice>>> GetPricesAsync([Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get the last trade price of all symbols*  

</p>
</details>

***

<details>
<summary>
<b>GetServerTimeAsync</b>  

[https://bybit-exchange.github.io/docs/spot/#t-servertime](https://bybit-exchange.github.io/docs/spot/#t-servertime)  
</summary>
<p>

```C#  
Task<WebCallResult<DateTime>> GetServerTimeAsync([Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get the server time*  

</p>
</details>

***

<details>
<summary>
<b>GetSymbolsAsync</b>  

[https://bybit-exchange.github.io/docs/spot/#t-spot_querysymbol](https://bybit-exchange.github.io/docs/spot/#t-spot_querysymbol)  
</summary>
<p>

```C#  
Task<WebCallResult<IEnumerable<BybitSpotSymbol>>> GetSymbolsAsync([Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get all supported symbols*  

</p>
</details>

***

<details>
<summary>
<b>GetTickerAsync</b>  

[https://bybit-exchange.github.io/docs/spot/#t-spot_latestsymbolinfo](https://bybit-exchange.github.io/docs/spot/#t-spot_latestsymbolinfo)  
</summary>
<p>

```C#  
Task<WebCallResult<BybitSpotTicker>> GetTickerAsync(string symbol, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*The ticker info for a symbol*  

</p>
</details>

***

<details>
<summary>
<b>GetTickersAsync</b>  

[https://bybit-exchange.github.io/docs/spot/#t-spot_latestsymbolinfo](https://bybit-exchange.github.io/docs/spot/#t-spot_latestsymbolinfo)  
</summary>
<p>

```C#  
Task<WebCallResult<IEnumerable<BybitSpotTicker>>> GetTickersAsync([Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*The ticker info for all symbols*  

</p>
</details>

***

<details>
<summary>
<b>GetTradeHistoryAsync</b>  

[https://bybit-exchange.github.io/docs/spot/#t-publictradingrecords](https://bybit-exchange.github.io/docs/spot/#t-publictradingrecords)  
</summary>
<p>

```C#  
Task<WebCallResult<IEnumerable<BybitSpotTrade>>> GetTradeHistoryAsync(string symbol, [Optional] int? limit, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`limit`|Max amount of results|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get public trade history*  

</p>
</details>
