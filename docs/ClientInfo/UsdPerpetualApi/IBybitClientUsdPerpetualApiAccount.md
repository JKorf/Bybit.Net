---
title: IBybitClientUsdPerpetualApiAccount
has_children: false
parent: IBybitClientUsdPerpetualApi
grand_parent: IBybitClient
---
*[generated documentation]*  
`BybitClient > UsdPerpetualApi > Account`
*Bybit account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings*
  

***

<details>
<summary>
<b>AddReduceMarginAsync</b>  

</summary>
<p>

```C#  
Task<WebCallResult<BybitMarginResult>> AddReduceMarginAsync(string symbol, OrderSide side, decimal margin, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`side`|The side|
|`margin`|Margin to add (positive) or remove (negative)|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Add/reduce margin*  

</p>
</details>

***

<details>
<summary>
<b>GetApiKeyInfoAsync</b>  

[https://bybit-exchange.github.io/docs/linear/#t-key](https://bybit-exchange.github.io/docs/linear/#t-key)  
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

[https://bybit-exchange.github.io/docs/linear/#t-assetexchangerecords](https://bybit-exchange.github.io/docs/linear/#t-assetexchangerecords)  
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

[https://bybit-exchange.github.io/docs/linear/#t-balance](https://bybit-exchange.github.io/docs/linear/#t-balance)  
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
<b>GetPositionAsync</b>  

[https://bybit-exchange.github.io/docs/linear/#t-myposition](https://bybit-exchange.github.io/docs/linear/#t-myposition)  
</summary>
<p>

```C#  
Task<WebCallResult<IEnumerable<BybitPositionUsd>>> GetPositionAsync(string symbol, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
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
<b>GetPositionsAsync</b>  

[https://bybit-exchange.github.io/docs/linear/#t-myposition](https://bybit-exchange.github.io/docs/linear/#t-myposition)  
</summary>
<p>

```C#  
Task<WebCallResult<IEnumerable<BybitPositionUsd>>> GetPositionsAsync([Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get user positions*  

</p>
</details>

***

<details>
<summary>
<b>GetProfitAndLossHistoryAsync</b>  

[https://bybit-exchange.github.io/docs/linear/#t-closedprofitandloss](https://bybit-exchange.github.io/docs/linear/#t-closedprofitandloss)  
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

[https://bybit-exchange.github.io/docs/linear/#t-getrisklimit](https://bybit-exchange.github.io/docs/linear/#t-getrisklimit)  
</summary>
<p>

```C#  
Task<WebCallResult<IEnumerable<BybitRiskLimit>>> GetRiskLimitAsync(string symbol, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
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
<b>GetUserLastFundingFeeAsync</b>  

[https://bybit-exchange.github.io/docs/linear/#t-mylastfundingfee](https://bybit-exchange.github.io/docs/linear/#t-mylastfundingfee)  
</summary>
<p>

```C#  
Task<WebCallResult<BybitFundingSettlement>> GetUserLastFundingFeeAsync(string symbol, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get user last funding fee*  

</p>
</details>

***

<details>
<summary>
<b>GetUserPredictedFundingRateAsync</b>  

[https://bybit-exchange.github.io/docs/linear/#t-predictedfunding](https://bybit-exchange.github.io/docs/linear/#t-predictedfunding)  
</summary>
<p>

```C#  
Task<WebCallResult<BybitPredictedFunding>> GetUserPredictedFundingRateAsync(string symbol, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Get predicted next funding rate*  

</p>
</details>

***

<details>
<summary>
<b>GetWalletFundHistoryAsync</b>  

[https://bybit-exchange.github.io/docs/linear/#t-walletrecords](https://bybit-exchange.github.io/docs/linear/#t-walletrecords)  
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

[https://bybit-exchange.github.io/docs/linear/#t-withdrawrecords](https://bybit-exchange.github.io/docs/linear/#t-withdrawrecords)  
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
<b>SetAutoAddMarginAsync</b>  

[https://bybit-exchange.github.io/docs/linear/#t-setautoaddmargin](https://bybit-exchange.github.io/docs/linear/#t-setautoaddmargin)  
</summary>
<p>

```C#  
Task<WebCallResult> SetAutoAddMarginAsync(string symbol, OrderSide side, bool autoAddMargin, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|Symbol|
|`side`|Side|
|`autoAddMargin`|Auto add or not|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Set auto add margin switch*  

</p>
</details>

***

<details>
<summary>
<b>SetFullPartialPositionModeAsync</b>  

[https://bybit-exchange.github.io/docs/linear/#t-switchmode](https://bybit-exchange.github.io/docs/linear/#t-switchmode)  
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
<b>SetLeverageAsync</b>  

[https://bybit-exchange.github.io/docs/linear/#t-setleverage](https://bybit-exchange.github.io/docs/linear/#t-setleverage)  
</summary>
<p>

```C#  
Task<WebCallResult> SetLeverageAsync(string symbol, int buyLeverage, int sellLeverage, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
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
</details>

***

<details>
<summary>
<b>SetPositionModeAsync</b>  

[https://bybit-exchange.github.io/docs/linear/#t-marginswitch](https://bybit-exchange.github.io/docs/linear/#t-marginswitch)  
</summary>
<p>

```C#  
Task<WebCallResult> SetPositionModeAsync(string symbol, bool isIsolated, decimal buyLeverage, decimal sellLeverage, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`isIsolated`|True is Isolated; false is Cross|
|`buyLeverage`|Buy leverage|
|`sellLeverage`|Sell leverage|
|`receiveWindow`||
|`ct`|Cancellation token|

*Switch Cross/Isolated; must set leverage value when switching from Cross to Isolated*  

</p>
</details>

***

<details>
<summary>
<b>SetRiskLimitAsync</b>  

[https://bybit-exchange.github.io/docs/linear/#t-setrisklimit](https://bybit-exchange.github.io/docs/linear/#t-setrisklimit)  
</summary>
<p>

```C#  
Task<WebCallResult<BybitRiskId>> SetRiskLimitAsync(string symbol, OrderSide side, long riskId, [Optional] long? receiveWindow, [Optional] CancellationToken ct);  
```  

|Parameter|Description|
|---|---|
|`symbol`|The symbol|
|`side`|Side|
|`riskId`|The risk id to set|
|`receiveWindow`|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|`ct`|Cancellation token|

*Set position risk*  

</p>
</details>
