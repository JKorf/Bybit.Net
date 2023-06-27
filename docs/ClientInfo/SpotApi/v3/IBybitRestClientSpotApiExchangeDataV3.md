---
title: IBybitRestClientSpotApiExchangeDataV3
has_children: false
parent: IBybitRestClientSpotApi\v3
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BybitRestClient > SpotApi\v3 > SpotApiExchangeDataV3`  
*Bybit exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.*
  

***

## GetBookPriceAsync  

[https://bybit-exchange.github.io/docs/spot/v3/#t-bestbidask](https://bybit-exchange.github.io/docs/spot/v3/#t-bestbidask)  
<p>

*Get the best ask/bid price for a symbol*  

```csharp  
var client = new BybitRestClient();  
var result = await client.SpotApi\v3.SpotApiExchangeDataV3.GetBookPriceAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitSpotBookPriceV3>> GetBookPriceAsync(string symbol, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetBookPricesAsync  

[https://bybit-exchange.github.io/docs/spot/v3/#t-bestbidask](https://bybit-exchange.github.io/docs/spot/v3/#t-bestbidask)  
<p>

*Get the best ask/bid prices for all symbols*  

```csharp  
var client = new BybitRestClient();  
var result = await client.SpotApi\v3.SpotApiExchangeDataV3.GetBookPricesAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitSpotBookPriceV3>>> GetBookPricesAsync(CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetBorrowInterestAndQuotaAsync  

<p>

*Get borrow info*  

```csharp  
var client = new BybitRestClient();  
var result = await client.SpotApi\v3.SpotApiExchangeDataV3.GetBorrowInterestAndQuotaAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitBorrowInfoV3>> GetBorrowInterestAndQuotaAsync(string asset, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|asset|The asset to retrieve info on|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetKlinesAsync  

[https://bybit-exchange.github.io/docs/spot/v3/#t-querykline](https://bybit-exchange.github.io/docs/spot/v3/#t-querykline)  
<p>

*Get price klines*  

```csharp  
var client = new BybitRestClient();  
var result = await client.SpotApi\v3.SpotApiExchangeDataV3.GetKlinesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitSpotKlineV3>>> GetKlinesAsync(string symbol, KlineInterval interval, DateTime? startTime = default, DateTime? endTime = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol of the klines|
|interval|Interval of the kline data|
|_[Optional]_ startTime|Start time of the data|
|_[Optional]_ endTime|End time of the data|
|_[Optional]_ limit|Max amount of candles|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetMergedOrderBookAsync  

[https://bybit-exchange.github.io/docs/spot/v3/#t-mergedorderbook](https://bybit-exchange.github.io/docs/spot/v3/#t-mergedorderbook)  
<p>

*Get merged order book based on the scale*  

```csharp  
var client = new BybitRestClient();  
var result = await client.SpotApi\v3.SpotApiExchangeDataV3.GetMergedOrderBookAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitSpotOrderBook>> GetMergedOrderBookAsync(string symbol, int? scale = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ scale|The scale of the order book. 1 means 1 digit|
|_[Optional]_ limit|The amount of rows|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOrderBookAsync  

[https://bybit-exchange.github.io/docs/spot/v3/#t-orderbook](https://bybit-exchange.github.io/docs/spot/v3/#t-orderbook)  
<p>

*Get the current order book for a symbol*  

```csharp  
var client = new BybitRestClient();  
var result = await client.SpotApi\v3.SpotApiExchangeDataV3.GetOrderBookAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitSpotOrderBook>> GetOrderBookAsync(string symbol, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ limit|The number of rows|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetPriceAsync  

[https://bybit-exchange.github.io/docs/spot/v3/#t-lasttradedprice](https://bybit-exchange.github.io/docs/spot/v3/#t-lasttradedprice)  
<p>

*Get the last trade price of a symbol*  

```csharp  
var client = new BybitRestClient();  
var result = await client.SpotApi\v3.SpotApiExchangeDataV3.GetPriceAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitSpotPrice>> GetPriceAsync(string symbol, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetPricesAsync  

[https://bybit-exchange.github.io/docs/spot/v3/#t-lasttradedprice](https://bybit-exchange.github.io/docs/spot/v3/#t-lasttradedprice)  
<p>

*Get the last trade price of all symbols*  

```csharp  
var client = new BybitRestClient();  
var result = await client.SpotApi\v3.SpotApiExchangeDataV3.GetPricesAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitSpotPrice>>> GetPricesAsync(CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetServerTimeAsync  

[https://bybit-exchange.github.io/docs/spot/v3/#t-servertime](https://bybit-exchange.github.io/docs/spot/v3/#t-servertime)  
<p>

*Get the server time*  

```csharp  
var client = new BybitRestClient();  
var result = await client.SpotApi\v3.SpotApiExchangeDataV3.GetServerTimeAsync();  
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

[https://bybit-exchange.github.io/docs/spot/v3/#t-getsymbols](https://bybit-exchange.github.io/docs/spot/v3/#t-getsymbols)  
<p>

*Get all supported symbols*  

```csharp  
var client = new BybitRestClient();  
var result = await client.SpotApi\v3.SpotApiExchangeDataV3.GetSymbolsAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitSpotSymbolV3>>> GetSymbolsAsync(CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetTickerAsync  

[https://bybit-exchange.github.io/docs/spot/v3/#t-spot_latestsymbolinfo](https://bybit-exchange.github.io/docs/spot/v3/#t-spot_latestsymbolinfo)  
<p>

*The ticker info for a symbol*  

```csharp  
var client = new BybitRestClient();  
var result = await client.SpotApi\v3.SpotApiExchangeDataV3.GetTickerAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitSpotTickerV3>> GetTickerAsync(string symbol, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetTickersAsync  

[https://bybit-exchange.github.io/docs/spot/v3/#t-spot_latestsymbolinfo](https://bybit-exchange.github.io/docs/spot/v3/#t-spot_latestsymbolinfo)  
<p>

*The ticker info for all symbols*  

```csharp  
var client = new BybitRestClient();  
var result = await client.SpotApi\v3.SpotApiExchangeDataV3.GetTickersAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitSpotTickerV3>>> GetTickersAsync(CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetTradeHistoryAsync  

[https://bybit-exchange.github.io/docs/spot/v3/#t-publictradingrecords](https://bybit-exchange.github.io/docs/spot/v3/#t-publictradingrecords)  
<p>

*Get public trade history*  

```csharp  
var client = new BybitRestClient();  
var result = await client.SpotApi\v3.SpotApiExchangeDataV3.GetTradeHistoryAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitSpotTradeV3>>> GetTradeHistoryAsync(string symbol, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ limit|Max amount of results|
|_[Optional]_ ct|Cancellation token|

</p>
