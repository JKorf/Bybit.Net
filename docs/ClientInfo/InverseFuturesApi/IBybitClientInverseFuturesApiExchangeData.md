---
title: IBybitClientInverseFuturesApiExchangeData
parent: IBybitClientInverseFuturesApi
---
*[generated documentation]*  
`BybitClient > InverseFuturesApi > ExchangeData`
*Bybit exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.*
  

***

<details>
<summary>
<b>GetAnnouncementsAsync</b>  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-announcement](https://bybit-exchange.github.io/docs/inverse_futures/#t-announcement)  
</summary>
<p>

```C#  
Task<WebCallResult<IEnumerable<BybitAnnouncement>>> GetAnnouncementsAsync([Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*The API announcements for the last 30 days*  

</p>
</details>

***

<details>
<summary>
<b>GetIndexPriceKlinesAsync</b>  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-queryindexpricekline](https://bybit-exchange.github.io/docs/inverse_futures/#t-queryindexpricekline)  
</summary>
<p>

```C#  
Task<WebCallResult<IEnumerable<BybitIndexPriceKline>>> GetIndexPriceKlinesAsync(string symbol, KlineInterval interval, DateTime from, [Optional] int? limit, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|Symbol of the klines|
|`interval`|Interval of the kline data|
|`from`|Start time of the data|
|`limit`|Max amount of candles|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get index price klines*  

</p>
</details>

***

<details>
<summary>
<b>GetKlinesAsync</b>  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-querykline](https://bybit-exchange.github.io/docs/inverse_futures/#t-querykline)  
</summary>
<p>

```C#  
Task<WebCallResult<IEnumerable<BybitKline>>> GetKlinesAsync(string symbol, KlineInterval interval, DateTime from, [Optional] int? limit, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|Symbol of the klines|
|`interval`|Interval of the kline data|
|`from`|Start time of the data|
|`limit`|Max amount of candles|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get price klines*  

</p>
</details>

***

<details>
<summary>
<b>GetLongShortRatioAsync</b>  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-marketaccountratio](https://bybit-exchange.github.io/docs/inverse_futures/#t-marketaccountratio)  
</summary>
<p>

```C#  
Task<WebCallResult<IEnumerable<BybitAccountRatio>>> GetLongShortRatioAsync(string symbol, DataPeriod period, [Optional] int? limit, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`period`|The data period|
|`limit`|Max amount of results|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get long/short ratio*  

</p>
</details>

***

<details>
<summary>
<b>GetMarkPriceKlinesAsync</b>  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-markpricekline](https://bybit-exchange.github.io/docs/inverse_futures/#t-markpricekline)  
</summary>
<p>

```C#  
Task<WebCallResult<IEnumerable<BybitMarkPriceKline>>> GetMarkPriceKlinesAsync(string symbol, KlineInterval interval, DateTime from, [Optional] int? limit, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|Symbol of the klines|
|`interval`|Interval of the kline data|
|`from`|Start time of the data|
|`limit`|Max amount of candles|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get mark price klines*  

</p>
</details>

***

<details>
<summary>
<b>GetOpenInterestAsync</b>  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-marketopeninterest](https://bybit-exchange.github.io/docs/inverse_futures/#t-marketopeninterest)  
</summary>
<p>

```C#  
Task<WebCallResult<IEnumerable<BybitOpenInterest>>> GetOpenInterestAsync(string symbol, DataPeriod period, [Optional] int? limit, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`period`|The period of data|
|`limit`|Max amount of results|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Gets the total amount of unsettled contracts. In other words, the total number of contracts held in open positions.*  

</p>
</details>

***

<details>
<summary>
<b>GetOrderBookAsync</b>  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-orderbook](https://bybit-exchange.github.io/docs/inverse_futures/#t-orderbook)  
</summary>
<p>

```C#  
Task<WebCallResult<IEnumerable<BybitOrderBookEntry>>> GetOrderBookAsync(string symbol, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get the current order book for a symbol*  

</p>
</details>

***

<details>
<summary>
<b>GetRecentBigTradesAsync</b>  

[https://bybit-exchange.github.io/docs/inverse/#t-marketbigdeal](https://bybit-exchange.github.io/docs/inverse/#t-marketbigdeal)  
</summary>
<p>

```C#  
Task<WebCallResult<IEnumerable<BybitBigTrade>>> GetRecentBigTradesAsync(string symbol, [Optional] int? limit, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`limit`|The max amount of results|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Obtain filled orders worth more than 500,000 USD within the last 24h.*  

</p>
</details>

***

<details>
<summary>
<b>GetServerTimeAsync</b>  

[https://bybit-exchange.github.io/docs/inverse/#t-servertime](https://bybit-exchange.github.io/docs/inverse/#t-servertime)  
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

[https://bybit-exchange.github.io/docs/inverse_futures/#t-querysymbol](https://bybit-exchange.github.io/docs/inverse_futures/#t-querysymbol)  
</summary>
<p>

```C#  
Task<WebCallResult<IEnumerable<BybitSymbol>>> GetSymbolsAsync([Optional] long? receiveWindow, [Optional] CancellationToken ct);  
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

[https://bybit-exchange.github.io/docs/inverse_futures/#t-latestsymbolinfo](https://bybit-exchange.github.io/docs/inverse_futures/#t-latestsymbolinfo)  
</summary>
<p>

```C#  
Task<WebCallResult<IEnumerable<BybitTicker>>> GetTickerAsync([Optional] string? symbol, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
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
<b>GetTradeHistoryAsync</b>  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-publictradingrecords](https://bybit-exchange.github.io/docs/inverse_futures/#t-publictradingrecords)  
</summary>
<p>

```C#  
Task<WebCallResult<IEnumerable<BybitTrade>>> GetTradeHistoryAsync(string symbol, [Optional] long? fromId, [Optional] int? limit, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`fromId`|Filter by records after this id|
|`limit`|Max amount of results|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get public trade history*  

</p>
</details>
