---
title: IBybitRestClientSpotApiAccountV1
has_children: false
parent: IBybitRestClientSpotApi\v1
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BybitRestClient > SpotApi\v1 > SpotApiAccountV1`  
*[DEPRECATED, WILL STOP WORKING ON 30 OCTOBER, USE V5 API INSTEAD] Bybit account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings*
  

***

## GetBalancesAsync  

[https://bybit-exchange.github.io/docs/spot/v1/#t-balance](https://bybit-exchange.github.io/docs/spot/v1/#t-balance)  
<p>

*Get wallet balances*  

```csharp  
var client = new BybitRestClient();  
var result = await client.SpotApi\v1.SpotApiAccountV1.GetBalancesAsync();  
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
var client = new BybitRestClient();  
var result = await client.SpotApi\v1.SpotApiAccountV1.GetMarginAccountInfoAsync();  
```  

```csharp  
Task<WebCallResult<BybitMarginAccountInfo>> GetMarginAccountInfoAsync(long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>
