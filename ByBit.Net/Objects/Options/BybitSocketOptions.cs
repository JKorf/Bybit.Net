﻿using CryptoExchange.Net.Objects.Options;
using System;

namespace Bybit.Net.Objects.Options
{
    /// <summary>
    /// Options for the BybitSocketClient
    /// </summary>
    public class BybitSocketOptions : SocketExchangeOptions<BybitEnvironment>
    {
        /// <summary>
        /// Default options for the socket client
        /// </summary>
        public static BybitSocketOptions Default { get; set; } = new BybitSocketOptions()
        {
            Environment = BybitEnvironment.Live,
            SocketSubscriptionsCombineTarget = 10,
            SocketNoDataTimeout = TimeSpan.FromSeconds(30)
        };

        /// <summary>
        /// Options for the Inverse Futures API
        /// </summary>
        public BybitSocketApiOptions InverseFuturesOptions { get; private set; } = new BybitSocketApiOptions();
        /// <summary>
        /// Options for the Inverse Perpetual API
        /// </summary>
        public BybitSocketApiOptions InversePerpetualOptions { get; private set; } = new BybitSocketApiOptions();
        /// <summary>
        /// Options for the Usd Perpetual API
        /// </summary>
        public BybitSocketApiOptions UsdPerpetualOptions { get; private set; } = new BybitSocketApiOptions();
        /// <summary>
        /// Options for the Spot V1 API
        /// </summary>
        public BybitSocketApiOptions SpotV1Options { get; private set; } = new BybitSocketApiOptions();
        /// <summary>
        /// Options for the Spot V2 API
        /// </summary>
        public BybitSocketApiOptions SpotV2Options { get; private set; } = new BybitSocketApiOptions();
        /// <summary>
        /// Options for the Spot V3 API
        /// </summary>
        public BybitSocketApiOptions SpotV3Options { get; private set; } = new BybitSocketApiOptions();
        /// <summary>
        /// Options for the Copy Trading API
        /// </summary>
        public BybitSocketApiOptions CopyTradingOptions { get; private set; } = new BybitSocketApiOptions();
        /// <summary>
        /// Options for the Public Derivatives API
        /// </summary>
        public BybitSocketApiOptions DerivativesPublicOptions { get; private set; } = new BybitSocketApiOptions();
        /// <summary>
        /// Options for the Unified margin API
        /// </summary>
        public BybitSocketApiOptions UnifiedMarginOptions { get; private set; } = new BybitSocketApiOptions();
        /// <summary>
        /// Options for the Contract API
        /// </summary>
        public BybitSocketApiOptions ContractOptions { get; private set; } = new BybitSocketApiOptions();
        /// <summary>
        /// Options for the V5 API
        /// </summary>
        public BybitSocketApiOptions V5Options { get; private set; } = new BybitSocketApiOptions();

        internal BybitSocketOptions Copy()
        {
            var options = Copy<BybitSocketOptions>();
            options.InverseFuturesOptions = InverseFuturesOptions.Copy();
            options.InversePerpetualOptions = InversePerpetualOptions.Copy();
            options.UsdPerpetualOptions = UsdPerpetualOptions.Copy();
            options.SpotV1Options = SpotV1Options.Copy();
            options.SpotV2Options = SpotV2Options.Copy();
            options.SpotV3Options = SpotV3Options.Copy();
            options.CopyTradingOptions = CopyTradingOptions.Copy();
            options.DerivativesPublicOptions = DerivativesPublicOptions.Copy();
            options.UnifiedMarginOptions = UnifiedMarginOptions.Copy();
            options.ContractOptions = ContractOptions.Copy();
            options.V5Options = V5Options.Copy();
            return options;
        }
    }
}
