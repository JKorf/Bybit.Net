---
title: IBybitRestClientGeneralApiWithdrawDeposit
has_children: false
parent: IBybitRestClientGeneralApi
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BybitRestClient > GeneralApi > WithdrawDeposit`  
*Bybit withdrawal and deposit endpoints*
  

***

## CancelWithdrawalAsync  

[https://bybit-exchange.github.io/docs/account_asset/#t-cancel_withdraw](https://bybit-exchange.github.io/docs/account_asset/#t-cancel_withdraw)  
<p>

*Cancel withdrawal*  

```csharp  
var client = new BybitRestClient();  
var result = await client.GeneralApi.WithdrawDeposit.CancelWithdrawalAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> CancelWithdrawalAsync(string withdrawalId, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|withdrawalId|Id to cancel|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetAccountInfoAsync  

[https://bybit-exchange.github.io/docs/account_asset/#t-asset_info_query](https://bybit-exchange.github.io/docs/account_asset/#t-asset_info_query)  
<p>

*Get account info*  

```csharp  
var client = new BybitRestClient();  
var result = await client.GeneralApi.WithdrawDeposit.GetAccountInfoAsync();  
```  

```csharp  
Task<WebCallResult<Dictionary<string, BybitGeneralAccountStatus>>> GetAccountInfoAsync(string? asset = default, string? accountType = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ asset|Filter asset|
|_[Optional]_ accountType|Filter account type|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetAssetInfoAsync  

[https://bybit-exchange.github.io/docs/account_asset/#t-coin_info_query](https://bybit-exchange.github.io/docs/account_asset/#t-coin_info_query)  
<p>

*Get asset information regarding withdrawal/deposits*  

```csharp  
var client = new BybitRestClient();  
var result = await client.GeneralApi.WithdrawDeposit.GetAssetInfoAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitAssetInfo>>> GetAssetInfoAsync(string? asset = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ asset|Filter by asset|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetDepositAddressesAsync  

[https://bybit-exchange.github.io/docs/account_asset/#t-deposit_addr_info](https://bybit-exchange.github.io/docs/account_asset/#t-deposit_addr_info)  
<p>

*Get deposit addresses for an asset*  

```csharp  
var client = new BybitRestClient();  
var result = await client.GeneralApi.WithdrawDeposit.GetDepositAddressesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitDepositAddress>> GetDepositAddressesAsync(string asset, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|asset|The asset to get addresses for|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetDepositHistoryAsync  

[https://bybit-exchange.github.io/docs/account_asset/#t-depositsrecordquery](https://bybit-exchange.github.io/docs/account_asset/#t-depositsrecordquery)  
<p>

*Get deposit history*  

```csharp  
var client = new BybitRestClient();  
var result = await client.GeneralApi.WithdrawDeposit.GetDepositHistoryAsync();  
```  

```csharp  
Task<WebCallResult<BybitCursorPage<IEnumerable<BybitDeposit>>>> GetDepositHistoryAsync(string? asset = default, DateTime? startTime = default, DateTime? endTime = default, SearchDirection? direction = default, int? limit = default, string? cursor = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ asset|Filter by asset|
|_[Optional]_ startTime|Filter by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ direction|Filter by direction|
|_[Optional]_ limit|Max amount of results|
|_[Optional]_ cursor|Page cursor|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetSupportedDepositMethodsAsync  

[https://bybit-exchange.github.io/docs/account_asset/#t-allowdepositlist](https://bybit-exchange.github.io/docs/account_asset/#t-allowdepositlist)  
<p>

*Get deposit information*  

```csharp  
var client = new BybitRestClient();  
var result = await client.GeneralApi.WithdrawDeposit.GetSupportedDepositMethodsAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitDepositConfig>>> GetSupportedDepositMethodsAsync(string? asset = default, string? network = default, int? page = default, int? pageSize = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ asset|Filter by asset|
|_[Optional]_ network|Filter by network|
|_[Optional]_ page|Page number|
|_[Optional]_ pageSize|Page size|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetWithdrawalHistoryAsync  

[https://bybit-exchange.github.io/docs/account_asset/#t-withdrawrecordquery](https://bybit-exchange.github.io/docs/account_asset/#t-withdrawrecordquery)  
<p>

*Get withdrawal history*  

```csharp  
var client = new BybitRestClient();  
var result = await client.GeneralApi.WithdrawDeposit.GetWithdrawalHistoryAsync();  
```  

```csharp  
Task<WebCallResult<BybitCursorPage<IEnumerable<BybitWithdraw>>>> GetWithdrawalHistoryAsync(string? withdrawalId = default, string? asset = default, DateTime? startTime = default, DateTime? endTime = default, SearchDirection? direction = default, int? limit = default, string? cursor = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ withdrawalId|Filter by withdrawal id|
|_[Optional]_ asset|Filter by asset|
|_[Optional]_ startTime|Filter by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ direction|Filter by direction|
|_[Optional]_ limit|Max amount of results|
|_[Optional]_ cursor|Page cursor|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## WithdrawAsync  

[https://bybit-exchange.github.io/docs/account_asset/#t-withdraw_info](https://bybit-exchange.github.io/docs/account_asset/#t-withdraw_info)  
<p>

*Create a withdrawal request*  

```csharp  
var client = new BybitRestClient();  
var result = await client.GeneralApi.WithdrawDeposit.WithdrawAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitId>> WithdrawAsync(string asset, string network, string address, decimal quantity, string? tag = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|asset|Asset to withdraw|
|network|Network to use|
|address|Address to withdraw to, should be whitelisted|
|quantity|Quantity to withdraw|
|_[Optional]_ tag|Tag|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>
