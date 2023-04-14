using Bybit.Net.Objects;
using CryptoExchange.Net;
using System;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Interfaces.Clients.UsdPerpetualApi;
using Bybit.Net.Interfaces.Clients.InversePerpetualApi;
using Bybit.Net.Clients.InversePerpetualApi;
using Bybit.Net.Clients.UsdPerpetualApi;
using Bybit.Net.Clients.SpotApi.v1;
using Bybit.Net.Clients.SpotApi.v2;
using Bybit.Net.Clients.SpotApi.v3;
using Bybit.Net.Interfaces.Clients.SpotApi.v1;
using Bybit.Net.Interfaces.Clients.SpotApi.v2;
using Bybit.Net.Interfaces.Clients.SpotApi.v3;
using Bybit.Net.Interfaces.Clients.DerivativesApi.UnifiedMarginApi;
using Bybit.Net.Interfaces.Clients.DerivativesApi.ContractApi;
using Bybit.Net.Clients.DerivativesApi.UnifiedMarginApi;
using Bybit.Net.Clients.DerivativesApi.ContractApi;
using Bybit.Net.Clients.DerivativesApi;
using Bybit.Net.Interfaces.Clients.DerivativesApi;
using CryptoExchange.Net.Authentication;
using Bybit.Net.Clients.V5;
using Bybit.Net.Interfaces.Clients.V5;

namespace Bybit.Net.Clients
{
    /// <inheritdoc cref="IBybitSocketClient" />
    public class BybitSocketClient : BaseSocketClient, IBybitSocketClient
    {
        /// <inheritdoc />
        public IBybitSocketClientUsdPerpetualStreams UsdPerpetualStreams { get; }
        /// <inheritdoc />
        public IBybitSocketClientInversePerpetualStreams InversePerpetualStreams { get; }
        /// <inheritdoc />
        public IBybitSocketClientSpotStreamsV1 SpotStreamsV1 { get; }
        /// <inheritdoc />
        public IBybitSocketClientSpotStreamsV2 SpotStreamsV2 { get; }
        /// <inheritdoc />
        public IBybitSocketClientSpotStreamsV3 SpotStreamsV3 { get; }

        /// <inheritdoc />
        public IBybitSocketClientCopyTradingStreams CopyTrading { get; }

        /// <inheritdoc />
        public IBybitSocketClientDerivativesPublicStreams DerivativesPublic { get; }
        /// <inheritdoc />
        public IBybitSocketClientUnifiedMarginStreams UnifiedMarginPrivate { get; }
        /// <inheritdoc />
        public IBybitSocketClientContractStreams ContractPrivate { get; }
        /// <inheritdoc />
        public IBybitSocketClientSpotStreams V5SpotStreams { get; }
        /// <inheritdoc />
        public IBybitSocketClientLinearStreams V5LinearStreams { get; }
        /// <inheritdoc />
        public IBybitSocketClientOptionStreams V5OptionsStreams { get; }
        /// <inheritdoc />
        public IBybitSocketClientPrivateStreams V5PrivateStreams { get; }

        /// <summary>
        /// Create a new instance of BybitSocketClientFutures using the default options
        /// </summary>
        public BybitSocketClient() : this(BybitSocketClientOptions.Default)
        {
        }

        /// <summary>
        /// Create a new instance of BybitSocketClient using provided options
        /// </summary>
        /// <param name="options">The options to use for this client</param>
        public BybitSocketClient(BybitSocketClientOptions options) : base("Bybit", options)
        {
            if (options == null)
                throw new ArgumentException("Cant pass null options, use empty constructor for default");

            UsdPerpetualStreams = AddApiClient(new BybitSocketClientUsdPerpetualStreams(log, this, options));
            InversePerpetualStreams = AddApiClient(new BybitSocketClientInversePerpetualStreams(log, options));
            SpotStreamsV1 = AddApiClient(new BybitSocketClientSpotStreamsV1(log, options));
            SpotStreamsV2 = AddApiClient(new BybitSocketClientSpotStreamsV2(log, options));
            SpotStreamsV3 = AddApiClient(new BybitSocketClientSpotStreamsV3(log, options));

            CopyTrading = AddApiClient(new BybitSocketClientCopyTradingStreams(log, options));

            DerivativesPublic = AddApiClient(new BybitSocketClientDerivativesPublicStreams(log, options));
            UnifiedMarginPrivate = AddApiClient(new BybitSocketClientUnifiedMarginStreams(log, options));
            ContractPrivate = AddApiClient(new BybitSocketClientContractStreams(log, options));

            V5SpotStreams = AddApiClient(new BybitSocketClientSpotStreams(log, options));
            V5LinearStreams = AddApiClient(new BybitSocketClientLinearStreams(log, options));
            V5OptionsStreams = AddApiClient(new BybitSocketClientOptionStreams(log, options));
            V5PrivateStreams = AddApiClient(new BybitSocketClientPrivateStreams(log, options));
        }

        /// <summary>
        /// Set the default options to be used when creating new clients
        /// </summary>
        /// <param name="options"></param>
        public static void SetDefaultOptions(BybitSocketClientOptions options)
        {
            BybitSocketClientOptions.Default = options;
        }

        /// <inheritdoc />
        public void SetApiCredentials(ApiCredentials credentials)
        {
            UsdPerpetualStreams.SetApiCredentials(credentials);
            InversePerpetualStreams.SetApiCredentials(credentials);
            SpotStreamsV1.SetApiCredentials(credentials);
            SpotStreamsV2.SetApiCredentials(credentials);
            SpotStreamsV3.SetApiCredentials(credentials);
            CopyTrading.SetApiCredentials(credentials);
            DerivativesPublic.SetApiCredentials(credentials);
            UnifiedMarginPrivate.SetApiCredentials(credentials);
            ContractPrivate.SetApiCredentials(credentials);
            V5LinearStreams.SetApiCredentials(credentials);
            V5OptionsStreams.SetApiCredentials(credentials);
            V5PrivateStreams.SetApiCredentials(credentials);
            V5SpotStreams.SetApiCredentials(credentials);
        }
    }
}
