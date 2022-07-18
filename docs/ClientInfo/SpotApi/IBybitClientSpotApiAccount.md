---
title: IBybitClientSpotApiAccount
has_children: false
parent: IBybitClientSpotApi
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BybitClient > SpotApi > Account`  
*Bybit account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings*
  

***

## GetBalancesAsync  

[https://bybit-exchange.github.io/docs/spot/#t-balance](https://bybit-exchange.github.io/docs/spot/#t-balance)  
<p>

*Get wallet balances*  

```csharp  
var client = new BybitClient();  
var result = await client.SpotApi.Account.GetBalancesAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitSpotBalance>>> GetBalancesAsync(long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetMarginAccountInfoAsync  

<p>

*Get margin account info*  

```csharp  
var client = new BybitClient();  
var result = await client.SpotApi.Account.GetMarginAccountInfoAsync();  
```  

```csharp  
Task<WebCallResult<BybitMarginAccountInfo>> GetMarginAccountInfoAsync(long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>
