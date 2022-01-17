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

*Change margin*  

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.ChangeMarginAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<decimal>> ChangeMarginAsync(string symbol, PositionMode mode, decimal margin, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|mode|The position mode|
|margin|The margin|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetApiKeyInfoAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-key](https://bybit-exchange.github.io/docs/inverse/#t-key)  
<p>

*Get Api key info*  

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.GetApiKeyInfoAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<ByBitApiKeyInfo>>> GetApiKeyInfoAsync(long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetAssetExchangeHistoryAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-assetexchangerecords](https://bybit-exchange.github.io/docs/inverse/#t-assetexchangerecords)  
<p>

*Get asset exchange history*  

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.GetAssetExchangeHistoryAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitExchangeHistoryEntry>>> GetAssetExchangeHistoryAsync(long? fromId = default, SearchDirection? direction = default, int? limit = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ fromId|Filter by id|
|_[Optional]_ direction|Filter by direction|
|_[Optional]_ limit|Max records|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetBalancesAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-balance](https://bybit-exchange.github.io/docs/inverse/#t-balance)  
<p>

*Get wallet balances*  

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.GetBalancesAsync();  
```  

```csharp  
Task<WebCallResult<Dictionary<string, BybitBalance>>> GetBalancesAsync(string? asset = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ asset|Filter by asset|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetLastUserFundingFeeAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-mylastfundingfee](https://bybit-exchange.github.io/docs/inverse/#t-mylastfundingfee)  
<p>

*Get user last funding fee*  

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.GetLastUserFundingFeeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitFundingSettlement>> GetLastUserFundingFeeAsync(string symbol, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetPositionsAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-myposition](https://bybit-exchange.github.io/docs/inverse/#t-myposition)  
<p>

*Get user positions*  

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.GetPositionsAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitPosition>>> GetPositionsAsync(string? symbol = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ symbol|Filter by symbol|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetPredictedUserFundingFeeAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-predictedfunding](https://bybit-exchange.github.io/docs/inverse/#t-predictedfunding)  
<p>

*Get predicted next funding rate*  

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.GetPredictedUserFundingFeeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitPredictedFunding>> GetPredictedUserFundingFeeAsync(string symbol, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetProfitAndLossHistoryAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-closedprofitandloss](https://bybit-exchange.github.io/docs/inverse/#t-closedprofitandloss)  
<p>

*Get user's profit and loss records*  

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.GetProfitAndLossHistoryAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitPage<IEnumerable<BybitPnlEntry>>>> GetProfitAndLossHistoryAsync(string symbol, DateTime? startTime = default, DateTime? endTime = default, TradeType? type = default, int? page = default, int? pageSize = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol to get records for|
|_[Optional]_ startTime|Filter by startTime|
|_[Optional]_ endTime|Filter by endTime|
|_[Optional]_ type|Filter by type|
|_[Optional]_ page|Page|
|_[Optional]_ pageSize|Page size|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetRiskLimitAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-getrisklimit](https://bybit-exchange.github.io/docs/inverse/#t-getrisklimit)  
<p>

*Get position risk limit*  

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.GetRiskLimitAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitRiskLimit>>> GetRiskLimitAsync(string? symbol = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ symbol|The symbol|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetWalletFundHistoryAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-walletrecords](https://bybit-exchange.github.io/docs/inverse/#t-walletrecords)  
<p>

*Get wallet fund endpoints*  

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.GetWalletFundHistoryAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitWalletFundRecord>>> GetWalletFundHistoryAsync(string? asset = default, DateTime? startTime = default, DateTime? endTime = default, WalletFundType? type = default, int? pageSize = default, int? page = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ asset|Filter by asset|
|_[Optional]_ startTime|Filter by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ type|Filter by type|
|_[Optional]_ pageSize|Page size|
|_[Optional]_ page|Page|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetWithdrawalHistoryAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-withdrawrecords](https://bybit-exchange.github.io/docs/inverse/#t-withdrawrecords)  
<p>

*Get withdrawal history*  

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.GetWithdrawalHistoryAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitWithdrawal>>> GetWithdrawalHistoryAsync(string? asset = default, DateTime? startTime = default, DateTime? endTime = default, WithdrawStatus? status = default, int? pageSize = default, int? page = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ asset|Filter by asset|
|_[Optional]_ startTime|Filter by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ status|Filter by status|
|_[Optional]_ pageSize|Page size|
|_[Optional]_ page|Page|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetFullPartialPositionModeAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-switchmode](https://bybit-exchange.github.io/docs/inverse/#t-switchmode)  
<p>

*Switch between full or partial Stop loss/Take profit mode*  

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.SetFullPartialPositionModeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitTpSlMode>> SetFullPartialPositionModeAsync(string symbol, StopLossTakeProfitMode mode, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|mode|New mode|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetIsolatedModeAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-marginswitch](https://bybit-exchange.github.io/docs/inverse/#t-marginswitch)  
<p>

*Switch between cross and isolated mode.*  

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.SetIsolatedModeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> SetIsolatedModeAsync(string symbol, bool isIsolated, decimal buyLeverage, decimal sellLeverage, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|isIsolated|Is isolated|
|buyLeverage|Buy leverage|
|sellLeverage|Sell leverage|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetLeverageAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-setleverage](https://bybit-exchange.github.io/docs/inverse/#t-setleverage)  
<p>

*Set leverage*  

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.SetLeverageAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<int>> SetLeverageAsync(string symbol, int buyLeverage, int sellLeverage, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|buyLeverage|Buy leverage|
|sellLeverage|Sell leverage|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetRiskLimitAsync  

[https://bybit-exchange.github.io/docs/inverse/#t-setrisklimit](https://bybit-exchange.github.io/docs/inverse/#t-setrisklimit)  
<p>

*Set position risk*  

```csharp  
var client = new BybitClient();  
var result = await client.InversePerpetualApi.Account.SetRiskLimitAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitRiskId>> SetRiskLimitAsync(string symbol, long riskId, PositionMode? mode = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|riskId|The risk id to set|
|_[Optional]_ mode|Position mode|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>
