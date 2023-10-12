---
title: IBybitRestClientInversePerpetualApiExchangeData
has_children: false
parent: IBybitRestClientInversePerpetualApi
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BybitRestClient > InversePerpetualApi > ExchangeData`  
*[DEPRECATED, WILL STOP WORKING ON 16 OCTOBER, USE V5 API INSTEAD] Bybit exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.*
  

***

## GetAnnouncementsAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-announcement](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-announcement)  
<p>

*The API announcements for the last 30 days*  

```csharp  
var client = new BybitRestClient();  
var result = await client.InversePerpetualApi.ExchangeData.GetAnnouncementsAsync();  
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

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-queryindexpricekline](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-queryindexpricekline)  
<p>

*Get index price klines*  

```csharp  
var client = new BybitRestClient();  
var result = await client.InversePerpetualApi.ExchangeData.GetIndexPriceKlinesAsync(/* parameters */);  
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

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-querykline](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-querykline)  
<p>

*Get price klines*  

```csharp  
var client = new BybitRestClient();  
var result = await client.InversePerpetualApi.ExchangeData.GetKlinesAsync(/* parameters */);  
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

## GetLastFundingRateAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-fundingrate](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-fundingrate)  
<p>

*Get last funding rate*  

```csharp  
var client = new BybitRestClient();  
var result = await client.InversePerpetualApi.ExchangeData.GetLastFundingRateAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitFundingRate>> GetLastFundingRateAsync(string symbol, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetLongShortRatioAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-marketaccountratio](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-marketaccountratio)  
<p>

*Get long/short ratio*  

```csharp  
var client = new BybitRestClient();  
var result = await client.InversePerpetualApi.ExchangeData.GetLongShortRatioAsync(/* parameters */);  
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

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-markpricekline](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-markpricekline)  
<p>

*Get mark price klines*  

```csharp  
var client = new BybitRestClient();  
var result = await client.InversePerpetualApi.ExchangeData.GetMarkPriceKlinesAsync(/* parameters */);  
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

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-marketopeninterest](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-marketopeninterest)  
<p>

*Gets the total amount of unsettled contracts. In other words, the total number of contracts held in open positions.*  

```csharp  
var client = new BybitRestClient();  
var result = await client.InversePerpetualApi.ExchangeData.GetOpenInterestAsync(/* parameters */);  
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

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-orderbook](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-orderbook)  
<p>

*Get the current order book for a symbol*  

```csharp  
var client = new BybitRestClient();  
var result = await client.InversePerpetualApi.ExchangeData.GetOrderBookAsync(/* parameters */);  
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

## GetPremiumIndexKlinesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-querypremiumindexkline](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-querypremiumindexkline)  
<p>

*Get premium index klines*  

```csharp  
var client = new BybitRestClient();  
var result = await client.InversePerpetualApi.ExchangeData.GetPremiumIndexKlinesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitIndexPriceKline>>> GetPremiumIndexKlinesAsync(string symbol, KlineInterval interval, DateTime from, int? limit = default, CancellationToken ct = default);  
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

## GetRecentBigTradesAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-marketbigdeal](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-marketbigdeal)  
<p>

*Obtain filled orders worth more than 500,000 USD within the last 24h.*  

```csharp  
var client = new BybitRestClient();  
var result = await client.InversePerpetualApi.ExchangeData.GetRecentBigTradesAsync(/* parameters */);  
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

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-servertime](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-servertime)  
<p>

*Get the server time*  

```csharp  
var client = new BybitRestClient();  
var result = await client.InversePerpetualApi.ExchangeData.GetServerTimeAsync();  
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

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-querysymbol](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-querysymbol)  
<p>

*Get all supported symbols*  

```csharp  
var client = new BybitRestClient();  
var result = await client.InversePerpetualApi.ExchangeData.GetSymbolsAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitSymbol>>> GetSymbolsAsync(CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetTickersAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-latestsymbolinfo](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-latestsymbolinfo)  
<p>

*The ticker info for a symbol*  

```csharp  
var client = new BybitRestClient();  
var result = await client.InversePerpetualApi.ExchangeData.GetTickersAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitTicker>>> GetTickersAsync(string? symbol = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ symbol|The symbol|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetTradeHistoryAsync  

[https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-publictradingrecords](https://bybit-exchange.github.io/docs/futuresV2/inverse/#t-publictradingrecords)  
<p>

*Get public trade history*  

```csharp  
var client = new BybitRestClient();  
var result = await client.InversePerpetualApi.ExchangeData.GetTradeHistoryAsync(/* parameters */);  
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
