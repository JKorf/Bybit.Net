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

<details>
<summary>
<b>ChangeMarginAsync</b>  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-changemargin](https://bybit-exchange.github.io/docs/inverse_futures/#t-changemargin)  
</summary>
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
</details>

***

<details>
<summary>
<b>GetApiKeyInfoAsync</b>  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-key](https://bybit-exchange.github.io/docs/inverse_futures/#t-key)  
</summary>
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
</details>

***

<details>
<summary>
<b>GetAssetExchangeHistoryAsync</b>  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-assetexchangerecords](https://bybit-exchange.github.io/docs/inverse_futures/#t-assetexchangerecords)  
</summary>
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
</details>

***

<details>
<summary>
<b>GetBalancesAsync</b>  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-wallet](https://bybit-exchange.github.io/docs/inverse_futures/#t-wallet)  
</summary>
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
</details>

***

<details>
<summary>
<b>GetPositionsAsync</b>  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-myposition](https://bybit-exchange.github.io/docs/inverse_futures/#t-myposition)  
</summary>
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
</details>

***

<details>
<summary>
<b>GetProfitAndLossHistoryAsync</b>  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-closedprofitandloss](https://bybit-exchange.github.io/docs/inverse_futures/#t-closedprofitandloss)  
</summary>
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
</details>

***

<details>
<summary>
<b>GetRiskLimitAsync</b>  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-getrisklimit](https://bybit-exchange.github.io/docs/inverse_futures/#t-getrisklimit)  
</summary>
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
</details>

***

<details>
<summary>
<b>GetWalletFundHistoryAsync</b>  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-walletrecords](https://bybit-exchange.github.io/docs/inverse_futures/#t-walletrecords)  
</summary>
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
</details>

***

<details>
<summary>
<b>GetWithdrawalHistoryAsync</b>  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-withdrawrecords](https://bybit-exchange.github.io/docs/inverse_futures/#t-withdrawrecords)  
</summary>
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
</details>

***

<details>
<summary>
<b>SetFullPartialPositionModeAsync</b>  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-switchmode](https://bybit-exchange.github.io/docs/inverse_futures/#t-switchmode)  
</summary>
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
</details>

***

<details>
<summary>
<b>SetIsolatedModeAsync</b>  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-marginswitch](https://bybit-exchange.github.io/docs/inverse_futures/#t-marginswitch)  
</summary>
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
</details>

***

<details>
<summary>
<b>SetLeverageAsync</b>  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-setleverage](https://bybit-exchange.github.io/docs/inverse_futures/#t-setleverage)  
</summary>
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
</details>

***

<details>
<summary>
<b>SetPositionModeAsync</b>  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-switchpositionmode](https://bybit-exchange.github.io/docs/inverse_futures/#t-switchpositionmode)  
</summary>
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
</details>

***

<details>
<summary>
<b>SetRiskLimitAsync</b>  

[https://bybit-exchange.github.io/docs/inverse_futures/#t-risklimit](https://bybit-exchange.github.io/docs/inverse_futures/#t-risklimit)  
</summary>
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
</details>
