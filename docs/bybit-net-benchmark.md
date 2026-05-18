# Bybit.Net vs CCXT and Bybit.Api

This document compares measured `Bybit.Net`, `Bybit.Net` shared interfaces, `CCXT`, and `Bybit.Api` performance for C#/.NET users building against Bybit REST and WebSocket APIs.

The results show `Bybit.Net` as the clear winner. It has the fastest direct REST results in the measured server-time and ticker scenarios, the lowest allocation profile across the REST comparison, and a very large WebSocket trade-ingestion advantage over both CCXT and `Bybit.Api`.

The shared-interface results are especially useful when comparing against CCXT's unified API style. `Bybit.Net` shared clients keep most of the performance of the direct Bybit.Net clients while still exposing exchange-agnostic abstractions.

## Benchmark source

The benchmark source is available in `Benchmark/Client/Program.cs`. It contains the direct Bybit.Net benchmarks, shared-interface benchmarks, CCXT benchmarks, and `Bybit.Api` benchmarks in one BenchmarkDotNet project: `Benchmark/Client/Bybit.Net.Benchmark.Client.csproj`.

The benchmarks run against the local mock Bybit server in `Benchmark/Server`, including the REST and WebSocket mock endpoints in `Benchmark/Server/Controllers/RestController.cs` and `Benchmark/Server/Controllers/WsController.cs`.

## Summary

| Area | Result |
|---|---|
| REST server time on .NET 10 | `Bybit.Net` is fastest; CCXT is 1.02x slower and `Bybit.Api` is 1.09x slower |
| REST server time on .NET Framework 4.8 | `Bybit.Net` is fastest; CCXT is 1.04x slower and `Bybit.Api` is 1.10x slower |
| REST ticker on .NET 10 | Direct `Bybit.Net` is fastest; shared `Bybit.Net` is close and allocates far less than CCXT and `Bybit.Api` |
| REST ticker on .NET Framework 4.8 | Direct `Bybit.Net` is fastest; shared `Bybit.Net` stays close and keeps allocations low |
| WebSocket trade stream on .NET 10 | `Bybit.Net` is fastest; shared `Bybit.Net` is 1.15x slower, `Bybit.Api` is 6.15x slower, and CCXT is 14.98x slower |
| WebSocket trade stream on .NET Framework 4.8 | `Bybit.Net` is fastest; shared `Bybit.Net` is 1.03x slower, `Bybit.Api` is 3.48x slower, and CCXT is 6.22x slower |
| Unified/shared API comparison | `Bybit.Net` shared interfaces outperform CCXT unified results by a wide margin |
| Allocation profile | Direct `Bybit.Net` allocates the least memory in every measured scenario; shared `Bybit.Net` remains close |

The REST results show that `Bybit.Net` has very low request/response overhead and consistently lower memory usage. The WebSocket results show a much larger difference under sustained message processing, where parsing, dispatch, and allocation behavior dominate.

## REST comparison

| Method | Runtime | Mean | Error | StdDev | Ratio | RatioSD | Gen0 | Gen1 | Allocated | Alloc Ratio |
|---|---|---:|---:|---:|---:|---:|---:|---:|---:|---:|
| BybitNet_ServerTime | .NET 10.0 | 108.1 us | 1.87 us | 2.49 us | 1.00 | 0.03 | 0.2441 | - | 5.48 KB | 1.00 |
| CCXT_ServerTime | .NET 10.0 | 110.3 us | 1.50 us | 1.90 us | 1.02 | 0.03 | 1.2207 | - | 16.23 KB | 2.96 |
| BybitApi_ServerTime | .NET 10.0 | 118.0 us | 5.22 us | 6.97 us | 1.09 | 0.07 | 0.9766 | - | 12.52 KB | 2.29 |
| BybitNet_Ticker | .NET 10.0 | 123.1 us | 2.30 us | 3.06 us | 1.14 | 0.04 | 0.4883 | - | 8.54 KB | 1.56 |
| BybitNetShared_Ticker | .NET 10.0 | 125.5 us | 1.87 us | 2.43 us | 1.16 | 0.03 | 0.7324 | - | 9.3 KB | 1.70 |
| CCXT_Ticker | .NET 10.0 | 129.2 us | 3.72 us | 4.84 us | 1.20 | 0.05 | 1.9531 | - | 25.2 KB | 4.60 |
| BybitApi_Ticker | .NET 10.0 | 141.1 us | 2.48 us | 3.32 us | 1.31 | 0.04 | 1.4648 | - | 19.74 KB | 3.60 |
| BybitNet_ServerTime | .NET Framework 4.8 | 174.1 us | 2.93 us | 3.81 us | 1.00 | 0.03 | 2.6855 | - | 17.82 KB | 1.00 |
| CCXT_ServerTime | .NET Framework 4.8 | 180.3 us | 2.24 us | 2.91 us | 1.04 | 0.03 | 5.3711 | 0.2441 | 34.09 KB | 1.91 |
| BybitApi_ServerTime | .NET Framework 4.8 | 191.2 us | 1.69 us | 2.14 us | 1.10 | 0.03 | 4.3945 | - | 28.27 KB | 1.59 |
| BybitNet_Ticker | .NET Framework 4.8 | 202.6 us | 2.52 us | 3.28 us | 1.16 | 0.03 | 3.1738 | - | 20.98 KB | 1.18 |
| CCXT_Ticker | .NET Framework 4.8 | 202.8 us | 1.41 us | 1.83 us | 1.17 | 0.03 | 6.8359 | 0.2441 | 43.18 KB | 2.42 |
| BybitNetShared_Ticker | .NET Framework 4.8 | 205.7 us | 2.31 us | 3.09 us | 1.18 | 0.03 | 3.4180 | - | 22.32 KB | 1.25 |
| BybitApi_Ticker | .NET Framework 4.8 | 233.5 us | 1.41 us | 1.83 us | 1.34 | 0.03 | 6.1035 | 0.2441 | 38.27 KB | 2.15 |

### REST findings

For server-time requests, `Bybit.Net` is the clear leader in both time and memory:

- .NET 10: 108.1 us and 5.48 KB for `Bybit.Net`, compared with 110.3 us and 16.23 KB for CCXT, and 118.0 us and 12.52 KB for `Bybit.Api`
- .NET Framework 4.8: 174.1 us and 17.82 KB for `Bybit.Net`, compared with 180.3 us and 34.09 KB for CCXT, and 191.2 us and 28.27 KB for `Bybit.Api`

For ticker requests, direct `Bybit.Net` is fastest on both runtimes and has the lowest allocation profile:

- .NET 10: direct `Bybit.Net` completes in 123.1 us and allocates 8.54 KB. Shared `Bybit.Net` completes in 125.5 us and allocates 9.3 KB. CCXT takes 129.2 us and allocates 25.2 KB, while `Bybit.Api` takes 141.1 us and allocates 19.74 KB.
- .NET Framework 4.8: direct `Bybit.Net` completes in 202.6 us and allocates 20.98 KB. Shared `Bybit.Net` completes in 205.7 us and allocates 22.32 KB. CCXT is essentially tied on mean at 202.8 us but allocates 43.18 KB, and `Bybit.Api` takes 233.5 us while allocating 38.27 KB.

The shared-interface ticker result is the most direct REST comparison with CCXT's unified approach. On .NET 10, shared `Bybit.Net` is faster than CCXT and allocates about 63% less memory. On .NET Framework 4.8, shared `Bybit.Net` is close on mean time and allocates about 48% less memory than CCXT.

## WebSocket comparison

| Method | Runtime | Mean | Error | StdDev | Median | Ratio | RatioSD | Gen0 | Gen1 | Gen2 | Allocated | Alloc Ratio |
|---|---|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|
| BybitNet_Trades | .NET 10.0 | 159.6 ms | 5.44 ms | 7.26 ms | 155.5 ms | 1.00 | 0.06 | 9000.0000 | - | - | 115.74 MB | 1.00 |
| BybitNetShared_Trades | .NET 10.0 | 182.8 ms | 9.47 ms | 12.65 ms | 177.6 ms | 1.15 | 0.09 | 12000.0000 | - | - | 143.88 MB | 1.24 |
| BybitApi_Trades | .NET 10.0 | 979.6 ms | 32.26 ms | 38.40 ms | 968.7 ms | 6.15 | 0.35 | 193000.0000 | 7000.0000 | - | 2318.38 MB | 20.03 |
| CCXT_Trades | .NET 10.0 | 2,386.8 ms | 123.24 ms | 164.52 ms | 2,326.5 ms | 14.98 | 1.20 | 413000.0000 | 95000.0000 | 3000.0000 | 4461.07 MB | 38.54 |
| BybitNet_Trades | .NET Framework 4.8 | 824.7 ms | 10.70 ms | 13.91 ms | 822.3 ms | 1.00 | 0.02 | 37000.0000 | - | - | 224.86 MB | 1.00 |
| BybitNetShared_Trades | .NET Framework 4.8 | 849.8 ms | 5.99 ms | 6.90 ms | 852.5 ms | 1.03 | 0.02 | 43000.0000 | - | - | 261.97 MB | 1.17 |
| BybitApi_Trades | .NET Framework 4.8 | 2,873.3 ms | 58.21 ms | 75.69 ms | 2,846.2 ms | 3.48 | 0.11 | 437000.0000 | 1000.0000 | - | 2630.95 MB | 11.70 |
| CCXT_Trades | .NET Framework 4.8 | 5,128.9 ms | 59.33 ms | 72.86 ms | 5,131.3 ms | 6.22 | 0.13 | 879000.0000 | 224000.0000 | 16000.0000 | 5195.15 MB | 23.10 |

### WebSocket findings

The WebSocket benchmark is the clearest result. On .NET 10, direct `Bybit.Net` completes the trade benchmark in 159.6 ms, and shared `Bybit.Net` completes in 182.8 ms. `Bybit.Api` takes 979.6 ms, and CCXT takes 2,386.8 ms. That makes `Bybit.Api` 6.15x slower and CCXT 14.98x slower than the direct Bybit.Net socket path.

The allocation difference is even larger. On .NET 10, direct `Bybit.Net` allocates 115.74 MB and shared `Bybit.Net` allocates 143.88 MB, while `Bybit.Api` allocates 2,318.38 MB and CCXT allocates 4,461.07 MB. On .NET Framework 4.8, direct `Bybit.Net` allocates 224.86 MB and shared `Bybit.Net` allocates 261.97 MB, while `Bybit.Api` allocates 2,630.95 MB and CCXT allocates 5,195.15 MB.

For market-data consumers, this is the most important part of the comparison. WebSocket workloads run continuously, often across many symbols. Higher allocation pressure increases GC activity, and slower dispatch reduces headroom for strategy logic, persistence, aggregation, and downstream event processing.

The shared-interface socket result is important for multi-exchange designs. It shows that the exchange-agnostic Bybit.Net path remains close to the direct path, while CCXT's unified socket path is much slower and allocates dramatically more memory in this benchmark.
