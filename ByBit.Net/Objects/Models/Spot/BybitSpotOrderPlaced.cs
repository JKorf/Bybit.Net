using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Objects.Models.Spot
{
    /// <summary>
    /// Spot order info
    /// </summary>
    public class BybitSpotOrderPlaced: BybitSpotOrderBase
    {
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime TransactTime { get; set; }        
    }
}
