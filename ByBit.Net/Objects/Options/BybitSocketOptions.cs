using CryptoExchange.Net.Objects.Options;
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
        /// ctor
        /// </summary>
        public BybitSocketOptions()
        {
            Default?.Set(this);
        }

        /// <summary>
        /// A referer, will be sent in the Referer header
        /// </summary>
        public string? Referer { get; set; }

        /// <summary>
        /// Options for the Spot V3 API
        /// </summary>
        public BybitSocketApiOptions SpotV3Options { get; private set; } = new BybitSocketApiOptions();
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

        internal BybitSocketOptions Set(BybitSocketOptions targetOptions)
        {
            targetOptions = base.Set<BybitSocketOptions>(targetOptions);
            targetOptions.Referer = Referer;
            targetOptions.SpotV3Options = SpotV3Options.Set(targetOptions.SpotV3Options);
            targetOptions.DerivativesPublicOptions = DerivativesPublicOptions.Set(targetOptions.DerivativesPublicOptions);
            targetOptions.UnifiedMarginOptions = UnifiedMarginOptions.Set(targetOptions.UnifiedMarginOptions);
            targetOptions.ContractOptions = ContractOptions.Set(targetOptions.ContractOptions);
            targetOptions.V5Options = V5Options.Set(targetOptions.V5Options);
            return targetOptions;
        }
    }
}
