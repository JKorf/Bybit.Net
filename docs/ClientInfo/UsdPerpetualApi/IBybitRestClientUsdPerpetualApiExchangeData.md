---
title: IBybitRestClientUsdPerpetualApiExchangeData
has_children: false
parent: IBybitRestClientUsdPerpetualApi
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BybitRestClient > UsdPerpetualApi > ExchangeData`  
*[DEPRECATED, WILL STOP WORKING ON 16 OCTOBER, USE V5 API INSTEAD] Bybit exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.*
  

***

## GetAnnouncementsAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-announcement](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-announcement)  
<p>

*The API announcements for the last 30 days*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.ExchangeData.GetAnnouncementsAsync();  
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

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-queryindexpricekline](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-queryindexpricekline)  
<p>

*Get index price klines*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.ExchangeData.GetIndexPriceKlinesAsync(/* parameters */);  
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

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-querykline](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-querykline)  
<p>

*Get price klines*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.ExchangeData.GetKlinesAsync(/* parameters */);  
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

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-fundingrate](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-fundingrate)  
<p>

*Get last funding rate*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.ExchangeData.GetLastFundingRateAsync(/* parameters */);  
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

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-marketaccountratio](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-marketaccountratio)  
<p>

*Get long/short ratio*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.ExchangeData.GetLongShortRatioAsync(/* parameters */);  
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

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-markpricekline](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-markpricekline)  
<p>

*Get mark price klines*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.ExchangeData.GetMarkPriceKlinesAsync(/* parameters */);  
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

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-marketopeninterest](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-marketopeninterest)  
<p>

*Gets the total amount of unsettled contracts. In other words, the total number of contracts held in open positions.*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.ExchangeData.GetOpenInterestAsync(/* parameters */);  
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

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-orderbook](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-orderbook)  
<p>

*Get the current order book for a symbol*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.ExchangeData.GetOrderBookAsync(/* parameters */);  
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

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-querypremiumindexkline](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-querypremiumindexkline)  
<p>

*Get premium index klines*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.ExchangeData.GetPremiumIndexKlinesAsync(/* parameters */);  
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

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-marketbigdeal](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-marketbigdeal)  
<p>

*Obtain filled orders worth more than 500,000 USD within the last 24h.*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.ExchangeData.GetRecentBigTradesAsync(/* parameters */);  
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

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-servertime](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-servertime)  
<p>

*Get the server time*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.ExchangeData.GetServerTimeAsync();  
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

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-querysymbol](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-querysymbol)  
<p>

*Get all supported symbols*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.ExchangeData.GetSymbolsAsync();  
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

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-latestsymbolinfo](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-latestsymbolinfo)  
<p>

*The ticker info for a symbol*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.ExchangeData.GetTickerAsync();  
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

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-publictradingrecords](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-publictradingrecords)  
<p>

*Get public trade history*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.ExchangeData.GetTradeHistoryAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitTrade>>> GetTradeHistoryAsync(string symbol, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ limit|Max amount of results|
|_[Optional]_ ct|Cancellation token|

</p>
