---
title: IBybitRestClientApiAccount
has_children: false
parent: IBybitRestClientV5
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BybitRestClient > V5 > ApiAccount`  
*Bybit account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and changing account settings*
  

***

## CancelWithdrawalAsync  

[https://bybit-exchange.github.io/docs/v5/asset/cancel-withdraw](https://bybit-exchange.github.io/docs/v5/asset/cancel-withdraw)  
<p>

*Cancel a withdrawal*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.CancelWithdrawalAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitOperationResult>> CancelWithdrawalAsync(string id, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|id|The id of the withdrawal to cancel|
|_[Optional]_ ct|Cancellation token|

</p>

***

## CreateInternalTransferAsync  

[https://bybit-exchange.github.io/docs/v5/asset/create-inter-transfer](https://bybit-exchange.github.io/docs/v5/asset/create-inter-transfer)  
<p>

*Create an internal transfer between different account types*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.CreateInternalTransferAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitTransferId>> CreateInternalTransferAsync(string asset, decimal quantity, AccountType fromAccountType, AccountType toAccountType, string? transferId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|asset|Coin|
|quantity|Quantity|
|fromAccountType|From account type|
|toAccountType|To account type|
|_[Optional]_ transferId|Client id|
|_[Optional]_ ct|Cancellation token|

</p>

***

## CreateUniversalTransferAsync  

[https://bybit-exchange.github.io/docs/v5/asset/unitransfer](https://bybit-exchange.github.io/docs/v5/asset/unitransfer)  
<p>

*Transfer between main/sub accounts*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.CreateUniversalTransferAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitTransferId>> CreateUniversalTransferAsync(string asset, decimal quantity, string fromMemberId, string toMemberId, AccountType fromAccountType, AccountType toAccountType, string? transferId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|asset|The asset|
|quantity|Quantity|
|fromMemberId|From member id|
|toMemberId|To member id|
|fromAccountType|From account type|
|toAccountType|To account type|
|_[Optional]_ transferId|Client id|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetAllAssetBalancesAsync  

[https://bybit-exchange.github.io/docs/v5/asset/all-balance](https://bybit-exchange.github.io/docs/v5/asset/all-balance)  
<p>

*Get all balances*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.GetAllAssetBalancesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitAllAssetBalances>> GetAllAssetBalancesAsync(AccountType accountType, string? memberId = default, string? asset = default, bool? withBonus = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|accountType|Account tpye|
|_[Optional]_ memberId|Member id|
|_[Optional]_ asset|Asset|
|_[Optional]_ withBonus|Include bonus|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetAllowedDepositAssetInfoAsync  

[https://bybit-exchange.github.io/docs/v5/asset/deposit-coin-spec](https://bybit-exchange.github.io/docs/v5/asset/deposit-coin-spec)  
<p>

*Get allowed deposit asset info*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.GetAllowedDepositAssetInfoAsync();  
```  

```csharp  
Task<WebCallResult<BybitAllowedDepositInfoResponse>> GetAllowedDepositAssetInfoAsync(string? asset = default, string? network = default, int? limit = default, string? cursor = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ asset|Filter on asset|
|_[Optional]_ network|Filter on network|
|_[Optional]_ limit|Number of results per page|
|_[Optional]_ cursor|Pagination cursor|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetApiKeyInfoAsync  

[https://bybit-exchange.github.io/docs/v5/user/apikey-info](https://bybit-exchange.github.io/docs/v5/user/apikey-info)  
<p>

*Get api key info for the current api key*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.GetApiKeyInfoAsync();  
```  

```csharp  
Task<WebCallResult<BybitApiKeyInfo>> GetApiKeyInfoAsync(CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetAssetBalanceAsync  

[https://bybit-exchange.github.io/docs/v5/asset/account-coin-balance](https://bybit-exchange.github.io/docs/v5/asset/account-coin-balance)  
<p>

*Get asset balance*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.GetAssetBalanceAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitSingleAssetBalance>> GetAssetBalanceAsync(AccountType accountType, string asset, string? memberId = default, bool? withBonus = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|accountType|Account type|
|asset|The asset|
|_[Optional]_ memberId|Member id|
|_[Optional]_ withBonus|Include bonus|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetAssetGreeksAsync  

[https://bybit-exchange.github.io/docs/v5/account/coin-greeks](https://bybit-exchange.github.io/docs/v5/account/coin-greeks)  
<p>

*Get current account greek info*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.GetAssetGreeksAsync();  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitGreeks>>> GetAssetGreeksAsync(string? baseAsset = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ baseAsset|Base asset|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetAssetInfoAsync  

[https://bybit-exchange.github.io/docs/v5/asset/coin-info](https://bybit-exchange.github.io/docs/v5/asset/coin-info)  
<p>

*Get coin info including chain info and withdrawal and deposit status*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.GetAssetInfoAsync();  
```  

```csharp  
Task<WebCallResult<BybitUserAssetInfos>> GetAssetInfoAsync(string? asset = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ asset|Filter by asset|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetAssetInfoAsync  

[https://bybit-exchange.github.io/docs/v5/asset/asset-info](https://bybit-exchange.github.io/docs/v5/asset/asset-info)  
<p>

*Get asset information*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.GetAssetInfoAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitAccountAssetInfo>> GetAssetInfoAsync(AccountType accountType, string? asset = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|accountType|Account type (spot only atm)|
|_[Optional]_ asset|Filter asset|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetBalancesAsync  

[https://bybit-exchange.github.io/docs/v5/account/wallet-balance](https://bybit-exchange.github.io/docs/v5/account/wallet-balance)  
<p>

*Get wallet balance and account info*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.GetBalancesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitBalance>>> GetBalancesAsync(AccountType accountType, string? asset = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|accountType|Account info|
|_[Optional]_ asset|Filter by asset|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetBorrowHistoryAsync  

[https://bybit-exchange.github.io/docs/v5/account/borrow-history](https://bybit-exchange.github.io/docs/v5/account/borrow-history)  
<p>

*Get borrow history*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.GetBorrowHistoryAsync();  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitBorrowHistory>>> GetBorrowHistoryAsync(string? asset = default, DateTime? startTime = default, DateTime? endTime = default, int? limit = default, string? cursor = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ asset|Filter by asset|
|_[Optional]_ startTime|Filter by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ limit|Number of results per page|
|_[Optional]_ cursor|Pagination cursor|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetCollateralInfoAsync  

[https://bybit-exchange.github.io/docs/v5/account/collateral-info](https://bybit-exchange.github.io/docs/v5/account/collateral-info)  
<p>

*Get the collateral information of the current unified margin account, including loan interest rate, loanable amount, collateral conversion rate, whether it can be mortgaged as margin, etc.*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.GetCollateralInfoAsync();  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitCollateralInfo>>> GetCollateralInfoAsync(string? asset = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ asset|Filter by asset|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetDelayedWithdrawQuantityAsync  

[https://bybit-exchange.github.io/docs/v5/asset/delay-amount](https://bybit-exchange.github.io/docs/v5/asset/delay-amount)  
<p>

*Get delayed withdrawal amount*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.GetDelayedWithdrawQuantityAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitDelayedWithdrawal>> GetDelayedWithdrawQuantityAsync(string asset, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|asset|The asset|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetDepositAddressAsync  

[https://bybit-exchange.github.io/docs/v5/asset/master-deposit-addr](https://bybit-exchange.github.io/docs/v5/asset/master-deposit-addr)  
<p>

*Get the master deposit address for an asset*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.GetDepositAddressAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitDepositAddress>> GetDepositAddressAsync(string asset, string? networkType = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|asset|Asset|
|_[Optional]_ networkType|Network type|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetDepositsAsync  

[https://bybit-exchange.github.io/docs/v5/asset/deposit-record](https://bybit-exchange.github.io/docs/v5/asset/deposit-record)  
<p>

*Get list of deposits*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.GetDepositsAsync();  
```  

```csharp  
Task<WebCallResult<BybitDeposits>> GetDepositsAsync(string? asset = default, DateTime? startTime = default, DateTime? endTime = default, int? limit = default, string? cursor = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ asset|Filter by asset|
|_[Optional]_ startTime|Filter by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ limit|Number of results per page|
|_[Optional]_ cursor|Pagination cursor|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetFeeRateAsync  

[https://bybit-exchange.github.io/docs/v5/account/fee-rate](https://bybit-exchange.github.io/docs/v5/account/fee-rate)  
<p>

*Get fee rates*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.GetFeeRateAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitFeeRate>>> GetFeeRateAsync(Category category, string? symbol = default, string? baseAsset = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|_[Optional]_ symbol|Filter by symbol|
|_[Optional]_ baseAsset|Filter by base asset|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetInternalTransfersAsync  

[https://bybit-exchange.github.io/docs/v5/asset/inter-transfer-list](https://bybit-exchange.github.io/docs/v5/asset/inter-transfer-list)  
<p>

*Get internal transfer history*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.GetInternalTransfersAsync();  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitTransfer>>> GetInternalTransfersAsync(string? transferId = default, string? asset = default, TransferStatus? transferStatus = default, DateTime? startTime = default, DateTime? endTime = default, int? limit = default, string? cursor = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ transferId|Filter by tansfer id|
|_[Optional]_ asset|Filter by asset|
|_[Optional]_ transferStatus|Filter by status|
|_[Optional]_ startTime|Filter by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ limit|Number of results per page|
|_[Optional]_ cursor|Pagination cursor|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetMarginAccountInfoAsync  

[https://bybit-exchange.github.io/docs/v5/account/account-info](https://bybit-exchange.github.io/docs/v5/account/account-info)  
<p>

*Get margin configuration info*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.GetMarginAccountInfoAsync();  
```  

```csharp  
Task<WebCallResult<BybitAccountInfo>> GetMarginAccountInfoAsync(CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetTransactionHistoryAsync  

[https://bybit-exchange.github.io/docs/v5/account/transaction-log](https://bybit-exchange.github.io/docs/v5/account/transaction-log)  
<p>

*Get transaction logs in Unified account.*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.GetTransactionHistoryAsync();  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitTransactionLog>>> GetTransactionHistoryAsync(AccountType? accountType = default, Category? category = default, string? asset = default, string? baseAsset = default, TransactionLogType? type = default, DateTime? startTime = default, DateTime? endTime = default, int? limit = default, string? cursor = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ accountType|Filter by account type|
|_[Optional]_ category|Filter by category|
|_[Optional]_ asset|Filter by asset|
|_[Optional]_ baseAsset|Filter by base asset|
|_[Optional]_ type|Filter by type|
|_[Optional]_ startTime|Filter by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ limit|Number of results per page|
|_[Optional]_ cursor|Pagination cursor|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetTransferableAssetsAsync  

[https://bybit-exchange.github.io/docs/v5/asset/transferable-coin](https://bybit-exchange.github.io/docs/v5/asset/transferable-coin)  
<p>

*Get a list of transferable assets between accounts*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.GetTransferableAssetsAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitResponse<string>>> GetTransferableAssetsAsync(AccountType fromAccountType, AccountType toAccountType, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|fromAccountType|From account type|
|toAccountType|To account type|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetUniversalTransfersAsync  

[https://bybit-exchange.github.io/docs/v5/asset/unitransfer-list](https://bybit-exchange.github.io/docs/v5/asset/unitransfer-list)  
<p>

*Get universal transfer history*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.GetUniversalTransfersAsync();  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitTransfer>>> GetUniversalTransfersAsync(string? transferId = default, string? asset = default, TransferStatus? transferStatus = default, DateTime? startTime = default, DateTime? endTime = default, int? limit = default, string? cursor = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ transferId|Filter by tansfer id|
|_[Optional]_ asset|Filter by asset|
|_[Optional]_ transferStatus|Filter by status|
|_[Optional]_ startTime|Filter by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ limit|Number of results per page|
|_[Optional]_ cursor|Pagination cursor|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetWithdrawalsAsync  

[https://bybit-exchange.github.io/docs/v5/asset/withdraw-record](https://bybit-exchange.github.io/docs/v5/asset/withdraw-record)  
<p>

*Get withdrawal history*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.GetWithdrawalsAsync();  
```  

```csharp  
Task<WebCallResult<BybitResponse<BybitWithdrawal>>> GetWithdrawalsAsync(string? withdrawId = default, string? asset = default, WithdrawalType? type = default, DateTime? startTime = default, DateTime? endTime = default, int? limit = default, string? cursor = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ withdrawId|Filter by withdrawal id|
|_[Optional]_ asset|Filter by asset|
|_[Optional]_ type|Filter by type|
|_[Optional]_ startTime|Filter by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ limit|Number of results per page|
|_[Optional]_ cursor|Pagination cursor|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetAutoAddMarginAsync  

[https://bybit-exchange.github.io/docs/v5/position/add-margin](https://bybit-exchange.github.io/docs/v5/position/add-margin)  
<p>

*Set auto add margin*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.SetAutoAddMarginAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> SetAutoAddMarginAsync(Category category, string symbol, bool autoAddMargin, PositionIdx? positionIdx = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|symbol|Symbol|
|autoAddMargin|Auto add margin or not|
|_[Optional]_ positionIdx|Position idx|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetDepositAccountAsync  

[https://bybit-exchange.github.io/docs/v5/asset/set-deposit-acct](https://bybit-exchange.github.io/docs/v5/asset/set-deposit-acct)  
<p>

*Set the account deposits are credited to*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.SetDepositAccountAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitOperationResult>> SetDepositAccountAsync(AccountType accountType, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|accountType|The account|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetLeverageAsync  

[https://bybit-exchange.github.io/docs/v5/position/leverage](https://bybit-exchange.github.io/docs/v5/position/leverage)  
<p>

*Set leverage*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.SetLeverageAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> SetLeverageAsync(Category category, string symbol, decimal buyLeverage, decimal sellLeverage, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|symbol|Symbol|
|buyLeverage|Buy leverage. Must be the same as sellLeverage under one-way mode|
|sellLeverage|Sell leverage. Must be the same as sellLeverage under one-way mode|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetMarginModeAsync  

[https://bybit-exchange.github.io/docs/v5/account/set-margin-mode](https://bybit-exchange.github.io/docs/v5/account/set-margin-mode)  
<p>

*Set the margin mode*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.SetMarginModeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitSetMarginModeResult>> SetMarginModeAsync(MarginMode marginMode, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|marginMode|Margin mode|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetRiskLimitAsync  

[https://bybit-exchange.github.io/docs/v5/position/set-risk-limit](https://bybit-exchange.github.io/docs/v5/position/set-risk-limit)  
<p>

*Set the risk limit*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.SetRiskLimitAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitSetRiskLimit>> SetRiskLimitAsync(Category category, string symbol, int riskId, PositionIdx? positionIdx = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|symbol|Symbol|
|riskId|Risk id|
|_[Optional]_ positionIdx|Position idx|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetTakeProfitStopLossModeAsync  

[https://bybit-exchange.github.io/docs/v5/position/tpsl-mode](https://bybit-exchange.github.io/docs/v5/position/tpsl-mode)  
<p>

*Set take profit/stop loss mode*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.SetTakeProfitStopLossModeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitTakeProfitStopLossMode>> SetTakeProfitStopLossModeAsync(Category category, string symbol, StopLossTakeProfitMode tpSlMode, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|symbol|Symbol|
|tpSlMode|Mode|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SwitchCrossIsolatedMarginAsync  

[https://bybit-exchange.github.io/docs/v5/position/cross-isolate](https://bybit-exchange.github.io/docs/v5/position/cross-isolate)  
<p>

*Switch cross or isolated margin mode*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.SwitchCrossIsolatedMarginAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> SwitchCrossIsolatedMarginAsync(Category category, string symbol, TradeMode tradeMode, decimal buyLeverage, decimal sellLeverage, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|symbol|Symbol|
|tradeMode|Trade mode|
|buyLeverage|Buy leverage|
|sellLeverage|Sell leverage|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SwitchPositionModeAsync  

[https://bybit-exchange.github.io/docs/v5/position/position-mode](https://bybit-exchange.github.io/docs/v5/position/position-mode)  
<p>

*Switch position mode*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.SwitchPositionModeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> SwitchPositionModeAsync(Category category, Enums.V5.PositionMode mode, string? symbol = default, string? asset = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|category|Category|
|mode|Mode|
|_[Optional]_ symbol|Symbol|
|_[Optional]_ asset|Asset|
|_[Optional]_ ct|Cancellation token|

</p>

***

## WithdrawAsync  

[https://bybit-exchange.github.io/docs/v5/asset/withdraw](https://bybit-exchange.github.io/docs/v5/asset/withdraw)  
<p>

*Withdraw funds*  

```csharp  
var client = new BybitRestClient();  
var result = await client.V5.ApiAccount.WithdrawAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BybitId>> WithdrawAsync(string asset, string network, string toAddress, decimal quantity, string? tag = default, bool? forceNetwork = default, AccountType? accountType = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|asset|Asset|
|network|Network to use|
|toAddress|Target address|
|quantity|Quantity|
|_[Optional]_ tag|Tag|
|_[Optional]_ forceNetwork|Force on-chain withdrawal|
|_[Optional]_ accountType|Account type to withdraw from|
|_[Optional]_ ct|Cancellation token|

</p>
