﻿using Bybit.Net.Interfaces.Clients.CopyTradingApi;
using Bybit.Net.Objects.Models.CopyTrading;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.CopyTradingApi
{
    /// <inheritdoc />
    public class BybitClientCopyTradingApiExchangeData : IBybitClientCopyTradingApiExchangeData
    {
        private BybitClientCopyTradingApi _baseClient;

        internal BybitClientCopyTradingApiExchangeData(BybitClientCopyTradingApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Get symbols

        /// <inheritdoc />
        public async Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default)
        {
            var result = await _baseClient.SendRequestWrapperAsync<BybitCopyTradingSymbol>(_baseClient.GetUrl("/v2/public/time"), HttpMethod.Get, ct, null, false).ConfigureAwait(false);
            return result.As(result.Data.Timestamp);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitCopyTradingSymbol>>> GetSymbolsAsync(CancellationToken ct = default)
        {
            return await _baseClient.SendRequestListAsync<BybitCopyTradingSymbol>(_baseClient.GetUrl("contract/v3/public/copytrading/symbol/list"), HttpMethod.Get, ct, null, false).ConfigureAwait(false);
        }

        #endregion
    }
}
