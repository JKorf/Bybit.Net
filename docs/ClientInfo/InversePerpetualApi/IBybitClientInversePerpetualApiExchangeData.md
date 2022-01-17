---
title: IBybitClientInversePerpetualApiExchangeData
has_children: false
parent: IBybitClientInversePerpetualApi
grand_parent: IBybitClient
---
*[generated documentation]*  
`BybitClient > InversePerpetualApi > ExchangeData`  
*Bybit exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.*
  

***

## GetAnnouncementsAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-announcement](https://bybit-exchange.github.io/docs/inverse/#t-announcement)  
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

***

## GetIndexPriceKlinesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-queryindexpricekline](https://bybit-exchange.github.io/docs/inverse/#t-queryindexpricekline)  
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

***

## GetKlinesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-querykline](https://bybit-exchange.github.io/docs/inverse/#t-querykline)  
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

***

## GetLastFundingRateAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-fundingrate](https://bybit-exchange.github.io/docs/inverse/#t-fundingrate)  
<p>

```C#  
Task<WebCallResult<BybitFundingRate>> GetLastFundingRateAsync(string symbol, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get last funding rate*  

</p>

***

## GetLongShortRatioAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-marketaccountratio](https://bybit-exchange.github.io/docs/inverse/#t-marketaccountratio)  
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

***

## GetMarkPriceKlinesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-markpricekline](https://bybit-exchange.github.io/docs/inverse/#t-markpricekline)  
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

***

## GetOpenInterestAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-marketopeninterest](https://bybit-exchange.github.io/docs/inverse/#t-marketopeninterest)  
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

***

## GetOrderBookAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-orderbook](https://bybit-exchange.github.io/docs/inverse/#t-orderbook)  
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

***

## GetPremiumIndexKlinesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-querypremiumindexkline](https://bybit-exchange.github.io/docs/inverse/#t-querypremiumindexkline)  
<p>

```C#  
Task<WebCallResult<IEnumerable<BybitIndexPriceKline>>> GetPremiumIndexKlinesAsync(string symbol, KlineInterval interval, DateTime from, [Optional] int? limit, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|Symbol of the klines|
|`interval`|Interval of the kline data|
|`from`|Start time of the data|
|`limit`|Max amount of candles|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get premium index klines*  

</p>

***

## GetRecentBigTradesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-marketbigdeal](https://bybit-exchange.github.io/docs/inverse/#t-marketbigdeal)  
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

***

## GetServerTimeAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-servertime](https://bybit-exchange.github.io/docs/inverse/#t-servertime)  
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

***

## GetSymbolsAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-querysymbol](https://bybit-exchange.github.io/docs/inverse/#t-querysymbol)  
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

***

## GetTickersAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-latestsymbolinfo](https://bybit-exchange.github.io/docs/inverse/#t-latestsymbolinfo)  
<p>

```C#  
Task<WebCallResult<IEnumerable<BybitTicker>>> GetTickersAsync([Optional] string? symbol, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*The ticker info for a symbol*  

</p>

***

## GetTradeHistoryAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-publictradingrecords](https://bybit-exchange.github.io/docs/inverse/#t-publictradingrecords)  
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
