---
title: IBybitRestClientUsdPerpetualApiAccount
has_children: false
parent: IBybitRestClientUsdPerpetualApi
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BybitRestClient > UsdPerpetualApi > Account`  
*[DEPRECATED, WILL STOP WORKING ON 30 OCTOBER, USE V5 API INSTEAD] Bybit account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and changing account settings*
  

***

## AddReduceMarginAsync  

<p>

*Add/reduce margin*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Account.AddReduceMarginAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitMarginResult>> AddReduceMarginAsync(string symbol, OrderSide side, decimal margin, PositionMode? positionMode = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|side|The side|
|margin|Margin to add (positive) or remove (negative)|
|_[Optional]_ positionMode|Position mode|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetApiKeyInfoAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-key](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-key)  
<p>

*Get Api key info*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Account.GetApiKeyInfoAsync();  
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

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-assetexchangerecords](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-assetexchangerecords)  
<p>

*Get asset exchange history*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Account.GetAssetExchangeHistoryAsync();  
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

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-balance](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-balance)  
<p>

*Get wallet balances*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Account.GetBalancesAsync();  
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

## GetPositionAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-myposition](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-myposition)  
<p>

*Get user positions*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Account.GetPositionAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitPositionUsd>>> GetPositionAsync(string symbol, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Filter by symbol|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetPositionsAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-myposition](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-myposition)  
<p>

*Get user positions*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Account.GetPositionsAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitPositionUsd>>> GetPositionsAsync(long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetProfitAndLossHistoryAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-closedprofitandloss](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-closedprofitandloss)  
<p>

*Get user's profit and loss records*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Account.GetProfitAndLossHistoryAsync(/* parameters */);  
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

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-getrisklimit](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-getrisklimit)  
<p>

*Get position risk limit*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Account.GetRiskLimitAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitRiskLimit>>> GetRiskLimitAsync(string symbol, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetUserLastFundingFeeAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-mylastfundingfee](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-mylastfundingfee)  
<p>

*Get user last funding fee*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Account.GetUserLastFundingFeeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitFundingSettlement>> GetUserLastFundingFeeAsync(string symbol, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetUserPredictedFundingRateAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-predictedfunding](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-predictedfunding)  
<p>

*Get predicted next funding rate*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Account.GetUserPredictedFundingRateAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitPredictedFunding>> GetUserPredictedFundingRateAsync(string symbol, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetWalletFundHistoryAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-walletrecords](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-walletrecords)  
<p>

*Get wallet fund endpoints*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Account.GetWalletFundHistoryAsync();  
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

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-withdrawrecords](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-withdrawrecords)  
<p>

*Get withdrawal history*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Account.GetWithdrawalHistoryAsync();  
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

## SetAutoAddMarginAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-setautoaddmargin](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-setautoaddmargin)  
<p>

*Set auto add margin switch*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Account.SetAutoAddMarginAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> SetAutoAddMarginAsync(string symbol, OrderSide side, bool autoAddMargin, PositionMode? positionMode = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|side|Side|
|autoAddMargin|Auto add or not|
|_[Optional]_ positionMode|Position mode|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetFullPartialPositionModeAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-switchmode](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-switchmode)  
<p>

*Switch between full or partial Stop loss/Take profit mode*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Account.SetFullPartialPositionModeAsync(/* parameters */);  
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

## SetIsolatedPositionModeAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-marginswitch](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-marginswitch)  
<p>

*Switch Cross/Isolated; must set leverage value when switching from Cross to Isolated*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Account.SetIsolatedPositionModeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> SetIsolatedPositionModeAsync(string symbol, bool isIsolated, decimal buyLeverage, decimal sellLeverage, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|isIsolated|True is Isolated; false is Cross|
|buyLeverage|Buy leverage|
|sellLeverage|Sell leverage|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetLeverageAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-setleverage](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-setleverage)  
<p>

*Set leverage*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Account.SetLeverageAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> SetLeverageAsync(string symbol, decimal buyLeverage, decimal sellLeverage, long? receiveWindow = default, CancellationToken ct = default);  
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

## SetPositionModeAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-switchpositionmode](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-switchpositionmode)  
<p>

*Switch position mode. If you are in One-Way Mode, you can only open one position on Buy or Sell side;*  
*If you are in Hedge Mode, you can open both Buy and Sell side positions simultaneously.*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Account.SetPositionModeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> SetPositionModeAsync(string symbol, string asset, bool hedgeMode, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol. Required if not passing coin|
|asset|Currency alias. Required if not passing symbol|
|hedgeMode|True = HedgeMode, False = OneWayMode|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetRiskLimitAsync  

[https://bybit-exchange.github.io/docs/futuresV2/linear/#t-setrisklimit](https://bybit-exchange.github.io/docs/futuresV2/linear/#t-setrisklimit)  
<p>

*Set position risk*  

```csharp  
var client = new BybitRestClient();  
var result = await client.UsdPerpetualApi.Account.SetRiskLimitAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitRiskId>> SetRiskLimitAsync(string symbol, OrderSide side, long riskId, PositionMode? positionMode = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|side|Side|
|riskId|The risk id to set|
|_[Optional]_ positionMode|Position mode|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>
