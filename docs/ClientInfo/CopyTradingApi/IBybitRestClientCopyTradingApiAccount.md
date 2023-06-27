---
title: IBybitRestClientCopyTradingApiAccount
has_children: false
parent: IBybitRestClientCopyTradingApi
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BybitRestClient > CopyTradingApi > Account`  
*Bybit account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings*
  

***

## GetBalancesAsync  

[https://bybit-exchange.github.io/docs/copy_trading/#t-ct_wallet_balance](https://bybit-exchange.github.io/docs/copy_trading/#t-ct_wallet_balance)  
<p>

*Get the current wallet balance*  

```csharp  
var client = new BybitRestClient();  
var result = await client.CopyTradingApi.Account.GetBalancesAsync();  
```  

```csharp  
Task<WebCallResult<BybitCopyTradingBalance>> GetBalancesAsync(CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ ct|Cancellation token|

</p>

***

## TransferAsync  

[https://bybit-exchange.github.io/docs/copy_trading/#t-ct_wallet_transfer](https://bybit-exchange.github.io/docs/copy_trading/#t-ct_wallet_transfer)  
<p>

*Transfer to or from the Copy Trading account*  

```csharp  
var client = new BybitRestClient();  
var result = await client.CopyTradingApi.Account.TransferAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitCopyTradingTransfer>> TransferAsync(string transferId, string asset, decimal quantity, AccountType fromAccount, AccountType toAccount, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|transferId|Uninque id|
|asset|Asset to transfer|
|quantity|Quantity to transfer|
|fromAccount|From account type|
|toAccount|To account type|
|_[Optional]_ ct|Cancellation token|

</p>
