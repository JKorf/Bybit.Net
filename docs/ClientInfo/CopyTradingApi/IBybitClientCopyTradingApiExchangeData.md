---
title: IBybitClientCopyTradingApiExchangeData
has_children: false
parent: IBybitClientCopyTradingApi
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BybitClient > CopyTradingApi > ExchangeData`  
*Bybit Copy Trading exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.*
  

***

## GetServerTimeAsync  

[https://bybit-exchange.github.io/docs/copy_trading/#t-servertime](https://bybit-exchange.github.io/docs/copy_trading/#t-servertime)  
<p>

*Retrieve the server timestamp*  

```csharp  
var client = new BybitClient();  
var result = await client.CopyTradingApi.ExchangeData.GetServerTimeAsync();  
```  

```csharp  
Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ ct||

</p>

***

## GetSymbolsAsync  

[https://bybit-exchange.github.io/docs/copy_trading/#t-ct_symbol_list](https://bybit-exchange.github.io/docs/copy_trading/#t-ct_symbol_list)  
<p>

*Get a list of supported symbols*  

```csharp  
var client = new BybitClient();  
var result = await client.CopyTradingApi.ExchangeData.GetSymbolsAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitCopyTradingSymbol>>> GetSymbolsAsync(CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ ct|Cancellation token|

</p>
