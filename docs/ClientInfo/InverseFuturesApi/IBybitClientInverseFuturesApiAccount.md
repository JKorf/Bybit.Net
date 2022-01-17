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

```C#  
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

[https://bybit-exchange.github.io/docs/inverse_futures/#t-key](https://bybit-exchange.github.io/docs/inverse_futures/#t-key)  
<p>

```C#  
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

[https://bybit-exchange.github.io/docs/inverse_futures/#t-assetexchangerecords](https://bybit-exchange.github.io/docs/inverse_futures/#t-assetexchangerecords)  
<p>

```C#  
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

[https://bybit-exchange.github.io/docs/inverse_futures/#t-wallet](https://bybit-exchange.github.io/docs/inverse_futures/#t-wallet)  
<p>

```C#  
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

## GetPositionsAsync  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-myposition](https://bybit-exchange.github.io/docs/inverse_futures/#t-myposition)  
<p>

```C#  
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

## GetProfitAndLossHistoryAsync  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-closedprofitandloss](https://bybit-exchange.github.io/docs/inverse_futures/#t-closedprofitandloss)  
<p>

```C#  
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

[https://bybit-exchange.github.io/docs/inverse_futures/#t-getrisklimit](https://bybit-exchange.github.io/docs/inverse_futures/#t-getrisklimit)  
<p>

```C#  
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

[https://bybit-exchange.github.io/docs/inverse_futures/#t-walletrecords](https://bybit-exchange.github.io/docs/inverse_futures/#t-walletrecords)  
<p>

```C#  
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

[https://bybit-exchange.github.io/docs/inverse_futures/#t-withdrawrecords](https://bybit-exchange.github.io/docs/inverse_futures/#t-withdrawrecords)  
<p>

```C#  
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

[https://bybit-exchange.github.io/docs/inverse_futures/#t-switchmode](https://bybit-exchange.github.io/docs/inverse_futures/#t-switchmode)  
<p>

```C#  
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

[https://bybit-exchange.github.io/docs/inverse_futures/#t-marginswitch](https://bybit-exchange.github.io/docs/inverse_futures/#t-marginswitch)  
<p>

```C#  
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

[https://bybit-exchange.github.io/docs/inverse_futures/#t-setleverage](https://bybit-exchange.github.io/docs/inverse_futures/#t-setleverage)  
<p>

```C#  
Task<WebCallResult<int>> SetLeverageAsync(string symbol, int buyLeverage, int sellLeverage, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`buyLeverage`|Buy leverage|
|`sellLeverage`|Sell leverage|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Set leerage*  

</p>

***

## SetPositionModeAsync  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-switchpositionmode](https://bybit-exchange.github.io/docs/inverse_futures/#t-switchpositionmode)  
<p>

```C#  
Task<WebCallResult> SetPositionModeAsync(string symbol, bool hedgeMode, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`hedgeMode`|Hedgemode|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Switch beteen onway and hedge position mode.*  
*If you are in One-Way Mode, you can only open one position on Buy or Sell side;*  
*If you are in Hedge Mode, you can open both Buy and Sell side positions simultaneously.*  

</p>

***

## SetRiskLimitAsync  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-risklimit](https://bybit-exchange.github.io/docs/inverse_futures/#t-risklimit)  
<p>

```C#  
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
