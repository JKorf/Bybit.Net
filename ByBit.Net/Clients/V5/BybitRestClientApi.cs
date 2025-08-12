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

        protected override ErrorCollection ErrorMapping { get; } = new ErrorCollection(
            [
                new ErrorInfo(ErrorType.SignatureInvalid, false, "Signature error", "10004"),

                new ErrorInfo(ErrorType.TimestampInvalid, false, "Request expired", "-1"),
                new ErrorInfo(ErrorType.TimestampInvalid, false, "The request time exceeds the time window range", "10002"),

                new ErrorInfo(ErrorType.Timeout, false, "Server timeout", "10000"),
                new ErrorInfo(ErrorType.Timeout, false, "Server timeout", "170007"),
                new ErrorInfo(ErrorType.Timeout, false, "Order create timeout", "170146"),
                new ErrorInfo(ErrorType.Timeout, false, "Order cancel timeout", "170147"),
                new ErrorInfo(ErrorType.Timeout, false, "Order edit timeout", "170310"),

                new ErrorInfo(ErrorType.SystemError, true, "System load error, please retry", "429"),
                new ErrorInfo(ErrorType.SystemError, true, "Server error", "10016"),
                new ErrorInfo(ErrorType.SystemError, true, "Server error, please retry later", "3400214", "131230"),
                new ErrorInfo(ErrorType.SystemError, true, "Internal error", "170001", "131003", "131201"),
                new ErrorInfo(ErrorType.SystemError, true, "Network error", "170032"),
                new ErrorInfo(ErrorType.SystemError, true, "System error", "170234", "131200"),

                new ErrorInfo(ErrorType.Unauthorized, false, "Your api key has expired", "-2015", "33004"),
                new ErrorInfo(ErrorType.Unauthorized, false, "Api key invalid", "10003"),
                new ErrorInfo(ErrorType.Unauthorized, false, "Insufficient permissions", "10005"),
                new ErrorInfo(ErrorType.Unauthorized, false, "IP not whitelisted", "10010"),
                new ErrorInfo(ErrorType.Unauthorized, false, "IP has been banned", "10009"),
                new ErrorInfo(ErrorType.Unauthorized, false, "Banned", "10008"),
                new ErrorInfo(ErrorType.Unauthorized, false, "User authentication failed", "10007"),
                new ErrorInfo(ErrorType.Unauthorized, false, "Compliance rules triggered", "10024"),
                new ErrorInfo(ErrorType.Unauthorized, false, "Leveraged trading not allowed", "110068"),
                new ErrorInfo(ErrorType.Unauthorized, false, "KYC required", "131004", "131065", "20096"),
                new ErrorInfo(ErrorType.Unauthorized, false, "Withdrawal has been disabled for 24 hours after account update", "131089"),

                new ErrorInfo(ErrorType.RequestRateLimited, false, "Too many requests", "10006", "170222"),

                new ErrorInfo(ErrorType.InvalidParameter, false, "Parameter error", "10001", "170130", "131002", "131203"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Liquidation will be triggered immediately by this adjustment", "110011"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Invalid user id", "110018"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Invalid order id", "110019"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Allowable range: 5 to 2000 tick size", "110108"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Allowable range: 0.05% to 1%", "110109"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Invalid timeInForce", "170115"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Invalid orderType", "170116"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Invalid side", "170117"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "QuoteQuantity too many decimal places", "170137", "170148"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "StartTime exceeds endTime", "176004", "181009", "182202"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Memo/tag should not be set", "131081"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Invalid category", "181001"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Time between startTime and endTime should not exceed 7 days", "181010"),

                new ErrorInfo(ErrorType.MissingParameter, false, "BaseAsset parameter required", "3100326"),
                new ErrorInfo(ErrorType.MissingParameter, false, "Parameter value not provided", "170105"),
                new ErrorInfo(ErrorType.MissingParameter, false, "TP/SL price missing", "170202"),
                new ErrorInfo(ErrorType.MissingParameter, false, "Parameters startTime and endTime are both required", "181008", "182201"),

                new ErrorInfo(ErrorType.PriceInvalid, false, "Order price exceeds the allowable range", "110003"),
                new ErrorInfo(ErrorType.PriceInvalid, false, "Order price too low", "110120", "170133", "170194"),
                new ErrorInfo(ErrorType.PriceInvalid, false, "Order price too high", "110121", "170132", "170192", "170193"),
                new ErrorInfo(ErrorType.PriceInvalid, false, "Order price too many decimal places", "170134"),
                new ErrorInfo(ErrorType.PriceInvalid, false, "Invalid price for LimitMaker order", "170218"),

                new ErrorInfo(ErrorType.QuantityInvalid, false, "Order value below lower limit", "110094", "170140"),
                new ErrorInfo(ErrorType.QuantityInvalid, false, "Order quantity too large", "170124", "170135", "170341", "175009", "175013", "176026", "176027"),
                new ErrorInfo(ErrorType.QuantityInvalid, false, "Order quantity too small", "170136", "176025"),

                new ErrorInfo(ErrorType.UnknownSymbol, false, "Invalid symbol", "10029", "170121", "181012"),
                new ErrorInfo(ErrorType.UnknownOrder, false, "Order does not exist", "110001", "170213", "175007", "700004"),
                new ErrorInfo(ErrorType.UnknownAsset, false, "Invalid asset", "110050", "170221", "182204"),

                new ErrorInfo(ErrorType.BalanceInsufficient, false, "Insufficient balance", "110004", "110007", "110012", "110014", "110045", "110051", "110052", "110053", "170131", "175003", "175006", "176015", "131212", "131228"),
                new ErrorInfo(ErrorType.BalanceInsufficient, false, "The assets are estimated to be unable to cover the position margin", "110006"),
                new ErrorInfo(ErrorType.BalanceInsufficient, false, "Available margin is insufficient", "110044", "110047","170033"),

                new ErrorInfo(ErrorType.TargetIncorrectState, false, "Position status error", "110005"),
                new ErrorInfo(ErrorType.TargetIncorrectState, false, "The order has been completed or cancelled", "110008"),
                new ErrorInfo(ErrorType.TargetIncorrectState, false, "The order has been cancelled", "110010", "170142"),
                new ErrorInfo(ErrorType.TargetIncorrectState, false, "The position is in cross margin mode", "110015"),
                new ErrorInfo(ErrorType.TargetIncorrectState, false, "Position mode can't be switched when you have open positions", "110024"),
                new ErrorInfo(ErrorType.TargetIncorrectState, false, "Position mode can't be switched when you have open orders", "110028"),
                new ErrorInfo(ErrorType.TargetIncorrectState, true, "The order is processing and can not be operated, please try again later", "110079"),
                new ErrorInfo(ErrorType.TargetIncorrectState, false, "OrderStatus must be final status", "181017"),
                new ErrorInfo(ErrorType.TargetIncorrectState, false, "Order has been filled", "170139"),

                new ErrorInfo(ErrorType.SymbolNotTrading, false, "Settlement in progress", "110063"),
                new ErrorInfo(ErrorType.SymbolNotTrading, false, "Trading not currently allowed", "110066"),
                new ErrorInfo(ErrorType.SymbolNotTrading, false, "Symbol not trading", "110074", "176012"),
                new ErrorInfo(ErrorType.SymbolNotTrading, false, "Symbol not trading yet", "170151"),

                new ErrorInfo(ErrorType.NoPosition, false, "You can't set margin without an open position", "110033"),
                new ErrorInfo(ErrorType.NoPosition, false, "There is no net position", "110034"),

                new ErrorInfo(ErrorType.DuplicateClientOrderId, false, "Duplicate client order id", "110072", "170141"),

                new ErrorInfo(ErrorType.StopParametersInvalid, false, "Trigger price should be lower than current price", "110092"),
                new ErrorInfo(ErrorType.StopParametersInvalid, false, "Trigger price should be higher than current price", "110093"),
                new ErrorInfo(ErrorType.StopParametersInvalid, false, "Trigger price cannot be higher than 110% price", "170203"),
                new ErrorInfo(ErrorType.StopParametersInvalid, false, "Trigger price cannot be lower than 90% price", "170204"),

                new ErrorInfo(ErrorType.OrderConfigurationRejected, false, "Only GoodTillCanceled timeInForce supported in Call Auction mode", "110098"),
                new ErrorInfo(ErrorType.OrderConfigurationRejected, false, "Only PostOnly orders currently allowed", "110103"),
                new ErrorInfo(ErrorType.OrderConfigurationRejected, false, "Market order not allowed for new symbol", "170159"),
                new ErrorInfo(ErrorType.OrderConfigurationRejected, false, "Stop limit order not allowed for new symbol", "170206"),
                new ErrorInfo(ErrorType.OrderConfigurationRejected, false, "Only LimitMaker orders allowed for this symbol", "170217"),

                new ErrorInfo(ErrorType.OrderRateLimited, false, "Stop orders limit exceeded", "110009"),
                new ErrorInfo(ErrorType.OrderRateLimited, false, "Orders limit exceeded", "110020"),
                new ErrorInfo(ErrorType.OrderRateLimited, false, "Too many new orders", "170005"),
                new ErrorInfo(ErrorType.OrderRateLimited, false, "Not allowed to have more than 20 TP/SLs under Partial tpSlMode", "110061"),
                new ErrorInfo(ErrorType.OrderRateLimited, false, "Cannot exceed maximum of 500 conditional, TP/SL and active orders", "170810"),

                new ErrorInfo(ErrorType.InvalidOperation, false, "Only available for unified account", "10028"),
                new ErrorInfo(ErrorType.InvalidOperation, false, "Not available for unified account", "100028", "110067"),
            ]
        );

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

        protected override Error? TryParseError(KeyValuePair<string, string[]>[] responseHeaders, IMessageAccessor accessor)
        {
            var code = accessor.GetValue<int?>(MessagePath.Get().Property("retCode"));
            if (code != 10006)
                return null;

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

        /// <inheritdoc />
        protected override Error ParseErrorResponse(int httpStatusCode, KeyValuePair<string, string[]>[] responseHeaders, IMessageAccessor accessor, Exception? exception)
        {
            if (!accessor.IsValid)
                return new ServerError(ErrorInfo.Unknown, exception: exception);

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
