using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Bybit.Net.Interfaces.Clients.SpotApi;
using Newtonsoft.Json.Linq;

namespace Bybit.Net.Objects.Internal.Socket
{
    internal class BybitRequestMessage
    {
        [JsonProperty("op")]
        public string Operation { get; set; } = string.Empty;
        [JsonProperty("args")]
        public object[] Parameters { get; set; } = Array.Empty<object>();
    }

    internal class BybitDerivativesRequestMessage : BybitRequestMessage
    {
        [JsonProperty("req_id")]
        public string CustomisedId { get; set; } = string.Empty;
    }

    internal class BybitSpotRequestMessageV1 : BybitSpotRequestMessageV2, IBybitSpotRequestValidable
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;

        /// <inheritdoc />
        /// <remarks>  Got fallback message only in version 2,3. In version 1 we get a plain responseData </remarks>
        public new bool ValidateResponse(JToken responseData, ref bool forcedExit)
        {
            forcedExit = false;

            var symbols = responseData["symbol"]?.ToString().Split(',').ToList();
            var requestSymbols = Symbol?.Split(',').ToList();

            var success = responseData["data"]?.Any() ?? false;
            var topic = responseData["topic"]?.ToString();

            if (topic != null && !Operation.StartsWith(topic))
            {
                forcedExit = true;
                return success;
            }

            if (requestSymbols.Any(p => symbols?.Contains(p) != true))
            {
                forcedExit = true;
                return success;
            }

            return success;
        }

        /// <inheritdoc />
        public new bool MatchReponse(JToken responseData)
        {
            var topic = responseData["topic"]?.ToString();

            var symbol = responseData["symbol"]?.ToString();
            var requestSymbols = Symbol.Split(',').ToList();

            if (!Operation.StartsWith(topic))
                return false;

            if (!requestSymbols.Contains(symbol))
                return false;

            var klineInterval = responseData["params"]?["klineType"]?.ToString();
            if (klineInterval != null && Parameters.ContainsKey("klineType"))
            {
                if (klineInterval != (string)Parameters["klineType"])
                    return false;
            }

            return true;
        }
    }

    internal class BybitSpotRequestMessageV2 : IBybitSpotRequestValidable
    {
        [JsonProperty("topic")]
        public string Operation { get; set; } = string.Empty;
        [JsonProperty("params")]
        public Dictionary<string, object> Parameters { get; set; } = new Dictionary<string, object>();
        [JsonProperty("event")]
        public string Event { get; set; } = string.Empty;

        /// <inheritdoc />
        public bool ValidateResponse(JToken responseData, ref bool forcedExit)
        {
            forcedExit = false;
            var operation = responseData["event"]?.ToString();
            var success = responseData["msg"]?.Value<string>() == "Success";

            if (operation != "sub")
            {
                forcedExit = true;
                return success;
            }

            var symbols = responseData["params"]?["symbol"]?.ToString().Split(',').ToList();
            var requestSymbols = Parameters["symbol"]?.ToString().Split(',').ToList();
            var topic = responseData["topic"]?.ToString();

            if (topic != null && !Operation.StartsWith(topic))
            {
                forcedExit = true;
                return success;
            }

            if (requestSymbols.Any(p => symbols?.Contains(p) != true))
            {
                forcedExit = true;
                return success;
            }

            return success;
        }

        /// <inheritdoc />
        public bool MatchReponse(JToken responseData)
        {
            var topic = responseData["topic"]?.ToString();

            var symbol = responseData["params"]?["symbol"]?.ToString();
            var requestSymbols = Parameters["symbol"].ToString().Split(',').ToList();

            if (!Operation.StartsWith(topic))
                return false;

            if (!requestSymbols.Contains(symbol))
                return false;

            var klineInterval = responseData["params"]?["klineType"]?.ToString();
            if (klineInterval != null && Parameters.ContainsKey("klineType"))
            {
                if (klineInterval != (string)Parameters["klineType"])
                    return false;
            }

            return true;
        }
    }

    internal class BybitSpotRequestMessageV3 : IBybitSpotRequestValidable
    {
        [JsonProperty("req_id")]
        public string ID { get; set; } = string.Empty;
        [JsonProperty("op")]
        public string Operation { get; set; } = string.Empty;
        [JsonProperty("args")]
        public object[] Parameters { get; set; } = Array.Empty<object>();

        /// <inheritdoc />
        public bool ValidateResponse(JToken responseData, ref bool forcedExit)
        {
            forcedExit = false;
            var operation = responseData["op"]?.ToString();
            var success = responseData["success"]?.Value<bool>() == true;
            var req_id = responseData["req_id"]?.ToString();

            if (operation != "subscribe")
            {
                forcedExit = true;
                return success;
            }

            if (req_id != ID)
            {
                forcedExit = true;
                return success;
            }

            return success;
        }

        /// <inheritdoc />
        public bool MatchReponse(JToken responseData)
        {
            var topic = responseData["topic"]?.ToString();
            return Parameters.Any(p => topic == p.ToString());
        }
    }
}
