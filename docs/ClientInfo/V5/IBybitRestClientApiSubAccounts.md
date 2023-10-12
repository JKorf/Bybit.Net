---
title: IBybitRestClientApiSubAccounts
has_children: false
parent: IBybitRestClientV5
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BybitRestClient > V5 > ApiSubAccounts`  
*Bybit sub account endpoints*
  

***

## CreateSubAccountApiKeyAsync  

[https://bybit-exchange.github.io/docs/v5/user/create-subuid-apikey](https://bybit-exchange.github.io/docs/v5/user/create-subuid-apikey)  
<p>

*Create a new API key for a sub account*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiSubAccounts.CreateSubAccountApiKeyAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitApiKeyInfo>> CreateSubAccountApiKeyAsync(string subAccountId, bool readOnly, bool? permissionContractTradeOrder = default, bool? permissionContractTradePosition = default, bool? permissionSpotTrade = default, bool? permissionWalletTransfer = default, bool? permissionWalletSubAccountTransfer = default, bool? permissionOptionsTrade = default, bool? permissionExchangeHistory = default, bool? permissionCopyTrading = default, string? ipRestrictions = default, string? note = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|subAccountId|Subaccount id|
|readOnly|Readonly key|
|_[Optional]_ permissionContractTradeOrder|Has contract order permission|
|_[Optional]_ permissionContractTradePosition|Has contract position permission|
|_[Optional]_ permissionSpotTrade|Has spot trade permission|
|_[Optional]_ permissionWalletTransfer|Has wallet transfer permission|
|_[Optional]_ permissionWalletSubAccountTransfer|Has permission wallet subaccount transfer permission|
|_[Optional]_ permissionOptionsTrade|Has option trade permission|
|_[Optional]_ permissionExchangeHistory|Has exchange history permission|
|_[Optional]_ permissionCopyTrading|Has copy trade permission|
|_[Optional]_ ipRestrictions|Ip restrictions, comma seperated|
|_[Optional]_ note|Note|
|_[Optional]_ ct|Cancelation token|

</p>

***

## CreateSubAccountAsync  

[https://bybit-exchange.github.io/docs/v5/user/create-subuid](https://bybit-exchange.github.io/docs/v5/user/create-subuid)  
<p>

*Create a new sub account*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiSubAccounts.CreateSubAccountAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitSubAccount>> CreateSubAccountAsync(string username, SubAccountType type, string? password = default, bool? enableQuickLogin = default, bool? isUta = default, string? note = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|username|Username|
|type|Account type|
|_[Optional]_ password|Password, 8-30 characters, must include numbers, upper and lowercase letters|
|_[Optional]_ enableQuickLogin|Enable quick login|
|_[Optional]_ isUta|Uta account|
|_[Optional]_ note|Set a remark|
|_[Optional]_ ct|Cancelation token|

</p>

***

## DeleteSubAccountApiKeyAsync  

[https://bybit-exchange.github.io/docs/v5/user/rm-sub-apikey](https://bybit-exchange.github.io/docs/v5/user/rm-sub-apikey)  
<p>

*Delete an API key*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiSubAccounts.DeleteSubAccountApiKeyAsync();  
```  

```csharp  
Task<WebCallResult> DeleteSubAccountApiKeyAsync(string? apiKey = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ apiKey|Api key, should be passed if deleting from Master account, should be null if editing own API key from sub account|
|_[Optional]_ ct|Cancelation token|

</p>

***

## EditSubAccountApiKeyAsync  

[https://bybit-exchange.github.io/docs/v5/user/modify-sub-apikey](https://bybit-exchange.github.io/docs/v5/user/modify-sub-apikey)  
<p>

*Edit API key*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiSubAccounts.EditSubAccountApiKeyAsync();  
```  

```csharp  
Task<WebCallResult<BybitApiKeyInfo>> EditSubAccountApiKeyAsync(string? apiKey = default, bool? readOnly = default, string? ipRestrictions = default, bool? permissionContractTradeOrder = default, bool? permissionContractTradePosition = default, bool? permissionSpotTrade = default, bool? permissionWalletTransfer = default, bool? permissionWalletSubAccountTransfer = default, bool? permissionOptionsTrade = default, bool? permissionCopyTrading = default, bool? permissionExchangeHistory = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ apiKey|Api key, should be passed if editing from Master account, should be null if editing own API key from sub account|
|_[Optional]_ readOnly|Readonly|
|_[Optional]_ ipRestrictions|IP restrictions, comma seperated|
|_[Optional]_ permissionContractTradeOrder|Has contract order permission|
|_[Optional]_ permissionContractTradePosition|Has contract position permission|
|_[Optional]_ permissionSpotTrade|Has spot trade permission|
|_[Optional]_ permissionWalletTransfer|Has wallet transfer permission|
|_[Optional]_ permissionWalletSubAccountTransfer|Has permission wallet subaccount transfer permission|
|_[Optional]_ permissionOptionsTrade|Has option trade permission|
|_[Optional]_ permissionCopyTrading|Has copy trade permission|
|_[Optional]_ permissionExchangeHistory|Has exchange history permission|
|_[Optional]_ ct|Cancelation token|

</p>

***

## GetSubAccountsAsync  

[https://bybit-exchange.github.io/docs/v5/user/subuid-list](https://bybit-exchange.github.io/docs/v5/user/subuid-list)  
<p>

*Get list of subaccounts*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiSubAccounts.GetSubAccountsAsync();  
```  

```csharp  
Task<WebCallResult<List<BybitSubAccount>>> GetSubAccountsAsync(CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ ct|Cancelation token|

</p>
