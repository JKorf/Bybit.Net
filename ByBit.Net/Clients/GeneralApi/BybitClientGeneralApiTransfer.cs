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
    public class BybitClientGeneralApiTransfer : IBybitClientGeneralApiTransfer
    {
        private BybitClientGeneralApi _baseClient;

        internal BybitClientGeneralApiTransfer(BybitClientGeneralApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Create internal transfer

        /// <inheritdoc />
        public async Task<WebCallResult<BybitTransfer>> CreateInternalTransferAsync(string transferId, string asset, decimal quantity, AccountType fromAccountType, AccountType toAccountType, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "transfer_id", transferId },
                { "coin", asset },
                { "amount", quantity.ToString(CultureInfo.InvariantCulture) },
                { "from_account_type", EnumConverter.GetString(fromAccountType)! },
                { "to_account_type", EnumConverter.GetString(toAccountType)! },
            };
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitTransfer>(_baseClient.GetUrl("asset/v1/private/transfer"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Create subaccount transfer

        /// <inheritdoc />
        public async Task<WebCallResult<BybitTransfer>> CreateSubAccountTransferAsync(string transferId, string asset, decimal quantity, string subAccountId, TransferType type, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "transfer_id", transferId },
                { "coin", asset },
                { "amount", quantity.ToString(CultureInfo.InvariantCulture) },
                { "sub_user_id", subAccountId },
                { "type", EnumConverter.GetString(type)! },
            };
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitTransfer>(_baseClient.GetUrl("asset/v1/private/sub-member/transfer"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get transfer history

        /// <inheritdoc />
        public async Task<WebCallResult<BybitCursorPage<IEnumerable<BybitInternalTransferDetails>>>> GetTransferHistoryAsync(
            string? transferId = null,
            string? asset = null,
            TransferStatus? status = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            SearchDirection? direction = null,
            int? limit = null,
            string? cursor = null,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("transfer_id", transferId);
            parameters.AddOptionalParameter("coin", asset);
            parameters.AddOptionalParameter("status", EnumConverter.GetString(status));
            parameters.AddOptionalParameter("start_time", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("end_time", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("direction", transferId);
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("direction", direction == null ? null : JsonConvert.SerializeObject(direction, new SearchDirectionConverter(false)));
            parameters.AddOptionalParameter("cursor", cursor);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitCursorPage<IEnumerable<BybitInternalTransferDetails>>>(_baseClient.GetUrl("asset/v1/private/transfer/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get subaccount transfer history

        /// <inheritdoc />
        public async Task<WebCallResult<BybitCursorPage<IEnumerable<BybitSubAccountTransferDetails>>>> GetSubAccountTransferHistoryAsync(
            string? transferId = null,
            string? asset = null,
            TransferStatus? status = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            SearchDirection? direction = null,
            int? limit = null,
            string? cursor = null,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("transfer_id", transferId);
            parameters.AddOptionalParameter("coin", asset);
            parameters.AddOptionalParameter("status", EnumConverter.GetString(status));
            parameters.AddOptionalParameter("start_time", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("end_time", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("direction", transferId);
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("direction", direction == null ? null : JsonConvert.SerializeObject(direction, new SearchDirectionConverter(false)));
            parameters.AddOptionalParameter("cursor", cursor);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitCursorPage<IEnumerable<BybitSubAccountTransferDetails>>>(_baseClient.GetUrl("asset/v1/private/sub-member/transfer/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get subaccounts

        /// <inheritdoc />
        public async Task<WebCallResult<BybitSubAccountList>> GetSubAccountsAsync(long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitSubAccountList>(_baseClient.GetUrl("asset/v1/private/sub-member/member-ids"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Enable Subaccounts Universal Transfer

        /// <inheritdoc />
        public async Task<WebCallResult> EnableSubaccountsUniversalTransferAsync(IEnumerable<string>? subaccountIds = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("transferable_sub_ids", subaccountIds == null ? null : string.Join(",", subaccountIds));
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("/asset/v1/private/transferable-subs/save"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return result.AsDataless();
        }

        #endregion

        #region Enable Subaccounts Universal Transfer

        /// <inheritdoc />
        public async Task<WebCallResult<BybitTransferId>> UniversalTransferAsync(string transferId, string asset, decimal quantity, string fromMemberId, string toMemberId, AccountType fromAccountType, AccountType toAccountType, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "transfer_id", transferId },
                { "coin", asset },
                { "amount", quantity.ToString(CultureInfo.InvariantCulture) },
                { "from_member_id", fromMemberId },
                { "to_member_id", toMemberId },
                { "from_account_type", EnumConverter.GetString(fromAccountType) },
                { "to_account_type", EnumConverter.GetString(toAccountType) },
            };

            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitTransferId>(_baseClient.GetUrl("/asset/v1/private/universal/transfer"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get universal transfer history

        /// <inheritdoc />
        public async Task<WebCallResult<BybitCursorPage<IEnumerable<BybitUniversalTransfer>>>> GetUniversalTransferHistoryAsync(
            string? transferId = null,
            string? asset = null,
            TransferStatus? status = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            SearchDirection? direction = null,
            int? limit = null,
            string? cursor = null,
            long? receiveWindow = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("transfer_id", transferId);
            parameters.AddOptionalParameter("coin", asset);
            parameters.AddOptionalParameter("status", EnumConverter.GetString(status));
            parameters.AddOptionalParameter("start_time", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("end_time", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("direction", transferId);
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("direction", direction == null ? null : JsonConvert.SerializeObject(direction, new SearchDirectionConverter(false)));
            parameters.AddOptionalParameter("cursor", cursor);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitCursorPage<IEnumerable<BybitUniversalTransfer>>>(_baseClient.GetUrl("asset/v1/private/universal/transfer/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion
    }
}
