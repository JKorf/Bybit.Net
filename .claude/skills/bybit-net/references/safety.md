# Operational considerations

## Credentials and account scope

Private operations require HMAC key/secret credentials or the supported RSA credential wrapper, with no passphrase. Keep keys and RSA private material outside source. RSA PEM support is conditional on the target framework; consult the credentials type when targeting older frameworks.

`Live`, `Testnet`, `DemoTrading`, and regional environments are distinct; configure the intended environment and matching credentials. Product category and account type are independent choices. A unified account's wallet balance does not necessarily represent its transferable or withdrawable amount; use the relevant account endpoint.

## Execution and position mode

Use the same category and symbol for placement, lookup, edits, and cancellation. Match `PositionIdx.OneWayMode`, `BuyHedgeMode`, or `SellHedgeMode` to the account's position mode and intended position. Verify margin, leverage, and reduce-only behavior for the selected product; inverse sizing is not interchangeable with linear base-asset sizing. Spot market sizing can depend on `MarketUnit`.

A limit order can fill immediately if its price crosses the book. Placement and cancellation acknowledgments do not prove the final execution state. Reconcile order updates and executions, especially when cancellation races with fills. `PreCheckOrderAsync` checks an order without placing it; a normal placement call is an account mutation.

Leverage, margin and position-mode switches, risk limits, trading stops, and added/reduced margin change account exposure. Disconnect-cancel-all behavior is a distinct configured workflow; subscribing to a topic alone is not a substitute for verifying the configured cancellation behavior.

## Batch results and submission recovery

Batch REST and socket operations can return arrays of `CallResult<T>`. Check the outer result and every item's `Success` and `Error`. A successful request does not establish that every order succeeded.

A timeout or lost response can occur after Bybit accepted a submission. Query by the supported order/client identifier and inspect executions or relevant transaction/account state before deciding whether to resubmit. A client identifier supports correlation but does not by itself prove resubmission is idempotent. Transient errors do not make account-changing requests safe to repeat; bound public-read retries separately from submission recovery.

## Fund movements and specialized products

Internal/universal transfers, withdrawals, convert confirmation, earn orders, borrowing, repayment, and collateral adjustment change fund ownership, location, or obligations. Preserve account direction and endpoint-specific account types. For withdrawals, verify asset, chain, address, amount, and required destination metadata, then reconcile resulting withdrawal status.

The complete trading example gates live placement with `BYBIT_EXAMPLE_PLACE_ORDER=true`; that gate is an example configuration, not an exchange test-order mode.
