---
name: bybit-net
description: Implement or review Bybit.Net V5 REST calls, spot and derivatives trading, account workflows, WebSocket subscriptions and order queries, authentication, Shared API integration, and dependency injection in .NET applications.
---
# Bybit.Net

Install with `dotnet add package Bybit.Net`.

- Reuse `BybitRestClient` and `BybitSocketClient`, or resolve them through dependency injection. REST uses `V5Api`; public sockets are split by product, while private streams and socket trading use `V5PrivateApi`.
- Public market data needs no credentials. Private operations use `BybitCredentials(key, secret)` for HMAC, without a passphrase; RSA credential wrappers are also supported on the applicable target frameworks.
- Match `Category.Spot`, `Linear`, `Inverse`, or `Option` to the product. Native symbols are compact, such as `ETHUSDT`; discover option and spread symbols from the exchange.
- REST returns `HttpResult<T>` / `HttpResult`, subscriptions return `WebSocketResult<UpdateSubscription>`, and socket order queries return `QueryResult<T>` / `QueryResult`. Check `Success` before reading `Data`; inspect `Error` on failure. Many V5 REST responses wrap records in `Data.List`.
- Retain the concrete socket client and unsubscribe successful subscriptions on shutdown. Order-query results are not subscriptions.
- Choose account type and derivatives `PositionIdx` to match the account and position mode. Order acknowledgment does not establish execution or cancellation completion.
- Use `V5Api.SharedApi` and the supported socket roots' `SharedApi` for Shared API V2. Depend on the required capability interface; use the aggregate for dynamic selection. Native and shared requests use different models.

## References

- Read [API surfaces](references/api-surfaces.md) for routing, category/account selection, Shared API capabilities, catalogs, and quantities.
- Read [usage](references/usage.md) for authentication, market/account reads, trading, subscription cleanup, socket queries, Shared API V2, and DI snippets.
- Read [operational considerations](references/safety.md) for order recovery, position modes, batch outcomes, and fund movements.

Checkout-only: [repository instructions](../../../AGENTS.md) and [complete examples](../../../Examples/ai-friendly/).
