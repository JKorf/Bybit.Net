---
title: IBybitClientSpotApiAccount
parent: IBybitClientSpotApi
---
*[generated documentation]*  
`BybitClient > SpotApi > Account`
*Bybit account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings*
  

***

<details>
<summary>
<b>GetBalancesAsync</b>  

[https://bybit-exchange.github.io/docs/spot/#t-balance](https://bybit-exchange.github.io/docs/spot/#t-balance)  
</summary>
<p>

```C#  
Task<WebCallResult<IEnumerable<BybitSpotBalance>>> GetBalancesAsync([Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get wallet balances*  

</p>
</details>
