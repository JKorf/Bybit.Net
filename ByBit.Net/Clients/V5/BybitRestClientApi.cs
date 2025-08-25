using Bybit.Net.Objects.Internal;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Bybit.Net.Interfaces.Clients.V5;
using Microsoft.Extensions.Logging;
using Bybit.Net.Objects.Options;
using System.Linq;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.MessageParsing;
using CryptoExchange.Net.Interfaces;
using Bybit.Net.Interfaces.Clients;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.Objects.Errors;

namespace Bybit.Net.Clients.V5
{
    /// <inheritdoc cref="IBybitRestClientApi"/>
    internal partial class BybitRestClientApi : RestApiClient, IBybitRestClientApi
    {
        internal TimeSyncState _timeSyncState = new TimeSyncState("Bybit V5 API");

        protected override ErrorMapping ErrorMapping => BybitErrors.RestErrors;

        public IBybitRestClientApiShared SharedClient => this;

        /// <summary>
        /// Options
        /// </summary>
        public new BybitRestOptions ClientOptions => (BybitRestOptions)base.ClientOptions;

        /// <inheritdoc />
        public IBybitRestClientApiAccount Account { get; }
        /// <inheritdoc />
        public IBybitRestClientApiExchangeData ExchangeData { get; }
        /// <inheritdoc />
        public IBybitRestClientApiTrading Trading { get; }
        /// <inheritdoc />
        public IBybitRestClientApiSubAccounts SubAccount { get; }
        /// <inheritdoc />
        public IBybitRestClientApiCryptoLoan CryptoLoan { get; }
        /// <inheritdoc />
        public IBybitRestClientApiEarn Earn { get; }

        /// <inheritdoc />
        public string ExchangeName => "Bybit";

        internal string _referer = "Zx000356";

        #region ctor
        internal BybitRestClientApi(ILogger logger, HttpClient? httpClient, BybitRestOptions options) :
            base(logger, httpClient, options.Environment.RestBaseAddress, options, options.V5Options)
        {
            _referer = !string.IsNullOrEmpty(options.Referer) ? options.Referer! : _referer;
            StandardRequestHeaders = new Dictionary<string, string>
            {
                { "Referer", _referer }
            };

            Account = new BybitRestClientApiAccount(this);
            ExchangeData = new BybitRestClientApiExchangeData(this);
            Trading = new BybitRestClientApiTrading(this);
            SubAccount = new BybitRestClientApiSubAccounts(this);
            CryptoLoan = new BybitRestClientApiCryptoLoan(this);
            Earn = new BybitRestClientApiEarn(this);

            RequestBodyFormat = RequestBodyFormat.Json;
            ParameterPositions[HttpMethod.Delete] = HttpMethodParameterPosition.InUri;
        }
        #endregion

        protected override IStreamMessageAccessor CreateAccessor() => new SystemTextJsonStreamMessageAccessor(SerializerOptions.WithConverters(BybitExchange._serializerContext));
        protected override IMessageSerializer CreateSerializer() => new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(BybitExchange._serializerContext));

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new BybitAuthenticationProvider(credentials);

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
                => BybitExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverTime);

        /// <summary>
        /// Get url for an endpoint
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        internal Uri GetUrl(string endpoint)
        {
            return new Uri(BaseAddress.AppendPath(endpoint));
        }

        /// <inheritdoc />
        protected override async Task<WebCallResult<DateTime>> GetServerTimestampAsync()
        {
            var time = await ExchangeData.GetServerTimeAsync().ConfigureAwait(false);
            if (!time)
                return time.As<DateTime>(default);

            return time.As(time.Data.TimeNano);
        }

        /// <inheritdoc />
        public override TimeSyncInfo? GetTimeSyncInfo()
            => new TimeSyncInfo(_logger, (ApiOptions.AutoTimestamp ?? ClientOptions.AutoTimestamp), (ApiOptions.TimestampRecalculationInterval ?? ClientOptions.TimestampRecalculationInterval), _timeSyncState);

        /// <inheritdoc />
        public override TimeSpan? GetTimeOffset()
            => _timeSyncState.TimeOffset;

        internal async Task<WebCallResult> SendAsync(RequestDefinition definition, ParameterCollection? parameters, CancellationToken cancellationToken, int? weight = null, int? singleLimiterWeight = null)
        {
            var result = await base.SendAsync<BybitResult>(BaseAddress, definition, parameters, cancellationToken, null, weight, weightSingleLimiter: singleLimiterWeight).ConfigureAwait(false);
            if (!result)
                return result.AsDataless();

            if (result.Data.ReturnCode != 0)
                return result.AsDatalessError(new ServerError(result.Data.ReturnCode, GetErrorInfo(result.Data.ReturnCode, result.Data.ReturnMessage)));

            return result.AsDataless();
        }

        internal async Task<WebCallResult<T>> SendAsync<T>(RequestDefinition definition, ParameterCollection? parameters, CancellationToken cancellationToken, int? weight = null, int? singleLimiterWeight = null)
        {
            var result = await base.SendAsync<BybitResult<T>>(BaseAddress, definition, parameters, cancellationToken, null, weight, weightSingleLimiter: singleLimiterWeight).ConfigureAwait(false);
            if (!result)
                return result.As<T>(default);

            if (result.Data.ReturnCode != 0)
                return result.AsError<T>(new ServerError(result.Data.ReturnCode, GetErrorInfo(result.Data.ReturnCode, result.Data.ReturnMessage)));

            return result.As(result.Data.Result);
        }

        internal async Task<WebCallResult<BybitExtResult<T,U>>> SendRawAsync<T,U>(RequestDefinition definition, ParameterCollection? parameters, CancellationToken cancellationToken, int? weight = null, int? singleLimiterWeight = null)
        {
            return await base.SendAsync<BybitExtResult<T,U>>(BaseAddress, definition, parameters, cancellationToken, null, weight, weightSingleLimiter: singleLimiterWeight).ConfigureAwait(false);
        }

        protected override Error? TryParseError(RequestDefinition request, KeyValuePair<string, string[]>[] responseHeaders, IMessageAccessor accessor)
        {
            var code = accessor.GetValue<int?>(MessagePath.Get().Property("retCode"));
            if (code == null || code == 0)
                return null;

            if (code == 10006)
            {
                // Rate limit error
                var error = new ServerRateLimitError(accessor.GetValue<string>(MessagePath.Get().Property("retMsg"))!);
                var retryAfterHeader = responseHeaders.SingleOrDefault(r => r.Key.Equals("X-Bapi-Limit-Reset-Timestamp", StringComparison.InvariantCultureIgnoreCase));
                if (retryAfterHeader.Value?.Any() != true)
                    return error;

                var value = retryAfterHeader.Value.First();
                if (!long.TryParse(value, out var timestamp))
                    return error;

                var time = DateTimeConverter.ConvertFromMilliseconds(timestamp);
                error.RetryAfter = time;
                return error;
            }

            var msg = accessor.GetValue<string>(MessagePath.Get().Property("retMsg"));
            return new ServerError(code.Value, GetErrorInfo(code.Value, msg));
        }

        /// <inheritdoc />
        protected override Error ParseErrorResponse(int httpStatusCode, KeyValuePair<string, string[]>[] responseHeaders, IMessageAccessor accessor, Exception? exception)
        {
            if (!accessor.IsValid)
            {
                if (httpStatusCode == 401)
                    return new ServerError(new ErrorInfo(ErrorType.Unauthorized, "Unauthorized"));

                return new ServerError(ErrorInfo.Unknown, exception: exception);
            }

            var code = accessor.GetValue<int?>(MessagePath.Get().Property("retCode"));
            var msg = accessor.GetValue<string>(MessagePath.Get().Property("retMsg"));
            if (msg == null)
                return new ServerError(ErrorInfo.Unknown, exception: exception);

            if (code == null)
                return new ServerError(ErrorInfo.Unknown with { Message = msg }, exception);

            return new ServerError(code.Value, GetErrorInfo(code.Value, msg), exception);
        }
    }
}
