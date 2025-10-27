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
    /// Best bid/offset side type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BboSideType>))]
    public enum BboSideType
    {
        /// <summary>
        /// Use the order price on the orderbook in the same direction as the side
        /// </summary>
        [Map("Queue")]
        Queue,
        /// <summary>
        /// Use the order price on the orderbook in the opposite direction as the side
        /// </summary>
        [Map("Counterparty")]
        Counterparty
    }
}
