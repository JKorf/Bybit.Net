---
title: IBybitClientSpotApiExchangeData
has_children: false
parent: IBybitClientSpotApi
grand_parent: IBybitClient
---
*[generated documentation]*  
`BybitClient > SpotApi > ExchangeData`  
*Bybit exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.*
  

***

## GetBookPriceAsync  

[https://bybit-exchange.github.io/docs/spot/#t-bestbidask](https://bybit-exchange.github.io/docs/spot/#t-bestbidask)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.SpotApi.ExchangeData.GetBookPriceAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitSpotBookPrice>> GetBookPriceAsync(string symbol, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get the best ask/bid price for a symbol*  

</p>

***

## GetBookPricesAsync  

[https://bybit-exchange.github.io/docs/spot/#t-bestbidask](https://bybit-exchange.github.io/docs/spot/#t-bestbidask)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.SpotApi.ExchangeData.GetBookPricesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitSpotBookPrice>>> GetBookPricesAsync([Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get the best ask/bid prices for all symbols*  

</p>

***

## GetKlinesAsync  

[https://bybit-exchange.github.io/docs/spot/#t-querykline](https://bybit-exchange.github.io/docs/spot/#t-querykline)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.SpotApi.ExchangeData.GetKlinesAsync(/* parameters */);  
```  

```csharp  
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

***

## GetMergedOrderBookAsync  

[https://bybit-exchange.github.io/docs/spot/#t-mergedorderbook](https://bybit-exchange.github.io/docs/spot/#t-mergedorderbook)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.SpotApi.ExchangeData.GetMergedOrderBookAsync(/* parameters */);  
```  

```csharp  
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

***

## GetOrderBookAsync  

[https://bybit-exchange.github.io/docs/spot/#t-orderbook](https://bybit-exchange.github.io/docs/spot/#t-orderbook)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.SpotApi.ExchangeData.GetOrderBookAsync(/* parameters */);  
```  

```csharp  
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

***

## GetPriceAsync  

[https://bybit-exchange.github.io/docs/spot/#t-lasttradedprice](https://bybit-exchange.github.io/docs/spot/#t-lasttradedprice)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.SpotApi.ExchangeData.GetPriceAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitSpotPrice>> GetPriceAsync(string symbol, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get the last trade price of a symbol*  

</p>

***

## GetPricesAsync  

[https://bybit-exchange.github.io/docs/spot/#t-lasttradedprice](https://bybit-exchange.github.io/docs/spot/#t-lasttradedprice)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.SpotApi.ExchangeData.GetPricesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitSpotPrice>>> GetPricesAsync([Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get the last trade price of all symbols*  

</p>

***

## GetServerTimeAsync  

[https://bybit-exchange.github.io/docs/spot/#t-servertime](https://bybit-exchange.github.io/docs/spot/#t-servertime)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.SpotApi.ExchangeData.GetServerTimeAsync(/* parameters */);  
```  

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

[https://bybit-exchange.github.io/docs/spot/#t-spot_querysymbol](https://bybit-exchange.github.io/docs/spot/#t-spot_querysymbol)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.SpotApi.ExchangeData.GetSymbolsAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitSpotSymbol>>> GetSymbolsAsync([Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get all supported symbols*  

</p>

***

## GetTickerAsync  

[https://bybit-exchange.github.io/docs/spot/#t-spot_latestsymbolinfo](https://bybit-exchange.github.io/docs/spot/#t-spot_latestsymbolinfo)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.SpotApi.ExchangeData.GetTickerAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitSpotTicker>> GetTickerAsync(string symbol, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*The ticker info for a symbol*  

</p>

***

## GetTickersAsync  

[https://bybit-exchange.github.io/docs/spot/#t-spot_latestsymbolinfo](https://bybit-exchange.github.io/docs/spot/#t-spot_latestsymbolinfo)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.SpotApi.ExchangeData.GetTickersAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitSpotTicker>>> GetTickersAsync([Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*The ticker info for all symbols*  

</p>

***

## GetTradeHistoryAsync  

[https://bybit-exchange.github.io/docs/spot/#t-publictradingrecords](https://bybit-exchange.github.io/docs/spot/#t-publictradingrecords)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.SpotApi.ExchangeData.GetTradeHistoryAsync(/* parameters */);  
```  

```csharp  
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
