---
title: IBybitRestClientInverseFuturesApiExchangeData
has_children: false
parent: IBybitRestClientInverseFuturesApi
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BybitRestClient > InverseFuturesApi > ExchangeData`  
*[DEPRECATED, WILL STOP WORKING ON 16 OCTOBER, USE V5 API INSTEAD] Bybit exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.*
  

***

## GetAnnouncementsAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse_futures/#t-announcement](https://bybit-exchange.github.io/docs/futuresV2/inverse_futures/#t-announcement)  
<p>

*The API announcements for the last 30 days*  

```csharp  
var client = new BybitRestClient();  
var result = await client.InverseFuturesApi.ExchangeData.GetAnnouncementsAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitAnnouncement>>> GetAnnouncementsAsync(CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetIndexPriceKlinesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse_futures/#t-queryindexpricekline](https://bybit-exchange.github.io/docs/futuresV2/inverse_futures/#t-queryindexpricekline)  
<p>

*Get index price klines*  

```csharp  
var client = new BybitRestClient();  
var result = await client.InverseFuturesApi.ExchangeData.GetIndexPriceKlinesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitIndexPriceKline>>> GetIndexPriceKlinesAsync(string symbol, KlineInterval interval, DateTime from, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol of the klines|
|interval|Interval of the kline data|
|from|Start time of the data|
|_[Optional]_ limit|Max amount of candles|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetKlinesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse_futures/#t-querykline](https://bybit-exchange.github.io/docs/futuresV2/inverse_futures/#t-querykline)  
<p>

*Get price klines*  

```csharp  
var client = new BybitRestClient();  
var result = await client.InverseFuturesApi.ExchangeData.GetKlinesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitKline>>> GetKlinesAsync(string symbol, KlineInterval interval, DateTime from, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol of the klines|
|interval|Interval of the kline data|
|from|Start time of the data|
|_[Optional]_ limit|Max amount of candles|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetLongShortRatioAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse_futures/#t-marketaccountratio](https://bybit-exchange.github.io/docs/futuresV2/inverse_futures/#t-marketaccountratio)  
<p>

*Get long/short ratio*  

```csharp  
var client = new BybitRestClient();  
var result = await client.InverseFuturesApi.ExchangeData.GetLongShortRatioAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitAccountRatio>>> GetLongShortRatioAsync(string symbol, DataPeriod period, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|period|The data period|
|_[Optional]_ limit|Max amount of results|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetMarkPriceKlinesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse_futures/#t-markpricekline](https://bybit-exchange.github.io/docs/futuresV2/inverse_futures/#t-markpricekline)  
<p>

*Get mark price klines*  

```csharp  
var client = new BybitRestClient();  
var result = await client.InverseFuturesApi.ExchangeData.GetMarkPriceKlinesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitMarkPriceKline>>> GetMarkPriceKlinesAsync(string symbol, KlineInterval interval, DateTime from, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol of the klines|
|interval|Interval of the kline data|
|from|Start time of the data|
|_[Optional]_ limit|Max amount of candles|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOpenInterestAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse_futures/#t-marketopeninterest](https://bybit-exchange.github.io/docs/futuresV2/inverse_futures/#t-marketopeninterest)  
<p>

*Gets the total amount of unsettled contracts. In other words, the total number of contracts held in open positions.*  

```csharp  
var client = new BybitRestClient();  
var result = await client.InverseFuturesApi.ExchangeData.GetOpenInterestAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitOpenInterest>>> GetOpenInterestAsync(string symbol, DataPeriod period, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|period|The period of data|
|_[Optional]_ limit|Max amount of results|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOrderBookAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse_futures/#t-orderbook](https://bybit-exchange.github.io/docs/futuresV2/inverse_futures/#t-orderbook)  
<p>

*Get the current order book for a symbol*  

```csharp  
var client = new BybitRestClient();  
var result = await client.InverseFuturesApi.ExchangeData.GetOrderBookAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitOrderBookEntry>>> GetOrderBookAsync(string symbol, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetRecentBigTradesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse_futures/#t-marketbigdeal](https://bybit-exchange.github.io/docs/futuresV2/inverse_futures/#t-marketbigdeal)  
<p>

*Obtain filled orders worth more than 500,000 USD within the last 24h.*  

```csharp  
var client = new BybitRestClient();  
var result = await client.InverseFuturesApi.ExchangeData.GetRecentBigTradesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitBigTrade>>> GetRecentBigTradesAsync(string symbol, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ limit|The max amount of results|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetServerTimeAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-servertime](https://bybit-exchange.github.io/docs/inverse/#t-servertime)  
<p>

*Get the server time*  

```csharp  
var client = new BybitRestClient();  
var result = await client.InverseFuturesApi.ExchangeData.GetServerTimeAsync();  
```  

```csharp  
Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetSymbolsAsync  

[https://bybit-exchange.github.io/docs/futuresV2/futuresV2/inverse_futures/#t-querysymbol](https://bybit-exchange.github.io/docs/futuresV2/futuresV2/inverse_futures/#t-querysymbol)  
<p>

*Get all supported symbols*  

```csharp  
var client = new BybitRestClient();  
var result = await client.InverseFuturesApi.ExchangeData.GetSymbolsAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitSymbol>>> GetSymbolsAsync(CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetTickerAsync  

[https://bybit-exchange.github.io/docs/futuresV2/futuresV2/inverse_futures/#t-latestsymbolinfo](https://bybit-exchange.github.io/docs/futuresV2/futuresV2/inverse_futures/#t-latestsymbolinfo)  
<p>

*The ticker info for a symbol*  

```csharp  
var client = new BybitRestClient();  
var result = await client.InverseFuturesApi.ExchangeData.GetTickerAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitTicker>>> GetTickerAsync(string? symbol = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ symbol|The symbol|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetTradeHistoryAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse_futures/#t-publictradingrecords](https://bybit-exchange.github.io/docs/futuresV2/inverse_futures/#t-publictradingrecords)  
<p>

*Get public trade history*  

```csharp  
var client = new BybitRestClient();  
var result = await client.InverseFuturesApi.ExchangeData.GetTradeHistoryAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitTrade>>> GetTradeHistoryAsync(string symbol, long? fromId = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ fromId|Filter by records after this id|
|_[Optional]_ limit|Max amount of results|
|_[Optional]_ ct|Cancellation token|

</p>
