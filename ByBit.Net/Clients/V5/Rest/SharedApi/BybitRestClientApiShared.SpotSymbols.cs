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
        #region Spot Symbol client
        public SharedSymbolCatalog? SpotSymbolCatalog => ExchangeSymbolCache.GetSymbolCatalog(_exchangeName, _topicSpotId, _api.EnvironmentName, null);

        public GetSpotSymbolsOptions GetSpotSymbolsOptions { get; } = new GetSpotSymbolsOptions(_exchangeName, false);
        public async Task<HttpResult<SharedSpotSymbol[]>> GetSpotSymbolsAsync(GetSymbolsRequest request, CancellationToken ct)
        {
            var validationError = GetSpotSymbolsOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedSpotSymbol[]>(Exchange, validationError);

            var result = await _api.ExchangeData.GetSpotSymbolsAsync(ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedSpotSymbol[]>(result);

            var data = result.Data.List
               .Select(x => ParseSymbol(x)!)
               .Where(x => x != null)
               .ToArray();

            ExchangeSymbolCache.UpdateSymbolInfo(_topicSpotId, _api.EnvironmentName, null, data);
            return HttpResult.Ok(result, SharedUtils.ApplySymbolFilter(data, request));
        }

        private SharedSpotSymbol ParseSymbol(BybitSpotSymbol s)
        {
            var result = new SharedSpotSymbol(s.BaseAsset, s.QuoteAsset, s.Name, s.Status == SymbolStatus.Trading)
            {
                MinTradeQuantity = s.LotSizeFilter?.MinOrderQuantity,
                MaxTradeQuantity = s.LotSizeFilter?.MaxOrderQuantity,
                MinNotionalValue = s.LotSizeFilter?.MinOrderValue,
                QuantityStep = s.LotSizeFilter?.BasePrecision,
                PriceStep = s.PriceFilter?.TickSize,
                DisplayName = s.Name                
            };

            if (s.SymbolType == SymbolType.XStocks)
            {
                result.BaseAssetType = SharedAssetType.TradFi;
                result.BaseAssetSubType = SharedAssetSubType.Equity;
            }
            else if (LibraryHelpers.IsCommodity(result.BaseAsset))
            {
                result.BaseAssetType = SharedAssetType.TradFi;
                result.BaseAssetSubType = SharedAssetSubType.Commodity;
            }
            else if (LibraryHelpers.IsStableCoin(result.BaseAsset))
            {
                result.BaseAssetType = SharedAssetType.Crypto;
                result.BaseAssetSubType = SharedAssetSubType.StableCoin;
            }
            else if (_exchangeSupportedFiat.Contains(result.BaseAsset))
            {
                result.BaseAssetType = SharedAssetType.Fiat;
            }
            else
            {
                result.BaseAssetType = SharedAssetType.Crypto;
            }

            if (LibraryHelpers.IsStableCoin(result.QuoteAsset))
            {
                result.QuoteAssetType = SharedAssetType.Crypto;
                result.QuoteAssetSubType = SharedAssetSubType.StableCoin;
            }
            else if (_exchangeSupportedFiat.Contains(result.QuoteAsset))
            {
                result.QuoteAssetType = SharedAssetType.Fiat;
            }
            else
            {
                result.QuoteAssetType = SharedAssetType.Crypto;
            }

                return result;
        }

        public async Task<ExchangeCallResult<SharedSymbol[]>> GetSpotSymbolsForBaseAssetAsync(string baseAsset)
        {
            if (!ExchangeSymbolCache.HasCached(_topicSpotId, _api.EnvironmentName, null))
            {
                var symbols = await GetSpotSymbolsAsync(new GetSymbolsRequest(), default).ConfigureAwait(false);
                if (!symbols.Success)
                    return ExchangeCallResult<SharedSymbol[]>.Fail(Exchange, symbols.Error!);
            }

            return ExchangeCallResult<SharedSymbol[]>.Ok(Exchange, ExchangeSymbolCache.GetSymbolsForBaseAsset(_topicSpotId, _api.EnvironmentName, null, baseAsset));
        }

        public async Task<ExchangeCallResult<bool>> SupportsSpotSymbolAsync(SharedSymbol symbol)
        {
            if (symbol.TradingMode != TradingMode.Spot)
                throw new ArgumentException(nameof(symbol), "Only Spot symbols allowed");

            if (!ExchangeSymbolCache.HasCached(_topicSpotId, _api.EnvironmentName, null))
            {
                var symbols = await GetSpotSymbolsAsync(new GetSymbolsRequest(), default).ConfigureAwait(false);
                if (!symbols.Success)
                    return ExchangeCallResult<bool>.Fail(Exchange, symbols.Error!);
            }

            return ExchangeCallResult<bool>.Ok(Exchange, ExchangeSymbolCache.SupportsSymbol(_topicSpotId, _api.EnvironmentName, null, symbol));
        }

        public async Task<ExchangeCallResult<bool>> SupportsSpotSymbolAsync(string symbolName)
        {
            if (!ExchangeSymbolCache.HasCached(_topicSpotId, _api.EnvironmentName, null))
            {
                var symbols = await GetSpotSymbolsAsync(new GetSymbolsRequest(), default).ConfigureAwait(false);
                if (!symbols.Success)
                    return ExchangeCallResult<bool>.Fail(Exchange, symbols.Error!);
            }

            return ExchangeCallResult<bool>.Ok(Exchange, ExchangeSymbolCache.SupportsSymbol(_topicSpotId, _api.EnvironmentName, null, symbolName));
        }
        #endregion
    }
}
