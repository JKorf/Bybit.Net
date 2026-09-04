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
        #region Get Futures Symbols

        public SharedSymbolCatalog? FuturesSymbolCatalog => ExchangeSymbolCache.GetSymbolCatalog(_exchangeName, _topicFuturesId, _api.EnvironmentName, null);
        async Task<ICallResult<SharedFuturesSymbol[]>> IGetFuturesSymbols.GetFuturesSymbolsAsync(GetSymbolsRequest request, CancellationToken ct)
            => await GetFuturesSymbolsAsync(request, ct).ConfigureAwait(false);

        public GetFuturesSymbolsOptions GetFuturesSymbolsOptions { get; } = new GetFuturesSymbolsOptions(_exchangeName, false);
        public async Task<HttpResult<SharedFuturesSymbol[]>> GetFuturesSymbolsAsync(GetSymbolsRequest request, CancellationToken ct)
        {
            var validationError = GetFuturesSymbolsOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesSymbol[]>(Exchange, validationError);

            var category = (request.TradingMode == null || request.TradingMode == TradingMode.PerpetualLinear || request.TradingMode == TradingMode.DeliveryLinear) ? Category.Linear : Category.Inverse;
            var result = await _api.ExchangeData.GetLinearInverseSymbolsAsync(category, limit: 1000, ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedFuturesSymbol[]>(result);

            var data = result.Data.List
                .Select(x => ParseSymbol(x))
                .ToArray();

            ExchangeSymbolCache.UpdateSymbolInfo(_topicFuturesId, _api.EnvironmentName, category.ToString(), data);
            return HttpResult.Ok(result, SharedUtils.ApplySymbolFilter(data, request));
        }

        #endregion

        private SharedFuturesSymbol ParseSymbol(BybitLinearInverseSymbol s)
        {
            var result = new SharedFuturesSymbol(
                s.ContractType == ContractTypeV5.LinearPerpetual ? TradingMode.PerpetualLinear :
                s.ContractType == ContractTypeV5.InversePerpetual ? TradingMode.PerpetualInverse :
                s.ContractType == ContractTypeV5.LinearFutures ? TradingMode.DeliveryLinear :
                TradingMode.DeliveryInverse,
                s.BaseAsset, s.QuoteAsset, s.Name, s.Status == SymbolStatus.Trading)
            {
                MinTradeQuantity = s.LotSizeFilter?.MinOrderQuantity,
                MinNotionalValue = s.LotSizeFilter?.MinNotionalValue,
                PriceStep = s.PriceFilter?.TickSize,
                QuantityStep = s.LotSizeFilter?.QuantityStep,
                DeliveryTime = s.DeliveryTime,
                ContractSize = 1,
                MaxLongLeverage = s.LeverageFilter?.MaxLeverage,
                MaxShortLeverage = s.LeverageFilter?.MaxLeverage,
                DisplayName = !string.IsNullOrEmpty(s.DisplayName) ? s.DisplayName : s.Name,
                LowerFundingCap = s.LowerFundingRate,
                UpperFundingCap = s.UpperFundingRate,
            };

            if (result.TradingMode.IsInverse())
            {
                result.QuoteAssetType = SharedAssetType.Fiat;
            }
            else
            {
                result.QuoteAssetType = SharedAssetType.Crypto;
                result.QuoteAssetSubType = SharedAssetSubType.StableCoin;
            }

            if (s.SymbolType == SymbolType.Stock
                || s.SymbolType == SymbolType.XStocks
                || s.SymbolType == SymbolType.Etf)
            {
                result.BaseAssetType = SharedAssetType.TradFi;
                result.BaseAssetSubType = SharedAssetSubType.Equity;
            }
            else if (s.SymbolType == SymbolType.Commodity)
            {
                result.BaseAssetType = SharedAssetType.TradFi;
                result.BaseAssetSubType = SharedAssetSubType.Commodity;
            }
            else if (s.SymbolType == SymbolType.Forex)
            {
                result.BaseAssetType = SharedAssetType.Fiat;
            }
            else
            {
                result.BaseAssetType = SharedAssetType.Crypto;

                if (LibraryHelpers.IsStableCoin(result.BaseAsset))
                    result.BaseAssetSubType = SharedAssetSubType.StableCoin;
            }

            return result;
        }

        public async Task<ExchangeCallResult<SharedSymbol[]>> GetFuturesSymbolsForBaseAssetAsync(string baseAsset)
        {
            if (!ExchangeSymbolCache.HasCached(_topicFuturesId, _api.EnvironmentName, null))
            {
                var symbols = await GetFuturesSymbolsAsync(new GetSymbolsRequest(), default).ConfigureAwait(false);
                if (!symbols.Success)
                    return ExchangeCallResult<SharedSymbol[]>.Fail(Exchange, symbols.Error!);
            }

            return ExchangeCallResult<SharedSymbol[]>.Ok(Exchange, ExchangeSymbolCache.GetSymbolsForBaseAsset(_topicFuturesId, _api.EnvironmentName, null, baseAsset));
        }

        public async Task<ExchangeCallResult<bool>> SupportsFuturesSymbolAsync(SharedSymbol symbol)
        {
            if (symbol.TradingMode == TradingMode.Spot)
                throw new ArgumentException(nameof(symbol), "Spot symbols not allowed");

            if (!ExchangeSymbolCache.HasCached(_topicFuturesId, _api.EnvironmentName, null))
            {
                var symbols = await GetFuturesSymbolsAsync(new GetSymbolsRequest(), default).ConfigureAwait(false);
                if (!symbols.Success)
                    return ExchangeCallResult<bool>.Fail(Exchange, symbols.Error!);
            }

            return ExchangeCallResult<bool>.Ok(Exchange, ExchangeSymbolCache.SupportsSymbol(_topicFuturesId, _api.EnvironmentName, null, symbol));
        }

        public async Task<ExchangeCallResult<bool>> SupportsFuturesSymbolAsync(string symbolName)
        {
            if (!ExchangeSymbolCache.HasCached(_topicFuturesId, _api.EnvironmentName, null))
            {
                var symbols = await GetFuturesSymbolsAsync(new GetSymbolsRequest(), default).ConfigureAwait(false);
                if (!symbols.Success)
                    return ExchangeCallResult<bool>.Fail(Exchange, symbols.Error!);
            }

            return ExchangeCallResult<bool>.Ok(Exchange, ExchangeSymbolCache.SupportsSymbol(_topicFuturesId, _api.EnvironmentName, null, symbolName));
        }
    }
}
