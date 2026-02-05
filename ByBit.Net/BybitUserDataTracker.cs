using Bybit.Net.Interfaces.Clients;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.Trackers.UserData;
using CryptoExchange.Net.Trackers.UserData.Objects;
using Microsoft.Extensions.Logging;

namespace Bybit.Net
{
    /// <inheritdoc/>
    public class BybitUserSpotDataTracker : UserSpotDataTracker
    {
        /// <summary>
        /// ctor
        /// </summary>
        public BybitUserSpotDataTracker(
            ILogger<BybitUserSpotDataTracker> logger,
            IBybitRestClient restClient,
            IBybitSocketClient socketClient,
            string? userIdentifier,
            SpotUserDataTrackerConfig? config) : base(
                logger,
                restClient.V5Api.SharedClient,
                null,
                restClient.V5Api.SharedClient,
                socketClient.V5PrivateApi.SharedClient,
                restClient.V5Api.SharedClient,
                socketClient.V5PrivateApi.SharedClient,
                socketClient.V5PrivateApi.SharedClient,
                userIdentifier,
                config ?? new SpotUserDataTrackerConfig())
        {
        }
    }

    /// <inheritdoc/>
    public class BybitUserFuturesDataTracker : UserFuturesDataTracker
    {
        /// <inheritdoc/>
        protected override bool WebsocketPositionUpdatesAreFullSnapshots => false;

        /// <summary>
        /// ctor
        /// </summary>
        public BybitUserFuturesDataTracker(
            ILogger<BybitUserFuturesDataTracker> logger,
            IBybitRestClient restClient,
            IBybitSocketClient socketClient,
            string? userIdentifier,
            FuturesUserDataTrackerConfig? config) : base(logger,
                restClient.V5Api.SharedClient,
                null,
                restClient.V5Api.SharedClient,
                socketClient.V5PrivateApi.SharedClient,
                restClient.V5Api.SharedClient,
                socketClient.V5PrivateApi.SharedClient,
                socketClient.V5PrivateApi.SharedClient,
                socketClient.V5PrivateApi.SharedClient,
                userIdentifier,
                config ?? new FuturesUserDataTrackerConfig())
        {
        }
    }
}
