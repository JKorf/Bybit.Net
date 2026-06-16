# AI-Friendly Examples

These examples are optimized for AI coding assistants and quick onboarding. Each file is:

- **Compilable**: drop into a console project with `dotnet add package Bybit.Net` and it builds.
- **Self-contained**: single file, no shared helpers.
- **Heavily commented**: explains why each line matters for Bybit.Net.
- **V5-focused**: uses the current Bybit V5 REST and WebSocket client shapes.

## Files

| File | What it shows |
|---|---|
| `01-v5-market-and-account.cs` | V5 REST setup, public spot/linear market data, order book, and credential-gated wallet balance |
| `02-v5-trading.cs` | V5 order placement, open orders, positions, cancellation, categories, and dry-run safety |
| `03-websocket.cs` | V5 public spot and linear subscriptions, private order updates, and proper teardown |
| `04-shared-client.cs` | CryptoExchange.Net shared client access beside native Bybit V5 endpoints |
| `05-error-handling.cs` | `HttpResult` / `CallResult` handling, typed errors, and retry-friendly helpers |

## Running

```bash
dotnet new console -n MyBybitApp
cd MyBybitApp
dotnet add package Bybit.Net
# Copy one example file into Program.cs
dotnet run
```

Private examples read credentials from:

- `BYBIT_API_KEY`
- `BYBIT_API_SECRET`

The trading example defaults to dry-run mode. Set `BYBIT_EXAMPLE_PLACE_ORDER=true` only after reviewing symbol, category, quantity, price, account mode, and permissions.
