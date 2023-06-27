---
title: IBybitRestClientUnifiedMarginApiAccount
has_children: false
parent: IBybitRestClientDerivativesApi\UnifiedMarginApi
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BybitRestClient > DerivativesApi\UnifiedMarginApi > UnifiedMarginApiAccount`  
*Bybit account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings*
  

***

## ExchangeCoinsAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_queryexchangerecords](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_queryexchangerecords)  
<p>

*Exchange Coins*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\UnifiedMarginApi.UnifiedMarginApiAccount.ExchangeCoinsAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitUnifiedMarginCoinExchangeResult>>> ExchangeCoinsAsync(string? fromCoint = default, string? toCoint = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ fromCoint||
|_[Optional]_ toCoint||
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetBorrowHistoryAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_interestbillstatement](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_interestbillstatement)  
<p>

*Get Borrow History*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\UnifiedMarginApi.UnifiedMarginApiAccount.GetBorrowHistoryAsync();  
```  

```csharp  
Task<WebCallResult<BybitCursorPage<IEnumerable<BybitUnifiedMarginBorrowRecord>>>> GetBorrowHistoryAsync(string? asset = default, DateTime? startTime = default, DateTime? endTime = default, SearchDirection? direction = default, int? limit = default, string? cursor = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ asset|USDC, USDT, BTC, and ETH|
|_[Optional]_ startTime|Starting timestamp|
|_[Optional]_ endTime|Ending timestamp|
|_[Optional]_ direction||
|_[Optional]_ limit||
|_[Optional]_ cursor||
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetBorrowRateAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_queryloaninterest](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_queryloaninterest)  
<p>

*Get borrow rate*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\UnifiedMarginApi.UnifiedMarginApiAccount.GetBorrowRateAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BybitUnifiedMarginBorrowRate>>> GetBorrowRateAsync(string? asset = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ asset|Only for UDDC, USDT. If not passed, USDT-USDC interests are returned. You could pass multiple currency separated by comma, e.a USDC,USDT|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetPositionAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_myposition](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_myposition)  
<p>

*Get user positions*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\UnifiedMarginApi.UnifiedMarginApiAccount.GetPositionAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitDerivativesCursorPage<IEnumerable<BybitUnifiedMarginPosition>>>> GetPositionAsync(Category category, string? symbol = default, string? baseAsset = default, SearchDirection? direction = default, int? limit = default, string? cursor = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Type of derivatives product: linear or option|
|_[Optional]_ symbol|Name of Contract|
|_[Optional]_ baseAsset|Base coin. When category=option. If not passed, BTC by default.|
|_[Optional]_ direction||
|_[Optional]_ limit||
|_[Optional]_ cursor||
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetProfitAndLossHistoryAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_usertraderecords7day](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_usertraderecords7day)  
<p>

*Get 7-day Trading History*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\UnifiedMarginApi.UnifiedMarginApiAccount.GetProfitAndLossHistoryAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitDerivativesCursorPage<IEnumerable<BybitUnifiedMarginPnlEntry>>>> GetProfitAndLossHistoryAsync(Category category, string? symbol = default, string? baseAsset = default, string? orderId = default, string? clientOrderId = default, OrderFilter? orderFilter = default, DateTime? startTime = default, DateTime? endTime = default, TradeType? type = default, SearchDirection? direction = default, int? limit = default, string? cursor = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category||
|_[Optional]_ symbol|The symbol|
|_[Optional]_ baseAsset|Base coin. When category=option. If not passed, BTC by default.|
|_[Optional]_ orderId|Filter by order id|
|_[Optional]_ clientOrderId|Filter by client order id|
|_[Optional]_ orderFilter|Conditional order or active order|
|_[Optional]_ startTime|Filter by startTime|
|_[Optional]_ endTime|Filter by endTime|
|_[Optional]_ type|Filter by type|
|_[Optional]_ direction|Search direction|
|_[Optional]_ limit|Data quantity per page: Max data value per page is 50, and default value at 20|
|_[Optional]_ cursor|API pass-through|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetTransactionLogAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_querytransactionlogs](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_querytransactionlogs)  
<p>

*Query trading history*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\UnifiedMarginApi.UnifiedMarginApiAccount.GetTransactionLogAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitDerivativesCursorPage<IEnumerable<BybitUnifiedMarginTransactionLog>>>> GetTransactionLogAsync(Category category, string asset, string? baseAsset = default, DateTime? startTime = default, DateTime? endTime = default, SearchDirection? direction = default, int? limit = default, string? cursor = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|	Type of derivatives product: linear or option|
|asset|USDC, USDT, BTC, and ETH|
|_[Optional]_ baseAsset|Base coin|
|_[Optional]_ startTime|Starting timestamp|
|_[Optional]_ endTime|Ending timestamp|
|_[Optional]_ direction||
|_[Optional]_ limit||
|_[Optional]_ cursor||
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetWalletBalance  

<p>

*Query wallet balance*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\UnifiedMarginApi.UnifiedMarginApiAccount.GetWalletBalance();  
```  

```csharp  
Task<WebCallResult<BybitUnifiedMarginBalance>> GetWalletBalance(string? asset = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ asset|Currency alias. If the parameter coin is not passed, all wallet balance will be returned. Multiple parameters can be passed, which should be separated using commas, such as USDC, USDT|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## IsUMAEnabled  

<p>

*Check, if Unified Margin Account enabled for current credentials*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\UnifiedMarginApi.UnifiedMarginApiAccount.IsUMAEnabled();  
```  

```csharp  
Task<WebCallResult<bool>> IsUMAEnabled();  
```  

|Parameter|Description|
|---|---|

</p>

***

## SetFullPartialPositionModeAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_switchmode](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_switchmode)  
<p>

*Switch between full or partial Stop loss/Take profit mode*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\UnifiedMarginApi.UnifiedMarginApiAccount.SetFullPartialPositionModeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> SetFullPartialPositionModeAsync(Category category, string symbol, StopLossTakeProfitMode mode, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Type of derivatives product: linear or option|
|symbol|The symbol|
|mode|New mode|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetLeverageAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_setleverage](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_setleverage)  
<p>

*Modify leverage*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\UnifiedMarginApi.UnifiedMarginApiAccount.SetLeverageAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> SetLeverageAsync(Category category, string symbol, decimal buyLeverage, decimal cellLeverage, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Type of derivatives product: linear or option|
|symbol|Name of Contract|
|buyLeverage|leverage of the corresponding risk limit|
|cellLeverage|leverage of the corresponding risk limit|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetRiskLimitAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_setrisklimit](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_setrisklimit)  
<p>

*Set position risk*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\UnifiedMarginApi.UnifiedMarginApiAccount.SetRiskLimitAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> SetRiskLimitAsync(Category category, string symbol, long riskId, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Type of derivatives product: linear or option|
|symbol|The symbol|
|riskId|The risk id to set|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetSlTpAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_switchmode](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_switchmode)  
<p>

*Set position TP/SL and trailing stop.*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\UnifiedMarginApi.UnifiedMarginApiAccount.SetSlTpAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> SetSlTpAsync(Category category, string symbol, decimal? takeProfit = default, decimal? stopLoss = default, decimal? trailingStop = default, TriggerType? tpTriggerBy = default, TriggerType? slTriggerBy = default, decimal? activePrice = default, decimal? slSize = default, decimal? tpSize = default, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category| Derivatives products category. If category is not passed, then return ""For now, linear is available|
|symbol| Name of Contract|
|_[Optional]_ takeProfit| ≥ 0, if = 0, cancel take-profit (TP)|
|_[Optional]_ stopLoss| ≥ 0, if = 0, cancel stop-loss (SL)|
|_[Optional]_ trailingStop| ≥ 0, if = 0, cancel trailing stop (TS)|
|_[Optional]_ tpTriggerBy|Type of take-profit activation price, LastPrice by default|
|_[Optional]_ slTriggerBy|Type of stop-loss activation price, LastPrice by default|
|_[Optional]_ activePrice|Trailing stop trigger price. Trailing stop will only be triggered when this price is touched (trailing stop will be immediately triggered by default)|
|_[Optional]_ slSize|Quantity of stop-loss orders with the TP/SL mode on selected positions|
|_[Optional]_ tpSize|Quantity of take-profit orders with the TP/SL mode on selected positions|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>

***

## TransferFundsAsync  

[https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_transfer](https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-dv_transfer)  
<p>

*Fund transfer between accounts*  

```csharp  
var client = new BybitRestClient();  
var result = await client.DerivativesApi\UnifiedMarginApi.UnifiedMarginApiAccount.TransferFundsAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitUnifiedMarginTransferInfo>> TransferFundsAsync(string transferId, decimal amount, string currency, AccountType fromAccountType, AccountType toAccountType, long? receiveWindow = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|transferId|UUID, globally unique|
|amount|Exchanged amount|
|currency|Currency alias|
|fromAccountType|Account type|
|toAccountType|Account type|
|_[Optional]_ receiveWindow|The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request|
|_[Optional]_ ct|Cancellation token|

</p>
