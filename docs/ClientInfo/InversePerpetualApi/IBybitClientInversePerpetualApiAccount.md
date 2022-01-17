---
title: IBybitClientInversePerpetualApiAccount
has_children: false
parent: IBybitClientInversePerpetualApi
grand_parent: IBybitClient
---
*[generated documentation]*  
`BybitClient > InversePerpetualApi > Account`  
*Bybit account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings*
  

***

## ChangeMarginAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-changemargin](https://bybit-exchange.github.io/docs/inverse/#t-changemargin)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.ChangeMarginAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<decimal>> ChangeMarginAsync(string symbol, PositionMode mode, decimal margin, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`mode`|The position mode|
|`margin`|The margin|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Change margin*  

</p>

***

## GetApiKeyInfoAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-key](https://bybit-exchange.github.io/docs/inverse/#t-key)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.GetApiKeyInfoAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<ByBitApiKeyInfo>>> GetApiKeyInfoAsync([Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get Api key info*  

</p>

***

## GetAssetExchangeHistoryAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-assetexchangerecords](https://bybit-exchange.github.io/docs/inverse/#t-assetexchangerecords)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.GetAssetExchangeHistoryAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitExchangeHistoryEntry>>> GetAssetExchangeHistoryAsync([Optional] long? fromId, [Optional] SearchDirection? direction, [Optional] int? limit, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`fromId`|Filter by id|
|`direction`|Filter by direction|
|`limit`|Max records|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get asset exchange history*  

</p>

***

## GetBalancesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-balance](https://bybit-exchange.github.io/docs/inverse/#t-balance)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.GetBalancesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<Dictionary<string, BybitBalance>>> GetBalancesAsync([Optional] string? asset, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`asset`|Filter by asset|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get wallet balances*  

</p>

***

## GetLastUserFundingFeeAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-mylastfundingfee](https://bybit-exchange.github.io/docs/inverse/#t-mylastfundingfee)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.GetLastUserFundingFeeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitFundingSettlement>> GetLastUserFundingFeeAsync(string symbol, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get user last funding fee*  

</p>

***

## GetPositionsAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-myposition](https://bybit-exchange.github.io/docs/inverse/#t-myposition)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.GetPositionsAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitPosition>>> GetPositionsAsync([Optional] string? symbol, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|Filter by symbol|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get user positions*  

</p>

***

## GetPredictedUserFundingFeeAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-predictedfunding](https://bybit-exchange.github.io/docs/inverse/#t-predictedfunding)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.GetPredictedUserFundingFeeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitPredictedFunding>> GetPredictedUserFundingFeeAsync(string symbol, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get predicted next funding rate*  

</p>

***

## GetProfitAndLossHistoryAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-closedprofitandloss](https://bybit-exchange.github.io/docs/inverse/#t-closedprofitandloss)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.GetProfitAndLossHistoryAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitPage<IEnumerable<BybitPnlEntry>>>> GetProfitAndLossHistoryAsync(string symbol, [Optional] DateTime? startTime, [Optional] DateTime? endTime, [Optional] TradeType? type, [Optional] int? page, [Optional] int? pageSize, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol to get records for|
|`startTime`|Filter by startTime|
|`endTime`|Filter by endTime|
|`type`|Filter by type|
|`page`|Page|
|`pageSize`|Page size|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get user's profit and loss records*  

</p>

***

## GetRiskLimitAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-getrisklimit](https://bybit-exchange.github.io/docs/inverse/#t-getrisklimit)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.GetRiskLimitAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitRiskLimit>>> GetRiskLimitAsync([Optional] string? symbol, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get position risk limit*  

</p>

***

## GetWalletFundHistoryAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-walletrecords](https://bybit-exchange.github.io/docs/inverse/#t-walletrecords)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.GetWalletFundHistoryAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitWalletFundRecord>>> GetWalletFundHistoryAsync([Optional] string? asset, [Optional] DateTime? startTime, [Optional] DateTime? endTime, [Optional] WalletFundType? type, [Optional] int? pageSize, [Optional] int? page, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`asset`|Filter by asset|
|`startTime`|Filter by start time|
|`endTime`|Filter by end time|
|`type`|Filter by type|
|`pageSize`|Page size|
|`page`|Page|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get wallet fund endpoints*  

</p>

***

## GetWithdrawalHistoryAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-withdrawrecords](https://bybit-exchange.github.io/docs/inverse/#t-withdrawrecords)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.GetWithdrawalHistoryAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitWithdrawal>>> GetWithdrawalHistoryAsync([Optional] string? asset, [Optional] DateTime? startTime, [Optional] DateTime? endTime, [Optional] WithdrawStatus? status, [Optional] int? pageSize, [Optional] int? page, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`asset`|Filter by asset|
|`startTime`|Filter by start time|
|`endTime`|Filter by end time|
|`status`|Filter by status|
|`pageSize`|Page size|
|`page`|Page|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get withdrawal history*  

</p>

***

## SetFullPartialPositionModeAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-switchmode](https://bybit-exchange.github.io/docs/inverse/#t-switchmode)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.SetFullPartialPositionModeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitTpSlMode>> SetFullPartialPositionModeAsync(string symbol, StopLossTakeProfitMode mode, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`mode`|New mode|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Switch between full or partial Stop loss/Take profit mode*  

</p>

***

## SetIsolatedModeAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-marginswitch](https://bybit-exchange.github.io/docs/inverse/#t-marginswitch)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.SetIsolatedModeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> SetIsolatedModeAsync(string symbol, bool isIsolated, decimal buyLeverage, decimal sellLeverage, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`isIsolated`|Is isolated|
|`buyLeverage`|Buy leverage|
|`sellLeverage`|Sell leverage|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Switch between cross and isolated mode.*  

</p>

***

## SetLeverageAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-setleverage](https://bybit-exchange.github.io/docs/inverse/#t-setleverage)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.SetLeverageAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<int>> SetLeverageAsync(string symbol, int buyLeverage, int sellLeverage, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`buyLeverage`|Buy leverage|
|`sellLeverage`|Sell leverage|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Set leverage*  

</p>

***

## SetRiskLimitAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-setrisklimit](https://bybit-exchange.github.io/docs/inverse/#t-setrisklimit)  
<p>

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.SetRiskLimitAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitRiskId>> SetRiskLimitAsync(string symbol, long riskId, [Optional] PositionMode? mode, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`riskId`|The risk id to set|
|`mode`|Position mode|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Set position risk*  

</p>
