using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.GeneralApi;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Models;
using CryptoExchange.Net;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.GeneralApi
{
    /// <inheritdoc />
    public class BybitClientGeneralApiWithdrawDeposit : IBybitClientGeneralApiWithdrawDeposit
    {
        private readonly BybitClientGeneralApi _baseClient;

        internal BybitClientGeneralApiWithdrawDeposit(BybitClientGeneralApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Get supported deposit methods

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitDepositConfig>>> GetSupportedDepositMethodsAsync(
            string? asset = null,
            string? network = null,
            int? page = null,
            int? pageSize = null,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("coin", asset);
            parameters.AddOptionalParameter("chain", network);
            parameters.AddOptionalParameter("page_index", page);
            parameters.AddOptionalParameter("page_size", pageSize);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitDepositConfigWrapper>(_baseClient.GetUrl("/asset/v1/public/deposit/allowed-deposit-list"), HttpMethod.Get, ct, parameters, false).ConfigureAwait(false);
            return result.As(result.Data?.ConfigList!);
        }

        #endregion

        #region Get deposit history

        /// <inheritdoc />
        public async Task<WebCallResult<BybitCursorPage<IEnumerable<BybitDeposit>>>> GetDepositHistoryAsync(
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            SearchDirection? direction = null,
            int? limit = null,
            string? cursor = null,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("coin", asset);
            parameters.AddOptionalParameter("start_time", DateTimeConverter.ConvertToSeconds(startTime));
            parameters.AddOptionalParameter("end_time", DateTimeConverter.ConvertToSeconds(endTime));
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("direction", direction == null ? null : JsonConvert.SerializeObject(direction, new SearchDirectionConverter(false)));
            parameters.AddOptionalParameter("cursor", cursor);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitCursorPage<IEnumerable<BybitDeposit>>>(_baseClient.GetUrl("/asset/v1/private/deposit/record/query"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get withdrawal history

        /// <inheritdoc />
        public async Task<WebCallResult<BybitCursorPage<IEnumerable<BybitWithdraw>>>> GetWithdrawalHistoryAsync(
            string? withdrawalId = null,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            SearchDirection? direction = null,
            int? limit = null,
            string? cursor = null,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("withdraw_id", withdrawalId);
            parameters.AddOptionalParameter("coin", asset);
            parameters.AddOptionalParameter("start_time", DateTimeConverter.ConvertToSeconds(startTime));
            parameters.AddOptionalParameter("end_time", DateTimeConverter.ConvertToSeconds(endTime));
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("direction", direction == null ? null : JsonConvert.SerializeObject(direction, new SearchDirectionConverter(false)));
            parameters.AddOptionalParameter("cursor", cursor);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitCursorPage<IEnumerable<BybitWithdraw>>>(_baseClient.GetUrl("/asset/v1/private/withdraw/record/query"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get asset info

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitAssetInfo>>> GetAssetInfoAsync(
            string? asset = null,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("coin", asset);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitData<IEnumerable<BybitAssetInfo>>>(_baseClient.GetUrl("/asset/v1/private/coin-info/query"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
            return result.As<IEnumerable<BybitAssetInfo>>(result.Data?.Data);
        }

        #endregion

        #region Get account info

        /// <inheritdoc />
        public async Task<WebCallResult<Dictionary<string, BybitGeneralAccountStatus>>> GetAccountInfoAsync(
            string? asset = null,
            string? accountType = null,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("coin", asset);
            parameters.AddOptionalParameter("account_type", accountType);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<Dictionary<string, BybitGeneralAccountStatus>>(_baseClient.GetUrl("/asset/v1/private/asset-info/query"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Withdraw

        /// <inheritdoc />
        public async Task<WebCallResult<BybitId>> WithdrawAsync(
            string asset,
            string network,
            string address,
            decimal quantity,
            string? tag = null,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "coin", asset },
                { "chain", network },
                { "address", address },
                { "quantity", quantity.ToString(CultureInfo.InvariantCulture) }
            };
            parameters.AddOptionalParameter("tag", tag);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitId>(_baseClient.GetUrl("/asset/v1/private/withdraw"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Cancel withdrawal

        /// <inheritdoc />
        public async Task<WebCallResult> CancelWithdrawalAsync(
            string withdrawalId,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "id", withdrawalId }
            };
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("/asset/v1/private/withdraw/cancel"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return result.AsDataless();
        }

        #endregion

        #region Get account info

        /// <inheritdoc />
        public async Task<WebCallResult<BybitDepositAddress>> GetDepositAddressesAsync(
            string asset,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("coin", asset);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitDepositAddress>(_baseClient.GetUrl("/asset/v1/private/deposit/address"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion
    }
}
