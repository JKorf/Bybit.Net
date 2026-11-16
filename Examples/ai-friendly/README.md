# Bybit.Net examples

See [usage](../../.claude/skills/bybit-net/references/usage.md), [API routing](../../.claude/skills/bybit-net/references/api-surfaces.md), and [operational considerations](../../.claude/skills/bybit-net/references/safety.md) for maintained consumer guidance.

- [V5 market and account](01-v5-market-and-account.cs)
- [V5 trading](02-v5-trading.cs)
- [WebSockets](03-websocket.cs)
- [Shared API V2](04-shared-client.cs)
- [Error handling](05-error-handling.cs)

The documentation test compiles these files as independent console programs without executing exchange operations. Running them contacts Bybit. The trading example gates live placement with `BYBIT_EXAMPLE_PLACE_ORDER=true`; review its parameters before enabling it.

See [repository instructions](../../AGENTS.md) for build and test commands.
