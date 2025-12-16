using Bybit.Net.Objects.Internal;
using CryptoExchange.Net.Converters.SystemTextJson.MessageHandlers;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.MessageHandlers
{
    internal class BybitRestMessageHandler : JsonRestMessageHandler
    {
        private readonly ErrorMapping _errorMapping;

        public override JsonSerializerOptions Options { get; } = SerializerOptions.WithConverters(BybitExchange._serializerContext);

        public BybitRestMessageHandler(ErrorMapping errorMapping)
        {
            _errorMapping = errorMapping;
        }


        public override Error? CheckDeserializedResponse<T>(HttpResponseHeaders responseHeaders, T result)
        {
            if (result is not BybitResult bybitResponse)
                return null;

            if (bybitResponse.ReturnCode == 0)
                return null;

            if (bybitResponse.ReturnCode == 10006)
            {
                // Rate limit error
                var error = new ServerRateLimitError(bybitResponse.ReturnMessage);
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

            return new ServerError(bybitResponse.ReturnCode, _errorMapping.GetErrorInfo(bybitResponse.ReturnCode.ToString(), bybitResponse.ReturnMessage));
        }

        public override async ValueTask<Error> ParseErrorResponse(int httpStatusCode, HttpResponseHeaders responseHeaders, Stream responseStream)
        {
            if (httpStatusCode == 401)
                return new ServerError(new ErrorInfo(ErrorType.Unauthorized, "Unauthorized"));

            var (parseError, document) = await GetJsonDocument(responseStream).ConfigureAwait(false);
            if (parseError != null)
                return parseError;

            int? code = document!.RootElement.TryGetProperty("retCode", out var codeProp) ? codeProp.GetInt32() : null;
            var msg = document!.RootElement.TryGetProperty("retMsg", out var msgProp) ? msgProp.GetString() : null;

            return new ServerError(code!.Value, _errorMapping.GetErrorInfo(code.Value.ToString(), msg));
        }
    }
}
