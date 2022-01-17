---
title: IBybitClientInverseFuturesApiAccount
has_children: false
parent: IBybitClientInverseFuturesApi
grand_parent: IBybitClient
---
*[generated documentation]*  
`BybitClient > InverseFuturesApi > Account`  
*Bybit account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings*
  

***

## ChangeMarginAsync  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-changemargin](https://bybit-exchange.github.io/docs/inverse_futures/#t-changemargin)  
<p>

*Change margin*  

```csharp  
var client = new BybitClient();  
var result = await client.InverseFuturesApi.Account.ChangeMarginAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<decimal>> ChangeMarginAsync(string symbol, PositionMode mode, decimal margin, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
| `symbol`|The symbol|
| `mode`|The position mode|
| `margin`|The margin|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## GetApiKeyInfoAsync  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-key](https://bybit-exchange.github.io/docs/inverse_futures/#t-key)  
<p>

*Get Api key info*  

```csharp  
var client = new BybitClient();  
var result = await client.InverseFuturesApi.Account.GetApiKeyInfoAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<ByBitApiKeyInfo>>> GetApiKeyInfoAsync(long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## GetAssetExchangeHistoryAsync  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-assetexchangerecords](https://bybit-exchange.github.io/docs/inverse_futures/#t-assetexchangerecords)  
<p>

*Get asset exchange history*  

```csharp  
var client = new BybitClient();  
var result = await client.InverseFuturesApi.Account.GetAssetExchangeHistoryAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitExchangeHistoryEntry>>> GetAssetExchangeHistoryAsync(long? fromId = default, SearchDirection? direction = default, int? limit = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|[Optional] `fromId`|Filter by id|
|[Optional] `direction`|Filter by direction|
|[Optional] `limit`|Max records|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## GetBalancesAsync  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-wallet](https://bybit-exchange.github.io/docs/inverse_futures/#t-wallet)  
<p>

*Get wallet balances*  

```csharp  
var client = new BybitClient();  
var result = await client.InverseFuturesApi.Account.GetBalancesAsync();  
```  

```csharp  
Task<WebCallResult<Dictionary<string, BybitBalance>>> GetBalancesAsync(string? asset = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|[Optional] `asset`|Filter by asset|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## GetPositionsAsync  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-myposition](https://bybit-exchange.github.io/docs/inverse_futures/#t-myposition)  
<p>

*Get user positions*  

```csharp  
var client = new BybitClient();  
var result = await client.InverseFuturesApi.Account.GetPositionsAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitPosition>>> GetPositionsAsync(string? symbol = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|[Optional] `symbol`|Filter by symbol|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## GetProfitAndLossHistoryAsync  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-closedprofitandloss](https://bybit-exchange.github.io/docs/inverse_futures/#t-closedprofitandloss)  
<p>

*Get user's profit and loss records*  

```csharp  
var client = new BybitClient();  
var result = await client.InverseFuturesApi.Account.GetProfitAndLossHistoryAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitPage<IEnumerable<BybitPnlEntry>>>> GetProfitAndLossHistoryAsync(string symbol, DateTime? startTime = default, DateTime? endTime = default, TradeType? type = default, int? page = default, int? pageSize = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
| `symbol`|The symbol to get records for|
|[Optional] `startTime`|Filter by startTime|
|[Optional] `endTime`|Filter by endTime|
|[Optional] `type`|Filter by type|
|[Optional] `page`|Page|
|[Optional] `pageSize`|Page size|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## GetRiskLimitAsync  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-getrisklimit](https://bybit-exchange.github.io/docs/inverse_futures/#t-getrisklimit)  
<p>

*Get position risk limit*  

```csharp  
var client = new BybitClient();  
var result = await client.InverseFuturesApi.Account.GetRiskLimitAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitRiskLimit>>> GetRiskLimitAsync(string? symbol = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|[Optional] `symbol`|The symbol|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## GetWalletFundHistoryAsync  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-walletrecords](https://bybit-exchange.github.io/docs/inverse_futures/#t-walletrecords)  
<p>

*Get wallet fund endpoints*  

```csharp  
var client = new BybitClient();  
var result = await client.InverseFuturesApi.Account.GetWalletFundHistoryAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitWalletFundRecord>>> GetWalletFundHistoryAsync(string? asset = default, DateTime? startTime = default, DateTime? endTime = default, WalletFundType? type = default, int? pageSize = default, int? page = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|[Optional] `asset`|Filter by asset|
|[Optional] `startTime`|Filter by start time|
|[Optional] `endTime`|Filter by end time|
|[Optional] `type`|Filter by type|
|[Optional] `pageSize`|Page size|
|[Optional] `page`|Page|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## GetWithdrawalHistoryAsync  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-withdrawrecords](https://bybit-exchange.github.io/docs/inverse_futures/#t-withdrawrecords)  
<p>

*Get withdrawal history*  

```csharp  
var client = new BybitClient();  
var result = await client.InverseFuturesApi.Account.GetWithdrawalHistoryAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitWithdrawal>>> GetWithdrawalHistoryAsync(string? asset = default, DateTime? startTime = default, DateTime? endTime = default, WithdrawStatus? status = default, int? pageSize = default, int? page = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|[Optional] `asset`|Filter by asset|
|[Optional] `startTime`|Filter by start time|
|[Optional] `endTime`|Filter by end time|
|[Optional] `status`|Filter by status|
|[Optional] `pageSize`|Page size|
|[Optional] `page`|Page|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## SetFullPartialPositionModeAsync  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-switchmode](https://bybit-exchange.github.io/docs/inverse_futures/#t-switchmode)  
<p>

*Switch between full or partial Stop loss/Take profit mode*  

```csharp  
var client = new BybitClient();  
var result = await client.InverseFuturesApi.Account.SetFullPartialPositionModeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitTpSlMode>> SetFullPartialPositionModeAsync(string symbol, StopLossTakeProfitMode mode, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
| `symbol`|The symbol|
| `mode`|New mode|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## SetIsolatedModeAsync  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-marginswitch](https://bybit-exchange.github.io/docs/inverse_futures/#t-marginswitch)  
<p>

*Switch between cross and isolated mode.*  

```csharp  
var client = new BybitClient();  
var result = await client.InverseFuturesApi.Account.SetIsolatedModeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> SetIsolatedModeAsync(string symbol, bool isIsolated, decimal buyLeverage, decimal sellLeverage, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
| `symbol`|The symbol|
| `isIsolated`|Is isolated|
| `buyLeverage`|Buy leverage|
| `sellLeverage`|Sell leverage|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## SetLeverageAsync  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-setleverage](https://bybit-exchange.github.io/docs/inverse_futures/#t-setleverage)  
<p>

*Set leerage*  

```csharp  
var client = new BybitClient();  
var result = await client.InverseFuturesApi.Account.SetLeverageAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<int>> SetLeverageAsync(string symbol, int buyLeverage, int sellLeverage, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
| `symbol`|The symbol|
| `buyLeverage`|Buy leverage|
| `sellLeverage`|Sell leverage|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## SetPositionModeAsync  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-switchpositionmode](https://bybit-exchange.github.io/docs/inverse_futures/#t-switchpositionmode)  
<p>

*Switch beteen onway and hedge position mode.*  
*If you are in One-Way Mode, you can only open one position on Buy or Sell side;*  
*If you are in Hedge Mode, you can open both Buy and Sell side positions simultaneously.*  

```csharp  
var client = new BybitClient();  
var result = await client.InverseFuturesApi.Account.SetPositionModeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> SetPositionModeAsync(string symbol, bool hedgeMode, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
| `symbol`|The symbol|
| `hedgeMode`|Hedgemode|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>

***

## SetRiskLimitAsync  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-risklimit](https://bybit-exchange.github.io/docs/inverse_futures/#t-risklimit)  
<p>

*Set position risk*  

```csharp  
var client = new BybitClient();  
var result = await client.InverseFuturesApi.Account.SetRiskLimitAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitRiskId>> SetRiskLimitAsync(string symbol, long riskId, PositionMode? mode = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
| `symbol`|The symbol|
| `riskId`|The risk id to set|
|[Optional] `mode`|Position mode|
|[Optional] `receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|[Optional] `ct`|Cancellation token|

</p>
