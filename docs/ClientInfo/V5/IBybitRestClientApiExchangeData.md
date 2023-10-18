---
title: IBybitRestClientApiExchangeData
has_children: false
parent: IBybitRestClientV5
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BybitRestClient > V5 > ApiExchangeData`  
*Bybit exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.*
  

***

## GetAnnouncementsAsync  

[https://bybit-exchange.github.io/docs/v5/announcement](https://bybit-exchange.github.io/docs/v5/announcement)  
<p>

*Get server announcements*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiExchangeData.GetAnnouncementsAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitAnnouncement>>> GetAnnouncementsAsync(string locale, string? type = default, string? tag = default, int? page = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|locale|Language|
|_[Optional]_ type|Filter by type|
|_[Optional]_ tag|Filter by tag|
|_[Optional]_ page|Page|
|_[Optional]_ limit|Page size|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetDeliveryPriceAsync  

[https://bybit-exchange.github.io/docs/v5/market/delivery-price](https://bybit-exchange.github.io/docs/v5/market/delivery-price)  
<p>

*Get delivery price*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiExchangeData.GetDeliveryPriceAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitDeliveryPrice>>> GetDeliveryPriceAsync(Category category, string? symbol = default, string? baseAsset = default, int? limit = default, string? cursor = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|_[Optional]_ symbol|Filter by symbol|
|_[Optional]_ baseAsset|Filter by base asset|
|_[Optional]_ limit|Number of results per page|
|_[Optional]_ cursor|Pagination cursor|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetFundingRateHistoryAsync  

[https://bybit-exchange.github.io/docs/v5/market/history-fund-rate](https://bybit-exchange.github.io/docs/v5/market/history-fund-rate)  
<p>

*Get funding rate history*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiExchangeData.GetFundingRateHistoryAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitFundingHistory>>> GetFundingRateHistoryAsync(Category category, string symbol, DateTime? startTime = default, DateTime? endTime = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|symbol|Symbol|
|_[Optional]_ startTime|Fitler by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ limit|Number of results|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetHistoricalVolatilityAsync  

[https://bybit-exchange.github.io/docs/v5/market/iv](https://bybit-exchange.github.io/docs/v5/market/iv)  
<p>

*Get historical volatility*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiExchangeData.GetHistoricalVolatilityAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitHistoricalVolatility>>> GetHistoricalVolatilityAsync(Category category, string? baseAsset = default, int? period = default, DateTime? startTime = default, DateTime? endTime = default, int? limit = default, string? cursor = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|_[Optional]_ baseAsset|Filter by base asset|
|_[Optional]_ period|Period|
|_[Optional]_ startTime|Fitler by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ limit|Number of results per page|
|_[Optional]_ cursor|Pagination cursor|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetIndexPriceKlinesAsync  

[https://bybit-exchange.github.io/docs/v5/market/index-kline](https://bybit-exchange.github.io/docs/v5/market/index-kline)  
<p>

*Get index price klines*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiExchangeData.GetIndexPriceKlinesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitBasicKline>>> GetIndexPriceKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime? startTime = default, DateTime? endTime = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|symbol|Symbol|
|interval|Kline interval|
|_[Optional]_ startTime|Fitler by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ limit|Number of results|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetInsuranceAsync  

[https://bybit-exchange.github.io/docs/v5/market/insurance](https://bybit-exchange.github.io/docs/v5/market/insurance)  
<p>

*Get insurance pool data*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiExchangeData.GetInsuranceAsync();  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitInsurance>>> GetInsuranceAsync(string? asset = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ asset|Asset|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetKlinesAsync  

[https://bybit-exchange.github.io/docs/v5/market/kline](https://bybit-exchange.github.io/docs/v5/market/kline)  
<p>

*Get klines*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiExchangeData.GetKlinesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitKline>>> GetKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime? startTime = default, DateTime? endTime = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|symbol|Symbol|
|interval|Kline interval|
|_[Optional]_ startTime|Fitler by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ limit|Number of results|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetLeverageTokenMarketAsync  

[https://bybit-exchange.github.io/docs/v5/lt/leverage-token-reference](https://bybit-exchange.github.io/docs/v5/lt/leverage-token-reference)  
<p>

*Get leveraged token market info*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiExchangeData.GetLeverageTokenMarketAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitLeverageTokenMarket>> GetLeverageTokenMarketAsync(string leverageToken, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|leverageToken|Token|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetLeverageTokensAsync  

[https://bybit-exchange.github.io/docs/v5/lt/leverage-token-info](https://bybit-exchange.github.io/docs/v5/lt/leverage-token-info)  
<p>

*Get leverage token info*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiExchangeData.GetLeverageTokensAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitLeverageToken>>> GetLeverageTokensAsync(string? leverageToken = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ leverageToken|Filter by token|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetLinearInverseSymbolsAsync  

[https://bybit-exchange.github.io/docs/v5/market/instrument](https://bybit-exchange.github.io/docs/v5/market/instrument)  
<p>

*Get linear/inverse symbols*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiExchangeData.GetLinearInverseSymbolsAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitLinearInverseSymbol>>> GetLinearInverseSymbolsAsync(Category category, string? symbol = default, string? baseAsset = default, int? limit = default, string? cursor = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|_[Optional]_ symbol|Symbol|
|_[Optional]_ baseAsset|Base asset|
|_[Optional]_ limit|Number of results per page|
|_[Optional]_ cursor|Pagination cursor|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetLinearInverseTickersAsync  

[https://bybit-exchange.github.io/docs/v5/market/tickers](https://bybit-exchange.github.io/docs/v5/market/tickers)  
<p>

*Get linear/inverse tickers*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiExchangeData.GetLinearInverseTickersAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitLinearInverseTicker>>> GetLinearInverseTickersAsync(Category category, string? symbol = default, string? baseAsset = default, string? expirationDate = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|_[Optional]_ symbol|Symbol|
|_[Optional]_ baseAsset|Base asset|
|_[Optional]_ expirationDate|Expiration date|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetMarkPriceKlinesAsync  

[https://bybit-exchange.github.io/docs/v5/market/mark-kline](https://bybit-exchange.github.io/docs/v5/market/mark-kline)  
<p>

*Get mark price klines*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiExchangeData.GetMarkPriceKlinesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitBasicKline>>> GetMarkPriceKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime? startTime = default, DateTime? endTime = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|symbol|Symbol|
|interval|Kline interval|
|_[Optional]_ startTime|Fitler by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ limit|Number of results|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOpenInterestAsync  

[https://bybit-exchange.github.io/docs/v5/market/open-interest](https://bybit-exchange.github.io/docs/v5/market/open-interest)  
<p>

*Get open interest*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiExchangeData.GetOpenInterestAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitOpenInterest>>> GetOpenInterestAsync(Category category, string symbol, OpenInterestInterval interestInterval, DateTime? startTime = default, DateTime? endTime = default, int? limit = default, string? cursor = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|symbol|Symbol|
|interestInterval|Interval|
|_[Optional]_ startTime|Fitler by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ limit|Number of results per page|
|_[Optional]_ cursor|Pagination cursor|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOptionSymbolsAsync  

[https://bybit-exchange.github.io/docs/v5/market/instrument](https://bybit-exchange.github.io/docs/v5/market/instrument)  
<p>

*Get option symbols*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiExchangeData.GetOptionSymbolsAsync();  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitOptionSymbol>>> GetOptionSymbolsAsync(string? symbol = default, string? baseAsset = default, int? limit = default, string? cursor = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ symbol|Symbol|
|_[Optional]_ baseAsset|Base asset|
|_[Optional]_ limit|Number of results per page|
|_[Optional]_ cursor|Pagination cursor|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOptionTickersAsync  

[https://bybit-exchange.github.io/docs/v5/market/tickers](https://bybit-exchange.github.io/docs/v5/market/tickers)  
<p>

*Get option tickers*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiExchangeData.GetOptionTickersAsync();  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitOptionTicker>>> GetOptionTickersAsync(string? symbol = default, string? baseAsset = default, string? expirationDate = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ symbol|Filter by symbol|
|_[Optional]_ baseAsset|Filter by asset|
|_[Optional]_ expirationDate|Expiration date|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOrderbookAsync  

[https://bybit-exchange.github.io/docs/v5/market/orderbook](https://bybit-exchange.github.io/docs/v5/market/orderbook)  
<p>

*Get order book*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiExchangeData.GetOrderbookAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitOrderbook>> GetOrderbookAsync(Category category, string symbol, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|symbol|Symbol|
|_[Optional]_ limit|Limit of results|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetPremiumIndexPriceKlinesAsync  

[https://bybit-exchange.github.io/docs/v5/market/preimum-index-kline](https://bybit-exchange.github.io/docs/v5/market/preimum-index-kline)  
<p>

*Get premium index klines*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiExchangeData.GetPremiumIndexPriceKlinesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitBasicKline>>> GetPremiumIndexPriceKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime? startTime = default, DateTime? endTime = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|symbol|Symbol|
|interval|Kline interval|
|_[Optional]_ startTime|Fitler by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ limit|Number of results per page|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetRiskLimitAsync  

<p>

*Get risk limits*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiExchangeData.GetRiskLimitAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitRiskLimit>>> GetRiskLimitAsync(Category category, string? symbol = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|_[Optional]_ symbol|Symbol|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetServerTimeAsync  

[https://bybit-exchange.github.io/docs/v3/server-time](https://bybit-exchange.github.io/docs/v3/server-time)  
<p>

*Get server time*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiExchangeData.GetServerTimeAsync();  
```  

```csharp  
Task<WebCallResult<BybitTime>> GetServerTimeAsync(CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetSpotSymbolsAsync  

[https://bybit-exchange.github.io/docs/v5/market/instrument](https://bybit-exchange.github.io/docs/v5/market/instrument)  
<p>

*Get spot symbols*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiExchangeData.GetSpotSymbolsAsync();  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitSpotSymbol>>> GetSpotSymbolsAsync(string? symbol = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ symbol|Filter by symbol|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetSpotTickersAsync  

[https://bybit-exchange.github.io/docs/v5/market/tickers](https://bybit-exchange.github.io/docs/v5/market/tickers)  
<p>

*Spot tickers*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiExchangeData.GetSpotTickersAsync();  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitSpotTicker>>> GetSpotTickersAsync(string? symbol = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ symbol|Filter by symbol|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetTradeHistoryAsync  

[https://bybit-exchange.github.io/docs/v5/market/recent-trade](https://bybit-exchange.github.io/docs/v5/market/recent-trade)  
<p>

*Get trade history*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiExchangeData.GetTradeHistoryAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitTradeHistory>>> GetTradeHistoryAsync(Category category, string symbol, string? baseAsset = default, OptionType? optionType = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|symbol|Symbol|
|_[Optional]_ baseAsset|Base asset|
|_[Optional]_ optionType|Option type|
|_[Optional]_ limit|Limit of results|
|_[Optional]_ ct|Cancellation token|

</p>
