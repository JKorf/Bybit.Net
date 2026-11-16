# API surfaces

## Client roots, categories, and accounts

`client` below is a `BybitRestClient`; `socketClient` is a `BybitSocketClient`. REST uses `client.V5Api`, grouped into `ExchangeData`, `Account`, `Trading`, `SubAccount`, `CryptoLoan`, and `Earn`.

| Product | REST category | Public socket root |
| --- | --- | --- |
| Spot | `Category.Spot` | `socketClient.V5SpotApi` |
| Linear perpetuals and futures | `Category.Linear` | `socketClient.V5LinearApi` |
| Inverse perpetuals and futures | `Category.Inverse` | `socketClient.V5InverseApi` |
| Options | `Category.Option` | `socketClient.V5OptionsApi` |
| Spread instruments | Dedicated spread methods | `socketClient.V5SpreadApi` |
| Private account streams and socket order queries | Applicable category on trading calls | `socketClient.V5PrivateApi` |

Native symbols use compact identifiers such as `ETHUSDT`; request exact option and spread instrument names rather than constructing them. Match symbols to their product category. Candles use `KlineInterval`, new orders use `NewOrderType`, and derivatives position selection uses `PositionIdx`.

Account type is separate from product category. `AccountType.Unified`, `Spot`, `Contract`, and `Fund` identify different account scopes; each endpoint supports its own subset. For example, wallet balances use `GetBalancesAsync`, while funding asset reads use `GetAssetBalanceAsync` or `GetAllAssetBalancesAsync`. Do not treat a wallet field as an interchangeable transferable/withdrawable balance.

## ExchangeData

| Intent | Method |
| --- | --- |
| Get server time | `client.V5Api.ExchangeData.GetServerTimeAsync(...)` |
| Get announcements | `client.V5Api.ExchangeData.GetAnnouncementsAsync(...)` |
| Get spot symbols | `client.V5Api.ExchangeData.GetSpotSymbolsAsync(...)` |
| Get linear/inverse symbols | `client.V5Api.ExchangeData.GetLinearInverseSymbolsAsync(...)` |
| Get option symbols | `client.V5Api.ExchangeData.GetOptionSymbolsAsync(...)` |
| Get spot ticker | `client.V5Api.ExchangeData.GetSpotTickersAsync(...)` |
| Get linear/inverse ticker | `client.V5Api.ExchangeData.GetLinearInverseTickersAsync(...)` |
| Get option ticker | `client.V5Api.ExchangeData.GetOptionTickersAsync(...)` |
| Get klines | `client.V5Api.ExchangeData.GetKlinesAsync(...)` |
| Get mark price klines | `client.V5Api.ExchangeData.GetMarkPriceKlinesAsync(...)` |
| Get index price klines | `client.V5Api.ExchangeData.GetIndexPriceKlinesAsync(...)` |
| Get premium index klines | `client.V5Api.ExchangeData.GetPremiumIndexPriceKlinesAsync(...)` |
| Get order book | `client.V5Api.ExchangeData.GetOrderbookAsync(...)` |
| Get RPI order book | `client.V5Api.ExchangeData.GetRpiOrderbookAsync(...)` |
| Get recent trades | `client.V5Api.ExchangeData.GetTradeHistoryAsync(...)` |
| Get funding rate history | `client.V5Api.ExchangeData.GetFundingRateHistoryAsync(...)` |
| Get open interest | `client.V5Api.ExchangeData.GetOpenInterestAsync(...)` |
| Get risk limit | `client.V5Api.ExchangeData.GetRiskLimitAsync(...)` |
| Get delivery price | `client.V5Api.ExchangeData.GetDeliveryPriceAsync(...)` |
| Get insurance | `client.V5Api.ExchangeData.GetInsuranceAsync(...)` |
| Get long/short ratio | `client.V5Api.ExchangeData.GetLongShortRatioAsync(...)` |
| Get system status | `client.V5Api.ExchangeData.GetSystemStatusAsync(...)` |
| Get spread symbols | `client.V5Api.ExchangeData.GetSpreadSymbolsAsync(...)` |
| Get spread order book | `client.V5Api.ExchangeData.GetSpreadOrderBookAsync(...)` |
| Get spread tickers | `client.V5Api.ExchangeData.GetSpreadTickersAsync(...)` |
| Get spread trades | `client.V5Api.ExchangeData.GetSpreadRecentTradesAsync(...)` |
| Get Order Price Limit | `client.V5Api.ExchangeData.GetOrderPriceLimitAsync(...)` |

## Account

| Intent | Method |
| --- | --- |
| Get wallet balance | `client.V5Api.Account.GetBalancesAsync(...)` |
| Get all asset balances | `client.V5Api.Account.GetAllAssetBalancesAsync(...)` |
| Get one asset balance | `client.V5Api.Account.GetAssetBalanceAsync(...)` |
| Get asset info | `client.V5Api.Account.GetAssetInfoAsync(...)` |
| Get deposit address | `client.V5Api.Account.GetDepositAddressAsync(...)` |
| Get deposits | `client.V5Api.Account.GetDepositsAsync(...)` |
| Get withdrawals | `client.V5Api.Account.GetWithdrawalsAsync(...)` |
| Cancel withdrawal | `client.V5Api.Account.CancelWithdrawalAsync(...)` |
| Get API key info | `client.V5Api.Account.GetApiKeyInfoAsync(...)` |
| Get account types | `client.V5Api.Account.GetAccountTypesAsync(...)` |
| Get fee rates | `client.V5Api.Account.GetFeeRateAsync(...)` |
| Create internal transfer | `client.V5Api.Account.CreateInternalTransferAsync(...)` |
| Create universal transfer | `client.V5Api.Account.CreateUniversalTransferAsync(...)` |
| Get transferable amount | `client.V5Api.Account.GetTransferableAsync(...)` |
| Get collateral info | `client.V5Api.Account.GetCollateralInfoAsync(...)` |
| Get borrow history | `client.V5Api.Account.GetBorrowHistoryAsync(...)` |
| Get transfer history | `client.V5Api.Account.GetFundingTransactionHistoryAsync(...)` |
| Get asset overview | `client.V5Api.Account.GetAssetOverviewAsync(...)` |
| Get spot margin auto repay mode | `client.V5Api.Account.GetSpotMarginAutoRepayModeAsync(...)` |
| Set spot margin auto repay mode | `client.V5Api.Account.SetSpotMarginAutoRepayModeAsync(...)` |
| Withdraw | `client.V5Api.Account.WithdrawAsync(...)` |
| Set Leverage | `client.V5Api.Account.SetLeverageAsync(...)` |
| Set Margin Mode | `client.V5Api.Account.SetMarginModeAsync(...)` |
| Switch Cross Isolated Margin | `client.V5Api.Account.SwitchCrossIsolatedMarginAsync(...)` |
| Switch Position Mode | `client.V5Api.Account.SwitchPositionModeAsync(...)` |
| Set Risk Limit | `client.V5Api.Account.SetRiskLimitAsync(...)` |
| Set Auto Add Margin | `client.V5Api.Account.SetAutoAddMarginAsync(...)` |
| Add Or Reduce Margin | `client.V5Api.Account.AddOrReduceMarginAsync(...)` |

## Trading

| Intent | Method |
| --- | --- |
| Place order | `client.V5Api.Trading.PlaceOrderAsync(...)` |
| Pre-check order | `client.V5Api.Trading.PreCheckOrderAsync(...)` |
| Edit order | `client.V5Api.Trading.EditOrderAsync(...)` |
| Cancel order | `client.V5Api.Trading.CancelOrderAsync(...)` |
| Cancel all orders | `client.V5Api.Trading.CancelAllOrderAsync(...)` |
| Get open orders | `client.V5Api.Trading.GetOrdersAsync(...)` |
| Get order history | `client.V5Api.Trading.GetOrderHistoryAsync(...)` |
| Get user trades | `client.V5Api.Trading.GetUserTradesAsync(...)` |
| Get positions | `client.V5Api.Trading.GetPositionsAsync(...)` |
| Set trading stop | `client.V5Api.Trading.SetTradingStopAsync(...)` |
| Get closed PnL | `client.V5Api.Trading.GetClosedProfitLossAsync(...)` |
| Place multiple orders | `client.V5Api.Trading.PlaceMultipleOrdersAsync(...)` |
| Edit multiple orders | `client.V5Api.Trading.EditMultipleOrdersAsync(...)` |
| Cancel multiple orders | `client.V5Api.Trading.CancelMultipleOrdersAsync(...)` |
| Purchase leverage token | `client.V5Api.Trading.PurchaseLeverageTokenAsync(...)` |
| Redeem leverage token | `client.V5Api.Trading.RedeemLeverageTokenAsync(...)` |
| Get leverage token order history | `client.V5Api.Trading.GetLeverageTokenOrderHistoryAsync(...)` |
| Place spread order | `client.V5Api.Trading.PlaceSpreadOrderAsync(...)` |
| Get open spread orders | `client.V5Api.Trading.GetOpenSpreadOrdersAsync(...)` |
| Get closed spread orders | `client.V5Api.Trading.GetClosedSpreadOrdersAsync(...)` |
| Cancel spread order | `client.V5Api.Trading.CancelSpreadOrderAsync(...)` |
| Cancel all spread orders | `client.V5Api.Trading.CancelAllSpreadOrdersAsync(...)` |
| Get spread user trades | `client.V5Api.Trading.GetSpreadUserTradesAsync(...)` |

## Specialized workflows

- `client.V5Api.SubAccount` handles subaccount creation, listing, API keys, and deposit addresses.
- `client.V5Api.CryptoLoan` handles collateral, borrowable assets and limits, borrowing, repayment, loan history, and collateral adjustment.
- `client.V5Api.Earn` handles product information, order placement/history, and staked positions.
- Spread market data and orders use the dedicated methods under `ExchangeData` and `Trading`, plus spread public/private socket topics. They are not another `Category` value.
- `PreCheckOrderAsync` is a pre-check rather than order placement; regular `PlaceOrderAsync` submits an order.

## Socket operations

Public product roots provide ticker/trade, kline, and order-book subscriptions as exposed by their interfaces. Spot/linear/inverse sockets also have product-specific topics such as price limits, liquidations, insurance pools, and ADL alerts; check the selected interface rather than assuming every topic exists on all products.

| Intent | Example route |
| --- | --- |
| Spot ticker | `socketClient.V5SpotApi.SubscribeToTickerUpdatesAsync(...)` |
| Linear ticker | `socketClient.V5LinearApi.SubscribeToTickerUpdatesAsync(...)` |
| Inverse ticker | `socketClient.V5InverseApi.SubscribeToTickerUpdatesAsync(...)` |
| Options ticker | `socketClient.V5OptionsApi.SubscribeToTickerUpdatesAsync(...)` |
| Spread ticker | `socketClient.V5SpreadApi.SubscribeToTickerUpdatesAsync(...)` |
| Spot order book | `socketClient.V5SpotApi.SubscribeToOrderbookUpdatesAsync(...)` |
| Linear candles | `socketClient.V5LinearApi.SubscribeToKlineUpdatesAsync(...)` |
| Private orders | `socketClient.V5PrivateApi.SubscribeToOrderUpdatesAsync(...)` |
| Positions | `socketClient.V5PrivateApi.SubscribeToPositionUpdatesAsync(...)` |
| Executions | `socketClient.V5PrivateApi.SubscribeToUserTradeUpdatesAsync(...)` |
| Wallet | `socketClient.V5PrivateApi.SubscribeToWalletUpdatesAsync(...)` |
| Greeks | `socketClient.V5PrivateApi.SubscribeToGreekUpdatesAsync(...)` |
| Disconnect-cancel-all topic | `socketClient.V5PrivateApi.SubscribeToDisconnectCancelAllTopicAsync(...)` |
| Place/edit/cancel over socket | `socketClient.V5PrivateApi.PlaceOrderAsync(...)`, `socketClient.V5PrivateApi.EditOrderAsync(...)`, `socketClient.V5PrivateApi.CancelOrderAsync(...)` |

Subscriptions return `WebSocketResult<UpdateSubscription>`; socket trading returns query results. Configure private socket credentials directly rather than creating a listen key.

## Shared API V2

REST uses `client.V5Api.SharedApi`. Public shared sockets are `V5SpotApi.SharedApi`, `V5LinearApi.SharedApi`, and `V5InverseApi.SharedApi`; private subscriptions and order queries use `V5PrivateApi.SharedApi`.

The DI aggregate `IBybitSharedApiClient` exposes `Rest`, `SpotSocket`, `LinearSocket`, `InverseSocket`, and `PrivateSocket`. Options and spread sockets do not expose these shared surfaces.

| Surface | Representative capabilities |
| --- | --- |
| REST | `IGetTickerRest`, `IGetSpotSymbolsRest`, `IGetFuturesSymbolsRest`, `IGetBalancesRest`, `IPlaceSpotOrderRest`, `IPlaceFuturesOrderRest`, order/client-ID lookups and cancellation, `IGetPositionsRest`, `IGetPositionModeRest`, `ISetPositionModeRest`, leverage, funding, TP/SL, trigger orders, deposits, withdrawals, fees, and transfers |
| Spot/linear/inverse public socket | `ISubscribeTickerSocket`, `ISubscribeTradesSocket`, `ISubscribeBookTickerSocket`, `ISubscribeKlinesSocket` |
| Private socket subscriptions | `ISubscribeBalancesSocket`, `ISubscribeSpotOrdersSocket`, `ISubscribeFuturesOrdersSocket`, `ISubscribeUserTradesSocket`, `ISubscribePositionsSocket` |
| Private socket order queries | `IPlaceSpotOrderSocket`, `ICancelSpotOrderSocket`, `IPlaceFuturesOrderSocket`, `ICancelFuturesOrderSocket` |

The shared public socket interfaces do not expose an order-book subscription capability; use the native product order-book method or a maintained local book when required.

For dynamic selection, call the aggregate's `GetCapability` with a descriptor such as `SharedCapabilities.Tickers.GetTicker.Rest` and the required trading mode. Check for a missing match before accessing `Capability` and `Options`. `GetCapabilities` enumerates implementations and `Discover()` describes supported operations. With several exchanges registered, resolve `IEnumerable<TCapability>` and select by exchange and supported mode.

### Symbol catalogs and quantities

Use `IGetSpotSymbolsRest.GetSpotSymbolsAsync(new GetSymbolsRequest())` and `IGetFuturesSymbolsRest.GetFuturesSymbolsAsync(new GetSymbolsRequest())`. After a successful request, read `SpotSymbolCatalog` or `FuturesSymbolCatalog`. Requests support asset-type/subtype filters; metadata includes display names, constraints, and asset classifications (`Crypto`, `Fiat`, `TradFi`; applicable `StableCoin`, `Equity`, `Commodity` subtypes). Select a supported `TradingMode` when building `SharedSymbol` requests. Futures symbol retrieval defaults to the linear category; request the appropriate inverse trading mode explicitly when inverse metadata is required. Follow `NextPageCursor` for paginated native responses rather than treating one `Data.List` page as the full result set.

Shared orders use `SharedOrderQuantity`. Read the capability's quantity support and options for the requested order type and side. Spot market requests can use base or quote quantity; the futures capability advertises base-asset quantities. REST shared order books identify entries with `SharedQuantityType.BaseAsset`. Do not copy another exchange's contract representation or assume a native inverse quantity has linear base-asset semantics.

Shared REST results use `HttpResult<T>` / `HttpResult`, subscriptions use `WebSocketResult<UpdateSubscription>`, socket order queries use `QueryResult<T>` / `QueryResult`, and non-I/O symbol/cache helpers can return `ExchangeCallResult<T>`.

## Environments and source navigation

Clients default to `BybitEnvironment.Live`. `Testnet`, `DemoTrading`, and regional environments are distinct configurations; use credentials for the selected environment. Configure receive-window behavior through REST options rather than writing signing or timestamp code manually.

Checkout-only: [public interfaces](../../../../ByBit.Net/Interfaces/Clients/V5/), [local order books](../../../../ByBit.Net/SymbolOrderBooks/), and [tracker factory](../../../../ByBit.Net/BybitTrackerFactory.cs). Local books maintain snapshots/deltas; ticker or depth messages alone do not establish a synchronized local book.
