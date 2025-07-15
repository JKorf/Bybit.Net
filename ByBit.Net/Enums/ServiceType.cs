using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Service types
    /// </summary>
    [JsonConverter(typeof(EnumConverter<ServiceType>))]
    public enum ServiceType
    {
        /// <summary>
        /// Trading service
        /// </summary>
        [Map("1")]
        TradingService,
        /// <summary>
        /// Trading service REST
        /// </summary>
        [Map("2")]
        RestTradingService,
        /// <summary>
        /// Trading service Websocket
        /// </summary>
        [Map("3")]
        WebsocketTradingService,
        /// <summary>
        /// Private websocket stream
        /// </summary>
        [Map("4")]
        PrivateWebsocketStream,
        /// <summary>
        /// Market data service
        /// </summary>
        [Map("5")]
        MarketDataService
    }
}
