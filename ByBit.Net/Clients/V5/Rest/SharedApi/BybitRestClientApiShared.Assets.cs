using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.SharedApis;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Bybit.Net.Clients.V5
{
    internal partial class BybitRestClientSharedApi
    {
        #region Asset client
        public GetAssetOptions GetAssetOptions { get; } = new GetAssetOptions(_exchangeName, false);
        public async Task<HttpResult<SharedAsset>> GetAssetAsync(GetAssetRequest request, CancellationToken ct)
        {
            var validationError = GetAssetOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedAsset>(Exchange, validationError);

            var assets = await _api.Account.GetAssetInfoAsync(request.Asset, ct: ct).ConfigureAwait(false);
            if (!assets.Success)
                return HttpResult.Fail<SharedAsset>(assets);

            var asset = assets.Data.Assets.SingleOrDefault();
            if (asset == null)
                return HttpResult.Fail<SharedAsset>(assets, new ServerError(new ErrorInfo(ErrorType.UnknownAsset, "Asset not found")));

            return HttpResult.Ok(assets, new SharedAsset(asset.Name)
            {
                Networks = asset.Networks.Select(x => new SharedAssetNetwork(x.Network)
                {
                    MinConfirmations = x.Confirmation,
                    DepositEnabled = x.NetworkDeposit,
                    MinWithdrawQuantity = x.MinWithdraw,
                    WithdrawEnabled = x.NetworkWithdraw,
                    WithdrawFee = x.WithdrawFee,
                    ContractAddress = x.ContractAddress
                }).ToArray()
            });
        }

        Task<HttpResult<SharedAsset[]>> IAssetsRestClient.GetAssetsAsync(GetAssetsRequest request, CancellationToken ct)
            => GetAllAssetsAsync(request, ct);
        GetAllAssetsOptions IAssetsRestClient.GetAssetsOptions => GetAllAssetsOptions;

        public GetAllAssetsOptions GetAllAssetsOptions { get; } = new GetAllAssetsOptions(_exchangeName, true);
        public async Task<HttpResult<SharedAsset[]>> GetAllAssetsAsync(GetAssetsRequest request, CancellationToken ct)
        {
            var validationError = GetAllAssetsOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedAsset[]>(Exchange, validationError);

            var assets = await _api.Account.GetAssetInfoAsync(ct: ct).ConfigureAwait(false);
            if (!assets.Success)
                return HttpResult.Fail<SharedAsset[]>(assets);

            return HttpResult.Ok(assets, assets.Data.Assets.Select(x => new SharedAsset(x.Name)
            {
                Networks = x.Networks.Select(x => new SharedAssetNetwork(x.Network)
                {
                    MinConfirmations = x.Confirmation,
                    DepositEnabled = x.NetworkDeposit,
                    MinWithdrawQuantity = x.MinWithdraw,
                    WithdrawEnabled = x.NetworkWithdraw,
                    WithdrawFee = x.WithdrawFee,
                    ContractAddress = x.ContractAddress
                }).ToArray()
            }).ToArray());
        }

        #endregion
    }
}
