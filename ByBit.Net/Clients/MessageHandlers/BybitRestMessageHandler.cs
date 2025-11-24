using CryptoExchange.Net.Converters.MessageParsing;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Converters.SystemTextJson.MessageConverters;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
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

        public override async ValueTask<Error?> CheckForErrorResponse(RequestDefinition request, object? state, HttpResponseHeaders responseHeaders, Stream responseStream)
        {
            var (parseError, document) = await GetJsonDocument(responseStream, state).ConfigureAwait(false);
            if (parseError != null)
                return parseError;

            int? code = document!.RootElement.TryGetProperty("retCode", out var codeProp) ? codeProp.GetInt32() : null;
            if (code == null || code == 0)
                return null;

            var retMsg = document!.RootElement.TryGetProperty("retMsg", out var msgProp) ? msgProp.GetString() : null;
            if (code == 10006)
            {
                // Rate limit error
                var error = new ServerRateLimitError(retMsg);
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

            return new ServerError(code.Value, _errorMapping.GetErrorInfo(code.Value.ToString(), retMsg));
        }

        public override async ValueTask<Error> ParseErrorResponse(int httpStatusCode, object? state, HttpResponseHeaders responseHeaders, Stream responseStream)
        {
            if (httpStatusCode == 401)
                return new ServerError(new ErrorInfo(ErrorType.Unauthorized, "Unauthorized"));

            var (parseError, document) = await GetJsonDocument(responseStream, state).ConfigureAwait(false);
            if (parseError != null)
                return parseError;

            int? code = document!.RootElement.TryGetProperty("retCode", out var codeProp) ? codeProp.GetInt32() : null;
            var msg = document!.RootElement.TryGetProperty("retMsg", out var msgProp) ? msgProp.GetString() : null;

            return new ServerError(code!.Value, _errorMapping.GetErrorInfo(code.Value.ToString(), msg));
        }
    }
}
