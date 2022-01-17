---
title: IBybitClientGeneralApiTransfer
has_children: false
parent: IBybitClientGeneralApi
grand_parent: IBybitClient
---
*[generated documentation]*  
`BybitClient > GeneralApi > Transfer`  
*Bybit asset transfer endpoints*
  

***

## CreateInternalTransferAsync  

[https://bybit-exchange.github.io/docs/account_asset/#t-createinternaltransfer](https://bybit-exchange.github.io/docs/account_asset/#t-createinternaltransfer)  
<p>

```csharp  
Task<WebCallResult<BybitTransfer>> CreateInternalTransferAsync(string transferId, string asset, decimal quantity, AccountType fromAccountType, AccountType toAccountType, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`transferId`|A generated UUID, should be unique|
|`asset`|The asset to transfer|
|`quantity`|Quantity to transfer|
|`fromAccountType`|From account|
|`toAccountType`|To account|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Create a new transfer from one account type to the other*  

</p>

***

## CreateSubAccountTransferAsync  

[https://bybit-exchange.github.io/docs/account_asset/#t-createsubaccounttransfer](https://bybit-exchange.github.io/docs/account_asset/#t-createsubaccounttransfer)  
<p>

```csharp  
Task<WebCallResult<BybitTransfer>> CreateSubAccountTransferAsync(string transferId, string asset, decimal quantity, string subAccountId, TransferType type, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`transferId`|A generated UUID, should be unique|
|`asset`|The asset to transfer|
|`quantity`|Quantity to transfer|
|`subAccountId`|The sub account id|
|`type`|The type of the transfer|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Create a new transfer for a subaccount*  

</p>

***

## GetSubAccountsAsync  

<p>

```csharp  
Task<WebCallResult<BybitSubAccountList>> GetSubAccountsAsync([Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get a list of subaccount ids*  

</p>

***

## GetSubAccountTransferHistoryAsync  

[https://bybit-exchange.github.io/docs/account_asset/#t-querysubaccounttransferlist](https://bybit-exchange.github.io/docs/account_asset/#t-querysubaccounttransferlist)  
<p>

```csharp  
Task<WebCallResult<BybitCursorPage<IEnumerable<BybitSubAccountTransferDetails>>>> GetSubAccountTransferHistoryAsync([Optional] string? transferId, [Optional] string? asset, [Optional] TransferStatus? status, [Optional] DateTime? startTime, [Optional] DateTime? endTime, [Optional] SearchDirection? direction, [Optional] int? limit, [Optional] string? cursor, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`transferId`|Filter by transfer id|
|`asset`|Filter by asset|
|`status`|Filter by status|
|`startTime`|Filter by start time|
|`endTime`|Filter by end time|
|`direction`|Filter by direction|
|`limit`|Max amount of results|
|`cursor`|Page cursor|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get history of sub account transfers*  

</p>

***

## GetTransferHistoryAsync  

[https://bybit-exchange.github.io/docs/account_asset/#t-querytransferlist](https://bybit-exchange.github.io/docs/account_asset/#t-querytransferlist)  
<p>

```csharp  
Task<WebCallResult<BybitCursorPage<IEnumerable<BybitInternalTransferDetails>>>> GetTransferHistoryAsync([Optional] string? transferId, [Optional] string? asset, [Optional] TransferStatus? status, [Optional] DateTime? startTime, [Optional] DateTime? endTime, [Optional] SearchDirection? direction, [Optional] int? limit, [Optional] string? cursor, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`transferId`|Filter by transfer id|
|`asset`|Filter by asset|
|`status`|Filter by status|
|`startTime`|Filter by start time|
|`endTime`|Filter by end time|
|`direction`|Filter by direction|
|`limit`|Max amount of results|
|`cursor`|Page cursor|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get history of transfers*  

</p>
