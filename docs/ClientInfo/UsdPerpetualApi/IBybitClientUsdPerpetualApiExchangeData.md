---
title: IBybitClientUsdPerpetualApiExchangeData
has_children: false
parent: IBybitClientUsdPerpetualApi
grand_parent: IBybitClient
---
*[generated documentation]*  
`BybitClient > UsdPerpetualApi > ExchangeData`  
*Bybit exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.*
  

***

## GetAnnouncementsAsync  

[https://bybit-exchange.github.io/docs/linear/#t-announcement](https://bybit-exchange.github.io/docs/linear/#t-announcement)  
<p>

```csharp  
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

[https://bybit-exchange.github.io/docs/linear/#t-queryindexpricekline](https://bybit-exchange.github.io/docs/linear/#t-queryindexpricekline)  
<p>

```csharp  
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

[https://bybit-exchange.github.io/docs/linear/#t-querykline](https://bybit-exchange.github.io/docs/linear/#t-querykline)  
<p>

```csharp  
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

[https://bybit-exchange.github.io/docs/linear/#t-fundingrate](https://bybit-exchange.github.io/docs/linear/#t-fundingrate)  
<p>

```csharp  
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

[https://bybit-exchange.github.io/docs/linear/#t-marketaccountratio](https://bybit-exchange.github.io/docs/linear/#t-marketaccountratio)  
<p>

```csharp  
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

[https://bybit-exchange.github.io/docs/linear/#t-markpricekline](https://bybit-exchange.github.io/docs/linear/#t-markpricekline)  
<p>

```csharp  
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

[https://bybit-exchange.github.io/docs/linear/#t-marketopeninterest](https://bybit-exchange.github.io/docs/linear/#t-marketopeninterest)  
<p>

```csharp  
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

[https://bybit-exchange.github.io/docs/linear/#t-orderbook](https://bybit-exchange.github.io/docs/linear/#t-orderbook)  
<p>

```csharp  
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

[https://bybit-exchange.github.io/docs/linear/#t-querypremiumindexkline](https://bybit-exchange.github.io/docs/linear/#t-querypremiumindexkline)  
<p>

```csharp  
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

[https://bybit-exchange.github.io/docs/linear/#t-marketbigdeal](https://bybit-exchange.github.io/docs/linear/#t-marketbigdeal)  
<p>

```csharp  
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

[https://bybit-exchange.github.io/docs/linear/#t-servertime](https://bybit-exchange.github.io/docs/linear/#t-servertime)  
<p>

```csharp  
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

[https://bybit-exchange.github.io/docs/linear/#t-querysymbol](https://bybit-exchange.github.io/docs/linear/#t-querysymbol)  
<p>

```csharp  
Task<WebCallResult<IEnumerable<BybitSymbol>>> GetSymbolsAsync([Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get all supported symbols*  

</p>

***

## GetTickerAsync  

[https://bybit-exchange.github.io/docs/linear/#t-latestsymbolinfo](https://bybit-exchange.github.io/docs/linear/#t-latestsymbolinfo)  
<p>

```csharp  
Task<WebCallResult<IEnumerable<BybitTicker>>> GetTickerAsync([Optional] string? symbol, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
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

[https://bybit-exchange.github.io/docs/linear/#t-publictradingrecords](https://bybit-exchange.github.io/docs/linear/#t-publictradingrecords)  
<p>

```csharp  
Task<WebCallResult<IEnumerable<BybitTrade>>> GetTradeHistoryAsync(string symbol, [Optional] int? limit, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`limit`|Max amount of results|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get public trade history*  

</p>
