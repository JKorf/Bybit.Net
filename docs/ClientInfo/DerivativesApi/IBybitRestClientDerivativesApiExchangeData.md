---
title: IBybitRestClientDerivativesApiExchangeData
has_children: false
parent: IBybitRestClientDerivativesApi
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BybitRestClient > DerivativesApi > ExchangeData`  
*Bybit exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.*
  

***

## GetFundingRateAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_historyfundingratehead](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_historyfundingratehead)  
<p>

*Get funding rate history*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi.ExchangeData.GetFundingRateAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitDerivativesFundingRate>>> GetFundingRateAsync(Category category, string symbol, DateTime? from = default, DateTime? to = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Derivatives products category. If category is not passed, then return ""For now, linear inverse including inverse futures are available|
|symbol|The symbol|
|_[Optional]_ from|Start time of the data|
|_[Optional]_ to|End time of the data|
|_[Optional]_ limit|Max amount of results|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetIndexPriceKlinesAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_indexpricekline](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_indexpricekline)  
<p>

*Get index price klines*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi.ExchangeData.GetIndexPriceKlinesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitKline>>> GetIndexPriceKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime from, DateTime to, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Derivatives products category. If category is not passed, then return ""For now, linear inverse including inverse futures are available|
|symbol|Symbol of the klines|
|interval|Interval of the kline data|
|from|Start time of the data|
|to|End time of the data|
|_[Optional]_ limit|Max amount of candles|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetKlinesAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_querykline](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_querykline)  
<p>

*Get price klines*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi.ExchangeData.GetKlinesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitKline>>> GetKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime from, DateTime to, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Derivatives products category. If category is not passed, then return ""For now, linear inverse including inverse futures are available|
|symbol|Symbol of the klines|
|interval|Interval of the kline data|
|from|Start time of the data|
|to|End time of the data|
|_[Optional]_ limit|Max amount of candles|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetMarkPriceKlinesAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_markpricekline](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_markpricekline)  
<p>

*Get mark price klines*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi.ExchangeData.GetMarkPriceKlinesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitKline>>> GetMarkPriceKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime from, DateTime to, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Derivatives products category. If category is not passed, then return ""For now, linear inverse including inverse futures are available|
|symbol|Symbol of the klines|
|interval|Interval of the kline data|
|from|Start time of the data|
|to|End time of the data|
|_[Optional]_ limit|Max amount of candles|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOpenInterestAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_marketopeninterest](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_marketopeninterest)  
<p>

*Gets the total amount of unsettled contracts. In other words, the total number of contracts held in open positions.*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi.ExchangeData.GetOpenInterestAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitDerivativesOpenInterest>>> GetOpenInterestAsync(Category category, string symbol, OpenInterestInterval interval, DataPeriod period, DateTime? from = default, DateTime? to = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Derivatives products category. If category is not passed, then return ""For now, linear inverse including inverse futures are available|
|symbol|The symbol|
|interval| Open interest interval type |
|period|The period of data|
|_[Optional]_ from|Start time of the data|
|_[Optional]_ to|End time of the data|
|_[Optional]_ limit|Max amount of results|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOptionDeliveryPriceAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_optiondeliveryhead](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_optiondeliveryhead)  
<p>

*Get option delivery price*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi.ExchangeData.GetOptionDeliveryPriceAsync();  
```  

```csharp  
Task<WebCallResult<BybitCursorPage<IEnumerable<BybitDerivativesOptionDeliveryPrice>>>> GetOptionDeliveryPriceAsync(Category? category = default, string? symbol = default, string? baseAsset = default, int? limit = default, string? cursor = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ category|Derivatives products category. If category is not passed, then return ""For now, linear inverse including inverse futures are available|
|_[Optional]_ symbol|The symbol|
|_[Optional]_ baseAsset|Base coin. Only valid when category=option. If not passed, BTC by default.|
|_[Optional]_ limit|Max amount of results|
|_[Optional]_ cursor|API pass-through|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOrderBookAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_orderbook](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_orderbook)  
<p>

*Get the current order book for a symbol*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi.ExchangeData.GetOrderBookAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitDerivativesOrderBookEntry>> GetOrderBookAsync(string symbol, Category? category = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ category|Derivatives products category. If category is not passed, then return ""For now, linear inverse option are available|
|_[Optional]_ limit|25 by default, 500 is max. If option, only 25 is available|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetRiskLimitAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_risklimithead](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_risklimithead)  
<p>

*Get Risk Limit*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi.ExchangeData.GetRiskLimitAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitDerivativesRiskLimit>>> GetRiskLimitAsync(Category category, string symbol, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Derivatives products category. If category is not passed, then return ""For now, linear inverse including inverse futures are available|
|symbol|The symbol|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetServerTimeAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-servertime](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-servertime)  
<p>

*Get the server time*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi.ExchangeData.GetServerTimeAsync();  
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

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_instrhead](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_instrhead)  
<p>

*Get all supported symbols*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi.ExchangeData.GetSymbolsAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitDerivativesCursorPage<IEnumerable<BybitDerivativesSymbol>>>> GetSymbolsAsync(Category category, string? symbol = default, string? baseAsset = default, int? limit = default, string? cursor = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category| Derivatives products category.If category is not passed, then return ""For now, linear inverse option are available|
|_[Optional]_ symbol|Symbol|
|_[Optional]_ baseAsset|Base coin.Only valid when category = option.If not passed, BTC by default.|
|_[Optional]_ limit|Limit for data size per cursor, max size is 1000. Default as showing 500 pieces of data per cursor|
|_[Optional]_ cursor|API pass-through|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetTickerAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_tickerhead](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_tickerhead)  
<p>

*The ticker info for a symbol*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi.ExchangeData.GetTickerAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitDerivativesTicker>>> GetTickerAsync(Category category, string? symbol = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Derivatives products category. If category is not passed, then return ""For now, linear inverse option are available|
|_[Optional]_ symbol|The symbol|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetTradeHistoryAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_publictradingrecords](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_publictradingrecords)  
<p>

*Get Trade history*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi.ExchangeData.GetTradeHistoryAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitDerivativesTrade>>> GetTradeHistoryAsync(Category category, string symbol, string? baseAsset = default, OptionType? optionType = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Derivatives products category. If category is not passed, then return ""For now, linear inverse including inverse futures are available|
|symbol|The symbol|
|_[Optional]_ baseAsset|Base coin. Only valid when category=option. If not passed, BTC by default.|
|_[Optional]_ optionType|Trading type of option|
|_[Optional]_ limit|Max amount of results|
|_[Optional]_ ct|Cancellation token|

</p>
