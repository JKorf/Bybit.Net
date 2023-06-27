---
title: IBybitRestClientContractApiAccount
has_children: false
parent: IBybitRestClientDerivativesApi\ContractApi
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BybitRestClient > DerivativesApi\ContractApi > ContractApiAccount`  
*Bybit account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings*
  

***

## GetBalancesAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-balance](https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-balance)  
<p>

*Get wallet balances*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\ContractApi.ContractApiAccount.GetBalancesAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitContractBalance>>> GetBalancesAsync(string? asset = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ asset|Filter by asset|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetPositionAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-dv_myposition](https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-dv_myposition)  
<p>

*Get user positions*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\ContractApi.ContractApiAccount.GetPositionAsync();  
```  

```csharp  
Task<WebCallResult<BybitDerivativesCursorPage<IEnumerable<BybitContractPosition>>>> GetPositionAsync(string? symbol = default, string? settleAsset = default, SettleDataFilter? dataFilter = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ symbol|Filter by symbol|
|_[Optional]_ settleAsset|Settle coin. Either symbol or settleCoin is required. If both are passed, symbol is used first.|
|_[Optional]_ dataFilter|Only work when settleCoin is passed. full: get all positions regardless zero or not based on settle coin. valid: get valid positions based on settle coin|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetProfitAndLossHistoryAsync  

<p>

*Get user's closed profit and loss records. The results are ordered in descending order (the first item is the latest).*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\ContractApi.ContractApiAccount.GetProfitAndLossHistoryAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitCursorPage<IEnumerable<BybitContractClosedPnlEntry>>>> GetProfitAndLossHistoryAsync(string symbol, DateTime? startTime = default, DateTime? endTime = default, int? limit = default, string? cursor = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol| Symbol |
|_[Optional]_ startTime| Start timestamp point for result, in seconds |
|_[Optional]_ endTime| End timestamp point for result, in seconds |
|_[Optional]_ limit| Limit for data size per page, max size is 200. Default as showing 50 pieces of data per page. |
|_[Optional]_ cursor| Page turning mark |
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetTradingFeeRate  

[https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-tradingfeerate](https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-tradingfeerate)  
<p>

*Get user trading fee rate*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\ContractApi.ContractApiAccount.GetTradingFeeRate();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitContractTradingFeeRate>>> GetTradingFeeRate(string? symbol = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ symbol| Symbol |
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetUserTradesAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-usertraderecords](https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-usertraderecords)  
<p>

*Get executed user trades*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\ContractApi.ContractApiAccount.GetUserTradesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitCursorPage<IEnumerable<BybitContractUserTrade>>>> GetUserTradesAsync(string symbol, string? orderId = default, DateTime? startTime = default, DateTime? endTime = default, TradeType? tradeType = default, int? limit = default, string? cursor = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ orderId|Filter by order id|
|_[Optional]_ startTime|Start timestamp in millisecond|
|_[Optional]_ endTime|End timestamp in millisecond|
|_[Optional]_ tradeType|Execution type|
|_[Optional]_ limit|Data quantity per page: Max data value per page is 50, and default value at 20|
|_[Optional]_ cursor|API pass-through|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetWalletFundRecords  

[https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-dv_walletrecords](https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-dv_walletrecords)  
<p>

*Get user trading fee rate*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\ContractApi.ContractApiAccount.GetWalletFundRecords();  
```  

```csharp  
Task<WebCallResult<BybitCursorPage<IEnumerable<BybitContractWalletFundRecord>>>> GetWalletFundRecords(string? asset = default, DateTime? startTime = default, DateTime? endTime = default, WalletFundType? fundType = default, int? limit = default, string? cursor = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ asset| Coin |
|_[Optional]_ startTime|Start timestamp in milliseconds|
|_[Optional]_ endTime|End timestamp in milliseconds. The past year records ONLY|
|_[Optional]_ fundType|Wallet fund type|
|_[Optional]_ limit|Data quantity per page: Max data value per page is 50, and default value at 20|
|_[Optional]_ cursor|API pass-through|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetAutoAddMarginAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-setautoaddmargin](https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-setautoaddmargin)  
<p>

*Set auto add margin switch*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\ContractApi.ContractApiAccount.SetAutoAddMarginAsync(/* parameters */);  
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

[https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-dv_switchmode](https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-dv_switchmode)  
<p>

*Switch between full or partial Stop loss/Take profit mode*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\ContractApi.ContractApiAccount.SetFullPartialPositionModeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> SetFullPartialPositionModeAsync(string symbol, StopLossTakeProfitMode mode, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|mode|New mode|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetLeverageAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-setleverage](https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-setleverage)  
<p>

*Set leverage*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\ContractApi.ContractApiAccount.SetLeverageAsync(/* parameters */);  
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

## SetMarginMode  

[https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-dv_setmarginmode](https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-dv_setmarginmode)  
<p>

*Get user trading fee rate*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\ContractApi.ContractApiAccount.SetMarginMode(/* parameters */);  
```  

```csharp  
Task<WebCallResult> SetMarginMode(MarginMode marginMode, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|marginMode| Margin mode |
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetPositionModeAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-dv_switchpositionmode](https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-dv_switchpositionmode)  
<p>

*Switch position mode. If you are in One-Way Mode, you can only open one position on Buy or Sell side;*  
*If you are in Hedge Mode, you can open both Buy and Sell side positions simultaneously.*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\ContractApi.ContractApiAccount.SetPositionModeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> SetPositionModeAsync(PositionMode hedgeMode, string? symbol = default, string? asset = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|hedgeMode|Hedge mode. OneWay/Hedge are supported|
|_[Optional]_ symbol|The symbol|
|_[Optional]_ asset|Currency alias|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetRiskLimitAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-setrisklimit](https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-setrisklimit)  
<p>

*Set position risk*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\ContractApi.ContractApiAccount.SetRiskLimitAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> SetRiskLimitAsync(string symbol, long riskId, PositionMode? positionMode = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|riskId|The risk id to set|
|_[Optional]_ positionMode|Position mode|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetTradeModeAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-dv_marginswitch](https://bybit-exchange.github.io/docs/derivativesV3/contract/#t-dv_marginswitch)  
<p>

*Switch cross margin mode/isolated margin mode*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\ContractApi.ContractApiAccount.SetTradeModeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> SetTradeModeAsync(string symbol, TradeMode tradeMode, decimal buyLeverage, decimal sellLeverage, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|tradeMode|Cross/isolated mode|
|buyLeverage|Buy leverage|
|sellLeverage|Sell leverage|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>
